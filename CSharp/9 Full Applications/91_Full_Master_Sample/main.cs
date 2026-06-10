using System;
using System.Drawing;
using System.Windows.Forms;
using PLCcomModbus.Core;
using System.Xml;
using System.IO;
using System.Diagnostics;
using PLCcomModbus.Master;
using PLCcomModbus.DataAdapter;
using System.Collections.Generic;
using PLCcomModbus.Core.Security;

namespace PLCComMB_Master_Example_CSharp
{
    public partial class main : Form
    {

        #region Private member
        private ModbusMaster Device = null;
        private System.Resources.ResourceManager resources;
        private delegate void dlgtOnConnectionStateChange(object sender, eConnectionState e);
        private Timer certificateAlertTimer;
        private ToolTip certificateToolTip;
        private Color certificateManagerDefaultBackColor;
        private bool certificateAlertBlinkState;
        private bool certificateManagerOpen;
        private bool certificateManagerAutoOpened;
        #endregion

        #region Internal member
        internal static int CountOpenDialogs = 0;
        #endregion

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            try
            {
                //english ressources test
                //System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("en");
                //System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                //System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

                //set language combobox
                List<System.Globalization.CultureInfo> lisCultureInfo = new List<System.Globalization.CultureInfo>();
                if (System.Threading.Thread.CurrentThread.CurrentCulture.Parent.TwoLetterISOLanguageName == "de")
                {
                    lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("de").Parent);
                    lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("en").Parent);
                }
                else
                {
                    lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("en").Parent);
                    lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("de").Parent);
                }
                cmbLanguage.DataSource = lisCultureInfo;

                //set UI language
                SetLanguage(System.Threading.Thread.CurrentThread.CurrentCulture);
                InitializeCertificateAlert();

#if TESTAPP
                txtUser.Text = "demo";
                txtSerial.Text = "demo";
