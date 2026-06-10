namespace PLCComMB_Master_Example_CSharp
{
    partial class ReadCollectionBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadCollectionBox));
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblReadAddress = new System.Windows.Forms.Label();
            this.lblBit = new System.Windows.Forms.Label();
            this.txtBit = new System.Windows.Forms.TextBox();
            this.txtReadAddress = new System.Windows.Forms.TextBox();
            this.lblFunction = new System.Windows.Forms.Label();
            this.cmbFunction = new System.Windows.Forms.ComboBox();
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.txtInfoRCB = new System.Windows.Forms.TextBox();
            this.btnRemoveRequest = new System.Windows.Forms.Button();
            this.lvRequests = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtRequestKey = new System.Windows.Forms.TextBox();
            this.lblRequestKey = new System.Windows.Forms.Label();
            this.lblDataType = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.btnAddRequest = new System.Windows.Forms.Button();
            this.lblSlaveID = new System.Windows.Forms.Label();
            this.cmbSlaveID = new System.Windows.Forms.ComboBox();
            this.cmbByteOrder = new System.Windows.Forms.ComboBox();
            this.lblByteOrder = new System.Windows.Forms.Label();
            this.btnSaveRequests = new System.Windows.Forms.Button();
            this.btnLoadRequests = new System.Windows.Forms.Button();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnSaveLogtoFile = new System.Windows.Forms.Button();
            this.btnSaveLogtoClipboard = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReadCollection = new System.Windows.Forms.Button();
            this.lvValues = new System.Windows.Forms.ListView();
            this.colDummy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelStatusStrip = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDeviceGUID = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpAddress.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.panelStatusStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(338, 127);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 13);
            this.lblQuantity.TabIndex = 61;
            this.lblQuantity.Text = "Quantity";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(406, 124);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(238, 20);
            this.txtQuantity.TabIndex = 60;
            this.txtQuantity.Text = "8";
            // 
            // lblReadAddress
            // 
            this.lblReadAddress.Location = new System.Drawing.Point(338, 72);
            this.lblReadAddress.Name = "lblReadAddress";
            this.lblReadAddress.Size = new System.Drawing.Size(62, 13);
            this.lblReadAddress.TabIndex = 58;
            this.lblReadAddress.Text = "read adress";
            this.lblReadAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBit
            // 
            this.lblBit.Location = new System.Drawing.Point(338, 99);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(62, 13);
            this.lblBit.TabIndex = 57;
            this.lblBit.Text = "Bit";
            this.lblBit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtBit
            // 
            this.txtBit.Location = new System.Drawing.Point(406, 95);
            this.txtBit.Name = "txtBit";
            this.txtBit.Size = new System.Drawing.Size(238, 20);
            this.txtBit.TabIndex = 56;
            this.txtBit.Text = "0";
            // 
            // txtReadAddress
            // 
            this.txtReadAddress.Location = new System.Drawing.Point(406, 69);
            this.txtReadAddress.Name = "txtReadAddress";
            this.txtReadAddress.Size = new System.Drawing.Size(238, 20);
            this.txtReadAddress.TabIndex = 55;
            this.txtReadAddress.Text = "0";
            // 
            // lblFunction
            // 
            this.lblFunction.Location = new System.Drawing.Point(6, 44);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(82, 16);
            this.lblFunction.TabIndex = 53;
            this.lblFunction.Text = "function";
            this.lblFunction.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbFunction
            // 
            this.cmbFunction.FormattingEnabled = true;
            this.cmbFunction.Location = new System.Drawing.Point(94, 41);
            this.cmbFunction.Name = "cmbFunction";
            this.cmbFunction.Size = new System.Drawing.Size(238, 21);
            this.cmbFunction.TabIndex = 52;
            this.cmbFunction.SelectedIndexChanged += new System.EventHandler(this.cmbFunction_SelectedIndexChanged);
            // 
            // grpAddress
            // 
            this.grpAddress.Controls.Add(this.txtInfoRCB);
            this.grpAddress.Controls.Add(this.btnRemoveRequest);
            this.grpAddress.Controls.Add(this.lvRequests);
            this.grpAddress.Controls.Add(this.txtRequestKey);
            this.grpAddress.Controls.Add(this.lblRequestKey);
            this.grpAddress.Controls.Add(this.lblDataType);
            this.grpAddress.Controls.Add(this.cmbDataType);
            this.grpAddress.Controls.Add(this.btnAddRequest);
            this.grpAddress.Controls.Add(this.lblSlaveID);
            this.grpAddress.Controls.Add(this.txtQuantity);
            this.grpAddress.Controls.Add(this.lblQuantity);
            this.grpAddress.Controls.Add(this.txtBit);
            this.grpAddress.Controls.Add(this.lblBit);
            this.grpAddress.Controls.Add(this.cmbSlaveID);
            this.grpAddress.Controls.Add(this.txtReadAddress);
            this.grpAddress.Controls.Add(this.cmbByteOrder);
            this.grpAddress.Controls.Add(this.lblByteOrder);
            this.grpAddress.Controls.Add(this.lblReadAddress);
            this.grpAddress.Controls.Add(this.cmbFunction);
            this.grpAddress.Controls.Add(this.lblFunction);
            this.grpAddress.Location = new System.Drawing.Point(12, 4);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Size = new System.Drawing.Size(656, 306);
            this.grpAddress.TabIndex = 87;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "add read request";
            // 
            // txtInfoRCB
            // 
            this.txtInfoRCB.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfoRCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfoRCB.Location = new System.Drawing.Point(406, 12);
            this.txtInfoRCB.Multiline = true;
            this.txtInfoRCB.Name = "txtInfoRCB";
            this.txtInfoRCB.Size = new System.Drawing.Size(238, 49);
            this.txtInfoRCB.TabIndex = 106;
            this.txtInfoRCB.Text = "Bei der ReadCollection werden Lese-Vorgänge logisch optimiert, sodass nur die min" +
    "imal notwendigen Zugriffe auf den Modbus erfolgen. ";
            // 
            // btnRemoveRequest
            // 
            this.btnRemoveRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveRequest.Image")));
            this.btnRemoveRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveRequest.Location = new System.Drawing.Point(9, 227);
            this.btnRemoveRequest.Name = "btnRemoveRequest";
            this.btnRemoveRequest.Size = new System.Drawing.Size(68, 68);
            this.btnRemoveRequest.TabIndex = 105;
            this.btnRemoveRequest.Text = "remove Request";
            this.btnRemoveRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveRequest.UseVisualStyleBackColor = true;
            this.btnRemoveRequest.Click += new System.EventHandler(this.btnRemoveRequest_Click);
            // 
            // lvRequests
            // 
            this.lvRequests.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvRequests.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.lvRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvRequests.FullRowSelect = true;
            this.lvRequests.Location = new System.Drawing.Point(94, 153);
            this.lvRequests.Name = "lvRequests";
            this.lvRequests.Size = new System.Drawing.Size(550, 140);
            this.lvRequests.TabIndex = 104;
            this.lvRequests.UseCompatibleStateImageBehavior = false;
            this.lvRequests.View = System.Windows.Forms.View.Details;
            this.lvRequests.SelectedIndexChanged += new System.EventHandler(this.lvRequests_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 0;
            this.columnHeader4.Text = "Request";
            this.columnHeader4.Width = 520;
            // 
            // txtRequestKey
            // 
            this.txtRequestKey.Location = new System.Drawing.Point(94, 12);
            this.txtRequestKey.Name = "txtRequestKey";
            this.txtRequestKey.Size = new System.Drawing.Size(238, 20);
            this.txtRequestKey.TabIndex = 69;
            // 
            // lblRequestKey
            // 
            this.lblRequestKey.Location = new System.Drawing.Point(6, 16);
            this.lblRequestKey.Name = "lblRequestKey";
            this.lblRequestKey.Size = new System.Drawing.Size(82, 16);
            this.lblRequestKey.TabIndex = 70;
            this.lblRequestKey.Text = "requestkey";
            this.lblRequestKey.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDataType
            // 
            this.lblDataType.Location = new System.Drawing.Point(6, 99);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(82, 16);
            this.lblDataType.TabIndex = 68;
            this.lblDataType.Text = "datatype";
            this.lblDataType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbDataType
            // 
            this.cmbDataType.Enabled = false;
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(94, 96);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(238, 21);
            this.cmbDataType.TabIndex = 67;
            this.cmbDataType.SelectedIndexChanged += new System.EventHandler(this.cmbDataType_SelectedIndexChanged);
            // 
            // btnAddRequest
            // 
            this.btnAddRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRequest.Image")));
            this.btnAddRequest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddRequest.Location = new System.Drawing.Point(9, 153);
            this.btnAddRequest.Name = "btnAddRequest";
            this.btnAddRequest.Size = new System.Drawing.Size(68, 68);
            this.btnAddRequest.TabIndex = 66;
            this.btnAddRequest.Text = "add Request";
            this.btnAddRequest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddRequest.UseVisualStyleBackColor = true;
            this.btnAddRequest.Click += new System.EventHandler(this.btnAddRequest_Click);
            // 
            // lblSlaveID
            // 
            this.lblSlaveID.Location = new System.Drawing.Point(6, 72);
            this.lblSlaveID.Name = "lblSlaveID";
            this.lblSlaveID.Size = new System.Drawing.Size(82, 16);
            this.lblSlaveID.TabIndex = 65;
            this.lblSlaveID.Text = "slave id";
            this.lblSlaveID.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbSlaveID
            // 
            this.cmbSlaveID.FormattingEnabled = true;
            this.cmbSlaveID.Location = new System.Drawing.Point(94, 69);
            this.cmbSlaveID.Name = "cmbSlaveID";
            this.cmbSlaveID.Size = new System.Drawing.Size(238, 21);
            this.cmbSlaveID.TabIndex = 64;
            // 
            // cmbByteOrder
            // 
            this.cmbByteOrder.Enabled = false;
            this.cmbByteOrder.FormattingEnabled = true;
            this.cmbByteOrder.Location = new System.Drawing.Point(94, 124);
            this.cmbByteOrder.Name = "cmbByteOrder";
            this.cmbByteOrder.Size = new System.Drawing.Size(238, 21);
            this.cmbByteOrder.TabIndex = 63;
            // 
            // lblByteOrder
            // 
            this.lblByteOrder.Location = new System.Drawing.Point(6, 127);
            this.lblByteOrder.Name = "lblByteOrder";
            this.lblByteOrder.Size = new System.Drawing.Size(82, 16);
            this.lblByteOrder.TabIndex = 62;
            this.lblByteOrder.Text = "byte encoding";
            this.lblByteOrder.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSaveRequests
            // 
            this.btnSaveRequests.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRequests.Image")));
            this.btnSaveRequests.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveRequests.Location = new System.Drawing.Point(514, 668);
            this.btnSaveRequests.Name = "btnSaveRequests";
            this.btnSaveRequests.Size = new System.Drawing.Size(68, 68);
            this.btnSaveRequests.TabIndex = 98;
            this.btnSaveRequests.Text = "save requests";
            this.btnSaveRequests.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveRequests.UseVisualStyleBackColor = true;
            this.btnSaveRequests.Click += new System.EventHandler(this.btnSaveRequests_Click);
            // 
            // btnLoadRequests
            // 
            this.btnLoadRequests.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadRequests.Image")));
            this.btnLoadRequests.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoadRequests.Location = new System.Drawing.Point(440, 668);
            this.btnLoadRequests.Name = "btnLoadRequests";
            this.btnLoadRequests.Size = new System.Drawing.Size(68, 68);
            this.btnLoadRequests.TabIndex = 100;
            this.btnLoadRequests.Text = "load requests";
            this.btnLoadRequests.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadRequests.UseVisualStyleBackColor = true;
            this.btnLoadRequests.Click += new System.EventHandler(this.btnLoadRequests_Click);
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnSaveLogtoFile);
            this.grpAction.Controls.Add(this.btnSaveLogtoClipboard);
            this.grpAction.Controls.Add(this.lblLog);
            this.grpAction.Controls.Add(this.lvLog);
            this.grpAction.Controls.Add(this.btnReadCollection);
            this.grpAction.Controls.Add(this.lvValues);
            this.grpAction.Location = new System.Drawing.Point(15, 331);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(656, 334);
            this.grpAction.TabIndex = 88;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Results";
            // 
            // btnSaveLogtoFile
            // 
            this.btnSaveLogtoFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLogtoFile.Image")));
            this.btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLogtoFile.Location = new System.Drawing.Point(6, 256);
            this.btnSaveLogtoFile.Name = "btnSaveLogtoFile";
            this.btnSaveLogtoFile.Size = new System.Drawing.Size(68, 68);
            this.btnSaveLogtoFile.TabIndex = 105;
            this.btnSaveLogtoFile.Text = "save log to file";
            this.btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLogtoFile.UseVisualStyleBackColor = true;
            this.btnSaveLogtoFile.Click += new System.EventHandler(this.btnSaveLogtoFile_Click);
            // 
            // btnSaveLogtoClipboard
            // 
            this.btnSaveLogtoClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLogtoClipboard.Image")));
            this.btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLogtoClipboard.Location = new System.Drawing.Point(6, 182);
            this.btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard";
            this.btnSaveLogtoClipboard.Size = new System.Drawing.Size(68, 68);
            this.btnSaveLogtoClipboard.TabIndex = 104;
            this.btnSaveLogtoClipboard.Text = "copy log in clipboard";
            this.btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLogtoClipboard.UseVisualStyleBackColor = true;
            this.btnSaveLogtoClipboard.Click += new System.EventHandler(this.btnSaveLogtoClipboard_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(98, 166);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(90, 13);
            this.lblLog.TabIndex = 39;
            this.lblLog.Text = "Diagnostic output";
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLog.Location = new System.Drawing.Point(91, 182);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(550, 140);
            this.lvLog.TabIndex = 98;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 1000;
            // 
            // btnReadCollection
            // 
            this.btnReadCollection.Image = ((System.Drawing.Image)(resources.GetObject("btnReadCollection.Image")));
            this.btnReadCollection.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReadCollection.Location = new System.Drawing.Point(6, 18);
            this.btnReadCollection.Name = "btnReadCollection";
            this.btnReadCollection.Size = new System.Drawing.Size(68, 68);
            this.btnReadCollection.TabIndex = 103;
            this.btnReadCollection.Text = "read collection";
            this.btnReadCollection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReadCollection.UseVisualStyleBackColor = true;
            this.btnReadCollection.Click += new System.EventHandler(this.btnReadCollection_Click);
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
            this.lvValues.Location = new System.Drawing.Point(91, 18);
            this.lvValues.Name = "lvValues";
            this.lvValues.Size = new System.Drawing.Size(550, 140);
            this.lvValues.TabIndex = 102;
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
            // panelStatusStrip
            // 
            this.panelStatusStrip.AutoSize = true;
            this.panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatusStrip.Controls.Add(this.statusStrip);
            this.panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatusStrip.Location = new System.Drawing.Point(0, 742);
            this.panelStatusStrip.Name = "panelStatusStrip";
            this.panelStatusStrip.Size = new System.Drawing.Size(678, 24);
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
            this.statusStrip.Size = new System.Drawing.Size(676, 22);
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
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(588, 668);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 68);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "close window";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReadCollectionBox
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 766);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelStatusStrip);
            this.Controls.Add(this.btnSaveRequests);
            this.Controls.Add(this.btnLoadRequests);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.grpAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadCollectionBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReadCollectionBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReadCollectionBox_FormClosing);
            this.Load += new System.EventHandler(this.ReadCollectionBox_Load);
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.panelStatusStrip.ResumeLayout(false);
            this.panelStatusStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblQuantity;
        internal System.Windows.Forms.TextBox txtQuantity;
        internal System.Windows.Forms.Label lblReadAddress;
        internal System.Windows.Forms.Label lblBit;
        internal System.Windows.Forms.TextBox txtBit;
        internal System.Windows.Forms.TextBox txtReadAddress;
        internal System.Windows.Forms.Label lblFunction;
        internal System.Windows.Forms.ComboBox cmbFunction;
        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.GroupBox grpAction;
        internal System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceGUID;
        internal System.Windows.Forms.ComboBox cmbByteOrder;
        private System.Windows.Forms.Label lblByteOrder;
        private System.Windows.Forms.Label lblSlaveID;
        internal System.Windows.Forms.ComboBox cmbSlaveID;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader colDummy;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.ListView lvRequests;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnReadCollection;
        private System.Windows.Forms.Label lblDataType;
        internal System.Windows.Forms.ComboBox cmbDataType;
        internal System.Windows.Forms.TextBox txtRequestKey;
        internal System.Windows.Forms.Label lblRequestKey;
        private System.Windows.Forms.Button btnRemoveRequest;
        private System.Windows.Forms.Button btnLoadRequests;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveRequests;
        private System.Windows.Forms.Button btnSaveLogtoClipboard;
        private System.Windows.Forms.Button btnSaveLogtoFile;
        private System.Windows.Forms.TextBox txtInfoRCB;

    }
}
