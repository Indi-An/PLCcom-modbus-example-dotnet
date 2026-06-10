// MIT License
// Copyright (c) Indi.An GmbH
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// ==============================================================================
// PLCcom for Modbus - Workshop 21: SecureTCP Master
//
// Secure Modbus TCP keeps the normal Modbus TCP telegram format and protects the
// connection with mutual TLS. This master creates an OPC UA-style PKI store and
// installs a deliberately unsafe workshop validator that accepts every remote
// server certificate so the SecureTCP mechanics can be tested immediately.
//
// Essentials:
//   * Replace the license placeholders before running the sample.
//   * Start Workshop 22 or another Secure Modbus TCP slave.
//   * RemoteCertificateValidator decides whether the server certificate is accepted.
//   * Remove the accept-all validator assignment to test the normal PKI workflow.
// ==============================================================================

using System;
using System.Net;
using PLCcomModbus.Core;
using PLCcomModbus.Core.Security;
using PLCcomModbus.Master;

namespace PLCcomModbus.Workshops.SecureTcp.SecureTcpMaster
{
    internal static class Program
    {
        // -- License ----------------------------------------------------------
        // TODO: Replace with your PLCcom Modbus license credentials.
        // Keep the placeholders visible so SDK users see where credentials enter.
        private const string LicenseUserName = "<Enter your UserName here>";
        private const string LicenseSerial = "<Enter your Serial here>";

        private const string SlaveHost = "127.0.0.1";
        private const string ExpectedCertificateHostName = "localhost";
        private const int SecureTcpPort = SecureModbusTcpOptions.DefaultSecureModbusTcpPort;
        private const byte SlaveId = 1;

