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
// PLCcom for Modbus - Workshop 24: Role-Based Authorization
//
// SecureTCP certificate validation answers "who is connecting?". Role-based
// authorization answers "what may this peer do?". PLCcom keeps this decision in
// your application: if you assign an authorization validator, PLCcom passes the
// role name, function code and request context to it for every SecureTCP request.
//
// Essentials:
//   * Replace the license placeholders before running the sample.
//   * If no validator is configured, requests are allowed after TLS validation.
//   * Keep validators fast; they can be called for every Modbus request.
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

namespace PLCcomModbus.Workshops.SecureTcp.RoleBasedAuthorization
{
    internal static class Program
    {
        // -- License ----------------------------------------------------------
        // TODO: Replace with your PLCcom Modbus license credentials.
        // Keep the placeholders visible so SDK users see where credentials enter.
        private const string LicenseUserName = "<Enter your UserName here>";
        private const string LicenseSerial = "<Enter your Serial here>";

        private const string OperatorRoleName = "Operator";
        private const string ListenerId = "secure-role";
        private const string ConnectHost = "127.0.0.1";
        private const string CertificateHostName = "localhost";
        private const int LoopbackPort = 802;
        private const byte SlaveId = 1;

        private static void Main()
        {
            PrintHeader();

            try
            {
                // -- Step 1: Generate a client certificate with a role -------
                // The role is stored in the Modbus Security certificate extension.
                // PLCcom extracts it and passes it to the authorization validator.
                SecureTcpWorkshopCertificates certificates = SecureTcpWorkshopCertificates.Create(OperatorRoleName);

                SecureModbusTcpOptions slaveOptions = new SecureModbusTcpOptions();
                slaveOptions.LocalCertificate = certificates.ServerCertificate;
                slaveOptions.TrustedRemoteCertificates.Add(certificates.RootCertificate);
                // The validator is deliberately application code. PLCcom does
                // not decide what "Operator" may do in the customer plant.
                slaveOptions.AuthorizationValidator = new OperatorReadOnlyAuthorizationValidator();

                SecureModbusTcpOptions masterOptions = new SecureModbusTcpOptions();
                masterOptions.LocalCertificate = certificates.ClientCertificate;
                masterOptions.TrustedRemoteCertificates.Add(certificates.RootCertificate);
                masterOptions.TargetHostName = CertificateHostName;

                using (ModbusSlave slave = CreateRoleProtectedSlave(slaveOptions))
                {
                    RunOperatorClient(masterOptions);
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

        private static ModbusSlave CreateRoleProtectedSlave(SecureModbusTcpOptions slaveOptions)
        {
            // -- Step 2: Start the role-protected slave ---------------------
            // Authorization is enforced by the slave. This local listener keeps
            // the workshop self-contained while showing the same validator hook
            // used by a production SecureTCP slave.
            ModbusSlave slave = new ModbusSlave(LicenseUserName, LicenseSerial, SlaveId);

            try
            {
                slave.SetValue(0, eModbusRegion.HoldingRegister, (ushort)802);
                slave.SetValue(1, eModbusRegion.HoldingRegister, (ushort)803);

                // Listener key is fixed so you can open/close one secure endpoint for experiments.
                slave.AddOrReplaceListener_SecureTCP(ListenerId, LoopbackPort, slaveOptions);
                // Brief pause so the listener socket is ready before the master connects.
                // Without it the master may attempt a connection before the TCP accept loop starts.
                Thread.Sleep(250);
                return slave;
            }
            catch
            {
                slave.Dispose();
                throw;
            }
        }

        private static void RunOperatorClient(SecureModbusTcpOptions masterOptions)
        {
            // -- Step 3: Connect the master through SecureTCP --------------
            // The master is a local test client. Its certificate carries role
            // "Operator", so the validator can decide from authenticated
            // certificate content and the Modbus function code.
            using (ModbusMaster master = new ModbusMaster(LicenseUserName, LicenseSerial))
            {
                master.SetConnector_SecureTCP(ConnectHost, LoopbackPort, masterOptions);
                master.RegisterMode = eRegisterMode._16Bit;

                // -- Step 4: Execute an allowed read request ----------------
                // The validator allows read functions for role "Operator".
                ReadRequest readRequest = RequestBuilder.ReadRequestBuilder.Create(
                    SlaveId,
                    eReadFunction.F03_Read_Holding_Registers,
                    0,
                    eDataType.USHORT,
                    2);
                readRequest.ByteOrder = eByteOrder.AB_CD;

                ReadResult readResult = master.Read(readRequest);
                Console.WriteLine("Operator read: " + readResult.Message);

                // -- Step 5: Execute a denied write request -----------------
                // Function 16 is a write operation. The sample policy rejects
                // it for role "Operator" and the slave returns a Modbus
                // exception instead of changing the data.
                WriteRequest deniedWrite = RequestBuilder.WriteRequestBuilder.Create(
                    SlaveId,
                    eWriteFunction.F16_Write_Multiple_Registers,
                    0);
                deniedWrite.AddRange(new ushort[] { 900 });

                WriteResult writeResult = master.Write(deniedWrite);
                Console.WriteLine("Operator write: " + writeResult.Message);
            }
        }

        // -- Console output ---------------------------------------------------
        private static void PrintHeader()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ PLCcom for Modbus - Workshop 24: Role-Based Authorization            ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Adds an application-controlled authorization decision after          ║");
            Console.WriteLine("║ certificate validation.                                              ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ What you will learn:                                                 ║");
            Console.WriteLine("║   * Read the SecureTCP role from the client certificate              ║");
            Console.WriteLine("║   * Implement a fast authorization validator                         ║");
            Console.WriteLine("║   * Return Modbus exception 01 for denied requests                   ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Self-contained SecureTCP loopback workshop                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        // -- Authorization policy -------------------------------------------
        // PLCcom calls this validator after certificate validation and before
        // executing the Modbus request. Returning false blocks the request at
        // the slave side. Keep production implementations fast because this can
        // run for every request on a busy connection.
        private sealed class OperatorReadOnlyAuthorizationValidator : ISecureModbusAuthorizationValidator
        {
            public bool Validate(SecureModbusAuthorizationContext context)
            {
                // This method can be called for every Modbus request. Keep real
                // implementations fast, cached and free of blocking UI/database work.
                if (!string.Equals(context.RoleName, OperatorRoleName, StringComparison.Ordinal))
                {
                    // Any role mismatch (including null/empty) is rejected by policy.
                    return false;
                }

                switch (context.FunctionCode)
                {
                    // Function code 1: Read Coils, 2: Read Discrete Inputs, 3: Read Holding, 4: Read Input Registers.
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        return true;
                    default:
                        // All other function codes are blocked for this role in this sample.
                        return false;
                }
            }
        }

        // -- Certificate setup ----------------------------------------------
        // This workshop generates a local root CA and two endpoint certificates
        // so the authorization flow can be demonstrated without preparing files
        // in a PKI store. In production, load these objects from the PLCcom PKI
        // structure or from your enterprise certificate management process.
        private sealed class SecureTcpWorkshopCertificates
        {
            internal X509Certificate2 RootCertificate { get; private set; }
            internal X509Certificate2 ServerCertificate { get; private set; }
            internal X509Certificate2 ClientCertificate { get; private set; }

            internal static SecureTcpWorkshopCertificates Create(string clientRoleName)
            {
                SecureTcpWorkshopCertificates certificates = new SecureTcpWorkshopCertificates();

                // The temporary root CA signs the slave and master certificates.
                // Trusting this root on both sides is enough for the local TLS
                // handshake in this workshop.
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

                // The server certificate identifies the slave. The client
                // certificate identifies the master and carries the role marker
                // that will later be passed to the validator.
                certificates.ServerCertificate = CreateEndpointCertificate(certificates.RootCertificate, "PLCcom Modbus Workshop Server", true, null);
                certificates.ClientCertificate = CreateEndpointCertificate(certificates.RootCertificate, "PLCcom Modbus Workshop Client", false, clientRoleName);

                return certificates;
            }

            private static X509Certificate2 CreateEndpointCertificate(X509Certificate2 issuerCertificate, string commonName, bool server, string roleName)
            {
                using (RSA endpointKey = RSA.Create(2048))
                {
                    // Endpoint certificates are signed by the temporary root
                    // CA. They are not allowed to sign other certificates.
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
                        // For server certs, add identity values required by TLS host validation.
                        SubjectAlternativeNameBuilder sanBuilder = new SubjectAlternativeNameBuilder();
                        sanBuilder.AddDnsName(CertificateHostName);
                        sanBuilder.AddIpAddress(IPAddress.Parse(ConnectHost));
                        request.CertificateExtensions.Add(sanBuilder.Build());
                    }

                    // The role extension is optional in the standard. When it is
                    // missing, PLCcom passes NULL to the validator instead.
                    // This workshop adds it only to the client certificate.
                    if (!string.IsNullOrWhiteSpace(roleName))
                        request.CertificateExtensions.Add(SecureModbusRoleExtension.Create(roleName, false));

                    // Deterministic serial content is generated from secure random bytes.
                    byte[] serialNumber = new byte[16];
                    RandomNumberGenerator.Fill(serialNumber);

                    using (X509Certificate2 endpointWithoutPrivateKey = request.Create(
                        issuerCertificate,
                        DateTimeOffset.UtcNow.AddDays(-1),
                        issuerCertificate.NotAfter.AddMinutes(-1),
                        serialNumber))
                    {
                        // Return a loaded PKCS#12 version to ensure private key can be used by the TLS stack.
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

