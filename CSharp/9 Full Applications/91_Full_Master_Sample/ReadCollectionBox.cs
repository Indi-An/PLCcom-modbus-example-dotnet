using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using PLCcomModbus.Core;
using PLCcomModbus.Master;

namespace PLCComMB_Master_Example_CSharp
{
    public partial class ReadCollectionBox : Form
    {

        public ReadCollectionBox(ModbusMaster Device)
        {
            InitializeComponent();
            this.Device = Device;
        }

        #region Private Member
        ModbusMaster Device;
        System.Resources.ResourceManager resources;
        ReadRequestCollection RequestCollection = new ReadRequestCollection();
        #endregion

        private void ReadCollectionBox_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeviceGUID.Text = "Device Guid: " + Device.DeviceGuid.ToString();
                lblDeviceType.Text = "Adapter Type: " + Device.Connector.GetType().ToString();

                cmbByteOrder.DataSource = Enum.GetValues(typeof(eByteOrder));
                cmbDataType.DataSource = Enum.GetValues(typeof(eDataType));
                cmbFunction.DataSource = Enum.GetValues(typeof(eReadFunction));

                //set ressources
                resources = new System.Resources.ResourceManager(this.GetType().Namespace + ".Properties.Resources", this.GetType().Assembly);
                this.lblLog.Text = resources.GetString("lblLog_Text");
                this.grpAddress.Text = resources.GetString("grpAddress_Text");
                this.grpAction.Text = resources.GetString("grpAction_Text");
                this.lblFunction.Text = resources.GetString("lblFunction_Text");
                this.lblSlaveID.Text = resources.GetString("lblSlaveID_Text");
                this.btnClose.Text = resources.GetString("btnClose_Text");
                this.btnAddRequest.Text = resources.GetString("btnAddRequest_Text");
                this.btnRemoveRequest.Text = resources.GetString("btnRemoveRequest_Text");
                this.btnReadCollection.Text = resources.GetString("btnReadCollection_Text");
                this.btnLoadRequests.Text = resources.GetString("btnLoadRequests_Text");
                this.btnSaveRequests.Text = resources.GetString("btnSaveRequests_Text");
                this.txtInfoRCB.Text = resources.GetString("txtInfoRCB_Text");
                this.lblByteOrder.Text = resources.GetString("lblByteOrder_Text");
                this.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveSlaveLogtoClipboard_Text");
                this.btnSaveLogtoFile.Text = resources.GetString("btnSaveSlaveLogtoFile_Text");
                this.lblDataType.Text = resources.GetString("lblDataType_Text");
                this.lblReadAddress.Text = resources.GetString("lblReadAddress_Text");
                this.lblQuantity.Text = resources.GetString("lblQuantity_Text");

                //init slave id
                List<object> lisSlaveID = new List<object>();
                for (int i = 0; i < 248; i++) { lisSlaveID.Add(i); }
                cmbSlaveID.DataSource = lisSlaveID;
                cmbSlaveID.SelectedItem = 1;



