<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadWriteBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadWriteBox))
        Me.btnSaveRequest = New System.Windows.Forms.Button()
        Me.grbWriteValues = New System.Windows.Forms.Panel()
        Me.txtOR = New System.Windows.Forms.TextBox()
        Me.chkSingleValue = New System.Windows.Forms.CheckBox()
        Me.lblWriteMaskRegister_OR = New System.Windows.Forms.Label()
        Me.txtAND = New System.Windows.Forms.TextBox()
        Me.lblWriteMaskRegister_AND = New System.Windows.Forms.Label()
        Me.rbOff = New System.Windows.Forms.RadioButton()
        Me.rbOn = New System.Windows.Forms.RadioButton()
        Me.txtSingleValues = New System.Windows.Forms.TextBox()
        Me.lblEnterValues = New System.Windows.Forms.Label()
        Me.txtMultipleValues = New System.Windows.Forms.TextBox()
        Me.grpAction = New System.Windows.Forms.GroupBox()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.lvValues = New System.Windows.Forms.ListView()
        Me.colDummy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAddress = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnLoadRequest = New System.Windows.Forms.Button()
        Me.lblWriteAddress = New System.Windows.Forms.Label()
        Me.txtWriteAddress = New System.Windows.Forms.TextBox()
        Me.txtInfoRB = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSaveLogtoFile = New System.Windows.Forms.Button()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvLog = New System.Windows.Forms.ListView()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.txtBit = New System.Windows.Forms.TextBox()
        Me.lblBit = New System.Windows.Forms.Label()
        Me.lblDeviceGUID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtReadAddress = New System.Windows.Forms.TextBox()
        Me.lblDataType = New System.Windows.Forms.Label()
        Me.cmbDataType = New System.Windows.Forms.ComboBox()
        Me.lblDeviceType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.panelStatusStrip = New System.Windows.Forms.Panel()
        Me.lblReadAddress = New System.Windows.Forms.Label()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.lblSlaveID = New System.Windows.Forms.Label()
        Me.grpAddress = New System.Windows.Forms.GroupBox()
        Me.cmbSlaveID = New System.Windows.Forms.ComboBox()
        Me.cmbByteOrder = New System.Windows.Forms.ComboBox()
        Me.lblByteOrder = New System.Windows.Forms.Label()
        Me.cmbFunction = New System.Windows.Forms.ComboBox()
        Me.lblFunction = New System.Windows.Forms.Label()
        Me.lblBroadcast = New System.Windows.Forms.Label()
        Me.btnSaveLogtoClipboard = New System.Windows.Forms.Button()
        Me.grbWriteValues.SuspendLayout()
        Me.grpAction.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        Me.panelStatusStrip.SuspendLayout()
        Me.grpAddress.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSaveRequest
        '
        Me.btnSaveRequest.Image = CType(resources.GetObject("btnSaveRequest.Image"), System.Drawing.Image)
        Me.btnSaveRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveRequest.Location = New System.Drawing.Point(520, 602)
        Me.btnSaveRequest.Name = "btnSaveRequest"
        Me.btnSaveRequest.Size = New System.Drawing.Size(68, 68)
        Me.btnSaveRequest.TabIndex = 126
        Me.btnSaveRequest.Text = "save request"
        Me.btnSaveRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveRequest.UseVisualStyleBackColor = True
        '
        'grbWriteValues
        '
        Me.grbWriteValues.Controls.Add(Me.txtOR)
        Me.grbWriteValues.Controls.Add(Me.chkSingleValue)
        Me.grbWriteValues.Controls.Add(Me.lblWriteMaskRegister_OR)
        Me.grbWriteValues.Controls.Add(Me.txtAND)
        Me.grbWriteValues.Controls.Add(Me.lblWriteMaskRegister_AND)
        Me.grbWriteValues.Controls.Add(Me.rbOff)
        Me.grbWriteValues.Controls.Add(Me.rbOn)
        Me.grbWriteValues.Controls.Add(Me.txtSingleValues)
        Me.grbWriteValues.Controls.Add(Me.lblEnterValues)
        Me.grbWriteValues.Controls.Add(Me.txtMultipleValues)
        Me.grbWriteValues.Enabled = False
        Me.grbWriteValues.Location = New System.Drawing.Point(331, 77)
        Me.grbWriteValues.Name = "grbWriteValues"
        Me.grbWriteValues.Size = New System.Drawing.Size(319, 158)
        Me.grbWriteValues.TabIndex = 118
        '
        'txtOR
        '
        Me.txtOR.BackColor = System.Drawing.Color.White
        Me.txtOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOR.Location = New System.Drawing.Point(41, 110)
        Me.txtOR.Name = "txtOR"
        Me.txtOR.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOR.Size = New System.Drawing.Size(275, 20)
        Me.txtOR.TabIndex = 124
        Me.txtOR.Text = "0"
        Me.txtOR.Visible = False
        '
        'chkSingleValue
        '
        Me.chkSingleValue.AutoSize = True
        Me.chkSingleValue.Location = New System.Drawing.Point(41, 11)
        Me.chkSingleValue.Name = "chkSingleValue"
        Me.chkSingleValue.Size = New System.Drawing.Size(82, 17)
        Me.chkSingleValue.TabIndex = 126
        Me.chkSingleValue.Text = "single value"
        Me.chkSingleValue.UseVisualStyleBackColor = True
        '
        'lblWriteMaskRegister_OR
        '
        Me.lblWriteMaskRegister_OR.AutoSize = True
        Me.lblWriteMaskRegister_OR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWriteMaskRegister_OR.Location = New System.Drawing.Point(38, 91)
        Me.lblWriteMaskRegister_OR.Name = "lblWriteMaskRegister_OR"
        Me.lblWriteMaskRegister_OR.Size = New System.Drawing.Size(176, 13)
        Me.lblWriteMaskRegister_OR.TabIndex = 125
        Me.lblWriteMaskRegister_OR.Text = "Enter the OR value in ushort format:"
        Me.lblWriteMaskRegister_OR.Visible = False
        '
        'txtAND
        '
        Me.txtAND.BackColor = System.Drawing.Color.White
        Me.txtAND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAND.Location = New System.Drawing.Point(41, 55)
        Me.txtAND.Name = "txtAND"
        Me.txtAND.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAND.Size = New System.Drawing.Size(275, 20)
        Me.txtAND.TabIndex = 122
        Me.txtAND.Text = "0"
        Me.txtAND.Visible = False
        '
        'lblWriteMaskRegister_AND
        '
        Me.lblWriteMaskRegister_AND.AutoSize = True
        Me.lblWriteMaskRegister_AND.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWriteMaskRegister_AND.Location = New System.Drawing.Point(38, 32)
        Me.lblWriteMaskRegister_AND.Name = "lblWriteMaskRegister_AND"
        Me.lblWriteMaskRegister_AND.Size = New System.Drawing.Size(183, 13)
        Me.lblWriteMaskRegister_AND.TabIndex = 123
        Me.lblWriteMaskRegister_AND.Text = "Enter the AND value in ushort format:"
        Me.lblWriteMaskRegister_AND.Visible = False
        '
        'rbOff
        '
        Me.rbOff.AutoSize = True
        Me.rbOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbOff.Location = New System.Drawing.Point(179, 53)
        Me.rbOff.Name = "rbOff"
        Me.rbOff.Size = New System.Drawing.Size(44, 17)
        Me.rbOff.TabIndex = 121
        Me.rbOff.Text = "OFF"
        Me.rbOff.UseVisualStyleBackColor = True
        Me.rbOff.Visible = False
        '
        'rbOn
        '
        Me.rbOn.AutoSize = True
        Me.rbOn.Checked = True
        Me.rbOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbOn.Location = New System.Drawing.Point(41, 53)
        Me.rbOn.Name = "rbOn"
        Me.rbOn.Size = New System.Drawing.Size(40, 17)
        Me.rbOn.TabIndex = 120
        Me.rbOn.TabStop = True
        Me.rbOn.Text = "ON"
        Me.rbOn.UseVisualStyleBackColor = True
        Me.rbOn.Visible = False
        '
        'txtSingleValues
        '
        Me.txtSingleValues.BackColor = System.Drawing.Color.White
        Me.txtSingleValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSingleValues.Location = New System.Drawing.Point(41, 53)
        Me.txtSingleValues.Name = "txtSingleValues"
        Me.txtSingleValues.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSingleValues.Size = New System.Drawing.Size(275, 20)
        Me.txtSingleValues.TabIndex = 119
        Me.txtSingleValues.Text = "0"
        Me.txtSingleValues.Visible = False
        '
        'lblEnterValues
        '
        Me.lblEnterValues.AutoSize = True
        Me.lblEnterValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnterValues.Location = New System.Drawing.Point(38, 31)
        Me.lblEnterValues.Name = "lblEnterValues"
        Me.lblEnterValues.Size = New System.Drawing.Size(212, 13)
        Me.lblEnterValues.TabIndex = 118
        Me.lblEnterValues.Text = "Please enter the values separated by return"
        '
        'txtMultipleValues
        '
        Me.txtMultipleValues.BackColor = System.Drawing.Color.White
        Me.txtMultipleValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMultipleValues.Location = New System.Drawing.Point(41, 54)
        Me.txtMultipleValues.Multiline = True
        Me.txtMultipleValues.Name = "txtMultipleValues"
        Me.txtMultipleValues.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMultipleValues.Size = New System.Drawing.Size(275, 94)
        Me.txtMultipleValues.TabIndex = 117
        Me.txtMultipleValues.Text = "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0"
        '
        'grpAction
        '
        Me.grpAction.Controls.Add(Me.btnExecute)
        Me.grpAction.Controls.Add(Me.lvValues)
        Me.grpAction.Location = New System.Drawing.Point(12, 249)
        Me.grpAction.Name = "grpAction"
        Me.grpAction.Size = New System.Drawing.Size(656, 180)
        Me.grpAction.TabIndex = 120
        Me.grpAction.TabStop = False
        Me.grpAction.Text = "Action"
        '
        'btnExecute
        '
        Me.btnExecute.Image = CType(resources.GetObject("btnExecute.Image"), System.Drawing.Image)
        Me.btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExecute.Location = New System.Drawing.Point(15, 19)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(68, 68)
        Me.btnExecute.TabIndex = 105
        Me.btnExecute.Text = "execute function"
        Me.btnExecute.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lvValues
        '
        Me.lvValues.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvValues.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDummy, Me.colAddress, Me.colValue})
        Me.lvValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvValues.FullRowSelect = True
        Me.lvValues.Location = New System.Drawing.Point(100, 19)
        Me.lvValues.Name = "lvValues"
        Me.lvValues.Size = New System.Drawing.Size(550, 140)
        Me.lvValues.TabIndex = 104
        Me.lvValues.UseCompatibleStateImageBehavior = False
        Me.lvValues.View = System.Windows.Forms.View.Details
        '
        'colDummy
        '
        Me.colDummy.DisplayIndex = 2
        Me.colDummy.Text = ""
        Me.colDummy.Width = 0
        '
        'colAddress
        '
        Me.colAddress.DisplayIndex = 0
        Me.colAddress.Text = "Adress"
        Me.colAddress.Width = 260
        '
        'colValue
        '
        Me.colValue.DisplayIndex = 1
        Me.colValue.Text = "Value"
        Me.colValue.Width = 260
        '
        'btnLoadRequest
        '
        Me.btnLoadRequest.Image = CType(resources.GetObject("btnLoadRequest.Image"), System.Drawing.Image)
        Me.btnLoadRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLoadRequest.Location = New System.Drawing.Point(446, 602)
        Me.btnLoadRequest.Name = "btnLoadRequest"
        Me.btnLoadRequest.Size = New System.Drawing.Size(68, 68)
        Me.btnLoadRequest.TabIndex = 127
        Me.btnLoadRequest.Text = "load request"
        Me.btnLoadRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoadRequest.UseVisualStyleBackColor = True
        '
        'lblWriteAddress
        '
        Me.lblWriteAddress.Location = New System.Drawing.Point(6, 213)
        Me.lblWriteAddress.Name = "lblWriteAddress"
        Me.lblWriteAddress.Size = New System.Drawing.Size(88, 13)
        Me.lblWriteAddress.TabIndex = 101
        Me.lblWriteAddress.Text = "write adress"
        Me.lblWriteAddress.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtWriteAddress
        '
        Me.txtWriteAddress.Location = New System.Drawing.Point(100, 210)
        Me.txtWriteAddress.Name = "txtWriteAddress"
        Me.txtWriteAddress.Size = New System.Drawing.Size(190, 20)
        Me.txtWriteAddress.TabIndex = 100
        Me.txtWriteAddress.Text = "0"
        '
        'txtInfoRB
        '
        Me.txtInfoRB.BackColor = System.Drawing.SystemColors.Info
        Me.txtInfoRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfoRB.Location = New System.Drawing.Point(372, 21)
        Me.txtInfoRB.Multiline = True
        Me.txtInfoRB.Name = "txtInfoRB"
        Me.txtInfoRB.Size = New System.Drawing.Size(275, 47)
        Me.txtInfoRB.TabIndex = 114
        Me.txtInfoRB.Text = "In diesem Fenster können einzelne Lese- oder Schreibvorgänge durchgeführt werden." & _
    " Für optimierte Lesevorgänge benutzen Sie bitte die ReadCollection."
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.Location = New System.Drawing.Point(594, 602)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 68)
        Me.btnClose.TabIndex = 125
        Me.btnClose.Text = "close window"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSaveLogtoFile
        '
        Me.btnSaveLogtoFile.Image = CType(resources.GetObject("btnSaveLogtoFile.Image"), System.Drawing.Image)
        Me.btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveLogtoFile.Location = New System.Drawing.Point(27, 521)
        Me.btnSaveLogtoFile.Name = "btnSaveLogtoFile"
        Me.btnSaveLogtoFile.Size = New System.Drawing.Size(68, 68)
        Me.btnSaveLogtoFile.TabIndex = 124
        Me.btnSaveLogtoFile.Text = "save log to file"
        Me.btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveLogtoFile.UseVisualStyleBackColor = True
        '
        'columnHeader1
        '
        Me.columnHeader1.Width = 1000
        '
        'lvLog
        '
        Me.lvLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1})
        Me.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvLog.Location = New System.Drawing.Point(112, 447)
        Me.lvLog.Name = "lvLog"
        Me.lvLog.Size = New System.Drawing.Size(550, 142)
        Me.lvLog.TabIndex = 122
        Me.lvLog.UseCompatibleStateImageBehavior = False
        Me.lvLog.View = System.Windows.Forms.View.Details
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(100, 184)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(190, 20)
        Me.txtQuantity.TabIndex = 112
        Me.txtQuantity.Text = "8"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(6, 187)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(88, 13)
        Me.lblQuantity.TabIndex = 113
        Me.lblQuantity.Text = "Quantity"
        Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtBit
        '
        Me.txtBit.Location = New System.Drawing.Point(100, 156)
        Me.txtBit.Name = "txtBit"
        Me.txtBit.Size = New System.Drawing.Size(190, 20)
        Me.txtBit.TabIndex = 109
        Me.txtBit.Text = "0"
        '
        'lblBit
        '
        Me.lblBit.Location = New System.Drawing.Point(6, 159)
        Me.lblBit.Name = "lblBit"
        Me.lblBit.Size = New System.Drawing.Size(88, 13)
        Me.lblBit.TabIndex = 110
        Me.lblBit.Text = "bit"
        Me.lblBit.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDeviceGUID
        '
        Me.lblDeviceGUID.BackColor = System.Drawing.Color.White
        Me.lblDeviceGUID.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblDeviceGUID.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.lblDeviceGUID.Margin = New System.Windows.Forms.Padding(2, 3, 2, 2)
        Me.lblDeviceGUID.Name = "lblDeviceGUID"
        Me.lblDeviceGUID.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.lblDeviceGUID.Size = New System.Drawing.Size(86, 17)
        Me.lblDeviceGUID.Text = "GUID: nothing"
        '
        'txtReadAddress
        '
        Me.txtReadAddress.Location = New System.Drawing.Point(100, 129)
        Me.txtReadAddress.Name = "txtReadAddress"
        Me.txtReadAddress.Size = New System.Drawing.Size(190, 20)
        Me.txtReadAddress.TabIndex = 108
        Me.txtReadAddress.Text = "0"
        '
        'lblDataType
        '
        Me.lblDataType.Location = New System.Drawing.Point(6, 77)
        Me.lblDataType.Name = "lblDataType"
        Me.lblDataType.Size = New System.Drawing.Size(88, 13)
        Me.lblDataType.TabIndex = 76
        Me.lblDataType.Text = "DataType"
        Me.lblDataType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbDataType
        '
        Me.cmbDataType.Enabled = False
        Me.cmbDataType.FormattingEnabled = True
        Me.cmbDataType.Location = New System.Drawing.Point(100, 74)
        Me.cmbDataType.Name = "cmbDataType"
        Me.cmbDataType.Size = New System.Drawing.Size(190, 21)
        Me.cmbDataType.TabIndex = 75
        '
        'lblDeviceType
        '
        Me.lblDeviceType.BackColor = System.Drawing.Color.White
        Me.lblDeviceType.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblDeviceType.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.lblDeviceType.Margin = New System.Windows.Forms.Padding(2, 3, 2, 2)
        Me.lblDeviceType.Name = "lblDeviceType"
        Me.lblDeviceType.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.lblDeviceType.Size = New System.Drawing.Size(78, 17)
        Me.lblDeviceType.Text = "DeviceType: "
        '
        'statusStrip
        '
        Me.statusStrip.BackColor = System.Drawing.SystemColors.Control
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDeviceType, Me.lblDeviceGUID})
        Me.statusStrip.Location = New System.Drawing.Point(0, 0)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(669, 22)
        Me.statusStrip.TabIndex = 95
        '
        'panelStatusStrip
        '
        Me.panelStatusStrip.AutoSize = True
        Me.panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelStatusStrip.Controls.Add(Me.statusStrip)
        Me.panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelStatusStrip.Location = New System.Drawing.Point(0, 687)
        Me.panelStatusStrip.Name = "panelStatusStrip"
        Me.panelStatusStrip.Size = New System.Drawing.Size(671, 24)
        Me.panelStatusStrip.TabIndex = 121
        '
        'lblReadAddress
        '
        Me.lblReadAddress.Location = New System.Drawing.Point(6, 132)
        Me.lblReadAddress.Name = "lblReadAddress"
        Me.lblReadAddress.Size = New System.Drawing.Size(88, 13)
        Me.lblReadAddress.TabIndex = 111
        Me.lblReadAddress.Text = "read adress"
        Me.lblReadAddress.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(109, 432)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(90, 13)
        Me.lblLog.TabIndex = 118
        Me.lblLog.Text = "Diagnostic output"
        '
        'lblSlaveID
        '
        Me.lblSlaveID.Location = New System.Drawing.Point(6, 50)
        Me.lblSlaveID.Name = "lblSlaveID"
        Me.lblSlaveID.Size = New System.Drawing.Size(88, 13)
        Me.lblSlaveID.TabIndex = 74
        Me.lblSlaveID.Text = "slave id"
        Me.lblSlaveID.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpAddress
        '
        Me.grpAddress.Controls.Add(Me.grbWriteValues)
        Me.grpAddress.Controls.Add(Me.lblWriteAddress)
        Me.grpAddress.Controls.Add(Me.txtWriteAddress)
        Me.grpAddress.Controls.Add(Me.txtInfoRB)
        Me.grpAddress.Controls.Add(Me.txtQuantity)
        Me.grpAddress.Controls.Add(Me.lblQuantity)
        Me.grpAddress.Controls.Add(Me.txtBit)
        Me.grpAddress.Controls.Add(Me.lblBit)
        Me.grpAddress.Controls.Add(Me.txtReadAddress)
        Me.grpAddress.Controls.Add(Me.lblReadAddress)
        Me.grpAddress.Controls.Add(Me.lblDataType)
        Me.grpAddress.Controls.Add(Me.cmbDataType)
        Me.grpAddress.Controls.Add(Me.lblSlaveID)
        Me.grpAddress.Controls.Add(Me.cmbSlaveID)
        Me.grpAddress.Controls.Add(Me.cmbByteOrder)
        Me.grpAddress.Controls.Add(Me.lblByteOrder)
        Me.grpAddress.Controls.Add(Me.cmbFunction)
        Me.grpAddress.Controls.Add(Me.lblFunction)
        Me.grpAddress.Controls.Add(Me.lblBroadcast)
        Me.grpAddress.Location = New System.Drawing.Point(12, 2)
        Me.grpAddress.Name = "grpAddress"
        Me.grpAddress.Size = New System.Drawing.Size(656, 241)
        Me.grpAddress.TabIndex = 119
        Me.grpAddress.TabStop = False
        Me.grpAddress.Text = "Address"
        '
        'cmbSlaveID
        '
        Me.cmbSlaveID.FormattingEnabled = True
        Me.cmbSlaveID.Location = New System.Drawing.Point(100, 47)
        Me.cmbSlaveID.Name = "cmbSlaveID"
        Me.cmbSlaveID.Size = New System.Drawing.Size(190, 21)
        Me.cmbSlaveID.TabIndex = 73
        '
        'cmbByteOrder
        '
        Me.cmbByteOrder.Enabled = False
        Me.cmbByteOrder.FormattingEnabled = True
        Me.cmbByteOrder.Location = New System.Drawing.Point(100, 102)
        Me.cmbByteOrder.Name = "cmbByteOrder"
        Me.cmbByteOrder.Size = New System.Drawing.Size(190, 21)
        Me.cmbByteOrder.TabIndex = 72
        '
        'lblByteOrder
        '
        Me.lblByteOrder.Location = New System.Drawing.Point(6, 105)
        Me.lblByteOrder.Name = "lblByteOrder"
        Me.lblByteOrder.Size = New System.Drawing.Size(88, 13)
        Me.lblByteOrder.TabIndex = 71
        Me.lblByteOrder.Text = "byte encoding"
        Me.lblByteOrder.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbFunction
        '
        Me.cmbFunction.FormattingEnabled = True
        Me.cmbFunction.Location = New System.Drawing.Point(100, 19)
        Me.cmbFunction.Name = "cmbFunction"
        Me.cmbFunction.Size = New System.Drawing.Size(190, 21)
        Me.cmbFunction.TabIndex = 69
        '
        'lblFunction
        '
        Me.lblFunction.Location = New System.Drawing.Point(6, 23)
        Me.lblFunction.Name = "lblFunction"
        Me.lblFunction.Size = New System.Drawing.Size(88, 13)
        Me.lblFunction.TabIndex = 70
        Me.lblFunction.Text = "Function"
        Me.lblFunction.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBroadcast
        '
        Me.lblBroadcast.ForeColor = System.Drawing.Color.Red
        Me.lblBroadcast.Location = New System.Drawing.Point(295, 38)
        Me.lblBroadcast.Name = "lblBroadcast"
        Me.lblBroadcast.Size = New System.Drawing.Size(91, 45)
        Me.lblBroadcast.TabIndex = 66
        Me.lblBroadcast.Text = "broadcast, if it supported by slave"
        '
        'btnSaveLogtoClipboard
        '
        Me.btnSaveLogtoClipboard.Image = CType(resources.GetObject("btnSaveLogtoClipboard.Image"), System.Drawing.Image)
        Me.btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveLogtoClipboard.Location = New System.Drawing.Point(27, 447)
        Me.btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard"
        Me.btnSaveLogtoClipboard.Size = New System.Drawing.Size(68, 68)
        Me.btnSaveLogtoClipboard.TabIndex = 123
        Me.btnSaveLogtoClipboard.Text = "copy log to clipboard"
        Me.btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveLogtoClipboard.UseVisualStyleBackColor = True
        '
        'ReadWriteBox
        '
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 711)
        Me.Controls.Add(Me.btnSaveRequest)
        Me.Controls.Add(Me.grpAction)
        Me.Controls.Add(Me.btnLoadRequest)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSaveLogtoFile)
        Me.Controls.Add(Me.lvLog)
        Me.Controls.Add(Me.panelStatusStrip)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.grpAddress)
        Me.Controls.Add(Me.btnSaveLogtoClipboard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReadWriteBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReadWriteBox"
        Me.grbWriteValues.ResumeLayout(False)
        Me.grbWriteValues.PerformLayout()
        Me.grpAction.ResumeLayout(False)
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.panelStatusStrip.ResumeLayout(False)
        Me.panelStatusStrip.PerformLayout()
        Me.grpAddress.ResumeLayout(False)
        Me.grpAddress.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnSaveRequest As System.Windows.Forms.Button
    Private WithEvents grbWriteValues As System.Windows.Forms.Panel
    Friend WithEvents txtOR As System.Windows.Forms.TextBox
    Private WithEvents chkSingleValue As System.Windows.Forms.CheckBox
    Friend WithEvents lblWriteMaskRegister_OR As System.Windows.Forms.Label
    Friend WithEvents txtAND As System.Windows.Forms.TextBox
    Friend WithEvents lblWriteMaskRegister_AND As System.Windows.Forms.Label
    Private WithEvents rbOff As System.Windows.Forms.RadioButton
    Private WithEvents rbOn As System.Windows.Forms.RadioButton
    Friend WithEvents txtSingleValues As System.Windows.Forms.TextBox
    Friend WithEvents lblEnterValues As System.Windows.Forms.Label
    Friend WithEvents txtMultipleValues As System.Windows.Forms.TextBox
    Private WithEvents grpAction As System.Windows.Forms.GroupBox
    Private WithEvents btnExecute As System.Windows.Forms.Button
    Private WithEvents lvValues As System.Windows.Forms.ListView
    Private WithEvents colDummy As System.Windows.Forms.ColumnHeader
    Private WithEvents colAddress As System.Windows.Forms.ColumnHeader
    Private WithEvents colValue As System.Windows.Forms.ColumnHeader
    Private WithEvents btnLoadRequest As System.Windows.Forms.Button
    Friend WithEvents lblWriteAddress As System.Windows.Forms.Label
    Friend WithEvents txtWriteAddress As System.Windows.Forms.TextBox
    Private WithEvents txtInfoRB As System.Windows.Forms.TextBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSaveLogtoFile As System.Windows.Forms.Button
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents lvLog As System.Windows.Forms.ListView
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents txtBit As System.Windows.Forms.TextBox
    Friend WithEvents lblBit As System.Windows.Forms.Label
    Private WithEvents lblDeviceGUID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtReadAddress As System.Windows.Forms.TextBox
    Private WithEvents lblDataType As System.Windows.Forms.Label
    Friend WithEvents cmbDataType As System.Windows.Forms.ComboBox
    Private WithEvents lblDeviceType As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Private WithEvents panelStatusStrip As System.Windows.Forms.Panel
    Friend WithEvents lblReadAddress As System.Windows.Forms.Label
    Friend WithEvents lblLog As System.Windows.Forms.Label
    Private WithEvents lblSlaveID As System.Windows.Forms.Label
    Private WithEvents grpAddress As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSlaveID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbByteOrder As System.Windows.Forms.ComboBox
    Private WithEvents lblByteOrder As System.Windows.Forms.Label
    Friend WithEvents cmbFunction As System.Windows.Forms.ComboBox
    Friend WithEvents lblFunction As System.Windows.Forms.Label
    Private WithEvents lblBroadcast As System.Windows.Forms.Label
    Private WithEvents btnSaveLogtoClipboard As System.Windows.Forms.Button
End Class