#endif

                //fill combobox with enum values
                cmbConnectionType.DataSource = Enum.GetValues(typeof(eTypeOfCommunication));
                cmbRegisterMode.DataSource = Enum.GetValues(typeof(eRegisterMode));
                cmbBaudrate.DataSource = Enum.GetValues(typeof(eBaudrate));
                cmbParity.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
                cmbDataBits.DataSource = Enum.GetValues(typeof(eDataBits));
                cmbStopbits.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));
                cmbHandshake.DataSource = Enum.GetValues(typeof(System.IO.Ports.Handshake));
                cmbNetworkAddressFamily.DataSource = Enum.GetValues(typeof(eNetworkAddressFamily));

                //set combobox default values
                cmbParity.SelectedItem = System.IO.Ports.Parity.None;
                cmbDataBits.SelectedItem = eDataBits.DataBits8;
                cmbStopbits.SelectedItem = System.IO.Ports.StopBits.One;
                cmbHandshake.SelectedItem = System.IO.Ports.Handshake.None;

                string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                if (ports.Length > 0)
                {
                    cmbSerialPort.DataSource = ports;
                }
                else
                {
                    cmbSerialPort.Items.Clear();
                    cmbSerialPort.Text = "No serial ports detected";
                }

                LoadSettingsFromFile();
                CreateAndInitDevice();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SetLanguage(System.Globalization.CultureInfo culture)
        {
            //set UI-Controls with actual CultureInfo information

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture.TwoLetterISOLanguageName);
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture.TwoLetterISOLanguageName);

            //init ResourceManager
            if (resources == null)
            {
                resources = new System.Resources.ResourceManager(this.GetType().Namespace + ".Properties.Resources", this.GetType().Assembly);
            }

            //set controls 
            this.txtWarning.Text = resources.GetString("txtWarning_Text");
            this.Text = resources.GetString("main_Text");
            this.btnEditConnectionSettings.Text = resources.GetString("btnEditConnectionSettings_Text");
            this.btnSaveConnectionSettings.Text = resources.GetString("btnSaveConnectionSettings_Text");
            this.lblConnectionType.Text = resources.GetString("lblConnectionType_Text");
            this.lblSerialCode.Text = resources.GetString("lblSerialCode_Text");
            this.grbFunctions.Text = resources.GetString("grbFunctions_Text");
            this.btnOtherFunctions.Text = resources.GetString("btnOtherFunctions_Text");
            this.btnClose.Text = resources.GetString("btnClose_Text");
            this.lblmaxIdleTime.Text = resources.GetString("lblmaxIdleTime_Text");
            this.btnReadWriteModbus.Text = resources.GetString("btnReadWriteModbus_Text");
            this.btnReadCollection.Text = resources.GetString("btnReadCollection_Text");
            this.lblRegisterMode.Text = resources.GetString("lblRegisterMode_Text");
            this.lblLanguage.Text = resources.GetString("lblLanguage_Text");
            this.lblNetworkAddressFamily.Text = resources.GetString("lblNetworkAddressFamily_Text");
            SetCertificateManagerText();
            if (certificateToolTip != null)
                UpdateCertificateAlertState();
        }

        private void SetCertificateManagerText()
        {
            if (btnCertificateManager == null)
                return;

            btnCertificateManager.Text = GetResourceString("btnCertificateManager_Text", "show\r\ncertificates");
        }

        private string GetResourceString(string name, string fallback)
        {
            if (resources == null)
                return fallback;

            string value = resources.GetString(name);
            return string.IsNullOrEmpty(value) ? fallback : value;
        }

        private void InitializeCertificateAlert()
        {
            certificateManagerDefaultBackColor = btnCertificateManager.BackColor;
            certificateToolTip = new ToolTip();
            certificateAlertTimer = new Timer();
            certificateAlertTimer.Interval = 550;
            certificateAlertTimer.Tick += certificateAlertTimer_Tick;
            UpdateCertificateAlertState();
        }

        private void certificateAlertTimer_Tick(object sender, EventArgs e)
        {
            certificateAlertBlinkState = !certificateAlertBlinkState;
            btnCertificateManager.UseVisualStyleBackColor = false;
            btnCertificateManager.BackColor = certificateAlertBlinkState ? Color.LightCoral : Color.MistyRose;
        }

        private void UpdateCertificateAlertState()
        {
            int rejectedCertificateCount = CountRejectedCertificates();
            if (rejectedCertificateCount > 0)
            {
                certificateToolTip.SetToolTip(
                    btnCertificateManager,
                    string.Format(GetResourceString("btnCertificateManager_RejectedToolTip_Text", "{0} rejected SecureTCP certificate(s) require review."), rejectedCertificateCount));
                if (!certificateAlertTimer.Enabled)
                    certificateAlertTimer.Start();
            }
            else
            {
                if (certificateAlertTimer.Enabled)
                    certificateAlertTimer.Stop();

                certificateAlertBlinkState = false;
                btnCertificateManager.UseVisualStyleBackColor = true;
                btnCertificateManager.BackColor = certificateManagerDefaultBackColor;
                certificateToolTip.SetToolTip(
                    btnCertificateManager,
                    GetResourceString("btnCertificateManager_ToolTip_Text", "Open SecureTCP certificate manager."));
            }
        }

        private int CountRejectedCertificates()
        {
            try
            {
                SecureModbusPkiStore pkiStore = SecureTcpExampleOptions.CreatePkiStore();
                if (!Directory.Exists(pkiStore.RejectedCertificatesPath))
                    return 0;

                int count = 0;
                foreach (string fileName in Directory.GetFiles(pkiStore.RejectedCertificatesPath))
                {
                    if (HasCertificateExtension(fileName))
                        count++;
                }

                return count;
            }
            catch
            {
                return 0;
            }
        }

        private static bool HasCertificateExtension(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            return string.Equals(extension, ".der", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".cer", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".cert", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".crt", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".pem", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".pfx", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".p12", StringComparison.OrdinalIgnoreCase);
        }

        private SecureModbusTcpOptions PrepareSecureTcpOptionsForUi(SecureModbusTcpOptions options)
        {
            if (options != null && options.PkiStore != null)
                options.PkiStore.CertificateStored += pkiStore_CertificateStored;

            return options;
        }

        private void pkiStore_CertificateStored(object sender, SecureModbusPkiCertificateStoredEventArgs e)
        {
            if (e == null || e.StoreKind != SecureModbusPkiStoreKind.Rejected)
                return;

            if (IsDisposed)
                return;

            try
            {
                MethodInvoker action = delegate { OnRejectedCertificateStored(e.IsNewFile); };
                if (InvokeRequired)
                    BeginInvoke(action);
                else
                    action();
            }
            catch
            {
                // UI notification must not change the SecureTCP certificate validation result.
            }
        }

        private void OnRejectedCertificateStored(bool isNewFile)
        {
            UpdateCertificateAlertState();
            if (!isNewFile || certificateManagerOpen || certificateManagerAutoOpened)
                return;

            certificateManagerAutoOpened = true;
            OpenCertificateManager();
        }

        [DebuggerStepThrough()]
        private void LoadSettingsFromFile()
        {
            try
            {

                string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusMaster", "PLCcomModbusCoreExSettings.xml");


                // Check if the directory exists, if not, create it
                string directoryPath = Path.GetDirectoryName(targetFile);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (File.Exists(targetFile))
                {

                    using (XmlTextReader reader = new XmlTextReader(targetFile))
                    {
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element: // The node is an element.
                                    switch (reader.Name)
                                    {
                                        case "Authentication":
                                            txtUser.Text = reader.GetAttribute("user");
                                            txtSerial.Text = reader.GetAttribute("serial");
                                            break;
                                        case "Communication":
                                            if (cmbConnectionType.FindString(reader.GetAttribute("TypeOfCommunication")) > -1) cmbConnectionType.Text = reader.GetAttribute("TypeOfCommunication");
                                            if (cmbRegisterMode.FindString(reader.GetAttribute("RegisterMode")) > -1) cmbRegisterMode.Text = reader.GetAttribute("RegisterMode");
                                            if (cmbBaudrate.FindString(reader.GetAttribute("Baudrate")) > -1) cmbBaudrate.Text = reader.GetAttribute("Baudrate");
                                            if (cmbSerialPort.FindString(reader.GetAttribute("SerialPort")) > -1) cmbSerialPort.Text = reader.GetAttribute("SerialPort");
                                            if (cmbParity.FindString(reader.GetAttribute("Parity")) > -1) cmbParity.Text = reader.GetAttribute("Parity");
                                            if (cmbDataBits.FindString(reader.GetAttribute("DataBits")) > -1) cmbDataBits.Text = reader.GetAttribute("DataBits");
                                            if (cmbStopbits.FindString(reader.GetAttribute("Stopbits")) > -1) cmbStopbits.Text = reader.GetAttribute("Stopbits");
                                            if (cmbHandshake.FindString(reader.GetAttribute("Handshake")) > -1) cmbHandshake.Text = reader.GetAttribute("Handshake");
                                            if (cmbNetworkAddressFamily.FindString(reader.GetAttribute("NetworkAddressFamily")) > -1) cmbNetworkAddressFamily.Text = reader.GetAttribute("NetworkAddressFamily");
                                            txtAddressIP.Text = reader.GetAttribute("txtAddressIP");
                                            txtRemotePort.Text = reader.GetAttribute("txtRemotePort");
                                            txtLocalPort.Text = reader.GetAttribute("txtLocalPort");
                                            txtIdleTime.Text = reader.GetAttribute("txtIdleTime");
                                            txtOperationTimeout.Text = (reader.GetAttribute("txtOperationTimeout") == null ? "2000" : reader.GetAttribute("txtOperationTimeout"));
                                            chkCRCCheck.Checked = (reader.GetAttribute("chkCRCCheck") == null || reader.GetAttribute("chkCRCCheck").Equals(Boolean.TrueString) ? true : false);
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void CreateAndInitDevice()
        {

            //clean up
            if (Device != null)
            {
                if (Device.Connector != null)
                {
                    Device.Connector.OnConnectionStateChange -= new ModbusConnector.ConnectionStateChangeEventHandler(Device_OnConnectionStateChange);
                }
                Device.Dispose();
            }

            try
            {
                //create new device instance
                Device = new ModbusMaster(txtUser.Text, txtSerial.Text);

                //linking device with adapter
                switch (cmbConnectionType.SelectedValue.ToString())
                {
                    case "TCP":
                        //set tcp adapter
                        Device.SetConnector_TCP(txtAddressIP.Text, Convert.ToInt32(txtRemotePort.Text), Convert.ToInt32(txtLocalPort.Text), (eNetworkAddressFamily)cmbNetworkAddressFamily.SelectedValue);
                        break;
                    case "UDP":
                        //set udp adapter
                        Device.SetConnector_UDP(txtAddressIP.Text, Convert.ToInt32(txtRemotePort.Text), Convert.ToInt32(txtLocalPort.Text), (eNetworkAddressFamily)cmbNetworkAddressFamily.SelectedValue);
                        break;
                    case "RTU_over_TCP":
                        //set rtu over tcp adapter
                        Device.SetConnector_RTU_over_TCP(txtAddressIP.Text, Convert.ToInt32(txtRemotePort.Text), Convert.ToInt32(txtLocalPort.Text), (eNetworkAddressFamily)cmbNetworkAddressFamily.SelectedValue);
                        break;
                    case "SecureTCP":
                        //set secure tcp adapter; certificates are loaded from PLCCOM_MODBUS_SECURETCP_* environment variables
                        Device.SetConnector_SecureTCP(txtAddressIP.Text, Convert.ToInt32(txtRemotePort.Text), Convert.ToInt32(txtLocalPort.Text), (eNetworkAddressFamily)cmbNetworkAddressFamily.SelectedValue, PrepareSecureTcpOptionsForUi(SecureTcpExampleOptions.Create()));
                        break;
                    case "RTU":
                        //set rtu adapter
                        Device.SetConnector_RTU(cmbSerialPort.Text,
                                                (eBaudrate)cmbBaudrate.SelectedValue,
                                                (eDataBits)cmbDataBits.SelectedValue,
                                                (System.IO.Ports.Parity)cmbParity.SelectedValue,
                                                (System.IO.Ports.StopBits)cmbStopbits.SelectedValue,
                                                (System.IO.Ports.Handshake)cmbHandshake.SelectedValue);
                        break;
                    case "ASCII":
                        //set ascii adapter
                        Device.SetConnector_ASCII(cmbSerialPort.Text,
                                                (eBaudrate)cmbBaudrate.SelectedValue,
                                                (eDataBits)cmbDataBits.SelectedValue,
                                                (System.IO.Ports.Parity)cmbParity.SelectedValue,
                                                (System.IO.Ports.StopBits)cmbStopbits.SelectedValue,
                                                (System.IO.Ports.Handshake)cmbHandshake.SelectedValue);
                        break;
                    default:
                        MessageBox.Show(resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                }

                //set max idleTime, Standard = 10000ms
                uint MaxIdleTime = 0;
                Device.Connector.SetMaxIdleTime(uint.TryParse(txtIdleTime.Text, out MaxIdleTime) ? MaxIdleTime : 10000);

                //Set operation timeout, Standard = 2000ms
                int OperationTimeout = 0;
                Device.Connector.OperationTimeout = (int.TryParse(txtOperationTimeout.Text, out OperationTimeout) ? OperationTimeout : 2000);

                //Set crc/lcr Check
                Device.CRCCheckEnabled = chkCRCCheck.Checked;

                //Set RegisterMode >> 16-bit, 32-bit, or 64-bit register mapping; settings must match the slave.
                Device.RegisterMode = (eRegisterMode)cmbRegisterMode.SelectedValue;

                Device.Connector.OnConnectionStateChange += new ModbusConnector.ConnectionStateChangeEventHandler(Device_OnConnectionStateChange);
                lblDeviceGUID.Text = "Device Guid: " + Device.DeviceGuid.ToString();
                lblDeviceType.Text = "Adapter Type: " + Device.Connector.GetType().Name;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }


        [DebuggerStepThrough()]
        private void btnSaveConnectionSettings_Click(object sender, EventArgs e)
        {
            try
            {
                btnEditConnectionSettings.Enabled = true;
                grbFunctions.Enabled = true;
                grbAddress.Enabled = false;

                CreateAndInitDevice();

                if (btnSaveConnectionSettings.Enabled) btnSaveConnectionSettings_Click(null, null);

                string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusMaster", "PLCcomModbusCoreExSettings.xml");

                // Check if the directory exists, if not, create it
                string directoryPath = Path.GetDirectoryName(targetFile);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                //Write Settings in PlccomExSettings.xml
                using (XmlTextWriter myXmlTextWriter = new XmlTextWriter(targetFile, System.Text.Encoding.UTF8))
                {

                    myXmlTextWriter.Formatting = Formatting.Indented;
                    myXmlTextWriter.WriteStartDocument(false);
                    myXmlTextWriter.WriteStartElement("Settings");
                    myXmlTextWriter.WriteStartElement("Authentication");
                    myXmlTextWriter.WriteAttributeString("user", txtUser.Text);
                    myXmlTextWriter.WriteAttributeString("serial", txtSerial.Text);
                    myXmlTextWriter.WriteEndElement();

                    myXmlTextWriter.WriteStartElement("Communication");
                    if (cmbConnectionType.SelectedItem != null) myXmlTextWriter.WriteAttributeString("TypeOfCommunication", cmbConnectionType.SelectedItem.ToString());
                    if (cmbRegisterMode.SelectedItem != null) myXmlTextWriter.WriteAttributeString("RegisterMode", cmbRegisterMode.SelectedItem.ToString());
                    if (cmbBaudrate.SelectedItem != null) myXmlTextWriter.WriteAttributeString("Baudrate", cmbBaudrate.SelectedItem.ToString());
                    if (cmbSerialPort.SelectedItem != null) myXmlTextWriter.WriteAttributeString("SerialPort", cmbSerialPort.SelectedItem.ToString());
                    if (cmbParity.SelectedItem != null) myXmlTextWriter.WriteAttributeString("Parity", cmbParity.SelectedItem.ToString());
                    if (cmbDataBits.SelectedItem != null) myXmlTextWriter.WriteAttributeString("DataBits", cmbDataBits.SelectedItem.ToString());
                    if (cmbStopbits.SelectedItem != null) myXmlTextWriter.WriteAttributeString("Stopbits", cmbStopbits.SelectedItem.ToString());
                    if (cmbHandshake.SelectedItem != null) myXmlTextWriter.WriteAttributeString("Handshake", cmbHandshake.SelectedItem.ToString());
                    if (cmbNetworkAddressFamily.SelectedItem != null) myXmlTextWriter.WriteAttributeString("NetworkAddressFamily", cmbNetworkAddressFamily.SelectedItem.ToString());
                    myXmlTextWriter.WriteAttributeString("txtAddressIP", txtAddressIP.Text);
                    myXmlTextWriter.WriteAttributeString("txtRemotePort", txtRemotePort.Text);
                    myXmlTextWriter.WriteAttributeString("txtLocalPort", txtLocalPort.Text);
                    myXmlTextWriter.WriteAttributeString("txtIdleTime", txtIdleTime.Text);
                    myXmlTextWriter.WriteAttributeString("txtOperationTimeout", txtOperationTimeout.Text);
                    myXmlTextWriter.WriteAttributeString("chkCRCCheck", chkCRCCheck.Checked.ToString());

                    myXmlTextWriter.WriteEndElement();

                    myXmlTextWriter.WriteEndElement();
                    myXmlTextWriter.WriteEndDocument();
                    myXmlTextWriter.Flush();
                    myXmlTextWriter.Close();
                    MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine +
                                    "File: " + targetFile, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                switch ((eTypeOfCommunication)this.cmbConnectionType.SelectedValue)
                {
                    case eTypeOfCommunication.TCP:
                    case eTypeOfCommunication.RTU_over_TCP:
                    case eTypeOfCommunication.UDP:
                    case eTypeOfCommunication.SecureTCP:
                        grbIPSettings.Enabled = true;
                        grbSerialSettings.Enabled = false;
                        eTypeOfCommunication selectedCommunication = (eTypeOfCommunication)this.cmbConnectionType.SelectedValue;
                        if (selectedCommunication == eTypeOfCommunication.SecureTCP && txtRemotePort.Text == "502")
                            txtRemotePort.Text = "802";
                        else if (selectedCommunication != eTypeOfCommunication.SecureTCP && txtRemotePort.Text == "802")
                            txtRemotePort.Text = "502";
                        break;
                    case eTypeOfCommunication.RTU:
                    case eTypeOfCommunication.ASCII:
                        grbIPSettings.Enabled = false;
                        grbSerialSettings.Enabled = true;
                        break;
                    default:
                        grbIPSettings.Enabled = false;
                        grbSerialSettings.Enabled = false;
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        private void main_Activated(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Device != null)
            {
                Device.Dispose();
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (Device != null)
                Device.SetUser(txtUser.Text);
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            if (Device != null)
                Device.SetSerial(txtSerial.Text);
        }

        private void btnEditConnectionSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (CountOpenDialogs > 0)
                {
                    MessageBox.Show(resources.GetString("to_many_windows"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                btnEditConnectionSettings.Enabled = false;
                grbFunctions.Enabled = false;
                grbAddress.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Device_OnConnectionStateChange(object sender, eConnectionState e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new dlgtOnConnectionStateChange(Device_OnConnectionStateChange), new object[] { sender, e });
                }
                else
                {
                    txtDeviceState.Text = resources.GetString("State_" + e.ToString()) + (Device != null ? " " : string.Empty);
                    txtDeviceState.BackColor = (e == eConnectionState.open || e == eConnectionState.connected) ? Color.Green : Color.White;
                    txtDeviceState.ForeColor = (e == eConnectionState.open || e == eConnectionState.connected) ? Color.White : Color.Black;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReadWriteModbus_Click(object sender, EventArgs e)
        {
            CountOpenDialogs++;
            ReadWriteBox rwb = new ReadWriteBox(Device);
            rwb.Show(this);
        }

        private void btnReadCollection_Click(object sender, EventArgs e)
        {
            CountOpenDialogs++;
            ReadCollectionBox rcb = new ReadCollectionBox(Device);
            rcb.Show(this);
        }

        private void btnOtherFunctions_Click(object sender, EventArgs e)
        {
            CountOpenDialogs++;
            OtherFunctions otf = new OtherFunctions(Device);
            otf.Show(this);
        }

        private void btnCertificateManager_Click(object sender, EventArgs e)
        {
            OpenCertificateManager();
        }

        private void OpenCertificateManager()
        {
            if (certificateManagerOpen)
                return;

            certificateManagerOpen = true;
            try
            {
                using (CertificateManagerForm certificateManager = new CertificateManagerForm())
                {
                    certificateManager.ShowDialog(this);
                }
            }
            finally
            {
                certificateManagerOpen = false;
                UpdateCertificateAlertState();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change UI language
            SetLanguage((System.Globalization.CultureInfo)cmbLanguage.SelectedItem);
        }

        private void lblLanguage_Click(object sender, EventArgs e)
        {

        }
    }
}
