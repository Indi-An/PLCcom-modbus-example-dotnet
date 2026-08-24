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
' PLCcom for Modbus - Workshop 21: SecureTCP Master
'
' Secure Modbus TCP keeps the normal Modbus TCP telegram format and protects the
' connection with mutual TLS. This master creates an OPC UA-style PKI store and
' installs a deliberately unsafe workshop validator that accepts every remote
' server certificate so the SecureTCP mechanics can be tested immediately.
'
' Essentials:
'   * Replace the license placeholders before running the sample.
'   * Start Workshop 22 or another Secure Modbus TCP slave.
'   * RemoteCertificateValidator decides whether the server certificate is accepted.
'   * Remove the accept-all validator assignment to test the normal PKI workflow.
' ==============================================================================

Imports System.Net
Imports PLCcomModbus.Core
Imports PLCcomModbus.Core.Security
Imports PLCcomModbus.Master

Namespace PLCcomModbus.Workshops.SecureTcp.SecureTcpMaster
    Friend Module Program
        ' Important !!!!!!!!!!!!!!!!!!
        ' Enter your Username + Serial here! Please note: with blank fields the library runs
        ' for 15 minutes during a debug session. Both values can also come
        ' from configuration or an environment variable.
        ' Free trial license (14 days, uninterrupted): https://www.indi-an.com/en/plccom/modbus/modbus-download/
        Private Const LicenseUserName As String = ""
        Private Const LicenseSerial As String = ""

        Private Const SlaveHost As String = "127.0.0.1"
        Private Const ExpectedCertificateHostName As String = "localhost"
        Private Const SecureTcpPort As Integer = SecureModbusTcpOptions.DefaultSecureModbusTcpPort
        Private Const SlaveId As Byte = 1

        Public Sub Main()
            PrintHeader()

            Try
                ' -- Step 1: Prepare the SecureTCP policy -------------------
                ' The options object describes the TLS and certificate behavior.
                ' The Modbus request built below is still the normal F03 request.
                Dim options As SecureModbusTcpOptions = CreateSecureTcpOptions()

                Using master As New ModbusMaster(LicenseUserName, LicenseSerial)
                    ' -- Step 2: Select SecureTCP as transport --------------
                    ' SetConnector_SecureTCP opens a Modbus TCP connection through
                    ' a TLS tunnel. The Modbus request itself stays unchanged.
                    master.SetConnector_SecureTCP(SlaveHost, SecureTcpPort, options)
                    master.RegisterMode = eRegisterMode._16Bit

                    ' -- Step 3: Create and execute a normal Modbus request -
                    ' SecureTCP protects the connection. The application still
                    ' creates the same read request it would use for plain TCP.
                    Dim readRequest As ReadRequest = RequestBuilder.ReadRequestBuilder.Create(
                        SlaveId,
                        eReadFunction.F03_Read_Holding_Registers,
                        0,
                        eDataType.USHORT,
                        4)
                    ' Explicit byte order keeps the sample deterministic.
                    readRequest.ByteOrder = eByteOrder.AB_CD

                    Console.WriteLine("Reading via SecureTCP from {0}:{1}.", SlaveHost, SecureTcpPort)
                    Dim result As ReadResult = master.Read(readRequest)
                    Console.WriteLine("Result: " & result.Message)

                    If result.Quality = OperationResult.eQuality.GOOD Then
                        For Each value As ReadValue In result.FetchValues()
                            ' On GOOD quality, every fetched value maps to logical address/value
                            ' pairs exactly as requested in the request object.
                            Console.WriteLine("  Holding register {0} = {1}", value.Address, value.Value)
                        Next
                    End If
                End Using
            Catch ex As Exception
                Console.WriteLine("Workshop failed: " & ex.Message)
                Console.WriteLine("If the accept-all validator is disabled, unknown certificates are written to rejected/certs for review.")
            End Try

            Console.WriteLine()
            Console.WriteLine("Press ENTER to exit.")
            Console.ReadLine()
        End Sub

        Private Function CreateSecureTcpOptions() As SecureModbusTcpOptions
            ' Keep PKI store path local to the sample to avoid side effects in other examples.
            Dim pkiStore As New SecureModbusPkiStore(".\pki\securetcp-master")
            pkiStore.EnsureDirectories()
            AddHandler pkiStore.CertificateStored, AddressOf OnCertificateStored
            PrintPkiStoreLayout(pkiStore)

            ' The master keeps one own certificate for TLS client authentication and one
            ' local PKI area that can hold trusted/rejected/issuer/own certificates.
            ' The folder layout is created automatically at first access.

            Dim ownCertificate As New SecureModbusOwnCertificate(
                pkiStore,
                "PLCcom Modbus Workshop Master",
                "workshop-password",
                3650,
                "Indi.An GmbH",
                New String() {"localhost"},
                New IPAddress() {IPAddress.Parse("127.0.0.1")})

            Dim options As New SecureModbusTcpOptions()
            options.PkiStore = pkiStore
            options.OwnCertificate = ownCertificate

            ' PKI default behavior when RemoteCertificateValidator is NOT set:
            '   * own/certs and own/private contain this master's certificate
            '     and private key. SecureModbusOwnCertificate creates them on
            '     first use if no valid certificate exists yet.
            '   * trusted/certs contains remote leaf certificates that are
            '     trusted directly. They are accepted only while their validity
            '     period is still OK.
            '   * issuers/certs contains CA or issuer certificates. If a remote
            '     certificate chains to one of these issuers and the chain is
            '     valid, PLCcom copies the leaf certificate to trusted/certs and
            '     accepts the connection.
            '   * rejected/certs receives unknown, expired, host-name-mismatched
            '     or otherwise invalid remote certificates. The connection is
            '     rejected so an operator can review and move trust material.
            '
            ' Workshop-only override:
            ' Assigning RemoteCertificateValidator disables that automatic
            ' certificate-level PKI decision. This intentionally unsafe validator
            ' returns True for every server certificate so the user can see how
            ' the validator hook works without preparing trusted certificates.
            options.RemoteCertificateValidator = New UnsafeAcceptAllCertificateValidator("SecureTCP server")

            ' This validation name should match the expected server certificate identity.
            options.TargetHostName = ExpectedCertificateHostName

            ' Start with Auto protocol selection for broad interoperability.
            options.TlsProtocolMode = SecureModbusTlsProtocolMode.Auto
            Return options
        End Function

        Private Sub OnCertificateStored(sender As Object, e As SecureModbusPkiCertificateStoredEventArgs)
            ' In this workshop, every newly seen remote certificate is just
            ' announced. The operator can move it to trusted after manual review.
            Console.WriteLine("PKI {0}: {1}", e.StoreKind, e.FilePath)
        End Sub

        Private Sub PrintPkiStoreLayout(pkiStore As SecureModbusPkiStore)
            Console.WriteLine("PKI store:")
            Console.WriteLine("  own/certs      : {0}", pkiStore.OwnCertificatesPath)
            Console.WriteLine("  own/private    : {0}", pkiStore.OwnPrivatePath)
            Console.WriteLine("  trusted/certs  : {0}", pkiStore.TrustedCertificatesPath)
            Console.WriteLine("  issuers/certs  : {0}", pkiStore.IssuerCertificatesPath)
            Console.WriteLine("  rejected/certs : {0}", pkiStore.RejectedCertificatesPath)
            Console.WriteLine()
        End Sub

        ' -- Certificate validation -----------------------------------------
        ' Deliberately insecure workshop validator. It is useful when the
        ' workshop should focus on SecureTCP mechanics and not on trust-store
        ' administration. Do not use this policy in production.
        Private NotInheritable Class UnsafeAcceptAllCertificateValidator
            Implements ISecureModbusCertificateValidator

            Private ReadOnly mRemoteEndpointName As String

            Friend Sub New(remoteEndpointName As String)
                mRemoteEndpointName = remoteEndpointName
            End Sub

            Public Function Validate(context As SecureModbusCertificateValidationContext) As Boolean Implements ISecureModbusCertificateValidator.Validate
                Console.WriteLine("WARNING: accepting every {0} certificate.", mRemoteEndpointName)
                Console.WriteLine("         PKI trust checks are bypassed by this workshop validator.")
                Console.WriteLine("         Remote chain length: {0}", context.RemoteCertificateChain.Length)

                For Each certificate In context.RemoteCertificateChain
                    Console.WriteLine("         {0}", certificate.Subject)
                Next

                Return True
            End Function
        End Class

        ' -- Console output ---------------------------------------------------
        Private Sub PrintHeader()
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗")
            Console.WriteLine("║ PLCcom for Modbus - Workshop 21: SecureTCP Master                    ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ Connects a Modbus master through Secure Modbus TCP with mutual TLS.  ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ What you will learn:                                                 ║")
            Console.WriteLine("║   * Configure the SecureTCP connector                                ║")
            Console.WriteLine("║   * See how the PKI store is structured                              ║")
            Console.WriteLine("║   * Override certificate validation with an accept-all validator     ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ Required peer: Workshop 22 on 127.0.0.1:802                          ║")
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝")
            Console.WriteLine()
        End Sub
    End Module
End Namespace

