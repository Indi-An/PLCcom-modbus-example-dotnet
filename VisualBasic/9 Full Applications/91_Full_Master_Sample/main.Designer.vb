<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        lblHandshake = New Label()
        lblStopBits = New Label()
        lblDataBits = New Label()
        cmbHandshake = New ComboBox()
        grbFunctions = New Panel()
        btnReadWriteModbus = New Button()
        btnOtherFunctions = New Button()
        btnReadCollection = New Button()
        btnCertificateManager = New Button()
        grbIPSettings = New GroupBox()
        lblNetworkAddressFamily = New Label()
        cmbNetworkAddressFamily = New ComboBox()
        txtLocalPort = New TextBox()
        lblAddress0 = New Label()
        txtAddressIP = New TextBox()
        lblAddress1 = New Label()
        txtRemotePort = New TextBox()
        lblAddress2 = New Label()
        lblParity = New Label()
        lblConnectionType = New Label()
        cmbConnectionType = New ComboBox()
        panelStatusStrip = New Panel()
        statusStrip = New StatusStrip()
        txtDeviceState = New ToolStripStatusLabel()
        lblDeviceType = New ToolStripStatusLabel()
        lblDeviceGUID = New ToolStripStatusLabel()
        btnEditConnectionSettings = New Button()
        btnClose = New Button()
        groupBox1 = New GroupBox()
        cmbDataBits = New ComboBox()
        grbSerial = New GroupBox()
        lblSerial = New Label()
        lblUser = New Label()
        txtSerial = New TextBox()
        txtUser = New TextBox()
        lblSerialCode = New Label()
        txtWarning = New TextBox()
        grbAddress = New GroupBox()
        lblCRCCheck = New Label()
        chkCRCCheck = New CheckBox()
        lblOperationTimeout = New Label()
        Label2 = New Label()
        txtOperationTimeout = New TextBox()
        btnSaveConnectionSettings = New Button()
        lblRegisterMode = New Label()
        cmbRegisterMode = New ComboBox()
        label1 = New Label()
        lblmaxIdleTime = New Label()
        txtIdleTime = New TextBox()
        grbSerialSettings = New GroupBox()
        lblSerialPort = New Label()
        cmbStopbits = New ComboBox()
        cmbParity = New ComboBox()
        cmbSerialPort = New ComboBox()
        lblBaudrate = New Label()
        cmbBaudrate = New ComboBox()
        lblLanguage = New Label()
        cmbLanguage = New ComboBox()
        grbFunctions.SuspendLayout()
        grbIPSettings.SuspendLayout()
        panelStatusStrip.SuspendLayout()
        statusStrip.SuspendLayout()
        groupBox1.SuspendLayout()
        grbSerial.SuspendLayout()
        grbAddress.SuspendLayout()
        grbSerialSettings.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblHandshake
        ' 
        lblHandshake.Location = New Point(5, 240)
        lblHandshake.Margin = New Padding(5, 0, 5, 0)
        lblHandshake.Name = "lblHandshake"
        lblHandshake.Size = New Size(100, 20)
        lblHandshake.TabIndex = 50
        lblHandshake.Text = "handshake"
        lblHandshake.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblStopBits
        ' 
        lblStopBits.Location = New Point(28, 198)
        lblStopBits.Margin = New Padding(5, 0, 5, 0)
        lblStopBits.Name = "lblStopBits"
        lblStopBits.Size = New Size(77, 20)
        lblStopBits.TabIndex = 49
        lblStopBits.Text = "stop bits"
        lblStopBits.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblDataBits
        ' 
        lblDataBits.Location = New Point(25, 157)
        lblDataBits.Margin = New Padding(5, 0, 5, 0)
        lblDataBits.Name = "lblDataBits"
        lblDataBits.Size = New Size(78, 20)
        lblDataBits.TabIndex = 48
        lblDataBits.Text = "data bits"
        lblDataBits.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbHandshake
        ' 
        cmbHandshake.FormattingEnabled = True
        cmbHandshake.Location = New Point(122, 235)
        cmbHandshake.Margin = New Padding(5, 5, 5, 5)
        cmbHandshake.Name = "cmbHandshake"
        cmbHandshake.Size = New Size(184, 28)
        cmbHandshake.TabIndex = 46
        ' 
        ' grbFunctions
        ' 
        grbFunctions.Controls.Add(btnReadWriteModbus)
        grbFunctions.Controls.Add(btnOtherFunctions)
        grbFunctions.Controls.Add(btnReadCollection)
        grbFunctions.Controls.Add(btnCertificateManager)
        grbFunctions.Location = New Point(10, 14)
        grbFunctions.Margin = New Padding(5, 5, 5, 5)
        grbFunctions.Name = "grbFunctions"
        grbFunctions.Size = New Size(567, 115)
        grbFunctions.TabIndex = 110
        ' 
        ' btnReadWriteModbus
        ' 
        btnReadWriteModbus.Image = CType(resources.GetObject("btnReadWriteModbus.Image"), Image)
        btnReadWriteModbus.ImageAlign = ContentAlignment.TopCenter
        btnReadWriteModbus.Location = New Point(15, 5)
        btnReadWriteModbus.Margin = New Padding(5, 5, 5, 5)
        btnReadWriteModbus.Name = "btnReadWriteModbus"
        btnReadWriteModbus.Size = New Size(113, 105)
        btnReadWriteModbus.TabIndex = 101
        btnReadWriteModbus.Text = "read write modbus"
        btnReadWriteModbus.TextAlign = ContentAlignment.BottomCenter
        btnReadWriteModbus.UseVisualStyleBackColor = True
        ' 
        ' btnOtherFunctions
        ' 
        btnOtherFunctions.Image = CType(resources.GetObject("btnOtherFunctions.Image"), Image)
        btnOtherFunctions.ImageAlign = ContentAlignment.TopCenter
        btnOtherFunctions.Location = New Point(292, 5)
        btnOtherFunctions.Margin = New Padding(5, 5, 5, 5)
        btnOtherFunctions.Name = "btnOtherFunctions"
        btnOtherFunctions.Size = New Size(113, 105)
        btnOtherFunctions.TabIndex = 103
        btnOtherFunctions.Text = "other MB functions"
        btnOtherFunctions.TextAlign = ContentAlignment.BottomCenter
        btnOtherFunctions.UseVisualStyleBackColor = True
        ' 
        ' btnReadCollection
        ' 
        btnReadCollection.Image = CType(resources.GetObject("btnReadCollection.Image"), Image)
        btnReadCollection.ImageAlign = ContentAlignment.TopCenter
        btnReadCollection.Location = New Point(155, 5)
        btnReadCollection.Margin = New Padding(5, 5, 5, 5)
        btnReadCollection.Name = "btnReadCollection"
        btnReadCollection.Size = New Size(113, 105)
        btnReadCollection.TabIndex = 102
        btnReadCollection.Text = "read collection"
        btnReadCollection.TextAlign = ContentAlignment.BottomCenter
        btnReadCollection.UseVisualStyleBackColor = True
        ' 
        ' btnCertificateManager
        ' 
        btnCertificateManager.Image = CType(resources.GetObject("btnCertificateManager.Image"), Image)
        btnCertificateManager.ImageAlign = ContentAlignment.TopCenter
        btnCertificateManager.Location = New Point(425, 5)
        btnCertificateManager.Margin = New Padding(5, 5, 5, 5)
        btnCertificateManager.Name = "btnCertificateManager"
        btnCertificateManager.Size = New Size(113, 105)
        btnCertificateManager.TabIndex = 104
        btnCertificateManager.Text = "show" & vbCrLf & "certificates"
        btnCertificateManager.TextAlign = ContentAlignment.BottomCenter
        btnCertificateManager.UseVisualStyleBackColor = True
        ' 
        ' grbIPSettings
        ' 
        grbIPSettings.Controls.Add(lblNetworkAddressFamily)
        grbIPSettings.Controls.Add(cmbNetworkAddressFamily)
        grbIPSettings.Controls.Add(txtLocalPort)
        grbIPSettings.Controls.Add(lblAddress0)
        grbIPSettings.Controls.Add(txtAddressIP)
        grbIPSettings.Controls.Add(lblAddress1)
        grbIPSettings.Controls.Add(txtRemotePort)
        grbIPSettings.Controls.Add(lblAddress2)
        grbIPSettings.Location = New Point(410, 20)
        grbIPSettings.Margin = New Padding(5, 5, 5, 5)
        grbIPSettings.Name = "grbIPSettings"
        grbIPSettings.Padding = New Padding(5, 5, 5, 5)
        grbIPSettings.Size = New Size(417, 289)
        grbIPSettings.TabIndex = 40
        grbIPSettings.TabStop = False
        ' 
        ' lblNetworkAddressFamily
        ' 
        lblNetworkAddressFamily.Location = New Point(25, 145)
        lblNetworkAddressFamily.Margin = New Padding(5, 0, 5, 0)
        lblNetworkAddressFamily.Name = "lblNetworkAddressFamily"
        lblNetworkAddressFamily.Size = New Size(172, 60)
        lblNetworkAddressFamily.TabIndex = 72
        lblNetworkAddressFamily.Text = "network address family"
        lblNetworkAddressFamily.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' cmbNetworkAddressFamily
        ' 
        cmbNetworkAddressFamily.FormattingEnabled = True
        cmbNetworkAddressFamily.Location = New Point(207, 157)
        cmbNetworkAddressFamily.Margin = New Padding(5, 5, 5, 5)
        cmbNetworkAddressFamily.Name = "cmbNetworkAddressFamily"
        cmbNetworkAddressFamily.Size = New Size(184, 28)
        cmbNetworkAddressFamily.TabIndex = 71
        ' 
        ' txtLocalPort
        ' 
        txtLocalPort.Location = New Point(207, 115)
        txtLocalPort.Margin = New Padding(5, 5, 5, 5)
        txtLocalPort.Name = "txtLocalPort"
        txtLocalPort.Size = New Size(184, 26)
        txtLocalPort.TabIndex = 29
        txtLocalPort.Text = "0"
        ' 
        ' lblAddress0
        ' 
        lblAddress0.Location = New Point(60, 28)
        lblAddress0.Margin = New Padding(5, 0, 5, 0)
        lblAddress0.Name = "lblAddress0"
        lblAddress0.Size = New Size(137, 20)
        lblAddress0.TabIndex = 9
        lblAddress0.Text = "IP/HostAddress"
        lblAddress0.TextAlign = ContentAlignment.TopRight
        ' 
        ' txtAddressIP
        ' 
        txtAddressIP.Location = New Point(207, 25)
        txtAddressIP.Margin = New Padding(5, 5, 5, 5)
        txtAddressIP.Name = "txtAddressIP"
        txtAddressIP.Size = New Size(184, 26)
        txtAddressIP.TabIndex = 8
        txtAddressIP.Text = "127.0.0.1"
        ' 
        ' lblAddress1
        ' 
        lblAddress1.Location = New Point(12, 78)
        lblAddress1.Margin = New Padding(5, 0, 5, 0)
        lblAddress1.Name = "lblAddress1"
        lblAddress1.Size = New Size(185, 20)
        lblAddress1.TabIndex = 28
        lblAddress1.Text = "PLC Port (usually 502)"
        lblAddress1.TextAlign = ContentAlignment.TopRight
        ' 
        ' txtRemotePort
        ' 
        txtRemotePort.Location = New Point(207, 69)
        txtRemotePort.Margin = New Padding(5, 5, 5, 5)
        txtRemotePort.Name = "txtRemotePort"
        txtRemotePort.Size = New Size(184, 26)
        txtRemotePort.TabIndex = 27
        txtRemotePort.Text = "502"
        ' 
        ' lblAddress2
        ' 
        lblAddress2.Location = New Point(32, 120)
        lblAddress2.Margin = New Padding(5, 0, 5, 0)
        lblAddress2.Name = "lblAddress2"
        lblAddress2.Size = New Size(165, 20)
        lblAddress2.TabIndex = 30
        lblAddress2.Text = "Local Port (intern 0)"
        lblAddress2.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblParity
        ' 
        lblParity.Location = New Point(50, 115)
        lblParity.Margin = New Padding(5, 0, 5, 0)
        lblParity.Name = "lblParity"
        lblParity.Size = New Size(53, 20)
        lblParity.TabIndex = 47
        lblParity.Text = "parity"
        lblParity.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblConnectionType
        ' 
        lblConnectionType.Location = New Point(3, 35)
        lblConnectionType.Margin = New Padding(5, 0, 5, 0)
        lblConnectionType.Name = "lblConnectionType"
        lblConnectionType.Size = New Size(175, 28)
        lblConnectionType.TabIndex = 37
        lblConnectionType.Text = "Type of Connection"
        lblConnectionType.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbConnectionType
        ' 
        cmbConnectionType.FormattingEnabled = True
        cmbConnectionType.Location = New Point(180, 35)
        cmbConnectionType.Margin = New Padding(5, 5, 5, 5)
        cmbConnectionType.Name = "cmbConnectionType"
        cmbConnectionType.Size = New Size(184, 28)
        cmbConnectionType.TabIndex = 36
        ' 
        ' panelStatusStrip
        ' 
        panelStatusStrip.AutoSize = True
        panelStatusStrip.AutoSizeMode = AutoSizeMode.GrowAndShrink
        panelStatusStrip.BorderStyle = BorderStyle.FixedSingle
        panelStatusStrip.Controls.Add(statusStrip)
        panelStatusStrip.Dock = DockStyle.Bottom
        panelStatusStrip.Location = New Point(0, 1027)
        panelStatusStrip.Margin = New Padding(5, 5, 5, 5)
        panelStatusStrip.Name = "panelStatusStrip"
        panelStatusStrip.Size = New Size(1218, 36)
        panelStatusStrip.TabIndex = 115
        ' 
        ' statusStrip
        ' 
        statusStrip.BackColor = SystemColors.Control
        statusStrip.ImageScalingSize = New Size(24, 24)
        statusStrip.Items.AddRange(New ToolStripItem() {txtDeviceState, lblDeviceType, lblDeviceGUID})
        statusStrip.Location = New Point(0, 0)
        statusStrip.Name = "statusStrip"
        statusStrip.Padding = New Padding(2, 0, 23, 0)
        statusStrip.Size = New Size(1216, 34)
        statusStrip.TabIndex = 93
        ' 
        ' txtDeviceState
        ' 
        txtDeviceState.BackColor = Color.White
        txtDeviceState.BorderSides = ToolStripStatusLabelBorderSides.Left Or ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Right Or ToolStripStatusLabelBorderSides.Bottom
        txtDeviceState.BorderStyle = Border3DStyle.SunkenInner
        txtDeviceState.Margin = New Padding(2, 3, 2, 2)
        txtDeviceState.Name = "txtDeviceState"
        txtDeviceState.Size = New Size(123, 29)
        txtDeviceState.Text = "Disconnected"
        ' 
        ' lblDeviceType
        ' 
        lblDeviceType.BackColor = Color.White
        lblDeviceType.BorderSides = ToolStripStatusLabelBorderSides.Left Or ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Right Or ToolStripStatusLabelBorderSides.Bottom
        lblDeviceType.BorderStyle = Border3DStyle.SunkenInner
        lblDeviceType.Margin = New Padding(2, 3, 2, 2)
        lblDeviceType.Name = "lblDeviceType"
        lblDeviceType.Overflow = ToolStripItemOverflow.Always
        lblDeviceType.Size = New Size(129, 29)
        lblDeviceType.Text = "GUID: nothing"
        ' 
        ' lblDeviceGUID
        ' 
        lblDeviceGUID.BackColor = Color.White
        lblDeviceGUID.BorderSides = ToolStripStatusLabelBorderSides.Left Or ToolStripStatusLabelBorderSides.Top Or ToolStripStatusLabelBorderSides.Right Or ToolStripStatusLabelBorderSides.Bottom
        lblDeviceGUID.BorderStyle = Border3DStyle.SunkenInner
        lblDeviceGUID.Margin = New Padding(2, 3, 2, 2)
        lblDeviceGUID.Name = "lblDeviceGUID"
        lblDeviceGUID.Overflow = ToolStripItemOverflow.Always
        lblDeviceGUID.Size = New Size(129, 29)
        lblDeviceGUID.Text = "GUID: nothing"
        ' 
        ' btnEditConnectionSettings
        ' 
        btnEditConnectionSettings.Image = CType(resources.GetObject("btnEditConnectionSettings.Image"), Image)
        btnEditConnectionSettings.ImageAlign = ContentAlignment.TopCenter
        btnEditConnectionSettings.Location = New Point(45, 440)
        btnEditConnectionSettings.Margin = New Padding(5, 5, 5, 5)
        btnEditConnectionSettings.Name = "btnEditConnectionSettings"
        btnEditConnectionSettings.Size = New Size(113, 105)
        btnEditConnectionSettings.TabIndex = 116
        btnEditConnectionSettings.Text = "edit settings"
        btnEditConnectionSettings.TextAlign = ContentAlignment.BottomCenter
        btnEditConnectionSettings.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Image = CType(resources.GetObject("btnClose.Image"), Image)
        btnClose.ImageAlign = ContentAlignment.TopCenter
        btnClose.Location = New Point(1043, 18)
        btnClose.Margin = New Padding(5, 5, 5, 5)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(113, 105)
        btnClose.TabIndex = 109
        btnClose.Text = "close window"
        btnClose.TextAlign = ContentAlignment.BottomCenter
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' groupBox1
        ' 
        groupBox1.Controls.Add(grbFunctions)
        groupBox1.Controls.Add(btnClose)
        groupBox1.Location = New Point(20, 865)
        groupBox1.Margin = New Padding(5, 5, 5, 5)
        groupBox1.Name = "groupBox1"
        groupBox1.Padding = New Padding(5, 5, 5, 5)
        groupBox1.Size = New Size(1188, 134)
        groupBox1.TabIndex = 117
        groupBox1.TabStop = False
        ' 
        ' cmbDataBits
        ' 
        cmbDataBits.FormattingEnabled = True
        cmbDataBits.Location = New Point(122, 152)
        cmbDataBits.Margin = New Padding(5, 5, 5, 5)
        cmbDataBits.Name = "cmbDataBits"
        cmbDataBits.Size = New Size(184, 28)
        cmbDataBits.TabIndex = 45
        ' 
        ' grbSerial
        ' 
        grbSerial.Controls.Add(lblSerial)
        grbSerial.Controls.Add(lblUser)
        grbSerial.Controls.Add(txtSerial)
        grbSerial.Controls.Add(txtUser)
        grbSerial.Controls.Add(lblSerialCode)
        grbSerial.Location = New Point(20, 332)
        grbSerial.Margin = New Padding(5, 5, 5, 5)
        grbSerial.Name = "grbSerial"
        grbSerial.Padding = New Padding(5, 5, 5, 5)
        grbSerial.Size = New Size(1183, 98)
        grbSerial.TabIndex = 113
        grbSerial.TabStop = False
        grbSerial.Text = "Serial"
        ' 
        ' lblSerial
        ' 
        lblSerial.AutoSize = True
        lblSerial.Location = New Point(547, 63)
        lblSerial.Margin = New Padding(5, 0, 5, 0)
        lblSerial.Name = "lblSerial"
        lblSerial.Size = New Size(57, 20)
        lblSerial.TabIndex = 12
        lblSerial.Text = "Serial:"
        ' 
        ' lblUser
        ' 
        lblUser.AutoSize = True
        lblUser.Location = New Point(547, 23)
        lblUser.Margin = New Padding(5, 0, 5, 0)
        lblUser.Name = "lblUser"
        lblUser.Size = New Size(50, 20)
        lblUser.TabIndex = 11
        lblUser.Text = "User:"
        ' 
        ' txtSerial
        ' 
        txtSerial.Location = New Point(617, 58)
        txtSerial.Margin = New Padding(5, 5, 5, 5)
        txtSerial.Name = "txtSerial"
        txtSerial.Size = New Size(541, 26)
        txtSerial.TabIndex = 10
        ' 
        ' txtUser
        ' 
        txtUser.AcceptsReturn = True
        txtUser.Location = New Point(617, 18)
        txtUser.Margin = New Padding(5, 5, 5, 5)
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(541, 26)
        txtUser.TabIndex = 0
        ' 
        ' lblSerialCode
        ' 
        lblSerialCode.AutoSize = True
        lblSerialCode.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSerialCode.Location = New Point(5, 40)
        lblSerialCode.Margin = New Padding(5, 0, 5, 0)
        lblSerialCode.Name = "lblSerialCode"
        lblSerialCode.Size = New Size(367, 25)
        lblSerialCode.TabIndex = 0
        lblSerialCode.Text = "Enter Serialcode First     >>>>>>>>>"
        ' 
        ' txtWarning
        ' 
        txtWarning.BackColor = SystemColors.Info
        txtWarning.BorderStyle = BorderStyle.FixedSingle
        txtWarning.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtWarning.Location = New Point(20, 9)
        txtWarning.Margin = New Padding(5, 5, 5, 5)
        txtWarning.Multiline = True
        txtWarning.Name = "txtWarning"
        txtWarning.ReadOnly = True
        txtWarning.Size = New Size(1187, 313)
        txtWarning.TabIndex = 112
        txtWarning.TextAlign = HorizontalAlignment.Center
        ' 
        ' grbAddress
        ' 
        grbAddress.Controls.Add(lblCRCCheck)
        grbAddress.Controls.Add(chkCRCCheck)
        grbAddress.Controls.Add(lblOperationTimeout)
        grbAddress.Controls.Add(Label2)
        grbAddress.Controls.Add(txtOperationTimeout)
        grbAddress.Controls.Add(btnSaveConnectionSettings)
        grbAddress.Controls.Add(lblRegisterMode)
        grbAddress.Controls.Add(cmbRegisterMode)
        grbAddress.Controls.Add(label1)
        grbAddress.Controls.Add(lblmaxIdleTime)
        grbAddress.Controls.Add(txtIdleTime)
        grbAddress.Controls.Add(grbSerialSettings)
        grbAddress.Controls.Add(grbIPSettings)
        grbAddress.Controls.Add(lblConnectionType)
        grbAddress.Controls.Add(cmbConnectionType)
        grbAddress.Enabled = False
        grbAddress.Location = New Point(20, 546)
        grbAddress.Margin = New Padding(5, 5, 5, 5)
        grbAddress.Name = "grbAddress"
        grbAddress.Padding = New Padding(5, 5, 5, 5)
        grbAddress.Size = New Size(1188, 318)
        grbAddress.TabIndex = 114
        grbAddress.TabStop = False
        ' 
        ' lblCRCCheck
        ' 
        lblCRCCheck.Location = New Point(180, 260)
        lblCRCCheck.Margin = New Padding(5, 0, 5, 0)
        lblCRCCheck.Name = "lblCRCCheck"
        lblCRCCheck.Size = New Size(187, 48)
        lblCRCCheck.TabIndex = 125
        lblCRCCheck.Text = "RTU/ASCII- CRC/LCR Check"
        lblCRCCheck.TextAlign = ContentAlignment.TopRight
        ' 
        ' chkCRCCheck
        ' 
        chkCRCCheck.AutoSize = True
        chkCRCCheck.Checked = True
        chkCRCCheck.CheckState = CheckState.Checked
        chkCRCCheck.Location = New Point(370, 275)
        chkCRCCheck.Margin = New Padding(5, 5, 5, 5)
        chkCRCCheck.Name = "chkCRCCheck"
        chkCRCCheck.Size = New Size(22, 21)
        chkCRCCheck.TabIndex = 124
        chkCRCCheck.UseVisualStyleBackColor = True
        ' 
        ' lblOperationTimeout
        ' 
        lblOperationTimeout.Location = New Point(3, 162)
        lblOperationTimeout.Margin = New Padding(5, 0, 5, 0)
        lblOperationTimeout.Name = "lblOperationTimeout"
        lblOperationTimeout.Size = New Size(175, 28)
        lblOperationTimeout.TabIndex = 121
        lblOperationTimeout.Text = "OperationTimeout"
        lblOperationTimeout.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(370, 163)
        Label2.Margin = New Padding(5, 0, 5, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(32, 20)
        Label2.TabIndex = 120
        Label2.Text = "ms"
        ' 
        ' txtOperationTimeout
        ' 
        txtOperationTimeout.Location = New Point(180, 158)
        txtOperationTimeout.Margin = New Padding(5, 5, 5, 5)
        txtOperationTimeout.Name = "txtOperationTimeout"
        txtOperationTimeout.Size = New Size(184, 26)
        txtOperationTimeout.TabIndex = 119
        txtOperationTimeout.Text = "2000"
        ' 
        ' btnSaveConnectionSettings
        ' 
        btnSaveConnectionSettings.Image = CType(resources.GetObject("btnSaveConnectionSettings.Image"), Image)
        btnSaveConnectionSettings.ImageAlign = ContentAlignment.TopCenter
        btnSaveConnectionSettings.Location = New Point(25, 195)
        btnSaveConnectionSettings.Margin = New Padding(5, 5, 5, 5)
        btnSaveConnectionSettings.Name = "btnSaveConnectionSettings"
        btnSaveConnectionSettings.Size = New Size(113, 105)
        btnSaveConnectionSettings.TabIndex = 118
        btnSaveConnectionSettings.Text = "save settings"
        btnSaveConnectionSettings.TextAlign = ContentAlignment.BottomCenter
        btnSaveConnectionSettings.UseVisualStyleBackColor = True
        ' 
        ' lblRegisterMode
        ' 
        lblRegisterMode.Location = New Point(3, 74)
        lblRegisterMode.Margin = New Padding(5, 0, 5, 0)
        lblRegisterMode.Name = "lblRegisterMode"
        lblRegisterMode.Size = New Size(175, 28)
        lblRegisterMode.TabIndex = 72
        lblRegisterMode.Text = "RegisterMode"
        lblRegisterMode.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbRegisterMode
        ' 
        cmbRegisterMode.FormattingEnabled = True
        cmbRegisterMode.Location = New Point(180, 77)
        cmbRegisterMode.Margin = New Padding(5, 5, 5, 5)
        cmbRegisterMode.Name = "cmbRegisterMode"
        cmbRegisterMode.Size = New Size(184, 28)
        cmbRegisterMode.TabIndex = 71
        ' 
        ' label1
        ' 
        label1.AutoSize = True
        label1.Location = New Point(370, 123)
        label1.Margin = New Padding(5, 0, 5, 0)
        label1.Name = "label1"
        label1.Size = New Size(32, 20)
        label1.TabIndex = 70
        label1.Text = "ms"
        ' 
        ' lblmaxIdleTime
        ' 
        lblmaxIdleTime.Location = New Point(7, 103)
        lblmaxIdleTime.Margin = New Padding(5, 0, 5, 0)
        lblmaxIdleTime.Name = "lblmaxIdleTime"
        lblmaxIdleTime.Size = New Size(172, 60)
        lblmaxIdleTime.TabIndex = 69
        lblmaxIdleTime.Text = "max. idle time to close the port"
        lblmaxIdleTime.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' txtIdleTime
        ' 
        txtIdleTime.Location = New Point(180, 118)
        txtIdleTime.Margin = New Padding(5, 5, 5, 5)
        txtIdleTime.Name = "txtIdleTime"
        txtIdleTime.Size = New Size(184, 26)
        txtIdleTime.TabIndex = 68
        txtIdleTime.Text = "3000"
        ' 
        ' grbSerialSettings
        ' 
        grbSerialSettings.Controls.Add(lblHandshake)
        grbSerialSettings.Controls.Add(lblStopBits)
        grbSerialSettings.Controls.Add(lblDataBits)
        grbSerialSettings.Controls.Add(lblParity)
        grbSerialSettings.Controls.Add(cmbHandshake)
        grbSerialSettings.Controls.Add(cmbDataBits)
        grbSerialSettings.Controls.Add(lblSerialPort)
        grbSerialSettings.Controls.Add(cmbStopbits)
        grbSerialSettings.Controls.Add(cmbParity)
        grbSerialSettings.Controls.Add(cmbSerialPort)
        grbSerialSettings.Controls.Add(lblBaudrate)
        grbSerialSettings.Controls.Add(cmbBaudrate)
        grbSerialSettings.Location = New Point(837, 20)
        grbSerialSettings.Margin = New Padding(5, 5, 5, 5)
        grbSerialSettings.Name = "grbSerialSettings"
        grbSerialSettings.Padding = New Padding(5, 5, 5, 5)
        grbSerialSettings.Size = New Size(342, 289)
        grbSerialSettings.TabIndex = 41
        grbSerialSettings.TabStop = False
        ' 
        ' lblSerialPort
        ' 
        lblSerialPort.Location = New Point(18, 28)
        lblSerialPort.Margin = New Padding(5, 0, 5, 0)
        lblSerialPort.Name = "lblSerialPort"
        lblSerialPort.Size = New Size(87, 20)
        lblSerialPort.TabIndex = 44
        lblSerialPort.Text = "serial port"
        lblSerialPort.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbStopbits
        ' 
        cmbStopbits.FormattingEnabled = True
        cmbStopbits.Location = New Point(122, 194)
        cmbStopbits.Margin = New Padding(5, 5, 5, 5)
        cmbStopbits.Name = "cmbStopbits"
        cmbStopbits.Size = New Size(184, 28)
        cmbStopbits.TabIndex = 42
        ' 
        ' cmbParity
        ' 
        cmbParity.FormattingEnabled = True
        cmbParity.Location = New Point(122, 111)
        cmbParity.Margin = New Padding(5, 5, 5, 5)
        cmbParity.Name = "cmbParity"
        cmbParity.Size = New Size(184, 28)
        cmbParity.TabIndex = 41
        ' 
        ' cmbSerialPort
        ' 
        cmbSerialPort.FormattingEnabled = True
        cmbSerialPort.Location = New Point(122, 23)
        cmbSerialPort.Margin = New Padding(5, 5, 5, 5)
        cmbSerialPort.Name = "cmbSerialPort"
        cmbSerialPort.Size = New Size(184, 28)
        cmbSerialPort.TabIndex = 40
        ' 
        ' lblBaudrate
        ' 
        lblBaudrate.Location = New Point(22, 74)
        lblBaudrate.Margin = New Padding(5, 0, 5, 0)
        lblBaudrate.Name = "lblBaudrate"
        lblBaudrate.Size = New Size(82, 20)
        lblBaudrate.TabIndex = 39
        lblBaudrate.Text = "baudrate"
        lblBaudrate.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbBaudrate
        ' 
        cmbBaudrate.FormattingEnabled = True
        cmbBaudrate.Location = New Point(122, 68)
        cmbBaudrate.Margin = New Padding(5, 5, 5, 5)
        cmbBaudrate.Name = "cmbBaudrate"
        cmbBaudrate.Size = New Size(184, 28)
        cmbBaudrate.TabIndex = 38
        ' 
        ' lblLanguage
        ' 
        lblLanguage.Location = New Point(542, 445)
        lblLanguage.Margin = New Padding(5, 0, 5, 0)
        lblLanguage.Name = "lblLanguage"
        lblLanguage.Size = New Size(85, 20)
        lblLanguage.TabIndex = 130
        lblLanguage.Text = "language"
        lblLanguage.TextAlign = ContentAlignment.TopRight
        ' 
        ' cmbLanguage
        ' 
        cmbLanguage.FormattingEnabled = True
        cmbLanguage.Location = New Point(637, 440)
        cmbLanguage.Margin = New Padding(5, 5, 5, 5)
        cmbLanguage.Name = "cmbLanguage"
        cmbLanguage.Size = New Size(184, 28)
        cmbLanguage.TabIndex = 129
        ' 
        ' main
        ' 
        AutoScaleDimensions = New SizeF(10F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1218, 1063)
        Controls.Add(lblLanguage)
        Controls.Add(cmbLanguage)
        Controls.Add(panelStatusStrip)
        Controls.Add(btnEditConnectionSettings)
        Controls.Add(groupBox1)
        Controls.Add(grbSerial)
        Controls.Add(txtWarning)
        Controls.Add(grbAddress)
        Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(5, 5, 5, 5)
        MaximizeBox = False
        Name = "main"
        StartPosition = FormStartPosition.CenterScreen
        Text = "start example"
        grbFunctions.ResumeLayout(False)
        grbIPSettings.ResumeLayout(False)
        grbIPSettings.PerformLayout()
        panelStatusStrip.ResumeLayout(False)
        panelStatusStrip.PerformLayout()
        statusStrip.ResumeLayout(False)
        statusStrip.PerformLayout()
        groupBox1.ResumeLayout(False)
        grbSerial.ResumeLayout(False)
        grbSerial.PerformLayout()
        grbAddress.ResumeLayout(False)
        grbAddress.PerformLayout()
        grbSerialSettings.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents lblHandshake As System.Windows.Forms.Label
    Friend WithEvents lblStopBits As System.Windows.Forms.Label
    Friend WithEvents lblDataBits As System.Windows.Forms.Label
    Friend WithEvents cmbHandshake As System.Windows.Forms.ComboBox
    Private WithEvents grbFunctions As System.Windows.Forms.Panel
    Private WithEvents btnReadWriteModbus As System.Windows.Forms.Button
    Private WithEvents btnOtherFunctions As System.Windows.Forms.Button
    Private WithEvents btnReadCollection As System.Windows.Forms.Button
    Private WithEvents btnCertificateManager As System.Windows.Forms.Button
    Private WithEvents grbIPSettings As System.Windows.Forms.GroupBox
    Friend WithEvents txtLocalPort As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress0 As System.Windows.Forms.Label
    Friend WithEvents txtAddressIP As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress1 As System.Windows.Forms.Label
    Friend WithEvents txtRemotePort As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress2 As System.Windows.Forms.Label
    Friend WithEvents lblParity As System.Windows.Forms.Label
    Friend WithEvents lblConnectionType As System.Windows.Forms.Label
    Friend WithEvents cmbConnectionType As System.Windows.Forms.ComboBox
    Private WithEvents panelStatusStrip As System.Windows.Forms.Panel
    Private WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Private WithEvents txtDeviceState As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents lblDeviceType As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents lblDeviceGUID As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents btnEditConnectionSettings As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbDataBits As System.Windows.Forms.ComboBox
    Friend WithEvents grbSerial As System.Windows.Forms.GroupBox
    Friend WithEvents lblSerial As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtSerial As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblSerialCode As System.Windows.Forms.Label
    Private WithEvents txtWarning As System.Windows.Forms.TextBox
    Private WithEvents grbAddress As System.Windows.Forms.GroupBox
    Private WithEvents btnSaveConnectionSettings As System.Windows.Forms.Button
    Friend WithEvents lblRegisterMode As System.Windows.Forms.Label
    Friend WithEvents cmbRegisterMode As System.Windows.Forms.ComboBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents lblmaxIdleTime As System.Windows.Forms.Label
    Friend WithEvents txtIdleTime As System.Windows.Forms.TextBox
    Private WithEvents grbSerialSettings As System.Windows.Forms.GroupBox
    Friend WithEvents lblSerialPort As System.Windows.Forms.Label
    Friend WithEvents cmbStopbits As System.Windows.Forms.ComboBox
    Friend WithEvents cmbParity As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSerialPort As System.Windows.Forms.ComboBox
    Friend WithEvents lblBaudrate As System.Windows.Forms.Label
    Friend WithEvents cmbBaudrate As System.Windows.Forms.ComboBox
    Private WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents cmbLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblNetworkAddressFamily As System.Windows.Forms.Label
    Friend WithEvents cmbNetworkAddressFamily As System.Windows.Forms.ComboBox
    Friend WithEvents lblOperationTimeout As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOperationTimeout As TextBox
    Friend WithEvents lblCRCCheck As Label
    Private WithEvents chkCRCCheck As CheckBox
End Class
