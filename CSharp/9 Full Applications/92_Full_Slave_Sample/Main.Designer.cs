namespace PLCcomMB_Slave_Example_CSharp
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnStartSlave = new System.Windows.Forms.Button();
            this.lblRegisterMode = new System.Windows.Forms.Label();
            this.cmbRegisterMode = new System.Windows.Forms.ComboBox();
            this.grbSerial = new System.Windows.Forms.GroupBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblSerialCode = new System.Windows.Forms.Label();
            this.grbListener = new System.Windows.Forms.GroupBox();
            this.grbStatistics = new System.Windows.Forms.GroupBox();
            this.txtUnparseableRequests = new System.Windows.Forms.TextBox();
            this.lblUnparseableRequests = new System.Windows.Forms.Label();
            this.txtIncorectRequests = new System.Windows.Forms.TextBox();
            this.txtIncomingRequests = new System.Windows.Forms.TextBox();
            this.lblIncorrectRequests = new System.Windows.Forms.Label();
            this.lblIncomingRequests = new System.Windows.Forms.Label();
            this.txtOutgoingBytes = new System.Windows.Forms.TextBox();
            this.txtIncomingBytes = new System.Windows.Forms.TextBox();
            this.lblOutgoingBytes = new System.Windows.Forms.Label();
            this.lblIncomingBytes = new System.Windows.Forms.Label();
            this.grbSlaveSettings = new System.Windows.Forms.GroupBox();
            this.cmbByteOrder = new System.Windows.Forms.ComboBox();
            this.lblByteOrder = new System.Windows.Forms.Label();
            this.cmbSlaveID = new System.Windows.Forms.ComboBox();
            this.lblSlaveID = new System.Windows.Forms.Label();
            this.grbSupportedFunctions = new System.Windows.Forms.GroupBox();
            this.chkSupportsFC23 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC16 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC15 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC08 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC06 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC05 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC04 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC03 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC02 = new System.Windows.Forms.CheckBox();
            this.chkSupportsFC01 = new System.Windows.Forms.CheckBox();
            this.btnRemoveListener = new System.Windows.Forms.Button();
            this.btnStopSlave = new System.Windows.Forms.Button();
            this.btnAddListener = new System.Windows.Forms.Button();
            this.lvListener = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParameter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.chkLogging = new System.Windows.Forms.CheckBox();
            this.lvLog = new System.Windows.Forms.ListView();
            this.colText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbLog = new System.Windows.Forms.GroupBox();
            this.lblLogLevel = new System.Windows.Forms.Label();
            this.cmbLogLevel = new System.Windows.Forms.ComboBox();
            this.grbDataStore = new System.Windows.Forms.GroupBox();
            this.grbValues = new System.Windows.Forms.GroupBox();
            this.rbValueOFF = new System.Windows.Forms.RadioButton();
            this.rbValueOn = new System.Windows.Forms.RadioButton();
            this.btnSetValue = new System.Windows.Forms.Button();
            this.chkBit27 = new System.Windows.Forms.CheckBox();
            this.chkBit26 = new System.Windows.Forms.CheckBox();
            this.chkBit25 = new System.Windows.Forms.CheckBox();
            this.chkBit24 = new System.Windows.Forms.CheckBox();
            this.chkBit28 = new System.Windows.Forms.CheckBox();
            this.chkBit29 = new System.Windows.Forms.CheckBox();
            this.chkBit30 = new System.Windows.Forms.CheckBox();
            this.chkBit31 = new System.Windows.Forms.CheckBox();
            this.chkBit19 = new System.Windows.Forms.CheckBox();
            this.chkBit18 = new System.Windows.Forms.CheckBox();
            this.chkBit17 = new System.Windows.Forms.CheckBox();
            this.chkBit16 = new System.Windows.Forms.CheckBox();
            this.chkBit20 = new System.Windows.Forms.CheckBox();
            this.chkBit21 = new System.Windows.Forms.CheckBox();
            this.chkBit22 = new System.Windows.Forms.CheckBox();
            this.chkBit23 = new System.Windows.Forms.CheckBox();
            this.chkBit11 = new System.Windows.Forms.CheckBox();
            this.chkBit10 = new System.Windows.Forms.CheckBox();
            this.chkBit9 = new System.Windows.Forms.CheckBox();
            this.chkBit8 = new System.Windows.Forms.CheckBox();
            this.chkBit12 = new System.Windows.Forms.CheckBox();
            this.chkBit13 = new System.Windows.Forms.CheckBox();
            this.chkBit14 = new System.Windows.Forms.CheckBox();
            this.chkBit15 = new System.Windows.Forms.CheckBox();
            this.chkBit3 = new System.Windows.Forms.CheckBox();
            this.chkBit2 = new System.Windows.Forms.CheckBox();
            this.chkBit1 = new System.Windows.Forms.CheckBox();
            this.chkBit0 = new System.Windows.Forms.CheckBox();
            this.chkBit4 = new System.Windows.Forms.CheckBox();
            this.chkBit5 = new System.Windows.Forms.CheckBox();
            this.chkBit6 = new System.Windows.Forms.CheckBox();
            this.chkBit7 = new System.Windows.Forms.CheckBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.grbAddressType = new System.Windows.Forms.GroupBox();
            this.rbRegisterTypeDiscreteInputs = new System.Windows.Forms.RadioButton();
            this.rbRegisterTypeCoils = new System.Windows.Forms.RadioButton();
            this.rbRegisterTypeInputRegister = new System.Windows.Forms.RadioButton();
            this.rbRegisterTypeHoldingRegister = new System.Windows.Forms.RadioButton();
            this.lvValues = new System.Windows.Forms.ListView();
            this.colDummy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.btnCopyLogtoFile = new System.Windows.Forms.Button();
            this.btnCertificateManager = new System.Windows.Forms.Button();
            this.btnCopyLogtoClipboard = new System.Windows.Forms.Button();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.grbSerial.SuspendLayout();
            this.grbListener.SuspendLayout();
            this.grbStatistics.SuspendLayout();
            this.grbSlaveSettings.SuspendLayout();
            this.grbSupportedFunctions.SuspendLayout();
            this.grbLog.SuspendLayout();
            this.grbDataStore.SuspendLayout();
            this.grbValues.SuspendLayout();
            this.grbAddressType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartSlave
            // 
            this.btnStartSlave.Image = ((System.Drawing.Image)(resources.GetObject("btnStartSlave.Image")));
            this.btnStartSlave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartSlave.Location = new System.Drawing.Point(8, 16);
            this.btnStartSlave.Name = "btnStartSlave";
            this.btnStartSlave.Size = new System.Drawing.Size(68, 68);
            this.btnStartSlave.TabIndex = 0;
            this.btnStartSlave.Text = "Start Slave";
            this.btnStartSlave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStartSlave.UseVisualStyleBackColor = true;
            this.btnStartSlave.Click += new System.EventHandler(this.btnStartSlave_Click);
            // 
            // lblRegisterMode
            // 
            this.lblRegisterMode.Location = new System.Drawing.Point(1, 18);
            this.lblRegisterMode.Name = "lblRegisterMode";
            this.lblRegisterMode.Size = new System.Drawing.Size(89, 13);
            this.lblRegisterMode.TabIndex = 74;
            this.lblRegisterMode.Text = "RegisterMode";
            // 
            // cmbRegisterMode
            // 
            this.cmbRegisterMode.FormattingEnabled = true;
            this.cmbRegisterMode.Location = new System.Drawing.Point(90, 15);
            this.cmbRegisterMode.Name = "cmbRegisterMode";
            this.cmbRegisterMode.Size = new System.Drawing.Size(60, 21);
            this.cmbRegisterMode.TabIndex = 73;
            // 
            // grbSerial
            // 
            this.grbSerial.Controls.Add(this.lblSerial);
            this.grbSerial.Controls.Add(this.lblUser);
            this.grbSerial.Controls.Add(this.txtSerial);
            this.grbSerial.Controls.Add(this.txtUser);
            this.grbSerial.Controls.Add(this.lblSerialCode);
            this.grbSerial.Location = new System.Drawing.Point(7, 12);
            this.grbSerial.Name = "grbSerial";
            this.grbSerial.Size = new System.Drawing.Size(710, 64);
            this.grbSerial.TabIndex = 76;
            this.grbSerial.TabStop = false;
            this.grbSerial.Text = "Serial";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(461, 43);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(34, 13);
            this.lblSerial.TabIndex = 12;
            this.lblSerial.Text = "serial:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(465, 20);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(30, 13);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "user:";
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSerial.Location = new System.Drawing.Point(503, 40);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(191, 20);
            this.txtSerial.TabIndex = 10;
            // 
            // txtUser
            // 
            this.txtUser.AcceptsReturn = true;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtUser.Location = new System.Drawing.Point(503, 17);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(190, 20);
            this.txtUser.TabIndex = 0;
            // 
            // lblSerialCode
            // 
            this.lblSerialCode.AutoSize = true;
            this.lblSerialCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSerialCode.Location = new System.Drawing.Point(9, 26);
            this.lblSerialCode.Name = "lblSerialCode";
            this.lblSerialCode.Size = new System.Drawing.Size(313, 16);
            this.lblSerialCode.TabIndex = 0;
            this.lblSerialCode.Text = "Enter user name and serial code first     >>>>";
            // 
            // grbListener
            // 
            this.grbListener.Controls.Add(this.grbStatistics);
            this.grbListener.Controls.Add(this.grbSlaveSettings);
            this.grbListener.Controls.Add(this.grbSupportedFunctions);
            this.grbListener.Controls.Add(this.btnStartSlave);
            this.grbListener.Controls.Add(this.btnRemoveListener);
            this.grbListener.Controls.Add(this.btnStopSlave);
            this.grbListener.Controls.Add(this.btnAddListener);
            this.grbListener.Controls.Add(this.lvListener);
            this.grbListener.Location = new System.Drawing.Point(7, 77);
            this.grbListener.Name = "grbListener";
            this.grbListener.Size = new System.Drawing.Size(710, 366);
            this.grbListener.TabIndex = 77;
            this.grbListener.TabStop = false;
            this.grbListener.Text = "Select Register mode and start slave";
            // 
            // grbStatistics
            // 
            this.grbStatistics.Controls.Add(this.txtUnparseableRequests);
            this.grbStatistics.Controls.Add(this.lblUnparseableRequests);
            this.grbStatistics.Controls.Add(this.txtIncorectRequests);
            this.grbStatistics.Controls.Add(this.txtIncomingRequests);
            this.grbStatistics.Controls.Add(this.lblIncorrectRequests);
            this.grbStatistics.Controls.Add(this.lblIncomingRequests);
            this.grbStatistics.Controls.Add(this.txtOutgoingBytes);
            this.grbStatistics.Controls.Add(this.txtIncomingBytes);
            this.grbStatistics.Controls.Add(this.lblOutgoingBytes);
            this.grbStatistics.Controls.Add(this.lblIncomingBytes);
            this.grbStatistics.Location = new System.Drawing.Point(458, 13);
            this.grbStatistics.Name = "grbStatistics";
            this.grbStatistics.Size = new System.Drawing.Size(246, 146);
            this.grbStatistics.TabIndex = 82;
            this.grbStatistics.TabStop = false;
            this.grbStatistics.Text = "statistics";
            // 
            // txtUnparseableRequests
            // 
            this.txtUnparseableRequests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnparseableRequests.Location = new System.Drawing.Point(160, 114);
            this.txtUnparseableRequests.Name = "txtUnparseableRequests";
            this.txtUnparseableRequests.ReadOnly = true;
            this.txtUnparseableRequests.Size = new System.Drawing.Size(74, 20);
            this.txtUnparseableRequests.TabIndex = 84;
            this.txtUnparseableRequests.Text = "?????";
            // 
            // lblUnparseableRequests
            // 
            this.lblUnparseableRequests.Location = new System.Drawing.Point(1, 116);
            this.lblUnparseableRequests.Name = "lblUnparseableRequests";
            this.lblUnparseableRequests.Size = new System.Drawing.Size(155, 13);
            this.lblUnparseableRequests.TabIndex = 83;
            this.lblUnparseableRequests.Text = "unparseable requests";
            this.lblUnparseableRequests.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtIncorectRequests
            // 
            this.txtIncorectRequests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIncorectRequests.Location = new System.Drawing.Point(160, 89);
            this.txtIncorectRequests.Name = "txtIncorectRequests";
            this.txtIncorectRequests.ReadOnly = true;
            this.txtIncorectRequests.Size = new System.Drawing.Size(74, 20);
            this.txtIncorectRequests.TabIndex = 82;
            this.txtIncorectRequests.Text = "?????";
            // 
            // txtIncomingRequests
            // 
            this.txtIncomingRequests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIncomingRequests.Location = new System.Drawing.Point(160, 63);
            this.txtIncomingRequests.Name = "txtIncomingRequests";
            this.txtIncomingRequests.ReadOnly = true;
            this.txtIncomingRequests.Size = new System.Drawing.Size(74, 20);
            this.txtIncomingRequests.TabIndex = 81;
            this.txtIncomingRequests.Text = "?????";
            // 
            // lblIncorrectRequests
            // 
            this.lblIncorrectRequests.Location = new System.Drawing.Point(1, 91);
            this.lblIncorrectRequests.Name = "lblIncorrectRequests";
            this.lblIncorrectRequests.Size = new System.Drawing.Size(155, 13);
            this.lblIncorrectRequests.TabIndex = 80;
            this.lblIncorrectRequests.Text = "incorrect requests";
            this.lblIncorrectRequests.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIncomingRequests
            // 
            this.lblIncomingRequests.Location = new System.Drawing.Point(2, 65);
            this.lblIncomingRequests.Name = "lblIncomingRequests";
            this.lblIncomingRequests.Size = new System.Drawing.Size(155, 13);
            this.lblIncomingRequests.TabIndex = 79;
            this.lblIncomingRequests.Text = "incoming requests";
            this.lblIncomingRequests.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtOutgoingBytes
            // 
            this.txtOutgoingBytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutgoingBytes.Location = new System.Drawing.Point(159, 38);
            this.txtOutgoingBytes.Name = "txtOutgoingBytes";
            this.txtOutgoingBytes.ReadOnly = true;
            this.txtOutgoingBytes.Size = new System.Drawing.Size(74, 20);
            this.txtOutgoingBytes.TabIndex = 78;
            this.txtOutgoingBytes.Text = "?????";
            // 
            // txtIncomingBytes
            // 
            this.txtIncomingBytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIncomingBytes.Location = new System.Drawing.Point(159, 12);
            this.txtIncomingBytes.Name = "txtIncomingBytes";
            this.txtIncomingBytes.ReadOnly = true;
            this.txtIncomingBytes.Size = new System.Drawing.Size(74, 20);
            this.txtIncomingBytes.TabIndex = 77;
            this.txtIncomingBytes.Text = "?????";
            // 
            // lblOutgoingBytes
            // 
            this.lblOutgoingBytes.Location = new System.Drawing.Point(2, 40);
            this.lblOutgoingBytes.Name = "lblOutgoingBytes";
            this.lblOutgoingBytes.Size = new System.Drawing.Size(155, 13);
            this.lblOutgoingBytes.TabIndex = 76;
            this.lblOutgoingBytes.Text = "outgoing bytes";
            this.lblOutgoingBytes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblIncomingBytes
            // 
            this.lblIncomingBytes.Location = new System.Drawing.Point(1, 14);
            this.lblIncomingBytes.Name = "lblIncomingBytes";
            this.lblIncomingBytes.Size = new System.Drawing.Size(150, 13);
            this.lblIncomingBytes.TabIndex = 75;
            this.lblIncomingBytes.Text = "incoming bytes";
            this.lblIncomingBytes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grbSlaveSettings
            // 
            this.grbSlaveSettings.Controls.Add(this.cmbByteOrder);
            this.grbSlaveSettings.Controls.Add(this.lblByteOrder);
            this.grbSlaveSettings.Controls.Add(this.cmbRegisterMode);
            this.grbSlaveSettings.Controls.Add(this.lblRegisterMode);
            this.grbSlaveSettings.Controls.Add(this.cmbSlaveID);
            this.grbSlaveSettings.Controls.Add(this.lblSlaveID);
            this.grbSlaveSettings.Location = new System.Drawing.Point(172, 13);
            this.grbSlaveSettings.Name = "grbSlaveSettings";
            this.grbSlaveSettings.Size = new System.Drawing.Size(279, 73);
            this.grbSlaveSettings.TabIndex = 81;
            this.grbSlaveSettings.TabStop = false;
            this.grbSlaveSettings.Text = "Slave settings";
            // 
            // cmbByteOrder
            // 
            this.cmbByteOrder.FormattingEnabled = true;
            this.cmbByteOrder.Location = new System.Drawing.Point(90, 43);
            this.cmbByteOrder.Name = "cmbByteOrder";
            this.cmbByteOrder.Size = new System.Drawing.Size(183, 21);
            this.cmbByteOrder.TabIndex = 81;
            // 
            // lblByteOrder
            // 
            this.lblByteOrder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblByteOrder.Location = new System.Drawing.Point(1, 46);
            this.lblByteOrder.Name = "lblByteOrder";
            this.lblByteOrder.Size = new System.Drawing.Size(89, 13);
            this.lblByteOrder.TabIndex = 80;
            this.lblByteOrder.Text = "number encoding";
            // 
            // cmbSlaveID
            // 
            this.cmbSlaveID.FormattingEnabled = true;
            this.cmbSlaveID.Location = new System.Drawing.Point(214, 15);
            this.cmbSlaveID.Name = "cmbSlaveID";
            this.cmbSlaveID.Size = new System.Drawing.Size(60, 21);
            this.cmbSlaveID.TabIndex = 78;
            // 
            // lblSlaveID
            // 
            this.lblSlaveID.Location = new System.Drawing.Point(156, 18);
            this.lblSlaveID.Name = "lblSlaveID";
            this.lblSlaveID.Size = new System.Drawing.Size(59, 13);
            this.lblSlaveID.TabIndex = 79;
            this.lblSlaveID.Text = "Slave ID";
            this.lblSlaveID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grbSupportedFunctions
            // 
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC23);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC16);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC15);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC08);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC06);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC05);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC04);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC03);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC02);
            this.grbSupportedFunctions.Controls.Add(this.chkSupportsFC01);
            this.grbSupportedFunctions.Enabled = false;
            this.grbSupportedFunctions.Location = new System.Drawing.Point(172, 85);
            this.grbSupportedFunctions.Name = "grbSupportedFunctions";
            this.grbSupportedFunctions.Size = new System.Drawing.Size(279, 75);
            this.grbSupportedFunctions.TabIndex = 80;
            this.grbSupportedFunctions.TabStop = false;
            this.grbSupportedFunctions.Text = "Supported modbus functions";
            // 
            // chkSupportsFC23
            // 
            this.chkSupportsFC23.AutoSize = true;
            this.chkSupportsFC23.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC23.Checked = true;
            this.chkSupportsFC23.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC23.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC23.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC23.Location = new System.Drawing.Point(241, 41);
            this.chkSupportsFC23.Name = "chkSupportsFC23";
            this.chkSupportsFC23.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC23.TabIndex = 99;
            this.chkSupportsFC23.Text = "FC23";
            this.chkSupportsFC23.UseVisualStyleBackColor = true;
            this.chkSupportsFC23.CheckedChanged += new System.EventHandler(this.chkFC23_CheckedChanged);
            // 
            // chkSupportsFC16
            // 
            this.chkSupportsFC16.AutoSize = true;
            this.chkSupportsFC16.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC16.Checked = true;
            this.chkSupportsFC16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC16.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC16.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC16.Location = new System.Drawing.Point(187, 41);
            this.chkSupportsFC16.Name = "chkSupportsFC16";
            this.chkSupportsFC16.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC16.TabIndex = 98;
            this.chkSupportsFC16.Text = "FC16";
            this.chkSupportsFC16.UseVisualStyleBackColor = true;
            this.chkSupportsFC16.CheckedChanged += new System.EventHandler(this.chkFC16_CheckedChanged);
            // 
            // chkSupportsFC15
            // 
            this.chkSupportsFC15.AutoSize = true;
            this.chkSupportsFC15.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC15.Checked = true;
            this.chkSupportsFC15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC15.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC15.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC15.Location = new System.Drawing.Point(125, 41);
            this.chkSupportsFC15.Name = "chkSupportsFC15";
            this.chkSupportsFC15.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC15.TabIndex = 97;
            this.chkSupportsFC15.Text = "FC15";
            this.chkSupportsFC15.UseVisualStyleBackColor = true;
            this.chkSupportsFC15.CheckedChanged += new System.EventHandler(this.chkFC15_CheckedChanged);
            // 
            // chkSupportsFC08
            // 
            this.chkSupportsFC08.AutoSize = true;
            this.chkSupportsFC08.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC08.Checked = true;
            this.chkSupportsFC08.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC08.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC08.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC08.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC08.Location = new System.Drawing.Point(58, 41);
            this.chkSupportsFC08.Name = "chkSupportsFC08";
            this.chkSupportsFC08.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC08.TabIndex = 96;
            this.chkSupportsFC08.Text = "FC08";
            this.chkSupportsFC08.UseVisualStyleBackColor = true;
            this.chkSupportsFC08.CheckedChanged += new System.EventHandler(this.chkFC08_CheckedChanged);
            // 
            // chkSupportsFC06
            // 
            this.chkSupportsFC06.AutoSize = true;
            this.chkSupportsFC06.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC06.Checked = true;
            this.chkSupportsFC06.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC06.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC06.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC06.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC06.Location = new System.Drawing.Point(2, 41);
            this.chkSupportsFC06.Name = "chkSupportsFC06";
            this.chkSupportsFC06.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC06.TabIndex = 95;
            this.chkSupportsFC06.Text = "FC06";
            this.chkSupportsFC06.UseVisualStyleBackColor = true;
            this.chkSupportsFC06.CheckedChanged += new System.EventHandler(this.chkFC06_CheckedChanged);
            // 
            // chkSupportsFC05
            // 
            this.chkSupportsFC05.AutoSize = true;
            this.chkSupportsFC05.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC05.Checked = true;
            this.chkSupportsFC05.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC05.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC05.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC05.Location = new System.Drawing.Point(241, 16);
            this.chkSupportsFC05.Name = "chkSupportsFC05";
            this.chkSupportsFC05.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC05.TabIndex = 94;
            this.chkSupportsFC05.Text = "FC05";
            this.chkSupportsFC05.UseVisualStyleBackColor = true;
            this.chkSupportsFC05.CheckedChanged += new System.EventHandler(this.chkFC05_CheckedChanged);
            // 
            // chkSupportsFC04
            // 
            this.chkSupportsFC04.AutoSize = true;
            this.chkSupportsFC04.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC04.Checked = true;
            this.chkSupportsFC04.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC04.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC04.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC04.Location = new System.Drawing.Point(187, 16);
            this.chkSupportsFC04.Name = "chkSupportsFC04";
            this.chkSupportsFC04.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC04.TabIndex = 93;
            this.chkSupportsFC04.Text = "FC04";
            this.chkSupportsFC04.UseVisualStyleBackColor = true;
            this.chkSupportsFC04.CheckedChanged += new System.EventHandler(this.chkFC04_CheckedChanged);
            // 
            // chkSupportsFC03
            // 
            this.chkSupportsFC03.AutoSize = true;
            this.chkSupportsFC03.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC03.Checked = true;
            this.chkSupportsFC03.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC03.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC03.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC03.Location = new System.Drawing.Point(125, 16);
            this.chkSupportsFC03.Name = "chkSupportsFC03";
            this.chkSupportsFC03.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC03.TabIndex = 92;
            this.chkSupportsFC03.Text = "FC03";
            this.chkSupportsFC03.UseVisualStyleBackColor = true;
            this.chkSupportsFC03.CheckedChanged += new System.EventHandler(this.chkFC03_CheckedChanged);
            // 
            // chkSupportsFC02
            // 
            this.chkSupportsFC02.AutoSize = true;
            this.chkSupportsFC02.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC02.Checked = true;
            this.chkSupportsFC02.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC02.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC02.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC02.Location = new System.Drawing.Point(58, 16);
            this.chkSupportsFC02.Name = "chkSupportsFC02";
            this.chkSupportsFC02.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC02.TabIndex = 91;
            this.chkSupportsFC02.Text = "FC02";
            this.chkSupportsFC02.UseVisualStyleBackColor = true;
            this.chkSupportsFC02.CheckedChanged += new System.EventHandler(this.chkFC02_CheckedChanged);
            // 
            // chkSupportsFC01
            // 
            this.chkSupportsFC01.AutoSize = true;
            this.chkSupportsFC01.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSupportsFC01.Checked = true;
            this.chkSupportsFC01.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSupportsFC01.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkSupportsFC01.FlatAppearance.BorderSize = 2;
            this.chkSupportsFC01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSupportsFC01.Location = new System.Drawing.Point(2, 16);
            this.chkSupportsFC01.Name = "chkSupportsFC01";
            this.chkSupportsFC01.Size = new System.Drawing.Size(36, 28);
            this.chkSupportsFC01.TabIndex = 90;
            this.chkSupportsFC01.Text = "FC01";
            this.chkSupportsFC01.UseVisualStyleBackColor = true;
            this.chkSupportsFC01.CheckedChanged += new System.EventHandler(this.chkFC01_CheckedChanged);
            // 
            // btnRemoveListener
            // 
            this.btnRemoveListener.Enabled = false;
            this.btnRemoveListener.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveListener.Image")));
            this.btnRemoveListener.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveListener.Location = new System.Drawing.Point(87, 92);
            this.btnRemoveListener.Name = "btnRemoveListener";
            this.btnRemoveListener.Size = new System.Drawing.Size(68, 68);
            this.btnRemoveListener.TabIndex = 3;
            this.btnRemoveListener.Text = "remove listener";
            this.btnRemoveListener.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveListener.UseVisualStyleBackColor = true;
            this.btnRemoveListener.Click += new System.EventHandler(this.btnRemoveListener_Click);
            // 
            // btnStopSlave
            // 
            this.btnStopSlave.Enabled = false;
            this.btnStopSlave.Image = ((System.Drawing.Image)(resources.GetObject("btnStopSlave.Image")));
            this.btnStopSlave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStopSlave.Location = new System.Drawing.Point(87, 16);
            this.btnStopSlave.Name = "btnStopSlave";
            this.btnStopSlave.Size = new System.Drawing.Size(68, 68);
            this.btnStopSlave.TabIndex = 75;
            this.btnStopSlave.Text = "Stop Slave";
            this.btnStopSlave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStopSlave.UseVisualStyleBackColor = true;
            this.btnStopSlave.Click += new System.EventHandler(this.btnStopSlave_Click);
            // 
            // btnAddListener
            // 
            this.btnAddListener.Enabled = false;
            this.btnAddListener.Image = ((System.Drawing.Image)(resources.GetObject("btnAddListener.Image")));
            this.btnAddListener.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddListener.Location = new System.Drawing.Point(8, 92);
            this.btnAddListener.Name = "btnAddListener";
            this.btnAddListener.Size = new System.Drawing.Size(68, 68);
            this.btnAddListener.TabIndex = 2;
            this.btnAddListener.Text = "add listener";
            this.btnAddListener.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddListener.UseVisualStyleBackColor = true;
            this.btnAddListener.Click += new System.EventHandler(this.btnAddListener_Click);
            // 
            // lvListener
            // 
            this.lvListener.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvListener.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colParameter});
            this.lvListener.FullRowSelect = true;
            this.lvListener.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvListener.HideSelection = false;
            this.lvListener.Location = new System.Drawing.Point(8, 165);
            this.lvListener.MultiSelect = false;
            this.lvListener.Name = "lvListener";
            this.lvListener.Size = new System.Drawing.Size(685, 192);
            this.lvListener.TabIndex = 0;
            this.lvListener.UseCompatibleStateImageBehavior = false;
            this.lvListener.View = System.Windows.Forms.View.Details;
            this.lvListener.SelectedIndexChanged += new System.EventHandler(this.lvListener_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Listener Name";
            this.colName.Width = 85;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 43;
            // 
            // colParameter
            // 
            this.colParameter.Text = "Parameter";
            this.colParameter.Width = 530;
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Checked = true;
            this.chkAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScroll.Location = new System.Drawing.Point(420, 746);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(71, 17);
            this.chkAutoScroll.TabIndex = 80;
            this.chkAutoScroll.Text = "AutoScoll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // chkLogging
            // 
            this.chkLogging.AutoSize = true;
            this.chkLogging.Checked = true;
            this.chkLogging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogging.Location = new System.Drawing.Point(420, 723);
            this.chkLogging.Name = "chkLogging";
            this.chkLogging.Size = new System.Drawing.Size(109, 17);
            this.chkLogging.TabIndex = 79;
            this.chkLogging.Text = "Diagnostic output";
            this.chkLogging.UseVisualStyleBackColor = true;
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colText});
            this.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLog.HideSelection = false;
            this.lvLog.Location = new System.Drawing.Point(11, 17);
            this.lvLog.MultiSelect = false;
            this.lvLog.Name = "lvLog";
            this.lvLog.ShowGroups = false;
            this.lvLog.Size = new System.Drawing.Size(1041, 246);
            this.lvLog.TabIndex = 78;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // colText
            // 
            this.colText.Text = "Text";
            this.colText.Width = 6000;
            // 
            // grbLog
            // 
            this.grbLog.Controls.Add(this.lvLog);
            this.grbLog.Location = new System.Drawing.Point(7, 449);
            this.grbLog.Name = "grbLog";
            this.grbLog.Size = new System.Drawing.Size(1066, 269);
            this.grbLog.TabIndex = 79;
            this.grbLog.TabStop = false;
            this.grbLog.Text = "Log";
            // 
            // lblLogLevel
            // 
            this.lblLogLevel.AutoSize = true;
            this.lblLogLevel.Location = new System.Drawing.Point(253, 727);
            this.lblLogLevel.Name = "lblLogLevel";
            this.lblLogLevel.Size = new System.Drawing.Size(51, 13);
            this.lblLogLevel.TabIndex = 82;
            this.lblLogLevel.Text = "LogLevel";
            // 
            // cmbLogLevel
            // 
            this.cmbLogLevel.FormattingEnabled = true;
            this.cmbLogLevel.Location = new System.Drawing.Point(310, 724);
            this.cmbLogLevel.Name = "cmbLogLevel";
            this.cmbLogLevel.Size = new System.Drawing.Size(91, 21);
            this.cmbLogLevel.TabIndex = 81;
            // 
            // grbDataStore
            // 
            this.grbDataStore.Controls.Add(this.grbValues);
            this.grbDataStore.Controls.Add(this.grbAddressType);
            this.grbDataStore.Controls.Add(this.lvValues);
            this.grbDataStore.Enabled = false;
            this.grbDataStore.Location = new System.Drawing.Point(726, 12);
            this.grbDataStore.Name = "grbDataStore";
            this.grbDataStore.Size = new System.Drawing.Size(347, 431);
            this.grbDataStore.TabIndex = 80;
            this.grbDataStore.TabStop = false;
            this.grbDataStore.Text = "DataStore";
            // 
            // grbValues
            // 
            this.grbValues.Controls.Add(this.rbValueOFF);
            this.grbValues.Controls.Add(this.rbValueOn);
            this.grbValues.Controls.Add(this.btnSetValue);
            this.grbValues.Controls.Add(this.chkBit27);
            this.grbValues.Controls.Add(this.chkBit26);
            this.grbValues.Controls.Add(this.chkBit25);
            this.grbValues.Controls.Add(this.chkBit24);
            this.grbValues.Controls.Add(this.chkBit28);
            this.grbValues.Controls.Add(this.chkBit29);
            this.grbValues.Controls.Add(this.chkBit30);
            this.grbValues.Controls.Add(this.chkBit31);
            this.grbValues.Controls.Add(this.chkBit19);
            this.grbValues.Controls.Add(this.chkBit18);
            this.grbValues.Controls.Add(this.chkBit17);
            this.grbValues.Controls.Add(this.chkBit16);
            this.grbValues.Controls.Add(this.chkBit20);
            this.grbValues.Controls.Add(this.chkBit21);
            this.grbValues.Controls.Add(this.chkBit22);
            this.grbValues.Controls.Add(this.chkBit23);
            this.grbValues.Controls.Add(this.chkBit11);
            this.grbValues.Controls.Add(this.chkBit10);
            this.grbValues.Controls.Add(this.chkBit9);
            this.grbValues.Controls.Add(this.chkBit8);
            this.grbValues.Controls.Add(this.chkBit12);
            this.grbValues.Controls.Add(this.chkBit13);
            this.grbValues.Controls.Add(this.chkBit14);
            this.grbValues.Controls.Add(this.chkBit15);
            this.grbValues.Controls.Add(this.chkBit3);
            this.grbValues.Controls.Add(this.chkBit2);
            this.grbValues.Controls.Add(this.chkBit1);
            this.grbValues.Controls.Add(this.chkBit0);
            this.grbValues.Controls.Add(this.chkBit4);
            this.grbValues.Controls.Add(this.chkBit5);
            this.grbValues.Controls.Add(this.chkBit6);
            this.grbValues.Controls.Add(this.chkBit7);
            this.grbValues.Controls.Add(this.txtValue);
            this.grbValues.Controls.Add(this.txtAddress);
            this.grbValues.Controls.Add(this.lblValue);
            this.grbValues.Controls.Add(this.lblAddress);
            this.grbValues.Location = new System.Drawing.Point(9, 65);
            this.grbValues.Name = "grbValues";
            this.grbValues.Size = new System.Drawing.Size(330, 159);
            this.grbValues.TabIndex = 2;
            this.grbValues.TabStop = false;
            this.grbValues.Text = "set new value";
            // 
            // rbValueOFF
            // 
            this.rbValueOFF.AutoSize = true;
            this.rbValueOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbValueOFF.Location = new System.Drawing.Point(154, 62);
            this.rbValueOFF.Name = "rbValueOFF";
            this.rbValueOFF.Size = new System.Drawing.Size(46, 17);
            this.rbValueOFF.TabIndex = 46;
            this.rbValueOFF.Text = "false";
            this.rbValueOFF.UseVisualStyleBackColor = true;
            // 
            // rbValueOn
            // 
            this.rbValueOn.AutoSize = true;
            this.rbValueOn.Checked = true;
            this.rbValueOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbValueOn.Location = new System.Drawing.Point(99, 61);
            this.rbValueOn.Name = "rbValueOn";
            this.rbValueOn.Size = new System.Drawing.Size(42, 17);
            this.rbValueOn.TabIndex = 45;
            this.rbValueOn.TabStop = true;
            this.rbValueOn.Text = "true";
            this.rbValueOn.UseVisualStyleBackColor = true;
            // 
            // btnSetValue
            // 
            this.btnSetValue.Enabled = false;
            this.btnSetValue.Image = ((System.Drawing.Image)(resources.GetObject("btnSetValue.Image")));
            this.btnSetValue.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetValue.Location = new System.Drawing.Point(256, 13);
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(68, 68);
            this.btnSetValue.TabIndex = 36;
            this.btnSetValue.Text = "set value";
            this.btnSetValue.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSetValue.UseVisualStyleBackColor = true;
            this.btnSetValue.Click += new System.EventHandler(this.btnSetValue_Click);
            // 
            // chkBit27
            // 
            this.chkBit27.AutoSize = true;
            this.chkBit27.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit27.Enabled = false;
            this.chkBit27.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit27.FlatAppearance.BorderSize = 2;
            this.chkBit27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit27.Location = new System.Drawing.Point(80, 117);
            this.chkBit27.Name = "chkBit27";
            this.chkBit27.Size = new System.Drawing.Size(23, 28);
            this.chkBit27.TabIndex = 35;
            this.chkBit27.Text = "27";
            this.chkBit27.UseVisualStyleBackColor = true;
            this.chkBit27.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit26
            // 
            this.chkBit26.AutoSize = true;
            this.chkBit26.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit26.Enabled = false;
            this.chkBit26.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit26.FlatAppearance.BorderSize = 2;
            this.chkBit26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit26.Location = new System.Drawing.Point(100, 117);
            this.chkBit26.Name = "chkBit26";
            this.chkBit26.Size = new System.Drawing.Size(23, 28);
            this.chkBit26.TabIndex = 34;
            this.chkBit26.Text = "26";
            this.chkBit26.UseVisualStyleBackColor = true;
            this.chkBit26.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit25
            // 
            this.chkBit25.AutoSize = true;
            this.chkBit25.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit25.Enabled = false;
            this.chkBit25.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit25.FlatAppearance.BorderSize = 2;
            this.chkBit25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit25.Location = new System.Drawing.Point(119, 117);
            this.chkBit25.Name = "chkBit25";
            this.chkBit25.Size = new System.Drawing.Size(23, 28);
            this.chkBit25.TabIndex = 33;
            this.chkBit25.Text = "25";
            this.chkBit25.UseVisualStyleBackColor = true;
            this.chkBit25.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit24
            // 
            this.chkBit24.AutoSize = true;
            this.chkBit24.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit24.Enabled = false;
            this.chkBit24.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit24.FlatAppearance.BorderSize = 2;
            this.chkBit24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit24.Location = new System.Drawing.Point(140, 117);
            this.chkBit24.Name = "chkBit24";
            this.chkBit24.Size = new System.Drawing.Size(23, 28);
            this.chkBit24.TabIndex = 32;
            this.chkBit24.Text = "24";
            this.chkBit24.UseVisualStyleBackColor = true;
            this.chkBit24.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit28
            // 
            this.chkBit28.AutoSize = true;
            this.chkBit28.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit28.Enabled = false;
            this.chkBit28.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit28.FlatAppearance.BorderSize = 2;
            this.chkBit28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit28.Location = new System.Drawing.Point(61, 117);
            this.chkBit28.Name = "chkBit28";
            this.chkBit28.Size = new System.Drawing.Size(23, 28);
            this.chkBit28.TabIndex = 31;
            this.chkBit28.Text = "28";
            this.chkBit28.UseVisualStyleBackColor = true;
            this.chkBit28.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit29
            // 
            this.chkBit29.AutoSize = true;
            this.chkBit29.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit29.Enabled = false;
            this.chkBit29.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit29.FlatAppearance.BorderSize = 2;
            this.chkBit29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit29.Location = new System.Drawing.Point(41, 117);
            this.chkBit29.Name = "chkBit29";
            this.chkBit29.Size = new System.Drawing.Size(23, 28);
            this.chkBit29.TabIndex = 30;
            this.chkBit29.Text = "29";
            this.chkBit29.UseVisualStyleBackColor = true;
            this.chkBit29.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit30
            // 
            this.chkBit30.AutoSize = true;
            this.chkBit30.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit30.Enabled = false;
            this.chkBit30.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit30.FlatAppearance.BorderSize = 2;
            this.chkBit30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit30.Location = new System.Drawing.Point(21, 117);
            this.chkBit30.Name = "chkBit30";
            this.chkBit30.Size = new System.Drawing.Size(23, 28);
            this.chkBit30.TabIndex = 29;
            this.chkBit30.Text = "30";
            this.chkBit30.UseVisualStyleBackColor = true;
            this.chkBit30.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit31
            // 
            this.chkBit31.AutoSize = true;
            this.chkBit31.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit31.Enabled = false;
            this.chkBit31.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit31.FlatAppearance.BorderSize = 2;
            this.chkBit31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit31.Location = new System.Drawing.Point(2, 117);
            this.chkBit31.Name = "chkBit31";
            this.chkBit31.Size = new System.Drawing.Size(23, 28);
            this.chkBit31.TabIndex = 28;
            this.chkBit31.Text = "31";
            this.chkBit31.UseVisualStyleBackColor = true;
            this.chkBit31.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit19
            // 
            this.chkBit19.AutoSize = true;
            this.chkBit19.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit19.Enabled = false;
            this.chkBit19.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit19.FlatAppearance.BorderSize = 2;
            this.chkBit19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit19.Location = new System.Drawing.Point(243, 117);
            this.chkBit19.Name = "chkBit19";
            this.chkBit19.Size = new System.Drawing.Size(23, 28);
            this.chkBit19.TabIndex = 27;
            this.chkBit19.Text = "19";
            this.chkBit19.UseVisualStyleBackColor = true;
            this.chkBit19.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit18
            // 
            this.chkBit18.AutoSize = true;
            this.chkBit18.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit18.Enabled = false;
            this.chkBit18.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit18.FlatAppearance.BorderSize = 2;
            this.chkBit18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit18.Location = new System.Drawing.Point(264, 117);
            this.chkBit18.Name = "chkBit18";
            this.chkBit18.Size = new System.Drawing.Size(23, 28);
            this.chkBit18.TabIndex = 26;
            this.chkBit18.Text = "18";
            this.chkBit18.UseVisualStyleBackColor = true;
            this.chkBit18.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit17
            // 
            this.chkBit17.AutoSize = true;
            this.chkBit17.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit17.Enabled = false;
            this.chkBit17.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit17.FlatAppearance.BorderSize = 2;
            this.chkBit17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit17.Location = new System.Drawing.Point(284, 117);
            this.chkBit17.Name = "chkBit17";
            this.chkBit17.Size = new System.Drawing.Size(23, 28);
            this.chkBit17.TabIndex = 25;
            this.chkBit17.Text = "17";
            this.chkBit17.UseVisualStyleBackColor = true;
            this.chkBit17.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit16
            // 
            this.chkBit16.AutoSize = true;
            this.chkBit16.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit16.Enabled = false;
            this.chkBit16.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit16.FlatAppearance.BorderSize = 2;
            this.chkBit16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit16.Location = new System.Drawing.Point(305, 117);
            this.chkBit16.Name = "chkBit16";
            this.chkBit16.Size = new System.Drawing.Size(23, 28);
            this.chkBit16.TabIndex = 24;
            this.chkBit16.Text = "16";
            this.chkBit16.UseVisualStyleBackColor = true;
            this.chkBit16.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit20
            // 
            this.chkBit20.AutoSize = true;
            this.chkBit20.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit20.Enabled = false;
            this.chkBit20.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit20.FlatAppearance.BorderSize = 2;
            this.chkBit20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit20.Location = new System.Drawing.Point(222, 117);
            this.chkBit20.Name = "chkBit20";
            this.chkBit20.Size = new System.Drawing.Size(23, 28);
            this.chkBit20.TabIndex = 23;
            this.chkBit20.Text = "20";
            this.chkBit20.UseVisualStyleBackColor = true;
            this.chkBit20.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit21
            // 
            this.chkBit21.AutoSize = true;
            this.chkBit21.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit21.Enabled = false;
            this.chkBit21.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit21.FlatAppearance.BorderSize = 2;
            this.chkBit21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit21.Location = new System.Drawing.Point(200, 117);
            this.chkBit21.Name = "chkBit21";
            this.chkBit21.Size = new System.Drawing.Size(23, 28);
            this.chkBit21.TabIndex = 22;
            this.chkBit21.Text = "21";
            this.chkBit21.UseVisualStyleBackColor = true;
            this.chkBit21.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit22
            // 
            this.chkBit22.AutoSize = true;
            this.chkBit22.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit22.Enabled = false;
            this.chkBit22.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit22.FlatAppearance.BorderSize = 2;
            this.chkBit22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit22.Location = new System.Drawing.Point(179, 117);
            this.chkBit22.Name = "chkBit22";
            this.chkBit22.Size = new System.Drawing.Size(23, 28);
            this.chkBit22.TabIndex = 21;
            this.chkBit22.Text = "22";
            this.chkBit22.UseVisualStyleBackColor = true;
            this.chkBit22.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit23
            // 
            this.chkBit23.AutoSize = true;
            this.chkBit23.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit23.Enabled = false;
            this.chkBit23.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit23.FlatAppearance.BorderSize = 2;
            this.chkBit23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit23.Location = new System.Drawing.Point(161, 117);
            this.chkBit23.Name = "chkBit23";
            this.chkBit23.Size = new System.Drawing.Size(23, 28);
            this.chkBit23.TabIndex = 20;
            this.chkBit23.Text = "23";
            this.chkBit23.UseVisualStyleBackColor = true;
            this.chkBit23.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit11
            // 
            this.chkBit11.AutoSize = true;
            this.chkBit11.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit11.Enabled = false;
            this.chkBit11.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit11.FlatAppearance.BorderSize = 2;
            this.chkBit11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit11.Location = new System.Drawing.Point(80, 92);
            this.chkBit11.Name = "chkBit11";
            this.chkBit11.Size = new System.Drawing.Size(23, 28);
            this.chkBit11.TabIndex = 19;
            this.chkBit11.Text = "11";
            this.chkBit11.UseVisualStyleBackColor = true;
            this.chkBit11.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit10
            // 
            this.chkBit10.AutoSize = true;
            this.chkBit10.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit10.Enabled = false;
            this.chkBit10.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit10.FlatAppearance.BorderSize = 2;
            this.chkBit10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit10.Location = new System.Drawing.Point(100, 92);
            this.chkBit10.Name = "chkBit10";
            this.chkBit10.Size = new System.Drawing.Size(23, 28);
            this.chkBit10.TabIndex = 18;
            this.chkBit10.Text = "10";
            this.chkBit10.UseVisualStyleBackColor = true;
            this.chkBit10.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit9
            // 
            this.chkBit9.AutoSize = true;
            this.chkBit9.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit9.Enabled = false;
            this.chkBit9.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit9.FlatAppearance.BorderSize = 2;
            this.chkBit9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit9.Location = new System.Drawing.Point(122, 92);
            this.chkBit9.Name = "chkBit9";
            this.chkBit9.Size = new System.Drawing.Size(17, 28);
            this.chkBit9.TabIndex = 17;
            this.chkBit9.Text = "9";
            this.chkBit9.UseVisualStyleBackColor = true;
            this.chkBit9.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit8
            // 
            this.chkBit8.AutoSize = true;
            this.chkBit8.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit8.Enabled = false;
            this.chkBit8.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit8.FlatAppearance.BorderSize = 2;
            this.chkBit8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit8.Location = new System.Drawing.Point(143, 92);
            this.chkBit8.Name = "chkBit8";
            this.chkBit8.Size = new System.Drawing.Size(17, 28);
            this.chkBit8.TabIndex = 16;
            this.chkBit8.Text = "8";
            this.chkBit8.UseVisualStyleBackColor = true;
            this.chkBit8.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit12
            // 
            this.chkBit12.AutoSize = true;
            this.chkBit12.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit12.Enabled = false;
            this.chkBit12.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit12.FlatAppearance.BorderSize = 2;
            this.chkBit12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit12.Location = new System.Drawing.Point(61, 92);
            this.chkBit12.Name = "chkBit12";
            this.chkBit12.Size = new System.Drawing.Size(23, 28);
            this.chkBit12.TabIndex = 15;
            this.chkBit12.Text = "12";
            this.chkBit12.UseVisualStyleBackColor = true;
            this.chkBit12.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit13
            // 
            this.chkBit13.AutoSize = true;
            this.chkBit13.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit13.Enabled = false;
            this.chkBit13.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit13.FlatAppearance.BorderSize = 2;
            this.chkBit13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit13.Location = new System.Drawing.Point(41, 92);
            this.chkBit13.Name = "chkBit13";
            this.chkBit13.Size = new System.Drawing.Size(23, 28);
            this.chkBit13.TabIndex = 14;
            this.chkBit13.Text = "13";
            this.chkBit13.UseVisualStyleBackColor = true;
            this.chkBit13.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit14
            // 
            this.chkBit14.AutoSize = true;
            this.chkBit14.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit14.Enabled = false;
            this.chkBit14.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit14.FlatAppearance.BorderSize = 2;
            this.chkBit14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit14.Location = new System.Drawing.Point(21, 92);
            this.chkBit14.Name = "chkBit14";
            this.chkBit14.Size = new System.Drawing.Size(23, 28);
            this.chkBit14.TabIndex = 13;
            this.chkBit14.Text = "14";
            this.chkBit14.UseVisualStyleBackColor = true;
            this.chkBit14.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit15
            // 
            this.chkBit15.AutoSize = true;
            this.chkBit15.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit15.Enabled = false;
            this.chkBit15.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit15.FlatAppearance.BorderSize = 2;
            this.chkBit15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit15.Location = new System.Drawing.Point(2, 92);
            this.chkBit15.Name = "chkBit15";
            this.chkBit15.Size = new System.Drawing.Size(23, 28);
            this.chkBit15.TabIndex = 12;
            this.chkBit15.Text = "15";
            this.chkBit15.UseVisualStyleBackColor = true;
            this.chkBit15.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit3
            // 
            this.chkBit3.AutoSize = true;
            this.chkBit3.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit3.Enabled = false;
            this.chkBit3.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit3.FlatAppearance.BorderSize = 2;
            this.chkBit3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit3.Location = new System.Drawing.Point(245, 92);
            this.chkBit3.Name = "chkBit3";
            this.chkBit3.Size = new System.Drawing.Size(17, 28);
            this.chkBit3.TabIndex = 11;
            this.chkBit3.Text = "3";
            this.chkBit3.UseVisualStyleBackColor = true;
            this.chkBit3.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit2
            // 
            this.chkBit2.AutoSize = true;
            this.chkBit2.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit2.Enabled = false;
            this.chkBit2.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit2.FlatAppearance.BorderSize = 2;
            this.chkBit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit2.Location = new System.Drawing.Point(266, 92);
            this.chkBit2.Name = "chkBit2";
            this.chkBit2.Size = new System.Drawing.Size(17, 28);
            this.chkBit2.TabIndex = 10;
            this.chkBit2.Text = "2";
            this.chkBit2.UseVisualStyleBackColor = true;
            this.chkBit2.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit1
            // 
            this.chkBit1.AutoSize = true;
            this.chkBit1.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit1.Enabled = false;
            this.chkBit1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit1.FlatAppearance.BorderSize = 2;
            this.chkBit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit1.Location = new System.Drawing.Point(286, 92);
            this.chkBit1.Name = "chkBit1";
            this.chkBit1.Size = new System.Drawing.Size(17, 28);
            this.chkBit1.TabIndex = 9;
            this.chkBit1.Text = "1";
            this.chkBit1.UseVisualStyleBackColor = true;
            this.chkBit1.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit0
            // 
            this.chkBit0.AutoSize = true;
            this.chkBit0.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit0.Enabled = false;
            this.chkBit0.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit0.FlatAppearance.BorderSize = 2;
            this.chkBit0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit0.Location = new System.Drawing.Point(307, 92);
            this.chkBit0.Name = "chkBit0";
            this.chkBit0.Size = new System.Drawing.Size(17, 28);
            this.chkBit0.TabIndex = 8;
            this.chkBit0.Text = "0";
            this.chkBit0.UseVisualStyleBackColor = true;
            this.chkBit0.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit4
            // 
            this.chkBit4.AutoSize = true;
            this.chkBit4.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit4.Enabled = false;
            this.chkBit4.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit4.FlatAppearance.BorderSize = 2;
            this.chkBit4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit4.Location = new System.Drawing.Point(224, 92);
            this.chkBit4.Name = "chkBit4";
            this.chkBit4.Size = new System.Drawing.Size(17, 28);
            this.chkBit4.TabIndex = 7;
            this.chkBit4.Text = "4";
            this.chkBit4.UseVisualStyleBackColor = true;
            this.chkBit4.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit5
            // 
            this.chkBit5.AutoSize = true;
            this.chkBit5.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit5.Enabled = false;
            this.chkBit5.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit5.FlatAppearance.BorderSize = 2;
            this.chkBit5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit5.Location = new System.Drawing.Point(202, 92);
            this.chkBit5.Name = "chkBit5";
            this.chkBit5.Size = new System.Drawing.Size(17, 28);
            this.chkBit5.TabIndex = 6;
            this.chkBit5.Text = "5";
            this.chkBit5.UseVisualStyleBackColor = true;
            this.chkBit5.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit6
            // 
            this.chkBit6.AutoSize = true;
            this.chkBit6.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit6.Enabled = false;
            this.chkBit6.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit6.FlatAppearance.BorderSize = 2;
            this.chkBit6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit6.Location = new System.Drawing.Point(181, 92);
            this.chkBit6.Name = "chkBit6";
            this.chkBit6.Size = new System.Drawing.Size(17, 28);
            this.chkBit6.TabIndex = 5;
            this.chkBit6.Text = "6";
            this.chkBit6.UseVisualStyleBackColor = true;
            this.chkBit6.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // chkBit7
            // 
            this.chkBit7.AutoSize = true;
            this.chkBit7.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBit7.Enabled = false;
            this.chkBit7.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.chkBit7.FlatAppearance.BorderSize = 2;
            this.chkBit7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBit7.Location = new System.Drawing.Point(163, 92);
            this.chkBit7.Name = "chkBit7";
            this.chkBit7.Size = new System.Drawing.Size(17, 28);
            this.chkBit7.TabIndex = 4;
            this.chkBit7.Text = "7";
            this.chkBit7.UseVisualStyleBackColor = true;
            this.chkBit7.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(98, 61);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 3;
            this.txtValue.Visible = false;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(98, 19);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 20);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Text = "0";
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(6, 64);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(91, 13);
            this.lblValue.TabIndex = 1;
            this.lblValue.Text = "Value";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(6, 22);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(91, 13);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "address (0-based)";
            // 
            // grbAddressType
            // 
            this.grbAddressType.Controls.Add(this.rbRegisterTypeDiscreteInputs);
            this.grbAddressType.Controls.Add(this.rbRegisterTypeCoils);
            this.grbAddressType.Controls.Add(this.rbRegisterTypeInputRegister);
            this.grbAddressType.Controls.Add(this.rbRegisterTypeHoldingRegister);
            this.grbAddressType.Location = new System.Drawing.Point(9, 15);
            this.grbAddressType.Name = "grbAddressType";
            this.grbAddressType.Size = new System.Drawing.Size(328, 49);
            this.grbAddressType.TabIndex = 1;
            this.grbAddressType.TabStop = false;
            this.grbAddressType.Text = "register type";
            // 
            // rbRegisterTypeDiscreteInputs
            // 
            this.rbRegisterTypeDiscreteInputs.AutoSize = true;
            this.rbRegisterTypeDiscreteInputs.Location = new System.Drawing.Point(57, 19);
            this.rbRegisterTypeDiscreteInputs.Name = "rbRegisterTypeDiscreteInputs";
            this.rbRegisterTypeDiscreteInputs.Size = new System.Drawing.Size(54, 17);
            this.rbRegisterTypeDiscreteInputs.TabIndex = 2;
            this.rbRegisterTypeDiscreteInputs.Text = "Inputs";
            this.rbRegisterTypeDiscreteInputs.UseVisualStyleBackColor = true;
            this.rbRegisterTypeDiscreteInputs.CheckedChanged += new System.EventHandler(this.rbRegisterTypeDiscreteInputs_CheckedChanged);
            // 
            // rbRegisterTypeCoils
            // 
            this.rbRegisterTypeCoils.AutoSize = true;
            this.rbRegisterTypeCoils.Checked = true;
            this.rbRegisterTypeCoils.Location = new System.Drawing.Point(6, 19);
            this.rbRegisterTypeCoils.Name = "rbRegisterTypeCoils";
            this.rbRegisterTypeCoils.Size = new System.Drawing.Size(47, 17);
            this.rbRegisterTypeCoils.TabIndex = 1;
            this.rbRegisterTypeCoils.TabStop = true;
            this.rbRegisterTypeCoils.Text = "Coils";
            this.rbRegisterTypeCoils.UseVisualStyleBackColor = true;
            this.rbRegisterTypeCoils.CheckedChanged += new System.EventHandler(this.rbRegisterTypeCoils_CheckedChanged);
            // 
            // rbRegisterTypeInputRegister
            // 
            this.rbRegisterTypeInputRegister.AutoSize = true;
            this.rbRegisterTypeInputRegister.Location = new System.Drawing.Point(227, 19);
            this.rbRegisterTypeInputRegister.Name = "rbRegisterTypeInputRegister";
            this.rbRegisterTypeInputRegister.Size = new System.Drawing.Size(91, 17);
            this.rbRegisterTypeInputRegister.TabIndex = 4;
            this.rbRegisterTypeInputRegister.Text = "Input Register";
            this.rbRegisterTypeInputRegister.UseVisualStyleBackColor = true;
            this.rbRegisterTypeInputRegister.CheckedChanged += new System.EventHandler(this.rbRegisterTypeInputRegister_CheckedChanged);
            // 
            // rbRegisterTypeHoldingRegister
            // 
            this.rbRegisterTypeHoldingRegister.AutoSize = true;
            this.rbRegisterTypeHoldingRegister.Location = new System.Drawing.Point(117, 19);
            this.rbRegisterTypeHoldingRegister.Name = "rbRegisterTypeHoldingRegister";
            this.rbRegisterTypeHoldingRegister.Size = new System.Drawing.Size(103, 17);
            this.rbRegisterTypeHoldingRegister.TabIndex = 3;
            this.rbRegisterTypeHoldingRegister.Text = "Holding Register";
            this.rbRegisterTypeHoldingRegister.UseVisualStyleBackColor = true;
            this.rbRegisterTypeHoldingRegister.CheckedChanged += new System.EventHandler(this.rbRegisterTypeHoldingRegister_CheckedChanged);
            // 
            // lvValues
            // 
            this.lvValues.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDummy,
            this.colAddress,
            this.colValue});
            this.lvValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvValues.FullRowSelect = true;
            this.lvValues.HideSelection = false;
            this.lvValues.Location = new System.Drawing.Point(6, 230);
            this.lvValues.Name = "lvValues";
            this.lvValues.Size = new System.Drawing.Size(328, 195);
            this.lvValues.TabIndex = 0;
            this.lvValues.UseCompatibleStateImageBehavior = false;
            this.lvValues.View = System.Windows.Forms.View.Details;
            this.lvValues.VirtualMode = true;
            this.lvValues.SelectedIndexChanged += new System.EventHandler(this.lvValues_SelectedIndexChanged);
            // 
            // colDummy
            // 
            this.colDummy.DisplayIndex = 2;
            this.colDummy.Text = "";
            this.colDummy.Width = 0;
            // 
            // colAddress
            // 
            this.colAddress.DisplayIndex = 0;
            this.colAddress.Text = "Address";
            this.colAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colValue
            // 
            this.colValue.DisplayIndex = 1;
            this.colValue.Text = "Value";
            this.colValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colValue.Width = 240;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveSettings.Image")));
            this.btnSaveSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveSettings.Location = new System.Drawing.Point(912, 724);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(68, 68);
            this.btnSaveSettings.TabIndex = 80;
            this.btnSaveSettings.Text = "save settings";
            this.btnSaveSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(997, 724);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 68);
            this.btnClose.TabIndex = 81;
            this.btnClose.Text = "exit aplication";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadSettings.Image")));
            this.btnLoadSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadSettings.Location = new System.Drawing.Point(830, 724);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(68, 68);
            this.btnLoadSettings.TabIndex = 82;
            this.btnLoadSettings.Text = "load settings";
            this.btnLoadSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // btnCopyLogtoFile
            // 
            this.btnCopyLogtoFile.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyLogtoFile.Image")));
            this.btnCopyLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyLogtoFile.Location = new System.Drawing.Point(97, 723);
            this.btnCopyLogtoFile.Name = "btnCopyLogtoFile";
            this.btnCopyLogtoFile.Size = new System.Drawing.Size(68, 68);
            this.btnCopyLogtoFile.TabIndex = 83;
            this.btnCopyLogtoFile.Text = "copy slave log to file";
            this.btnCopyLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopyLogtoFile.UseVisualStyleBackColor = true;
            this.btnCopyLogtoFile.Click += new System.EventHandler(this.btnCopyLogtoFile_Click);
            // 
            // btnCertificateManager
            // 
            this.btnCertificateManager.Image = System.Drawing.SystemIcons.Shield.ToBitmap();
            this.btnCertificateManager.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCertificateManager.Location = new System.Drawing.Point(175, 724);
            this.btnCertificateManager.Name = "btnCertificateManager";
            this.btnCertificateManager.Size = new System.Drawing.Size(68, 68);
            this.btnCertificateManager.TabIndex = 127;
            this.btnCertificateManager.Text = "show\r\ncertificates";
            this.btnCertificateManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCertificateManager.UseVisualStyleBackColor = true;
            this.btnCertificateManager.Click += new System.EventHandler(this.btnCertificateManager_Click);
            // 
            // btnCopyLogtoClipboard
            // 
            this.btnCopyLogtoClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyLogtoClipboard.Image")));
            this.btnCopyLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyLogtoClipboard.Location = new System.Drawing.Point(19, 724);
            this.btnCopyLogtoClipboard.Name = "btnCopyLogtoClipboard";
            this.btnCopyLogtoClipboard.Size = new System.Drawing.Size(68, 68);
            this.btnCopyLogtoClipboard.TabIndex = 124;
            this.btnCopyLogtoClipboard.Text = "copy log to clipboard";
            this.btnCopyLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopyLogtoClipboard.UseVisualStyleBackColor = true;
            this.btnCopyLogtoClipboard.Click += new System.EventHandler(this.btnCopyLogtoClipboard_Click);
            // 
            // lblLanguage
            // 
            this.lblLanguage.Location = new System.Drawing.Point(669, 730);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(51, 13);
            this.lblLanguage.TabIndex = 126;
            this.lblLanguage.Text = "language";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(726, 727);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(62, 21);
            this.cmbLanguage.TabIndex = 125;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // Main
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 799);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.btnCopyLogtoClipboard);
            this.Controls.Add(this.btnCertificateManager);
            this.Controls.Add(this.chkAutoScroll);
            this.Controls.Add(this.lblLogLevel);
            this.Controls.Add(this.btnCopyLogtoFile);
            this.Controls.Add(this.chkLogging);
            this.Controls.Add(this.cmbLogLevel);
            this.Controls.Add(this.btnLoadSettings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.grbDataStore);
            this.Controls.Add(this.grbLog);
            this.Controls.Add(this.grbListener);
            this.Controls.Add(this.grbSerial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "slave example";
            this.Load += new System.EventHandler(this.main_Load);
            this.grbSerial.ResumeLayout(false);
            this.grbSerial.PerformLayout();
            this.grbListener.ResumeLayout(false);
            this.grbStatistics.ResumeLayout(false);
            this.grbStatistics.PerformLayout();
            this.grbSlaveSettings.ResumeLayout(false);
            this.grbSupportedFunctions.ResumeLayout(false);
            this.grbSupportedFunctions.PerformLayout();
            this.grbLog.ResumeLayout(false);
            this.grbDataStore.ResumeLayout(false);
            this.grbValues.ResumeLayout(false);
            this.grbValues.PerformLayout();
            this.grbAddressType.ResumeLayout(false);
            this.grbAddressType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSlave;
        internal System.Windows.Forms.Label lblRegisterMode;
        internal System.Windows.Forms.ComboBox cmbRegisterMode;
        internal System.Windows.Forms.GroupBox grbSerial;
        internal System.Windows.Forms.Label lblSerial;
        internal System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.TextBox txtSerial;
        internal System.Windows.Forms.TextBox txtUser;
        internal System.Windows.Forms.Label lblSerialCode;
        private System.Windows.Forms.GroupBox grbListener;
        private System.Windows.Forms.Button btnRemoveListener;
        private System.Windows.Forms.Button btnAddListener;
        private System.Windows.Forms.ListView lvListener;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colParameter;
        private System.Windows.Forms.Button btnStopSlave;
        private System.Windows.Forms.Label lblSlaveID;
        internal System.Windows.Forms.ComboBox cmbSlaveID;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.GroupBox grbLog;
        private System.Windows.Forms.GroupBox grbDataStore;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.RadioButton rbRegisterTypeInputRegister;
        private System.Windows.Forms.RadioButton rbRegisterTypeHoldingRegister;
        private System.Windows.Forms.RadioButton rbRegisterTypeDiscreteInputs;
        private System.Windows.Forms.RadioButton rbRegisterTypeCoils;
        private System.Windows.Forms.GroupBox grbAddressType;
        private System.Windows.Forms.GroupBox grbValues;
        private System.Windows.Forms.CheckBox chkBit27;
        private System.Windows.Forms.CheckBox chkBit26;
        private System.Windows.Forms.CheckBox chkBit25;
        private System.Windows.Forms.CheckBox chkBit24;
        private System.Windows.Forms.CheckBox chkBit28;
        private System.Windows.Forms.CheckBox chkBit29;
        private System.Windows.Forms.CheckBox chkBit30;
        private System.Windows.Forms.CheckBox chkBit31;
        private System.Windows.Forms.CheckBox chkBit19;
        private System.Windows.Forms.CheckBox chkBit18;
        private System.Windows.Forms.CheckBox chkBit17;
        private System.Windows.Forms.CheckBox chkBit16;
        private System.Windows.Forms.CheckBox chkBit20;
        private System.Windows.Forms.CheckBox chkBit21;
        private System.Windows.Forms.CheckBox chkBit22;
        private System.Windows.Forms.CheckBox chkBit23;
        private System.Windows.Forms.CheckBox chkBit11;
        private System.Windows.Forms.CheckBox chkBit10;
        private System.Windows.Forms.CheckBox chkBit9;
        private System.Windows.Forms.CheckBox chkBit8;
        private System.Windows.Forms.CheckBox chkBit12;
        private System.Windows.Forms.CheckBox chkBit13;
        private System.Windows.Forms.CheckBox chkBit14;
        private System.Windows.Forms.CheckBox chkBit15;
        private System.Windows.Forms.CheckBox chkBit3;
        private System.Windows.Forms.CheckBox chkBit2;
        private System.Windows.Forms.CheckBox chkBit1;
        private System.Windows.Forms.CheckBox chkBit0;
        private System.Windows.Forms.CheckBox chkBit4;
        private System.Windows.Forms.CheckBox chkBit5;
        private System.Windows.Forms.CheckBox chkBit6;
        private System.Windows.Forms.CheckBox chkBit7;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnSetValue;
        private System.Windows.Forms.RadioButton rbValueOFF;
        private System.Windows.Forms.RadioButton rbValueOn;
        private System.Windows.Forms.ColumnHeader colDummy;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.ColumnHeader colText;
        private System.Windows.Forms.CheckBox chkLogging;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.Label lblLogLevel;
        internal System.Windows.Forms.ComboBox cmbLogLevel;
        private System.Windows.Forms.Button btnCopyLogtoFile;
        private System.Windows.Forms.Button btnCertificateManager;
        private System.Windows.Forms.GroupBox grbSupportedFunctions;
        private System.Windows.Forms.CheckBox chkSupportsFC01;
        private System.Windows.Forms.CheckBox chkSupportsFC23;
        private System.Windows.Forms.CheckBox chkSupportsFC16;
        private System.Windows.Forms.CheckBox chkSupportsFC15;
        private System.Windows.Forms.CheckBox chkSupportsFC08;
        private System.Windows.Forms.CheckBox chkSupportsFC06;
        private System.Windows.Forms.CheckBox chkSupportsFC05;
        private System.Windows.Forms.CheckBox chkSupportsFC04;
        private System.Windows.Forms.CheckBox chkSupportsFC03;
        private System.Windows.Forms.CheckBox chkSupportsFC02;
        private System.Windows.Forms.GroupBox grbStatistics;
        private System.Windows.Forms.TextBox txtOutgoingBytes;
        private System.Windows.Forms.TextBox txtIncomingBytes;
        internal System.Windows.Forms.Label lblOutgoingBytes;
        internal System.Windows.Forms.Label lblIncomingBytes;
        private System.Windows.Forms.GroupBox grbSlaveSettings;
        private System.Windows.Forms.TextBox txtIncorectRequests;
        private System.Windows.Forms.TextBox txtIncomingRequests;
        internal System.Windows.Forms.Label lblIncorrectRequests;
        internal System.Windows.Forms.Label lblIncomingRequests;
        private System.Windows.Forms.TextBox txtUnparseableRequests;
        internal System.Windows.Forms.Label lblUnparseableRequests;
        private System.Windows.Forms.Label lblByteOrder;
        internal System.Windows.Forms.ComboBox cmbByteOrder;
        private System.Windows.Forms.Button btnCopyLogtoClipboard;
        private System.Windows.Forms.Label lblLanguage;
        internal System.Windows.Forms.ComboBox cmbLanguage;
    }
}

