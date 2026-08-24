using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PLCcomModbus.Slave;
using PLCcomModbus.DataAdapter;
using PLCcomModbus.Core;
using System.IO.Ports;
using System.Xml;
using System.IO;
using System.Diagnostics;
using PLCcomModbus.Core.Security;

namespace PLCcomMB_Slave_Example_CSharp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            initCheckBoxArray();
        }

        #region private member

        private ModbusSlave slave = null;
        private System.Resources.ResourceManager resources = null;
        private customCheckBoxes myCheckBoxes = new customCheckBoxes();
        private Timer certificateAlertTimer;
        private ToolTip certificateToolTip;
        private Color certificateManagerDefaultBackColor;
        private bool certificateAlertBlinkState;
        private bool certificateManagerOpen;
        private bool certificateManagerAutoOpened;

        #endregion

        #region init checkboxes

        private void initCheckBoxArray()
        {
            //initialize checkbox array
            myCheckBoxes.addCheckBox(chkBit0);
            myCheckBoxes.addCheckBox(chkBit1);
            myCheckBoxes.addCheckBox(chkBit2);
            myCheckBoxes.addCheckBox(chkBit3);
            myCheckBoxes.addCheckBox(chkBit4);
            myCheckBoxes.addCheckBox(chkBit5);
            myCheckBoxes.addCheckBox(chkBit6);
            myCheckBoxes.addCheckBox(chkBit7);
            myCheckBoxes.addCheckBox(chkBit8);
            myCheckBoxes.addCheckBox(chkBit9);
            myCheckBoxes.addCheckBox(chkBit10);
            myCheckBoxes.addCheckBox(chkBit11);
            myCheckBoxes.addCheckBox(chkBit12);
            myCheckBoxes.addCheckBox(chkBit13);
            myCheckBoxes.addCheckBox(chkBit14);
            myCheckBoxes.addCheckBox(chkBit15);
            myCheckBoxes.addCheckBox(chkBit16);
            myCheckBoxes.addCheckBox(chkBit17);
            myCheckBoxes.addCheckBox(chkBit18);
            myCheckBoxes.addCheckBox(chkBit19);
            myCheckBoxes.addCheckBox(chkBit20);
            myCheckBoxes.addCheckBox(chkBit21);
            myCheckBoxes.addCheckBox(chkBit22);
            myCheckBoxes.addCheckBox(chkBit23);
            myCheckBoxes.addCheckBox(chkBit24);
            myCheckBoxes.addCheckBox(chkBit25);
            myCheckBoxes.addCheckBox(chkBit26);
            myCheckBoxes.addCheckBox(chkBit27);
            myCheckBoxes.addCheckBox(chkBit28);
            myCheckBoxes.addCheckBox(chkBit29);
            myCheckBoxes.addCheckBox(chkBit30);
            myCheckBoxes.addCheckBox(chkBit31);

        }

        #endregion

        private void SetCertificateManagerText()
        {
            if (btnCertificateManager == null)
            {
                return;
            }

            btnCertificateManager.Text = GetResourceString("btnCertificateManager_Text", "show\r\ncertificates");
        }

        private string GetResourceString(string name, string fallback)
        {
            if (resources == null)
            {
                return fallback;
            }

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
                certificateToolTip.SetToolTip(btnCertificateManager, GetResourceString("btnCertificateManager_ToolTip_Text", "Open SecureTCP certificate manager."));
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


        private void main_Load(object sender, EventArgs e)
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
            txtUser.Text = ""; // blank: the library runs for 15 minutes during a debug session
            txtSerial.Text = ""; // free trial license: https://www.indi-an.com/en/plccom/modbus/modbus-download/
#endif

            //init virtual lvValues listview filler 
            lvValues.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(lvValues_RetrieveVirtualItem);

            //set DataSource to comboboxes
            cmbRegisterMode.DataSource = Enum.GetValues(typeof(eRegisterMode));
            cmbLogLevel.DataSource = Enum.GetValues(typeof(eLogLevel));
            cmbByteOrder.DataSource = Enum.GetValues(typeof(eByteOrder));

            //init cmbSlaveID and set DataSource to combobox
            List<object> lisSlaveID = new List<object>();
            for (int i = 1; i < 248; i++) { lisSlaveID.Add(i); }
            cmbSlaveID.DataSource = lisSlaveID;
            cmbSlaveID.SelectedItem = 1;

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
            this.Text = resources.GetString("main_Text");
            this.lblSerialCode.Text = resources.GetString("lblSerialCode_Text");
            this.grbListener.Text = resources.GetString("grbListener_Text");
            this.grbSlaveSettings.Text = resources.GetString("grbSlaveSettings_Text");
            this.lblByteOrder.Text = resources.GetString("lblByteOrder_Text");
            this.grbSupportedFunctions.Text = resources.GetString("grbSupportedFunctions_Text");
            this.grbStatistics.Text = resources.GetString("grbStatistics_Text");
            this.lblIncomingBytes.Text = resources.GetString("lblIncomingBytes_Text");
            this.lblOutgoingBytes.Text = resources.GetString("lblOutgoingBytes_Text");
            this.lblIncomingRequests.Text = resources.GetString("lblIncomingRequests_Text");
            this.lblIncorrectRequests.Text = resources.GetString("lblIncorrectRequests_Text");
            this.lblUnparseableRequests.Text = resources.GetString("lblUnparseableRequests_Text");
            this.grbDataStore.Text = resources.GetString("grbDataStore_Text");
            this.grbAddressType.Text = resources.GetString("grbAddressType_Text");
            this.grbValues.Text = resources.GetString("grbValues_Text");
            this.lblAddress.Text = resources.GetString("lblAddress_Text");
            this.lblValue.Text = resources.GetString("lblValue_Text");
            this.btnSetValue.Text = resources.GetString("btnSetValue_Text");
            this.colAddress.Text = resources.GetString("colAddress_Text");
            this.colValue.Text = resources.GetString("colValue_Text");
            this.colName.Text = resources.GetString("colName_Text");
            this.colType.Text = resources.GetString("colType_Text");
            this.colParameter.Text = resources.GetString("colParameter_Text");
            this.grbLog.Text = resources.GetString("grbLog_Text");
            this.chkLogging.Text = resources.GetString("chkLogging_Text");
            this.btnCopyLogtoFile.Text = resources.GetString("btnCopySlaveLogtoFile_Text");
            this.btnCopyLogtoClipboard.Text = resources.GetString("btnSaveLogtoClipboard_Text");
            this.btnLoadSettings.Text = resources.GetString("btnLoadSettings_Text");
            this.btnSaveSettings.Text = resources.GetString("btnSaveSettings_Text");
            this.btnClose.Text = resources.GetString("btnClose_Text");
            this.btnStartSlave.Text = resources.GetString("btnStartSlave_Text");
            this.btnStopSlave.Text = resources.GetString("btnStopSlave_Text");
            this.btnAddListener.Text = resources.GetString("btnAddListener_Text");
            this.btnRemoveListener.Text = resources.GetString("btnRemoveListener_Text");
            this.lblRegisterMode.Text = resources.GetString("lblRegisterMode_Text");
            this.lblSlaveID.Text = resources.GetString("lblSlaveID_Text");
            this.lblLanguage.Text = resources.GetString("lblLanguage_Text");
            SetCertificateManagerText();
            if (certificateToolTip != null)
            {
                UpdateCertificateAlertState();
            }
        }

        private void btnStartSlave_Click(object sender, EventArgs e)
        {
            try
            {
                lvLog.Items.Clear();

                //create new modbus slave
                slave = new ModbusSlave(txtUser.Text,
                                        txtSerial.Text,
                                        (int)cmbSlaveID.SelectedItem,
                                        (eRegisterMode)cmbRegisterMode.SelectedItem,
                                        (eByteOrder)cmbByteOrder.SelectedItem);

                lvValues.VirtualListSize = slave.GetMaxCountOfCoils();

                //adding slave events
                slave.OnPortStateChange += Slave_OnPortStateChange;
                slave.OnIncomingLogEntry += Slave_OnIncomingLogEntry;
                slave.OnDataStoreItemChange += Slave_OnDataStoreItemChange;
                slave.OnDataStoreItemRead += Slave_OnDataStoreItemRead;

                //set controls
                btnStartSlave.Enabled = false;
                grbSlaveSettings.Enabled = false;
                grbSupportedFunctions.Enabled = true;
                grbDataStore.Enabled = true;
                rbRegisterTypeCoils.Checked = true;
                lvValues.Refresh();
                btnStopSlave.Enabled = true;
                btnAddListener.Enabled = true;
                txtValue.Text = 0.ToString();
                txtUser.Enabled = false;
                txtSerial.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopSlave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //unregister Datastore events
                slave.OnDataStoreItemChange -= Slave_OnDataStoreItemChange;
                slave.OnDataStoreItemRead -= Slave_OnDataStoreItemRead;


                //unload existing listener
                List<ModbusListener> ModbusListenerItems = new List<ModbusListener>(slave.Listener.Values);
                foreach (ModbusListener ml in ModbusListenerItems)
                {
                    slave.RemoveListener(ml.Name);
                }

                //unregister slave events
                slave.OnIncomingLogEntry -= Slave_OnIncomingLogEntry;
                slave.OnPortStateChange -= Slave_OnPortStateChange;

                slave.Listener.Clear();
                lvListener.Items.Clear();

                //dispose modbus slave
                slave.Dispose();
                slave = null;

                //set controls
                grbDataStore.Enabled = false;
                grbSlaveSettings.Enabled = true;
                grbSupportedFunctions.Enabled = false;
                btnStartSlave.Enabled = true;
                cmbRegisterMode.Enabled = true;
                cmbSlaveID.Enabled = true;
                lvValues.Refresh();
                btnStopSlave.Enabled = false;
                btnAddListener.Enabled = false;
                btnRemoveListener.Enabled = false;
                txtValue.Text = 0.ToString();
                txtUser.Enabled = true;
                txtSerial.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        delegate void OnDataStoreReadChangeCallback(List<DataStoreItemReadEventArgs> args);
        void Slave_OnDataStoreItemRead(List<DataStoreItemReadEventArgs> args)
        {
            //incoming OnDataStoreItemRead event
            if (txtIncomingBytes.InvokeRequired)
            {
                //invoke required
                OnDataStoreReadChangeCallback callInvoke = new OnDataStoreReadChangeCallback(Slave_OnDataStoreItemRead);
                txtIncomingBytes.Invoke(callInvoke, new object[] { args });
            }
            else
            {
                //get statistics
                Statistics st = slave.GetStatistics();
                txtIncomingBytes.Text = st.GetNumberIncomingBytes().ToString();
                txtOutgoingBytes.Text = st.GetNumberOutgoingBytes().ToString();
                txtIncomingRequests.Text = st.GetNumberIncomingRequests().ToString();
                txtIncorectRequests.Text = st.GetNumberIncorrectRequests().ToString();
                txtUnparseableRequests.Text = st.GetNumberUnparseableRequests().ToString();
            }
        }


        delegate void OnDataStoreItemChangeCallback(List<DataStoreItemChangeEventArgs> args);
        void Slave_OnDataStoreItemChange(List<DataStoreItemChangeEventArgs> args)
        {
            //incoming OnDataStoreItemChange event
            if (lvValues.InvokeRequired)
            {
                //invoke required
                OnDataStoreItemChangeCallback callInvoke = new OnDataStoreItemChangeCallback(Slave_OnDataStoreItemChange);
                lvValues.Invoke(callInvoke, new object[] { args });
            }
            else
            {
                //set new values in listview
                foreach (DataStoreItemChangeEventArgs e in args)
                {
                    switch (e.ModbusRegion)
                    {
                        case eModbusRegion.Coil:
                            if (!rbRegisterTypeCoils.Checked) return;
                            break;
                        case eModbusRegion.Input:
                            if (!rbRegisterTypeDiscreteInputs.Checked) return;
                            break;
                        case eModbusRegion.HoldingRegister:
                            if (!rbRegisterTypeHoldingRegister.Checked) return;
                            break;
                        case eModbusRegion.InputRegister:
                            if (!rbRegisterTypeInputRegister.Checked) return;
                            break;
                        default:
                            return;
                    }
                    string oldValue = lvValues.Items[e.Address].SubItems[2].Text;
                    lvValues.Items[e.Address].SubItems[2].Text = e.NewValue.ToString();

                    //refresh ListView only by change of values 
                    if (!e.OldValue.Equals(e.NewValue))
                    {
                        lvValues.Refresh();
                    }

                    //get statistics
                    Statistics st = slave.GetStatistics();
                    txtIncomingBytes.Text = st.GetNumberIncomingBytes().ToString();
                    txtOutgoingBytes.Text = st.GetNumberOutgoingBytes().ToString();
                    txtIncomingRequests.Text = st.GetNumberIncomingRequests().ToString();
                    txtIncorectRequests.Text = st.GetNumberIncorrectRequests().ToString();
                    txtUnparseableRequests.Text = st.GetNumberUnparseableRequests().ToString();
                }
            }
        }


        void Slave_OnPortStateChange(object sender, eConnectionState e)
        {
            //this event occurs when changing the connection status
        }


        delegate void OnIncomingLogEntryCallback(LogEntry[] e);
        [DebuggerStepThrough]
        void Slave_OnIncomingLogEntry(LogEntry[] e)
        {
            //incoming OnIncomingLogEntry event
            //loading Logentrys in ListView
            if (!chkLogging.Checked) return;

            if (lvLog.InvokeRequired)
            {
                //invoke required
                try
                {
                    OnIncomingLogEntryCallback callInvoke = new OnIncomingLogEntryCallback(Slave_OnIncomingLogEntry);
                    lvLog.Invoke(callInvoke, new object[] { e });
                }
                catch (InvalidOperationException)
                {
                    //occurs during shutdown
                }
            }
            else
            {
                //write LogEntry into listview
                foreach (LogEntry le in e)
                {
                    if (le.getLogLevel() < (eLogLevel)cmbLogLevel.SelectedItem) return;
                    lock (lvLog)
                    {
                        ListViewItem lvi = new ListViewItem(le.ToString());
                        lvi.ForeColor = le.getLogLevel().Equals(eLogLevel.Error) ? Color.Red : Color.Black;
                        lvLog.Items.Add(lvi);

                        while (lvLog.Items.Count > 100)
                        {
                            lvLog.Items.RemoveAt(0);
                        }
                        if (chkAutoScroll.Checked && lvLog.Items.Count > 1) lvLog.Items[lvLog.Items.Count - 1].EnsureVisible();
                    }
                }
            }
        }


        private void btnAddListener_Click(object sender, EventArgs e)
        {
            try
            {
                //create new listener
                ListenerCreator frmCreateListener = new ListenerCreator();
                Dictionary<string, object> Args = frmCreateListener.CreateListener(slave.Listener.Count);

                //add or replace listener
                if (Args.Count > 0 && !string.IsNullOrEmpty(Args["ListerName"].ToString()))
                {
                    switch ((eTypeOfCommunication)Args["TypeOfCommunication"])
                    {
                        case eTypeOfCommunication.TCP:
                            slave.AddOrReplaceListener_TCP(Args["ListerName"].ToString(), (int)Args["LocalPort"]);
                            break;
                        case eTypeOfCommunication.UDP:
                            slave.AddOrReplaceListener_UDP(Args["ListerName"].ToString(), (int)Args["LocalPort"]);
                            break;
                        case eTypeOfCommunication.RTU_over_TCP:
                            slave.AddOrReplaceListener_RTU_over_TCP(Args["ListerName"].ToString(), (int)Args["LocalPort"]);
                            break;
                        case eTypeOfCommunication.SecureTCP:
                            slave.AddOrReplaceListener_SecureTCP(Args["ListerName"].ToString(), (int)Args["LocalPort"], PrepareSecureTcpOptionsForUi(SecureTcpExampleOptions.Create()));
                            break;
                        case eTypeOfCommunication.RTU:
                            slave.AddOrReplaceListener_RTU((string)Args["ListerName"],
                                                  (string)Args["SerialPortName"],
                                                  (eBaudrate)Args["Baudrate"],
                                                  (eDataBits)Args["DataBits"],
                                                  (Parity)Args["Parity"],
                                                  (StopBits)Args["StopBits"],
                                                  (Handshake)Args["Handshake"]);
                            break;
                        case eTypeOfCommunication.ASCII:
                            slave.AddOrReplaceListener_ASCII((string)Args["ListerName"],
                                                  (string)Args["SerialPortName"],
                                                  (eBaudrate)Args["Baudrate"],
                                                  (eDataBits)Args["DataBits"],
                                                  (Parity)Args["Parity"],
                                                  (StopBits)Args["StopBits"],
                                                  (Handshake)Args["Handshake"]);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                RefreshListViewListener();
            }
        }

        private void btnRemoveListener_Click(object sender, EventArgs e)
        {
            try
            {
                //removed named listener
                if (lvListener.SelectedItems.Count != 0)
                {
                    slave.RemoveListener(lvListener.SelectedItems[0].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                RefreshListViewListener();
            }
        }

        private void lvListener_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enable or disable btnRemoveListener
            btnRemoveListener.Enabled = lvListener.SelectedItems.Count != 0;
        }

        private void RefreshListViewListener()
        {
            //refresh listener listview
            try
            {
                if (slave == null) return;
                Cursor = Cursors.WaitCursor;
                lvListener.BeginUpdate();
                lvListener.Items.Clear();
                foreach (ModbusListener ml in slave.Listener.Values)
                {
                    ListViewItem lvi = new ListViewItem(ml.Name);
                    lvi.SubItems.Add(ml.TypeOfCommunication.ToString());
                    lvi.SubItems.Add(ml.GetListenerParameterString());
                    lvListener.Items.Add(lvi);
                }
            }
            finally
            {
                lvListener.EndUpdate();
                Cursor = Cursors.Default;
            }
        }

        private void rbRegisterTypeCoils_CheckedChanged(object sender, EventArgs e)
        {
            //select Coils
            clearLvValues();
            lvValues.VirtualListSize = slave.GetMaxCountOfCoils();
            rbValueOn.Visible = true;
            rbValueOFF.Visible = true;
            txtValue.Visible = false;
            grbValues.Text = resources.GetString("grbValues_Text");
            myCheckBoxes.EnableBitBarComplete(false, false);
        }

        private void rbRegisterTypeDiscreteInputs_CheckedChanged(object sender, EventArgs e)
        {
            //select Discrete Inputs
            clearLvValues();
            lvValues.VirtualListSize = slave.GetMaxCountOfInputs();
            rbValueOn.Visible = true;
            rbValueOFF.Visible = true;
            txtValue.Visible = false;
            grbValues.Text = resources.GetString("grbValues_Text");
            myCheckBoxes.EnableBitBarComplete(false, false);
        }

        private void rbRegisterTypeHoldingRegister_CheckedChanged(object sender, EventArgs e)
        {
            //select Holding Register
            clearLvValues();
            lvValues.VirtualListSize = slave.GetMaxCountOfHoldingRegister();
            rbValueOn.Visible = false;
            rbValueOFF.Visible = false;
            txtValue.Visible = true;
            grbValues.Text = resources.GetString("grbValues_Text_between") + (slave.GetMaxCountOfHoldingRegister() - 1).ToString();
            eRegisterMode registerMode = (eRegisterMode)cmbRegisterMode.SelectedItem;
            myCheckBoxes.EnableBitBarComplete(registerMode == eRegisterMode._16Bit || registerMode == eRegisterMode._32Bit, registerMode == eRegisterMode._32Bit);
        }

        private void rbRegisterTypeInputRegister_CheckedChanged(object sender, EventArgs e)
        {
            //select Input Register
            clearLvValues();
            lvValues.VirtualListSize = slave.GetMaxCountOfInputRegister();
            rbValueOn.Visible = false;
            rbValueOFF.Visible = false;
            txtValue.Visible = true;
            grbValues.Text = resources.GetString("grbValues_Text_between") + (slave.GetMaxCountOfHoldingRegister() - 1).ToString();
            eRegisterMode registerMode = (eRegisterMode)cmbRegisterMode.SelectedItem;
            myCheckBoxes.EnableBitBarComplete(registerMode == eRegisterMode._16Bit || registerMode == eRegisterMode._32Bit, registerMode == eRegisterMode._32Bit);
        }

        private void clearLvValues()
        {
            //clear lvValues
            try
            {
                Cursor = Cursors.WaitCursor;
                lvValues.BeginUpdate();
                lvValues.Items.Clear();
                lvValues.Refresh();
            }
            finally
            {
                lvValues.EndUpdate();
                Cursor = Cursors.Default;
            }
        }



        void lvValues_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //load data in virtual listview mode
            if (slave != null)
            {
                e.Item = new ListViewItem();
                e.Item.SubItems.Add(e.ItemIndex.ToString());
                object value = null;

                ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem();
                if (rbRegisterTypeCoils.Checked) value = slave.GetValue((ushort)e.ItemIndex, eModbusRegion.Coil);
                else if (rbRegisterTypeDiscreteInputs.Checked) value = slave.GetValue((ushort)e.ItemIndex, eModbusRegion.Input);
                else if (rbRegisterTypeHoldingRegister.Checked) value = slave.GetValue((ushort)e.ItemIndex, eModbusRegion.HoldingRegister);
                else if (rbRegisterTypeInputRegister.Checked) value = slave.GetValue((ushort)e.ItemIndex, eModbusRegion.InputRegister);
                if (value != null)
                {
                    e.Item.ForeColor = value is bool && (bool)value == true ? Color.Blue : Color.Black;
                    lvsi.Text = value.ToString();
                    e.Item.SubItems.Add(lvsi);
                }
                else
                {
                    e.Item = new ListViewItem();
                    e.Item.SubItems.Add(e.ItemIndex.ToString());
                    e.Item.SubItems.Add("value is null");
                }

            }
            else
            {
                e.Item = new ListViewItem();
                e.Item.SubItems.Add(e.ItemIndex.ToString());
                e.Item.SubItems.Add(resources.GetString("slave_is_null"));
            }
        }

        private void btnSetValue_Click(object sender, EventArgs e)
        {
            try
            {
                //set value in datastore to desired value
                if (slave == null)
                {
                    MessageBox.Show(resources.GetString("slave_is_null"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (rbRegisterTypeCoils.Checked) slave.SetValue(ushort.Parse(txtAddress.Text), eModbusRegion.Coil, rbValueOn.Checked ? true : false);
                else if (rbRegisterTypeDiscreteInputs.Checked) slave.SetValue(ushort.Parse(txtAddress.Text), eModbusRegion.Input, rbValueOn.Checked ? true : false);
                else if (rbRegisterTypeHoldingRegister.Checked)
                {
                    switch ((eRegisterMode)cmbRegisterMode.SelectedItem)
                    {
                        case eRegisterMode._16Bit:
                            //16Bit = ushort
                            slave.SetValue(ushort.Parse(txtAddress.Text), eModbusRegion.HoldingRegister, ushort.Parse(txtValue.Text));
                            break;
                        case eRegisterMode._32Bit:
                            //32Bit = uint
                            slave.SetValue(ushort.Parse(txtAddress.Text), eModbusRegion.HoldingRegister, uint.Parse(txtValue.Text));
                            break;
                        case eRegisterMode._64Bit:
                            //64Bit = ulong
                            slave.SetValue(ushort.Parse(txtAddress.Text), eModbusRegion.HoldingRegister, ulong.Parse(txtValue.Text));
                            break;
                        default:
                            break;
                    }

                }
                else if (rbRegisterTypeInputRegister.Checked)
                {
                    switch ((eRegisterMode)cmbRegisterMode.SelectedItem)
                    {
                        case eRegisterMode._16Bit:
                            //16Bit = ushort
                            slave.SetValue(ushort.Parse(txtAddress.Text), eModbusRegion.InputRegister, ushort.Parse(txtValue.Text));
                            break;
                        case eRegisterMode._32Bit:
                            //32Bit = uint
                            slave.SetValue(ushort.Parse(txtAddress.Text), eModbusRegion.InputRegister, uint.Parse(txtValue.Text));
                            break;
                        case eRegisterMode._64Bit:
                            //64Bit = ulong
                            slave.SetValue(ushort.Parse(txtAddress.Text), eModbusRegion.InputRegister, ulong.Parse(txtValue.Text));
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            //check textbox to numeric values
            if (CheckAddressField(txtAddress.Text, lvValues.Items.Count))
            {
                txtAddress.BackColor = SystemColors.Window;
                lvValues.Items[int.Parse(txtAddress.Text)].EnsureVisible();
            }
            else
            {
                txtAddress.BackColor = Color.Red;
            }

            if (CheckAddressField(txtAddress.Text, lvValues.Items.Count) &&
               CheckValueField(txtValue.Text))
            {
                btnSetValue.Enabled = true;
            }
            else
            {
                btnSetValue.Enabled = false;
            }
        }


        private void txtValue_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtValue.Text))
            {
                txtValue.Text = "0";
            }
            //check textbox to numeric values
            if (CheckValueField(txtValue.Text))
            {
                txtValue.BackColor = SystemColors.Window;

                switch ((eRegisterMode)cmbRegisterMode.SelectedItem)
                {
                    case eRegisterMode._16Bit:
                        myCheckBoxes.SetCheckBoxesfromValue(ushort.Parse(txtValue.Text));
                        break;
                    case eRegisterMode._32Bit:
                        myCheckBoxes.SetCheckBoxesfromValue(uint.Parse(txtValue.Text));
                        break;
                    case eRegisterMode._64Bit:
                        myCheckBoxes.SetBitBarComplete(false);
                        break;
                }
            }
            else
            {
                txtValue.BackColor = Color.Red;
            }

            if (CheckAddressField(txtAddress.Text, lvValues.Items.Count) &&
               CheckValueField(txtValue.Text))
            {
                btnSetValue.Enabled = true;
            }
            else
            {
                btnSetValue.Enabled = false;
            }
        }

        private bool CheckAddressField(string text, int MaxAddress)
        {
            //check AddressField on allowed values
            ushort u;
            if (!string.IsNullOrEmpty(text) && ushort.TryParse(text, out u))
            {
                return u < MaxAddress;
            }
            else
                return false;
        }

        private bool CheckValueField(string text)
        {
            //check ValueField on allowed values
            try
            {
                if (rbRegisterTypeCoils.Checked || rbRegisterTypeDiscreteInputs.Checked)
                {
                    return true;
                }
                else if (rbRegisterTypeHoldingRegister.Checked || rbRegisterTypeInputRegister.Checked)
                {
                    switch ((eRegisterMode)cmbRegisterMode.SelectedItem)
                    {
                        case eRegisterMode._16Bit:
                            //16Bit = ushort
                            ushort u;
                            return !string.IsNullOrEmpty(text) && ushort.TryParse(text, out u);
                        case eRegisterMode._32Bit:
                            //32Bit = uint
                            uint i;
                            return !string.IsNullOrEmpty(text) && uint.TryParse(text, out i);
                        case eRegisterMode._64Bit:
                            //64Bit = ulong
                            ulong l;
                            return !string.IsNullOrEmpty(text) && ulong.TryParse(text, out l);
                        default:
                            return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void lvValues_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set value fields from lvValues.SelectedItem
            if (lvValues.SelectedIndices.Count > 0)
            {
                txtAddress.Text = lvValues.SelectedIndices[0].ToString();
                if (rbRegisterTypeCoils.Checked)
                {
                    if ((bool)slave.GetValue((ushort)lvValues.SelectedIndices[0], eModbusRegion.Coil))
                    {
                        rbValueOn.Checked = true;
                    }
                    else
                    {
                        rbValueOFF.Checked = true;
                    }
                }
                else if (rbRegisterTypeDiscreteInputs.Checked)
                {
                    if ((bool)slave.GetValue((ushort)lvValues.SelectedIndices[0], eModbusRegion.Input))
                    {
                        rbValueOn.Checked = true;
                    }
                    else
                    {
                        rbValueOFF.Checked = true;
                    }
                }
                else if (rbRegisterTypeHoldingRegister.Checked) txtValue.Text = slave.GetValue((ushort)lvValues.SelectedIndices[0], eModbusRegion.HoldingRegister).ToString();
                else if (rbRegisterTypeInputRegister.Checked) txtValue.Text = slave.GetValue((ushort)lvValues.SelectedIndices[0], eModbusRegion.InputRegister).ToString();
            }
            else
            {
                txtAddress.Text = string.Empty;
                txtValue.Text = string.Empty;
            }
        }

        private void chkBit_CheckedChanged(object sender, EventArgs e)
        {
            string temptext = myCheckBoxes.getValue().ToString();
            if (!txtValue.Text.Equals(temptext)) txtValue.Text = temptext;
        }

        #region check supported functions

        private void chkFC01_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC01 supported
            if (slave != null)
            {
                slave.SupportsFunction01 = chkSupportsFC01.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                chkSupportsFC01.Checked = true;
            }
        }

        private void chkFC02_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC02 supported
            if (slave != null)
            {
                slave.SupportsFunction02 = chkSupportsFC02.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkFC03_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC03 supported
            if (slave != null)
            {
                slave.SupportsFunction03 = chkSupportsFC03.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkFC04_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC04 supported
            if (slave != null)
            {
                slave.SupportsFunction04 = chkSupportsFC04.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkFC05_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC05 supported
            if (slave != null)
            {
                slave.SupportsFunction05 = chkSupportsFC05.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkFC06_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC06 supported
            if (slave != null)
            {
                slave.SupportsFunction06 = chkSupportsFC06.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkFC08_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC08 supported
            if (slave != null)
            {
                slave.SupportsFunction08 = chkSupportsFC08.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkFC15_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC15 supported
            if (slave != null)
            {
                slave.SupportsFunction15 = chkSupportsFC15.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkFC16_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC16 supported
            if (slave != null)
            {
                slave.SupportsFunction16 = chkSupportsFC16.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void chkFC23_CheckedChanged(object sender, EventArgs e)
        {
            //check if FC23 supported
            if (slave != null)
            {
                slave.SupportsFunction23 = chkSupportsFC23.Checked;
            }
            else
            {
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (slave != null)
                {
                    slave.OnDataStoreItemChange -= Slave_OnDataStoreItemChange;
                    slave.OnDataStoreItemRead -= Slave_OnDataStoreItemRead;
                    //unload and dispose all Listener
                    List<ModbusListener> ModbusListenerItems = new List<ModbusListener>(slave.Listener.Values);
                    foreach (ModbusListener ml in ModbusListenerItems)
                    {
                        slave.RemoveListener(ml.Name);
                    }
                    slave.Listener.Clear();
                    slave.Dispose();
                    slave = null;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            this.Close();
        }

        [DebuggerNonUserCode]
        private void btnLoadSettings_Click(object sender, EventArgs e)
        {

            string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusSlave", "PLCcomModbusSlaveSettings.xml");

            // Check if the directory exists, if not, create it
            string directoryPath = Path.GetDirectoryName(targetFile);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (File.Exists(targetFile))
            {
                try
                {

                    if (slave != null)//unload ModbusSlave
                    {
                        btnStopSlave_Click(null, null);
                    }

                    //load saved settiungs from PLCcomModbusSlaveSettings.xml
                    using (XmlTextReader reader = new XmlTextReader(targetFile))
                    {
                        while (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    switch (reader.Name)
                                    {
                                        case "SlaveSettings":
                                            txtUser.Text = reader.GetAttribute("user");
                                            txtSerial.Text = reader.GetAttribute("serial");
                                            cmbSlaveID.SelectedItem = reader.GetAttribute("SlaveID");
                                            cmbRegisterMode.SelectedItem = (eRegisterMode)Enum.Parse(typeof(eRegisterMode), reader.GetAttribute("RegisterMode"));
                                            cmbByteOrder.SelectedItem = (eByteOrder)Enum.Parse(typeof(eByteOrder), reader.GetAttribute("ByteOrder"));
                                            btnStartSlave_Click(null, null);
                                            chkSupportsFC01.Checked = bool.Parse(reader.GetAttribute("SupportsFunction01"));
                                            chkSupportsFC02.Checked = bool.Parse(reader.GetAttribute("SupportsFunction02"));
                                            chkSupportsFC03.Checked = bool.Parse(reader.GetAttribute("SupportsFunction03"));
                                            chkSupportsFC04.Checked = bool.Parse(reader.GetAttribute("SupportsFunction04"));
                                            chkSupportsFC05.Checked = bool.Parse(reader.GetAttribute("SupportsFunction05"));
                                            chkSupportsFC06.Checked = bool.Parse(reader.GetAttribute("SupportsFunction06"));
                                            chkSupportsFC08.Checked = bool.Parse(reader.GetAttribute("SupportsFunction08"));
                                            chkSupportsFC15.Checked = bool.Parse(reader.GetAttribute("SupportsFunction15"));
                                            chkSupportsFC16.Checked = bool.Parse(reader.GetAttribute("SupportsFunction16"));
                                            chkSupportsFC23.Checked = bool.Parse(reader.GetAttribute("SupportsFunction23"));
                                            break;
                                        case "Listener":
                                            eTypeOfCommunication ToC = (eTypeOfCommunication)Enum.Parse(typeof(eTypeOfCommunication), reader.GetAttribute("TypeOfCommunication"));
                                            switch (ToC)
                                            {
                                                case eTypeOfCommunication.TCP:
                                                    slave.AddOrReplaceListener_TCP(reader.GetAttribute("ListenerName"), int.Parse(reader.GetAttribute("LocalPort")));
                                                    break;
                                                case eTypeOfCommunication.UDP:
                                                    slave.AddOrReplaceListener_UDP(reader.GetAttribute("ListenerName"), int.Parse(reader.GetAttribute("LocalPort")));
                                                    break;
                                                case eTypeOfCommunication.RTU_over_TCP:
                                                    slave.AddOrReplaceListener_RTU_over_TCP(reader.GetAttribute("ListenerName"), int.Parse(reader.GetAttribute("LocalPort")));
                                                    break;
                                                case eTypeOfCommunication.SecureTCP:
                                                    slave.AddOrReplaceListener_SecureTCP(reader.GetAttribute("ListenerName"), int.Parse(reader.GetAttribute("LocalPort")), PrepareSecureTcpOptionsForUi(SecureTcpExampleOptions.Create()));
                                                    break;
                                                case eTypeOfCommunication.RTU:
                                                    slave.AddOrReplaceListener_RTU(reader.GetAttribute("ListenerName"),
                                                                          reader.GetAttribute("SerialPortName"),
                                                                          (eBaudrate)Enum.Parse(typeof(eBaudrate), reader.GetAttribute("Baudrate")),
                                                                          (eDataBits)Enum.Parse(typeof(eDataBits), reader.GetAttribute("DataBits")),
                                                                          (Parity)Enum.Parse(typeof(Parity), reader.GetAttribute("Parity")),
                                                                          (StopBits)Enum.Parse(typeof(StopBits), reader.GetAttribute("StopBits")),
                                                                          (Handshake)Enum.Parse(typeof(Handshake), reader.GetAttribute("Handshake")));
                                                    break;
                                                case eTypeOfCommunication.ASCII:
                                                    slave.AddOrReplaceListener_ASCII(reader.GetAttribute("ListenerName"),
                                                                            reader.GetAttribute("SerialPortName"),
                                                                            (eBaudrate)Enum.Parse(typeof(eBaudrate), reader.GetAttribute("Baudrate")),
                                                                            (eDataBits)Enum.Parse(typeof(eDataBits), reader.GetAttribute("DataBits")),
                                                                            (Parity)Enum.Parse(typeof(Parity), reader.GetAttribute("Parity")),
                                                                            (StopBits)Enum.Parse(typeof(StopBits), reader.GetAttribute("StopBits")),
                                                                            (Handshake)Enum.Parse(typeof(Handshake), reader.GetAttribute("Handshake")));
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case "FormSettings":

                                            chkAutoScroll.Checked = bool.Parse(reader.GetAttribute("AutoScroll"));
                                            chkLogging.Checked = bool.Parse(reader.GetAttribute("LogEnabled"));
                                            cmbLogLevel.SelectedItem = (eLogLevel)Enum.Parse(typeof(eLogLevel), reader.GetAttribute("LogLevel"));
                                            break;
                                    }
                                    break;
                            }
                        }

                    }
                    MessageBox.Show(resources.GetString("successfully_loaded") + Environment.NewLine +
                                    "File: " + targetFile, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message +
                                    "File: " + targetFile, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    RefreshListViewListener();
                }
            }
        }

        [DebuggerNonUserCode]
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (slave == null)
                {
                    MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                //Write Settings in PLCcomModbusSlaveSettings.xml

                string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusSlave", "PLCcomModbusSlaveSettings.xml");

                // Check if the directory exists, if not, create it
                string directoryPath = Path.GetDirectoryName(targetFile);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (XmlTextWriter myXmlTextWriter = new XmlTextWriter(targetFile, System.Text.Encoding.UTF8))
                    {

                        myXmlTextWriter.Formatting = Formatting.Indented;
                        myXmlTextWriter.WriteStartDocument(false);
                        myXmlTextWriter.WriteStartElement("SlaveSettings");
                        myXmlTextWriter.WriteAttributeString("SlaveID", cmbSlaveID.SelectedItem.ToString());
                        myXmlTextWriter.WriteAttributeString("RegisterMode", cmbRegisterMode.SelectedItem.ToString());
                        myXmlTextWriter.WriteAttributeString("ByteOrder", cmbByteOrder.SelectedItem.ToString());
                        myXmlTextWriter.WriteAttributeString("user", txtUser.Text);
                        myXmlTextWriter.WriteAttributeString("serial", txtSerial.Text);
                        myXmlTextWriter.WriteAttributeString("SupportsFunction01", chkSupportsFC01.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction02", chkSupportsFC02.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction03", chkSupportsFC03.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction04", chkSupportsFC04.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction05", chkSupportsFC05.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction06", chkSupportsFC06.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction08", chkSupportsFC08.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction15", chkSupportsFC15.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction16", chkSupportsFC16.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("SupportsFunction23", chkSupportsFC23.Checked.ToString());

                        foreach (ModbusListener mbl in slave.Listener.Values)
                        {
                            myXmlTextWriter.WriteStartElement("Listener");
                            myXmlTextWriter.WriteAttributeString("TypeOfCommunication", (mbl.TypeOfCommunication.ToString()));
                            myXmlTextWriter.WriteAttributeString("ListenerName", (mbl.Name));
                            switch (mbl.TypeOfCommunication)
                            {
                                case eTypeOfCommunication.TCP:
                                case eTypeOfCommunication.UDP:
                                case eTypeOfCommunication.RTU_over_TCP:
                                case eTypeOfCommunication.SecureTCP:
                                    myXmlTextWriter.WriteAttributeString("LocalPort", mbl.GetListenerParameter()["LocalPort"].ToString());
                                    break;
                                case eTypeOfCommunication.RTU:
                                case eTypeOfCommunication.ASCII:
                                    myXmlTextWriter.WriteAttributeString("SerialPortName", mbl.GetListenerParameter()["SerialPortName"].ToString());
                                    myXmlTextWriter.WriteAttributeString("Baudrate", mbl.GetListenerParameter()["Baudrate"].ToString());
                                    myXmlTextWriter.WriteAttributeString("DataBits", mbl.GetListenerParameter()["DataBits"].ToString());
                                    myXmlTextWriter.WriteAttributeString("Parity", mbl.GetListenerParameter()["Parity"].ToString());
                                    myXmlTextWriter.WriteAttributeString("StopBits", mbl.GetListenerParameter()["StopBits"].ToString());
                                    myXmlTextWriter.WriteAttributeString("Handshake", mbl.GetListenerParameter()["Handshake"].ToString());
                                    break;
                                default:
                                    break;
                            }
                            myXmlTextWriter.WriteEndElement();
                        }


                        myXmlTextWriter.WriteStartElement("FormSettings");
                        myXmlTextWriter.WriteAttributeString("AutoScroll", chkAutoScroll.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("LogEnabled", chkLogging.Checked.ToString());
                        myXmlTextWriter.WriteAttributeString("LogLevel", cmbLogLevel.SelectedItem.ToString());
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


        private void btnCopyLogtoClipboard_Click(object sender, EventArgs e)
        {
            //copy diagnostic log to clipboard
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem lvi in lvLog.Items)
            {
                sb.Append(lvi.Text);
                sb.Append(Environment.NewLine);
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                Clipboard.SetText(sb.ToString(), TextDataFormat.Text);
            }
        }

        private void btnCopyLogtoFile_Click(object sender, EventArgs e)
        {
            //copy diagnostic log to file
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem lvi in lvLog.Items)
            {
                sb.Append(lvi.Text);
                sb.Append(Environment.NewLine);
            }


            string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusSlave", "PLCcomModbusDiagnosticLog.log");

            // Check if the directory exists, if not, create it
            string directoryPath = Path.GetDirectoryName(targetFile);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            FileStream fs = File.Create(targetFile);
            BinaryWriter bw = new BinaryWriter(fs);

            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                bw.Write(System.Text.Encoding.Default.GetBytes(sb.ToString()));
            }
            bw.Close();
            fs.Close();

            MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine +
                                                "File: " + targetFile, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change UI language
            SetLanguage((System.Globalization.CultureInfo)cmbLanguage.SelectedItem);
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
    }
}
