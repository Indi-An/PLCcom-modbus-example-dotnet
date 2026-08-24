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
' PLCcom for Modbus - Workshop 23: Mutual TLS Loopback
'
' Secure Modbus TCP uses TLS on both sides of the connection. The slave presents
' a server certificate, the master presents a client certificate, and both peers
' trust the same workshop root CA. That is mutual TLS: transport encryption plus
' authenticated identities on master and slave side.
'
' What you will learn:
'   * How to configure SecureTCP certificates without using the PKI folders
'   * Why both peers need a local certificate for mutual TLS
'   * How a normal Modbus read/write cycle looks once the TLS tunnel is established
'
' This workshop starts a local slave in the same process so the full scenario is
' reproducible. Workshop 24 builds on this and adds role-based authorization.
' ==============================================================================

Imports System.Net
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading
Imports PLCcomModbus.Core
Imports PLCcomModbus.Core.Security
Imports PLCcomModbus.Master
Imports PLCcomModbus.Slave

Namespace PLCcomModbus.Workshops.SecureTcp.MutualTLSLoopback
    Friend Module Program
        ' Important !!!!!!!!!!!!!!!!!!
        ' Enter your Username + Serial here! Please note: with blank fields the library runs
        ' for 15 minutes during a debug session. Both values can also come
        ' from configuration or an environment variable.
        ' Free trial license (14 days, uninterrupted): https://www.indi-an.com/en/plccom/modbus/modbus-download/
        Private Const LicenseUserName As String = ""
        Private Const LicenseSerial As String = ""

        Private Const ListenerId As String = "secure-mutualtls-loopback"
        Private Const ConnectHost As String = "127.0.0.1"
        Private Const CertificateHostName As String = "localhost"
        Private Const LoopbackPort As Integer = SecureModbusTcpOptions.DefaultSecureModbusTcpPort
        Private Const SlaveId As Byte = 1

        Public Sub Main()
            PrintHeader()

            Try
                ' -- Step 1: Create a local certificate chain --------------
                ' Create a short-lived root CA and two endpoint certificates.
                ' The server certificate identifies the slave; the client
                ' certificate identifies the master during the TLS handshake.
                Dim certificates As SecureTcpWorkshopCertificates = SecureTcpWorkshopCertificates.Create()

                ' -- Step 2: Assign certificates to both SecureTCP peers ----
                ' Both peers trust the same root certificate. The slave uses
                ' the server certificate, the master uses the client certificate.
                Dim slaveOptions As New SecureModbusTcpOptions()
                slaveOptions.LocalCertificate = certificates.ServerCertificate
                slaveOptions.TrustedRemoteCertificates.Add(certificates.RootCertificate)

                Dim masterOptions As New SecureModbusTcpOptions()
                masterOptions.LocalCertificate = certificates.ClientCertificate
                masterOptions.TrustedRemoteCertificates.Add(certificates.RootCertificate)
                masterOptions.TargetHostName = CertificateHostName

                Using slave As New ModbusSlave(LicenseUserName, LicenseSerial, SlaveId)
                    Using master As New ModbusMaster(LicenseUserName, LicenseSerial)
                        ' -- Step 3: Start the local SecureTCP slave --------
                        ' Seed deterministic register values before the secure listener is opened.
                        slave.SetValue(0, eModbusRegion.HoldingRegister, CUShort(2300))
                        slave.SetValue(1, eModbusRegion.HoldingRegister, CUShort(2301))

                        ' The listener receives TLS connections and validates the
                        ' client certificate against the trusted workshop root.
                        slave.AddOrReplaceListener_SecureTCP(ListenerId, LoopbackPort, slaveOptions)
                        Thread.Sleep(250)

                        ' -- Step 4: Connect the master through SecureTCP ---
                        ' From here on the request code is normal Modbus. SecureTCP
                        ' protects the transport; it does not change the read/write API.
                        master.SetConnector_SecureTCP(ConnectHost, LoopbackPort, masterOptions)
                        master.RegisterMode = eRegisterMode._16Bit

                        ' -- Step 5: Read, write and verify holding registers
                        Dim readRequest As ReadRequest = RequestBuilder.ReadRequestBuilder.Create(
                            SlaveId,
                            eReadFunction.F03_Read_Holding_Registers,
                            0,
                            eDataType.USHORT,
                            2)
                        readRequest.ByteOrder = eByteOrder.AB_CD
                        PrintReadResult("Initial SecureTCP read", master.Read(readRequest))

                        ' Function 16 writes the two demo values back to the same
                        ' holding-register range that was read above.
                        Dim writeRequest As WriteRequest = RequestBuilder.WriteRequestBuilder.Create(
                            SlaveId,
                            eWriteFunction.F16_Write_Multiple_Registers,
                            0)
                        writeRequest.AddRange(New UShort() {2310, 2311})
                        PrintWriteResult("SecureTCP write", master.Write(writeRequest))

                        PrintReadResult("Read back after SecureTCP write", master.Read(readRequest))

                        ' Remove the named listener explicitly before disposing the slave.
                        slave.RemoveListener(ListenerId)
                    End Using
                End Using
            Catch ex As Exception
                Console.WriteLine("Workshop failed: " & ex.Message)
            End Try

            Console.WriteLine()
            Console.WriteLine("Press ENTER to exit.")
            Console.ReadLine()
        End Sub

        Private Sub PrintHeader()
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗")
            Console.WriteLine("║ PLCcom for Modbus - Workshop 23: Mutual TLS Loopback                ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ Starts one local SecureTCP slave and connects with a SecureTCP       ║")
            Console.WriteLine("║ master. Both peers use certificates signed by the same root CA.      ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ What you will learn:                                                 ║")
            Console.WriteLine("║   * Configure server and client certificates for mutual TLS          ║")
            Console.WriteLine("║   * Trust a shared root CA without using PKI folders                 ║")
            Console.WriteLine("║   * Run a normal Modbus read/write cycle over SecureTCP              ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ Self-contained endpoint: 127.0.0.1:802                               ║")
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝")
            Console.WriteLine()
        End Sub

        Private Sub PrintReadResult(title As String, result As ReadResult)
            Console.WriteLine(title & ": " & result.Message)

            If result.Quality <> OperationResult.eQuality.GOOD Then
                Console.WriteLine()
                Return
            End If

            For Each value As ReadValue In result.FetchValues()
                Console.WriteLine("  Holding register {0} = {1}", value.Address, value.Value)
            Next

            Console.WriteLine()
        End Sub

        Private Sub PrintWriteResult(title As String, result As WriteResult)
            Console.WriteLine(title & ": " & result.Message)
            Console.WriteLine()
        End Sub

        ' -- Certificate setup ----------------------------------------------
        ' The following helper keeps the certificate mechanics in this file so
        ' the workshop is reproducible without external PKI preparation. A
        ' production application would normally load these certificates from
        ' the PLCcom PKI store or from a company-managed certificate authority.
        Private NotInheritable Class SecureTcpWorkshopCertificates
            Friend Property RootCertificate As X509Certificate2
            Friend Property ServerCertificate As X509Certificate2
            Friend Property ClientCertificate As X509Certificate2

            Friend Shared Function Create() As SecureTcpWorkshopCertificates
                Dim certificates As New SecureTcpWorkshopCertificates()

                ' The temporary root CA signs both endpoint certificates. Both
                ' peers trust this root, so the master accepts the slave and
                ' the slave accepts the master during the TLS handshake.
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

                ' The server certificate is presented by the slave. The client
                ' certificate is presented by the master. They deliberately use
                ' different extended key usages so the TLS stack can distinguish
                ' server authentication from client authentication.
                certificates.ServerCertificate = CreateEndpointCertificate(certificates.RootCertificate, "PLCcom Modbus Workshop Server", True)
                certificates.ClientCertificate = CreateEndpointCertificate(certificates.RootCertificate, "PLCcom Modbus Workshop Client", False)
                Return certificates
            End Function

            Private Shared Function CreateEndpointCertificate(issuerCertificate As X509Certificate2, commonName As String, server As Boolean) As X509Certificate2
                Using endpointKey As RSA = RSA.Create(2048)
                    ' Endpoint certificates are signed by the temporary root
                    ' CA. They are not certificate authorities themselves.
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
                        ' The master validates the slave certificate against
                        ' TargetHostName. For loopback testing, the certificate
                        ' therefore contains both localhost and 127.0.0.1.
                        Dim sanBuilder As New SubjectAlternativeNameBuilder()
                        sanBuilder.AddDnsName(CertificateHostName)
                        sanBuilder.AddIpAddress(IPAddress.Parse(ConnectHost))
                        request.CertificateExtensions.Add(sanBuilder.Build())
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
                        ' CopyWithPrivateKey attaches the generated key to the
                        ' public certificate. ExportableCopy then reloads it as
                        ' a PKCS#12 object that the TLS layer can consume.
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
