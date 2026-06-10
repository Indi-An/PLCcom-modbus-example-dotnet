using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using PLCcomModbus.Core;

namespace PLCcomMB_Slave_Example_CSharp
{
    public partial class ListenerCreator : Form
    {
        #region private member

        private Dictionary<string, object> Args = new Dictionary<string, object>();
        private System.Resources.ResourceManager resources = null;

        #endregion


        public ListenerCreator()
        {
            InitializeComponent();
        }

        private void CreateListener_Load(object sender, EventArgs e)
        {
            //init controls
            resources = new System.Resources.ResourceManager(this.GetType().Namespace + ".Properties.Resources", this.GetType().Assembly);
            this.Text = resources.GetString("create_listener_Text");
            this.lblListenerName.Text = resources.GetString("lblListenerName_Text");
            this.lblConnectionType.Text = resources.GetString("lblConnectionType_Text");
            this.grbListenerSettings.Text = resources.GetString("grbListenerSettings_Text");
            this.btnAccept.Text = resources.GetString("btnAccept_Text");
            this.btnAbort.Text = resources.GetString("btnAbort_Text");
            this.txtInfoCreateListener.Text = resources.GetString("txtInfoCreateListener_Text");

            cmbConnectionType.DataSource = Enum.GetValues(typeof(eTypeOfCommunication));
            cmbBaudrate.DataSource = Enum.GetValues(typeof(eBaudrate));
            cmbBaudrate.SelectedItem = eBaudrate.b9600;
            cmbParity.DataSource = Enum.GetValues(typeof(Parity));
            cmbParity.SelectedItem = Parity.None;
            cmbDataBits.DataSource = Enum.GetValues(typeof(eDataBits));
            cmbDataBits.SelectedItem = eDataBits.DataBits8;
            cmbHandshake.DataSource = Enum.GetValues(typeof(Handshake));
            cmbHandshake.SelectedItem = Handshake.None;

            List<object> lisStopbits = new List<object>();
            foreach (StopBits stb in Enum.GetValues(typeof(StopBits)))
            {
                //StopBits.None is not supported
                if (stb != StopBits.None) lisStopbits.Add(stb);
            }
            cmbStopbits.DataSource = lisStopbits;
            cmbStopbits.SelectedItem = 1;

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
        }

        internal Dictionary<string, object> CreateListener(int ListenerNumber)
        {
            txtListenerName.Text = "Listener_" + (ListenerNumber + 1).ToString("00");
            Args.Clear();
            this.ShowDialog();
            return Args;
        }

        private void cmbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((eTypeOfCommunication)this.cmbConnectionType.SelectedValue)
                {
                    case eTypeOfCommunication.TCP:
                    case eTypeOfCommunication.UDP:
                    case eTypeOfCommunication.RTU_over_TCP:
                    case eTypeOfCommunication.SecureTCP:
                        grbIPSettings.Enabled = true;
                        grbSerialSettings.Enabled = false;
                        eTypeOfCommunication selectedCommunication = (eTypeOfCommunication)this.cmbConnectionType.SelectedValue;
                        if (selectedCommunication == eTypeOfCommunication.SecureTCP && txtLocalPort.Text == "502")
                            txtLocalPort.Text = "802";
                        else if (selectedCommunication != eTypeOfCommunication.SecureTCP && txtLocalPort.Text == "802")
                            txtLocalPort.Text = "502";
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Args.Add("TypeOfCommunication", (eTypeOfCommunication)cmbConnectionType.SelectedItem);
                Args.Add("ListerName", txtListenerName.Text);
                switch ((eTypeOfCommunication)cmbConnectionType.SelectedItem)
                {
                    case eTypeOfCommunication.TCP:
                    case eTypeOfCommunication.UDP:
                    case eTypeOfCommunication.RTU_over_TCP:
                    case eTypeOfCommunication.SecureTCP:
                        Args.Add("LocalPort", int.Parse(txtLocalPort.Text));
                        break;
                    case eTypeOfCommunication.RTU:
                    case eTypeOfCommunication.ASCII:
                        Args.Add("SerialPortName", cmbSerialPort.Text);
                        Args.Add("Baudrate", (eBaudrate)cmbBaudrate.SelectedItem);
                        Args.Add("DataBits", (eDataBits)cmbDataBits.SelectedItem);
                        Args.Add("Parity", (Parity)cmbParity.SelectedItem);
                        Args.Add("StopBits", (StopBits)cmbStopbits.SelectedItem);
                        Args.Add("Handshake", (Handshake)cmbHandshake.SelectedItem);
                        break;
                    default:
                        Args.Clear();
                        break;
                }
            }
            catch (Exception)
            {
                Args.Clear();
            }

            this.Close();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
