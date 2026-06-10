namespace PLCComMB_Master_Example_CSharp
{
    partial class ReadWriteBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadWriteBox));
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.grbWriteValues = new System.Windows.Forms.Panel();
            this.txtOR = new System.Windows.Forms.TextBox();
            this.chkSingleValue = new System.Windows.Forms.CheckBox();
            this.lblWriteMaskRegister_OR = new System.Windows.Forms.Label();
            this.txtAND = new System.Windows.Forms.TextBox();
            this.lblWriteMaskRegister_AND = new System.Windows.Forms.Label();
            this.rbOff = new System.Windows.Forms.RadioButton();
            this.rbOn = new System.Windows.Forms.RadioButton();
            this.txtSingleValues = new System.Windows.Forms.TextBox();
            this.lblEnterValues = new System.Windows.Forms.Label();
            this.txtMultipleValues = new System.Windows.Forms.TextBox();
            this.lblWriteAddress = new System.Windows.Forms.Label();
            this.txtWriteAddress = new System.Windows.Forms.TextBox();
            this.txtInfoRB = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtBit = new System.Windows.Forms.TextBox();
            this.lblBit = new System.Windows.Forms.Label();
            this.txtReadAddress = new System.Windows.Forms.TextBox();
            this.lblReadAddress = new System.Windows.Forms.Label();
            this.lblDataType = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.lblSlaveID = new System.Windows.Forms.Label();
            this.cmbSlaveID = new System.Windows.Forms.ComboBox();
            this.cmbByteOrder = new System.Windows.Forms.ComboBox();
            this.lblByteOrder = new System.Windows.Forms.Label();
            this.cmbFunction = new System.Windows.Forms.ComboBox();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lblBroadcast = new System.Windows.Forms.Label();
            this.btnSaveRequest = new System.Windows.Forms.Button();
            this.btnLoadRequest = new System.Windows.Forms.Button();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.lvValues = new System.Windows.Forms.ListView();
            this.colDummy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblLog = new System.Windows.Forms.Label();
            this.panelStatusStrip = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDeviceGUID = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSaveLogtoFile = new System.Windows.Forms.Button();
            this.btnSaveLogtoClipboard = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpAddress.SuspendLayout();
            this.grbWriteValues.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.panelStatusStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAddress
            // 
            this.grpAddress.Controls.Add(this.grbWriteValues);
            this.grpAddress.Controls.Add(this.lblWriteAddress);
            this.grpAddress.Controls.Add(this.txtWriteAddress);
            this.grpAddress.Controls.Add(this.txtInfoRB);
            this.grpAddress.Controls.Add(this.txtQuantity);
            this.grpAddress.Controls.Add(this.lblQuantity);
            this.grpAddress.Controls.Add(this.txtBit);
            this.grpAddress.Controls.Add(this.lblBit);
            this.grpAddress.Controls.Add(this.txtReadAddress);
            this.grpAddress.Controls.Add(this.lblReadAddress);
            this.grpAddress.Controls.Add(this.lblDataType);
            this.grpAddress.Controls.Add(this.cmbDataType);
            this.grpAddress.Controls.Add(this.lblSlaveID);
            this.grpAddress.Controls.Add(this.cmbSlaveID);
            this.grpAddress.Controls.Add(this.cmbByteOrder);
            this.grpAddress.Controls.Add(this.lblByteOrder);
            this.grpAddress.Controls.Add(this.cmbFunction);
            this.grpAddress.Controls.Add(this.lblFunction);
            this.grpAddress.Controls.Add(this.lblBroadcast);
            this.grpAddress.Location = new System.Drawing.Point(12, 4);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Size = new System.Drawing.Size(656, 241);
            this.grpAddress.TabIndex = 87;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "Address";
            // 
            // grbWriteValues
            // 
            this.grbWriteValues.Controls.Add(this.txtOR);
            this.grbWriteValues.Controls.Add(this.chkSingleValue);
            this.grbWriteValues.Controls.Add(this.lblWriteMaskRegister_OR);
            this.grbWriteValues.Controls.Add(this.txtAND);
            this.grbWriteValues.Controls.Add(this.lblWriteMaskRegister_AND);
            this.grbWriteValues.Controls.Add(this.rbOff);
            this.grbWriteValues.Controls.Add(this.rbOn);
            this.grbWriteValues.Controls.Add(this.txtSingleValues);
            this.grbWriteValues.Controls.Add(this.lblEnterValues);
            this.grbWriteValues.Controls.Add(this.txtMultipleValues);
            this.grbWriteValues.Enabled = false;
            this.grbWriteValues.Location = new System.Drawing.Point(331, 77);
            this.grbWriteValues.Name = "grbWriteValues";
            this.grbWriteValues.Size = new System.Drawing.Size(319, 158);
            this.grbWriteValues.TabIndex = 118;
            // 
            // txtOR
            // 
            this.txtOR.BackColor = System.Drawing.Color.White;
            this.txtOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOR.Location = new System.Drawing.Point(41, 110);
            this.txtOR.Name = "txtOR";
            this.txtOR.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOR.Size = new System.Drawing.Size(275, 20);
            this.txtOR.TabIndex = 124;
            this.txtOR.Text = "0";
            this.txtOR.Visible = false;
            // 
            // chkSingleValue
            // 
            this.chkSingleValue.AutoSize = true;
            this.chkSingleValue.Location = new System.Drawing.Point(41, 11);
            this.chkSingleValue.Name = "chkSingleValue";
            this.chkSingleValue.Size = new System.Drawing.Size(82, 17);
            this.chkSingleValue.TabIndex = 126;
            this.chkSingleValue.Text = "single value";
            this.chkSingleValue.UseVisualStyleBackColor = true;
            this.chkSingleValue.CheckedChanged += new System.EventHandler(this.chkSingleValue_CheckedChanged);
            // 
            // lblWriteMaskRegister_OR
            // 
            this.lblWriteMaskRegister_OR.AutoSize = true;
            this.lblWriteMaskRegister_OR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWriteMaskRegister_OR.Location = new System.Drawing.Point(38, 91);
            this.lblWriteMaskRegister_OR.Name = "lblWriteMaskRegister_OR";
            this.lblWriteMaskRegister_OR.Size = new System.Drawing.Size(176, 13);
            this.lblWriteMaskRegister_OR.TabIndex = 125;
            this.lblWriteMaskRegister_OR.Text = "Enter the OR value in ushort format:";
            this.lblWriteMaskRegister_OR.Visible = false;
            // 
            // txtAND
            // 
            this.txtAND.BackColor = System.Drawing.Color.White;
            this.txtAND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAND.Location = new System.Drawing.Point(41, 55);
            this.txtAND.Name = "txtAND";
            this.txtAND.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAND.Size = new System.Drawing.Size(275, 20);
            this.txtAND.TabIndex = 122;
            this.txtAND.Text = "0";
            this.txtAND.Visible = false;
            // 
            // lblWriteMaskRegister_AND
            // 
            this.lblWriteMaskRegister_AND.AutoSize = true;
            this.lblWriteMaskRegister_AND.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWriteMaskRegister_AND.Location = new System.Drawing.Point(38, 32);
            this.lblWriteMaskRegister_AND.Name = "lblWriteMaskRegister_AND";
            this.lblWriteMaskRegister_AND.Size = new System.Drawing.Size(183, 13);
            this.lblWriteMaskRegister_AND.TabIndex = 123;
            this.lblWriteMaskRegister_AND.Text = "Enter the AND value in ushort format:";
            this.lblWriteMaskRegister_AND.Visible = false;
            // 
            // rbOff
            // 
            this.rbOff.AutoSize = true;
            this.rbOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbOff.Location = new System.Drawing.Point(179, 53);
            this.rbOff.Name = "rbOff";
            this.rbOff.Size = new System.Drawing.Size(44, 17);
            this.rbOff.TabIndex = 121;
            this.rbOff.Text = "OFF";
            this.rbOff.UseVisualStyleBackColor = true;
            this.rbOff.Visible = false;
            this.rbOff.CheckedChanged += new System.EventHandler(this.rbOff_CheckedChanged);
            // 
            // rbOn
            // 
            this.rbOn.AutoSize = true;
            this.rbOn.Checked = true;
            this.rbOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbOn.Location = new System.Drawing.Point(41, 53);
            this.rbOn.Name = "rbOn";
            this.rbOn.Size = new System.Drawing.Size(40, 17);
            this.rbOn.TabIndex = 120;
            this.rbOn.TabStop = true;
            this.rbOn.Text = "ON";
            this.rbOn.UseVisualStyleBackColor = true;
            this.rbOn.Visible = false;
            this.rbOn.CheckedChanged += new System.EventHandler(this.rbOn_CheckedChanged);
            // 
            // txtSingleValues
            // 
            this.txtSingleValues.BackColor = System.Drawing.Color.White;
            this.txtSingleValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSingleValues.Location = new System.Drawing.Point(41, 53);
            this.txtSingleValues.Name = "txtSingleValues";
            this.txtSingleValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSingleValues.Size = new System.Drawing.Size(275, 20);
            this.txtSingleValues.TabIndex = 119;
            this.txtSingleValues.Text = "0";
            this.txtSingleValues.Visible = false;
            this.txtSingleValues.TextChanged += new System.EventHandler(this.txtSingleValues_TextChanged);
            // 
            // lblEnterValues
            // 
            this.lblEnterValues.AutoSize = true;
            this.lblEnterValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterValues.Location = new System.Drawing.Point(38, 31);
            this.lblEnterValues.Name = "lblEnterValues";
            this.lblEnterValues.Size = new System.Drawing.Size(212, 13);
            this.lblEnterValues.TabIndex = 118;
            this.lblEnterValues.Text = "Please enter the values separated by return";
            // 
            // txtMultipleValues
            // 
            this.txtMultipleValues.BackColor = System.Drawing.Color.White;
            this.txtMultipleValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMultipleValues.Location = new System.Drawing.Point(41, 54);
            this.txtMultipleValues.Multiline = true;
            this.txtMultipleValues.Name = "txtMultipleValues";
            this.txtMultipleValues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMultipleValues.Size = new System.Drawing.Size(275, 94);
            this.txtMultipleValues.TabIndex = 117;
            this.txtMultipleValues.Text = "0\r\n0\r\n0\r\n0";
            this.txtMultipleValues.TextChanged += new System.EventHandler(this.txtMultipleValues_TextChanged);
            // 
            // lblWriteAddress
            // 
            this.lblWriteAddress.Location = new System.Drawing.Point(6, 213);
            this.lblWriteAddress.Name = "lblWriteAddress";
            this.lblWriteAddress.Size = new System.Drawing.Size(88, 13);
            this.lblWriteAddress.TabIndex = 101;
            this.lblWriteAddress.Text = "write adress";
            this.lblWriteAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtWriteAddress
            // 
            this.txtWriteAddress.Location = new System.Drawing.Point(100, 210);
            this.txtWriteAddress.Name = "txtWriteAddress";
            this.txtWriteAddress.Size = new System.Drawing.Size(190, 20);
            this.txtWriteAddress.TabIndex = 100;
            this.txtWriteAddress.Text = "0";
            // 
            // txtInfoRB
            // 
            this.txtInfoRB.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfoRB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfoRB.Location = new System.Drawing.Point(372, 21);
            this.txtInfoRB.Multiline = true;
            this.txtInfoRB.Name = "txtInfoRB";
            this.txtInfoRB.Size = new System.Drawing.Size(275, 47);
            this.txtInfoRB.TabIndex = 114;
            this.txtInfoRB.Text = "In diesem Fenster können einzelne Lese- oder Schreibvorgänge durchgeführt werden." +
    " Für optimierte Lesevorgänge benutzen Sie bitte die ReadCollection.";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(100, 184);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(190, 20);
            this.txtQuantity.TabIndex = 112;
            this.txtQuantity.Text = "8";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(6, 187);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(88, 13);
            this.lblQuantity.TabIndex = 113;
            this.lblQuantity.Text = "Quantity";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBit
            // 
            this.txtBit.Location = new System.Drawing.Point(100, 156);
            this.txtBit.Name = "txtBit";
            this.txtBit.Size = new System.Drawing.Size(190, 20);
            this.txtBit.TabIndex = 109;
            this.txtBit.Text = "0";
            // 
            // lblBit
            // 
            this.lblBit.Location = new System.Drawing.Point(6, 159);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(88, 13);
            this.lblBit.TabIndex = 110;
            this.lblBit.Text = "bit";
            this.lblBit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtReadAddress
            // 
            this.txtReadAddress.Location = new System.Drawing.Point(100, 129);
            this.txtReadAddress.Name = "txtReadAddress";
            this.txtReadAddress.Size = new System.Drawing.Size(190, 20);
            this.txtReadAddress.TabIndex = 108;
            this.txtReadAddress.Text = "0";
            // 
            // lblReadAddress
            // 
            this.lblReadAddress.Location = new System.Drawing.Point(6, 132);
            this.lblReadAddress.Name = "lblReadAddress";
            this.lblReadAddress.Size = new System.Drawing.Size(88, 13);
            this.lblReadAddress.TabIndex = 111;
            this.lblReadAddress.Text = "read adress";
            this.lblReadAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDataType
            // 
            this.lblDataType.Location = new System.Drawing.Point(6, 77);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(88, 13);
            this.lblDataType.TabIndex = 76;
            this.lblDataType.Text = "DataType";
            this.lblDataType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbDataType
            // 
            this.cmbDataType.Enabled = false;
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(100, 74);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(190, 21);
            this.cmbDataType.TabIndex = 75;
            this.cmbDataType.SelectedIndexChanged += new System.EventHandler(this.cmbDataType_SelectedIndexChanged);
            // 
            // lblSlaveID
            // 
            this.lblSlaveID.Location = new System.Drawing.Point(6, 50);
            this.lblSlaveID.Name = "lblSlaveID";
            this.lblSlaveID.Size = new System.Drawing.Size(88, 13);
            this.lblSlaveID.TabIndex = 74;
            this.lblSlaveID.Text = "slave id";
            this.lblSlaveID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbSlaveID
            // 
            this.cmbSlaveID.FormattingEnabled = true;
            this.cmbSlaveID.Location = new System.Drawing.Point(100, 47);
            this.cmbSlaveID.Name = "cmbSlaveID";
            this.cmbSlaveID.Size = new System.Drawing.Size(190, 21);
            this.cmbSlaveID.TabIndex = 73;
            this.cmbSlaveID.SelectedIndexChanged += new System.EventHandler(this.cmbSlaveID_SelectedIndexChanged);
            // 
            // cmbByteOrder
            // 
            this.cmbByteOrder.Enabled = false;
            this.cmbByteOrder.FormattingEnabled = true;
            this.cmbByteOrder.Location = new System.Drawing.Point(100, 102);
            this.cmbByteOrder.Name = "cmbByteOrder";
            this.cmbByteOrder.Size = new System.Drawing.Size(190, 21);
            this.cmbByteOrder.TabIndex = 72;
            // 
            // lblByteOrder
            // 
            this.lblByteOrder.Location = new System.Drawing.Point(6, 105);
            this.lblByteOrder.Name = "lblByteOrder";
            this.lblByteOrder.Size = new System.Drawing.Size(88, 13);
            this.lblByteOrder.TabIndex = 71;
            this.lblByteOrder.Text = "byte encoding";
            this.lblByteOrder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbFunction
            // 
            this.cmbFunction.FormattingEnabled = true;
            this.cmbFunction.Location = new System.Drawing.Point(100, 19);
            this.cmbFunction.Name = "cmbFunction";
            this.cmbFunction.Size = new System.Drawing.Size(190, 21);
            this.cmbFunction.TabIndex = 69;
            this.cmbFunction.SelectedIndexChanged += new System.EventHandler(this.cmbFunction_SelectedIndexChanged);
            // 
            // lblFunction
            // 
            this.lblFunction.Location = new System.Drawing.Point(6, 23);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(88, 13);
            this.lblFunction.TabIndex = 70;
            this.lblFunction.Text = "Function";
            this.lblFunction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBroadcast
            // 
            this.lblBroadcast.ForeColor = System.Drawing.Color.Red;
            this.lblBroadcast.Location = new System.Drawing.Point(294, 41);
            this.lblBroadcast.Name = "lblBroadcast";
            this.lblBroadcast.Size = new System.Drawing.Size(81, 55);
            this.lblBroadcast.TabIndex = 66;
            this.lblBroadcast.Text = "broadcast, if it supported by slave";
            // 
            // btnSaveRequest
            // 
            this.btnSaveRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRequest.Image")));
            this.btnSaveRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveRequest.Location = new System.Drawing.Point(520, 604);
            this.btnSaveRequest.Name = "btnSaveRequest";
            this.btnSaveRequest.Size = new System.Drawing.Size(68, 68);
            this.btnSaveRequest.TabIndex = 116;
            this.btnSaveRequest.Text = "save request";
            this.btnSaveRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveRequest.UseVisualStyleBackColor = true;
            this.btnSaveRequest.Click += new System.EventHandler(this.btnSaveRequest_Click);
            // 
            // btnLoadRequest
            // 
            this.btnLoadRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadRequest.Image")));
            this.btnLoadRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadRequest.Location = new System.Drawing.Point(446, 604);
            this.btnLoadRequest.Name = "btnLoadRequest";
            this.btnLoadRequest.Size = new System.Drawing.Size(68, 68);
            this.btnLoadRequest.TabIndex = 117;
            this.btnLoadRequest.Text = "load request";
            this.btnLoadRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadRequest.UseVisualStyleBackColor = true;
            this.btnLoadRequest.Click += new System.EventHandler(this.btnLoadRequest_Click);
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnExecute);
            this.grpAction.Controls.Add(this.lvValues);
            this.grpAction.Location = new System.Drawing.Point(12, 251);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(656, 180);
            this.grpAction.TabIndex = 88;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Action";
            // 
            // btnExecute
            // 
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExecute.Location = new System.Drawing.Point(15, 19);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(68, 68);
            this.btnExecute.TabIndex = 105;
            this.btnExecute.Text = "execute function";
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lvValues
            // 
            this.lvValues.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDummy,
            this.colAddress,
            this.colValue});
            this.lvValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvValues.FullRowSelect = true;
            this.lvValues.Location = new System.Drawing.Point(100, 19);
            this.lvValues.Name = "lvValues";
            this.lvValues.Size = new System.Drawing.Size(550, 140);
            this.lvValues.TabIndex = 104;
            this.lvValues.UseCompatibleStateImageBehavior = false;
            this.lvValues.View = System.Windows.Forms.View.Details;
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
            this.colAddress.Text = "Adress";
            this.colAddress.Width = 260;
            // 
            // colValue
            // 
            this.colValue.DisplayIndex = 1;
            this.colValue.Text = "Value";
            this.colValue.Width = 260;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(109, 434);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(90, 13);
            this.lblLog.TabIndex = 39;
            this.lblLog.Text = "Diagnostic output";
            // 
            // panelStatusStrip
            // 
            this.panelStatusStrip.AutoSize = true;
            this.panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatusStrip.Controls.Add(this.statusStrip);
            this.panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatusStrip.Location = new System.Drawing.Point(0, 687);
            this.panelStatusStrip.Name = "panelStatusStrip";
            this.panelStatusStrip.Size = new System.Drawing.Size(671, 24);
            this.panelStatusStrip.TabIndex = 97;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDeviceType,
            this.lblDeviceGUID});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(669, 22);
            this.statusStrip.TabIndex = 95;
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
            this.lblDeviceType.Size = new System.Drawing.Size(78, 17);
            this.lblDeviceType.Text = "DeviceType: ";
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
            this.lblDeviceGUID.Size = new System.Drawing.Size(86, 17);
            this.lblDeviceGUID.Text = "GUID: nothing";
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLog.Location = new System.Drawing.Point(112, 449);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(550, 142);
            this.lvLog.TabIndex = 98;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 1000;
            // 
            // btnSaveLogtoFile
            // 
            this.btnSaveLogtoFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLogtoFile.Image")));
            this.btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLogtoFile.Location = new System.Drawing.Point(27, 523);
            this.btnSaveLogtoFile.Name = "btnSaveLogtoFile";
            this.btnSaveLogtoFile.Size = new System.Drawing.Size(68, 68);
            this.btnSaveLogtoFile.TabIndex = 107;
            this.btnSaveLogtoFile.Text = "save log to file";
            this.btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLogtoFile.UseVisualStyleBackColor = true;
            this.btnSaveLogtoFile.Click += new System.EventHandler(this.btnSaveLogtoFile_Click);
            // 
            // btnSaveLogtoClipboard
            // 
            this.btnSaveLogtoClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLogtoClipboard.Image")));
            this.btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLogtoClipboard.Location = new System.Drawing.Point(27, 449);
            this.btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard";
            this.btnSaveLogtoClipboard.Size = new System.Drawing.Size(68, 68);
            this.btnSaveLogtoClipboard.TabIndex = 106;
            this.btnSaveLogtoClipboard.Text = "copy log to clipboard";
            this.btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLogtoClipboard.UseVisualStyleBackColor = true;
            this.btnSaveLogtoClipboard.Click += new System.EventHandler(this.btnSaveLogtoClipboard_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(594, 604);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 68);
            this.btnClose.TabIndex = 108;
            this.btnClose.Text = "close window";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReadWriteBox
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 711);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveLogtoFile);
            this.Controls.Add(this.btnSaveRequest);
            this.Controls.Add(this.btnSaveLogtoClipboard);
            this.Controls.Add(this.btnLoadRequest);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.panelStatusStrip);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.grpAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadWriteBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReadWriteBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReadWriteBox_FormClosing);
            this.Load += new System.EventHandler(this.ReadWriteBox_Load);
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            this.grbWriteValues.ResumeLayout(false);
            this.grbWriteValues.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.panelStatusStrip.ResumeLayout(false);
            this.panelStatusStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.GroupBox grpAction;
        internal System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceGUID;
        internal System.Windows.Forms.TextBox txtWriteAddress;
        internal System.Windows.Forms.Label lblWriteAddress;
        private System.Windows.Forms.Label lblBroadcast;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblDataType;
        internal System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label lblSlaveID;
        internal System.Windows.Forms.ComboBox cmbSlaveID;
        internal System.Windows.Forms.ComboBox cmbByteOrder;
        private System.Windows.Forms.Label lblByteOrder;
        internal System.Windows.Forms.ComboBox cmbFunction;
        internal System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.TextBox txtInfoRB;
        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.Label lblQuantity;
        internal System.Windows.Forms.TextBox txtBit;
        internal System.Windows.Forms.Label lblBit;
        internal System.Windows.Forms.TextBox txtReadAddress;
        internal System.Windows.Forms.Label lblReadAddress;
        private System.Windows.Forms.Button btnSaveLogtoFile;
        private System.Windows.Forms.Button btnSaveLogtoClipboard;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader colDummy;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Button btnSaveRequest;
        private System.Windows.Forms.Button btnLoadRequest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel grbWriteValues;
        internal System.Windows.Forms.TextBox txtOR;
        private System.Windows.Forms.CheckBox chkSingleValue;
        internal System.Windows.Forms.Label lblWriteMaskRegister_OR;
        internal System.Windows.Forms.TextBox txtAND;
        internal System.Windows.Forms.Label lblWriteMaskRegister_AND;
        private System.Windows.Forms.RadioButton rbOff;
        private System.Windows.Forms.RadioButton rbOn;
        internal System.Windows.Forms.TextBox txtSingleValues;
        internal System.Windows.Forms.Label lblEnterValues;
        internal System.Windows.Forms.TextBox txtMultipleValues;

    }
}
