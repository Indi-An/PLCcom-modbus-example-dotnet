Imports System
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports PLCcomModbus.Core.Security

Friend NotInheritable Class SecureTcpExampleOptions
    Private Const DefaultOwnCertificateAlias As String = "PLCcom Modbus Slave TestApp"
    Private Const DefaultOwnCertificatePassword As String = "PLCcomModbusSecureTcpTestApp"
    Private Const DefaultOwnCertificateValidityDays As Integer = 3650

    Private Sub New()
    End Sub

    Friend Shared Function Create() As SecureModbusTcpOptions
        Dim options As New SecureModbusTcpOptions()

        Dim certificatePath As String = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_CERT_PATH", "PLCCOM_MODBUS_SECURETCP_CERT")
        Dim certificatePassword As String = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_CERT_PASSWORD", "PLCCOM_MODBUS_SECURETCP_PASSWORD")
        Dim trustedCertificatePaths As String = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_TRUSTED_CERT_PATHS", "PLCCOM_MODBUS_SECURETCP_TRUSTED_CERT")

        options.AcceptAllRemoteCertificates = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_ACCEPT_ALL_REMOTE_CERTIFICATES", options.AcceptAllRemoteCertificates)
        options.RequireLocalCertificate = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_REQUIRE_LOCAL_CERTIFICATE", options.RequireLocalCertificate)
        options.RequireRemoteCertificate = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_REQUIRE_REMOTE_CERTIFICATE", options.RequireRemoteCertificate)
        options.ValidateRemoteCertificateHostName = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_VALIDATE_HOSTNAME", options.ValidateRemoteCertificateHostName)
        options.TargetHostName = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_TARGET_HOST", "PLCCOM_MODBUS_SECURETCP_TARGET_HOSTNAME")

        options.PkiStore = CreatePkiStore()
        options.PkiStore.EnsureDirectories()

        If Not String.IsNullOrWhiteSpace(certificatePath) Then
            options.LocalCertificate = LoadCertificate(certificatePath, certificatePassword, True)
        ElseIf options.RequireLocalCertificate Then
            options.OwnCertificate = CreateOwnCertificate(options.PkiStore)
            options.LocalCertificate = options.OwnCertificate.LoadOrCreate()
        End If

        AddTrustedCertificates(options, trustedCertificatePaths)
        ConfigureAuthorizationValidator(options)

        If options.RequireLocalCertificate AndAlso options.LocalCertificate Is Nothing AndAlso options.OwnCertificate Is Nothing Then
            Throw New InvalidOperationException(
                "SecureTCP requires a local certificate. Set PLCCOM_MODBUS_SECURETCP_CERT_PATH to a PFX certificate with private key. " &
                "Alternatively set PLCCOM_MODBUS_SECURETCP_PKI_PATH, PLCCOM_MODBUS_SECURETCP_OWN_ALIAS, " &
                "PLCCOM_MODBUS_SECURETCP_OWN_PASSWORD, and PLCCOM_MODBUS_SECURETCP_OWN_VALIDITY_DAYS.")
        End If

        Return options
    End Function

    Friend Shared Function CreatePkiStore() As SecureModbusPkiStore
        Dim pkiStore As New SecureModbusPkiStore(GetPkiBasePath())
        pkiStore.EnsureDirectories()
        Return pkiStore
    End Function

    Friend Shared Function GetPkiBasePath() As String
        Dim configuredPath As String = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_PKI_PATH", "PLCCOM_MODBUS_SECURETCP_PKI_BASE")
        If Not String.IsNullOrWhiteSpace(configuredPath) Then
            Return configuredPath
        End If

        Return Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "PLCcom",
            "ModbusSlave",
            "SecureTCP",
            "pki")
    End Function

    Friend Shared Function EnsureOwnCertificate() As X509Certificate2
        Return CreateOwnCertificate(CreatePkiStore()).LoadOrCreate()
    End Function

    Private Shared Function CreateOwnCertificate(pkiStore As SecureModbusPkiStore) As SecureModbusOwnCertificate
        Dim [alias] As String = If(GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_ALIAS"), DefaultOwnCertificateAlias)
        Dim password As String = If(GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_PASSWORD"), DefaultOwnCertificatePassword)
        Dim validityText As String = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_VALIDITY_DAYS")
        Dim validityDays As Integer = If(String.IsNullOrWhiteSpace(validityText), DefaultOwnCertificateValidityDays, Integer.Parse(validityText))

        Dim ownCertificate As New SecureModbusOwnCertificate(pkiStore, [alias], password, validityDays)
        ownCertificate.DnsNames.Add("localhost")
        ownCertificate.DnsNames.Add(Environment.MachineName)
        ownCertificate.IpAddresses.Add(IPAddress.Loopback)
        ownCertificate.IpAddresses.Add(IPAddress.IPv6Loopback)
        AddDnsNames(ownCertificate, GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_DNS_NAMES"))
        AddIpAddresses(ownCertificate, GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_IP_ADDRESSES"))
        ownCertificate.RoleName = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_OWN_ROLE", "PLCCOM_MODBUS_SECURETCP_ROLE")
        Return ownCertificate
    End Function

    Private Shared Sub ConfigureAuthorizationValidator(options As SecureModbusTcpOptions)
        Dim requiredRole As String = GetEnvironmentValue("PLCCOM_MODBUS_SECURETCP_REQUIRED_ROLE", "PLCCOM_MODBUS_SECURETCP_ALLOWED_ROLE")
        Dim allowNullRole As Boolean = GetEnvironmentBool("PLCCOM_MODBUS_SECURETCP_ALLOW_NULL_ROLE", False)
        If String.IsNullOrWhiteSpace(requiredRole) AndAlso Not allowNullRole Then
            Return
        End If

        options.AuthorizationValidator = New RequiredRoleAuthorizationValidator(requiredRole, allowNullRole)
    End Sub

    Private Shared Sub AddDnsNames(ownCertificate As SecureModbusOwnCertificate, dnsNames As String)
        If String.IsNullOrWhiteSpace(dnsNames) Then
            Return
        End If

        For Each dnsName As String In dnsNames.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
            ownCertificate.DnsNames.Add(dnsName.Trim())
        Next
    End Sub

    Private Shared Sub AddIpAddresses(ownCertificate As SecureModbusOwnCertificate, ipAddresses As String)
        If String.IsNullOrWhiteSpace(ipAddresses) Then
            Return
        End If

        For Each ipAddressText As String In ipAddresses.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
            Dim ipAddress As IPAddress = Nothing
            If Not IPAddress.TryParse(ipAddressText.Trim(), ipAddress) Then
                Throw New InvalidOperationException("Invalid SecureTCP own-certificate IP address: " & ipAddressText)
            End If

            ownCertificate.IpAddresses.Add(ipAddress)
        Next
    End Sub

    Private Shared Sub AddTrustedCertificates(options As SecureModbusTcpOptions, trustedCertificatePaths As String)
        If String.IsNullOrWhiteSpace(trustedCertificatePaths) Then
            Return
        End If

        For Each certificatePath As String In trustedCertificatePaths.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
            options.TrustedRemoteCertificates.Add(LoadCertificate(certificatePath.Trim(), Nothing, False))
        Next
    End Sub

    Private Shared Function LoadCertificate(path As String, password As String, requirePrivateKey As Boolean) As X509Certificate2
        If Not File.Exists(path) Then
            Throw New FileNotFoundException("SecureTCP certificate file was not found.", path)
        End If

        Dim certificate As X509Certificate2
        If String.IsNullOrEmpty(password) Then
            certificate = New X509Certificate2(path)
        Else
            certificate = New X509Certificate2(path, password, X509KeyStorageFlags.MachineKeySet Or X509KeyStorageFlags.Exportable)
        End If

        If requirePrivateKey AndAlso Not certificate.HasPrivateKey Then
            Throw New InvalidOperationException("The SecureTCP local certificate must contain a private key.")
        End If

        Return certificate
    End Function

    Private Shared Function GetEnvironmentValue(ParamArray names As String()) As String
        For Each name As String In names
            Dim value As String = Environment.GetEnvironmentVariable(name)
            If Not String.IsNullOrWhiteSpace(value) Then
                Return value
            End If
        Next

        Return Nothing
    End Function

    Private Shared Function GetEnvironmentBool(name As String, defaultValue As Boolean) As Boolean
        Dim value As String = Environment.GetEnvironmentVariable(name)
        If String.IsNullOrWhiteSpace(value) Then
            Return defaultValue
        End If

        Return value.Equals("1", StringComparison.OrdinalIgnoreCase) OrElse
               value.Equals("true", StringComparison.OrdinalIgnoreCase) OrElse
               value.Equals("yes", StringComparison.OrdinalIgnoreCase) OrElse
               value.Equals("on", StringComparison.OrdinalIgnoreCase)
    End Function

    Private NotInheritable Class RequiredRoleAuthorizationValidator
        Implements ISecureModbusAuthorizationValidator

        Private ReadOnly mRequiredRole As String
        Private ReadOnly mAllowNullRole As Boolean

        Friend Sub New(requiredRole As String, allowNullRole As Boolean)
            mRequiredRole = requiredRole
            mAllowNullRole = allowNullRole
        End Sub

        Public Function Validate(context As SecureModbusAuthorizationContext) As Boolean Implements ISecureModbusAuthorizationValidator.Validate
            If context Is Nothing Then
                Return False
            End If

            If context.IsNullRole Then
                Return mAllowNullRole
            End If

            If String.IsNullOrWhiteSpace(mRequiredRole) Then
                Return False
            End If

            Return String.Equals(context.RoleName, mRequiredRole, StringComparison.Ordinal)
        End Function
    End Class
End Class
