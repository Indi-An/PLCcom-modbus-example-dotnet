' MIT License
' Copyright (c) Indi.An GmbH
'
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

' ==============================================================================
' PLCcom for Modbus - Workshop 24: Role-Based Authorization
'
' SecureTCP certificate validation answers "who is connecting?". Role-based
' authorization answers "what may this peer do?". PLCcom keeps this decision in
' your application: if you assign an authorization validator, PLCcom passes the
' role name, function code and request context to it for every SecureTCP request.
'
' Essentials:
'   * Replace the license placeholders before running the sample.
'   * If no validator is configured, requests are allowed after TLS validation.
'   * Keep validators fast; they can be called for every Modbus request.
' ==============================================================================

Imports System.Net
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading
Imports PLCcomModbus.Core
Imports PLCcomModbus.Core.Security
Imports PLCcomModbus.Master
Imports PLCcomModbus.Slave

Namespace PLCcomModbus.Workshops.SecureTcp.RoleBasedAuthorization
    Friend Module Program
        ' -- License ----------------------------------------------------------
        ' TODO: Replace with your PLCcom Modbus license credentials.
        ' Keep the placeholders visible so SDK users see where credentials enter.
        Private Const LicenseUserName As String = "<Enter your UserName here>"
        Private Const LicenseSerial As String = "<Enter your Serial here>"

        Private Const OperatorRoleName As String = "Operator"
        Private Const ListenerId As String = "secure-role"
        Private Const ConnectHost As String = "127.0.0.1"
        Private Const CertificateHostName As String = "localhost"
        Private Const LoopbackPort As Integer = 802
        Private Const SlaveId As Byte = 1

        Public Sub Main()
            PrintHeader()

            Try
                ' -- Step 1: Configure certificates and a custom authorization validator
                ' before communication starts.
                ' The certificate is used for TLS trust; the validator enforces what each
                ' role can do on top of TLS authentication.
                Dim certificates As SecureTcpWorkshopCertificates = SecureTcpWorkshopCertificates.Create(OperatorRoleName)

                Dim slaveOptions As New SecureModbusTcpOptions()
                slaveOptions.LocalCertificate = certificates.ServerCertificate
                slaveOptions.TrustedRemoteCertificates.Add(certificates.RootCertificate)
                ' Validator runs for every request; keep it simple and deterministic.
                slaveOptions.AuthorizationValidator = New OperatorReadOnlyAuthorizationValidator()

                Dim masterOptions As New SecureModbusTcpOptions()
                masterOptions.LocalCertificate = certificates.ClientCertificate
                masterOptions.TrustedRemoteCertificates.Add(certificates.RootCertificate)
                masterOptions.TargetHostName = CertificateHostName

                Using slave As ModbusSlave = CreateRoleProtectedSlave(slaveOptions)
                    RunOperatorClient(masterOptions)
                    slave.RemoveListener(ListenerId)
                End Using
            Catch ex As Exception
                Console.WriteLine("Workshop failed: " & ex.Message)
            End Try

            Console.WriteLine()
            Console.WriteLine("Press ENTER to exit.")
            Console.ReadLine()
        End Sub

        Private Function CreateRoleProtectedSlave(slaveOptions As SecureModbusTcpOptions) As ModbusSlave
            ' -- Step 2: Start the role-protected slave ---------------------
            ' Authorization is enforced by the slave. This local listener keeps
            ' the workshop self-contained while showing the same validator hook
            ' used by a production SecureTCP slave.
            Dim slave As New ModbusSlave(LicenseUserName, LicenseSerial, SlaveId)

            Try
                slave.SetValue(0, eModbusRegion.HoldingRegister, CUShort(802))
                slave.SetValue(1, eModbusRegion.HoldingRegister, CUShort(803))

                ' Listener key is fixed so you can open/close one secure endpoint for experiments.
                slave.AddOrReplaceListener_SecureTCP(ListenerId, LoopbackPort, slaveOptions)
                Thread.Sleep(250)
                Return slave
            Catch
                slave.Dispose()
                Throw
            End Try
        End Function

        Private Sub RunOperatorClient(masterOptions As SecureModbusTcpOptions)
            ' -- Step 3: Connect the master through SecureTCP --------------
            ' The master is a local test client. Its certificate carries role
            ' "Operator", so the validator can decide from authenticated
            ' certificate content and the Modbus function code.
            Using master As New ModbusMaster(LicenseUserName, LicenseSerial)
                master.SetConnector_SecureTCP(ConnectHost, LoopbackPort, masterOptions)
                master.RegisterMode = eRegisterMode._16Bit

                ' -- Step 4: Execute an allowed read request ----------------
                ' The validator allows read functions for role "Operator".
                Dim readRequest As ReadRequest = RequestBuilder.ReadRequestBuilder.Create(
                    SlaveId,
                    eReadFunction.F03_Read_Holding_Registers,
                    0,
                    eDataType.USHORT,
                    2)
                readRequest.ByteOrder = eByteOrder.AB_CD

                Dim readResult As ReadResult = master.Read(readRequest)
                Console.WriteLine("Operator read: " & readResult.Message)

                ' -- Step 5: Execute a denied write request -----------------
                ' Function 16 is a write operation. The sample policy rejects
                ' it for role "Operator" and the slave returns a Modbus
                ' exception instead of changing the data.
                Dim deniedWrite As WriteRequest = RequestBuilder.WriteRequestBuilder.Create(
                    SlaveId,
                    eWriteFunction.F16_Write_Multiple_Registers,
                    0)
                deniedWrite.AddRange(New UShort() {900})

                Dim writeResult As WriteResult = master.Write(deniedWrite)
                Console.WriteLine("Operator write: " & writeResult.Message)
            End Using
        End Sub

        ' -- Console output ---------------------------------------------------
        Private Sub PrintHeader()
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗")
            Console.WriteLine("║ PLCcom for Modbus - Workshop 24: Role-Based Authorization            ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ Adds an application-controlled authorization decision after          ║")
            Console.WriteLine("║ certificate validation.                                              ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ What you will learn:                                                 ║")
            Console.WriteLine("║   * Read the SecureTCP role from the client certificate              ║")
            Console.WriteLine("║   * Implement a fast authorization validator                         ║")
            Console.WriteLine("║   * Return Modbus exception 01 for denied requests                   ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ Self-contained SecureTCP loopback workshop                           ║")
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝")
            Console.WriteLine()
        End Sub

        ' -- Authorization policy -------------------------------------------
        ' PLCcom calls this validator after certificate validation and before
        ' executing the Modbus request. Returning False blocks the request at
        ' the slave side. Keep production implementations fast because this can
        ' run for every request on a busy connection.
        Private NotInheritable Class OperatorReadOnlyAuthorizationValidator
            Implements ISecureModbusAuthorizationValidator

            Public Function Validate(context As SecureModbusAuthorizationContext) As Boolean Implements ISecureModbusAuthorizationValidator.Validate
                ' A null role means caller did not include role extension; reject by default.
                If Not String.Equals(context.RoleName, OperatorRoleName, StringComparison.Ordinal) Then
                    Return False
                End If

                Select Case context.FunctionCode
                    Case 1, 2, 3, 4
                        ' Read operations are read-only allowed for the Operator role.
                        Return True
                    Case Else
                        ' Write and other function codes are denied in this sample policy.
                        Return False
                End Select
            End Function
        End Class

        ' -- Certificate setup ----------------------------------------------
        ' This workshop generates a local root CA and two endpoint certificates
        ' so the authorization flow can be demonstrated without preparing files
        ' in a PKI store. In production, load these objects from the PLCcom PKI
        ' structure or from your enterprise certificate management process.
        Private NotInheritable Class SecureTcpWorkshopCertificates
            Friend Property RootCertificate As X509Certificate2
            Friend Property ServerCertificate As X509Certificate2
            Friend Property ClientCertificate As X509Certificate2

            Friend Shared Function Create(clientRoleName As String) As SecureTcpWorkshopCertificates
                Dim certificates As New SecureTcpWorkshopCertificates()

                ' The temporary root CA signs the slave and master certificates.
                ' Trusting this root on both sides is enough for the local TLS
                ' handshake in this workshop.
                Using rootKey As RSA = RSA.Create(2048)
                    Dim rootRequest As New CertificateRequest(
                        "CN=PLCcom Modbus Workshop Root",
                        rootKey,
                        HashAlgorithmName.SHA256,
                        RSASignaturePadding.Pkcs1)
                    rootRequest.CertificateExtensions.Add(New X509BasicConstraintsExtension(True, False, 0, True))
                    rootRequest.CertificateExtensions.Add(New X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign Or X509KeyUsageFlags.CrlSign, True))
                    rootRequest.CertificateExtensions.Add(New X509SubjectKeyIdentifierExtension(rootRequest.PublicKey, False))

                    Using rootWithoutPrivateKey As X509Certificate2 = rootRequest.CreateSelfSigned(
                        DateTimeOffset.UtcNow.AddDays(-1),
                        DateTimeOffset.UtcNow.AddDays(7))
                        certificates.RootCertificate = ExportableCopy(rootWithoutPrivateKey)
                    End Using
                End Using

                ' The server certificate identifies the slave. The client
                ' certificate identifies the master and carries the role marker
                ' that will later be passed to the validator.
                certificates.ServerCertificate = CreateEndpointCertificate(certificates.RootCertificate, "PLCcom Modbus Workshop Server", True, Nothing)
                certificates.ClientCertificate = CreateEndpointCertificate(certificates.RootCertificate, "PLCcom Modbus Workshop Client", False, clientRoleName)

                Return certificates
            End Function

            Private Shared Function CreateEndpointCertificate(issuerCertificate As X509Certificate2, commonName As String, server As Boolean, roleName As String) As X509Certificate2
                Using endpointKey As RSA = RSA.Create(2048)
                    ' Endpoint certificates are signed by the temporary root
                    ' CA. They are not allowed to sign other certificates.
                    Dim request As New CertificateRequest(
                        "CN=" & commonName,
                        endpointKey,
                        HashAlgorithmName.SHA256,
                        RSASignaturePadding.Pkcs1)

                    request.CertificateExtensions.Add(New X509BasicConstraintsExtension(False, False, 0, True))
                    request.CertificateExtensions.Add(New X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, True))
                    request.CertificateExtensions.Add(New X509SubjectKeyIdentifierExtension(request.PublicKey, False))
                    request.CertificateExtensions.Add(New X509EnhancedKeyUsageExtension(
                        New OidCollection From {New Oid(If(server, "1.3.6.1.5.5.7.3.1", "1.3.6.1.5.5.7.3.2"))},
                        False))

                    If server Then
                        ' Server identity values are used by hostname validation at connect time.
                        Dim sanBuilder As New SubjectAlternativeNameBuilder()
                        sanBuilder.AddDnsName(CertificateHostName)
                        sanBuilder.AddIpAddress(IPAddress.Parse(ConnectHost))
                        request.CertificateExtensions.Add(sanBuilder.Build())
                    End If

                    ' The role extension is optional in the standard. When it is
                    ' missing, PLCcom passes Nothing to the validator instead.
                    ' This workshop adds it only to the client certificate.
                    If Not String.IsNullOrWhiteSpace(roleName) Then
                        request.CertificateExtensions.Add(SecureModbusRoleExtension.Create(roleName, False))
                    End If

                    Dim serialNumber(15) As Byte
                    Using randomNumberGenerator As RandomNumberGenerator = RandomNumberGenerator.Create()
                        randomNumberGenerator.GetBytes(serialNumber)
                    End Using

                    Using endpointWithoutPrivateKey As X509Certificate2 = request.Create(
                        issuerCertificate,
                        DateTimeOffset.UtcNow.AddDays(-1),
                        issuerCertificate.NotAfter.AddMinutes(-1),
                        serialNumber)
                        ' Return a loaded PKCS#12 version to ensure private key can be used by the TLS stack.
                        Return ExportableCopy(endpointWithoutPrivateKey.CopyWithPrivateKey(endpointKey))
                    End Using
                End Using
            End Function

            Private Shared Function ExportableCopy(certificate As X509Certificate2) As X509Certificate2
                ' Reloading from PKCS#12 avoids platform-specific private key
                ' handle issues and keeps this workshop independent of the
                ' Windows certificate store.
                Dim pfx As Byte() = certificate.Export(X509ContentType.Pfx, String.Empty)
                Return X509CertificateLoader.LoadPkcs12(
                    pfx,
                    String.Empty,
                    X509KeyStorageFlags.Exportable Or X509KeyStorageFlags.EphemeralKeySet,
                    Pkcs12LoaderLimits.Defaults)
            End Function
        End Class
    End Module
End Namespace

