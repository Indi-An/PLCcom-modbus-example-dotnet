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
        chkSupportsFC02 = New CheckBox()
        btnRemoveListener = New Button()
        btnStopSlave = New Button()
        btnAddListener = New Button()
        lvListener = New ListView()
        colName = New ColumnHeader()
        colType = New ColumnHeader()
        colParameter = New ColumnHeader()
        chkAutoScroll = New CheckBox()
        chkLogging = New CheckBox()
        lvLog = New ListView()
        colText = New ColumnHeader()
        lblLogLevel = New Label()
        cmbLogLevel = New ComboBox()
        grbDataStore = New GroupBox()
        grbValues = New GroupBox()
        rbValueOFF = New RadioButton()
        rbValueOn = New RadioButton()
        btnSetValue = New Button()
        chkBit27 = New CheckBox()
        chkBit26 = New CheckBox()
        chkBit25 = New CheckBox()
        chkBit24 = New CheckBox()
        chkBit28 = New CheckBox()
        chkBit29 = New CheckBox()
        chkBit30 = New CheckBox()
        chkBit31 = New CheckBox()
        chkBit19 = New CheckBox()
        chkBit18 = New CheckBox()
        chkBit17 = New CheckBox()
        chkBit16 = New CheckBox()
        chkBit20 = New CheckBox()
        chkBit21 = New CheckBox()
        chkBit22 = New CheckBox()
        chkBit23 = New CheckBox()
        chkBit11 = New CheckBox()
        chkBit10 = New CheckBox()
        chkBit9 = New CheckBox()
        chkBit8 = New CheckBox()
        chkBit12 = New CheckBox()
        chkBit13 = New CheckBox()
        chkBit14 = New CheckBox()
        chkBit15 = New CheckBox()
        chkBit3 = New CheckBox()
        chkBit2 = New CheckBox()
        chkBit1 = New CheckBox()
        chkBit0 = New CheckBox()
        chkBit4 = New CheckBox()
        chkBit5 = New CheckBox()
        chkBit6 = New CheckBox()
        chkBit7 = New CheckBox()
        txtValue = New TextBox()
        txtAddress = New TextBox()
        lblValue = New Label()
        lblAddress = New Label()
        grbAddressType = New GroupBox()
        rbRegisterTypeDiscreteInputs = New RadioButton()
        rbRegisterTypeCoils = New RadioButton()
        rbRegisterTypeInputRegister = New RadioButton()
        rbRegisterTypeHoldingRegister = New RadioButton()
        lvValues = New ListView()
        colDummy = New ColumnHeader()
        colAddress = New ColumnHeader()
        colValue = New ColumnHeader()
        grbLog = New GroupBox()
        cmbLanguage = New ComboBox()
        btnCopyLogtoClipboard = New Button()
        btnCopyLogtoFile = New Button()
        btnCertificateManager = New Button()
        btnLoadSettings = New Button()
        btnClose = New Button()
        btnSaveSettings = New Button()
        chkSupportsFC01 = New CheckBox()
        lblLanguage = New Label()
        txtUnparseableRequests = New TextBox()
        lblUnparseableRequests = New Label()
        txtIncorectRequests = New TextBox()
        txtIncomingRequests = New TextBox()
        grbStatistics = New GroupBox()
        lblIncorrectRequests = New Label()
        lblIncomingRequests = New Label()
        txtOutgoingBytes = New TextBox()
        txtIncomingBytes = New TextBox()
        lblOutgoingBytes = New Label()
        lblIncomingBytes = New Label()
        grbListener = New GroupBox()
        grbSlaveSettings = New GroupBox()
        cmbByteOrder = New ComboBox()
        lblByteOrder = New Label()
        cmbRegisterMode = New ComboBox()
        lblRegisterMode = New Label()
        cmbSlaveID = New ComboBox()
        lblSlaveID = New Label()
        grbSupportedFunctions = New GroupBox()
        chkSupportsFC23 = New CheckBox()
        chkSupportsFC16 = New CheckBox()
        chkSupportsFC15 = New CheckBox()
        chkSupportsFC08 = New CheckBox()
        chkSupportsFC06 = New CheckBox()
        chkSupportsFC05 = New CheckBox()
        chkSupportsFC04 = New CheckBox()
        chkSupportsFC03 = New CheckBox()
        btnStartSlave = New Button()
        lblSerial = New Label()
        lblUser = New Label()
        txtSerial = New TextBox()
        txtUser = New TextBox()
        lblSerialCode = New Label()
        grbSerial = New GroupBox()
        grbDataStore.SuspendLayout()
        grbValues.SuspendLayout()
        grbAddressType.SuspendLayout()
        grbLog.SuspendLayout()
        grbStatistics.SuspendLayout()
        grbListener.SuspendLayout()
        grbSlaveSettings.SuspendLayout()
        grbSupportedFunctions.SuspendLayout()
        grbSerial.SuspendLayout()
        SuspendLayout()
        ' 
        ' chkSupportsFC02
        ' 
        chkSupportsFC02.AutoSize = True
        chkSupportsFC02.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC02.Checked = True
        chkSupportsFC02.CheckState = CheckState.Checked
        chkSupportsFC02.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC02.FlatAppearance.BorderSize = 2
        chkSupportsFC02.FlatStyle = FlatStyle.Flat
        chkSupportsFC02.Location = New Point(97, 25)
        chkSupportsFC02.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC02.Name = "chkSupportsFC02"
        chkSupportsFC02.Size = New Size(53, 40)
        chkSupportsFC02.TabIndex = 91
        chkSupportsFC02.Text = "FC02"
        chkSupportsFC02.UseVisualStyleBackColor = True
        ' 
        ' btnRemoveListener
        ' 
        btnRemoveListener.Enabled = False
        btnRemoveListener.Image = CType(resources.GetObject("btnRemoveListener.Image"), Image)
        btnRemoveListener.ImageAlign = ContentAlignment.TopCenter
        btnRemoveListener.Location = New Point(145, 142)
        btnRemoveListener.Margin = New Padding(5, 5, 5, 5)
        btnRemoveListener.Name = "btnRemoveListener"
        btnRemoveListener.Size = New Size(113, 105)
        btnRemoveListener.TabIndex = 3
        btnRemoveListener.Text = "remove listener"
        btnRemoveListener.TextAlign = ContentAlignment.BottomCenter
        btnRemoveListener.UseVisualStyleBackColor = True
        ' 
        ' btnStopSlave
        ' 
        btnStopSlave.Enabled = False
        btnStopSlave.Image = CType(resources.GetObject("btnStopSlave.Image"), Image)
        btnStopSlave.ImageAlign = ContentAlignment.TopCenter
        btnStopSlave.Location = New Point(145, 25)
        btnStopSlave.Margin = New Padding(5, 5, 5, 5)
        btnStopSlave.Name = "btnStopSlave"
        btnStopSlave.Size = New Size(113, 105)
        btnStopSlave.TabIndex = 75
        btnStopSlave.Text = "Stop Slave"
        btnStopSlave.TextAlign = ContentAlignment.BottomCenter
        btnStopSlave.UseVisualStyleBackColor = True
        ' 
        ' btnAddListener
        ' 
        btnAddListener.Enabled = False
        btnAddListener.Image = CType(resources.GetObject("btnAddListener.Image"), Image)
        btnAddListener.ImageAlign = ContentAlignment.TopCenter
        btnAddListener.Location = New Point(13, 142)
        btnAddListener.Margin = New Padding(5, 5, 5, 5)
        btnAddListener.Name = "btnAddListener"
        btnAddListener.Size = New Size(113, 105)
        btnAddListener.TabIndex = 2
        btnAddListener.Text = "add listener"
        btnAddListener.TextAlign = ContentAlignment.BottomCenter
        btnAddListener.UseVisualStyleBackColor = True
        ' 
        ' lvListener
        ' 
        lvListener.Activation = ItemActivation.OneClick
        lvListener.Columns.AddRange(New ColumnHeader() {colName, colType, colParameter})
        lvListener.FullRowSelect = True
        lvListener.HeaderStyle = ColumnHeaderStyle.Nonclickable
        lvListener.Location = New Point(13, 254)
        lvListener.Margin = New Padding(5, 5, 5, 5)
        lvListener.MultiSelect = False
        lvListener.Name = "lvListener"
        lvListener.Size = New Size(1139, 293)
        lvListener.TabIndex = 0
        lvListener.UseCompatibleStateImageBehavior = False
        lvListener.View = View.Details
        ' 
        ' colName
        ' 
        colName.Text = "Listener Name"
        colName.Width = 85
        ' 
        ' colType
        ' 
        colType.Text = "Type"
        colType.Width = 43
        ' 
        ' colParameter
        ' 
        colParameter.Text = "Parameter"
        colParameter.Width = 530
        ' 
        ' chkAutoScroll
        ' 
        chkAutoScroll.AutoSize = True
        chkAutoScroll.Checked = True
        chkAutoScroll.CheckState = CheckState.Checked
        chkAutoScroll.Location = New Point(700, 1148)
        chkAutoScroll.Margin = New Padding(5, 5, 5, 5)
        chkAutoScroll.Name = "chkAutoScroll"
        chkAutoScroll.Size = New Size(106, 24)
        chkAutoScroll.TabIndex = 131
        chkAutoScroll.Text = "AutoScoll"
        chkAutoScroll.UseVisualStyleBackColor = True
        ' 
        ' chkLogging
        ' 
        chkLogging.AutoSize = True
        chkLogging.Checked = True
        chkLogging.CheckState = CheckState.Checked
        chkLogging.Location = New Point(700, 1112)
        chkLogging.Margin = New Padding(5, 5, 5, 5)
        chkLogging.Name = "chkLogging"
        chkLogging.Size = New Size(166, 24)
        chkLogging.TabIndex = 129
        chkLogging.Text = "Diagnostic output"
        chkLogging.UseVisualStyleBackColor = True
        ' 
        ' lvLog
        ' 
        lvLog.Columns.AddRange(New ColumnHeader() {colText})
        lvLog.HeaderStyle = ColumnHeaderStyle.None
        lvLog.Location = New Point(18, 26)
        lvLog.Margin = New Padding(5, 5, 5, 5)
        lvLog.MultiSelect = False
        lvLog.Name = "lvLog"
        lvLog.ShowGroups = False
        lvLog.Size = New Size(1732, 376)
        lvLog.TabIndex = 78
        lvLog.UseCompatibleStateImageBehavior = False
        lvLog.View = View.Details
        ' 
        ' colText
        ' 
        colText.Text = "Text"
        colText.Width = 6000
        ' 
        ' lblLogLevel
        ' 
        lblLogLevel.AutoSize = True
        lblLogLevel.Location = New Point(422, 1118)
        lblLogLevel.Margin = New Padding(5, 0, 5, 0)
        lblLogLevel.Name = "lblLogLevel"
        lblLogLevel.Size = New Size(77, 20)
        lblLogLevel.TabIndex = 136
        lblLogLevel.Text = "LogLevel"
        ' 
        ' cmbLogLevel
        ' 
        cmbLogLevel.FormattingEnabled = True
        cmbLogLevel.Location = New Point(517, 1114)
        cmbLogLevel.Margin = New Padding(5, 5, 5, 5)
        cmbLogLevel.Name = "cmbLogLevel"
        cmbLogLevel.Size = New Size(149, 28)
        cmbLogLevel.TabIndex = 134
        ' 
        ' grbDataStore
        ' 
        grbDataStore.Controls.Add(grbValues)
        grbDataStore.Controls.Add(grbAddressType)
        grbDataStore.Controls.Add(lvValues)
        grbDataStore.Enabled = False
        grbDataStore.Location = New Point(1207, 14)
        grbDataStore.Margin = New Padding(5, 5, 5, 5)
        grbDataStore.Name = "grbDataStore"
        grbDataStore.Padding = New Padding(5, 5, 5, 5)
        grbDataStore.Size = New Size(578, 663)
        grbDataStore.TabIndex = 132
        grbDataStore.TabStop = False
        grbDataStore.Text = "DataStore"
        ' 
        ' grbValues
        ' 
        grbValues.Controls.Add(rbValueOFF)
        grbValues.Controls.Add(rbValueOn)
        grbValues.Controls.Add(btnSetValue)
        grbValues.Controls.Add(chkBit27)
        grbValues.Controls.Add(chkBit26)
        grbValues.Controls.Add(chkBit25)
        grbValues.Controls.Add(chkBit24)
        grbValues.Controls.Add(chkBit28)
        grbValues.Controls.Add(chkBit29)
        grbValues.Controls.Add(chkBit30)
        grbValues.Controls.Add(chkBit31)
        grbValues.Controls.Add(chkBit19)
        grbValues.Controls.Add(chkBit18)
        grbValues.Controls.Add(chkBit17)
        grbValues.Controls.Add(chkBit16)
        grbValues.Controls.Add(chkBit20)
        grbValues.Controls.Add(chkBit21)
        grbValues.Controls.Add(chkBit22)
        grbValues.Controls.Add(chkBit23)
        grbValues.Controls.Add(chkBit11)
        grbValues.Controls.Add(chkBit10)
        grbValues.Controls.Add(chkBit9)
        grbValues.Controls.Add(chkBit8)
        grbValues.Controls.Add(chkBit12)
        grbValues.Controls.Add(chkBit13)
        grbValues.Controls.Add(chkBit14)
        grbValues.Controls.Add(chkBit15)
        grbValues.Controls.Add(chkBit3)
        grbValues.Controls.Add(chkBit2)
        grbValues.Controls.Add(chkBit1)
        grbValues.Controls.Add(chkBit0)
        grbValues.Controls.Add(chkBit4)
        grbValues.Controls.Add(chkBit5)
        grbValues.Controls.Add(chkBit6)
        grbValues.Controls.Add(chkBit7)
        grbValues.Controls.Add(txtValue)
        grbValues.Controls.Add(txtAddress)
        grbValues.Controls.Add(lblValue)
        grbValues.Controls.Add(lblAddress)
        grbValues.Location = New Point(15, 100)
        grbValues.Margin = New Padding(5, 5, 5, 5)
        grbValues.Name = "grbValues"
        grbValues.Padding = New Padding(5, 5, 5, 5)
        grbValues.Size = New Size(550, 245)
        grbValues.TabIndex = 2
        grbValues.TabStop = False
        grbValues.Text = "set new value"
        ' 
        ' rbValueOFF
        ' 
        rbValueOFF.AutoSize = True
        rbValueOFF.FlatStyle = FlatStyle.Flat
        rbValueOFF.Location = New Point(257, 95)
        rbValueOFF.Margin = New Padding(5, 5, 5, 5)
        rbValueOFF.Name = "rbValueOFF"
        rbValueOFF.Size = New Size(68, 24)
        rbValueOFF.TabIndex = 46
        rbValueOFF.Text = "false"
        rbValueOFF.UseVisualStyleBackColor = True
        ' 
        ' rbValueOn
        ' 
        rbValueOn.AutoSize = True
        rbValueOn.Checked = True
        rbValueOn.FlatStyle = FlatStyle.Flat
        rbValueOn.Location = New Point(165, 94)
        rbValueOn.Margin = New Padding(5, 5, 5, 5)
        rbValueOn.Name = "rbValueOn"
        rbValueOn.Size = New Size(61, 24)
        rbValueOn.TabIndex = 45
        rbValueOn.TabStop = True
        rbValueOn.Text = "true"
        rbValueOn.UseVisualStyleBackColor = True
        ' 
        ' btnSetValue
        ' 
        btnSetValue.Enabled = False
        btnSetValue.Image = CType(resources.GetObject("btnSetValue.Image"), Image)
        btnSetValue.ImageAlign = ContentAlignment.TopCenter
        btnSetValue.Location = New Point(427, 20)
        btnSetValue.Margin = New Padding(5, 5, 5, 5)
        btnSetValue.Name = "btnSetValue"
        btnSetValue.Size = New Size(113, 105)
        btnSetValue.TabIndex = 36
        btnSetValue.Text = "set value"
        btnSetValue.TextAlign = ContentAlignment.BottomCenter
        btnSetValue.UseVisualStyleBackColor = True
        ' 
        ' chkBit27
        ' 
        chkBit27.AutoSize = True
        chkBit27.CheckAlign = ContentAlignment.TopCenter
        chkBit27.Enabled = False
        chkBit27.FlatAppearance.BorderColor = Color.Red
        chkBit27.FlatAppearance.BorderSize = 2
        chkBit27.FlatStyle = FlatStyle.Flat
        chkBit27.Location = New Point(133, 180)
        chkBit27.Margin = New Padding(5, 5, 5, 5)
        chkBit27.Name = "chkBit27"
        chkBit27.Size = New Size(31, 40)
        chkBit27.TabIndex = 35
        chkBit27.Text = "27"
        chkBit27.UseVisualStyleBackColor = True
        ' 
        ' chkBit26
        ' 
        chkBit26.AutoSize = True
        chkBit26.CheckAlign = ContentAlignment.TopCenter
        chkBit26.Enabled = False
        chkBit26.FlatAppearance.BorderColor = Color.Red
        chkBit26.FlatAppearance.BorderSize = 2
        chkBit26.FlatStyle = FlatStyle.Flat
        chkBit26.Location = New Point(167, 180)
        chkBit26.Margin = New Padding(5, 5, 5, 5)
        chkBit26.Name = "chkBit26"
        chkBit26.Size = New Size(31, 40)
        chkBit26.TabIndex = 34
        chkBit26.Text = "26"
        chkBit26.UseVisualStyleBackColor = True
        ' 
        ' chkBit25
        ' 
        chkBit25.AutoSize = True
        chkBit25.CheckAlign = ContentAlignment.TopCenter
        chkBit25.Enabled = False
        chkBit25.FlatAppearance.BorderColor = Color.Red
        chkBit25.FlatAppearance.BorderSize = 2
        chkBit25.FlatStyle = FlatStyle.Flat
        chkBit25.Location = New Point(198, 180)
        chkBit25.Margin = New Padding(5, 5, 5, 5)
        chkBit25.Name = "chkBit25"
        chkBit25.Size = New Size(31, 40)
        chkBit25.TabIndex = 33
        chkBit25.Text = "25"
        chkBit25.UseVisualStyleBackColor = True
        ' 
        ' chkBit24
        ' 
        chkBit24.AutoSize = True
        chkBit24.CheckAlign = ContentAlignment.TopCenter
        chkBit24.Enabled = False
        chkBit24.FlatAppearance.BorderColor = Color.Red
        chkBit24.FlatAppearance.BorderSize = 2
        chkBit24.FlatStyle = FlatStyle.Flat
        chkBit24.Location = New Point(233, 180)
        chkBit24.Margin = New Padding(5, 5, 5, 5)
        chkBit24.Name = "chkBit24"
        chkBit24.Size = New Size(31, 40)
        chkBit24.TabIndex = 32
        chkBit24.Text = "24"
        chkBit24.UseVisualStyleBackColor = True
        ' 
        ' chkBit28
        ' 
        chkBit28.AutoSize = True
        chkBit28.CheckAlign = ContentAlignment.TopCenter
        chkBit28.Enabled = False
        chkBit28.FlatAppearance.BorderColor = Color.Red
        chkBit28.FlatAppearance.BorderSize = 2
        chkBit28.FlatStyle = FlatStyle.Flat
        chkBit28.Location = New Point(102, 180)
        chkBit28.Margin = New Padding(5, 5, 5, 5)
        chkBit28.Name = "chkBit28"
        chkBit28.Size = New Size(31, 40)
        chkBit28.TabIndex = 31
        chkBit28.Text = "28"
        chkBit28.UseVisualStyleBackColor = True
        ' 
        ' chkBit29
        ' 
        chkBit29.AutoSize = True
        chkBit29.CheckAlign = ContentAlignment.TopCenter
        chkBit29.Enabled = False
        chkBit29.FlatAppearance.BorderColor = Color.Red
        chkBit29.FlatAppearance.BorderSize = 2
        chkBit29.FlatStyle = FlatStyle.Flat
        chkBit29.Location = New Point(68, 180)
        chkBit29.Margin = New Padding(5, 5, 5, 5)
        chkBit29.Name = "chkBit29"
        chkBit29.Size = New Size(31, 40)
        chkBit29.TabIndex = 30
        chkBit29.Text = "29"
        chkBit29.UseVisualStyleBackColor = True
        ' 
        ' chkBit30
        ' 
        chkBit30.AutoSize = True
        chkBit30.CheckAlign = ContentAlignment.TopCenter
        chkBit30.Enabled = False
        chkBit30.FlatAppearance.BorderColor = Color.Red
        chkBit30.FlatAppearance.BorderSize = 2
        chkBit30.FlatStyle = FlatStyle.Flat
        chkBit30.Location = New Point(35, 180)
        chkBit30.Margin = New Padding(5, 5, 5, 5)
        chkBit30.Name = "chkBit30"
        chkBit30.Size = New Size(31, 40)
        chkBit30.TabIndex = 29
        chkBit30.Text = "30"
        chkBit30.UseVisualStyleBackColor = True
        ' 
        ' chkBit31
        ' 
        chkBit31.AutoSize = True
        chkBit31.CheckAlign = ContentAlignment.TopCenter
        chkBit31.Enabled = False
        chkBit31.FlatAppearance.BorderColor = Color.Red
        chkBit31.FlatAppearance.BorderSize = 2
        chkBit31.FlatStyle = FlatStyle.Flat
        chkBit31.Location = New Point(3, 180)
        chkBit31.Margin = New Padding(5, 5, 5, 5)
        chkBit31.Name = "chkBit31"
        chkBit31.Size = New Size(31, 40)
        chkBit31.TabIndex = 28
        chkBit31.Text = "31"
        chkBit31.UseVisualStyleBackColor = True
        ' 
        ' chkBit19
        ' 
        chkBit19.AutoSize = True
        chkBit19.CheckAlign = ContentAlignment.TopCenter
        chkBit19.Enabled = False
        chkBit19.FlatAppearance.BorderColor = Color.Red
        chkBit19.FlatAppearance.BorderSize = 2
        chkBit19.FlatStyle = FlatStyle.Flat
        chkBit19.Location = New Point(405, 180)
        chkBit19.Margin = New Padding(5, 5, 5, 5)
        chkBit19.Name = "chkBit19"
        chkBit19.Size = New Size(31, 40)
        chkBit19.TabIndex = 27
        chkBit19.Text = "19"
        chkBit19.UseVisualStyleBackColor = True
        ' 
        ' chkBit18
        ' 
        chkBit18.AutoSize = True
        chkBit18.CheckAlign = ContentAlignment.TopCenter
        chkBit18.Enabled = False
        chkBit18.FlatAppearance.BorderColor = Color.Red
        chkBit18.FlatAppearance.BorderSize = 2
        chkBit18.FlatStyle = FlatStyle.Flat
        chkBit18.Location = New Point(440, 180)
        chkBit18.Margin = New Padding(5, 5, 5, 5)
        chkBit18.Name = "chkBit18"
        chkBit18.Size = New Size(31, 40)
        chkBit18.TabIndex = 26
        chkBit18.Text = "18"
        chkBit18.UseVisualStyleBackColor = True
        ' 
        ' chkBit17
        ' 
        chkBit17.AutoSize = True
        chkBit17.CheckAlign = ContentAlignment.TopCenter
        chkBit17.Enabled = False
        chkBit17.FlatAppearance.BorderColor = Color.Red
        chkBit17.FlatAppearance.BorderSize = 2
        chkBit17.FlatStyle = FlatStyle.Flat
        chkBit17.Location = New Point(473, 180)
        chkBit17.Margin = New Padding(5, 5, 5, 5)
        chkBit17.Name = "chkBit17"
        chkBit17.Size = New Size(31, 40)
        chkBit17.TabIndex = 25
        chkBit17.Text = "17"
        chkBit17.UseVisualStyleBackColor = True
        ' 
        ' chkBit16
        ' 
        chkBit16.AutoSize = True
        chkBit16.CheckAlign = ContentAlignment.TopCenter
        chkBit16.Enabled = False
        chkBit16.FlatAppearance.BorderColor = Color.Red
        chkBit16.FlatAppearance.BorderSize = 2
        chkBit16.FlatStyle = FlatStyle.Flat
        chkBit16.Location = New Point(508, 180)
        chkBit16.Margin = New Padding(5, 5, 5, 5)
        chkBit16.Name = "chkBit16"
        chkBit16.Size = New Size(31, 40)
        chkBit16.TabIndex = 24
        chkBit16.Text = "16"
        chkBit16.UseVisualStyleBackColor = True
        ' 
        ' chkBit20
        ' 
        chkBit20.AutoSize = True
        chkBit20.CheckAlign = ContentAlignment.TopCenter
        chkBit20.Enabled = False
        chkBit20.FlatAppearance.BorderColor = Color.Red
        chkBit20.FlatAppearance.BorderSize = 2
        chkBit20.FlatStyle = FlatStyle.Flat
        chkBit20.Location = New Point(370, 180)
        chkBit20.Margin = New Padding(5, 5, 5, 5)
        chkBit20.Name = "chkBit20"
        chkBit20.Size = New Size(31, 40)
        chkBit20.TabIndex = 23
        chkBit20.Text = "20"
        chkBit20.UseVisualStyleBackColor = True
        ' 
        ' chkBit21
        ' 
        chkBit21.AutoSize = True
        chkBit21.CheckAlign = ContentAlignment.TopCenter
        chkBit21.Enabled = False
        chkBit21.FlatAppearance.BorderColor = Color.Red
        chkBit21.FlatAppearance.BorderSize = 2
        chkBit21.FlatStyle = FlatStyle.Flat
        chkBit21.Location = New Point(333, 180)
        chkBit21.Margin = New Padding(5, 5, 5, 5)
        chkBit21.Name = "chkBit21"
        chkBit21.Size = New Size(31, 40)
        chkBit21.TabIndex = 22
        chkBit21.Text = "21"
        chkBit21.UseVisualStyleBackColor = True
        ' 
        ' chkBit22
        ' 
        chkBit22.AutoSize = True
        chkBit22.CheckAlign = ContentAlignment.TopCenter
        chkBit22.Enabled = False
        chkBit22.FlatAppearance.BorderColor = Color.Red
        chkBit22.FlatAppearance.BorderSize = 2
        chkBit22.FlatStyle = FlatStyle.Flat
        chkBit22.Location = New Point(298, 180)
        chkBit22.Margin = New Padding(5, 5, 5, 5)
        chkBit22.Name = "chkBit22"
        chkBit22.Size = New Size(31, 40)
        chkBit22.TabIndex = 21
        chkBit22.Text = "22"
        chkBit22.UseVisualStyleBackColor = True
        ' 
        ' chkBit23
        ' 
        chkBit23.AutoSize = True
        chkBit23.CheckAlign = ContentAlignment.TopCenter
        chkBit23.Enabled = False
        chkBit23.FlatAppearance.BorderColor = Color.Red
        chkBit23.FlatAppearance.BorderSize = 2
        chkBit23.FlatStyle = FlatStyle.Flat
        chkBit23.Location = New Point(268, 180)
        chkBit23.Margin = New Padding(5, 5, 5, 5)
        chkBit23.Name = "chkBit23"
        chkBit23.Size = New Size(31, 40)
        chkBit23.TabIndex = 20
        chkBit23.Text = "23"
        chkBit23.UseVisualStyleBackColor = True
        ' 
        ' chkBit11
        ' 
        chkBit11.AutoSize = True
        chkBit11.CheckAlign = ContentAlignment.TopCenter
        chkBit11.Enabled = False
        chkBit11.FlatAppearance.BorderColor = Color.Red
        chkBit11.FlatAppearance.BorderSize = 2
        chkBit11.FlatStyle = FlatStyle.Flat
        chkBit11.Location = New Point(133, 142)
        chkBit11.Margin = New Padding(5, 5, 5, 5)
        chkBit11.Name = "chkBit11"
        chkBit11.Size = New Size(31, 40)
        chkBit11.TabIndex = 19
        chkBit11.Text = "11"
        chkBit11.UseVisualStyleBackColor = True
        ' 
        ' chkBit10
        ' 
        chkBit10.AutoSize = True
        chkBit10.CheckAlign = ContentAlignment.TopCenter
        chkBit10.Enabled = False
        chkBit10.FlatAppearance.BorderColor = Color.Red
        chkBit10.FlatAppearance.BorderSize = 2
        chkBit10.FlatStyle = FlatStyle.Flat
        chkBit10.Location = New Point(167, 142)
        chkBit10.Margin = New Padding(5, 5, 5, 5)
        chkBit10.Name = "chkBit10"
        chkBit10.Size = New Size(31, 40)
        chkBit10.TabIndex = 18
        chkBit10.Text = "10"
        chkBit10.UseVisualStyleBackColor = True
        ' 
        ' chkBit9
        ' 
        chkBit9.AutoSize = True
        chkBit9.CheckAlign = ContentAlignment.TopCenter
        chkBit9.Enabled = False
        chkBit9.FlatAppearance.BorderColor = Color.Red
        chkBit9.FlatAppearance.BorderSize = 2
        chkBit9.FlatStyle = FlatStyle.Flat
        chkBit9.Location = New Point(203, 142)
        chkBit9.Margin = New Padding(5, 5, 5, 5)
        chkBit9.Name = "chkBit9"
        chkBit9.Size = New Size(22, 40)
        chkBit9.TabIndex = 17
        chkBit9.Text = "9"
        chkBit9.UseVisualStyleBackColor = True
        ' 
        ' chkBit8
        ' 
        chkBit8.AutoSize = True
        chkBit8.CheckAlign = ContentAlignment.TopCenter
        chkBit8.Enabled = False
        chkBit8.FlatAppearance.BorderColor = Color.Red
        chkBit8.FlatAppearance.BorderSize = 2
        chkBit8.FlatStyle = FlatStyle.Flat
        chkBit8.Location = New Point(238, 142)
        chkBit8.Margin = New Padding(5, 5, 5, 5)
        chkBit8.Name = "chkBit8"
        chkBit8.Size = New Size(22, 40)
        chkBit8.TabIndex = 16
        chkBit8.Text = "8"
        chkBit8.UseVisualStyleBackColor = True
        ' 
        ' chkBit12
        ' 
        chkBit12.AutoSize = True
        chkBit12.CheckAlign = ContentAlignment.TopCenter
        chkBit12.Enabled = False
        chkBit12.FlatAppearance.BorderColor = Color.Red
        chkBit12.FlatAppearance.BorderSize = 2
        chkBit12.FlatStyle = FlatStyle.Flat
        chkBit12.Location = New Point(102, 142)
        chkBit12.Margin = New Padding(5, 5, 5, 5)
        chkBit12.Name = "chkBit12"
        chkBit12.Size = New Size(31, 40)
        chkBit12.TabIndex = 15
        chkBit12.Text = "12"
        chkBit12.UseVisualStyleBackColor = True
        ' 
        ' chkBit13
        ' 
        chkBit13.AutoSize = True
        chkBit13.CheckAlign = ContentAlignment.TopCenter
        chkBit13.Enabled = False
        chkBit13.FlatAppearance.BorderColor = Color.Red
        chkBit13.FlatAppearance.BorderSize = 2
        chkBit13.FlatStyle = FlatStyle.Flat
        chkBit13.Location = New Point(68, 142)
        chkBit13.Margin = New Padding(5, 5, 5, 5)
        chkBit13.Name = "chkBit13"
        chkBit13.Size = New Size(31, 40)
        chkBit13.TabIndex = 14
        chkBit13.Text = "13"
        chkBit13.UseVisualStyleBackColor = True
        ' 
        ' chkBit14
        ' 
        chkBit14.AutoSize = True
        chkBit14.CheckAlign = ContentAlignment.TopCenter
        chkBit14.Enabled = False
        chkBit14.FlatAppearance.BorderColor = Color.Red
        chkBit14.FlatAppearance.BorderSize = 2
        chkBit14.FlatStyle = FlatStyle.Flat
        chkBit14.Location = New Point(35, 142)
        chkBit14.Margin = New Padding(5, 5, 5, 5)
        chkBit14.Name = "chkBit14"
        chkBit14.Size = New Size(31, 40)
        chkBit14.TabIndex = 13
        chkBit14.Text = "14"
        chkBit14.UseVisualStyleBackColor = True
        ' 
        ' chkBit15
        ' 
        chkBit15.AutoSize = True
        chkBit15.CheckAlign = ContentAlignment.TopCenter
        chkBit15.Enabled = False
        chkBit15.FlatAppearance.BorderColor = Color.Red
        chkBit15.FlatAppearance.BorderSize = 2
        chkBit15.FlatStyle = FlatStyle.Flat
        chkBit15.Location = New Point(3, 142)
        chkBit15.Margin = New Padding(5, 5, 5, 5)
        chkBit15.Name = "chkBit15"
        chkBit15.Size = New Size(31, 40)
        chkBit15.TabIndex = 12
        chkBit15.Text = "15"
        chkBit15.UseVisualStyleBackColor = True
        ' 
        ' chkBit3
        ' 
        chkBit3.AutoSize = True
        chkBit3.CheckAlign = ContentAlignment.TopCenter
        chkBit3.Enabled = False
        chkBit3.FlatAppearance.BorderColor = Color.Red
        chkBit3.FlatAppearance.BorderSize = 2
        chkBit3.FlatStyle = FlatStyle.Flat
        chkBit3.Location = New Point(408, 142)
        chkBit3.Margin = New Padding(5, 5, 5, 5)
        chkBit3.Name = "chkBit3"
        chkBit3.Size = New Size(22, 40)
        chkBit3.TabIndex = 11
        chkBit3.Text = "3"
        chkBit3.UseVisualStyleBackColor = True
        ' 
        ' chkBit2
        ' 
        chkBit2.AutoSize = True
        chkBit2.CheckAlign = ContentAlignment.TopCenter
        chkBit2.Enabled = False
        chkBit2.FlatAppearance.BorderColor = Color.Red
        chkBit2.FlatAppearance.BorderSize = 2
        chkBit2.FlatStyle = FlatStyle.Flat
        chkBit2.Location = New Point(443, 142)
        chkBit2.Margin = New Padding(5, 5, 5, 5)
        chkBit2.Name = "chkBit2"
        chkBit2.Size = New Size(22, 40)
        chkBit2.TabIndex = 10
        chkBit2.Text = "2"
        chkBit2.UseVisualStyleBackColor = True
        ' 
        ' chkBit1
        ' 
        chkBit1.AutoSize = True
        chkBit1.CheckAlign = ContentAlignment.TopCenter
        chkBit1.Enabled = False
        chkBit1.FlatAppearance.BorderColor = Color.Red
        chkBit1.FlatAppearance.BorderSize = 2
        chkBit1.FlatStyle = FlatStyle.Flat
        chkBit1.Location = New Point(477, 142)
        chkBit1.Margin = New Padding(5, 5, 5, 5)
        chkBit1.Name = "chkBit1"
        chkBit1.Size = New Size(22, 40)
        chkBit1.TabIndex = 9
        chkBit1.Text = "1"
        chkBit1.UseVisualStyleBackColor = True
        ' 
        ' chkBit0
        ' 
        chkBit0.AutoSize = True
        chkBit0.CheckAlign = ContentAlignment.TopCenter
        chkBit0.Enabled = False
        chkBit0.FlatAppearance.BorderColor = Color.Red
        chkBit0.FlatAppearance.BorderSize = 2
        chkBit0.FlatStyle = FlatStyle.Flat
        chkBit0.Location = New Point(512, 142)
        chkBit0.Margin = New Padding(5, 5, 5, 5)
        chkBit0.Name = "chkBit0"
        chkBit0.Size = New Size(22, 40)
        chkBit0.TabIndex = 8
        chkBit0.Text = "0"
        chkBit0.UseVisualStyleBackColor = True
        ' 
        ' chkBit4
        ' 
        chkBit4.AutoSize = True
        chkBit4.CheckAlign = ContentAlignment.TopCenter
        chkBit4.Enabled = False
        chkBit4.FlatAppearance.BorderColor = Color.Red
        chkBit4.FlatAppearance.BorderSize = 2
        chkBit4.FlatStyle = FlatStyle.Flat
        chkBit4.Location = New Point(373, 142)
        chkBit4.Margin = New Padding(5, 5, 5, 5)
        chkBit4.Name = "chkBit4"
        chkBit4.Size = New Size(22, 40)
        chkBit4.TabIndex = 7
        chkBit4.Text = "4"
        chkBit4.UseVisualStyleBackColor = True
        ' 
        ' chkBit5
        ' 
        chkBit5.AutoSize = True
        chkBit5.CheckAlign = ContentAlignment.TopCenter
        chkBit5.Enabled = False
        chkBit5.FlatAppearance.BorderColor = Color.Red
        chkBit5.FlatAppearance.BorderSize = 2
        chkBit5.FlatStyle = FlatStyle.Flat
        chkBit5.Location = New Point(337, 142)
        chkBit5.Margin = New Padding(5, 5, 5, 5)
        chkBit5.Name = "chkBit5"
        chkBit5.Size = New Size(22, 40)
        chkBit5.TabIndex = 6
        chkBit5.Text = "5"
        chkBit5.UseVisualStyleBackColor = True
        ' 
        ' chkBit6
        ' 
        chkBit6.AutoSize = True
        chkBit6.CheckAlign = ContentAlignment.TopCenter
        chkBit6.Enabled = False
        chkBit6.FlatAppearance.BorderColor = Color.Red
        chkBit6.FlatAppearance.BorderSize = 2
        chkBit6.FlatStyle = FlatStyle.Flat
        chkBit6.Location = New Point(302, 142)
        chkBit6.Margin = New Padding(5, 5, 5, 5)
        chkBit6.Name = "chkBit6"
        chkBit6.Size = New Size(22, 40)
        chkBit6.TabIndex = 5
        chkBit6.Text = "6"
        chkBit6.UseVisualStyleBackColor = True
        ' 
        ' chkBit7
        ' 
        chkBit7.AutoSize = True
        chkBit7.CheckAlign = ContentAlignment.TopCenter
        chkBit7.Enabled = False
        chkBit7.FlatAppearance.BorderColor = Color.Red
        chkBit7.FlatAppearance.BorderSize = 2
        chkBit7.FlatStyle = FlatStyle.Flat
        chkBit7.Location = New Point(272, 142)
        chkBit7.Margin = New Padding(5, 5, 5, 5)
        chkBit7.Name = "chkBit7"
        chkBit7.Size = New Size(22, 40)
        chkBit7.TabIndex = 4
        chkBit7.Text = "7"
        chkBit7.UseVisualStyleBackColor = True
        ' 
        ' txtValue
        ' 
        txtValue.Location = New Point(163, 94)
        txtValue.Margin = New Padding(5, 5, 5, 5)
        txtValue.Name = "txtValue"
        txtValue.Size = New Size(164, 26)
        txtValue.TabIndex = 3
        txtValue.Visible = False
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(163, 29)
        txtAddress.Margin = New Padding(5, 5, 5, 5)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(164, 26)
        txtAddress.TabIndex = 2
        txtAddress.Text = "-1"
        ' 
        ' lblValue
        ' 
        lblValue.Location = New Point(10, 98)
        lblValue.Margin = New Padding(5, 0, 5, 0)
        lblValue.Name = "lblValue"
        lblValue.Size = New Size(152, 20)
        lblValue.TabIndex = 1
        lblValue.Text = "Value"
        ' 
        ' lblAddress
        ' 
        lblAddress.Location = New Point(10, 34)
        lblAddress.Margin = New Padding(5, 0, 5, 0)
        lblAddress.Name = "lblAddress"
        lblAddress.Size = New Size(152, 20)
        lblAddress.TabIndex = 0
        lblAddress.Text = "address (0-based)"
        ' 
        ' grbAddressType
        ' 
        grbAddressType.Controls.Add(rbRegisterTypeDiscreteInputs)
        grbAddressType.Controls.Add(rbRegisterTypeCoils)
        grbAddressType.Controls.Add(rbRegisterTypeInputRegister)
        grbAddressType.Controls.Add(rbRegisterTypeHoldingRegister)
        grbAddressType.Location = New Point(15, 23)
        grbAddressType.Margin = New Padding(5, 5, 5, 5)
        grbAddressType.Name = "grbAddressType"
        grbAddressType.Padding = New Padding(5, 5, 5, 5)
        grbAddressType.Size = New Size(547, 75)
        grbAddressType.TabIndex = 1
        grbAddressType.TabStop = False
        grbAddressType.Text = "register type"
        ' 
        ' rbRegisterTypeDiscreteInputs
        ' 
        rbRegisterTypeDiscreteInputs.AutoSize = True
        rbRegisterTypeDiscreteInputs.Location = New Point(95, 29)
        rbRegisterTypeDiscreteInputs.Margin = New Padding(5, 5, 5, 5)
        rbRegisterTypeDiscreteInputs.Name = "rbRegisterTypeDiscreteInputs"
        rbRegisterTypeDiscreteInputs.Size = New Size(79, 24)
        rbRegisterTypeDiscreteInputs.TabIndex = 2
        rbRegisterTypeDiscreteInputs.Text = "Inputs"
        rbRegisterTypeDiscreteInputs.UseVisualStyleBackColor = True
        ' 
        ' rbRegisterTypeCoils
        ' 
        rbRegisterTypeCoils.AutoSize = True
        rbRegisterTypeCoils.Checked = True
        rbRegisterTypeCoils.Location = New Point(10, 29)
        rbRegisterTypeCoils.Margin = New Padding(5, 5, 5, 5)
        rbRegisterTypeCoils.Name = "rbRegisterTypeCoils"
        rbRegisterTypeCoils.Size = New Size(72, 24)
        rbRegisterTypeCoils.TabIndex = 1
        rbRegisterTypeCoils.TabStop = True
        rbRegisterTypeCoils.Text = "Coils"
        rbRegisterTypeCoils.UseVisualStyleBackColor = True
        ' 
        ' rbRegisterTypeInputRegister
        ' 
        rbRegisterTypeInputRegister.AutoSize = True
        rbRegisterTypeInputRegister.Location = New Point(378, 29)
        rbRegisterTypeInputRegister.Margin = New Padding(5, 5, 5, 5)
        rbRegisterTypeInputRegister.Name = "rbRegisterTypeInputRegister"
        rbRegisterTypeInputRegister.Size = New Size(138, 24)
        rbRegisterTypeInputRegister.TabIndex = 4
        rbRegisterTypeInputRegister.Text = "Input Register"
        rbRegisterTypeInputRegister.UseVisualStyleBackColor = True
        ' 
        ' rbRegisterTypeHoldingRegister
        ' 
        rbRegisterTypeHoldingRegister.AutoSize = True
        rbRegisterTypeHoldingRegister.Location = New Point(195, 29)
        rbRegisterTypeHoldingRegister.Margin = New Padding(5, 5, 5, 5)
        rbRegisterTypeHoldingRegister.Name = "rbRegisterTypeHoldingRegister"
        rbRegisterTypeHoldingRegister.Size = New Size(159, 24)
        rbRegisterTypeHoldingRegister.TabIndex = 3
        rbRegisterTypeHoldingRegister.Text = "Holding Register"
        rbRegisterTypeHoldingRegister.UseVisualStyleBackColor = True
        ' 
        ' lvValues
        ' 
        lvValues.Activation = ItemActivation.OneClick
        lvValues.Columns.AddRange(New ColumnHeader() {colDummy, colAddress, colValue})
        lvValues.Font = New Font("Microsoft Sans Serif", 8.25F)
        lvValues.FullRowSelect = True
        lvValues.Location = New Point(10, 354)
        lvValues.Margin = New Padding(5, 5, 5, 5)
        lvValues.Name = "lvValues"
        lvValues.Size = New Size(544, 298)
        lvValues.TabIndex = 0
        lvValues.UseCompatibleStateImageBehavior = False
        lvValues.View = View.Details
        lvValues.VirtualListSize = 9999
        lvValues.VirtualMode = True
        ' 
        ' colDummy
        ' 
        colDummy.DisplayIndex = 2
        colDummy.Text = ""
        colDummy.Width = 0
        ' 
        ' colAddress
        ' 
        colAddress.DisplayIndex = 0
        colAddress.Text = "Address"
        colAddress.TextAlign = HorizontalAlignment.Center
        ' 
        ' colValue
        ' 
        colValue.DisplayIndex = 1
        colValue.Text = "Value"
        colValue.TextAlign = HorizontalAlignment.Center
        colValue.Width = 240
        ' 
        ' grbLog
        ' 
        grbLog.Controls.Add(lvLog)
        grbLog.Location = New Point(8, 686)
        grbLog.Margin = New Padding(5, 5, 5, 5)
        grbLog.Name = "grbLog"
        grbLog.Padding = New Padding(5, 5, 5, 5)
        grbLog.Size = New Size(1777, 414)
        grbLog.TabIndex = 130
        grbLog.TabStop = False
        grbLog.Text = "Log"
        ' 
        ' cmbLanguage
        ' 
        cmbLanguage.FormattingEnabled = True
        cmbLanguage.Location = New Point(1207, 1114)
        cmbLanguage.Margin = New Padding(5, 5, 5, 5)
        cmbLanguage.Name = "cmbLanguage"
        cmbLanguage.Size = New Size(101, 28)
        cmbLanguage.TabIndex = 140
        ' 
        ' btnCopyLogtoClipboard
        ' 
        btnCopyLogtoClipboard.Image = CType(resources.GetObject("btnCopyLogtoClipboard.Image"), Image)
        btnCopyLogtoClipboard.ImageAlign = ContentAlignment.TopCenter
        btnCopyLogtoClipboard.Location = New Point(28, 1109)
        btnCopyLogtoClipboard.Margin = New Padding(5, 5, 5, 5)
        btnCopyLogtoClipboard.Name = "btnCopyLogtoClipboard"
        btnCopyLogtoClipboard.Size = New Size(113, 105)
        btnCopyLogtoClipboard.TabIndex = 139
        btnCopyLogtoClipboard.Text = "copy log to clipboard"
        btnCopyLogtoClipboard.TextAlign = ContentAlignment.BottomCenter
        btnCopyLogtoClipboard.UseVisualStyleBackColor = True
        ' 
        ' btnCopyLogtoFile
        ' 
        btnCopyLogtoFile.Image = CType(resources.GetObject("btnCopyLogtoFile.Image"), Image)
        btnCopyLogtoFile.ImageAlign = ContentAlignment.TopCenter
        btnCopyLogtoFile.Location = New Point(158, 1108)
        btnCopyLogtoFile.Margin = New Padding(5, 5, 5, 5)
        btnCopyLogtoFile.Name = "btnCopyLogtoFile"
        btnCopyLogtoFile.Size = New Size(113, 105)
        btnCopyLogtoFile.TabIndex = 138
        btnCopyLogtoFile.Text = "copy slave log to file"
        btnCopyLogtoFile.TextAlign = ContentAlignment.BottomCenter
        btnCopyLogtoFile.UseVisualStyleBackColor = True
        ' 
        ' btnCertificateManager
        ' 
        btnCertificateManager.Image = CType(resources.GetObject("btnCertificateManager.Image"), Image)
        btnCertificateManager.ImageAlign = ContentAlignment.TopCenter
        btnCertificateManager.Location = New Point(290, 1109)
        btnCertificateManager.Margin = New Padding(5, 5, 5, 5)
        btnCertificateManager.Name = "btnCertificateManager"
        btnCertificateManager.Size = New Size(113, 105)
        btnCertificateManager.TabIndex = 127
        btnCertificateManager.Text = "show" & vbCrLf & "certificates"
        btnCertificateManager.TextAlign = ContentAlignment.BottomCenter
        btnCertificateManager.UseVisualStyleBackColor = True
        ' 
        ' btnLoadSettings
        ' 
        btnLoadSettings.Image = CType(resources.GetObject("btnLoadSettings.Image"), Image)
        btnLoadSettings.ImageAlign = ContentAlignment.TopCenter
        btnLoadSettings.Location = New Point(1380, 1109)
        btnLoadSettings.Margin = New Padding(5, 5, 5, 5)
        btnLoadSettings.Name = "btnLoadSettings"
        btnLoadSettings.Size = New Size(113, 105)
        btnLoadSettings.TabIndex = 137
        btnLoadSettings.Text = "load settings"
        btnLoadSettings.TextAlign = ContentAlignment.BottomCenter
        btnLoadSettings.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Image = CType(resources.GetObject("btnClose.Image"), Image)
        btnClose.ImageAlign = ContentAlignment.TopCenter
        btnClose.Location = New Point(1658, 1109)
        btnClose.Margin = New Padding(5, 5, 5, 5)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(113, 105)
        btnClose.TabIndex = 135
        btnClose.Text = "exit aplication"
        btnClose.TextAlign = ContentAlignment.BottomCenter
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' btnSaveSettings
        ' 
        btnSaveSettings.Image = CType(resources.GetObject("btnSaveSettings.Image"), Image)
        btnSaveSettings.ImageAlign = ContentAlignment.TopCenter
        btnSaveSettings.Location = New Point(1517, 1109)
        btnSaveSettings.Margin = New Padding(5, 5, 5, 5)
        btnSaveSettings.Name = "btnSaveSettings"
        btnSaveSettings.Size = New Size(113, 105)
        btnSaveSettings.TabIndex = 133
        btnSaveSettings.Text = "save settings"
        btnSaveSettings.TextAlign = ContentAlignment.BottomCenter
        btnSaveSettings.UseVisualStyleBackColor = True
        ' 
        ' chkSupportsFC01
        ' 
        chkSupportsFC01.AutoSize = True
        chkSupportsFC01.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC01.Checked = True
        chkSupportsFC01.CheckState = CheckState.Checked
        chkSupportsFC01.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC01.FlatAppearance.BorderSize = 2
        chkSupportsFC01.FlatStyle = FlatStyle.Flat
        chkSupportsFC01.Location = New Point(3, 25)
        chkSupportsFC01.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC01.Name = "chkSupportsFC01"
        chkSupportsFC01.Size = New Size(53, 40)
        chkSupportsFC01.TabIndex = 90
        chkSupportsFC01.Text = "FC01"
        chkSupportsFC01.UseVisualStyleBackColor = True
        ' 
        ' lblLanguage
        ' 
        lblLanguage.Location = New Point(1112, 1118)
        lblLanguage.Margin = New Padding(5, 0, 5, 0)
        lblLanguage.Name = "lblLanguage"
        lblLanguage.Size = New Size(85, 20)
        lblLanguage.TabIndex = 141
        lblLanguage.Text = "language"
        lblLanguage.TextAlign = ContentAlignment.TopRight
        ' 
        ' txtUnparseableRequests
        ' 
        txtUnparseableRequests.BorderStyle = BorderStyle.FixedSingle
        txtUnparseableRequests.Location = New Point(267, 175)
        txtUnparseableRequests.Margin = New Padding(5, 5, 5, 5)
        txtUnparseableRequests.Name = "txtUnparseableRequests"
        txtUnparseableRequests.ReadOnly = True
        txtUnparseableRequests.Size = New Size(122, 26)
        txtUnparseableRequests.TabIndex = 84
        txtUnparseableRequests.Text = "?????"
        ' 
        ' lblUnparseableRequests
        ' 
        lblUnparseableRequests.Location = New Point(2, 178)
        lblUnparseableRequests.Margin = New Padding(5, 0, 5, 0)
        lblUnparseableRequests.Name = "lblUnparseableRequests"
        lblUnparseableRequests.Size = New Size(258, 20)
        lblUnparseableRequests.TabIndex = 83
        lblUnparseableRequests.Text = "unparseable requests"
        lblUnparseableRequests.TextAlign = ContentAlignment.TopRight
        ' 
        ' txtIncorectRequests
        ' 
        txtIncorectRequests.BorderStyle = BorderStyle.FixedSingle
        txtIncorectRequests.Location = New Point(267, 137)
        txtIncorectRequests.Margin = New Padding(5, 5, 5, 5)
        txtIncorectRequests.Name = "txtIncorectRequests"
        txtIncorectRequests.ReadOnly = True
        txtIncorectRequests.Size = New Size(122, 26)
        txtIncorectRequests.TabIndex = 82
        txtIncorectRequests.Text = "?????"
        ' 
        ' txtIncomingRequests
        ' 
        txtIncomingRequests.BorderStyle = BorderStyle.FixedSingle
        txtIncomingRequests.Location = New Point(267, 97)
        txtIncomingRequests.Margin = New Padding(5, 5, 5, 5)
        txtIncomingRequests.Name = "txtIncomingRequests"
        txtIncomingRequests.ReadOnly = True
        txtIncomingRequests.Size = New Size(122, 26)
        txtIncomingRequests.TabIndex = 81
        txtIncomingRequests.Text = "?????"
        ' 
        ' grbStatistics
        ' 
        grbStatistics.Controls.Add(txtUnparseableRequests)
        grbStatistics.Controls.Add(lblUnparseableRequests)
        grbStatistics.Controls.Add(txtIncorectRequests)
        grbStatistics.Controls.Add(txtIncomingRequests)
        grbStatistics.Controls.Add(lblIncorrectRequests)
        grbStatistics.Controls.Add(lblIncomingRequests)
        grbStatistics.Controls.Add(txtOutgoingBytes)
        grbStatistics.Controls.Add(txtIncomingBytes)
        grbStatistics.Controls.Add(lblOutgoingBytes)
        grbStatistics.Controls.Add(lblIncomingBytes)
        grbStatistics.Location = New Point(762, 25)
        grbStatistics.Margin = New Padding(5, 5, 5, 5)
        grbStatistics.Name = "grbStatistics"
        grbStatistics.Padding = New Padding(5, 5, 5, 5)
        grbStatistics.Size = New Size(410, 220)
        grbStatistics.TabIndex = 82
        grbStatistics.TabStop = False
        grbStatistics.Text = "statistics"
        ' 
        ' lblIncorrectRequests
        ' 
        lblIncorrectRequests.Location = New Point(2, 140)
        lblIncorrectRequests.Margin = New Padding(5, 0, 5, 0)
        lblIncorrectRequests.Name = "lblIncorrectRequests"
        lblIncorrectRequests.Size = New Size(258, 20)
        lblIncorrectRequests.TabIndex = 80
        lblIncorrectRequests.Text = "incorrect requests"
        lblIncorrectRequests.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblIncomingRequests
        ' 
        lblIncomingRequests.Location = New Point(3, 100)
        lblIncomingRequests.Margin = New Padding(5, 0, 5, 0)
        lblIncomingRequests.Name = "lblIncomingRequests"
        lblIncomingRequests.Size = New Size(258, 20)
        lblIncomingRequests.TabIndex = 79
        lblIncomingRequests.Text = "incoming requests"
        lblIncomingRequests.TextAlign = ContentAlignment.TopRight
        ' 
        ' txtOutgoingBytes
        ' 
        txtOutgoingBytes.BorderStyle = BorderStyle.FixedSingle
        txtOutgoingBytes.Location = New Point(265, 58)
        txtOutgoingBytes.Margin = New Padding(5, 5, 5, 5)
        txtOutgoingBytes.Name = "txtOutgoingBytes"
        txtOutgoingBytes.ReadOnly = True
        txtOutgoingBytes.Size = New Size(122, 26)
        txtOutgoingBytes.TabIndex = 78
        txtOutgoingBytes.Text = "?????"
        ' 
        ' txtIncomingBytes
        ' 
        txtIncomingBytes.BorderStyle = BorderStyle.FixedSingle
        txtIncomingBytes.Location = New Point(265, 18)
        txtIncomingBytes.Margin = New Padding(5, 5, 5, 5)
        txtIncomingBytes.Name = "txtIncomingBytes"
        txtIncomingBytes.ReadOnly = True
        txtIncomingBytes.Size = New Size(122, 26)
        txtIncomingBytes.TabIndex = 77
        txtIncomingBytes.Text = "?????"
        ' 
        ' lblOutgoingBytes
        ' 
        lblOutgoingBytes.Location = New Point(3, 62)
        lblOutgoingBytes.Margin = New Padding(5, 0, 5, 0)
        lblOutgoingBytes.Name = "lblOutgoingBytes"
        lblOutgoingBytes.Size = New Size(258, 20)
        lblOutgoingBytes.TabIndex = 76
        lblOutgoingBytes.Text = "outgoing bytes"
        lblOutgoingBytes.TextAlign = ContentAlignment.TopRight
        ' 
        ' lblIncomingBytes
        ' 
        lblIncomingBytes.Location = New Point(2, 22)
        lblIncomingBytes.Margin = New Padding(5, 0, 5, 0)
        lblIncomingBytes.Name = "lblIncomingBytes"
        lblIncomingBytes.Size = New Size(258, 20)
        lblIncomingBytes.TabIndex = 75
        lblIncomingBytes.Text = "incoming bytes"
        lblIncomingBytes.TextAlign = ContentAlignment.TopRight
        ' 
        ' grbListener
        ' 
        grbListener.Controls.Add(grbStatistics)
        grbListener.Controls.Add(grbSlaveSettings)
        grbListener.Controls.Add(grbSupportedFunctions)
        grbListener.Controls.Add(btnStartSlave)
        grbListener.Controls.Add(btnRemoveListener)
        grbListener.Controls.Add(btnStopSlave)
        grbListener.Controls.Add(btnAddListener)
        grbListener.Controls.Add(lvListener)
        grbListener.Location = New Point(13, 114)
        grbListener.Margin = New Padding(5, 5, 5, 5)
        grbListener.Name = "grbListener"
        grbListener.Padding = New Padding(5, 5, 5, 5)
        grbListener.Size = New Size(1183, 563)
        grbListener.TabIndex = 128
        grbListener.TabStop = False
        grbListener.Text = "Select Register mode and start slave"
        ' 
        ' grbSlaveSettings
        ' 
        grbSlaveSettings.Controls.Add(cmbByteOrder)
        grbSlaveSettings.Controls.Add(lblByteOrder)
        grbSlaveSettings.Controls.Add(cmbRegisterMode)
        grbSlaveSettings.Controls.Add(lblRegisterMode)
        grbSlaveSettings.Controls.Add(cmbSlaveID)
        grbSlaveSettings.Controls.Add(lblSlaveID)
        grbSlaveSettings.Location = New Point(287, 20)
        grbSlaveSettings.Margin = New Padding(5, 5, 5, 5)
        grbSlaveSettings.Name = "grbSlaveSettings"
        grbSlaveSettings.Padding = New Padding(5, 5, 5, 5)
        grbSlaveSettings.Size = New Size(465, 112)
        grbSlaveSettings.TabIndex = 81
        grbSlaveSettings.TabStop = False
        grbSlaveSettings.Text = "Slave settings"
        ' 
        ' cmbByteOrder
        ' 
        cmbByteOrder.FormattingEnabled = True
        cmbByteOrder.Location = New Point(150, 66)
        cmbByteOrder.Margin = New Padding(5, 5, 5, 5)
        cmbByteOrder.Name = "cmbByteOrder"
        cmbByteOrder.Size = New Size(302, 28)
        cmbByteOrder.TabIndex = 81
        ' 
        ' lblByteOrder
        ' 
        lblByteOrder.ImeMode = ImeMode.NoControl
        lblByteOrder.Location = New Point(2, 71)
        lblByteOrder.Margin = New Padding(5, 0, 5, 0)
        lblByteOrder.Name = "lblByteOrder"
        lblByteOrder.Size = New Size(148, 20)
        lblByteOrder.TabIndex = 80
        lblByteOrder.Text = "number encoding"
        ' 
        ' cmbRegisterMode
        ' 
        cmbRegisterMode.FormattingEnabled = True
        cmbRegisterMode.Location = New Point(150, 23)
        cmbRegisterMode.Margin = New Padding(5, 5, 5, 5)
        cmbRegisterMode.Name = "cmbRegisterMode"
        cmbRegisterMode.Size = New Size(97, 28)
        cmbRegisterMode.TabIndex = 73
        ' 
        ' lblRegisterMode
        ' 
        lblRegisterMode.Location = New Point(2, 28)
        lblRegisterMode.Margin = New Padding(5, 0, 5, 0)
        lblRegisterMode.Name = "lblRegisterMode"
        lblRegisterMode.Size = New Size(148, 20)
        lblRegisterMode.TabIndex = 74
        lblRegisterMode.Text = "RegisterMode"
        ' 
        ' cmbSlaveID
        ' 
        cmbSlaveID.FormattingEnabled = True
        cmbSlaveID.Location = New Point(357, 23)
        cmbSlaveID.Margin = New Padding(5, 5, 5, 5)
        cmbSlaveID.Name = "cmbSlaveID"
        cmbSlaveID.Size = New Size(97, 28)
        cmbSlaveID.TabIndex = 78
        ' 
        ' lblSlaveID
        ' 
        lblSlaveID.Location = New Point(260, 28)
        lblSlaveID.Margin = New Padding(5, 0, 5, 0)
        lblSlaveID.Name = "lblSlaveID"
        lblSlaveID.Size = New Size(98, 20)
        lblSlaveID.TabIndex = 79
        lblSlaveID.Text = "Slave ID"
        lblSlaveID.TextAlign = ContentAlignment.TopRight
        ' 
        ' grbSupportedFunctions
        ' 
        grbSupportedFunctions.Controls.Add(chkSupportsFC23)
        grbSupportedFunctions.Controls.Add(chkSupportsFC16)
        grbSupportedFunctions.Controls.Add(chkSupportsFC15)
        grbSupportedFunctions.Controls.Add(chkSupportsFC08)
        grbSupportedFunctions.Controls.Add(chkSupportsFC06)
        grbSupportedFunctions.Controls.Add(chkSupportsFC05)
        grbSupportedFunctions.Controls.Add(chkSupportsFC04)
        grbSupportedFunctions.Controls.Add(chkSupportsFC03)
        grbSupportedFunctions.Controls.Add(chkSupportsFC02)
        grbSupportedFunctions.Controls.Add(chkSupportsFC01)
        grbSupportedFunctions.Enabled = False
        grbSupportedFunctions.Location = New Point(287, 131)
        grbSupportedFunctions.Margin = New Padding(5, 5, 5, 5)
        grbSupportedFunctions.Name = "grbSupportedFunctions"
        grbSupportedFunctions.Padding = New Padding(5, 5, 5, 5)
        grbSupportedFunctions.Size = New Size(465, 115)
        grbSupportedFunctions.TabIndex = 80
        grbSupportedFunctions.TabStop = False
        grbSupportedFunctions.Text = "Supported modbus functions"
        ' 
        ' chkSupportsFC23
        ' 
        chkSupportsFC23.AutoSize = True
        chkSupportsFC23.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC23.Checked = True
        chkSupportsFC23.CheckState = CheckState.Checked
        chkSupportsFC23.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC23.FlatAppearance.BorderSize = 2
        chkSupportsFC23.FlatStyle = FlatStyle.Flat
        chkSupportsFC23.Location = New Point(402, 63)
        chkSupportsFC23.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC23.Name = "chkSupportsFC23"
        chkSupportsFC23.Size = New Size(53, 40)
        chkSupportsFC23.TabIndex = 99
        chkSupportsFC23.Text = "FC23"
        chkSupportsFC23.UseVisualStyleBackColor = True
        ' 
        ' chkSupportsFC16
        ' 
        chkSupportsFC16.AutoSize = True
        chkSupportsFC16.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC16.Checked = True
        chkSupportsFC16.CheckState = CheckState.Checked
        chkSupportsFC16.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC16.FlatAppearance.BorderSize = 2
        chkSupportsFC16.FlatStyle = FlatStyle.Flat
        chkSupportsFC16.Location = New Point(312, 63)
        chkSupportsFC16.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC16.Name = "chkSupportsFC16"
        chkSupportsFC16.Size = New Size(53, 40)
        chkSupportsFC16.TabIndex = 98
        chkSupportsFC16.Text = "FC16"
        chkSupportsFC16.UseVisualStyleBackColor = True
        ' 
        ' chkSupportsFC15
        ' 
        chkSupportsFC15.AutoSize = True
        chkSupportsFC15.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC15.Checked = True
        chkSupportsFC15.CheckState = CheckState.Checked
        chkSupportsFC15.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC15.FlatAppearance.BorderSize = 2
        chkSupportsFC15.FlatStyle = FlatStyle.Flat
        chkSupportsFC15.Location = New Point(208, 63)
        chkSupportsFC15.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC15.Name = "chkSupportsFC15"
        chkSupportsFC15.Size = New Size(53, 40)
        chkSupportsFC15.TabIndex = 97
        chkSupportsFC15.Text = "FC15"
        chkSupportsFC15.UseVisualStyleBackColor = True
        ' 
        ' chkSupportsFC08
        ' 
        chkSupportsFC08.AutoSize = True
        chkSupportsFC08.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC08.Checked = True
        chkSupportsFC08.CheckState = CheckState.Checked
        chkSupportsFC08.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC08.FlatAppearance.BorderSize = 2
        chkSupportsFC08.FlatStyle = FlatStyle.Flat
        chkSupportsFC08.Location = New Point(97, 63)
        chkSupportsFC08.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC08.Name = "chkSupportsFC08"
        chkSupportsFC08.Size = New Size(53, 40)
        chkSupportsFC08.TabIndex = 96
        chkSupportsFC08.Text = "FC08"
        chkSupportsFC08.UseVisualStyleBackColor = True
        ' 
        ' chkSupportsFC06
        ' 
        chkSupportsFC06.AutoSize = True
        chkSupportsFC06.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC06.Checked = True
        chkSupportsFC06.CheckState = CheckState.Checked
        chkSupportsFC06.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC06.FlatAppearance.BorderSize = 2
        chkSupportsFC06.FlatStyle = FlatStyle.Flat
        chkSupportsFC06.Location = New Point(3, 63)
        chkSupportsFC06.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC06.Name = "chkSupportsFC06"
        chkSupportsFC06.Size = New Size(53, 40)
        chkSupportsFC06.TabIndex = 95
        chkSupportsFC06.Text = "FC06"
        chkSupportsFC06.UseVisualStyleBackColor = True
        ' 
        ' chkSupportsFC05
        ' 
        chkSupportsFC05.AutoSize = True
        chkSupportsFC05.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC05.Checked = True
        chkSupportsFC05.CheckState = CheckState.Checked
        chkSupportsFC05.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC05.FlatAppearance.BorderSize = 2
        chkSupportsFC05.FlatStyle = FlatStyle.Flat
        chkSupportsFC05.Location = New Point(402, 25)
        chkSupportsFC05.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC05.Name = "chkSupportsFC05"
        chkSupportsFC05.Size = New Size(53, 40)
        chkSupportsFC05.TabIndex = 94
        chkSupportsFC05.Text = "FC05"
        chkSupportsFC05.UseVisualStyleBackColor = True
        ' 
        ' chkSupportsFC04
        ' 
        chkSupportsFC04.AutoSize = True
        chkSupportsFC04.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC04.Checked = True
        chkSupportsFC04.CheckState = CheckState.Checked
        chkSupportsFC04.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC04.FlatAppearance.BorderSize = 2
        chkSupportsFC04.FlatStyle = FlatStyle.Flat
        chkSupportsFC04.Location = New Point(312, 25)
        chkSupportsFC04.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC04.Name = "chkSupportsFC04"
        chkSupportsFC04.Size = New Size(53, 40)
        chkSupportsFC04.TabIndex = 93
        chkSupportsFC04.Text = "FC04"
        chkSupportsFC04.UseVisualStyleBackColor = True
        ' 
        ' chkSupportsFC03
        ' 
        chkSupportsFC03.AutoSize = True
        chkSupportsFC03.CheckAlign = ContentAlignment.TopCenter
        chkSupportsFC03.Checked = True
        chkSupportsFC03.CheckState = CheckState.Checked
        chkSupportsFC03.FlatAppearance.BorderColor = Color.Red
        chkSupportsFC03.FlatAppearance.BorderSize = 2
        chkSupportsFC03.FlatStyle = FlatStyle.Flat
        chkSupportsFC03.Location = New Point(208, 25)
        chkSupportsFC03.Margin = New Padding(5, 5, 5, 5)
        chkSupportsFC03.Name = "chkSupportsFC03"
        chkSupportsFC03.Size = New Size(53, 40)
        chkSupportsFC03.TabIndex = 92
        chkSupportsFC03.Text = "FC03"
        chkSupportsFC03.UseVisualStyleBackColor = True
        ' 
        ' btnStartSlave
        ' 
        btnStartSlave.Image = CType(resources.GetObject("btnStartSlave.Image"), Image)
        btnStartSlave.ImageAlign = ContentAlignment.TopCenter
        btnStartSlave.Location = New Point(13, 25)
        btnStartSlave.Margin = New Padding(5, 5, 5, 5)
        btnStartSlave.Name = "btnStartSlave"
        btnStartSlave.Size = New Size(113, 105)
        btnStartSlave.TabIndex = 0
        btnStartSlave.Text = "Start Slave"
        btnStartSlave.TextAlign = ContentAlignment.BottomCenter
        btnStartSlave.UseVisualStyleBackColor = True
        ' 
        ' lblSerial
        ' 
        lblSerial.AutoSize = True
        lblSerial.Location = New Point(768, 66)
        lblSerial.Margin = New Padding(5, 0, 5, 0)
        lblSerial.Name = "lblSerial"
        lblSerial.Size = New Size(55, 20)
        lblSerial.TabIndex = 12
        lblSerial.Text = "serial:"
        ' 
        ' lblUser
        ' 
        lblUser.AutoSize = True
        lblUser.Location = New Point(775, 31)
        lblUser.Margin = New Padding(5, 0, 5, 0)
        lblUser.Name = "lblUser"
        lblUser.Size = New Size(47, 20)
        lblUser.TabIndex = 11
        lblUser.Text = "user:"
        ' 
        ' txtSerial
        ' 
        txtSerial.Font = New Font("Microsoft Sans Serif", 8.25F)
        txtSerial.Location = New Point(838, 62)
        txtSerial.Margin = New Padding(5, 5, 5, 5)
        txtSerial.Name = "txtSerial"
        txtSerial.Size = New Size(316, 26)
        txtSerial.TabIndex = 10
        ' 
        ' txtUser
        ' 
        txtUser.AcceptsReturn = True
        txtUser.Font = New Font("Microsoft Sans Serif", 8.25F)
        txtUser.Location = New Point(838, 26)
        txtUser.Margin = New Padding(5, 5, 5, 5)
        txtUser.Name = "txtUser"
        txtUser.Size = New Size(314, 26)
        txtUser.TabIndex = 0
        ' 
        ' lblSerialCode
        ' 
        lblSerialCode.AutoSize = True
        lblSerialCode.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold)
        lblSerialCode.Location = New Point(15, 40)
        lblSerialCode.Margin = New Padding(5, 0, 5, 0)
        lblSerialCode.Name = "lblSerialCode"
        lblSerialCode.Size = New Size(446, 25)
        lblSerialCode.TabIndex = 0
        lblSerialCode.Text = "Enter user name and serial code first     >>>>"
        ' 
        ' grbSerial
        ' 
        grbSerial.Controls.Add(lblSerial)
        grbSerial.Controls.Add(lblUser)
        grbSerial.Controls.Add(txtSerial)
        grbSerial.Controls.Add(txtUser)
        grbSerial.Controls.Add(lblSerialCode)
        grbSerial.Location = New Point(8, 14)
        grbSerial.Margin = New Padding(5, 5, 5, 5)
        grbSerial.Name = "grbSerial"
        grbSerial.Padding = New Padding(5, 5, 5, 5)
        grbSerial.Size = New Size(1183, 98)
        grbSerial.TabIndex = 127
        grbSerial.TabStop = False
        grbSerial.Text = "Serial"
        ' 
        ' main
        ' 
        AutoScaleDimensions = New SizeF(10F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1795, 1229)
        Controls.Add(chkAutoScroll)
        Controls.Add(chkLogging)
        Controls.Add(lblLogLevel)
        Controls.Add(cmbLogLevel)
        Controls.Add(grbDataStore)
        Controls.Add(grbLog)
        Controls.Add(cmbLanguage)
        Controls.Add(btnCopyLogtoClipboard)
        Controls.Add(btnCopyLogtoFile)
        Controls.Add(btnCertificateManager)
        Controls.Add(btnLoadSettings)
        Controls.Add(btnClose)
        Controls.Add(btnSaveSettings)
        Controls.Add(lblLanguage)
        Controls.Add(grbListener)
        Controls.Add(grbSerial)
        Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(5, 5, 5, 5)
        MaximizeBox = False
        Name = "main"
        StartPosition = FormStartPosition.CenterScreen
        Text = "slave example"
        grbDataStore.ResumeLayout(False)
        grbValues.ResumeLayout(False)
        grbValues.PerformLayout()
        grbAddressType.ResumeLayout(False)
        grbAddressType.PerformLayout()
        grbLog.ResumeLayout(False)
        grbStatistics.ResumeLayout(False)
        grbStatistics.PerformLayout()
        grbListener.ResumeLayout(False)
        grbSlaveSettings.ResumeLayout(False)
        grbSupportedFunctions.ResumeLayout(False)
        grbSupportedFunctions.PerformLayout()
        grbSerial.ResumeLayout(False)
        grbSerial.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Private WithEvents chkSupportsFC02 As System.Windows.Forms.CheckBox
    Private WithEvents btnRemoveListener As System.Windows.Forms.Button
    Private WithEvents btnStopSlave As System.Windows.Forms.Button
    Private WithEvents btnAddListener As System.Windows.Forms.Button
    Private WithEvents lvListener As System.Windows.Forms.ListView
    Private WithEvents colName As System.Windows.Forms.ColumnHeader
    Private WithEvents colType As System.Windows.Forms.ColumnHeader
    Private WithEvents colParameter As System.Windows.Forms.ColumnHeader
    Private WithEvents chkAutoScroll As System.Windows.Forms.CheckBox
    Private WithEvents chkLogging As System.Windows.Forms.CheckBox
    Private WithEvents lvLog As System.Windows.Forms.ListView
    Private WithEvents colText As System.Windows.Forms.ColumnHeader
    Private WithEvents lblLogLevel As System.Windows.Forms.Label
    Friend WithEvents cmbLogLevel As System.Windows.Forms.ComboBox
    Private WithEvents grbDataStore As System.Windows.Forms.GroupBox
    Private WithEvents grbValues As System.Windows.Forms.GroupBox
    Private WithEvents rbValueOFF As System.Windows.Forms.RadioButton
    Private WithEvents rbValueOn As System.Windows.Forms.RadioButton
    Private WithEvents btnSetValue As System.Windows.Forms.Button
    Private WithEvents chkBit27 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit26 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit25 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit24 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit28 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit29 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit30 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit31 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit19 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit18 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit17 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit16 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit20 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit21 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit22 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit23 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit11 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit10 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit9 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit8 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit12 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit13 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit14 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit15 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit3 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit2 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit1 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit0 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit4 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit5 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit6 As System.Windows.Forms.CheckBox
    Private WithEvents chkBit7 As System.Windows.Forms.CheckBox
    Private WithEvents txtValue As System.Windows.Forms.TextBox
    Private WithEvents txtAddress As System.Windows.Forms.TextBox
    Private WithEvents lblValue As System.Windows.Forms.Label
    Private WithEvents lblAddress As System.Windows.Forms.Label
    Private WithEvents grbAddressType As System.Windows.Forms.GroupBox
    Private WithEvents rbRegisterTypeDiscreteInputs As System.Windows.Forms.RadioButton
    Private WithEvents rbRegisterTypeCoils As System.Windows.Forms.RadioButton
    Private WithEvents rbRegisterTypeInputRegister As System.Windows.Forms.RadioButton
    Private WithEvents rbRegisterTypeHoldingRegister As System.Windows.Forms.RadioButton
    Private WithEvents lvValues As System.Windows.Forms.ListView
    Private WithEvents colDummy As System.Windows.Forms.ColumnHeader
    Private WithEvents colAddress As System.Windows.Forms.ColumnHeader
    Private WithEvents colValue As System.Windows.Forms.ColumnHeader
    Private WithEvents grbLog As System.Windows.Forms.GroupBox
    Friend WithEvents cmbLanguage As System.Windows.Forms.ComboBox
    Private WithEvents btnCopyLogtoClipboard As System.Windows.Forms.Button
    Private WithEvents btnCopyLogtoFile As System.Windows.Forms.Button
    Private WithEvents btnCertificateManager As System.Windows.Forms.Button
    Private WithEvents btnLoadSettings As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSaveSettings As System.Windows.Forms.Button
    Private WithEvents chkSupportsFC01 As System.Windows.Forms.CheckBox
    Private WithEvents lblLanguage As System.Windows.Forms.Label
    Private WithEvents txtUnparseableRequests As System.Windows.Forms.TextBox
    Friend WithEvents lblUnparseableRequests As System.Windows.Forms.Label
    Private WithEvents txtIncorectRequests As System.Windows.Forms.TextBox
    Private WithEvents txtIncomingRequests As System.Windows.Forms.TextBox
    Private WithEvents grbStatistics As System.Windows.Forms.GroupBox
    Friend WithEvents lblIncorrectRequests As System.Windows.Forms.Label
    Friend WithEvents lblIncomingRequests As System.Windows.Forms.Label
    Private WithEvents txtOutgoingBytes As System.Windows.Forms.TextBox
    Private WithEvents txtIncomingBytes As System.Windows.Forms.TextBox
    Friend WithEvents lblOutgoingBytes As System.Windows.Forms.Label
    Friend WithEvents lblIncomingBytes As System.Windows.Forms.Label
    Private WithEvents grbListener As System.Windows.Forms.GroupBox
    Private WithEvents grbSlaveSettings As System.Windows.Forms.GroupBox
    Friend WithEvents cmbByteOrder As System.Windows.Forms.ComboBox
    Private WithEvents lblByteOrder As System.Windows.Forms.Label
    Friend WithEvents cmbRegisterMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegisterMode As System.Windows.Forms.Label
    Friend WithEvents cmbSlaveID As System.Windows.Forms.ComboBox
    Private WithEvents lblSlaveID As System.Windows.Forms.Label
    Private WithEvents grbSupportedFunctions As System.Windows.Forms.GroupBox
    Private WithEvents chkSupportsFC23 As System.Windows.Forms.CheckBox
    Private WithEvents chkSupportsFC16 As System.Windows.Forms.CheckBox
    Private WithEvents chkSupportsFC15 As System.Windows.Forms.CheckBox
    Private WithEvents chkSupportsFC08 As System.Windows.Forms.CheckBox
    Private WithEvents chkSupportsFC06 As System.Windows.Forms.CheckBox
    Private WithEvents chkSupportsFC05 As System.Windows.Forms.CheckBox
    Private WithEvents chkSupportsFC04 As System.Windows.Forms.CheckBox
    Private WithEvents chkSupportsFC03 As System.Windows.Forms.CheckBox
    Private WithEvents btnStartSlave As System.Windows.Forms.Button
    Friend WithEvents lblSerial As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents txtSerial As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblSerialCode As System.Windows.Forms.Label
    Friend WithEvents grbSerial As System.Windows.Forms.GroupBox
End Class
