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
// PLCcom for Modbus - Workshop 23: Mutual TLS Loopback
//
// Secure Modbus TCP uses TLS on both sides of the connection. The slave presents
// a server certificate, the master presents a client certificate, and both peers
// trust the same workshop root CA. That is mutual TLS: transport encryption plus
// authenticated identities on master and slave side.
//
// What you will learn:
//   * How to configure SecureTCP certificates without using the PKI folders
//   * Why both peers need a local certificate for mutual TLS
//   * How a normal Modbus read/write cycle looks once the TLS tunnel is established
//
// This workshop starts a local slave in the same process so the full scenario is
// reproducible. Workshop 24 builds on this and adds role-based authorization.
// ==============================================================================

using System;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using PLCcomModbus.Core;
using PLCcomModbus.Core.Security;
using PLCcomModbus.Master;
using PLCcomModbus.Slave;

namespace PLCcomModbus.Workshops.SecureTcp.MutualTLSLoopback
{
    internal static class Program
    {
        // Important !!!!!!!!!!!!!!!!!!
        // Enter your Username + Serial here! Please note: with blank fields the library runs
        // for 15 minutes during a debug session. Both values can also come
        // from configuration or an environment variable.
        // Free trial license (14 days, uninterrupted): https://www.indi-an.com/en/plccom/modbus/modbus-download/
        private const string LicenseUserName = "";
        private const string LicenseSerial = "";

        private const string ListenerId = "secure-mutualtls-loopback";
        private const string ConnectHost = "127.0.0.1";
        private const string CertificateHostName = "localhost";
        private const int LoopbackPort = SecureModbusTcpOptions.DefaultSecureModbusTcpPort;
        private const byte SlaveId = 1;

