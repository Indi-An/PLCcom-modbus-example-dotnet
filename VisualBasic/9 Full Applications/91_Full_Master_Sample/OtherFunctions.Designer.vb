<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OtherFunctions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OtherFunctions))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSaveLogtoFile = New System.Windows.Forms.Button()
        Me.btnSaveLogtoClipboard = New System.Windows.Forms.Button()
        Me.lvLog = New System.Windows.Forms.ListView()
        Me.lblDeviceGUID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDeviceType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.panelStatusStrip = New System.Windows.Forms.Panel()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.cmbFunction = New System.Windows.Forms.ComboBox()
        Me.lblFunction = New System.Windows.Forms.Label()
        Me.lblBroadcast = New System.Windows.Forms.Label()
        Me.txtInfoOF = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.grpAction = New System.Windows.Forms.GroupBox()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.cmbSlaveID = New System.Windows.Forms.ComboBox()
        Me.statusStrip.SuspendLayout()
        Me.panelStatusStrip.SuspendLayout()
        Me.grpAction.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.Location = New System.Drawing.Point(585, 360)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 68)
        Me.btnClose.TabIndex = 127
        Me.btnClose.Text = "close window"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'columnHeader1
        '
        Me.columnHeader1.Width = 1000
        '
        'btnSaveLogtoFile
        '
        Me.btnSaveLogtoFile.Image = CType(resources.GetObject("btnSaveLogtoFile.Image"), System.Drawing.Image)
        Me.btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveLogtoFile.Location = New System.Drawing.Point(18, 286)
        Me.btnSaveLogtoFile.Name = "btnSaveLogtoFile"
        Me.btnSaveLogtoFile.Size = New System.Drawing.Size(68, 68)
        Me.btnSaveLogtoFile.TabIndex = 126
        Me.btnSaveLogtoFile.Text = "save log to file"
        Me.btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveLogtoFile.UseVisualStyleBackColor = True
        '
        'btnSaveLogtoClipboard
        '
        Me.btnSaveLogtoClipboard.Image = CType(resources.GetObject("btnSaveLogtoClipboard.Image"), System.Drawing.Image)
        Me.btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveLogtoClipboard.Location = New System.Drawing.Point(18, 212)
        Me.btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard"
        Me.btnSaveLogtoClipboard.Size = New System.Drawing.Size(68, 68)
        Me.btnSaveLogtoClipboard.TabIndex = 125
        Me.btnSaveLogtoClipboard.Text = "copy log in clipboard"
        Me.btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveLogtoClipboard.UseVisualStyleBackColor = True
        '
        'lvLog
        '
        Me.lvLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1})
        Me.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvLog.Location = New System.Drawing.Point(103, 212)
        Me.lvLog.Name = "lvLog"
        Me.lvLog.Size = New System.Drawing.Size(550, 142)
        Me.lvLog.TabIndex = 124
        Me.lvLog.UseCompatibleStateImageBehavior = False
        Me.lvLog.View = System.Windows.Forms.View.Details
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
        Me.statusStrip.Size = New System.Drawing.Size(668, 22)
        Me.statusStrip.TabIndex = 94
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(100, 196)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(90, 13)
        Me.lblLog.TabIndex = 123
        Me.lblLog.Text = "Diagnostic output"
        '
        'panelStatusStrip
        '
        Me.panelStatusStrip.AutoSize = True
        Me.panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelStatusStrip.Controls.Add(Me.statusStrip)
        Me.panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelStatusStrip.Location = New System.Drawing.Point(0, 438)
        Me.panelStatusStrip.Name = "panelStatusStrip"
        Me.panelStatusStrip.Size = New System.Drawing.Size(670, 24)
        Me.panelStatusStrip.TabIndex = 122
        '
        'btnExecute
        '
        Me.btnExecute.Image = CType(resources.GetObject("btnExecute.Image"), System.Drawing.Image)
        Me.btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExecute.Location = New System.Drawing.Point(6, 98)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(68, 68)
        Me.btnExecute.TabIndex = 106
        Me.btnExecute.Text = "execute function"
        Me.btnExecute.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'cmbFunction
        '
        Me.cmbFunction.FormattingEnabled = True
        Me.cmbFunction.Location = New System.Drawing.Point(73, 19)
        Me.cmbFunction.Name = "cmbFunction"
        Me.cmbFunction.Size = New System.Drawing.Size(164, 21)
        Me.cmbFunction.TabIndex = 76
        '
        'lblFunction
        '
        Me.lblFunction.AutoSize = True
        Me.lblFunction.Location = New System.Drawing.Point(8, 23)
        Me.lblFunction.Name = "lblFunction"
        Me.lblFunction.Size = New System.Drawing.Size(48, 13)
        Me.lblFunction.TabIndex = 77
        Me.lblFunction.Text = "Function"
        '
        'lblBroadcast
        '
        Me.lblBroadcast.AutoSize = True
        Me.lblBroadcast.ForeColor = System.Drawing.Color.Red
        Me.lblBroadcast.Location = New System.Drawing.Point(70, 70)
        Me.lblBroadcast.Name = "lblBroadcast"
        Me.lblBroadcast.Size = New System.Drawing.Size(55, 13)
        Me.lblBroadcast.TabIndex = 75
        Me.lblBroadcast.Text = "Broadcast"
        '
        'txtInfoOF
        '
        Me.txtInfoOF.BackColor = System.Drawing.SystemColors.Info
        Me.txtInfoOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfoOF.Location = New System.Drawing.Point(260, 19)
        Me.txtInfoOF.Multiline = True
        Me.txtInfoOF.Name = "txtInfoOF"
        Me.txtInfoOF.Size = New System.Drawing.Size(381, 60)
        Me.txtInfoOF.TabIndex = 115
        Me.txtInfoOF.Text = " In diesem Fenster können spezielle Modbusfunktionen getestet werden."
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(8, 49)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(48, 13)
        Me.label2.TabIndex = 74
        Me.label2.Text = "Slave ID"
        '
        'grpAction
        '
        Me.grpAction.Controls.Add(Me.txtResult)
        Me.grpAction.Controls.Add(Me.btnExecute)
        Me.grpAction.Controls.Add(Me.cmbFunction)
        Me.grpAction.Controls.Add(Me.lblFunction)
        Me.grpAction.Controls.Add(Me.lblBroadcast)
        Me.grpAction.Controls.Add(Me.txtInfoOF)
        Me.grpAction.Controls.Add(Me.label2)
        Me.grpAction.Controls.Add(Me.cmbSlaveID)
        Me.grpAction.Location = New System.Drawing.Point(12, 3)
        Me.grpAction.Name = "grpAction"
        Me.grpAction.Size = New System.Drawing.Size(651, 181)
        Me.grpAction.TabIndex = 121
        Me.grpAction.TabStop = False
        Me.grpAction.Text = "Action"
        '
        'txtResult
        '
        Me.txtResult.BackColor = System.Drawing.Color.White
        Me.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResult.Location = New System.Drawing.Point(260, 96)
        Me.txtResult.Multiline = True
        Me.txtResult.Name = "txtResult"
        Me.txtResult.ReadOnly = True
        Me.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResult.Size = New System.Drawing.Size(381, 68)
        Me.txtResult.TabIndex = 35
        '
        'cmbSlaveID
        '
        Me.cmbSlaveID.FormattingEnabled = True
        Me.cmbSlaveID.Location = New System.Drawing.Point(73, 46)
        Me.cmbSlaveID.Name = "cmbSlaveID"
        Me.cmbSlaveID.Size = New System.Drawing.Size(164, 21)
        Me.cmbSlaveID.TabIndex = 73
        '
        'OtherFunctions
        '
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 462)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSaveLogtoFile)
        Me.Controls.Add(Me.btnSaveLogtoClipboard)
        Me.Controls.Add(Me.lvLog)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.panelStatusStrip)
        Me.Controls.Add(Me.grpAction)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OtherFunctions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OtherFunctions"
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.panelStatusStrip.ResumeLayout(False)
        Me.panelStatusStrip.PerformLayout()
        Me.grpAction.ResumeLayout(False)
        Me.grpAction.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnSaveLogtoFile As System.Windows.Forms.Button
    Private WithEvents btnSaveLogtoClipboard As System.Windows.Forms.Button
    Private WithEvents lvLog As System.Windows.Forms.ListView
    Private WithEvents lblDeviceGUID As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents lblDeviceType As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents lblLog As System.Windows.Forms.Label
    Private WithEvents panelStatusStrip As System.Windows.Forms.Panel
    Private WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents cmbFunction As System.Windows.Forms.ComboBox
    Friend WithEvents lblFunction As System.Windows.Forms.Label
    Private WithEvents lblBroadcast As System.Windows.Forms.Label
    Private WithEvents txtInfoOF As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents grpAction As System.Windows.Forms.GroupBox
    Friend WithEvents txtResult As System.Windows.Forms.TextBox
    Friend WithEvents cmbSlaveID As System.Windows.Forms.ComboBox
End Class
