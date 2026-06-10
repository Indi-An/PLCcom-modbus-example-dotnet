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
' PLCcom for Modbus - Workshop 22: SecureTCP Slave
'
' This workshop starts a Secure Modbus TCP slave. It creates an OPC UA-style PKI
' store and installs a deliberately unsafe workshop validator that accepts every
' remote client certificate so the SecureTCP mechanics can be tested immediately.
'
' Essentials:
'   * Replace the license placeholders before running the sample.
'   * Secure Modbus TCP uses port 802 by default.
'   * Pair this workshop with Workshop 21 to see certificate validation callbacks.
'   * Remove the accept-all validator assignment to test the normal PKI workflow.
' ==============================================================================

Imports System.Net
Imports PLCcomModbus.Core
Imports PLCcomModbus.Core.Security
Imports PLCcomModbus.DataAdapter
Imports PLCcomModbus.Slave

Namespace PLCcomModbus.Workshops.SecureTcp.SecureTcpSlave
    Friend Module Program
        ' -- License ----------------------------------------------------------
        ' TODO: Replace with your PLCcom Modbus license credentials.
        ' Keep the placeholders visible so SDK users see where credentials enter.
        Private Const LicenseUserName As String = "<Enter your UserName here>"
        Private Const LicenseSerial As String = "<Enter your Serial here>"

        Private Const ListenerId As String = "securetcp"
        Private Const SecureTcpPort As Integer = SecureModbusTcpOptions.DefaultSecureModbusTcpPort
        Private Const SlaveId As Byte = 1

        Public Sub Main()
            PrintHeader()

            Try
                ' -- Step 1: Prepare the SecureTCP listener policy ---------
                ' The listener refuses unknown clients until their certificate
                ' is trusted directly or through an issuer certificate.
                Dim options As SecureModbusTcpOptions = CreateSecureTcpOptions()

                Using slave As New ModbusSlave(LicenseUserName, LicenseSerial, SlaveId)
                    ' -- Step 2: Enable basic diagnostics -------------------
                    ' The same events are useful for plain TCP and SecureTCP.
                    ' They show listener state changes and incoming telegrams.
                    AddHandler slave.OnPortStateChange, AddressOf OnPortStateChange
                    AddHandler slave.OnIncomingLogEntry, AddressOf OnIncomingLogEntry

                    ' -- Step 3: Prepare readable sample data --------------
                    ' Seed sample values to verify read paths immediately from a client.
                    slave.SetValue(0, eModbusRegion.HoldingRegister, CUShort(700))
                    slave.SetValue(1, eModbusRegion.HoldingRegister, CUShort(701))
                    slave.SetValue(2, eModbusRegion.HoldingRegister, CUShort(702))
                    slave.SetValue(3, eModbusRegion.HoldingRegister, CUShort(703))

                    ' -- Step 4: Start the SecureTCP listener --------------
                    ' The listener name is an application-level key. Use it to
                    ' replace or remove this listener while the slave is running.
                    slave.AddOrReplaceListener_SecureTCP(ListenerId, SecureTcpPort, options)

                    ' Keep the listener alive while the operator performs connection and certificate tests.
                    Console.WriteLine("SecureTCP slave is listening on port {0}.", SecureTcpPort)
                    Console.WriteLine("Start Workshop 21 in another console to connect as master.")
                    Console.WriteLine("Press ENTER to stop.")
                    Console.ReadLine()

                    slave.RemoveListener(ListenerId)
                End Using
            Catch ex As Exception
                Console.WriteLine("Workshop failed: " & ex.Message)
                Console.WriteLine("Press ENTER to exit.")
                Console.ReadLine()
            End Try
        End Sub

        Private Function CreateSecureTcpOptions() As SecureModbusTcpOptions
            ' The slave-side PKI store is the operator workflow: unknown
            ' client certificates land in rejected/certs and must be reviewed.
            ' The folder structure is created automatically on first access.
            Dim pkiStore As New SecureModbusPkiStore(".\pki\securetcp-slave")
            pkiStore.EnsureDirectories()
            AddHandler pkiStore.CertificateStored, AddressOf OnCertificateStored
            PrintPkiStoreLayout(pkiStore)

            Dim ownCertificate As New SecureModbusOwnCertificate(
                pkiStore,
                "PLCcom Modbus Workshop Slave",
                "workshop-password",
                3650,
                "Indi.An GmbH",
                New String() {"localhost"},
                New IPAddress() {IPAddress.Parse("127.0.0.1")})

            Dim options As New SecureModbusTcpOptions()
            options.PkiStore = pkiStore
            options.OwnCertificate = ownCertificate

            ' PKI default behavior when RemoteCertificateValidator is NOT set:
            '   * own/certs and own/private contain this slave's certificate
            '     and private key. SecureModbusOwnCertificate creates them on
            '     first use if no valid certificate exists yet.
            '   * trusted/certs contains remote client certificates that are
            '     trusted directly. They are accepted only while their validity
            '     period is still OK.
            '   * issuers/certs contains CA or issuer certificates. If a remote
            '     client certificate chains to one of these issuers and the chain
            '     is valid, PLCcom copies the leaf certificate to trusted/certs
            '     and accepts the connection.
            '   * rejected/certs receives unknown, expired or otherwise invalid
            '     remote client certificates. The connection is rejected so an
            '     operator can review and move trust material.
            '
            ' Workshop-only override:
            ' Assigning RemoteCertificateValidator disables that automatic
            ' certificate-level PKI decision. This intentionally unsafe validator
            ' returns True for every client certificate so the user can see how
            ' the validator hook works without preparing trusted certificates.
            options.RemoteCertificateValidator = New UnsafeAcceptAllCertificateValidator("SecureTCP client")

            ' Auto protocol mode is useful for workshop starts and validation.
            options.TlsProtocolMode = SecureModbusTlsProtocolMode.Auto
            Return options
        End Function

        Private Sub OnCertificateStored(sender As Object, e As SecureModbusPkiCertificateStoredEventArgs)
            ' This callback is called as soon as a remote certificate lands in a PKI store.
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

        Private Sub OnPortStateChange(sender As Object, state As eConnectionState)
            Console.WriteLine("Listener state: " & state.ToString())
        End Sub

        Private Sub OnIncomingLogEntry(entries As LogEntry())
            For Each entry As LogEntry In entries
                Console.WriteLine(entry.ToString())
            Next
        End Sub

        ' -- Console output ---------------------------------------------------
        Private Sub PrintHeader()
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗")
            Console.WriteLine("║ PLCcom for Modbus - Workshop 22: SecureTCP Slave                     ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ Starts a Secure Modbus TCP slave with a PKI store and a local        ║")
            Console.WriteLine("║ certificate.                                                         ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ What you will learn:                                                 ║")
            Console.WriteLine("║   * Create or load the slave own certificate                         ║")
            Console.WriteLine("║   * Override client certificate validation with accept-all           ║")
            Console.WriteLine("║   * Serve normal Modbus data through a TLS listener                  ║")
            Console.WriteLine("║                                                                      ║")
            Console.WriteLine("║ Used by Workshop 21 on SecureTCP port 802                            ║")
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝")
            Console.WriteLine()
        End Sub
    End Module
End Namespace

