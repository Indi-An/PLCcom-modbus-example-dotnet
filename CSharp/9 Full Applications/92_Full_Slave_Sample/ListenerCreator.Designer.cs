namespace PLCcomMB_Slave_Example_CSharp
{
    partial class ListenerCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListenerCreator));
            this.grbAddress = new System.Windows.Forms.GroupBox();
            this.btnAbort = new System.Windows.Forms.Button();
            this.grbListenerSettings = new System.Windows.Forms.GroupBox();
            this.grbSerialSettings = new System.Windows.Forms.Panel();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.cmbStopbits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.cmbHandshake = new System.Windows.Forms.ComboBox();
            this.cmbBaudrate = new System.Windows.Forms.ComboBox();
            this.lblLocalPort = new System.Windows.Forms.Label();
            this.lblHandshake = new System.Windows.Forms.Label();
            this.grbIPSettings = new System.Windows.Forms.Panel();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.lblSerialPort = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblBaudrate = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtListenerName = new System.Windows.Forms.TextBox();
            this.lblListenerName = new System.Windows.Forms.Label();
            this.cmbConnectionType = new System.Windows.Forms.ComboBox();
            this.txtInfoCreateListener = new System.Windows.Forms.TextBox();
            this.grbAddress.SuspendLayout();
            this.grbListenerSettings.SuspendLayout();
            this.grbSerialSettings.SuspendLayout();
            this.grbIPSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbAddress
            // 
            this.grbAddress.Controls.Add(this.btnAbort);
            this.grbAddress.Controls.Add(this.grbListenerSettings);
            this.grbAddress.Controls.Add(this.lblConnectionType);
            this.grbAddress.Controls.Add(this.btnAccept);
            this.grbAddress.Controls.Add(this.txtListenerName);
            this.grbAddress.Controls.Add(this.lblListenerName);
            this.grbAddress.Controls.Add(this.cmbConnectionType);
            this.grbAddress.Location = new System.Drawing.Point(12, 61);
            this.grbAddress.Name = "grbAddress";
            this.grbAddress.Size = new System.Drawing.Size(330, 403);
            this.grbAddress.TabIndex = 97;
            this.grbAddress.TabStop = false;
            // 
            // btnAbort
            // 
            this.btnAbort.Image = ((System.Drawing.Image)(resources.GetObject("btnAbort.Image")));
            this.btnAbort.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAbort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAbort.Location = new System.Drawing.Point(252, 324);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(68, 68);
            this.btnAbort.TabIndex = 117;
            this.btnAbort.Text = "abort";
            this.btnAbort.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // grbListenerSettings
            // 
            this.grbListenerSettings.Controls.Add(this.grbSerialSettings);
            this.grbListenerSettings.Controls.Add(this.lblLocalPort);
            this.grbListenerSettings.Controls.Add(this.lblHandshake);
            this.grbListenerSettings.Controls.Add(this.grbIPSettings);
            this.grbListenerSettings.Controls.Add(this.lblSerialPort);
            this.grbListenerSettings.Controls.Add(this.lblStopBits);
            this.grbListenerSettings.Controls.Add(this.lblBaudrate);
            this.grbListenerSettings.Controls.Add(this.lblParity);
            this.grbListenerSettings.Controls.Add(this.lblDataBits);
            this.grbListenerSettings.Location = new System.Drawing.Point(7, 83);
            this.grbListenerSettings.Name = "grbListenerSettings";
            this.grbListenerSettings.Size = new System.Drawing.Size(313, 235);
            this.grbListenerSettings.TabIndex = 45;
            this.grbListenerSettings.TabStop = false;
            this.grbListenerSettings.Text = "listener settings";
            // 
            // grbSerialSettings
            // 
            this.grbSerialSettings.Controls.Add(this.cmbSerialPort);
            this.grbSerialSettings.Controls.Add(this.cmbStopbits);
            this.grbSerialSettings.Controls.Add(this.cmbParity);
            this.grbSerialSettings.Controls.Add(this.cmbDataBits);
            this.grbSerialSettings.Controls.Add(this.cmbHandshake);
            this.grbSerialSettings.Controls.Add(this.cmbBaudrate);
            this.grbSerialSettings.Location = new System.Drawing.Point(136, 56);
            this.grbSerialSettings.Name = "grbSerialSettings";
            this.grbSerialSettings.Size = new System.Drawing.Size(171, 172);
            this.grbSerialSettings.TabIndex = 52;
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(18, 3);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(144, 21);
            this.cmbSerialPort.TabIndex = 40;
            // 
            // cmbStopbits
            // 
            this.cmbStopbits.FormattingEnabled = true;
            this.cmbStopbits.Location = new System.Drawing.Point(18, 114);
            this.cmbStopbits.Name = "cmbStopbits";
            this.cmbStopbits.Size = new System.Drawing.Size(144, 21);
            this.cmbStopbits.TabIndex = 42;
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(18, 60);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(144, 21);
            this.cmbParity.TabIndex = 41;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Location = new System.Drawing.Point(18, 87);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(144, 21);
            this.cmbDataBits.TabIndex = 45;
            // 
            // cmbHandshake
            // 
            this.cmbHandshake.FormattingEnabled = true;
            this.cmbHandshake.Location = new System.Drawing.Point(18, 141);
            this.cmbHandshake.Name = "cmbHandshake";
            this.cmbHandshake.Size = new System.Drawing.Size(144, 21);
            this.cmbHandshake.TabIndex = 46;
            // 
            // cmbBaudrate
            // 
            this.cmbBaudrate.FormattingEnabled = true;
            this.cmbBaudrate.Location = new System.Drawing.Point(18, 32);
            this.cmbBaudrate.Name = "cmbBaudrate";
            this.cmbBaudrate.Size = new System.Drawing.Size(144, 21);
            this.cmbBaudrate.TabIndex = 38;
            // 
            // lblLocalPort
            // 
            this.lblLocalPort.Location = new System.Drawing.Point(15, 28);
            this.lblLocalPort.Name = "lblLocalPort";
            this.lblLocalPort.Size = new System.Drawing.Size(117, 13);
            this.lblLocalPort.TabIndex = 30;
            this.lblLocalPort.Text = "local port (default 502)";
            this.lblLocalPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHandshake
            // 
            this.lblHandshake.Location = new System.Drawing.Point(72, 200);
            this.lblHandshake.Name = "lblHandshake";
            this.lblHandshake.Size = new System.Drawing.Size(60, 13);
            this.lblHandshake.TabIndex = 50;
            this.lblHandshake.Text = "handshake";
            this.lblHandshake.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grbIPSettings
            // 
            this.grbIPSettings.Controls.Add(this.txtLocalPort);
            this.grbIPSettings.Enabled = false;
            this.grbIPSettings.Location = new System.Drawing.Point(137, 19);
            this.grbIPSettings.Name = "grbIPSettings";
            this.grbIPSettings.Size = new System.Drawing.Size(170, 33);
            this.grbIPSettings.TabIndex = 51;
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(17, 6);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(144, 20);
            this.txtLocalPort.TabIndex = 29;
            this.txtLocalPort.Text = "502";
            // 
            // lblSerialPort
            // 
            this.lblSerialPort.Location = new System.Drawing.Point(72, 62);
            this.lblSerialPort.Name = "lblSerialPort";
            this.lblSerialPort.Size = new System.Drawing.Size(60, 13);
            this.lblSerialPort.TabIndex = 44;
            this.lblSerialPort.Text = "serial port";
            this.lblSerialPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblStopBits
            // 
            this.lblStopBits.Location = new System.Drawing.Point(72, 175);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(60, 13);
            this.lblStopBits.TabIndex = 49;
            this.lblStopBits.Text = "stop bits";
            this.lblStopBits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBaudrate
            // 
            this.lblBaudrate.Location = new System.Drawing.Point(72, 91);
            this.lblBaudrate.Name = "lblBaudrate";
            this.lblBaudrate.Size = new System.Drawing.Size(60, 13);
            this.lblBaudrate.TabIndex = 39;
            this.lblBaudrate.Text = "baudrate";
            this.lblBaudrate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblParity
            // 
            this.lblParity.Location = new System.Drawing.Point(72, 119);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(60, 13);
            this.lblParity.TabIndex = 47;
            this.lblParity.Text = "parity";
            this.lblParity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDataBits
            // 
            this.lblDataBits.Location = new System.Drawing.Point(72, 146);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(60, 13);
            this.lblDataBits.TabIndex = 48;
            this.lblDataBits.Text = "data bits";
            this.lblDataBits.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.Location = new System.Drawing.Point(22, 54);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(105, 18);
            this.lblConnectionType.TabIndex = 44;
            this.lblConnectionType.Text = "Type of Connection";
            this.lblConnectionType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAccept
            // 
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAccept.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAccept.Location = new System.Drawing.Point(178, 324);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(68, 68);
            this.btnAccept.TabIndex = 103;
            this.btnAccept.Text = "accept";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtListenerName
            // 
            this.txtListenerName.Location = new System.Drawing.Point(162, 22);
            this.txtListenerName.Name = "txtListenerName";
            this.txtListenerName.Size = new System.Drawing.Size(144, 20);
            this.txtListenerName.TabIndex = 42;
            // 
            // lblListenerName
            // 
            this.lblListenerName.Location = new System.Drawing.Point(22, 22);
            this.lblListenerName.Name = "lblListenerName";
            this.lblListenerName.Size = new System.Drawing.Size(105, 18);
            this.lblListenerName.TabIndex = 43;
            this.lblListenerName.Text = "Listenername";
            this.lblListenerName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbConnectionType
            // 
            this.cmbConnectionType.FormattingEnabled = true;
            this.cmbConnectionType.Location = new System.Drawing.Point(162, 51);
            this.cmbConnectionType.Name = "cmbConnectionType";
            this.cmbConnectionType.Size = new System.Drawing.Size(144, 21);
            this.cmbConnectionType.TabIndex = 36;
            this.cmbConnectionType.SelectedIndexChanged += new System.EventHandler(this.cmbConnectionType_SelectedIndexChanged);
            // 
            // txtInfoCreateListener
            // 
            this.txtInfoCreateListener.BackColor = System.Drawing.SystemColors.Info;
            this.txtInfoCreateListener.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfoCreateListener.Location = new System.Drawing.Point(12, 12);
            this.txtInfoCreateListener.Multiline = true;
            this.txtInfoCreateListener.Name = "txtInfoCreateListener";
            this.txtInfoCreateListener.Size = new System.Drawing.Size(330, 46);
            this.txtInfoCreateListener.TabIndex = 115;
            this.txtInfoCreateListener.Text = "Definieren Sie Listener mit dem gewünschten Verbindungstyp. \r\nSie können einem Mo" +
    "dbus-Slave mehrere verschiedene Listener hinzufügen.";
            // 
            // ListenerCreator
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 472);
            this.Controls.Add(this.txtInfoCreateListener);
            this.Controls.Add(this.grbAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListenerCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "create new listener";
            this.Load += new System.EventHandler(this.CreateListener_Load);
            this.grbAddress.ResumeLayout(false);
            this.grbAddress.PerformLayout();
            this.grbListenerSettings.ResumeLayout(false);
            this.grbSerialSettings.ResumeLayout(false);
            this.grbIPSettings.ResumeLayout(false);
            this.grbIPSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbAddress;
        internal System.Windows.Forms.Label lblHandshake;
        internal System.Windows.Forms.Label lblStopBits;
        internal System.Windows.Forms.Label lblDataBits;
        internal System.Windows.Forms.Label lblParity;
        internal System.Windows.Forms.ComboBox cmbHandshake;
        internal System.Windows.Forms.ComboBox cmbDataBits;
        internal System.Windows.Forms.Label lblSerialPort;
        internal System.Windows.Forms.ComboBox cmbStopbits;
        internal System.Windows.Forms.ComboBox cmbParity;
        internal System.Windows.Forms.ComboBox cmbSerialPort;
        internal System.Windows.Forms.Label lblBaudrate;
        internal System.Windows.Forms.ComboBox cmbBaudrate;
        internal System.Windows.Forms.TextBox txtLocalPort;
        internal System.Windows.Forms.Label lblLocalPort;
        internal System.Windows.Forms.ComboBox cmbConnectionType;
        internal System.Windows.Forms.TextBox txtListenerName;
        internal System.Windows.Forms.Label lblListenerName;
        private System.Windows.Forms.Button btnAccept;
        internal System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.TextBox txtInfoCreateListener;
        private System.Windows.Forms.Panel grbIPSettings;
        private System.Windows.Forms.GroupBox grbListenerSettings;
        private System.Windows.Forms.Panel grbSerialSettings;
        private System.Windows.Forms.Button btnAbort;
    }
}