        private static void Main()
        {
            PrintHeader();

            try
            {
                // -- Step 1: Create a local certificate chain --------------
                // Create a short-lived root CA and two endpoint certificates.
                // The server certificate identifies the slave; the client
                // certificate identifies the master during the TLS handshake.
                SecureTcpWorkshopCertificates certificates = SecureTcpWorkshopCertificates.Create();

                // -- Step 2: Assign certificates to both SecureTCP peers ----
                // Both peers trust the same root certificate. The slave uses
                // the server certificate, the master uses the client certificate.
                SecureModbusTcpOptions slaveOptions = new SecureModbusTcpOptions();
                slaveOptions.LocalCertificate = certificates.ServerCertificate;
                slaveOptions.TrustedRemoteCertificates.Add(certificates.RootCertificate);

                SecureModbusTcpOptions masterOptions = new SecureModbusTcpOptions();
                masterOptions.LocalCertificate = certificates.ClientCertificate;
                masterOptions.TrustedRemoteCertificates.Add(certificates.RootCertificate);
                masterOptions.TargetHostName = CertificateHostName;

                using (ModbusSlave slave = new ModbusSlave(LicenseUserName, LicenseSerial, SlaveId))
                using (ModbusMaster master = new ModbusMaster(LicenseUserName, LicenseSerial))
                {
                    // -- Step 3: Start the local SecureTCP slave ------------
                    // Seed deterministic register values before the secure listener is opened.
                    slave.SetValue(0, eModbusRegion.HoldingRegister, (ushort)2300);
                    slave.SetValue(1, eModbusRegion.HoldingRegister, (ushort)2301);

                    // The listener receives TLS connections and validates the
                    // client certificate against the trusted workshop root.
                    slave.AddOrReplaceListener_SecureTCP(ListenerId, LoopbackPort, slaveOptions);
                    // Brief pause so the listener socket is ready before the master connects.
                    // Without it the master may attempt a connection before the TCP accept loop starts.
                    Thread.Sleep(250);

                    // -- Step 4: Connect the master through SecureTCP -------
                    // From here on the request code is normal Modbus. SecureTCP
                    // protects the transport; it does not change the read/write API.
                    master.SetConnector_SecureTCP(ConnectHost, LoopbackPort, masterOptions);
                    master.RegisterMode = eRegisterMode._16Bit;

                    // -- Step 5: Read, write and verify holding registers ---
                    ReadRequest readRequest = RequestBuilder.ReadRequestBuilder.Create(
                        SlaveId,
                        eReadFunction.F03_Read_Holding_Registers,
                        0,
                        eDataType.USHORT,
                        2);
                    readRequest.ByteOrder = eByteOrder.AB_CD;
                    PrintReadResult("Initial SecureTCP read", master.Read(readRequest));

                    // Function 16 writes the two demo values back to the same
                    // holding-register range that was read above.
                    WriteRequest writeRequest = RequestBuilder.WriteRequestBuilder.Create(
                        SlaveId,
                        eWriteFunction.F16_Write_Multiple_Registers,
                        0);
                    writeRequest.AddRange(new ushort[] { 2310, 2311 });
                    PrintWriteResult("SecureTCP write", master.Write(writeRequest));

                    PrintReadResult("Read back after SecureTCP write", master.Read(readRequest));

                    // Remove the named listener explicitly before disposing the slave.
                    slave.RemoveListener(ListenerId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Workshop failed: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static void PrintHeader()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ PLCcom for Modbus - Workshop 23: Mutual TLS Loopback                 ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Starts one local SecureTCP slave and connects with a SecureTCP       ║");
            Console.WriteLine("║ master. Both peers use certificates signed by the same root CA.      ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ What you will learn:                                                 ║");
            Console.WriteLine("║   * Configure server and client certificates for mutual TLS          ║");
            Console.WriteLine("║   * Trust a shared root CA without using PKI folders                 ║");
            Console.WriteLine("║   * Run a normal Modbus read/write cycle over SecureTCP              ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Self-contained endpoint: 127.0.0.1:802                               ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        private static void PrintReadResult(string title, ReadResult result)
        {
            Console.WriteLine(title + ": " + result.Message);

            if (result.Quality != OperationResult.eQuality.GOOD)
            {
                Console.WriteLine();
                return;
            }

            foreach (ReadValue value in result.FetchValues())
            {
                Console.WriteLine("  Holding register {0} = {1}", value.Address, value.Value);
            }

            Console.WriteLine();
        }

        private static void PrintWriteResult(string title, WriteResult result)
        {
            Console.WriteLine(title + ": " + result.Message);
            Console.WriteLine();
        }

        // -- Certificate setup ----------------------------------------------
        // The following helper keeps the certificate mechanics in this file so
        // the workshop is reproducible without external PKI preparation. A
        // production application would normally load these certificates from
        // the PLCcom PKI store or from a company-managed certificate authority.
        private sealed class SecureTcpWorkshopCertificates
        {
            internal X509Certificate2 RootCertificate { get; private set; }
            internal X509Certificate2 ServerCertificate { get; private set; }
            internal X509Certificate2 ClientCertificate { get; private set; }

            internal static SecureTcpWorkshopCertificates Create()
            {
                SecureTcpWorkshopCertificates certificates = new SecureTcpWorkshopCertificates();

                // The temporary root CA signs both endpoint certificates. Both
                // peers trust this root, so the master accepts the slave and
                // the slave accepts the master during the TLS handshake.
                using (RSA rootKey = RSA.Create(2048))
                {
                    CertificateRequest rootRequest = new CertificateRequest(
                        "CN=PLCcom Modbus Workshop Root",
                        rootKey,
                        HashAlgorithmName.SHA256,
                        RSASignaturePadding.Pkcs1);
                    rootRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
                    rootRequest.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));
                    rootRequest.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(rootRequest.PublicKey, false));

                    using (X509Certificate2 rootWithoutPrivateKey = rootRequest.CreateSelfSigned(
                        DateTimeOffset.UtcNow.AddDays(-1),
                        DateTimeOffset.UtcNow.AddDays(7)))
                    {
                        certificates.RootCertificate = ExportableCopy(rootWithoutPrivateKey);
                    }
                }

                // The server certificate is presented by the slave. The client
                // certificate is presented by the master. They deliberately use
                // different extended key usages so the TLS stack can distinguish
                // server authentication from client authentication.
                certificates.ServerCertificate = CreateEndpointCertificate(certificates.RootCertificate, "PLCcom Modbus Workshop Server", true);
                certificates.ClientCertificate = CreateEndpointCertificate(certificates.RootCertificate, "PLCcom Modbus Workshop Client", false);
                return certificates;
            }

            private static X509Certificate2 CreateEndpointCertificate(X509Certificate2 issuerCertificate, string commonName, bool server)
            {
                using (RSA endpointKey = RSA.Create(2048))
                {
                    // Endpoint certificates are signed by the temporary root
                    // CA. They are not certificate authorities themselves.
                    CertificateRequest request = new CertificateRequest(
                        "CN=" + commonName,
                        endpointKey,
                        HashAlgorithmName.SHA256,
                        RSASignaturePadding.Pkcs1);

                    request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, true));
                    request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, true));
                    request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));
                    request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(
                        new OidCollection
                        {
                            new Oid(server ? "1.3.6.1.5.5.7.3.1" : "1.3.6.1.5.5.7.3.2")
                        },
                        false));

                    if (server)
                    {
                        // The master validates the slave certificate against
                        // TargetHostName. For loopback testing, the certificate
                        // therefore contains both localhost and 127.0.0.1.
                        SubjectAlternativeNameBuilder sanBuilder = new SubjectAlternativeNameBuilder();
                        sanBuilder.AddDnsName(CertificateHostName);
                        sanBuilder.AddIpAddress(IPAddress.Parse(ConnectHost));
                        request.CertificateExtensions.Add(sanBuilder.Build());
                    }

                    byte[] serialNumber = new byte[16];
                    RandomNumberGenerator.Fill(serialNumber);

                    using (X509Certificate2 endpointWithoutPrivateKey = request.Create(
                        issuerCertificate,
                        DateTimeOffset.UtcNow.AddDays(-1),
                        issuerCertificate.NotAfter.AddMinutes(-1),
                        serialNumber))
                    {
                        // CopyWithPrivateKey attaches the generated key to the
                        // public certificate. ExportableCopy then reloads it as
                        // a PKCS#12 object that the TLS layer can consume.
                        return ExportableCopy(endpointWithoutPrivateKey.CopyWithPrivateKey(endpointKey));
                    }
                }
            }

            private static X509Certificate2 ExportableCopy(X509Certificate2 certificate)
            {
                // Reloading from PKCS#12 avoids platform-specific private key
                // handle issues and keeps this workshop independent of the
                // Windows certificate store.
                byte[] pfx = certificate.Export(X509ContentType.Pfx, string.Empty);
                return X509CertificateLoader.LoadPkcs12(
                    pfx,
                    string.Empty,
                    X509KeyStorageFlags.Exportable | X509KeyStorageFlags.EphemeralKeySet,
                    Pkcs12LoaderLimits.Defaults);
            }
        }
    }
}
