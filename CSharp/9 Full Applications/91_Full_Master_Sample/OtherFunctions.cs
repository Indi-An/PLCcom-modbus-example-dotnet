using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PLCcomModbus.Core;
using PLCcomModbus.Master;


namespace PLCComMB_Master_Example_CSharp
{
    public partial class OtherFunctions : Form
    {

        public OtherFunctions(ModbusMaster Device)
        {
            InitializeComponent();
            this.Device = Device;
        }

        #region Private Member
        ModbusMaster Device;
        System.Resources.ResourceManager resources;
        #endregion


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OtherFunctions_Load(object sender, EventArgs e)
        {
            lblDeviceGUID.Text = "Device Guid: " + Device.DeviceGuid.ToString();
            lblDeviceType.Text = "Adapter Type: " + Device.Connector.GetType().ToString();

            //set ressources
            resources = new System.Resources.ResourceManager(this.GetType().Namespace + ".Properties.Resources", this.GetType().Assembly);
            this.lblLog.Text = resources.GetString("lblLog_Text");
            this.btnClose.Text = resources.GetString("btnClose_Text");
            this.lblBroadcast.Text = resources.GetString("lblBroadcast_Text");
            this.btnExecute.Text = resources.GetString("btnExecute_Text");
            this.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveSlaveLogtoClipboard_Text");
            this.btnSaveLogtoFile.Text = resources.GetString("btnSaveSlaveLogtoFile_Text");
            this.lblFunction.Text = resources.GetString("lblFunction_Text");
            this.grpAction.Text = resources.GetString("grpAction_Text");
            this.txtInfoOF.Text = resources.GetString("txtInfoOF_Text");

            //Set cmbFunction datasource
            List<object> lisAllFunctions = new List<object>();
            foreach (eOperationFunction FunctionEntry in Enum.GetValues(typeof(eOperationFunction))) { cmbFunction.Items.Add(FunctionEntry); }

            cmbFunction.Sorted = true;
            cmbFunction.SelectedItem = eOperationFunction.F08_Diagnostic;

            //init slave id
            List<object> lisSlaveID = new List<object>();
            for (int i = 0; i < 248; i++) { lisSlaveID.Add(i); }
            cmbSlaveID.DataSource = lisSlaveID;
            cmbSlaveID.SelectedItem = 1;

            lblBroadcast.Visible = (int)cmbSlaveID.SelectedItem == 0;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //execute desired function
            switch ((eOperationFunction)cmbFunction.SelectedItem)
            {
                case eOperationFunction.F07_Read_Exception_status:
                    getExceptionStatus();
                    break;
                case eOperationFunction.F08_Diagnostic:
                    GetDiagnostic();
                    break;
                case eOperationFunction.F11_Get_Com_event_counter:
                    getCommEventCounter();
                    break;
                case eOperationFunction.F12_Get_Com_Event_Log:
                    getCommEventlog();
                    break;
                case eOperationFunction.F17_Report_Server_ID:
                    ReportServerID();
                    break;
                case eOperationFunction.UserFunction:
                    MBUserFunction();
                    break;
            }
        }

        private void getExceptionStatus()
        {
            //declare a OperationRequest object
            //and set the request parameters
            OperationRequest myRequest = RequestBuilder.OperationRequestBuilder.Create(int.Parse(cmbSlaveID.SelectedValue.ToString()), //Slave ID
                                                                                        eOperationFunction.F07_Read_Exception_status);

            //execute function
            ExceptionStatusResult res = Device.GetExceptionStatus(myRequest);

            //evaluate results

            //set diagnostic output
            lvLog.Items.Clear();
            ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
            lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
            lvLog.Items.Add(lvi);
            foreach (LogEntry le in res.GetDiagnosticLog())
            {
                lvi = new ListViewItem(le.ToString());
                lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
            }

            txtResult.Text = string.Empty;
            if (res.Quality == OperationResult.eQuality.GOOD)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Data >> ");
                sb.Append(res.Data.ToString());
                sb.Append(Environment.NewLine);
                txtResult.Text = sb.ToString();
            }
        }

        private void GetDiagnostic()
        {
            //declare a ReadRequest object
            //and set the request parameters
            DiagnosticRequest myDiagnosticRequest = RequestBuilder.DiagnosticRequestBuilder.Create(int.Parse(cmbSlaveID.SelectedValue.ToString()), //Slave ID
                                                                                                    0, new byte[] { 3, 4 }); //quantity of objects to be read
            //execute function
            DiagnosticResult res = Device.GetDiagnostics(myDiagnosticRequest);


            //evaluate results

            //set diagnostic output
            lvLog.Items.Clear();
            ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
            lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
            lvLog.Items.Add(lvi);
            foreach (LogEntry le in res.GetDiagnosticLog())
            {
                lvi = new ListViewItem(le.ToString());
                lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
            }

            txtResult.Text = string.Empty;
            if (res.Quality == OperationResult.eQuality.GOOD)
            {
                ushort counter = 0;
                StringBuilder sb = new StringBuilder();
                foreach (object value in res.ResultData)
                {
                    sb.Append(counter++.ToString("0000"));
                    sb.Append(" >> ");
                    sb.Append(value.ToString());
                    sb.Append(Environment.NewLine);
                }
                txtResult.Text = sb.ToString();
            }

        }

