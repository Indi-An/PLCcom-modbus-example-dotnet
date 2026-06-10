<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListenerCreator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListenerCreator))
        Me.txtInfoCreateListener = New System.Windows.Forms.TextBox()
        Me.txtListenerName = New System.Windows.Forms.TextBox()
        Me.lblListenerName = New System.Windows.Forms.Label()
        Me.grbSerialSettings = New System.Windows.Forms.Panel()
        Me.cmbSerialPort = New System.Windows.Forms.ComboBox()
        Me.cmbStopbits = New System.Windows.Forms.ComboBox()
        Me.cmbParity = New System.Windows.Forms.ComboBox()
        Me.cmbDataBits = New System.Windows.Forms.ComboBox()
        Me.cmbHandshake = New System.Windows.Forms.ComboBox()
        Me.cmbBaudrate = New System.Windows.Forms.ComboBox()
        Me.lblConnectionType = New System.Windows.Forms.Label()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.txtLocalPort = New System.Windows.Forms.TextBox()
        Me.cmbConnectionType = New System.Windows.Forms.ComboBox()
        Me.lblLocalPort = New System.Windows.Forms.Label()
        Me.lblHandshake = New System.Windows.Forms.Label()
        Me.grbIPSettings = New System.Windows.Forms.Panel()
        Me.lblSerialPort = New System.Windows.Forms.Label()
        Me.lblStopBits = New System.Windows.Forms.Label()
        Me.lblBaudrate = New System.Windows.Forms.Label()
        Me.lblParity = New System.Windows.Forms.Label()
        Me.lblDataBits = New System.Windows.Forms.Label()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.grbListenerSettings = New System.Windows.Forms.GroupBox()
        Me.grbAddress = New System.Windows.Forms.GroupBox()
        Me.grbSerialSettings.SuspendLayout()
        Me.grbIPSettings.SuspendLayout()
        Me.grbListenerSettings.SuspendLayout()
        Me.grbAddress.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtInfoCreateListener
        '
        Me.txtInfoCreateListener.BackColor = System.Drawing.SystemColors.Info
        Me.txtInfoCreateListener.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfoCreateListener.Location = New System.Drawing.Point(9, 10)
        Me.txtInfoCreateListener.Multiline = True
        Me.txtInfoCreateListener.Name = "txtInfoCreateListener"
        Me.txtInfoCreateListener.Size = New System.Drawing.Size(330, 46)
        Me.txtInfoCreateListener.TabIndex = 117
        Me.txtInfoCreateListener.Text = "Definieren Sie Listener mit dem gewünschten Verbindungstyp. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sie können einem Mo" & _
    "dbus-Slave mehrere verschiedene Listener hinzufügen."
        '
        'txtListenerName
        '
        Me.txtListenerName.Location = New System.Drawing.Point(162, 22)
        Me.txtListenerName.Name = "txtListenerName"
        Me.txtListenerName.Size = New System.Drawing.Size(144, 20)
        Me.txtListenerName.TabIndex = 42
        '
        'lblListenerName
        '
        Me.lblListenerName.Location = New System.Drawing.Point(22, 22)
        Me.lblListenerName.Name = "lblListenerName"
        Me.lblListenerName.Size = New System.Drawing.Size(105, 18)
        Me.lblListenerName.TabIndex = 43
        Me.lblListenerName.Text = "Listenername"
        Me.lblListenerName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grbSerialSettings
        '
        Me.grbSerialSettings.Controls.Add(Me.cmbSerialPort)
        Me.grbSerialSettings.Controls.Add(Me.cmbStopbits)
        Me.grbSerialSettings.Controls.Add(Me.cmbParity)
        Me.grbSerialSettings.Controls.Add(Me.cmbDataBits)
        Me.grbSerialSettings.Controls.Add(Me.cmbHandshake)
        Me.grbSerialSettings.Controls.Add(Me.cmbBaudrate)
        Me.grbSerialSettings.Location = New System.Drawing.Point(136, 56)
        Me.grbSerialSettings.Name = "grbSerialSettings"
        Me.grbSerialSettings.Size = New System.Drawing.Size(171, 172)
        Me.grbSerialSettings.TabIndex = 52
        '
        'cmbSerialPort
        '
        Me.cmbSerialPort.FormattingEnabled = True
        Me.cmbSerialPort.Location = New System.Drawing.Point(18, 3)
        Me.cmbSerialPort.Name = "cmbSerialPort"
        Me.cmbSerialPort.Size = New System.Drawing.Size(144, 21)
        Me.cmbSerialPort.TabIndex = 40
        '
        'cmbStopbits
        '
        Me.cmbStopbits.FormattingEnabled = True
        Me.cmbStopbits.Location = New System.Drawing.Point(18, 114)
        Me.cmbStopbits.Name = "cmbStopbits"
        Me.cmbStopbits.Size = New System.Drawing.Size(144, 21)
        Me.cmbStopbits.TabIndex = 42
        '
        'cmbParity
        '
        Me.cmbParity.FormattingEnabled = True
        Me.cmbParity.Location = New System.Drawing.Point(18, 60)
        Me.cmbParity.Name = "cmbParity"
        Me.cmbParity.Size = New System.Drawing.Size(144, 21)
        Me.cmbParity.TabIndex = 41
        '
        'cmbDataBits
        '
        Me.cmbDataBits.FormattingEnabled = True
        Me.cmbDataBits.Location = New System.Drawing.Point(18, 87)
        Me.cmbDataBits.Name = "cmbDataBits"
        Me.cmbDataBits.Size = New System.Drawing.Size(144, 21)
        Me.cmbDataBits.TabIndex = 45
        '
        'cmbHandshake
        '
        Me.cmbHandshake.FormattingEnabled = True
        Me.cmbHandshake.Location = New System.Drawing.Point(18, 141)
        Me.cmbHandshake.Name = "cmbHandshake"
        Me.cmbHandshake.Size = New System.Drawing.Size(144, 21)
        Me.cmbHandshake.TabIndex = 46
        '
        'cmbBaudrate
        '
        Me.cmbBaudrate.FormattingEnabled = True
        Me.cmbBaudrate.Location = New System.Drawing.Point(18, 32)
        Me.cmbBaudrate.Name = "cmbBaudrate"
        Me.cmbBaudrate.Size = New System.Drawing.Size(144, 21)
        Me.cmbBaudrate.TabIndex = 38
        '
        'lblConnectionType
        '
        Me.lblConnectionType.Location = New System.Drawing.Point(22, 54)
        Me.lblConnectionType.Name = "lblConnectionType"
        Me.lblConnectionType.Size = New System.Drawing.Size(105, 18)
        Me.lblConnectionType.TabIndex = 44
        Me.lblConnectionType.Text = "Type of Connection"
        Me.lblConnectionType.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnAccept
        '
        Me.btnAccept.Image = CType(resources.GetObject("btnAccept.Image"), System.Drawing.Image)
        Me.btnAccept.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAccept.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAccept.Location = New System.Drawing.Point(178, 324)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(68, 68)
        Me.btnAccept.TabIndex = 103
        Me.btnAccept.Text = "accept"
        Me.btnAccept.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'txtLocalPort
        '
        Me.txtLocalPort.Location = New System.Drawing.Point(17, 6)
        Me.txtLocalPort.Name = "txtLocalPort"
        Me.txtLocalPort.Size = New System.Drawing.Size(144, 20)
        Me.txtLocalPort.TabIndex = 29
        Me.txtLocalPort.Text = "502"
        '
        'cmbConnectionType
        '
        Me.cmbConnectionType.FormattingEnabled = True
        Me.cmbConnectionType.Location = New System.Drawing.Point(162, 51)
        Me.cmbConnectionType.Name = "cmbConnectionType"
        Me.cmbConnectionType.Size = New System.Drawing.Size(144, 21)
        Me.cmbConnectionType.TabIndex = 36
        '
        'lblLocalPort
        '
        Me.lblLocalPort.Location = New System.Drawing.Point(15, 28)
        Me.lblLocalPort.Name = "lblLocalPort"
        Me.lblLocalPort.Size = New System.Drawing.Size(117, 13)
        Me.lblLocalPort.TabIndex = 30
        Me.lblLocalPort.Text = "Local Port (default 502)"
        Me.lblLocalPort.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHandshake
        '
        Me.lblHandshake.Location = New System.Drawing.Point(72, 200)
        Me.lblHandshake.Name = "lblHandshake"
        Me.lblHandshake.Size = New System.Drawing.Size(60, 13)
        Me.lblHandshake.TabIndex = 50
        Me.lblHandshake.Text = "handshake"
        Me.lblHandshake.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grbIPSettings
        '
        Me.grbIPSettings.Controls.Add(Me.txtLocalPort)
        Me.grbIPSettings.Enabled = False
        Me.grbIPSettings.Location = New System.Drawing.Point(137, 19)
        Me.grbIPSettings.Name = "grbIPSettings"
        Me.grbIPSettings.Size = New System.Drawing.Size(170, 33)
        Me.grbIPSettings.TabIndex = 51
        '
        'lblSerialPort
        '
        Me.lblSerialPort.Location = New System.Drawing.Point(72, 62)
        Me.lblSerialPort.Name = "lblSerialPort"
        Me.lblSerialPort.Size = New System.Drawing.Size(60, 13)
        Me.lblSerialPort.TabIndex = 44
        Me.lblSerialPort.Text = "serial port"
        Me.lblSerialPort.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblStopBits
        '
        Me.lblStopBits.Location = New System.Drawing.Point(72, 175)
        Me.lblStopBits.Name = "lblStopBits"
        Me.lblStopBits.Size = New System.Drawing.Size(60, 13)
        Me.lblStopBits.TabIndex = 49
        Me.lblStopBits.Text = "stop bits"
        Me.lblStopBits.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBaudrate
        '
        Me.lblBaudrate.Location = New System.Drawing.Point(72, 91)
        Me.lblBaudrate.Name = "lblBaudrate"
        Me.lblBaudrate.Size = New System.Drawing.Size(60, 13)
        Me.lblBaudrate.TabIndex = 39
        Me.lblBaudrate.Text = "baudrate"
        Me.lblBaudrate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblParity
        '
        Me.lblParity.Location = New System.Drawing.Point(72, 119)
        Me.lblParity.Name = "lblParity"
        Me.lblParity.Size = New System.Drawing.Size(60, 13)
        Me.lblParity.TabIndex = 47
        Me.lblParity.Text = "parity"
        Me.lblParity.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDataBits
        '
        Me.lblDataBits.Location = New System.Drawing.Point(72, 146)
        Me.lblDataBits.Name = "lblDataBits"
        Me.lblDataBits.Size = New System.Drawing.Size(60, 13)
        Me.lblDataBits.TabIndex = 48
        Me.lblDataBits.Text = "data bits"
        Me.lblDataBits.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnAbort
        '
        Me.btnAbort.Image = CType(resources.GetObject("btnAbort.Image"), System.Drawing.Image)
        Me.btnAbort.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAbort.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAbort.Location = New System.Drawing.Point(252, 324)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(68, 68)
        Me.btnAbort.TabIndex = 117
        Me.btnAbort.Text = "abort"
        Me.btnAbort.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'grbListenerSettings
        '
        Me.grbListenerSettings.Controls.Add(Me.grbSerialSettings)
        Me.grbListenerSettings.Controls.Add(Me.lblLocalPort)
        Me.grbListenerSettings.Controls.Add(Me.lblHandshake)
        Me.grbListenerSettings.Controls.Add(Me.grbIPSettings)
        Me.grbListenerSettings.Controls.Add(Me.lblSerialPort)
        Me.grbListenerSettings.Controls.Add(Me.lblStopBits)
        Me.grbListenerSettings.Controls.Add(Me.lblBaudrate)
        Me.grbListenerSettings.Controls.Add(Me.lblParity)
        Me.grbListenerSettings.Controls.Add(Me.lblDataBits)
        Me.grbListenerSettings.Location = New System.Drawing.Point(7, 83)
        Me.grbListenerSettings.Name = "grbListenerSettings"
        Me.grbListenerSettings.Size = New System.Drawing.Size(313, 235)
        Me.grbListenerSettings.TabIndex = 45
        Me.grbListenerSettings.TabStop = False
        Me.grbListenerSettings.Text = "listener settings"
        '
        'grbAddress
        '
        Me.grbAddress.Controls.Add(Me.btnAbort)
        Me.grbAddress.Controls.Add(Me.grbListenerSettings)
        Me.grbAddress.Controls.Add(Me.lblConnectionType)
        Me.grbAddress.Controls.Add(Me.btnAccept)
        Me.grbAddress.Controls.Add(Me.txtListenerName)
        Me.grbAddress.Controls.Add(Me.lblListenerName)
        Me.grbAddress.Controls.Add(Me.cmbConnectionType)
        Me.grbAddress.Location = New System.Drawing.Point(9, 59)
        Me.grbAddress.Name = "grbAddress"
        Me.grbAddress.Size = New System.Drawing.Size(330, 403)
        Me.grbAddress.TabIndex = 116
        Me.grbAddress.TabStop = False
        '
        'ListenerCreator
        '
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 472)
        Me.Controls.Add(Me.txtInfoCreateListener)
        Me.Controls.Add(Me.grbAddress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListenerCreator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "create new listener"
        Me.grbSerialSettings.ResumeLayout(False)
        Me.grbIPSettings.ResumeLayout(False)
        Me.grbIPSettings.PerformLayout()
        Me.grbListenerSettings.ResumeLayout(False)
        Me.grbAddress.ResumeLayout(False)
        Me.grbAddress.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtInfoCreateListener As System.Windows.Forms.TextBox
    Friend WithEvents txtListenerName As System.Windows.Forms.TextBox
    Friend WithEvents lblListenerName As System.Windows.Forms.Label
    Private WithEvents grbSerialSettings As System.Windows.Forms.Panel
    Friend WithEvents cmbSerialPort As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStopbits As System.Windows.Forms.ComboBox
    Friend WithEvents cmbParity As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDataBits As System.Windows.Forms.ComboBox
    Friend WithEvents cmbHandshake As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBaudrate As System.Windows.Forms.ComboBox
    Friend WithEvents lblConnectionType As System.Windows.Forms.Label
    Private WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents txtLocalPort As System.Windows.Forms.TextBox
    Friend WithEvents cmbConnectionType As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocalPort As System.Windows.Forms.Label
    Friend WithEvents lblHandshake As System.Windows.Forms.Label
    Private WithEvents grbIPSettings As System.Windows.Forms.Panel
    Friend WithEvents lblSerialPort As System.Windows.Forms.Label
    Friend WithEvents lblStopBits As System.Windows.Forms.Label
    Friend WithEvents lblBaudrate As System.Windows.Forms.Label
    Friend WithEvents lblParity As System.Windows.Forms.Label
    Friend WithEvents lblDataBits As System.Windows.Forms.Label
    Private WithEvents btnAbort As System.Windows.Forms.Button
    Private WithEvents grbListenerSettings As System.Windows.Forms.GroupBox
    Private WithEvents grbAddress As System.Windows.Forms.GroupBox
End Class
