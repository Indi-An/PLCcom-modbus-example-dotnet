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
    public partial class ReadWriteBox : Form
    {

        public ReadWriteBox(ModbusMaster Device)
        {
            InitializeComponent();
            this.Device = Device;
        }

        #region Private Member
        private ModbusMaster Device;

        System.Resources.ResourceManager resources;
        private string C_Values_Multiple_Coil = "true" + Environment.NewLine + "false" + Environment.NewLine + "false" + Environment.NewLine + "true" + Environment.NewLine;
        private string C_Values_Single_Register = "0";
        private string C_Values_Multiple_Register = "0" + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine;
        private string ValuetoWrite = string.Empty;

        #endregion

        private void ReadWriteBox_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeviceGUID.Text = "Device Guid: " + Device.DeviceGuid.ToString();
                lblDeviceType.Text = "Adapter Type: " + Device.Connector.GetType().ToString();


                cmbByteOrder.DataSource = Enum.GetValues(typeof(eByteOrder));
                cmbDataType.DataSource = Enum.GetValues(typeof(eDataType));

                //set ressources
                resources = new System.Resources.ResourceManager(this.GetType().Namespace + ".Properties.Resources", this.GetType().Assembly);
                this.lblLog.Text = resources.GetString("lblLog_Text");
                this.grpAddress.Text = resources.GetString("grpAddress_Text");
                this.grpAction.Text = resources.GetString("grpAction_Text");
                this.lblFunction.Text = resources.GetString("lblFunction_Text");
                this.lblSlaveID.Text = resources.GetString("lblSlaveID_Text");
                this.lblDataType.Text = resources.GetString("lblDataType_Text");
                this.lblReadAddress.Text = resources.GetString("lblReadAddress_Text");
                this.lblQuantity.Text = resources.GetString("lblQuantity_Text");
                this.lblWriteAddress.Text = resources.GetString("lblWriteAddress_Text");
                this.btnClose.Text = resources.GetString("btnClose_Text");
                this.btnExecute.Text = resources.GetString("btnExecute_Text");
                this.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveSlaveLogtoClipboard_Text");
                this.btnSaveLogtoFile.Text = resources.GetString("btnSaveSlaveLogtoFile_Text");
                this.btnLoadRequest.Text = resources.GetString("btnLoadRequest_Text");
                this.btnSaveRequest.Text = resources.GetString("btnSaveRequest_Text");
                this.lblByteOrder.Text = resources.GetString("lblByteOrder_Text");
                this.lblBroadcast.Text = resources.GetString("lblBroadcast_Text");
                this.lblWriteMaskRegister_AND.Text = resources.GetString("lblWriteMaskRegister_AND_Text");
                this.lblWriteMaskRegister_OR.Text = resources.GetString("lblWriteMaskRegister_OR_Text");
                this.txtInfoRB.Text = resources.GetString("txtInfoRB_OR_Text");
                this.chkSingleValue.Text = resources.GetString("chkSingleValue_Text");
                this.lblWriteMaskRegister_AND.Text = resources.GetString("lblWriteMaskRegister_AND_Text");
                this.lblWriteMaskRegister_OR.Text = resources.GetString("lblWriteMaskRegister_OR_Text");
                this.lblEnterValues.Text = resources.GetString("lblValues_Text");

                //Set cmbFunction datasource
                List<object> lisAllFunctions = new List<object>();
                foreach (eReadFunction FunctionEntry in Enum.GetValues(typeof(eReadFunction))) { cmbFunction.Items.Add(FunctionEntry); }
                foreach (eWriteFunction FunctionEntry in Enum.GetValues(typeof(eWriteFunction))) { cmbFunction.Items.Add(FunctionEntry); }
                foreach (eMaskWriteRegisterFunction FunctionEntry in Enum.GetValues(typeof(eMaskWriteRegisterFunction))) { cmbFunction.Items.Add(FunctionEntry); }
                foreach (eReadWriteFunction FunctionEntry in Enum.GetValues(typeof(eReadWriteFunction))) { cmbFunction.Items.Add(FunctionEntry); }

                cmbFunction.Sorted = true;
                cmbFunction.SelectedItem = eReadFunction.F01_Read_Coils;

                //init slave id
                List<object> lisSlaveID = new List<object>();
                for (int i = 0; i < 248; i++) { lisSlaveID.Add(i); }
                cmbSlaveID.DataSource = lisSlaveID;
                cmbSlaveID.SelectedItem = 1;

                lblBroadcast.Visible = (int)cmbSlaveID.SelectedItem == 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cmbFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //set controls with specific values
                eMBFunction myFunction = (eMBFunction)Enum.Parse(typeof(eMBFunction), cmbFunction.SelectedItem.ToString());

                bool booReadNumberAreaEnabled = false;
                bool booReadBoolAreaEnabled = false;
                bool booWriteNumberAreaEnabled = false;
                bool booWriteBoolAreaEnabled = false;

                switch (myFunction)
                {
                    case eMBFunction.F01_Read_Coils:
                    case eMBFunction.F02_Read_Discrete_Inputs:
                        booReadNumberAreaEnabled = false;
                        booReadBoolAreaEnabled = true;
                        booWriteNumberAreaEnabled = false;
                        booWriteBoolAreaEnabled = false;
                        break;
                    case eMBFunction.F03_Read_Holding_Registers:
                    case eMBFunction.F04_Read_Input_Register:
                        booReadNumberAreaEnabled = true;
                        booReadBoolAreaEnabled = true;
                        booWriteNumberAreaEnabled = false;
                        booWriteBoolAreaEnabled = false;
                        break;
                    case eMBFunction.F05_Write_Single_Coil:
                    case eMBFunction.F15_Write_Multiple_Coils:
                    case eMBFunction.Auto_Write_Coils:
                        booReadNumberAreaEnabled = false;
                        booReadBoolAreaEnabled = false;
                        booWriteBoolAreaEnabled = true;
                        booWriteNumberAreaEnabled = false;
                        break;
                    case eMBFunction.F06_Write_Single_Register:
                    case eMBFunction.F16_Write_Multiple_Registers:
                    case eMBFunction.Auto_Write_Register:
                        booReadNumberAreaEnabled = false;
                        booReadBoolAreaEnabled = false;
                        booWriteBoolAreaEnabled = false;
                        booWriteNumberAreaEnabled = true;
                        break;
                    case eMBFunction.F22_Mask_Write_Register:
                        booReadNumberAreaEnabled = false;
                        booWriteNumberAreaEnabled = false;
                        booWriteBoolAreaEnabled = false;
                        booReadBoolAreaEnabled = false;
                        break;
                    case eMBFunction.F23_Read_Write_Multiple_Registers:
                        booReadNumberAreaEnabled = false;
                        booWriteNumberAreaEnabled = false;
                        booWriteBoolAreaEnabled = false;
                        booReadBoolAreaEnabled = false;
                        break;
                    case eMBFunction.F07_Read_Exception_status:
                    case eMBFunction.F08_Diagnostic:
                    case eMBFunction.F11_Get_Com_event_counter:
                    case eMBFunction.F12_Get_Com_Event_Log:
                    case eMBFunction.F17_Report_Server_ID:
                    case eMBFunction.UserFunction:
                    default:
                        booReadNumberAreaEnabled = false;
                        booWriteNumberAreaEnabled = false;
                        booWriteBoolAreaEnabled = false;
                        booReadBoolAreaEnabled = false;
                        break;
                }

                #region set ReadArea
                lblReadAddress.ForeColor = booReadNumberAreaEnabled || booReadBoolAreaEnabled ? Color.Black : Color.Gray;
                lblBit.ForeColor = booReadNumberAreaEnabled ? Color.Black : Color.Gray;
                lblQuantity.ForeColor = booReadNumberAreaEnabled || booReadBoolAreaEnabled ? Color.Black : Color.Gray;
                txtReadAddress.Enabled = booReadNumberAreaEnabled || booReadBoolAreaEnabled;
                txtBit.Enabled = booReadNumberAreaEnabled;
                txtQuantity.Enabled = booReadNumberAreaEnabled || booReadBoolAreaEnabled;

                lvValues.Items.Clear();
                lvValues.BackColor = booReadNumberAreaEnabled || booReadBoolAreaEnabled ? Color.White : Color.WhiteSmoke;
                lvValues.Enabled = booReadNumberAreaEnabled || booReadBoolAreaEnabled;
                #endregion

                #region set WriteArea
                lblWriteAddress.ForeColor = booWriteNumberAreaEnabled || booWriteBoolAreaEnabled ? Color.Black : Color.Gray;
                txtWriteAddress.Enabled = booWriteNumberAreaEnabled || booWriteBoolAreaEnabled;
                #endregion

                #region set Mask write register

                if (myFunction == eMBFunction.F22_Mask_Write_Register)
                {
                    lblWriteAddress.ForeColor = Color.Black;
                    txtWriteAddress.Enabled = true;
                }

                #endregion

                #region set read write register

                if (myFunction == eMBFunction.F23_Read_Write_Multiple_Registers)
                {

                    lblWriteAddress.ForeColor = Color.Black;
                    txtWriteAddress.Enabled = true;

                    lblReadAddress.ForeColor = Color.Black;
                    lblQuantity.ForeColor = Color.Black;
                    txtReadAddress.Enabled = true;
                    txtQuantity.Enabled = true;
                    lvValues.Enabled = true;

                }

                #endregion

                #region set byteorder
                if (myFunction == eMBFunction.F03_Read_Holding_Registers ||
                    myFunction == eMBFunction.F04_Read_Input_Register ||
                    myFunction == eMBFunction.F06_Write_Single_Register ||
                    myFunction == eMBFunction.F16_Write_Multiple_Registers ||
                    myFunction == eMBFunction.F23_Read_Write_Multiple_Registers ||
                    myFunction == eMBFunction.Auto_Write_Register)
                {
                    cmbDataType.Enabled = true;
                    RefreshDataTypeOptions(myFunction, true);

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
                }

                else
                {
                    cmbByteOrder.Enabled = false;
                    cmbDataType.Enabled = false;
                    cmbDataType.DataSource = new eDataType[] { eDataType.BOOLEAN };
                    cmbDataType.SelectedItem = eDataType.BOOLEAN;
                }

                #endregion

                #region set input controls for write operations

                if (myFunction == eMBFunction.F05_Write_Single_Coil ||
                   myFunction == eMBFunction.F15_Write_Multiple_Coils ||
                   myFunction == eMBFunction.F06_Write_Single_Register ||
                   myFunction == eMBFunction.F16_Write_Multiple_Registers ||
                   myFunction == eMBFunction.F22_Mask_Write_Register ||
                   myFunction == eMBFunction.F23_Read_Write_Multiple_Registers ||
                   myFunction == eMBFunction.Auto_Write_Coils ||
                   myFunction == eMBFunction.Auto_Write_Register)
                {
                    grbWriteValues.Enabled = true;

                    switch (myFunction)
                    {
                        case eMBFunction.Auto_Write_Coils:
                            txtMultipleValues.Text = C_Values_Multiple_Coil;
                            chkSingleValue.Checked = true;
                            chkSingleValue.Visible = true;
                            rbOn.Visible = chkSingleValue.Checked;
                            rbOff.Visible = chkSingleValue.Checked;
                            rbOn.Checked = true;
                            txtSingleValues.Visible = false;
                            txtMultipleValues.Visible = !chkSingleValue.Checked;
                            lblEnterValues.Visible = true;
                            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                                        resources.GetString("lblValues_Text") :
                                                        resources.GetString("lblMultipleValues_Text");

                            lblWriteMaskRegister_AND.Visible = false;
                            lblWriteMaskRegister_OR.Visible = false;
                            txtAND.Visible = false;
                            txtOR.Visible = false;
                            break;
                        case eMBFunction.Auto_Write_Register:
                            txtMultipleValues.Text = C_Values_Multiple_Register;
                            chkSingleValue.Checked = true;
                            chkSingleValue.Visible = true;
                            rbOn.Visible = false;
                            rbOff.Visible = false;
                            txtSingleValues.Visible = true;
                            txtSingleValues.Visible = chkSingleValue.Checked;
                            txtMultipleValues.Visible = !chkSingleValue.Checked;
                            txtSingleValues.Text = C_Values_Single_Register;
                            lblEnterValues.Visible = true;
                            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                                        resources.GetString("lblValues_Text") :
                                                        resources.GetString("lblMultipleValues_Text");

                            lblWriteMaskRegister_AND.Visible = false;
                            lblWriteMaskRegister_OR.Visible = false;
                            txtAND.Visible = false;
                            txtOR.Visible = false;
                            break;
                        case eMBFunction.F05_Write_Single_Coil:
                            txtMultipleValues.Text = C_Values_Multiple_Coil;
                            chkSingleValue.Visible = true;
                            chkSingleValue.Checked = true;
                            rbOn.Visible = chkSingleValue.Checked;
                            rbOff.Visible = chkSingleValue.Checked;
                            rbOn.Checked = true;
                            txtSingleValues.Visible = false;
                            txtMultipleValues.Visible = !chkSingleValue.Checked;
                            lblEnterValues.Visible = true;
                            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                                        resources.GetString("lblValues_Text") :
                                                        resources.GetString("lblMultipleValues_Text");

                            lblWriteMaskRegister_AND.Visible = false;
                            lblWriteMaskRegister_OR.Visible = false;
                            txtAND.Visible = false;
                            txtOR.Visible = false;
                            break;
                        case eMBFunction.F06_Write_Single_Register:
                            txtSingleValues.Text = C_Values_Single_Register;
                            txtMultipleValues.Text = C_Values_Multiple_Register;
                            chkSingleValue.Visible = true;
                            chkSingleValue.Checked = true;
                            rbOn.Visible = false;
                            rbOff.Visible = false;
                            txtSingleValues.Visible = chkSingleValue.Checked;
                            txtMultipleValues.Visible = !chkSingleValue.Checked;
                            lblEnterValues.Visible = true;
                            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                                        resources.GetString("lblValues_Text") :
                                                        resources.GetString("lblMultipleValues_Text");

                            lblWriteMaskRegister_AND.Visible = false;
                            lblWriteMaskRegister_OR.Visible = false;
                            txtAND.Visible = false;
                            txtOR.Visible = false;
                            break;
                        case eMBFunction.F15_Write_Multiple_Coils:
                            txtSingleValues.Text = C_Values_Single_Register;
                            txtMultipleValues.Text = C_Values_Multiple_Coil;
                            chkSingleValue.Checked = false;
                            chkSingleValue.Visible = true;
                            rbOn.Visible = chkSingleValue.Checked;
                            rbOff.Visible = chkSingleValue.Checked;
                            rbOn.Checked = true;
                            txtSingleValues.Visible = false;
                            txtMultipleValues.Visible = !chkSingleValue.Checked;
                            lblEnterValues.Visible = true;
                            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                                        resources.GetString("lblValues_Text") :
                                                        resources.GetString("lblMultipleValues_Text");

                            lblWriteMaskRegister_AND.Visible = false;
                            lblWriteMaskRegister_OR.Visible = false;
                            txtAND.Visible = false;
                            txtOR.Visible = false;
                            break;
                        case eMBFunction.F16_Write_Multiple_Registers:
                            txtMultipleValues.Text = C_Values_Multiple_Register;
                            chkSingleValue.Checked = false;
                            chkSingleValue.Visible = true;
                            rbOn.Visible = false;
                            rbOff.Visible = false;
                            txtSingleValues.Visible = chkSingleValue.Checked;
                            txtMultipleValues.Visible = !chkSingleValue.Checked;
                            lblEnterValues.Visible = true;
                            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                                        resources.GetString("lblValues_Text") :
                                                        resources.GetString("lblMultipleValues_Text");

                            lblWriteMaskRegister_AND.Visible = false;
                            lblWriteMaskRegister_OR.Visible = false;
                            txtAND.Visible = false;
                            txtOR.Visible = false;
                            break;
                        case eMBFunction.F22_Mask_Write_Register:
                            chkSingleValue.Visible = false;
                            rbOn.Visible = false;
                            rbOff.Visible = false;
                            txtSingleValues.Visible = false;
                            txtMultipleValues.Visible = false;
                            lblEnterValues.Visible = false;

                            lblWriteMaskRegister_AND.Visible = true;
                            lblWriteMaskRegister_OR.Visible = true;
                            txtAND.Visible = true;
                            txtOR.Visible = true;
                            break;
                        case eMBFunction.F23_Read_Write_Multiple_Registers:
                            txtSingleValues.Text = C_Values_Single_Register;
                            txtMultipleValues.Text = C_Values_Multiple_Register;
                            chkSingleValue.Checked = false;
                            chkSingleValue.Visible = true;
                            rbOn.Visible = false;
                            rbOff.Visible = false;
                            txtSingleValues.Visible = chkSingleValue.Checked;
                            txtMultipleValues.Visible = !chkSingleValue.Checked;
                            lblEnterValues.Visible = true;
                            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                                        resources.GetString("lblValues_Text") :
                                                        resources.GetString("lblMultipleValues_Text");

                            lblWriteMaskRegister_AND.Visible = false;
                            lblWriteMaskRegister_OR.Visible = false;
                            txtAND.Visible = false;
                            txtOR.Visible = false;
                            break;
                    }
                }
                else
                {
                    grbWriteValues.Enabled = false;
                }

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshDataTypeOptions(eMBFunction function, bool selectDefault)
        {
            eDataType selected = cmbDataType.SelectedItem is eDataType ? (eDataType)cmbDataType.SelectedItem : GetDefaultRegisterDataType();
            eDataType[] options = GetDataTypeOptions(function);
            cmbDataType.DataSource = options;

            if (!selectDefault && Array.IndexOf(options, selected) >= 0)
            {
                cmbDataType.SelectedItem = selected;
                return;
            }

            cmbDataType.SelectedItem = GetDefaultRegisterDataType();
        }

        private eDataType[] GetDataTypeOptions(eMBFunction function)
        {
            if (Device.RegisterMode == eRegisterMode._64Bit && IsRegisterDataFunction(function))
            {
                if (function == eMBFunction.F03_Read_Holding_Registers || function == eMBFunction.F04_Read_Input_Register)
                {
                    return new eDataType[] { eDataType.BOOLEAN, eDataType.LONG, eDataType.ULONG, eDataType.DOUBLE, eDataType.PLC_LINT, eDataType.PLC_LWORD };
                }

                return new eDataType[] { eDataType.LONG, eDataType.ULONG, eDataType.DOUBLE, eDataType.PLC_LINT, eDataType.PLC_LWORD };
            }

            return (eDataType[])Enum.GetValues(typeof(eDataType));
        }

        private bool IsRegisterDataFunction(eMBFunction function)
        {
            return function == eMBFunction.F03_Read_Holding_Registers ||
                function == eMBFunction.F04_Read_Input_Register ||
                function == eMBFunction.F06_Write_Single_Register ||
                function == eMBFunction.F16_Write_Multiple_Registers ||
                function == eMBFunction.F23_Read_Write_Multiple_Registers ||
                function == eMBFunction.Auto_Write_Register;
        }

        private eDataType GetDefaultRegisterDataType()
        {
            return Device.RegisterMode == eRegisterMode._16Bit
                ? eDataType.USHORT
                : Device.RegisterMode == eRegisterMode._32Bit
                    ? eDataType.UINTEGER
                    : eDataType.ULONG;
        }

        private void cmbSlaveID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //TypeOfCommunication = ASCII or RTU and  slave id = 0 then broadcast mode will be enabled
                lblBroadcast.Visible = (int)cmbSlaveID.SelectedItem == 0 &&
                    (Device.Connector.TypeOfCommunication == eTypeOfCommunication.ASCII ||
                    Device.Connector.TypeOfCommunication == eTypeOfCommunication.RTU ||
                    Device.Connector.TypeOfCommunication == eTypeOfCommunication.RTU_over_TCP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            switch ((eMBFunction)cmbFunction.SelectedItem)
            {
                case eMBFunction.F01_Read_Coils:
                case eMBFunction.F02_Read_Discrete_Inputs:
                case eMBFunction.F03_Read_Holding_Registers:
                case eMBFunction.F04_Read_Input_Register:
                    //execute read
                    ExecRead();
                    break;
                case eMBFunction.Auto_Write_Coils:
                case eMBFunction.Auto_Write_Register:
                case eMBFunction.F05_Write_Single_Coil:
                case eMBFunction.F06_Write_Single_Register:
                case eMBFunction.F15_Write_Multiple_Coils:
                case eMBFunction.F16_Write_Multiple_Registers:
                    //execute write
                    ExecWrite();
                    break;
                case eMBFunction.F22_Mask_Write_Register:
                    //execute mask write register
                    ExecMaskWrite();
                    break;
                case eMBFunction.F23_Read_Write_Multiple_Registers:
                    //execute read write
                    ExecReadWrite();
                    break;
            }
        }

        private void ExecRead()
        {
            try
            {
                ReadRequest myReadRequest = null;
                //declare a ReadRequest object
                //and set the request parameters

                //read only allowed
                if (!(cmbFunction.SelectedItem is eReadFunction || cmbFunction.SelectedItem is eReadWriteFunction))
                {
                    MessageBox.Show(resources.GetString("wrong_function"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if ((eDataType)cmbDataType.SelectedItem == eDataType.BOOLEAN &&
                    ((eReadFunction)cmbFunction.SelectedItem == eReadFunction.F03_Read_Holding_Registers ||
                    (eReadFunction)cmbFunction.SelectedItem == eReadFunction.F04_Read_Input_Register))
                {

                    myReadRequest = RequestBuilder.ReadRequestBuilder.Create(int.Parse(cmbSlaveID.Text),                //Slave ID
                                                                           (eReadFunction)cmbFunction.SelectedItem,     //modbus function
                                                                           ushort.Parse(txtReadAddress.Text),           //Read start adress
                                                                           (eDataType)cmbDataType.SelectedItem,         //Target Datatype
                                                                           int.Parse(txtQuantity.Text),                 //quantity of objects to be read
                                                                           byte.Parse(txtBit.Text));                    //Address of first Bit by reading register
                }
                else
                {
                    myReadRequest = RequestBuilder.ReadRequestBuilder.Create(int.Parse(cmbSlaveID.Text),                //Slave ID
                                                                           (eReadFunction)cmbFunction.SelectedItem,     //modbus function
                                                                           ushort.Parse(txtReadAddress.Text),           //Read start adress
                                                                           (eDataType)cmbDataType.SelectedItem,         //Target Datatype
                                                                           int.Parse(txtQuantity.Text));                //quantity of objects to be read)
                }

                //set eventual byte order, standard = eByteOrder.AB_CD;
                myReadRequest.ByteOrder = (eByteOrder)cmbByteOrder.SelectedValue;

                //read from device
                ReadResult res = Device.Read(myReadRequest);

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

                //evaluate values
                lvValues.Items.Clear();
                lvValues.Columns[1].Text = (res.Function == eMBFunction.F03_Read_Holding_Registers || res.Function == eMBFunction.F04_Read_Input_Register) ? "Register" : "Address";
                if (res.Quality == OperationResult.eQuality.GOOD)
                {

                    foreach (ReadValue item in res.FetchValues())
                    {
                        lvi = new ListViewItem();
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, item.Address.ToString() + " / Pos" + item.AddressPosition.ToString()));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, item.Value.ToString()));
                        lvi.ForeColor = (item.Value is bool && (bool)item.Value == true ? Color.Blue : Color.Black);
                        lvValues.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ExecWrite()
        {
            try
            {
                //parse valuestring and add writable Data here
                Utilities.sValues_to_Write vtw = null;
                vtw = Utilities.CheckValues(ValuetoWrite, (eDataType)cmbDataType.SelectedItem);

                if (!vtw.ParseError)
                {
                    //last warning
                    if (MessageBox.Show(resources.GetString("Continue_Warning_Write") +
                                      Environment.NewLine +
                                      resources.GetString("Continue_Question")
                                      , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        //declare a WriteRequest object and
                        //set the request parameters
                        WriteRequest myWriteRequest = RequestBuilder.WriteRequestBuilder.Create(int.Parse(cmbSlaveID.Text), //Slave ID
                                                                                                (eWriteFunction)cmbFunction.SelectedItem,//modbus function
                                                                                                ushort.Parse(txtWriteAddress.Text));//write start adress

                        //set eventual byte order, standard = eByteOrder.AB_CD;
                        myWriteRequest.ByteOrder = (eByteOrder)cmbByteOrder.SelectedValue;

                        //add writable data to request
                        foreach (object writevalue in vtw.values)
                        {
                            switch ((eDataType)cmbDataType.SelectedItem)
                            {
                                case eDataType.BOOLEAN:
                                    myWriteRequest.AddBoolean((bool)writevalue);
                                    break;
                                case eDataType.SHORT:
                                    myWriteRequest.AddShort((short)writevalue);
                                    break;
                                case eDataType.USHORT:
                                    myWriteRequest.AddUShort((ushort)writevalue);
                                    break;
                                case eDataType.INTEGER:
                                    myWriteRequest.AddInteger((int)writevalue);
                                    break;
                                case eDataType.UINTEGER:
                                    myWriteRequest.AddUInteger((uint)writevalue);
                                    break;
                                case eDataType.LONG:
                                    myWriteRequest.AddLong((long)writevalue);
                                    break;
                                case eDataType.ULONG:
                                    myWriteRequest.AddULong((ulong)writevalue);
                                    break;
                                case eDataType.FLOAT:
                                    myWriteRequest.AddFloat((float)writevalue);
                                    break;
                                case eDataType.DOUBLE:
                                    myWriteRequest.AddDouble((double)writevalue);
                                    break;
                                case eDataType.STRING:
                                    myWriteRequest.AddString((string)writevalue);
                                    break;
                                case eDataType.PLC_INT:
                                    myWriteRequest.AddPLC_INT((short)writevalue);
                                    break;
                                case eDataType.PLC_DINT:
                                    myWriteRequest.AddPLC_DINT((int)writevalue);
                                    break;
                                case eDataType.PLC_LINT:
                                    myWriteRequest.AddPLC_LINT((long)writevalue);
                                    break;
                                case eDataType.PLC_WORD:
                                    myWriteRequest.AddPLC_WORD((ushort)writevalue);
                                    break;
                                case eDataType.PLC_DWORD:
                                    myWriteRequest.AddPLC_DWORD((uint)writevalue);
                                    break;
                                case eDataType.PLC_LWORD:
                                    myWriteRequest.AddPLC_LWORD((ulong)writevalue);
                                    break;
                                case eDataType.PLC_BCD16:
                                    myWriteRequest.AddPLC_BCD16((ushort)writevalue);
                                    break;
                                case eDataType.PLC_BCD32:
                                    myWriteRequest.AddPLC_BCD32((uint)writevalue);
                                    break;
                                case eDataType.BYTE:
                                    //abort message
                                    MessageBox.Show(resources.GetString("wrong_datatype_byte") + " " + resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                default:
                                    //abort message
                                    MessageBox.Show(resources.GetString("wrong_datatype") + " " + resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                            }
                        }

                        //write
                        WriteResult res = Device.Write(myWriteRequest);

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

                    }
                    else
                    {
                        //abort message
                        MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //parse error message
                    lvLog.Items.Clear();
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " " + resources.GetString("ParseError"));
                    lvi.ForeColor = Color.Red;
                    lvLog.Items.Add(lvi);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExecReadWrite()
        {
            try
            {
                Utilities.sValues_to_Write vtw = Utilities.CheckValues(
                    ValuetoWrite,
                    Device.RegisterMode.Equals(eRegisterMode._16Bit)
                        ? eDataType.USHORT
                        : Device.RegisterMode.Equals(eRegisterMode._32Bit)
                            ? eDataType.UINTEGER
                            : eDataType.ULONG);
                if (!vtw.ParseError)
                {
                    if (MessageBox.Show(resources.GetString("Continue_Warning_Write") +
                                      Environment.NewLine +
                                      resources.GetString("Continue_Question")
                                      , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //declare a ReadRequest object
                        //and set the request parameters
                        //ReadWriteRequest will allways using FC23
                        ReadWriteRegisterRequest myReadWriteRequest = RequestBuilder.ReadWriteRequestBuilder.Create(int.Parse(cmbSlaveID.Text),                         //Slave ID
                                                                                                                    ushort.Parse(txtReadAddress.Text),                  //ReadAddress
                                                                                                                    (eDataType)cmbDataType.SelectedItem,                //Target Datattype
                                                                                                                    int.Parse(txtQuantity.Text),                        //quantity of objects to be read
                                                                                                                    ushort.Parse(txtWriteAddress.Text));                 //WriteAddress

                        //set eventual byte order, standard = eByteOrder.AB_CD;
                        myReadWriteRequest.ByteOrder = (eByteOrder)cmbByteOrder.SelectedValue;

                        foreach (object writevalue in vtw.values)
                        {
                            if (Device.RegisterMode.Equals(eRegisterMode._16Bit))
                            {
                                myReadWriteRequest.AddUShort((ushort)writevalue);
                            }
                            else
                            {
                                if (Device.RegisterMode.Equals(eRegisterMode._32Bit))
                                    myReadWriteRequest.AddUInteger((uint)writevalue);
                                else
                                    myReadWriteRequest.AddULong((ulong)writevalue);
                            }
                        }

                        //read from device
                        ReadWriteRegisterResult res = Device.ReadWrite(myReadWriteRequest);

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

                        //evaluate values
                        lvValues.Items.Clear();
                        lvValues.Columns[1].Text = "Register";
                        if (res.Quality == OperationResult.eQuality.GOOD)
                        {
                            foreach (ReadValue item in res.FetchValues())
                            {
                                lvi = new ListViewItem();
                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, item.Address.ToString() + " / Pos" + item.AddressPosition.ToString()));
                                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, (item.Value.ToString())));
                                lvValues.Items.Add(lvi);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    lvLog.Items.Clear();
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " " + resources.GetString("ParseError"));
                    lvi.ForeColor = Color.Red;
                    lvLog.Items.Add(lvi);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExecMaskWrite()
        {
            try
            {
                //parse valuestring and add writable Data here
                Utilities.sValues_to_Write vtw = Utilities.CheckValues(txtAND.Text + Environment.NewLine + txtOR.Text, eDataType.USHORT);
                if (!vtw.ParseError)
                {
                    if (MessageBox.Show(resources.GetString("Continue_Warning_Write") +
                                      Environment.NewLine +
                                      resources.GetString("Continue_Question")
                                      , resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        //declare a WriteRequest object and
                        //set the request parameters
                        //Mask write register will allway using FC22
                        MaskWriteRegisterRequest myWriteRequest = RequestBuilder.MaskWriteRequestBuilder.Create(int.Parse(cmbSlaveID.Text), //Slave ID
                                                                                                                ushort.Parse(txtWriteAddress.Text),
                                                                                                                (ushort)vtw.values[0], //AND Mask
                                                                                                                (ushort)vtw.values[1]); //OR mask

                        //write
                        MaskWriteRegisterResult res = Device.MaskWriteRegister(myWriteRequest);

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

                    }
                    else
                    {
                        MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    lvLog.Items.Clear();
                    ListViewItem lvi = new ListViewItem(DateTime.Now.ToString() + " " + resources.GetString("ParseError"));
                    lvi.ForeColor = Color.Red;
                    lvLog.Items.Add(lvi);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkSingleValue_CheckedChanged(object sender, EventArgs e)
        {
            //switch between txtMultipleValues and txtSingleValues
            if ((eMBFunction)cmbFunction.SelectedItem == eMBFunction.F05_Write_Single_Coil || (eMBFunction)cmbFunction.SelectedItem == eMBFunction.F15_Write_Multiple_Coils || (eMBFunction)cmbFunction.SelectedItem == eMBFunction.Auto_Write_Coils)
            {
                txtSingleValues.Visible = false;
                rbOn.Visible = chkSingleValue.Checked;
                rbOff.Visible = chkSingleValue.Checked;
                ValuetoWrite = chkSingleValue.Checked ? rbOn.Checked.ToString() : txtMultipleValues.Text;
            }
            else
            {
                txtSingleValues.Visible = chkSingleValue.Checked;
                rbOn.Visible = false;
                rbOff.Visible = false;
                ValuetoWrite = chkSingleValue.Checked ? txtSingleValues.Text : txtMultipleValues.Text;
            }
            txtMultipleValues.Visible = !chkSingleValue.Checked;
            lblEnterValues.Visible = true;
            this.lblEnterValues.Text = chkSingleValue.Checked ?
                                        resources.GetString("lblValues_Text") :
                                        resources.GetString("lblMultipleValues_Text");


        }

        private void txtMultipleValues_TextChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = txtMultipleValues.Text;
        }

        private void txtSingleValues_TextChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = txtSingleValues.Text;
        }

        private void rbOff_CheckedChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = rbOn.Checked.ToString();
        }

        private void rbOn_CheckedChanged(object sender, EventArgs e)
        {
            //set writable string
            ValuetoWrite = rbOn.Checked.ToString();
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
        private void btnSaveRequest_Click(object sender, EventArgs e)
        {
            //save actual request in file
            try
            {

                string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusMaster", "PLCcomModbusSingleRequest.xml");

                // Check if the directory exists, if not, create it
                string directoryPath = Path.GetDirectoryName(targetFile);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                //Write Settings in PLCcomModbusSingleRequest.xml
                using (XmlTextWriter myXmlTextWriter = new XmlTextWriter(targetFile, System.Text.Encoding.UTF8))
                {

                    myXmlTextWriter.Formatting = Formatting.Indented;
                    myXmlTextWriter.WriteStartDocument(false);
                    myXmlTextWriter.WriteStartElement("Requests");

                    myXmlTextWriter.WriteStartElement("Request");
                    myXmlTextWriter.WriteAttributeString("Function", cmbFunction.SelectedItem.ToString());
                    myXmlTextWriter.WriteAttributeString("SlaveID", cmbSlaveID.SelectedItem.ToString());
                    myXmlTextWriter.WriteAttributeString("Target_Datatype", cmbDataType.SelectedItem.ToString());
                    myXmlTextWriter.WriteAttributeString("ByteOrder", cmbByteOrder.SelectedItem.ToString());
                    myXmlTextWriter.WriteAttributeString("ReadAddress", txtReadAddress.Text);
                    myXmlTextWriter.WriteAttributeString("Quantity", txtQuantity.Text);
                    myXmlTextWriter.WriteAttributeString("StartBit", txtBit.Text);
                    myXmlTextWriter.WriteAttributeString("WriteAddress", txtWriteAddress.Text);
                    myXmlTextWriter.WriteAttributeString("isSingleValue", chkSingleValue.Checked.ToString());
                    myXmlTextWriter.WriteAttributeString("SingleValueBool", rbOn.Checked.ToString());
                    myXmlTextWriter.WriteAttributeString("SingleValues", txtSingleValues.Text);
                    myXmlTextWriter.WriteAttributeString("MultipleValues", txtMultipleValues.Text);
                    myXmlTextWriter.WriteAttributeString("AND", txtAND.Text);
                    myXmlTextWriter.WriteAttributeString("OR", txtOR.Text);
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

        [DebuggerNonUserCode]
        private void btnLoadRequest_Click(object sender, EventArgs e)
        {
            //load request from filoe
            try
            {

                string targetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PLCcom", "ModbusMaster", "PLCcomModbusSingleRequest.xml");

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
                                    case XmlNodeType.Element:
                                        switch (reader.Name)
                                        {
                                            case "Request":

                                                eMBFunction myFunction = (eMBFunction)Enum.Parse(typeof(eMBFunction), reader.GetAttribute("Function"));

                                                //set controls
                                                switch (myFunction)
                                                {

                                                    case eMBFunction.F01_Read_Coils:
                                                    case eMBFunction.F02_Read_Discrete_Inputs:
                                                    case eMBFunction.F03_Read_Holding_Registers:
                                                    case eMBFunction.F04_Read_Input_Register:
                                                        cmbFunction.SelectedItem = (eReadFunction)myFunction;
                                                        break;
                                                    case eMBFunction.Auto_Write_Coils:
                                                    case eMBFunction.Auto_Write_Register:
                                                    case eMBFunction.F05_Write_Single_Coil:
                                                    case eMBFunction.F06_Write_Single_Register:
                                                    case eMBFunction.F15_Write_Multiple_Coils:
                                                    case eMBFunction.F16_Write_Multiple_Registers:
                                                        cmbFunction.SelectedItem = (eWriteFunction)myFunction;
                                                        break;
                                                    case eMBFunction.F22_Mask_Write_Register:
                                                        cmbFunction.SelectedItem = (eMaskWriteRegisterFunction)myFunction;
                                                        break;
                                                    case eMBFunction.F23_Read_Write_Multiple_Registers:
                                                        cmbFunction.SelectedItem = (eReadWriteFunction)myFunction;
                                                        break;
                                                    default:
                                                        return;
                                                }

                                                cmbSlaveID.SelectedItem = int.Parse(reader.GetAttribute("SlaveID"));
                                                cmbDataType.SelectedItem = (eDataType)Enum.Parse(typeof(eDataType), reader.GetAttribute("Target_Datatype"));
                                                cmbByteOrder.SelectedItem = (eByteOrder)Enum.Parse(typeof(eByteOrder), reader.GetAttribute("ByteOrder"));
                                                txtReadAddress.Text = reader.GetAttribute("ReadAddress");
                                                txtQuantity.Text = reader.GetAttribute("Quantity");
                                                txtBit.Text = reader.GetAttribute("StartBit");
                                                txtWriteAddress.Text = reader.GetAttribute("WriteAddress");
                                                chkSingleValue.Checked = bool.Parse(reader.GetAttribute("isSingleValue"));
                                                rbOn.Checked = bool.Parse(reader.GetAttribute("SingleValueBool"));
                                                txtSingleValues.Text = reader.GetAttribute("SingleValues");
                                                txtMultipleValues.Text = reader.GetAttribute("MultipleValues");
                                                txtAND.Text = reader.GetAttribute("AND");
                                                txtOR.Text = reader.GetAttribute("OR");
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


                    MessageBox.Show(resources.GetString("successfully_loaded") + Environment.NewLine +
                                    "File: " + targetFile, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch byteorder depending on the selected function
            if (cmbFunction.SelectedItem != null && cmbDataType.SelectedItem != null)
            {
                eMBFunction function = (eMBFunction)Enum.Parse(typeof(eMBFunction), cmbFunction.SelectedItem.ToString());
                if (function == eMBFunction.F03_Read_Holding_Registers ||
                    function == eMBFunction.F04_Read_Input_Register ||
                    function == eMBFunction.F06_Write_Single_Register ||
                    function == eMBFunction.F16_Write_Multiple_Registers ||
                    function == eMBFunction.F23_Read_Write_Multiple_Registers ||
                    function == eMBFunction.Auto_Write_Register)
                {
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

                else
                {
                    cmbByteOrder.Enabled = false;
                }
            }
        }

        private void ReadWriteBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.CountOpenDialogs--;
        }

    }
}