        private void getCommEventCounter()
        {
            //declare a OperationRequest object
            //and set the request parameters
            OperationRequest myRequest = RequestBuilder.OperationRequestBuilder.Create(int.Parse(cmbSlaveID.SelectedValue.ToString()), //Slave ID
                                                                                        eOperationFunction.F11_Get_Com_event_counter);

            //execute function
            CommEventCounterResult res = Device.GetCommEventCounter(myRequest);

            //evaluate results

            //set diagnostic output
            lvLog.Items.Clear();
            ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
            lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
            lvLog.Items.Add(lvi);
            foreach (LogEntry le in res.GetDiagnosticLog())
            {
                lvi = new ListViewItem(le.ToString());
                lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
            }

            txtResult.Text = string.Empty;
            if (res.Quality == OperationResult.eQuality.GOOD)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Status >> ");
                sb.Append(res.Status.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("EventCount >> ");
                sb.Append(res.EventCount.ToString());
                txtResult.Text = sb.ToString();
            }
        }

        private void getCommEventlog()
        {
            //declare a OperationRequest object
            //and set the request parameters
            OperationRequest myRequest = RequestBuilder.OperationRequestBuilder.Create(int.Parse(cmbSlaveID.SelectedValue.ToString()), //Slave ID
                                                                                        eOperationFunction.F12_Get_Com_Event_Log);

            //execute function
            CommEventLogResult res = Device.GetCommEventLog(myRequest);

            //evaluate results

            //set diagnostic output
            lvLog.Items.Clear();
            ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
            lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
            lvLog.Items.Add(lvi);
            foreach (LogEntry le in res.GetDiagnosticLog())
            {
                lvi = new ListViewItem(le.ToString());
                lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
            }

            txtResult.Text = string.Empty;
            if (res.Quality == OperationResult.eQuality.GOOD)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Status >> ");
                sb.Append(res.Status.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("EventCount >> ");
                sb.Append(res.EventCount.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("MessageCount >> ");
                sb.Append(res.MessageCount.ToString());
                int counter = 0;
                foreach (byte value in res.Events)
                {
                    sb.Append("Event ");
                    sb.Append(counter++.ToString("0000"));
                    sb.Append(" >> ");
                    sb.Append(value.ToString());
                    sb.Append(Environment.NewLine);
                }
                txtResult.Text = sb.ToString();
            }
        }

        private void ReportServerID()
        {
            //declare a OperationRequest object
            //and set the request parameters
            OperationRequest myRequest = RequestBuilder.OperationRequestBuilder.Create(int.Parse(cmbSlaveID.SelectedValue.ToString()), //Slave ID
                                                                                        eOperationFunction.F17_Report_Server_ID);

            //execute function
            ReportServerIDResult res = Device.GetReportServerID(myRequest);

            //evaluate results

            //set diagnostic output
            lvLog.Items.Clear();
            ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
            lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
            lvLog.Items.Add(lvi);
            foreach (LogEntry le in res.GetDiagnosticLog())
            {
                lvi = new ListViewItem(le.ToString());
                lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
            }

            txtResult.Text = string.Empty;
            if (res.Quality == OperationResult.eQuality.GOOD)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("ServerID >> ");
                sb.Append(res.ServerID.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("Run Indicator Status >> ");
                sb.Append(res.RunIndicatorStatus.ToString());
                int counter = 0;
                foreach (byte value in res.AdditionalData)
                {
                    sb.Append("Event ");
                    sb.Append(counter++.ToString("0000"));
                    sb.Append(" >> ");
                    sb.Append(value.ToString());
                    sb.Append(Environment.NewLine);
                }
                txtResult.Text = sb.ToString();
            }
        }

        private void MBUserFunction()
        {
            //declare a OperationRequest object
            //and set the request parameters
            OperationRequest myRequest = RequestBuilder.OperationRequestBuilder.CreateUserRequest(int.Parse(cmbSlaveID.SelectedValue.ToString()), //Slave ID
                                                                                                  65, new byte[] { 0, 2, 0, 10 }); // fictional user function 65 with data

            //execute function
            UserFunctionResult res = Device.callUserFunction(myRequest);

            //evaluate results

            //set diagnostic output
            lvLog.Items.Clear();
            ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " Message: " + res.Message);
            lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
            lvLog.Items.Add(lvi);
            foreach (LogEntry le in res.GetDiagnosticLog())
            {
                lvi = new ListViewItem(le.ToString());
                lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);
            }

            txtResult.Text = string.Empty;
            if (res.Quality == OperationResult.eQuality.GOOD)
            {
                StringBuilder sb = new StringBuilder();
                int counter = 0;
                foreach (byte value in res.ResultData)
                {
                    sb.Append("return byte ");
                    sb.Append(counter++.ToString("0000"));
                    sb.Append(" >> ");
                    sb.Append(value.ToString());
                    sb.Append(Environment.NewLine);
                }
                txtResult.Text = sb.ToString();
            }
        }

        private void cmbSlaveID_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblBroadcast.Visible = (int)cmbSlaveID.SelectedItem == 0;
        }

        private void btnSaveLogtoClipboard_Click(object sender, EventArgs e)
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

        private void btnSaveLogtoFile_Click(object sender, EventArgs e)
        {
            //copy diagnostic log to file
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem lvi in lvLog.Items)
            {
                sb.Append(lvi.Text);
                sb.Append(Environment.NewLine);
            }

            string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusMaster", "PLCcomModbusDiagnosticLog.log");

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

        private void OtherFunctions_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.CountOpenDialogs--;
        }

    }
}
