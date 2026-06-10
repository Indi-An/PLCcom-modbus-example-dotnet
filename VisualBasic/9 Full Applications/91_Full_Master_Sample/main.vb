Imports System.Drawing
Imports System.Windows.Forms
Imports PLCcomModbus.Core
Imports System.Xml
Imports System.IO
Imports System.Diagnostics
Imports PLCcomModbus.Master
Imports PLCcomModbus.DataAdapter
Imports PLCcomModbus.Core.Security

Public Class main

#Region "Private member"
    Private Device As ModbusMaster = Nothing
    Private resources As System.Resources.ResourceManager
    Private Delegate Sub dlgtOnConnectionStateChange(sender As Object, e As eConnectionState)
    Private certificateAlertTimer As Timer
    Private certificateToolTip As ToolTip
    Private certificateManagerDefaultBackColor As Color
    Private certificateAlertBlinkState As Boolean
    Private certificateManagerOpen As Boolean
    Private certificateManagerAutoOpened As Boolean
#End Region

#Region "Internal member"
    Friend Shared CountOpenDialogs As Integer = 0
#End Region


    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'english ressources test
            'Dim culture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("en")
            'System.Threading.Thread.CurrentThread.CurrentCulture = culture
            'System.Threading.Thread.CurrentThread.CurrentUICulture = culture

            'set language combobox
            Dim lisCultureInfo As New List(Of System.Globalization.CultureInfo)()
            If System.Threading.Thread.CurrentThread.CurrentCulture.Parent.TwoLetterISOLanguageName = "de" Then
                lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("de").Parent)
                lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("en").Parent)
            Else
                lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("en").Parent)
                lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("de").Parent)
            End If
            cmbLanguage.DataSource = lisCultureInfo

            'set UI language
            SetLanguage(System.Threading.Thread.CurrentThread.CurrentCulture)
            InitializeCertificateAlert()


            'fill combobox with enum values
            cmbConnectionType.DataSource = [Enum].GetValues(GetType(eTypeOfCommunication))
            cmbRegisterMode.DataSource = [Enum].GetValues(GetType(eRegisterMode))
            cmbBaudrate.DataSource = [Enum].GetValues(GetType(eBaudrate))
            cmbParity.DataSource = [Enum].GetValues(GetType(System.IO.Ports.Parity))
            cmbDataBits.DataSource = [Enum].GetValues(GetType(eDataBits))
            cmbStopbits.DataSource = [Enum].GetValues(GetType(System.IO.Ports.StopBits))
            cmbHandshake.DataSource = [Enum].GetValues(GetType(System.IO.Ports.Handshake))
            cmbNetworkAddressFamily.DataSource = [Enum].GetValues(GetType(eNetworkAddressFamily))

            'set combobox default values
            cmbParity.SelectedItem = System.IO.Ports.Parity.None
            cmbDataBits.SelectedItem = eDataBits.DataBits8
            cmbStopbits.SelectedItem = System.IO.Ports.StopBits.One
            cmbHandshake.SelectedItem = System.IO.Ports.Handshake.None

            Dim ports As String() = System.IO.Ports.SerialPort.GetPortNames()
            If ports.Length > 0 Then
                cmbSerialPort.DataSource = ports
            Else
                cmbSerialPort.Items.Clear()
                cmbSerialPort.Text = "No serial ports detected"
            End If

            LoadSettingsFromFile()
            CreateAndInitDevice()

            txtUser.Select()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub SetLanguage(culture As System.Globalization.CultureInfo)
        'set UI-Controls with actual CultureInfo information

        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture.TwoLetterISOLanguageName)
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture.TwoLetterISOLanguageName)

        'init ResourceManager
        If resources Is Nothing Then
            resources = New System.Resources.ResourceManager(Me.GetType().Namespace + ".Resources", Me.GetType().Assembly)
        End If

        'set controls 
        Me.txtWarning.Text = resources.GetString("txtWarning_Text")
        Me.Text = resources.GetString("main_Text")
        Me.btnEditConnectionSettings.Text = resources.GetString("btnEditConnectionSettings_Text")
        Me.btnSaveConnectionSettings.Text = resources.GetString("btnSaveConnectionSettings_Text")
        Me.lblConnectionType.Text = resources.GetString("lblConnectionType_Text")
        Me.lblSerialCode.Text = resources.GetString("lblSerialCode_Text")
        Me.grbFunctions.Text = resources.GetString("grbFunctions_Text")
        Me.btnOtherFunctions.Text = resources.GetString("btnOtherFunctions_Text")
        Me.btnClose.Text = resources.GetString("btnClose_Text")
        Me.lblmaxIdleTime.Text = resources.GetString("lblmaxIdleTime_Text")
        Me.btnReadWriteModbus.Text = resources.GetString("btnReadWriteModbus_Text")
        Me.btnReadCollection.Text = resources.GetString("btnReadCollection_Text")
        Me.lblRegisterMode.Text = resources.GetString("lblRegisterMode_Text")
        Me.lblLanguage.Text = resources.GetString("lblLanguage_Text")
        Me.lblNetworkAddressFamily.Text = resources.GetString("lblNetworkAddressFamily_Text")
        SetCertificateManagerText()
        If certificateToolTip IsNot Nothing Then
            UpdateCertificateAlertState()
        End If
    End Sub

    Private Sub SetCertificateManagerText()
        If btnCertificateManager Is Nothing Then
            Return
        End If

        btnCertificateManager.Text = GetResourceString("btnCertificateManager_Text", "show" & vbCrLf & "certificates")
    End Sub

    Private Function GetResourceString(name As String, fallback As String) As String
        If resources Is Nothing Then
            Return fallback
        End If

        Dim value As String = resources.GetString(name)
        If String.IsNullOrEmpty(value) Then
            Return fallback
        End If

        Return value
    End Function

    Private Sub InitializeCertificateAlert()
        certificateManagerDefaultBackColor = btnCertificateManager.BackColor
        certificateToolTip = New ToolTip()
        certificateAlertTimer = New Timer()
        certificateAlertTimer.Interval = 550
        AddHandler certificateAlertTimer.Tick, AddressOf certificateAlertTimer_Tick
        UpdateCertificateAlertState()
    End Sub

    Private Sub certificateAlertTimer_Tick(sender As Object, e As EventArgs)
        certificateAlertBlinkState = Not certificateAlertBlinkState
        btnCertificateManager.UseVisualStyleBackColor = False
        btnCertificateManager.BackColor = If(certificateAlertBlinkState, Color.LightCoral, Color.MistyRose)
    End Sub

    Private Sub UpdateCertificateAlertState()
        Dim rejectedCertificateCount As Integer = CountRejectedCertificates()
        If rejectedCertificateCount > 0 Then
            certificateToolTip.SetToolTip(btnCertificateManager, String.Format(GetResourceString("btnCertificateManager_RejectedToolTip_Text", "{0} rejected SecureTCP certificate(s) require review."), rejectedCertificateCount))
            If Not certificateAlertTimer.Enabled Then
                certificateAlertTimer.Start()
            End If
        Else
            If certificateAlertTimer.Enabled Then
                certificateAlertTimer.Stop()
            End If

            certificateAlertBlinkState = False
            btnCertificateManager.UseVisualStyleBackColor = True
            btnCertificateManager.BackColor = certificateManagerDefaultBackColor
            certificateToolTip.SetToolTip(btnCertificateManager, GetResourceString("btnCertificateManager_ToolTip_Text", "Open SecureTCP certificate manager."))
        End If
    End Sub

    Private Function CountRejectedCertificates() As Integer
        Try
            Dim pkiStore As SecureModbusPkiStore = SecureTcpExampleOptions.CreatePkiStore()
            If Not Directory.Exists(pkiStore.RejectedCertificatesPath) Then
                Return 0
            End If

            Dim count As Integer = 0
            For Each filePath As String In Directory.EnumerateFiles(pkiStore.RejectedCertificatesPath)
                If HasCertificateExtension(filePath) Then
                    count += 1
                End If
            Next

            Return count
        Catch
            Return 0
        End Try
    End Function

    Private Shared Function HasCertificateExtension(filePath As String) As Boolean
        Dim extension As String = Path.GetExtension(filePath)
        Return String.Equals(extension, ".der", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".cer", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".cert", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".crt", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".pem", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".pfx", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".p12", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function PrepareSecureTcpOptionsForUi(options As SecureModbusTcpOptions) As SecureModbusTcpOptions
        If options IsNot Nothing AndAlso options.PkiStore IsNot Nothing Then
            AddHandler options.PkiStore.CertificateStored, AddressOf pkiStore_CertificateStored
        End If

        Return options
    End Function

    Private Sub pkiStore_CertificateStored(sender As Object, e As SecureModbusPkiCertificateStoredEventArgs)
        If e Is Nothing OrElse e.StoreKind <> SecureModbusPkiStoreKind.Rejected Then
            Return
        End If

        If IsDisposed Then
            Return
        End If

        Try
            Dim action As MethodInvoker = Sub() OnRejectedCertificateStored(e.IsNewFile)
            If InvokeRequired Then
                BeginInvoke(action)
            Else
                action()
            End If
        Catch
            ' UI notification must not change the SecureTCP certificate validation result.
        End Try
    End Sub

    Private Sub OnRejectedCertificateStored(isNewFile As Boolean)
        UpdateCertificateAlertState()
        If Not isNewFile OrElse certificateManagerOpen OrElse certificateManagerAutoOpened Then
            Return
        End If

        certificateManagerAutoOpened = True
        OpenCertificateManager()
    End Sub


    <DebuggerStepThrough> _
    Private Sub LoadSettingsFromFile()
        Try
            If File.Exists(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusCoreExSettings.xml") Then

                Using reader As New XmlTextReader(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusCoreExSettings.xml")
                    While reader.Read()
                        Select Case reader.NodeType
                            Case XmlNodeType.Element
                                ' The node is an element.
                                Select Case reader.Name
                                    Case "Authentication"
                                        txtUser.Text = reader.GetAttribute("user")
                                        txtSerial.Text = reader.GetAttribute("serial")
                                        Exit Select
                                    Case "Communication"
                                        If cmbConnectionType.FindString(reader.GetAttribute("TypeOfCommunication")) > -1 Then
                                            cmbConnectionType.Text = reader.GetAttribute("TypeOfCommunication")
                                        End If
                                        If cmbRegisterMode.FindString(reader.GetAttribute("RegisterMode")) > -1 Then
                                            cmbRegisterMode.Text = reader.GetAttribute("RegisterMode")
                                        End If
                                        If cmbBaudrate.FindString(reader.GetAttribute("Baudrate")) > -1 Then
                                            cmbBaudrate.Text = reader.GetAttribute("Baudrate")
                                        End If
                                        If cmbSerialPort.FindString(reader.GetAttribute("SerialPort")) > -1 Then
                                            cmbSerialPort.Text = reader.GetAttribute("SerialPort")
                                        End If
                                        If cmbParity.FindString(reader.GetAttribute("Parity")) > -1 Then
                                            cmbParity.Text = reader.GetAttribute("Parity")
                                        End If
                                        If cmbDataBits.FindString(reader.GetAttribute("DataBits")) > -1 Then
                                            cmbDataBits.Text = reader.GetAttribute("DataBits")
                                        End If
                                        If cmbStopbits.FindString(reader.GetAttribute("Stopbits")) > -1 Then
                                            cmbStopbits.Text = reader.GetAttribute("Stopbits")
                                        End If
                                        If cmbHandshake.FindString(reader.GetAttribute("Handshake")) > -1 Then
                                            cmbHandshake.Text = reader.GetAttribute("Handshake")
                                        End If
                                        If cmbNetworkAddressFamily.FindString(reader.GetAttribute("NetworkAddressFamily")) > -1 Then
                                            cmbNetworkAddressFamily.Text = reader.GetAttribute("NetworkAddressFamily")
                                        End If
                                        txtAddressIP.Text = reader.GetAttribute("txtAddressIP")
                                        txtRemotePort.Text = reader.GetAttribute("txtRemotePort")
                                        txtLocalPort.Text = reader.GetAttribute("txtLocalPort")
                                        txtIdleTime.Text = reader.GetAttribute("txtIdleTime")
                                        txtOperationTimeout.Text = IIf(reader.GetAttribute("txtOperationTimeout") = Nothing, "2000", reader.GetAttribute("txtOperationTimeout"))
                                        chkCRCCheck.Checked = IIf(reader.GetAttribute("chkCRCCheck") = Nothing OrElse reader.GetAttribute("chkCRCCheck").Equals(Boolean.TrueString), True, False)
                                        Exit Select
                                End Select
                                Exit Select
                        End Select
                    End While
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    Private Sub CreateAndInitDevice()

        'clean up
        If Device IsNot Nothing Then
            If Device.Connector IsNot Nothing Then
                RemoveHandler Device.Connector.OnConnectionStateChange, AddressOf Device_OnConnectionStateChange
            End If
            Device.Dispose()
        End If

        Try
            'create new device instance
            Device = New ModbusMaster(txtUser.Text, txtSerial.Text)

            'linking device with adapter
            Select Case cmbConnectionType.SelectedValue.ToString()
                Case "TCP"
                    'set tcp adapter
                    Device.SetConnector_TCP(txtAddressIP.Text, Convert.ToInt32(txtRemotePort.Text), Convert.ToInt32(txtLocalPort.Text), DirectCast(cmbNetworkAddressFamily.SelectedValue, eNetworkAddressFamily))
                    Exit Select
                Case "UDP"
                    'set udp adapter
                    Device.SetConnector_UDP(txtAddressIP.Text, Convert.ToInt32(txtRemotePort.Text), Convert.ToInt32(txtLocalPort.Text), DirectCast(cmbNetworkAddressFamily.SelectedValue, eNetworkAddressFamily))
                    Exit Select
                Case "RTU_over_TCP"
                    'set rtu over tcp adapter
                    Device.SetConnector_RTU_over_TCP(txtAddressIP.Text, Convert.ToInt32(txtRemotePort.Text), Convert.ToInt32(txtLocalPort.Text), DirectCast(cmbNetworkAddressFamily.SelectedValue, eNetworkAddressFamily))
                    Exit Select
                Case "SecureTCP"
                    'set secure tcp adapter; certificates are loaded from PLCCOM_MODBUS_SECURETCP_* environment variables
                    Device.SetConnector_SecureTCP(txtAddressIP.Text, Convert.ToInt32(txtRemotePort.Text), Convert.ToInt32(txtLocalPort.Text), DirectCast(cmbNetworkAddressFamily.SelectedValue, eNetworkAddressFamily), PrepareSecureTcpOptionsForUi(SecureTcpExampleOptions.Create()))
                    Exit Select
                Case "RTU"
                    'set rtu adapter
                    Device.SetConnector_RTU(cmbSerialPort.Text, DirectCast(cmbBaudrate.SelectedValue, eBaudrate), DirectCast(cmbDataBits.SelectedValue, eDataBits), CType(cmbParity.SelectedValue, System.IO.Ports.Parity), CType(cmbStopbits.SelectedValue, System.IO.Ports.StopBits), CType(cmbHandshake.SelectedValue, System.IO.Ports.Handshake))
                    Exit Select
                Case "ASCII"
                    'set ascii adapter
                    Device.SetConnector_ASCII(cmbSerialPort.Text, DirectCast(cmbBaudrate.SelectedValue, eBaudrate), DirectCast(cmbDataBits.SelectedValue, eDataBits), CType(cmbParity.SelectedValue, System.IO.Ports.Parity), CType(cmbStopbits.SelectedValue, System.IO.Ports.StopBits), CType(cmbHandshake.SelectedValue, System.IO.Ports.Handshake))
                    Exit Select
                Case Else
                    MessageBox.Show(resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
            End Select

            'set max idleTime, Standard = 10000ms
            Dim MaxIdleTime As UInteger = 0
            Device.Connector.SetMaxIdleTime(If(UInteger.TryParse(txtIdleTime.Text, MaxIdleTime), MaxIdleTime, 10000))

            'Set operation timeout, Standard = 2000ms
            Dim OperationTimeout As Integer = 0
            Device.Connector.OperationTimeout = (If(Integer.TryParse(txtOperationTimeout.Text, OperationTimeout), OperationTimeout, 2000))

            'Set crc/lcr Check
            Device.CRCCheckEnabled = chkCRCCheck.Checked

            'Set RegisterMode >> 16-bit, 32-bit, or 64-bit register mapping; settings must match the slave.
            Device.RegisterMode = DirectCast(cmbRegisterMode.SelectedValue, eRegisterMode)

            AddHandler Device.Connector.OnConnectionStateChange, AddressOf Device_OnConnectionStateChange
            lblDeviceGUID.Text = "Device Guid: " & Device.DeviceGuid.ToString()

            lblDeviceType.Text = "Adapter Type: " + Device.Connector.[GetType]().Name
        Catch generatedExceptionName As Exception
            MessageBox.Show(resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try

    End Sub

    <DebuggerStepThrough> _
    Private Sub btnSaveConnectionSettings_Click(sender As Object, e As EventArgs) Handles btnSaveConnectionSettings.Click
        Try
            btnEditConnectionSettings.Enabled = True
            grbFunctions.Enabled = True
            grbAddress.Enabled = False

            CreateAndInitDevice()

            If btnSaveConnectionSettings.Enabled Then
                btnSaveConnectionSettings_Click(Nothing, Nothing)
            End If

            'Write Settings in PlccomExSettings.xml
            Using myXmlTextWriter As New XmlTextWriter(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusCoreExSettings.xml", System.Text.Encoding.UTF8)

                myXmlTextWriter.Formatting = Formatting.Indented
                myXmlTextWriter.WriteStartDocument(False)
                myXmlTextWriter.WriteStartElement("Settings")
                myXmlTextWriter.WriteStartElement("Authentication")
                myXmlTextWriter.WriteAttributeString("user", txtUser.Text)
                myXmlTextWriter.WriteAttributeString("serial", txtSerial.Text)
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteStartElement("Communication")
                If cmbConnectionType.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("TypeOfCommunication", cmbConnectionType.SelectedItem.ToString())
                End If
                If cmbRegisterMode.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("RegisterMode", cmbRegisterMode.SelectedItem.ToString())
                End If
                If cmbBaudrate.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("Baudrate", cmbBaudrate.SelectedItem.ToString())
                End If
                If cmbSerialPort.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("SerialPort", cmbSerialPort.SelectedItem.ToString())
                End If
                If cmbParity.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("Parity", cmbParity.SelectedItem.ToString())
                End If
                If cmbDataBits.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("DataBits", cmbDataBits.SelectedItem.ToString())
                End If
                If cmbStopbits.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("Stopbits", cmbStopbits.SelectedItem.ToString())
                End If
                If cmbHandshake.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("Handshake", cmbHandshake.SelectedItem.ToString())
                End If
                If cmbNetworkAddressFamily.SelectedItem IsNot Nothing Then
                    myXmlTextWriter.WriteAttributeString("NetworkAddressFamily", cmbNetworkAddressFamily.SelectedItem.ToString())
                End If
                myXmlTextWriter.WriteAttributeString("txtAddressIP", txtAddressIP.Text)
                myXmlTextWriter.WriteAttributeString("txtRemotePort", txtRemotePort.Text)
                myXmlTextWriter.WriteAttributeString("txtLocalPort", txtLocalPort.Text)
                myXmlTextWriter.WriteAttributeString("txtIdleTime", txtIdleTime.Text)
                myXmlTextWriter.WriteAttributeString("txtOperationTimeout", txtOperationTimeout.Text)
                myXmlTextWriter.WriteAttributeString("chkCRCCheck", chkCRCCheck.Checked.ToString())

                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndDocument()
                myXmlTextWriter.Flush()
                myXmlTextWriter.Close()
                MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine + "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusCoreExSettings.xml", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    Private Sub cmbConnectionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConnectionType.SelectedIndexChanged
        Try
            Select Case DirectCast(Me.cmbConnectionType.SelectedValue, eTypeOfCommunication)
                Case eTypeOfCommunication.TCP, eTypeOfCommunication.UDP, eTypeOfCommunication.RTU_over_TCP, eTypeOfCommunication.SecureTCP
                    grbIPSettings.Enabled = True
                    grbSerialSettings.Enabled = False
                    Dim selectedCommunication As eTypeOfCommunication = DirectCast(Me.cmbConnectionType.SelectedValue, eTypeOfCommunication)
                    If selectedCommunication = eTypeOfCommunication.SecureTCP AndAlso txtRemotePort.Text = "502" Then
                        txtRemotePort.Text = "802"
                    ElseIf selectedCommunication <> eTypeOfCommunication.SecureTCP AndAlso txtRemotePort.Text = "802" Then
                        txtRemotePort.Text = "502"
                    End If
                    Exit Select
                Case eTypeOfCommunication.RTU, eTypeOfCommunication.ASCII
                    grbIPSettings.Enabled = False
                    grbSerialSettings.Enabled = True
                    Exit Select
                Case Else
                    grbIPSettings.Enabled = False
                    grbSerialSettings.Enabled = False
                    Exit Select
            End Select
        Catch generatedExceptionName As Exception
            MessageBox.Show(resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try

    End Sub

    Private Sub main_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtUser.Focus()
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Device IsNot Nothing Then
            Device.Dispose()
        End If
    End Sub

    Private Sub txtUser_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged
        If Device IsNot Nothing Then
            Device.SetUser(txtUser.Text)
        End If
    End Sub

    Private Sub txtSerial_TextChanged(sender As Object, e As EventArgs) Handles txtSerial.TextChanged
        If Device IsNot Nothing Then
            Device.SetSerial(txtSerial.Text)
        End If
    End Sub

    Private Sub btnEditConnectionSettings_Click(sender As Object, e As EventArgs) Handles btnEditConnectionSettings.Click
        Try
            If Me.FindForm().OwnedForms.Length > 0 Then
                MessageBox.Show(resources.GetString("to_many_windows"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            btnEditConnectionSettings.Enabled = False
            grbFunctions.Enabled = False
            grbAddress.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Device_OnConnectionStateChange(sender As Object, e As eConnectionState)
        Try
            If Me.InvokeRequired Then
                Me.BeginInvoke(New dlgtOnConnectionStateChange(AddressOf Device_OnConnectionStateChange), New Object() {sender, e})
            Else
                txtDeviceState.Text = resources.GetString("State_" & e.ToString()) & (If(Device IsNot Nothing, " ", String.Empty))
                txtDeviceState.BackColor = If((e = eConnectionState.open OrElse e = eConnectionState.connected), Color.Green, Color.White)
                txtDeviceState.ForeColor = If((e = eConnectionState.open OrElse e = eConnectionState.connected), Color.White, Color.Black)
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnReadWriteModbus_Click(sender As Object, e As EventArgs) Handles btnReadWriteModbus.Click
        CountOpenDialogs += 1
        Dim rwb As New ReadWriteBox(Device)
        rwb.Show(Me)
    End Sub

    Private Sub btnReadCollection_Click(sender As Object, e As EventArgs) Handles btnReadCollection.Click
        CountOpenDialogs += 1
        Dim rcb As New ReadCollectionBox(Device)
        rcb.Show(Me)
    End Sub

    Private Sub btnOtherFunctions_Click(sender As Object, e As EventArgs) Handles btnOtherFunctions.Click
        CountOpenDialogs += 1
        Dim otf As New OtherFunctions(Device)
        otf.Show(Me)
    End Sub

    Private Sub btnCertificateManager_Click(sender As Object, e As EventArgs) Handles btnCertificateManager.Click
        OpenCertificateManager()
    End Sub

    Private Sub OpenCertificateManager()
        If certificateManagerOpen Then
            Return
        End If

        certificateManagerOpen = True
        Try
            Using certificateManager As New CertificateManagerForm()
                certificateManager.ShowDialog(Me)
            End Using
        Finally
            certificateManagerOpen = False
            UpdateCertificateAlertState()
        End Try
    End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLanguage.SelectedIndexChanged
        'change UI language
        SetLanguage(DirectCast(cmbLanguage.SelectedItem, System.Globalization.CultureInfo))
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