                txtRequestKey.Text = "Request_" + (RequestCollection.GetReadRequests().Length + 1).ToString("00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            try
            {
                //define new request
                ReadRequest RequestItem = null;

                if ((eDataType)cmbDataType.SelectedItem == eDataType.BOOLEAN &&
                    ((eReadFunction)cmbFunction.SelectedItem == eReadFunction.F03_Read_Holding_Registers ||
                    (eReadFunction)cmbFunction.SelectedItem == eReadFunction.F04_Read_Input_Register))
                {
                    RequestItem = RequestBuilder.ReadRequestBuilder.Create(int.Parse(cmbSlaveID.Text),            //Slave ID
                                                                           (eReadFunction)cmbFunction.SelectedItem, //modbus function
                                                                           ushort.Parse(txtReadAddress.Text),       //Read start adress
                                                                           (eDataType)cmbDataType.SelectedItem,   //Target Datatype
                                                                           int.Parse(txtQuantity.Text),             //quantity of objects to be read
                                                                           byte.Parse(txtBit.Text));                //Address of first Bit by reading register
                }
                else
                {
                    RequestItem = RequestBuilder.ReadRequestBuilder.Create(int.Parse(cmbSlaveID.Text),            //Slave ID
                                                                           (eReadFunction)cmbFunction.SelectedItem, //modbus function
                                                                           ushort.Parse(txtReadAddress.Text),       //Read start adress
                                                                           (eDataType)cmbDataType.SelectedItem,   //Target Datatype
                                                                           int.Parse(txtQuantity.Text));             //quantity of objects to be read)
                }


                //set eventual byte order, standard = eByteOrder.AB_CD;
                RequestItem.ByteOrder = (eByteOrder)cmbByteOrder.SelectedValue;

                //add new request to request collection
                RequestCollection.AddReadRequest(txtRequestKey.Text, RequestItem);

                txtRequestKey.Text = "Request_" + (RequestCollection.GetReadRequests().Length + 1).ToString("00");

                //update listview
                fillRequestListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnRemoveRequest_Click(object sender, EventArgs e)
        {
            //remove request from request collection
            try
            {
                if (lvRequests.SelectedItems.Count != 0)
                {
                    RequestCollection.RemoveReadItemRequest(lvRequests.SelectedItems[0].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                fillRequestListView();
            }
        }

        private void lvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemoveRequest.Enabled = lvRequests.SelectedItems.Count != 0;
        }

        private void fillRequestListView()
        {
            //clear ListView initial
            lvRequests.Items.Clear();

            //fill ListView with current ReadRequests
            foreach (ReadRequest rr in RequestCollection.GetReadRequests())
            {
                ListViewItem lvi = new ListViewItem(rr.RequestKey);
                lvi.SubItems.Add(rr.ToString());
                lvRequests.Items.Add(lvi);
            }
        }

        private void btnReadCollection_Click(object sender, EventArgs e)
        {
            try
            {
                // Optmize Mode
                RequestCollection.Optmize = true;

                //read from device
                ReadResultCollection ResultCollection = Device.Read(RequestCollection);

                lvValues.Items.Clear();
                lvLog.Items.Clear();
                lvValues.Columns[1].Text = "Address";

                //find itemresult with foreach-loop

                ListViewItem lvi = null;

                //getting readrequestcollection diagnoctic logs           
                lvi = new ListViewItem(DateTime.Now.ToString() + " " + ResultCollection.GetType().Name + " Message: " + ResultCollection.Message);
                lvi.ForeColor = ResultCollection.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                lvLog.Items.Add(lvi);

                foreach (LogEntry le in ResultCollection.GetDiagnosticLog())
                {
                    lvi = new ListViewItem(le.ToString());
                    lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                }

                //evaluate results
                foreach (ReadResult res in ResultCollection.GetReadItemResult())
                {
                    if (res.Quality == OperationResult.eQuality.GOOD)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Start Item:");
                        sb.Append(res.RequestKey);
                        sb.Append(" ");
                        sb.Append("Quality:");
                        sb.Append(" ");
                        sb.Append(res.Quality.ToString());
                        sb.Append(Environment.NewLine);

                        lvi = new ListViewItem();
                        lvi.ForeColor = res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red;
                        lvi.SubItems.Add(sb.ToString());
                        lvValues.Items.Add(lvi);

                        foreach (ReadValue item in res.FetchValues())
                        {
                            lvi = new ListViewItem();
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, "Address => " + item.Address.ToString() + " Position => " + item.AddressPosition.ToString()));
                            lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, (item.Value.ToString())));
                            lvValues.Items.Add(lvi);
                        }

                        sb = new StringBuilder();
                        sb.Append("End Item:");
                        sb.Append(res.RequestKey);
                        lvi = new ListViewItem();
                        lvi.ForeColor = res.Quality.Equals(OperationResult.eQuality.GOOD) ? Color.Black : Color.Red;
                        lvi.SubItems.Add(sb.ToString());
                        lvValues.Items.Add(lvi);
                        lvValues.Items.Add(new ListViewItem());
                    }

                    //getting readrequest diagnoctic logs           
                    lvi = new ListViewItem(DateTime.Now.ToString() + (!String.IsNullOrEmpty(res.RequestKey) ? " " + res.RequestKey : "") + " Message: " + res.Message);
                    lvi.ForeColor = res.Quality == OperationResult.eQuality.GOOD ? Color.Black : Color.Red;
                    lvLog.Items.Add(lvi);
                    foreach (LogEntry le in res.GetDiagnosticLog())
                    {
                        lvi = new ListViewItem(le.ToString());
                        lvi.ForeColor = le.getLogLevel() == eLogLevel.Information ? Color.Black : Color.Red;
                        lvLog.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cmbFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch byteorder depending on the selected function
            if ((eReadFunction)cmbFunction.SelectedItem == eReadFunction.F03_Read_Holding_Registers ||
                (eReadFunction)cmbFunction.SelectedItem == eReadFunction.F04_Read_Input_Register)
            {
                if ((eDataType)cmbDataType.SelectedItem == eDataType.BOOLEAN ||
                (eDataType)cmbDataType.SelectedItem == eDataType.BYTE ||
                (eDataType)cmbDataType.SelectedItem == eDataType.STRING)
                {
                    cmbByteOrder.Enabled = false;
                }
                else
                {
                    cmbByteOrder.Enabled = true;
                }
                cmbDataType.Enabled = true;
            }
            else
            {
                cmbByteOrder.Enabled = false;
                cmbDataType.Enabled = false;
                cmbDataType.SelectedItem = eDataType.BOOLEAN;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch byteorder depending on the selected data type
            if ((eDataType)cmbDataType.SelectedItem == eDataType.BOOLEAN ||
                (eDataType)cmbDataType.SelectedItem == eDataType.BYTE)
            {
                cmbByteOrder.Enabled = false;
            }
            else
            {
                cmbByteOrder.Enabled = true;
            }
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

        [DebuggerNonUserCode]
        private void btnLoadRequests_Click(object sender, EventArgs e)
        {
            //load settings from file
            RequestCollection = new ReadRequestCollection();

            try
            {
                string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusMaster", "PLCcomModbusRequestCollection.xml");

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
                            try
                            {
                                switch (reader.NodeType)
                                {

                                    case XmlNodeType.Element: // The node is an element

                                        switch (reader.Name)
                                        {
                                            case "Request":
                                                ReadRequest RequestItem = null;

                                                eReadFunction rfc = (eReadFunction)Enum.Parse(typeof(eReadFunction), reader.GetAttribute("Function"));

                                                if (((eDataType)Enum.Parse(typeof(eDataType), reader.GetAttribute("Target_Datatype"))).Equals(eDataType.BOOLEAN) &&
                                                    (rfc == eReadFunction.F03_Read_Holding_Registers ||
                                                    (rfc == eReadFunction.F04_Read_Input_Register)))
                                                {
                                                    RequestItem = RequestBuilder.ReadRequestBuilder.Create(int.Parse(reader.GetAttribute("SlaveID")),                                           //Slave ID
                                                                                                           rfc,                                                                                 //modbus function
                                                                                                           ushort.Parse(reader.GetAttribute("ReadAddress")),                                    //Read start adress
                                                                                                           (eDataType)Enum.Parse(typeof(eDataType), reader.GetAttribute("Target_Datatype")),    //Target Datatype
                                                                                                           int.Parse(reader.GetAttribute("Quantity")),                                          //quantity of objects to be read
                                                                                                           byte.Parse(reader.GetAttribute("StartBit")));                                        //Address of first Bit by reading register
                                                }
                                                else
                                                {
                                                    RequestItem = RequestBuilder.ReadRequestBuilder.Create(int.Parse(reader.GetAttribute("SlaveID")),                                           //Slave ID
                                                                                                           rfc,                                                                                 //modbus function
                                                                                                           ushort.Parse(reader.GetAttribute("ReadAddress")),                                    //Read start adress
                                                                                                           (eDataType)Enum.Parse(typeof(eDataType), reader.GetAttribute("Target_Datatype")),    //Target Datatype
                                                                                                           int.Parse(reader.GetAttribute("Quantity")));                                         //quantity of objects to be read
                                                }

                                                RequestCollection.AddReadRequest(reader.GetAttribute("RequestKey"), RequestItem);
                                                break;
                                        }
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    }

                    //Refresh listview
                    fillRequestListView();

                    MessageBox.Show(resources.GetString("successfully_loaded") + Environment.NewLine +
                                    "File: " + targetFile, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        [DebuggerNonUserCode]
        private void btnSaveRequests_Click(object sender, EventArgs e)
        {
            try
            {

                string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusMaster", "PLCcomModbusRequestCollection.xml");

                // Check if the directory exists, if not, create it
                string directoryPath = Path.GetDirectoryName(targetFile);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                //save and write Settings in PLCcomModbusRequestCollection.xml
                using (XmlTextWriter myXmlTextWriter = new XmlTextWriter(targetFile, System.Text.Encoding.UTF8))
                {

                    myXmlTextWriter.Formatting = Formatting.Indented;
                    myXmlTextWriter.WriteStartDocument(false);
                    myXmlTextWriter.WriteStartElement("Requests");

                    foreach (ReadRequest rreq in RequestCollection.GetReadRequests())
                    {
                        myXmlTextWriter.WriteStartElement("Request");
                        myXmlTextWriter.WriteAttributeString("RequestKey", rreq.RequestKey);
                        myXmlTextWriter.WriteAttributeString("Function", rreq.Function.ToString());
                        myXmlTextWriter.WriteAttributeString("SlaveID", rreq.SlaveID.ToString());
                        myXmlTextWriter.WriteAttributeString("Target_Datatype", rreq.Target_Datatype.ToString());
                        myXmlTextWriter.WriteAttributeString("ByteOrder", rreq.ByteOrder.ToString());
                        myXmlTextWriter.WriteAttributeString("ReadAddress", rreq.ReadAddress.ToString());
                        myXmlTextWriter.WriteAttributeString("Quantity", rreq.Quantity.ToString());
                        myXmlTextWriter.WriteAttributeString("StartBit", rreq.StartBit.ToString());
                        myXmlTextWriter.WriteEndElement();
                    }
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

        private void ReadCollectionBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.CountOpenDialogs--;
        }

    }
}
