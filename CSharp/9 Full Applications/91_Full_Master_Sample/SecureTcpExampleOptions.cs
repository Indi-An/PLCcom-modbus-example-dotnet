using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using PLCcomModbus.Core.Security;

namespace PLCComMB_Master_Example_CSharp
{
    internal static class SecureTcpExampleOptions
    {
        private const string DefaultOwnCertificateAlias = "PLCcom Modbus Master TestApp";
        private const string DefaultOwnCertificatePassword = "PLCcomModbusSecureTcpTestApp";
        private const int DefaultOwnCertificateValidityDays = 3650;

        internal static SecureModbusTcpOptions Create()
        {
            SecureModbusTcpOptions options = new SecureModbusTcpOptions();

            string certificatePath = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_CERT_PATH", "PLCCOM_MODBUS_SECURETCP_CERT");
            string certificatePassword = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_CERT_PASSWORD", "PLCCOM_MODBUS_SECURETCP_PASSWORD");
            string trustedCertificatePaths = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_TRUSTED_CERT_PATHS", "PLCCOM_MODBUS_SECURETCP_TRUSTED_CERT");

            options.AcceptAllRemoteCertificates = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_ACCEPT_ALL_REMOTE_CERTIFICATES", options.AcceptAllRemoteCertificates);
            options.RequireLocalCertificate = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_REQUIRE_LOCAL_CERTIFICATE", options.RequireLocalCertificate);
            options.RequireRemoteCertificate = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_REQUIRE_REMOTE_CERTIFICATE", options.RequireRemoteCertificate);
            options.ValidateRemoteCertificateHostName = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_VALIDATE_HOSTNAME", options.ValidateRemoteCertificateHostName);
            options.TargetHostName = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_TARGET_HOST", "PLCCOM_MODBUS_SECURETCP_TARGET_HOSTNAME");

            options.PkiStore = CreatePkiStore();
            options.PkiStore.EnsureDirectories();

            if (!string.IsNullOrWhiteSpace(certificatePath))
                options.LocalCertificate = LoadCertificate(certificatePath, certificatePassword, true);
            else if (options.RequireLocalCertificate)
            {
                options.OwnCertificate = CreateOwnCertificate(options.PkiStore);
                options.LocalCertificate = options.OwnCertificate.LoadOrCreate();
            }

            AddTrustedCertificates(options, trustedCertificatePaths);

            if (options.RequireLocalCertificate && options.LocalCertificate == null && options.OwnCertificate == null)
            {
                throw new InvalidOperationException(
                    "SecureTCP requires a local certificate. Set PLCCOM_MODBUS_SECURETCP_CERT_PATH to a PFX certificate with private key. " +
                    "Alternatively set PLCCOM_MODBUS_SECURETCP_PKI_PATH, PLCCOM_MODBUS_SECURETCP_OWN_ALIAS, " +
                    "PLCCOM_MODBUS_SECURETCP_OWN_PASSWORD, and PLCCOM_MODBUS_SECURETCP_OWN_VALIDITY_DAYS.");
            }

            return options;
        }

        internal static SecureModbusPkiStore CreatePkiStore()
        {
            SecureModbusPkiStore pkiStore = new SecureModbusPkiStore(GetPkiBasePath());
            pkiStore.EnsureDirectories();
            return pkiStore;
        }

        internal static string GetPkiBasePath()
        {
            string configuredPath = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_PKI_PATH", "PLCCOM_MODBUS_SECURETCP_PKI_BASE");
            if (!string.IsNullOrWhiteSpace(configuredPath))
                return configuredPath;

            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "PLCcom",
                "ModbusMaster",
                "SecureTCP",
                "pki");
        }

        internal static X509Certificate2 EnsureOwnCertificate()
        {
            return CreateOwnCertificate(CreatePkiStore()).LoadOrCreate();
        }

        private static SecureModbusOwnCertificate CreateOwnCertificate(SecureModbusPkiStore pkiStore)
        {
            string alias = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_ALIAS") ?? DefaultOwnCertificateAlias;
            string password = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_PASSWORD") ?? DefaultOwnCertificatePassword;
            string validityText = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_VALIDITY_DAYS");
            int validityDays = string.IsNullOrWhiteSpace(validityText)
                ? DefaultOwnCertificateValidityDays
                : int.Parse(validityText);

            SecureModbusOwnCertificate ownCertificate = new SecureModbusOwnCertificate(
                pkiStore,
                alias,
                password,
                validityDays);

            ownCertificate.DnsNames.Add("localhost");
            ownCertificate.DnsNames.Add(Environment.MachineName);
            ownCertificate.IpAddresses.Add(IPAddress.Loopback);
            ownCertificate.IpAddresses.Add(IPAddress.IPv6Loopback);
            AddDnsNames(ownCertificate, GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_DNS_NAMES"));
            AddIpAddresses(ownCertificate, GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_IP_ADDRESSES"));
            ownCertificate.RoleName = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_ROLE", "PLCCOM_MODBUS_SECURETCP_ROLE");
            return ownCertificate;
        }

        private static void AddDnsNames(SecureModbusOwnCertificate ownCertificate, string dnsNames)
        {
            if (string.IsNullOrWhiteSpace(dnsNames))
                return;

            foreach (string dnsName in dnsNames.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                ownCertificate.DnsNames.Add(dnsName.Trim());
        }

        private static void AddIpAddresses(SecureModbusOwnCertificate ownCertificate, string ipAddresses)
        {
            if (string.IsNullOrWhiteSpace(ipAddresses))
                return;

            foreach (string ipAddressText in ipAddresses.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                IPAddress ipAddress;
                if (!IPAddress.TryParse(ipAddressText.Trim(), out ipAddress))
                    throw new InvalidOperationException("Invalid SecureTCP own-certificate IP address: " + ipAddressText);

                ownCertificate.IpAddresses.Add(ipAddress);
            }
        }

        private static void AddTrustedCertificates(SecureModbusTcpOptions options, string trustedCertificatePaths)
        {
            if (string.IsNullOrWhiteSpace(trustedCertificatePaths))
                return;

            foreach (string certificatePath in trustedCertificatePaths.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                options.TrustedRemoteCertificates.Add(LoadCertificate(certificatePath.Trim(), null, false));
        }

        private static X509Certificate2 LoadCertificate(string path, string password, bool requirePrivateKey)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("SecureTCP certificate file was not found.", path);

            X509Certificate2 certificate = string.IsNullOrEmpty(password)
                ? new X509Certificate2(path)
                : new X509Certificate2(path, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

            if (requirePrivateKey && !certificate.HasPrivateKey)
                throw new InvalidOperationException("The SecureTCP local certificate must contain a private key.");

            return certificate;
        }

        private static string GetEnvironmentValue(params string[] names)
        {
            foreach (string name in names)
            {
                string value = Environment.GetEnvironmentVariable(name);
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
            }

            return null;
        }

        private static bool GetEnvironmentBool(string name, bool defaultValue)
        {
            string value = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            return value.Equals("1", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("on", StringComparison.OrdinalIgnoreCase);
        }
    }
}