        private static void Main()
        {
            PrintHeader();

            try
            {
                // -- Step 1: Prepare the SecureTCP policy -------------------
                // The options object describes the TLS and certificate behavior.
                // The Modbus request built below is still the normal F03 request.
                SecureModbusTcpOptions options = CreateSecureTcpOptions();

                using (ModbusMaster master = new ModbusMaster(LicenseUserName, LicenseSerial))
                {
                    // -- Step 2: Select SecureTCP as transport --------------
                    // SetConnector_SecureTCP opens a Modbus TCP connection through
                    // a TLS tunnel. The Modbus request itself stays unchanged.
                    master.SetConnector_SecureTCP(SlaveHost, SecureTcpPort, options);
                    master.RegisterMode = eRegisterMode._16Bit;

                    // -- Step 3: Create and execute a normal Modbus request -
                    // SecureTCP protects the connection. The application still
                    // creates the same read request it would use for plain TCP.
                    ReadRequest readRequest = RequestBuilder.ReadRequestBuilder.Create(
                        SlaveId,
                        eReadFunction.F03_Read_Holding_Registers,
                        0,
                        eDataType.USHORT,
                        4);

                    // Keep AB_CD for deterministic interpretation of this example.
                    readRequest.ByteOrder = eByteOrder.AB_CD;

                    Console.WriteLine("Reading via SecureTCP from {0}:{1}.", SlaveHost, SecureTcpPort);
                    ReadResult result = master.Read(readRequest);
                    Console.WriteLine("Result: " + result.Message);

                    if (result.Quality == OperationResult.eQuality.GOOD)
                    {
                        foreach (ReadValue value in result.FetchValues())
                        {
                            // On GOOD quality, each fetched item maps back to the
                            // requested logical address and conversion layout.
                            Console.WriteLine("  Holding register {0} = {1}", value.Address, value.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Workshop failed: " + ex.Message);
                Console.WriteLine("If the accept-all validator is disabled, unknown certificates are written to rejected/certs for review.");
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static SecureModbusTcpOptions CreateSecureTcpOptions()
        {
            // The PKI store follows the OPC UA-style folder layout: own,
            // trusted, issuers and rejected. The structure is created on first access.
            SecureModbusPkiStore pkiStore = new SecureModbusPkiStore(@".\pki\securetcp-master");
            pkiStore.EnsureDirectories();
            pkiStore.CertificateStored += OnCertificateStored;
            PrintPkiStoreLayout(pkiStore);

            // The master needs its own certificate for mutual TLS. If the
            // certificate does not exist yet, PLCcom can create it with the
            // explicitly supplied alias, password and validity period.
            // In production move secrets (like this password) to a secure storage.
            SecureModbusOwnCertificate ownCertificate = new SecureModbusOwnCertificate(
                pkiStore,
                "PLCcom Modbus Workshop Master",
                "workshop-password",
                3650,
                "Indi.An GmbH",
                new[] { "localhost" },
                new[] { IPAddress.Parse("127.0.0.1") });

            SecureModbusTcpOptions options = new SecureModbusTcpOptions();
            options.PkiStore = pkiStore;
            options.OwnCertificate = ownCertificate;

            // PKI default behavior when RemoteCertificateValidator is NOT set:
            //   * own/certs and own/private contain this master's certificate
            //     and private key. SecureModbusOwnCertificate creates them on
            //     first use if no valid certificate exists yet.
            //   * trusted/certs contains remote leaf certificates that are
            //     trusted directly. They are accepted only while their validity
            //     period is still OK.
            //   * issuers/certs contains CA or issuer certificates. If a remote
            //     certificate chains to one of these issuers and the chain is
            //     valid, PLCcom copies the leaf certificate to trusted/certs and
            //     accepts the connection.
            //   * rejected/certs receives unknown, expired, host-name-mismatched
            //     or otherwise invalid remote certificates. The connection is
            //     rejected so an operator can review and move trust material.
            //
            // Workshop-only override:
            // Assigning RemoteCertificateValidator disables that automatic
            // certificate-level PKI decision. This intentionally unsafe validator
            // returns true for every server certificate so the user can see how
            // the validator hook works without preparing trusted certificates.
            options.RemoteCertificateValidator = new UnsafeAcceptAllCertificateValidator("SecureTCP server");

            // Expected target host name is used by TLS endpoint checks.
            // Host-name validation compares the remote certificate against
            // this expected name. Use the real DNS name or IP identity in production.
            options.TargetHostName = ExpectedCertificateHostName;

            // Auto mode allows modern/default protocols while still enabling overrides.
            options.TlsProtocolMode = SecureModbusTlsProtocolMode.Auto;
            return options;
        }

        private static void OnCertificateStored(object sender, SecureModbusPkiCertificateStoredEventArgs e)
        {
            Console.WriteLine("PKI {0}: {1}", e.StoreKind, e.FilePath);
        }

        private static void PrintPkiStoreLayout(SecureModbusPkiStore pkiStore)
        {
            Console.WriteLine("PKI store:");
            Console.WriteLine("  own/certs      : {0}", pkiStore.OwnCertificatesPath);
            Console.WriteLine("  own/private    : {0}", pkiStore.OwnPrivatePath);
            Console.WriteLine("  trusted/certs  : {0}", pkiStore.TrustedCertificatesPath);
            Console.WriteLine("  issuers/certs  : {0}", pkiStore.IssuerCertificatesPath);
            Console.WriteLine("  rejected/certs : {0}", pkiStore.RejectedCertificatesPath);
            Console.WriteLine();
        }

        // -- Certificate validation -----------------------------------------
        // Deliberately insecure workshop validator. It is useful when the
        // workshop should focus on SecureTCP mechanics and not on trust-store
        // administration. Do not use this policy in production.
        private sealed class UnsafeAcceptAllCertificateValidator : ISecureModbusCertificateValidator
        {
            private readonly string mRemoteEndpointName;

            internal UnsafeAcceptAllCertificateValidator(string remoteEndpointName)
            {
                mRemoteEndpointName = remoteEndpointName;
            }

            public bool Validate(SecureModbusCertificateValidationContext context)
            {
                Console.WriteLine("WARNING: accepting every {0} certificate.", mRemoteEndpointName);
                Console.WriteLine("         PKI trust checks are bypassed by this workshop validator.");
                Console.WriteLine("         Remote chain length: {0}", context.RemoteCertificateChain.Length);

                foreach (var certificate in context.RemoteCertificateChain)
                    Console.WriteLine("         {0}", certificate.Subject);

                return true;
            }
        }

        // -- Console output ---------------------------------------------------
        private static void PrintHeader()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ PLCcom for Modbus - Workshop 21: SecureTCP Master                    ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Connects a Modbus master through Secure Modbus TCP with mutual TLS.  ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ What you will learn:                                                 ║");
            Console.WriteLine("║   * Configure the SecureTCP connector                                ║");
            Console.WriteLine("║   * See how the PKI store is structured                              ║");
            Console.WriteLine("║   * Override certificate validation with an accept-all validator     ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Required peer: Workshop 22 on 127.0.0.1:802                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }
    }
}

