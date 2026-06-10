<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReadCollectionBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadCollectionBox))
        Me.btnSaveLogtoClipboard = New System.Windows.Forms.Button()
        Me.lvLog = New System.Windows.Forms.ListView()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnReadCollection = New System.Windows.Forms.Button()
        Me.lvValues = New System.Windows.Forms.ListView()
        Me.colDummy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colAddress = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtRequestKey = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.lblDataType = New System.Windows.Forms.Label()
        Me.cmbDataType = New System.Windows.Forms.ComboBox()
        Me.btnAddRequest = New System.Windows.Forms.Button()
        Me.lblSlaveID = New System.Windows.Forms.Label()
        Me.txtInfoRCB = New System.Windows.Forms.TextBox()
        Me.btnRemoveRequest = New System.Windows.Forms.Button()
        Me.lvRequests = New System.Windows.Forms.ListView()
        Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panelStatusStrip = New System.Windows.Forms.Panel()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblDeviceType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDeviceGUID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtBit = New System.Windows.Forms.TextBox()
        Me.lblBit = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmbSlaveID = New System.Windows.Forms.ComboBox()
        Me.btnSaveRequests = New System.Windows.Forms.Button()
        Me.btnLoadRequests = New System.Windows.Forms.Button()
        Me.grpAction = New System.Windows.Forms.GroupBox()
        Me.btnSaveLogtoFile = New System.Windows.Forms.Button()
        Me.cmbByteOrder = New System.Windows.Forms.ComboBox()
        Me.lblByteOrder = New System.Windows.Forms.Label()
        Me.txtReadAddress = New System.Windows.Forms.TextBox()
        Me.lblReadAddress = New System.Windows.Forms.Label()
        Me.cmbFunction = New System.Windows.Forms.ComboBox()
        Me.lblFunction = New System.Windows.Forms.Label()
        Me.grpAddress = New System.Windows.Forms.GroupBox()
        Me.panelStatusStrip.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        Me.grpAction.SuspendLayout()
        Me.grpAddress.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSaveLogtoClipboard
        '
        Me.btnSaveLogtoClipboard.Image = CType(resources.GetObject("btnSaveLogtoClipboard.Image"), System.Drawing.Image)
        Me.btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveLogtoClipboard.Location = New System.Drawing.Point(6, 182)
        Me.btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard"
        Me.btnSaveLogtoClipboard.Size = New System.Drawing.Size(68, 68)
        Me.btnSaveLogtoClipboard.TabIndex = 104
        Me.btnSaveLogtoClipboard.Text = "copy log in clipboard"
        Me.btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveLogtoClipboard.UseVisualStyleBackColor = True
        '
        'lvLog
        '
        Me.lvLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1})
        Me.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvLog.Location = New System.Drawing.Point(91, 182)
        Me.lvLog.Name = "lvLog"
        Me.lvLog.Size = New System.Drawing.Size(550, 140)
        Me.lvLog.TabIndex = 98
        Me.lvLog.UseCompatibleStateImageBehavior = False
        Me.lvLog.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Width = 1000
        '
        'btnReadCollection
        '
        Me.btnReadCollection.Image = CType(resources.GetObject("btnReadCollection.Image"), System.Drawing.Image)
        Me.btnReadCollection.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReadCollection.Location = New System.Drawing.Point(6, 18)
        Me.btnReadCollection.Name = "btnReadCollection"
        Me.btnReadCollection.Size = New System.Drawing.Size(68, 68)
        Me.btnReadCollection.TabIndex = 103
        Me.btnReadCollection.Text = "read collection"
        Me.btnReadCollection.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReadCollection.UseVisualStyleBackColor = True
        '
        'lvValues
        '
        Me.lvValues.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvValues.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDummy, Me.colAddress, Me.colValue})
        Me.lvValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvValues.FullRowSelect = True
        Me.lvValues.Location = New System.Drawing.Point(91, 18)
        Me.lvValues.Name = "lvValues"
        Me.lvValues.Size = New System.Drawing.Size(550, 140)
        Me.lvValues.TabIndex = 102
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
        'txtRequestKey
        '
        Me.txtRequestKey.Location = New System.Drawing.Point(94, 12)
        Me.txtRequestKey.Name = "txtRequestKey"
        Me.txtRequestKey.Size = New System.Drawing.Size(238, 20)
        Me.txtRequestKey.TabIndex = 69
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(6, 16)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(82, 16)
        Me.label3.TabIndex = 70
        Me.label3.Text = "requestkey"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDataType
        '
        Me.lblDataType.Location = New System.Drawing.Point(6, 99)
        Me.lblDataType.Name = "lblDataType"
        Me.lblDataType.Size = New System.Drawing.Size(82, 16)
        Me.lblDataType.TabIndex = 68
        Me.lblDataType.Text = "datatype"
        Me.lblDataType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbDataType
        '
        Me.cmbDataType.Enabled = False
        Me.cmbDataType.FormattingEnabled = True
        Me.cmbDataType.Location = New System.Drawing.Point(94, 96)
        Me.cmbDataType.Name = "cmbDataType"
        Me.cmbDataType.Size = New System.Drawing.Size(238, 21)
        Me.cmbDataType.TabIndex = 67
        '
        'btnAddRequest
        '
        Me.btnAddRequest.Image = CType(resources.GetObject("btnAddRequest.Image"), System.Drawing.Image)
        Me.btnAddRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddRequest.Location = New System.Drawing.Point(9, 153)
        Me.btnAddRequest.Name = "btnAddRequest"
        Me.btnAddRequest.Size = New System.Drawing.Size(68, 68)
        Me.btnAddRequest.TabIndex = 66
        Me.btnAddRequest.Text = "add Request"
        Me.btnAddRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddRequest.UseVisualStyleBackColor = True
        '
        'lblSlaveID
        '
        Me.lblSlaveID.Location = New System.Drawing.Point(6, 72)
        Me.lblSlaveID.Name = "lblSlaveID"
        Me.lblSlaveID.Size = New System.Drawing.Size(82, 16)
        Me.lblSlaveID.TabIndex = 65
        Me.lblSlaveID.Text = "slave id"
        Me.lblSlaveID.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtInfoRCB
        '
        Me.txtInfoRCB.BackColor = System.Drawing.SystemColors.Info
        Me.txtInfoRCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfoRCB.Location = New System.Drawing.Point(406, 12)
        Me.txtInfoRCB.Multiline = True
        Me.txtInfoRCB.Name = "txtInfoRCB"
        Me.txtInfoRCB.Size = New System.Drawing.Size(238, 49)
        Me.txtInfoRCB.TabIndex = 106
        Me.txtInfoRCB.Text = "Bei der ReadCollection werden Lese-Vorgänge logisch optimiert, sodass nur die min" & _
    "imal notwendigen Zugriffe auf den Modbus erfolgen. "
        '
        'btnRemoveRequest
        '
        Me.btnRemoveRequest.Image = CType(resources.GetObject("btnRemoveRequest.Image"), System.Drawing.Image)
        Me.btnRemoveRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRemoveRequest.Location = New System.Drawing.Point(9, 227)
        Me.btnRemoveRequest.Name = "btnRemoveRequest"
        Me.btnRemoveRequest.Size = New System.Drawing.Size(68, 68)
        Me.btnRemoveRequest.TabIndex = 105
        Me.btnRemoveRequest.Text = "remove Request"
        Me.btnRemoveRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemoveRequest.UseVisualStyleBackColor = True
        '
        'lvRequests
        '
        Me.lvRequests.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvRequests.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader2, Me.columnHeader4})
        Me.lvRequests.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRequests.FullRowSelect = True
        Me.lvRequests.Location = New System.Drawing.Point(94, 153)
        Me.lvRequests.Name = "lvRequests"
        Me.lvRequests.Size = New System.Drawing.Size(550, 140)
        Me.lvRequests.TabIndex = 104
        Me.lvRequests.UseCompatibleStateImageBehavior = False
        Me.lvRequests.View = System.Windows.Forms.View.Details
        '
        'columnHeader2
        '
        Me.columnHeader2.DisplayIndex = 1
        Me.columnHeader2.Text = ""
        Me.columnHeader2.Width = 0
        '
        'columnHeader4
        '
        Me.columnHeader4.DisplayIndex = 0
        Me.columnHeader4.Text = "Request"
        Me.columnHeader4.Width = 520
        '
        'panelStatusStrip
        '
        Me.panelStatusStrip.AutoSize = True
        Me.panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelStatusStrip.Controls.Add(Me.statusStrip)
        Me.panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelStatusStrip.Location = New System.Drawing.Point(0, 742)
        Me.panelStatusStrip.Name = "panelStatusStrip"
        Me.panelStatusStrip.Size = New System.Drawing.Size(678, 24)
        Me.panelStatusStrip.TabIndex = 103
        '
        'statusStrip
        '
        Me.statusStrip.BackColor = System.Drawing.SystemColors.Control
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblDeviceType, Me.lblDeviceGUID})
        Me.statusStrip.Location = New System.Drawing.Point(0, 0)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(676, 22)
        Me.statusStrip.TabIndex = 95
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
        'txtBit
        '
        Me.txtBit.Location = New System.Drawing.Point(406, 95)
        Me.txtBit.Name = "txtBit"
        Me.txtBit.Size = New System.Drawing.Size(238, 20)
        Me.txtBit.TabIndex = 56
        Me.txtBit.Text = "0"
        '
        'lblBit
        '
        Me.lblBit.Location = New System.Drawing.Point(338, 99)
        Me.lblBit.Name = "lblBit"
        Me.lblBit.Size = New System.Drawing.Size(62, 13)
        Me.lblBit.TabIndex = 57
        Me.lblBit.Text = "Bit"
        Me.lblBit.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(406, 124)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(238, 20)
        Me.txtQuantity.TabIndex = 60
        Me.txtQuantity.Text = "8"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(338, 127)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(62, 13)
        Me.lblQuantity.TabIndex = 61
        Me.lblQuantity.Text = "Quantity"
        Me.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(98, 166)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(90, 13)
        Me.lblLog.TabIndex = 39
        Me.lblLog.Text = "Diagnostic output"
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.Location = New System.Drawing.Point(588, 666)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 68)
        Me.btnClose.TabIndex = 105
        Me.btnClose.Text = "close window"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmbSlaveID
        '
        Me.cmbSlaveID.FormattingEnabled = True
        Me.cmbSlaveID.Location = New System.Drawing.Point(94, 69)
        Me.cmbSlaveID.Name = "cmbSlaveID"
        Me.cmbSlaveID.Size = New System.Drawing.Size(238, 21)
        Me.cmbSlaveID.TabIndex = 64
        '
        'btnSaveRequests
        '
        Me.btnSaveRequests.Image = CType(resources.GetObject("btnSaveRequests.Image"), System.Drawing.Image)
        Me.btnSaveRequests.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveRequests.Location = New System.Drawing.Point(514, 666)
        Me.btnSaveRequests.Name = "btnSaveRequests"
        Me.btnSaveRequests.Size = New System.Drawing.Size(68, 68)
        Me.btnSaveRequests.TabIndex = 104
        Me.btnSaveRequests.Text = "save requests"
        Me.btnSaveRequests.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveRequests.UseVisualStyleBackColor = True
        '
        'btnLoadRequests
        '
        Me.btnLoadRequests.Image = CType(resources.GetObject("btnLoadRequests.Image"), System.Drawing.Image)
        Me.btnLoadRequests.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLoadRequests.Location = New System.Drawing.Point(440, 666)
        Me.btnLoadRequests.Name = "btnLoadRequests"
        Me.btnLoadRequests.Size = New System.Drawing.Size(68, 68)
        Me.btnLoadRequests.TabIndex = 106
        Me.btnLoadRequests.Text = "load requests"
        Me.btnLoadRequests.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoadRequests.UseVisualStyleBackColor = True
        '
        'grpAction
        '
        Me.grpAction.Controls.Add(Me.btnSaveLogtoFile)
        Me.grpAction.Controls.Add(Me.btnSaveLogtoClipboard)
        Me.grpAction.Controls.Add(Me.lblLog)
        Me.grpAction.Controls.Add(Me.lvLog)
        Me.grpAction.Controls.Add(Me.btnReadCollection)
        Me.grpAction.Controls.Add(Me.lvValues)
        Me.grpAction.Location = New System.Drawing.Point(15, 329)
        Me.grpAction.Name = "grpAction"
        Me.grpAction.Size = New System.Drawing.Size(656, 334)
        Me.grpAction.TabIndex = 102
        Me.grpAction.TabStop = False
        Me.grpAction.Text = "Results"
        '
        'btnSaveLogtoFile
        '
        Me.btnSaveLogtoFile.Image = CType(resources.GetObject("btnSaveLogtoFile.Image"), System.Drawing.Image)
        Me.btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveLogtoFile.Location = New System.Drawing.Point(6, 256)
        Me.btnSaveLogtoFile.Name = "btnSaveLogtoFile"
        Me.btnSaveLogtoFile.Size = New System.Drawing.Size(68, 68)
        Me.btnSaveLogtoFile.TabIndex = 105
        Me.btnSaveLogtoFile.Text = "save log to file"
        Me.btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveLogtoFile.UseVisualStyleBackColor = True
        '
        'cmbByteOrder
        '
        Me.cmbByteOrder.Enabled = False
        Me.cmbByteOrder.FormattingEnabled = True
        Me.cmbByteOrder.Location = New System.Drawing.Point(94, 124)
        Me.cmbByteOrder.Name = "cmbByteOrder"
        Me.cmbByteOrder.Size = New System.Drawing.Size(238, 21)
        Me.cmbByteOrder.TabIndex = 63
        '
        'lblByteOrder
        '
        Me.lblByteOrder.Location = New System.Drawing.Point(6, 127)
        Me.lblByteOrder.Name = "lblByteOrder"
        Me.lblByteOrder.Size = New System.Drawing.Size(82, 16)
        Me.lblByteOrder.TabIndex = 62
        Me.lblByteOrder.Text = "byte encoding"
        Me.lblByteOrder.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtReadAddress
        '
        Me.txtReadAddress.Location = New System.Drawing.Point(406, 69)
        Me.txtReadAddress.Name = "txtReadAddress"
        Me.txtReadAddress.Size = New System.Drawing.Size(238, 20)
        Me.txtReadAddress.TabIndex = 55
        Me.txtReadAddress.Text = "0"
        '
        'lblReadAddress
        '
        Me.lblReadAddress.Location = New System.Drawing.Point(338, 72)
        Me.lblReadAddress.Name = "lblReadAddress"
        Me.lblReadAddress.Size = New System.Drawing.Size(62, 13)
        Me.lblReadAddress.TabIndex = 58
        Me.lblReadAddress.Text = "read adress"
        Me.lblReadAddress.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbFunction
        '
        Me.cmbFunction.FormattingEnabled = True
        Me.cmbFunction.Location = New System.Drawing.Point(94, 41)
        Me.cmbFunction.Name = "cmbFunction"
        Me.cmbFunction.Size = New System.Drawing.Size(238, 21)
        Me.cmbFunction.TabIndex = 52
        '
        'lblFunction
        '
        Me.lblFunction.Location = New System.Drawing.Point(6, 44)
        Me.lblFunction.Name = "lblFunction"
        Me.lblFunction.Size = New System.Drawing.Size(82, 16)
        Me.lblFunction.TabIndex = 53
        Me.lblFunction.Text = "function"
        Me.lblFunction.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpAddress
        '
        Me.grpAddress.Controls.Add(Me.txtInfoRCB)
        Me.grpAddress.Controls.Add(Me.btnRemoveRequest)
        Me.grpAddress.Controls.Add(Me.lvRequests)
        Me.grpAddress.Controls.Add(Me.txtRequestKey)
        Me.grpAddress.Controls.Add(Me.label3)
        Me.grpAddress.Controls.Add(Me.lblDataType)
        Me.grpAddress.Controls.Add(Me.cmbDataType)
        Me.grpAddress.Controls.Add(Me.btnAddRequest)
        Me.grpAddress.Controls.Add(Me.lblSlaveID)
        Me.grpAddress.Controls.Add(Me.txtQuantity)
        Me.grpAddress.Controls.Add(Me.lblQuantity)
        Me.grpAddress.Controls.Add(Me.txtBit)
        Me.grpAddress.Controls.Add(Me.lblBit)
        Me.grpAddress.Controls.Add(Me.cmbSlaveID)
        Me.grpAddress.Controls.Add(Me.txtReadAddress)
        Me.grpAddress.Controls.Add(Me.cmbByteOrder)
        Me.grpAddress.Controls.Add(Me.lblByteOrder)
        Me.grpAddress.Controls.Add(Me.lblReadAddress)
        Me.grpAddress.Controls.Add(Me.cmbFunction)
        Me.grpAddress.Controls.Add(Me.lblFunction)
        Me.grpAddress.Location = New System.Drawing.Point(12, 2)
        Me.grpAddress.Name = "grpAddress"
        Me.grpAddress.Size = New System.Drawing.Size(656, 306)
        Me.grpAddress.TabIndex = 101
        Me.grpAddress.TabStop = False
        Me.grpAddress.Text = "add read request"
        '
        'ReadCollectionBox
        '
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 766)
        Me.Controls.Add(Me.panelStatusStrip)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSaveRequests)
        Me.Controls.Add(Me.btnLoadRequests)
        Me.Controls.Add(Me.grpAction)
        Me.Controls.Add(Me.grpAddress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReadCollectionBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReadWriteBox"
        Me.panelStatusStrip.ResumeLayout(False)
        Me.panelStatusStrip.PerformLayout()
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.grpAction.ResumeLayout(False)
        Me.grpAction.PerformLayout()
        Me.grpAddress.ResumeLayout(False)
        Me.grpAddress.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnSaveLogtoClipboard As System.Windows.Forms.Button
    Private WithEvents lvLog As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnReadCollection As System.Windows.Forms.Button
    Private WithEvents lvValues As System.Windows.Forms.ListView
    Private WithEvents colDummy As System.Windows.Forms.ColumnHeader
    Private WithEvents colAddress As System.Windows.Forms.ColumnHeader
    Private WithEvents colValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtRequestKey As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents lblDataType As System.Windows.Forms.Label
    Friend WithEvents cmbDataType As System.Windows.Forms.ComboBox
    Private WithEvents btnAddRequest As System.Windows.Forms.Button
    Private WithEvents lblSlaveID As System.Windows.Forms.Label
    Private WithEvents txtInfoRCB As System.Windows.Forms.TextBox
    Private WithEvents btnRemoveRequest As System.Windows.Forms.Button
    Private WithEvents lvRequests As System.Windows.Forms.ListView
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents panelStatusStrip As System.Windows.Forms.Panel
    Private WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Private WithEvents lblDeviceType As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents lblDeviceGUID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtBit As System.Windows.Forms.TextBox
    Friend WithEvents lblBit As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents lblLog As System.Windows.Forms.Label
    Private WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cmbSlaveID As System.Windows.Forms.ComboBox
    Private WithEvents btnSaveRequests As System.Windows.Forms.Button
    Private WithEvents btnLoadRequests As System.Windows.Forms.Button
    Private WithEvents grpAction As System.Windows.Forms.GroupBox
    Private WithEvents btnSaveLogtoFile As System.Windows.Forms.Button
    Friend WithEvents cmbByteOrder As System.Windows.Forms.ComboBox
    Private WithEvents lblByteOrder As System.Windows.Forms.Label
    Friend WithEvents txtReadAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblReadAddress As System.Windows.Forms.Label
    Friend WithEvents cmbFunction As System.Windows.Forms.ComboBox
    Friend WithEvents lblFunction As System.Windows.Forms.Label
    Private WithEvents grpAddress As System.Windows.Forms.GroupBox
End Class
