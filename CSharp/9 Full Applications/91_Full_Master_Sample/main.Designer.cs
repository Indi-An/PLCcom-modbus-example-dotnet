namespace PLCComMB_Master_Example_CSharp
{
    partial class main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.txtWarning = new System.Windows.Forms.TextBox();
            this.grbSerial = new System.Windows.Forms.GroupBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblSerialCode = new System.Windows.Forms.Label();
            this.btnOtherFunctions = new System.Windows.Forms.Button();
            this.btnReadCollection = new System.Windows.Forms.Button();
            this.btnReadWriteModbus = new System.Windows.Forms.Button();
            this.grbAddress = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOperationTimeout = new System.Windows.Forms.Label();
            this.txtOperationTimeout = new System.Windows.Forms.TextBox();
            this.btnSaveConnectionSettings = new System.Windows.Forms.Button();
            this.lblRegisterMode = new System.Windows.Forms.Label();
            this.cmbRegisterMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblmaxIdleTime = new System.Windows.Forms.Label();
            this.txtIdleTime = new System.Windows.Forms.TextBox();
            this.grbSerialSettings = new System.Windows.Forms.GroupBox();
            this.lblHandshake = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.cmbHandshake = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblSerialPort = new System.Windows.Forms.Label();
            this.cmbStopbits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.lblBaudrate = new System.Windows.Forms.Label();
            this.cmbBaudrate = new System.Windows.Forms.ComboBox();
            this.grbIPSettings = new System.Windows.Forms.GroupBox();
            this.lblNetworkAddressFamily = new System.Windows.Forms.Label();
            this.cmbNetworkAddressFamily = new System.Windows.Forms.ComboBox();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.lblAddress0 = new System.Windows.Forms.Label();
            this.txtAddressIP = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.cmbConnectionType = new System.Windows.Forms.ComboBox();
            this.panelStatusStrip = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.txtDeviceState = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDeviceGUID = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnEditConnectionSettings = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbFunctions = new System.Windows.Forms.Panel();
            this.btnCertificateManager = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.chkCRCCheck = new System.Windows.Forms.CheckBox();
            this.lblCRCCheck = new System.Windows.Forms.Label();
            this.grbSerial.SuspendLayout();
            this.grbAddress.SuspendLayout();
            this.grbSerialSettings.SuspendLayout();
            this.grbIPSettings.SuspendLayout();
            this.panelStatusStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grbFunctions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWarning
            // 
            this.txtWarning.BackColor = System.Drawing.SystemColors.Info;
            this.txtWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarning.Location = new System.Drawing.Point(12, 12);
            this.txtWarning.Multiline = true;
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.ReadOnly = true;
            this.txtWarning.Size = new System.Drawing.Size(713, 204);
            this.txtWarning.TabIndex = 5;
            this.txtWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grbSerial
            // 
            this.grbSerial.Controls.Add(this.lblSerial);
            this.grbSerial.Controls.Add(this.lblUser);
            this.grbSerial.Controls.Add(this.txtSerial);
            this.grbSerial.Controls.Add(this.txtUser);
            this.grbSerial.Controls.Add(this.lblSerialCode);
            this.grbSerial.Location = new System.Drawing.Point(12, 222);
            this.grbSerial.Name = "grbSerial";
            this.grbSerial.Size = new System.Drawing.Size(710, 64);
            this.grbSerial.TabIndex = 15;
            this.grbSerial.TabStop = false;
            this.grbSerial.Text = "Serial";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(328, 41);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(34, 13);
            this.lblSerial.TabIndex = 12;
            this.lblSerial.Text = "serial:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(328, 15);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(30, 13);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "user:";
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(370, 38);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(326, 20);
            this.txtSerial.TabIndex = 10;
            this.txtSerial.TextChanged += new System.EventHandler(this.txtSerial_TextChanged);
            // 
            // txtUser
            // 
            this.txtUser.AcceptsReturn = true;
            this.txtUser.Location = new System.Drawing.Point(370, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(326, 20);
            this.txtUser.TabIndex = 0;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // lblSerialCode
            // 
            this.lblSerialCode.AutoSize = true;
            this.lblSerialCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialCode.Location = new System.Drawing.Point(3, 26);
            this.lblSerialCode.Name = "lblSerialCode";
            this.lblSerialCode.Size = new System.Drawing.Size(250, 16);
            this.lblSerialCode.TabIndex = 0;
            this.lblSerialCode.Text = "Enter Serialcode First     >>>>>>>>>";
            // 
            // btnOtherFunctions
            // 
            this.btnOtherFunctions.Image = ((System.Drawing.Image)(resources.GetObject("btnOtherFunctions.Image")));
            this.btnOtherFunctions.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOtherFunctions.Location = new System.Drawing.Point(175, 3);
            this.btnOtherFunctions.Name = "btnOtherFunctions";
            this.btnOtherFunctions.Size = new System.Drawing.Size(68, 68);
            this.btnOtherFunctions.TabIndex = 103;
            this.btnOtherFunctions.Text = "other MB functions";
            this.btnOtherFunctions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOtherFunctions.UseVisualStyleBackColor = true;
            this.btnOtherFunctions.Click += new System.EventHandler(this.btnOtherFunctions_Click);
            // 
            // btnReadCollection
            // 
            this.btnReadCollection.Image = ((System.Drawing.Image)(resources.GetObject("btnReadCollection.Image")));
            this.btnReadCollection.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReadCollection.Location = new System.Drawing.Point(93, 3);
            this.btnReadCollection.Name = "btnReadCollection";
            this.btnReadCollection.Size = new System.Drawing.Size(68, 68);
            this.btnReadCollection.TabIndex = 102;
            this.btnReadCollection.Text = "read collection";
            this.btnReadCollection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReadCollection.UseVisualStyleBackColor = true;
            this.btnReadCollection.Click += new System.EventHandler(this.btnReadCollection_Click);
            // 
            // btnReadWriteModbus
            // 
            this.btnReadWriteModbus.Image = ((System.Drawing.Image)(resources.GetObject("btnReadWriteModbus.Image")));
            this.btnReadWriteModbus.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReadWriteModbus.Location = new System.Drawing.Point(9, 3);
            this.btnReadWriteModbus.Name = "btnReadWriteModbus";
            this.btnReadWriteModbus.Size = new System.Drawing.Size(68, 68);
            this.btnReadWriteModbus.TabIndex = 101;
            this.btnReadWriteModbus.Text = "read write modbus";
            this.btnReadWriteModbus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReadWriteModbus.UseVisualStyleBackColor = true;
            this.btnReadWriteModbus.Click += new System.EventHandler(this.btnReadWriteModbus_Click);
            // 
            // grbAddress
            // 
            this.grbAddress.Controls.Add(this.lblCRCCheck);
            this.grbAddress.Controls.Add(this.chkCRCCheck);
            this.grbAddress.Controls.Add(this.label2);
            this.grbAddress.Controls.Add(this.lblOperationTimeout);
            this.grbAddress.Controls.Add(this.txtOperationTimeout);
            this.grbAddress.Controls.Add(this.btnSaveConnectionSettings);
            this.grbAddress.Controls.Add(this.lblRegisterMode);
            this.grbAddress.Controls.Add(this.cmbRegisterMode);
            this.grbAddress.Controls.Add(this.label1);
            this.grbAddress.Controls.Add(this.lblmaxIdleTime);
            this.grbAddress.Controls.Add(this.txtIdleTime);
            this.grbAddress.Controls.Add(this.grbSerialSettings);
            this.grbAddress.Controls.Add(this.grbIPSettings);
            this.grbAddress.Controls.Add(this.lblConnectionType);
            this.grbAddress.Controls.Add(this.cmbConnectionType);
            this.grbAddress.Enabled = false;
            this.grbAddress.Location = new System.Drawing.Point(12, 361);
            this.grbAddress.Name = "grbAddress";
            this.grbAddress.Size = new System.Drawing.Size(713, 207);
            this.grbAddress.TabIndex = 29;
            this.grbAddress.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "ms";
            // 
            // lblOperationTimeout
            // 
            this.lblOperationTimeout.Location = new System.Drawing.Point(4, 109);
            this.lblOperationTimeout.Name = "lblOperationTimeout";
            this.lblOperationTimeout.Size = new System.Drawing.Size(105, 18);
            this.lblOperationTimeout.TabIndex = 120;
            this.lblOperationTimeout.Text = "OperationTimeout";
            this.lblOperationTimeout.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtOperationTimeout
            // 
            this.txtOperationTimeout.Location = new System.Drawing.Point(110, 107);
            this.txtOperationTimeout.Name = "txtOperationTimeout";
            this.txtOperationTimeout.Size = new System.Drawing.Size(112, 20);
            this.txtOperationTimeout.TabIndex = 119;
            this.txtOperationTimeout.Text = "2000";
            // 
            // btnSaveConnectionSettings
            // 
            this.btnSaveConnectionSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveConnectionSettings.Image")));
            this.btnSaveConnectionSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveConnectionSettings.Location = new System.Drawing.Point(15, 129);
            this.btnSaveConnectionSettings.Name = "btnSaveConnectionSettings";
            this.btnSaveConnectionSettings.Size = new System.Drawing.Size(68, 68);
            this.btnSaveConnectionSettings.TabIndex = 118;
            this.btnSaveConnectionSettings.Text = "save settings";
            this.btnSaveConnectionSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveConnectionSettings.UseVisualStyleBackColor = true;
            this.btnSaveConnectionSettings.Click += new System.EventHandler(this.btnSaveConnectionSettings_Click);
            // 
            // lblRegisterMode
            // 
            this.lblRegisterMode.Location = new System.Drawing.Point(4, 56);
            this.lblRegisterMode.Name = "lblRegisterMode";
            this.lblRegisterMode.Size = new System.Drawing.Size(105, 18);
            this.lblRegisterMode.TabIndex = 72;
            this.lblRegisterMode.Text = "RegisterMode";
            this.lblRegisterMode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbRegisterMode
            // 
            this.cmbRegisterMode.FormattingEnabled = true;
            this.cmbRegisterMode.Location = new System.Drawing.Point(110, 54);
            this.cmbRegisterMode.Name = "cmbRegisterMode";
            this.cmbRegisterMode.Size = new System.Drawing.Size(112, 21);
            this.cmbRegisterMode.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "ms";
            // 
            // lblmaxIdleTime
            // 
            this.lblmaxIdleTime.Location = new System.Drawing.Point(6, 71);
            this.lblmaxIdleTime.Name = "lblmaxIdleTime";
            this.lblmaxIdleTime.Size = new System.Drawing.Size(103, 39);
            this.lblmaxIdleTime.TabIndex = 69;
            this.lblmaxIdleTime.Text = "max. idle time to close the port";
            this.lblmaxIdleTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIdleTime
            // 
            this.txtIdleTime.Location = new System.Drawing.Point(110, 81);
            this.txtIdleTime.Name = "txtIdleTime";
            this.txtIdleTime.Size = new System.Drawing.Size(112, 20);
            this.txtIdleTime.TabIndex = 68;
            this.txtIdleTime.Text = "3000";
            // 
            // grbSerialSettings
            // 
            this.grbSerialSettings.Controls.Add(this.lblHandshake);
            this.grbSerialSettings.Controls.Add(this.lblStopBits);
            this.grbSerialSettings.Controls.Add(this.lblDataBits);
            this.grbSerialSettings.Controls.Add(this.lblParity);
            this.grbSerialSettings.Controls.Add(this.cmbHandshake);
            this.grbSerialSettings.Controls.Add(this.cmbDataBits);
            this.grbSerialSettings.Controls.Add(this.lblSerialPort);
            this.grbSerialSettings.Controls.Add(this.cmbStopbits);
            this.grbSerialSettings.Controls.Add(this.cmbParity);
            this.grbSerialSettings.Controls.Add(this.cmbSerialPort);
            this.grbSerialSettings.Controls.Add(this.lblBaudrate);
            this.grbSerialSettings.Controls.Add(this.cmbBaudrate);
            this.grbSerialSettings.Location = new System.Drawing.Point(502, 13);
            this.grbSerialSettings.Name = "grbSerialSettings";
            this.grbSerialSettings.Size = new System.Drawing.Size(205, 188);
            this.grbSerialSettings.TabIndex = 41;
            this.grbSerialSettings.TabStop = false;
            // 
            // lblHandshake
            // 
            this.lblHandshake.Location = new System.Drawing.Point(3, 156);
            this.lblHandshake.Name = "lblHandshake";
            this.lblHandshake.Size = new System.Drawing.Size(60, 13);
            this.lblHandshake.TabIndex = 50;
            this.lblHandshake.Text = "handshake";
            this.lblHandshake.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStopBits
            // 
            this.lblStopBits.Location = new System.Drawing.Point(17, 129);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(46, 13);
            this.lblStopBits.TabIndex = 49;
            this.lblStopBits.Text = "stop bits";
            this.lblStopBits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDataBits
            // 
            this.lblDataBits.Location = new System.Drawing.Point(15, 102);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(47, 13);
            this.lblDataBits.TabIndex = 48;
            this.lblDataBits.Text = "data bits";
            this.lblDataBits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblParity
            // 
            this.lblParity.Location = new System.Drawing.Point(30, 75);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(32, 13);
            this.lblParity.TabIndex = 47;
            this.lblParity.Text = "parity";
            this.lblParity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbHandshake
            // 
            this.cmbHandshake.FormattingEnabled = true;
            this.cmbHandshake.Location = new System.Drawing.Point(73, 153);
            this.cmbHandshake.Name = "cmbHandshake";
            this.cmbHandshake.Size = new System.Drawing.Size(112, 21);
            this.cmbHandshake.TabIndex = 46;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Location = new System.Drawing.Point(73, 99);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(112, 21);
            this.cmbDataBits.TabIndex = 45;
            // 
            // lblSerialPort
            // 
            this.lblSerialPort.Location = new System.Drawing.Point(11, 18);
            this.lblSerialPort.Name = "lblSerialPort";
            this.lblSerialPort.Size = new System.Drawing.Size(52, 13);
            this.lblSerialPort.TabIndex = 44;
            this.lblSerialPort.Text = "serial port";
            this.lblSerialPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbStopbits
            // 
            this.cmbStopbits.FormattingEnabled = true;
            this.cmbStopbits.Location = new System.Drawing.Point(73, 126);
            this.cmbStopbits.Name = "cmbStopbits";
            this.cmbStopbits.Size = new System.Drawing.Size(112, 21);
            this.cmbStopbits.TabIndex = 42;
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(73, 72);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(112, 21);
            this.cmbParity.TabIndex = 41;
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(73, 15);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(112, 21);
            this.cmbSerialPort.TabIndex = 40;
            // 
            // lblBaudrate
            // 
            this.lblBaudrate.Location = new System.Drawing.Point(13, 48);
            this.lblBaudrate.Name = "lblBaudrate";
            this.lblBaudrate.Size = new System.Drawing.Size(49, 13);
            this.lblBaudrate.TabIndex = 39;
            this.lblBaudrate.Text = "baudrate";
            this.lblBaudrate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbBaudrate
            // 
            this.cmbBaudrate.FormattingEnabled = true;
            this.cmbBaudrate.Location = new System.Drawing.Point(73, 44);
            this.cmbBaudrate.Name = "cmbBaudrate";
            this.cmbBaudrate.Size = new System.Drawing.Size(112, 21);
            this.cmbBaudrate.TabIndex = 38;
            // 
            // grbIPSettings
            // 
            this.grbIPSettings.Controls.Add(this.lblNetworkAddressFamily);
            this.grbIPSettings.Controls.Add(this.cmbNetworkAddressFamily);
            this.grbIPSettings.Controls.Add(this.txtLocalPort);
            this.grbIPSettings.Controls.Add(this.lblAddress0);
            this.grbIPSettings.Controls.Add(this.txtAddressIP);
            this.grbIPSettings.Controls.Add(this.lblAddress1);
            this.grbIPSettings.Controls.Add(this.txtRemotePort);
            this.grbIPSettings.Controls.Add(this.lblAddress2);
            this.grbIPSettings.Location = new System.Drawing.Point(246, 13);
            this.grbIPSettings.Name = "grbIPSettings";
            this.grbIPSettings.Size = new System.Drawing.Size(250, 188);
            this.grbIPSettings.TabIndex = 40;
            this.grbIPSettings.TabStop = false;
            // 
            // lblNetworkAddressFamily
            // 
            this.lblNetworkAddressFamily.Location = new System.Drawing.Point(15, 91);
            this.lblNetworkAddressFamily.Name = "lblNetworkAddressFamily";
            this.lblNetworkAddressFamily.Size = new System.Drawing.Size(103, 39);
            this.lblNetworkAddressFamily.TabIndex = 70;
            this.lblNetworkAddressFamily.Text = "network address family";
            this.lblNetworkAddressFamily.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNetworkAddressFamily
            // 
            this.cmbNetworkAddressFamily.FormattingEnabled = true;
            this.cmbNetworkAddressFamily.Location = new System.Drawing.Point(124, 99);
            this.cmbNetworkAddressFamily.Name = "cmbNetworkAddressFamily";
            this.cmbNetworkAddressFamily.Size = new System.Drawing.Size(112, 21);
            this.cmbNetworkAddressFamily.TabIndex = 41;
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(124, 72);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(112, 20);
            this.txtLocalPort.TabIndex = 29;
            this.txtLocalPort.Text = "0";
            // 
            // lblAddress0
            // 
            this.lblAddress0.Location = new System.Drawing.Point(36, 18);
            this.lblAddress0.Name = "lblAddress0";
            this.lblAddress0.Size = new System.Drawing.Size(82, 13);
            this.lblAddress0.TabIndex = 9;
            this.lblAddress0.Text = "IP/HostAddress";
            this.lblAddress0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtAddressIP
            // 
            this.txtAddressIP.Location = new System.Drawing.Point(124, 16);
            this.txtAddressIP.Name = "txtAddressIP";
            this.txtAddressIP.Size = new System.Drawing.Size(112, 20);
            this.txtAddressIP.TabIndex = 8;
            this.txtAddressIP.Text = "127.0.0.1";
            // 
            // lblAddress1
            // 
            this.lblAddress1.Location = new System.Drawing.Point(7, 48);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(111, 13);
            this.lblAddress1.TabIndex = 28;
            this.lblAddress1.Text = "Slave Port (502)";
            this.lblAddress1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.Location = new System.Drawing.Point(124, 44);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(112, 20);
            this.txtRemotePort.TabIndex = 27;
            this.txtRemotePort.Text = "502";
            // 
            // lblAddress2
            // 
            this.lblAddress2.Location = new System.Drawing.Point(6, 75);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(112, 13);
            this.lblAddress2.TabIndex = 30;
            this.lblAddress2.Text = "Master Port (auto=0)";
            this.lblAddress2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.Location = new System.Drawing.Point(4, 29);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(105, 18);
            this.lblConnectionType.TabIndex = 37;
            this.lblConnectionType.Text = "Type of Connection";
            this.lblConnectionType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbConnectionType
            // 
            this.cmbConnectionType.FormattingEnabled = true;
            this.cmbConnectionType.Location = new System.Drawing.Point(110, 29);
            this.cmbConnectionType.Name = "cmbConnectionType";
            this.cmbConnectionType.Size = new System.Drawing.Size(112, 21);
            this.cmbConnectionType.TabIndex = 36;
            this.cmbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cmbConnectionType_SelectedIndexChanged);
            // 
            // panelStatusStrip
            // 
            this.panelStatusStrip.AutoSize = true;
            this.panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatusStrip.Controls.Add(this.statusStrip);
            this.panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatusStrip.Location = new System.Drawing.Point(0, 665);
            this.panelStatusStrip.Name = "panelStatusStrip";
            this.panelStatusStrip.Size = new System.Drawing.Size(731, 26);
            this.panelStatusStrip.TabIndex = 92;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtDeviceState,
            this.lblDeviceType,
            this.lblDeviceGUID});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(729, 24);
            this.statusStrip.TabIndex = 93;
            // 
            // txtDeviceState
            // 
            this.txtDeviceState.BackColor = System.Drawing.Color.White;
            this.txtDeviceState.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.txtDeviceState.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.txtDeviceState.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.txtDeviceState.Name = "txtDeviceState";
            this.txtDeviceState.Size = new System.Drawing.Size(83, 19);
            this.txtDeviceState.Text = "Disconnected";
            // 
            // lblDeviceType
            // 
            this.lblDeviceType.BackColor = System.Drawing.Color.White;
            this.lblDeviceType.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblDeviceType.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblDeviceType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.lblDeviceType.Name = "lblDeviceType";
            this.lblDeviceType.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.lblDeviceType.Size = new System.Drawing.Size(132, 19);
            this.lblDeviceType.Text = "Adapter Type:  nothing";
            // 
            // lblDeviceGUID
            // 
            this.lblDeviceGUID.BackColor = System.Drawing.Color.White;
            this.lblDeviceGUID.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblDeviceGUID.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.lblDeviceGUID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.lblDeviceGUID.Name = "lblDeviceGUID";
            this.lblDeviceGUID.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.lblDeviceGUID.Size = new System.Drawing.Size(86, 19);
            this.lblDeviceGUID.Text = "GUID: nothing";
            // 
            // btnEditConnectionSettings
            // 
            this.btnEditConnectionSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnEditConnectionSettings.Image")));
            this.btnEditConnectionSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditConnectionSettings.Location = new System.Drawing.Point(27, 292);
            this.btnEditConnectionSettings.Name = "btnEditConnectionSettings";
            this.btnEditConnectionSettings.Size = new System.Drawing.Size(68, 68);
            this.btnEditConnectionSettings.TabIndex = 102;
            this.btnEditConnectionSettings.Text = "edit settings";
            this.btnEditConnectionSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditConnectionSettings.UseVisualStyleBackColor = true;
            this.btnEditConnectionSettings.Click += new System.EventHandler(this.btnEditConnectionSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(626, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 68);
            this.btnClose.TabIndex = 109;
            this.btnClose.Text = "close window";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grbFunctions
            // 
            this.grbFunctions.Controls.Add(this.btnReadWriteModbus);
            this.grbFunctions.Controls.Add(this.btnOtherFunctions);
            this.grbFunctions.Controls.Add(this.btnReadCollection);
            this.grbFunctions.Controls.Add(this.btnCertificateManager);
            this.grbFunctions.Location = new System.Drawing.Point(6, 9);
            this.grbFunctions.Name = "grbFunctions";
            this.grbFunctions.Size = new System.Drawing.Size(340, 75);
            this.grbFunctions.TabIndex = 110;
            // 
            // btnCertificateManager
            // 
            this.btnCertificateManager.Image = System.Drawing.SystemIcons.Shield.ToBitmap();
            this.btnCertificateManager.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCertificateManager.Location = new System.Drawing.Point(252, 5);
            this.btnCertificateManager.Name = "btnCertificateManager";
            this.btnCertificateManager.Size = new System.Drawing.Size(68, 68);
            this.btnCertificateManager.TabIndex = 104;
            this.btnCertificateManager.Text = "show\r\ncertificates";
            this.btnCertificateManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCertificateManager.UseVisualStyleBackColor = true;
            this.btnCertificateManager.Click += new System.EventHandler(this.btnCertificateManager_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grbFunctions);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 568);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 87);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            // 
            // lblLanguage
            // 
            this.lblLanguage.Location = new System.Drawing.Point(325, 295);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(51, 13);
            this.lblLanguage.TabIndex = 128;
            this.lblLanguage.Text = "language";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblLanguage.Click += new System.EventHandler(this.lblLanguage_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(382, 292);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(112, 21);
            this.cmbLanguage.TabIndex = 127;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // chkCRCCheck
            // 
            this.chkCRCCheck.AutoSize = true;
            this.chkCRCCheck.Checked = true;
            this.chkCRCCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCRCCheck.Location = new System.Drawing.Point(224, 180);
            this.chkCRCCheck.Name = "chkCRCCheck";
            this.chkCRCCheck.Size = new System.Drawing.Size(15, 14);
            this.chkCRCCheck.TabIndex = 122;
            this.chkCRCCheck.UseVisualStyleBackColor = true;
            // 
            // lblCRCCheck
            // 
            this.lblCRCCheck.Location = new System.Drawing.Point(110, 170);
            this.lblCRCCheck.Name = "lblCRCCheck";
            this.lblCRCCheck.Size = new System.Drawing.Size(112, 31);
            this.lblCRCCheck.TabIndex = 123;
            this.lblCRCCheck.Text = "RTU/ASCII- CRC/LCR Check";
            this.lblCRCCheck.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // main
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 691);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.btnEditConnectionSettings);
            this.Controls.Add(this.grbAddress);
            this.Controls.Add(this.panelStatusStrip);
            this.Controls.Add(this.grbSerial);
            this.Controls.Add(this.txtWarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start Example";
            this.Activated += new System.EventHandler(this.main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main_FormClosing);
            this.Load += new System.EventHandler(this.main_Load);
            this.grbSerial.ResumeLayout(false);
            this.grbSerial.PerformLayout();
            this.grbAddress.ResumeLayout(false);
            this.grbAddress.PerformLayout();
            this.grbSerialSettings.ResumeLayout(false);
            this.grbIPSettings.ResumeLayout(false);
            this.grbIPSettings.PerformLayout();
            this.panelStatusStrip.ResumeLayout(false);
            this.panelStatusStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grbFunctions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

#endregion

        private System.Windows.Forms.TextBox txtWarning;
        internal System.Windows.Forms.GroupBox grbSerial;
        internal System.Windows.Forms.Label lblSerial;
        internal System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.TextBox txtSerial;
        internal System.Windows.Forms.TextBox txtUser;
        internal System.Windows.Forms.Label lblSerialCode;
        internal System.Windows.Forms.Label lblAddress0;
        internal System.Windows.Forms.TextBox txtAddressIP;
        private System.Windows.Forms.GroupBox grbAddress;
        internal System.Windows.Forms.Label lblBaudrate;
        internal System.Windows.Forms.ComboBox cmbBaudrate;
        internal System.Windows.Forms.Label lblConnectionType;
        internal System.Windows.Forms.ComboBox cmbConnectionType;
        internal System.Windows.Forms.TextBox txtLocalPort;
        internal System.Windows.Forms.Label lblAddress2;
        internal System.Windows.Forms.TextBox txtRemotePort;
        internal System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel txtDeviceState;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceGUID;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.GroupBox grbSerialSettings;
        internal System.Windows.Forms.Label lblSerialPort;
        internal System.Windows.Forms.ComboBox cmbStopbits;
        internal System.Windows.Forms.ComboBox cmbParity;
        internal System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.GroupBox grbIPSettings;
        internal System.Windows.Forms.ComboBox cmbDataBits;
        internal System.Windows.Forms.ComboBox cmbHandshake;
        internal System.Windows.Forms.Label lblHandshake;
        internal System.Windows.Forms.Label lblStopBits;
        internal System.Windows.Forms.Label lblDataBits;
        internal System.Windows.Forms.Label lblParity;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblmaxIdleTime;
        internal System.Windows.Forms.TextBox txtIdleTime;
        internal System.Windows.Forms.Label lblRegisterMode;
        internal System.Windows.Forms.ComboBox cmbRegisterMode;
        private System.Windows.Forms.Button btnOtherFunctions;
        private System.Windows.Forms.Button btnReadCollection;
        private System.Windows.Forms.Button btnReadWriteModbus;
        private System.Windows.Forms.Button btnEditConnectionSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveConnectionSettings;
        private System.Windows.Forms.Panel grbFunctions;
        private System.Windows.Forms.Button btnCertificateManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLanguage;
        internal System.Windows.Forms.ComboBox cmbLanguage;
        internal System.Windows.Forms.Label lblNetworkAddressFamily;
        internal System.Windows.Forms.ComboBox cmbNetworkAddressFamily;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblOperationTimeout;
        internal System.Windows.Forms.TextBox txtOperationTimeout;
        internal System.Windows.Forms.Label lblCRCCheck;
        private System.Windows.Forms.CheckBox chkCRCCheck;
    }
}

