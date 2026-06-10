namespace PLCComMB_Master_Example_CSharp
{
    partial class OtherFunctions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherFunctions));
            this.txtResult = new System.Windows.Forms.TextBox();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cmbFunction = new System.Windows.Forms.ComboBox();
            this.lblFunction = new System.Windows.Forms.Label();
            this.lblBroadcast = new System.Windows.Forms.Label();
            this.txtInfoOF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSlaveID = new System.Windows.Forms.ComboBox();
            this.panelStatusStrip = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblDeviceType = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDeviceGUID = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSaveLogtoFile = new System.Windows.Forms.Button();
            this.btnSaveLogtoClipboard = new System.Windows.Forms.Button();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblLog = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpAction.SuspendLayout();
            this.panelStatusStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResult.Location = new System.Drawing.Point(260, 96);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(381, 68);
            this.txtResult.TabIndex = 35;
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.txtResult);
            this.grpAction.Controls.Add(this.btnExecute);
            this.grpAction.Controls.Add(this.cmbFunction);
            this.grpAction.Controls.Add(this.lblFunction);
            this.grpAction.Controls.Add(this.lblBroadcast);
            this.grpAction.Controls.Add(this.txtInfoOF);
            this.grpAction.Controls.Add(this.label2);
            this.grpAction.Controls.Add(this.cmbSlaveID);
            this.grpAction.Location = new System.Drawing.Point(12, 5);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(651, 181);
            this.grpAction.TabIndex = 98;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Action";
            // 
            // btnExecute
            // 
            this.btnExecute.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.Image")));
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExecute.Location = new System.Drawing.Point(6, 98);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(68, 68);
            this.btnExecute.TabIndex = 106;
            this.btnExecute.Text = "execute function";
            this.btnExecute.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cmbFunction
            // 
            this.cmbFunction.FormattingEnabled = true;
            this.cmbFunction.Location = new System.Drawing.Point(73, 19);
            this.cmbFunction.Name = "cmbFunction";
            this.cmbFunction.Size = new System.Drawing.Size(164, 21);
            this.cmbFunction.TabIndex = 76;
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(8, 23);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(48, 13);
            this.lblFunction.TabIndex = 77;
            this.lblFunction.Text = "Function";
            // 
            // lblBroadcast
            // 
            this.lblBroadcast.AutoSize = true;
            this.lblBroadcast.ForeColor = System.Drawing.Color.Red;
            this.lblBroadcast.Location = new System.Drawing.Point(70, 70);
            this.lblBroadcast.Name = "lblBroadcast";
            this.lblBroadcast.Size = new System.Drawing.Size(55, 13);
            this.lblBroadcast.TabIndex = 75;
            this.lblBroadcast.Text = "Broadcast";
            // 
            // txtInfoOF
            // 
            this.txtInfoOF.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfoOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfoOF.Location = new System.Drawing.Point(260, 19);
            this.txtInfoOF.Multiline = true;
            this.txtInfoOF.Name = "txtInfoOF";
            this.txtInfoOF.Size = new System.Drawing.Size(381, 48);
            this.txtInfoOF.TabIndex = 115;
            this.txtInfoOF.Text = " In diesem Fenster können spezielle Modbusfunktionen getestet werden.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Slave ID";
            // 
            // cmbSlaveID
            // 
            this.cmbSlaveID.FormattingEnabled = true;
            this.cmbSlaveID.Location = new System.Drawing.Point(73, 46);
            this.cmbSlaveID.Name = "cmbSlaveID";
            this.cmbSlaveID.Size = new System.Drawing.Size(164, 21);
            this.cmbSlaveID.TabIndex = 73;
            this.cmbSlaveID.SelectedIndexChanged += new System.EventHandler(this.cmbSlaveID_SelectedIndexChanged);
            // 
            // panelStatusStrip
            // 
            this.panelStatusStrip.AutoSize = true;
            this.panelStatusStrip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelStatusStrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatusStrip.Controls.Add(this.statusStrip);
            this.panelStatusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatusStrip.Location = new System.Drawing.Point(0, 438);
            this.panelStatusStrip.Name = "panelStatusStrip";
            this.panelStatusStrip.Size = new System.Drawing.Size(670, 24);
            this.panelStatusStrip.TabIndex = 101;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDeviceType,
            this.lblDeviceGUID});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(668, 22);
            this.statusStrip.TabIndex = 94;
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
            // btnSaveLogtoFile
            // 
            this.btnSaveLogtoFile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLogtoFile.Image")));
            this.btnSaveLogtoFile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLogtoFile.Location = new System.Drawing.Point(18, 288);
            this.btnSaveLogtoFile.Name = "btnSaveLogtoFile";
            this.btnSaveLogtoFile.Size = new System.Drawing.Size(68, 68);
            this.btnSaveLogtoFile.TabIndex = 119;
            this.btnSaveLogtoFile.Text = "save log to file";
            this.btnSaveLogtoFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLogtoFile.UseVisualStyleBackColor = true;
            this.btnSaveLogtoFile.Click += new System.EventHandler(this.btnSaveLogtoFile_Click);
            // 
            // btnSaveLogtoClipboard
            // 
            this.btnSaveLogtoClipboard.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLogtoClipboard.Image")));
            this.btnSaveLogtoClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSaveLogtoClipboard.Location = new System.Drawing.Point(18, 214);
            this.btnSaveLogtoClipboard.Name = "btnSaveLogtoClipboard";
            this.btnSaveLogtoClipboard.Size = new System.Drawing.Size(68, 68);
            this.btnSaveLogtoClipboard.TabIndex = 118;
            this.btnSaveLogtoClipboard.Text = "copy log in clipboard";
            this.btnSaveLogtoClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveLogtoClipboard.UseVisualStyleBackColor = true;
            this.btnSaveLogtoClipboard.Click += new System.EventHandler(this.btnSaveLogtoClipboard_Click);
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvLog.Location = new System.Drawing.Point(103, 214);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(550, 142);
            this.lvLog.TabIndex = 117;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 1000;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(100, 198);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(90, 13);
            this.lblLog.TabIndex = 116;
            this.lblLog.Text = "Diagnostic output";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.Location = new System.Drawing.Point(585, 362);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 68);
            this.btnClose.TabIndex = 120;
            this.btnClose.Text = "close window";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // OtherFunctions
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 462);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveLogtoFile);
            this.Controls.Add(this.btnSaveLogtoClipboard);
            this.Controls.Add(this.lvLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.panelStatusStrip);
            this.Controls.Add(this.grpAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OtherFunctions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OtherFunctions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OtherFunctions_FormClosing);
            this.Load += new System.EventHandler(this.OtherFunctions_Load);
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

        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Panel panelStatusStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceType;
        private System.Windows.Forms.ToolStripStatusLabel lblDeviceGUID;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbSlaveID;
        private System.Windows.Forms.Label lblBroadcast;
        internal System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtInfoOF;
        private System.Windows.Forms.Button btnSaveLogtoFile;
        private System.Windows.Forms.Button btnSaveLogtoClipboard;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        internal System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.ComboBox cmbFunction;
        internal System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.Button btnExecute;
    }
}
