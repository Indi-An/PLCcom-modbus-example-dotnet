Imports PLCcomModbus.Core
Imports System.Text
Imports System.Resources
Imports PLCcomModbus.Master
Imports System.IO
Imports System.Xml

Public Class ReadWriteBox

    Public Sub New(Device As ModbusMaster)
        Me.Device = Device
        InitializeComponent()
    End Sub

#Region "Private Member"
    Private Device As ModbusMaster

    Private resources As System.Resources.ResourceManager
    Private C_Values_Multiple_Coil As String = "true" + Environment.NewLine + "false" + Environment.NewLine + "false" + Environment.NewLine + "true" + Environment.NewLine
    Private C_Values_Single_Register As String = "0"
    Private C_Values_Multiple_Register As String = "0" + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine
    Private ValuetoWrite As String = String.Empty

#End Region



    Private Sub ReadWriteBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblDeviceGUID.Text = "Device Guid: " & Device.DeviceGuid.ToString()
            lblDeviceType.Text = "Adapter Type: " & Device.Connector.[GetType]().ToString()


            cmbByteOrder.DataSource = [Enum].GetValues(GetType(eByteOrder))
            cmbDataType.DataSource = [Enum].GetValues(GetType(eDataType))

            'set ressources
            resources = New ResourceManager(Me.GetType().Namespace + ".Resources", Me.GetType().Assembly)
            Me.lblLog.Text = resources.GetString("lblLog_Text")
            Me.grpAddress.Text = resources.GetString("grpAddress_Text")
            Me.grpAction.Text = resources.GetString("grpAction_Text")
            Me.lblFunction.Text = resources.GetString("lblFunction_Text")
            Me.lblSlaveID.Text = resources.GetString("lblSlaveID_Text")
            Me.lblDataType.Text = resources.GetString("lblDataType_Text")
            Me.lblReadAddress.Text = resources.GetString("lblReadAddress_Text")
            Me.lblQuantity.Text = resources.GetString("lblQuantity_Text")
            Me.lblWriteAddress.Text = resources.GetString("lblWriteAddress_Text")
            Me.btnClose.Text = resources.GetString("btnClose_Text")
            Me.btnExecute.Text = resources.GetString("btnExecute_Text")
            Me.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveSlaveLogtoClipboard_Text")
            Me.btnSaveLogtoFile.Text = resources.GetString("btnSaveSlaveLogtoFile_Text")
            Me.btnLoadRequest.Text = resources.GetString("btnLoadRequest_Text")
            Me.btnSaveRequest.Text = resources.GetString("btnSaveRequest_Text")
            Me.lblByteOrder.Text = resources.GetString("lblByteOrder_Text")
            Me.lblBroadcast.Text = resources.GetString("lblBroadcast_Text")
            Me.lblWriteMaskRegister_AND.Text = resources.GetString("lblWriteMaskRegister_AND_Text")
            Me.lblWriteMaskRegister_OR.Text = resources.GetString("lblWriteMaskRegister_OR_Text")
            Me.txtInfoRB.Text = resources.GetString("txtInfoRB_OR_Text")
            Me.chkSingleValue.Text = resources.GetString("chkSingleValue_Text")
            Me.lblWriteMaskRegister_AND.Text = resources.GetString("lblWriteMaskRegister_AND_Text")
            Me.lblWriteMaskRegister_OR.Text = resources.GetString("lblWriteMaskRegister_OR_Text")
            Me.lblEnterValues.Text = resources.GetString("lblValues_Text")

            'Set cmbFunction datasource
            Dim lisAllFunctions As New List(Of Object)()
            For Each FunctionEntry As eReadFunction In [Enum].GetValues(GetType(eReadFunction))
                cmbFunction.Items.Add(FunctionEntry)
            Next
            For Each FunctionEntry As eWriteFunction In [Enum].GetValues(GetType(eWriteFunction))
                cmbFunction.Items.Add(FunctionEntry)
            Next
            For Each FunctionEntry As eMaskWriteRegisterFunction In [Enum].GetValues(GetType(eMaskWriteRegisterFunction))
                cmbFunction.Items.Add(FunctionEntry)
            Next
            For Each FunctionEntry As eReadWriteFunction In [Enum].GetValues(GetType(eReadWriteFunction))
                cmbFunction.Items.Add(FunctionEntry)
            Next

            cmbFunction.Sorted = True
            cmbFunction.SelectedItem = eReadFunction.F01_Read_Coils

            'init slave id
            Dim lisSlaveID As New List(Of Object)()
            For i As Integer = 0 To 247
                lisSlaveID.Add(i)
            Next
            cmbSlaveID.DataSource = lisSlaveID
            cmbSlaveID.SelectedItem = 1
            lblBroadcast.Visible = CInt(cmbSlaveID.SelectedItem) = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFunction.SelectedIndexChanged
        Try
            'set controls with specific values
            Dim myFunction As eMBFunction = DirectCast([Enum].Parse(GetType(eMBFunction), cmbFunction.SelectedItem.ToString()), eMBFunction)

            Dim booReadNumberAreaEnabled As Boolean = False
            Dim booReadBoolAreaEnabled As Boolean = False
            Dim booWriteNumberAreaEnabled As Boolean = False
            Dim booWriteBoolAreaEnabled As Boolean = False

            Select Case myFunction
                Case eMBFunction.F01_Read_Coils, eMBFunction.F02_Read_Discrete_Inputs
                    booReadNumberAreaEnabled = False
                    booReadBoolAreaEnabled = True
                    booWriteNumberAreaEnabled = False
                    booWriteBoolAreaEnabled = False
                    Exit Select
                Case eMBFunction.F03_Read_Holding_Registers, eMBFunction.F04_Read_Input_Register
                    booReadNumberAreaEnabled = True
                    booReadBoolAreaEnabled = True
                    booWriteNumberAreaEnabled = False
                    booWriteBoolAreaEnabled = False
                    Exit Select
                Case eMBFunction.F05_Write_Single_Coil, eMBFunction.F15_Write_Multiple_Coils, eMBFunction.Auto_Write_Coils
                    booReadNumberAreaEnabled = False
                    booReadBoolAreaEnabled = False
                    booWriteBoolAreaEnabled = True
                    booWriteNumberAreaEnabled = False
                    Exit Select
                Case eMBFunction.F06_Write_Single_Register, eMBFunction.F16_Write_Multiple_Registers, eMBFunction.Auto_Write_Register
                    booReadNumberAreaEnabled = False
                    booReadBoolAreaEnabled = False
                    booWriteBoolAreaEnabled = False
                    booWriteNumberAreaEnabled = True
                    Exit Select
                Case eMBFunction.F22_Mask_Write_Register
                    booReadNumberAreaEnabled = False
                    booWriteNumberAreaEnabled = False
                    booWriteBoolAreaEnabled = False
                    booReadBoolAreaEnabled = False
                    Exit Select
                Case eMBFunction.F23_Read_Write_Multiple_Registers
                    booReadNumberAreaEnabled = False
                    booWriteNumberAreaEnabled = False
                    booWriteBoolAreaEnabled = False
                    booReadBoolAreaEnabled = False
                    Exit Select
                Case eMBFunction.F07_Read_Exception_status, eMBFunction.F08_Diagnostic, eMBFunction.F11_Get_Com_event_counter, eMBFunction.F12_Get_Com_Event_Log, eMBFunction.F17_Report_Server_ID, eMBFunction.UserFunction,
                    booReadNumberAreaEnabled = False
                    booWriteNumberAreaEnabled = False
                    booWriteBoolAreaEnabled = False
                    booReadBoolAreaEnabled = False
                    Exit Select
                Case Else
                    booReadNumberAreaEnabled = False
                    booWriteNumberAreaEnabled = False
                    booWriteBoolAreaEnabled = False
                    booReadBoolAreaEnabled = False
                    Exit Select
            End Select

            'set ReadArea
            lblReadAddress.ForeColor = If(booReadNumberAreaEnabled OrElse booReadBoolAreaEnabled, Color.Black, Color.Gray)
            lblBit.ForeColor = If(booReadNumberAreaEnabled, Color.Black, Color.Gray)
            lblQuantity.ForeColor = If(booReadNumberAreaEnabled OrElse booReadBoolAreaEnabled, Color.Black, Color.Gray)
            txtReadAddress.Enabled = booReadNumberAreaEnabled OrElse booReadBoolAreaEnabled
            txtBit.Enabled = booReadNumberAreaEnabled
            txtQuantity.Enabled = booReadNumberAreaEnabled OrElse booReadBoolAreaEnabled

            lvValues.Items.Clear()
            lvValues.BackColor = If(booReadNumberAreaEnabled OrElse booReadBoolAreaEnabled, Color.White, Color.WhiteSmoke)
            lvValues.Enabled = booReadNumberAreaEnabled OrElse booReadBoolAreaEnabled

            'set WriteArea
            lblWriteAddress.ForeColor = If(booWriteNumberAreaEnabled OrElse booWriteBoolAreaEnabled, Color.Black, Color.Gray)
            txtWriteAddress.Enabled = booWriteNumberAreaEnabled OrElse booWriteBoolAreaEnabled

            'set Mask write register
            If myFunction = eMBFunction.F22_Mask_Write_Register Then
                lblWriteAddress.ForeColor = Color.Black
                txtWriteAddress.Enabled = True
            End If

            'set read write register
            If myFunction = eMBFunction.F23_Read_Write_Multiple_Registers Then

                lblWriteAddress.ForeColor = Color.Black
                txtWriteAddress.Enabled = True

                lblReadAddress.ForeColor = Color.Black
                lblQuantity.ForeColor = Color.Black
                txtReadAddress.Enabled = True
                txtQuantity.Enabled = True

                lvValues.Enabled = True
            End If

            'set byteorder
            If myFunction = eMBFunction.F03_Read_Holding_Registers OrElse myFunction = eMBFunction.F04_Read_Input_Register OrElse myFunction = eMBFunction.F06_Write_Single_Register OrElse myFunction = eMBFunction.F16_Write_Multiple_Registers OrElse myFunction = eMBFunction.F23_Read_Write_Multiple_Registers OrElse myFunction = eMBFunction.Auto_Write_Register Then
                cmbDataType.Enabled = True
                RefreshDataTypeOptions(myFunction, True)

                If DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BOOLEAN] OrElse DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BYTE] OrElse DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[STRING] Then
                    cmbByteOrder.Enabled = False
                Else
                    cmbByteOrder.Enabled = True
                End If
            Else

                cmbByteOrder.Enabled = False
                cmbDataType.Enabled = False
                cmbDataType.DataSource = New eDataType() {eDataType.[BOOLEAN]}
                cmbDataType.SelectedItem = eDataType.[BOOLEAN]
            End If


            'set input controls for write operations
            If myFunction = eMBFunction.F05_Write_Single_Coil OrElse myFunction = eMBFunction.F15_Write_Multiple_Coils OrElse myFunction = eMBFunction.F06_Write_Single_Register OrElse myFunction = eMBFunction.F16_Write_Multiple_Registers OrElse myFunction = eMBFunction.F22_Mask_Write_Register OrElse myFunction = eMBFunction.F23_Read_Write_Multiple_Registers OrElse myFunction = eMBFunction.Auto_Write_Coils OrElse myFunction = eMBFunction.Auto_Write_Register Then
                grbWriteValues.Enabled = True

                Select Case myFunction
                    Case eMBFunction.Auto_Write_Coils
                        txtMultipleValues.Text = C_Values_Multiple_Coil
                        chkSingleValue.Checked = True
                        chkSingleValue.Visible = True
                        rbOn.Visible = chkSingleValue.Checked
                        rbOff.Visible = chkSingleValue.Checked
                        rbOn.Checked = True
                        txtSingleValues.Visible = False
                        txtMultipleValues.Visible = Not chkSingleValue.Checked
                        lblEnterValues.Visible = True
                        Me.lblEnterValues.Text = If(chkSingleValue.Checked, resources.GetString("lblValues_Text"), resources.GetString("lblMultipleValues_Text"))

                        lblWriteMaskRegister_AND.Visible = False
                        lblWriteMaskRegister_OR.Visible = False
                        txtAND.Visible = False
                        txtOR.Visible = False
                        Exit Select
                    Case eMBFunction.Auto_Write_Register
                        txtMultipleValues.Text = C_Values_Multiple_Register
                        chkSingleValue.Checked = True
                        chkSingleValue.Visible = True
                        rbOn.Visible = False
                        rbOff.Visible = False
                        txtSingleValues.Visible = True
                        txtSingleValues.Visible = chkSingleValue.Checked
                        txtMultipleValues.Visible = Not chkSingleValue.Checked
                        txtSingleValues.Text = C_Values_Single_Register
                        lblEnterValues.Visible = True
                        Me.lblEnterValues.Text = If(chkSingleValue.Checked, resources.GetString("lblValues_Text"), resources.GetString("lblMultipleValues_Text"))

                        lblWriteMaskRegister_AND.Visible = False
                        lblWriteMaskRegister_OR.Visible = False
                        txtAND.Visible = False
                        txtOR.Visible = False
                        Exit Select
                    Case eMBFunction.F05_Write_Single_Coil
                        txtMultipleValues.Text = C_Values_Multiple_Coil
                        chkSingleValue.Visible = True
                        chkSingleValue.Checked = True
                        rbOn.Visible = chkSingleValue.Checked
                        rbOff.Visible = chkSingleValue.Checked
                        rbOn.Checked = True
                        txtSingleValues.Visible = False
                        txtMultipleValues.Visible = Not chkSingleValue.Checked
                        lblEnterValues.Visible = True
                        Me.lblEnterValues.Text = If(chkSingleValue.Checked, resources.GetString("lblValues_Text"), resources.GetString("lblMultipleValues_Text"))

                        lblWriteMaskRegister_AND.Visible = False
                        lblWriteMaskRegister_OR.Visible = False
                        txtAND.Visible = False
                        txtOR.Visible = False
                        Exit Select
                    Case eMBFunction.F06_Write_Single_Register
                        txtSingleValues.Text = C_Values_Single_Register
                        txtMultipleValues.Text = C_Values_Multiple_Register
                        chkSingleValue.Visible = True
                        chkSingleValue.Checked = True
                        rbOn.Visible = False
                        rbOff.Visible = False
                        txtSingleValues.Visible = chkSingleValue.Checked
                        txtMultipleValues.Visible = Not chkSingleValue.Checked
                        lblEnterValues.Visible = True
                        Me.lblEnterValues.Text = If(chkSingleValue.Checked, resources.GetString("lblValues_Text"), resources.GetString("lblMultipleValues_Text"))

                        lblWriteMaskRegister_AND.Visible = False
                        lblWriteMaskRegister_OR.Visible = False
                        txtAND.Visible = False
                        txtOR.Visible = False
                        Exit Select
                    Case eMBFunction.F15_Write_Multiple_Coils
                        txtSingleValues.Text = C_Values_Single_Register
                        txtMultipleValues.Text = C_Values_Multiple_Coil
                        chkSingleValue.Checked = False
                        chkSingleValue.Visible = True
                        rbOn.Visible = chkSingleValue.Checked
                        rbOff.Visible = chkSingleValue.Checked
                        rbOn.Checked = True
                        txtSingleValues.Visible = False
                        txtMultipleValues.Visible = Not chkSingleValue.Checked
                        lblEnterValues.Visible = True
                        Me.lblEnterValues.Text = If(chkSingleValue.Checked, resources.GetString("lblValues_Text"), resources.GetString("lblMultipleValues_Text"))

                        lblWriteMaskRegister_AND.Visible = False
                        lblWriteMaskRegister_OR.Visible = False
                        txtAND.Visible = False
                        txtOR.Visible = False
                        Exit Select
                    Case eMBFunction.F16_Write_Multiple_Registers
                        txtMultipleValues.Text = C_Values_Multiple_Register
                        chkSingleValue.Checked = False
                        chkSingleValue.Visible = True
                        rbOn.Visible = False
                        rbOff.Visible = False
                        txtSingleValues.Visible = chkSingleValue.Checked
                        txtMultipleValues.Visible = Not chkSingleValue.Checked
                        lblEnterValues.Visible = True
                        Me.lblEnterValues.Text = If(chkSingleValue.Checked, resources.GetString("lblValues_Text"), resources.GetString("lblMultipleValues_Text"))

                        lblWriteMaskRegister_AND.Visible = False
                        lblWriteMaskRegister_OR.Visible = False
                        txtAND.Visible = False
                        txtOR.Visible = False
                        Exit Select
                    Case eMBFunction.F22_Mask_Write_Register
                        chkSingleValue.Visible = False
                        rbOn.Visible = False
                        rbOff.Visible = False
                        txtSingleValues.Visible = False
                        txtMultipleValues.Visible = False
                        lblEnterValues.Visible = False

                        lblWriteMaskRegister_AND.Visible = True
                        lblWriteMaskRegister_OR.Visible = True
                        txtAND.Visible = True
                        txtOR.Visible = True
                        Exit Select
                    Case eMBFunction.F23_Read_Write_Multiple_Registers
                        txtSingleValues.Text = C_Values_Single_Register
                        txtMultipleValues.Text = C_Values_Multiple_Register
                        chkSingleValue.Checked = False
                        chkSingleValue.Visible = True
                        rbOn.Visible = False
                        rbOff.Visible = False
                        txtSingleValues.Visible = chkSingleValue.Checked
                        txtMultipleValues.Visible = Not chkSingleValue.Checked
                        lblEnterValues.Visible = True
                        Me.lblEnterValues.Text = If(chkSingleValue.Checked, resources.GetString("lblValues_Text"), resources.GetString("lblMultipleValues_Text"))

                        lblWriteMaskRegister_AND.Visible = False
                        lblWriteMaskRegister_OR.Visible = False
                        txtAND.Visible = False
                        txtOR.Visible = False
                        Exit Select
                End Select
            Else
                grbWriteValues.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub RefreshDataTypeOptions(functionCode As eMBFunction, selectDefault As Boolean)
        Dim selected As eDataType = GetDefaultRegisterDataType()
        If cmbDataType.SelectedItem IsNot Nothing Then
            selected = DirectCast(cmbDataType.SelectedItem, eDataType)
        End If

        Dim options As eDataType() = GetDataTypeOptions(functionCode)
        cmbDataType.DataSource = options

        If Not selectDefault AndAlso Array.IndexOf(options, selected) >= 0 Then
            cmbDataType.SelectedItem = selected
            Return
        End If

        cmbDataType.SelectedItem = GetDefaultRegisterDataType()
    End Sub

    Private Function GetDataTypeOptions(functionCode As eMBFunction) As eDataType()
        If Device.RegisterMode = eRegisterMode._64Bit AndAlso IsRegisterDataFunction(functionCode) Then
            If functionCode = eMBFunction.F03_Read_Holding_Registers OrElse functionCode = eMBFunction.F04_Read_Input_Register Then
                Return New eDataType() {eDataType.[BOOLEAN], eDataType.[LONG], eDataType.[ULONG], eDataType.[DOUBLE], eDataType.PLC_LINT, eDataType.PLC_LWORD}
            End If

            Return New eDataType() {eDataType.[LONG], eDataType.[ULONG], eDataType.[DOUBLE], eDataType.PLC_LINT, eDataType.PLC_LWORD}
        End If

        Return DirectCast([Enum].GetValues(GetType(eDataType)), eDataType())
    End Function

    Private Function IsRegisterDataFunction(functionCode As eMBFunction) As Boolean
        Return functionCode = eMBFunction.F03_Read_Holding_Registers _
            OrElse functionCode = eMBFunction.F04_Read_Input_Register _
            OrElse functionCode = eMBFunction.F06_Write_Single_Register _
            OrElse functionCode = eMBFunction.F16_Write_Multiple_Registers _
            OrElse functionCode = eMBFunction.F23_Read_Write_Multiple_Registers _
            OrElse functionCode = eMBFunction.Auto_Write_Register
    End Function

    Private Function GetDefaultRegisterDataType() As eDataType
        Return If(Device.RegisterMode = eRegisterMode._16Bit, eDataType.[USHORT], If(Device.RegisterMode = eRegisterMode._32Bit, eDataType.[UINTEGER], eDataType.[ULONG]))
    End Function

    Private Sub cmbSlaveID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSlaveID.SelectedIndexChanged
        Try
            'TypeOfCommunication = ASCII or RTU and  slave id = 0 then broadcast mode will be enabled
            lblBroadcast.Visible = CInt(cmbSlaveID.SelectedItem) = 0 AndAlso (Device.Connector.TypeOfCommunication = eTypeOfCommunication.ASCII _
                OrElse Device.Connector.TypeOfCommunication = eTypeOfCommunication.RTU _
                OrElse Device.Connector.TypeOfCommunication = eTypeOfCommunication.RTU_over_TCP)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        Select Case DirectCast(cmbFunction.SelectedItem, eMBFunction)
            Case eMBFunction.F01_Read_Coils, eMBFunction.F02_Read_Discrete_Inputs, eMBFunction.F03_Read_Holding_Registers, eMBFunction.F04_Read_Input_Register
                'execute read
                ExecRead()
                Exit Select
            Case eMBFunction.Auto_Write_Coils, eMBFunction.Auto_Write_Register, eMBFunction.F05_Write_Single_Coil, eMBFunction.F06_Write_Single_Register, eMBFunction.F15_Write_Multiple_Coils, eMBFunction.F16_Write_Multiple_Registers
                'execute write
                ExecWrite()
                Exit Select
            Case eMBFunction.F22_Mask_Write_Register
                'execute mask write register
                ExecMaskWrite()
                Exit Select
            Case eMBFunction.F23_Read_Write_Multiple_Registers
                'execute read write
                ExecReadWrite()
                Exit Select
        End Select

    End Sub
    Private Sub ExecRead()
        Try
            Dim myReadRequest As ReadRequest = Nothing
            'declare a ReadRequest object
            'and set the request parameters

            'read only allowed
            If Not (TypeOf cmbFunction.SelectedItem Is eReadFunction OrElse TypeOf cmbFunction.SelectedItem Is eReadWriteFunction) Then
                MessageBox.Show(resources.GetString("wrong_function"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BOOLEAN] AndAlso (DirectCast(cmbFunction.SelectedItem, eReadFunction) = eReadFunction.F03_Read_Holding_Registers OrElse DirectCast(cmbFunction.SelectedItem, eReadFunction) = eReadFunction.F04_Read_Input_Register) Then

                'Slave ID
                'modbus function
                'Read start adress
                'Target Datatype
                'quantity of objects to be read
                'Address of first Bit by reading register
                myReadRequest = RequestBuilder.ReadRequestBuilder.Create(CInt(cmbSlaveID.Text), DirectCast(cmbFunction.SelectedItem, eReadFunction), UShort.Parse(txtReadAddress.Text), DirectCast(cmbDataType.SelectedItem, eDataType), Integer.Parse(txtQuantity.Text), Byte.Parse(txtBit.Text))
            Else
                'Slave ID
                'modbus function
                'Read start adress
                'Target Datatype
                'quantity of objects to be read)
                myReadRequest = RequestBuilder.ReadRequestBuilder.Create(CInt(cmbSlaveID.Text), DirectCast(cmbFunction.SelectedItem, eReadFunction), UShort.Parse(txtReadAddress.Text), DirectCast(cmbDataType.SelectedItem, eDataType), Integer.Parse(txtQuantity.Text))
            End If

            'set eventual byte order, standard = eByteOrder.AB_CD;
            myReadRequest.ByteOrder = DirectCast(cmbByteOrder.SelectedValue, eByteOrder)

            'read from device
            Dim res As ReadResult = Device.Read(myReadRequest)

            'evaluate results

            'set diagnostic output
            lvLog.Items.Clear()
            Dim lvi As New ListViewItem((DateTime.Now.ToString() & " Message: ") + res.Message)
            lvi.ForeColor = If(res.Quality = OperationResult.eQuality.GOOD, Color.Black, Color.Red)
            lvLog.Items.Add(lvi)
            For Each le As LogEntry In res.GetDiagnosticLog()
                lvi = New ListViewItem(le.ToString())
                lvi.ForeColor = If(le.getLogLevel() = eLogLevel.Information, Color.Black, Color.Red)
                lvLog.Items.Add(lvi)
            Next

            'evaluate values
            lvValues.Items.Clear()
            lvValues.Columns(1).Text = If((res.[Function] = eMBFunction.F03_Read_Holding_Registers OrElse res.[Function] = eMBFunction.F04_Read_Input_Register), "Register", "Address")
            If res.Quality = OperationResult.eQuality.GOOD Then

                For Each item As ReadValue In res.FetchValues()
                    lvi = New ListViewItem()
                    lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, item.Address.ToString() & " / Pos" & item.AddressPosition.ToString()))
                    lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, item.Value.ToString()))
                    lvi.ForeColor = (If(TypeOf item.Value Is Boolean AndAlso CBool(item.Value) = True, Color.Blue, Color.Black))
                    lvValues.Items.Add(lvi)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    Private Sub ExecWrite()
        Try
            'parse valuestring and add writable Data here
            Dim vtw As Utilities.sValues_to_Write = Nothing
            vtw = Utilities.CheckValues(ValuetoWrite, DirectCast(cmbDataType.SelectedItem, eDataType))

            If Not vtw.ParseError Then
                'last warning
                If MessageBox.Show(resources.GetString("Continue_Warning_Write") + Environment.NewLine + resources.GetString("Continue_Question"), resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

                    'declare a WriteRequest object and
                    'set the request parameters
                    'Slave ID
                    'modbus function
                    Dim myWriteRequest As WriteRequest = RequestBuilder.WriteRequestBuilder.Create(Integer.Parse(cmbSlaveID.Text), DirectCast(cmbFunction.SelectedItem, eWriteFunction), UShort.Parse(txtWriteAddress.Text))
                    'write start adress
                    'set eventual byte order, standard = eByteOrder.AB_CD;
                    myWriteRequest.ByteOrder = DirectCast(cmbByteOrder.SelectedValue, eByteOrder)

                    'add writable data to request
                    For Each writevalue As Object In vtw.values
                        Select Case DirectCast(cmbDataType.SelectedItem, eDataType)
                            Case eDataType.[BOOLEAN]
                                myWriteRequest.AddBoolean(CBool(writevalue))
                                Exit Select
                            Case eDataType.[SHORT]
                                myWriteRequest.AddShort(CShort(writevalue))
                                Exit Select
                            Case eDataType.[USHORT]
                                myWriteRequest.AddUShort(CUShort(writevalue))
                                Exit Select
                            Case eDataType.[INTEGER]
                                myWriteRequest.AddInteger(CInt(writevalue))
                                Exit Select
                            Case eDataType.[UINTEGER]
                                myWriteRequest.AddUInteger(CUInt(writevalue))
                                Exit Select
                            Case eDataType.[LONG]
                                myWriteRequest.AddLong(CLng(writevalue))
                                Exit Select
                            Case eDataType.[ULONG]
                                myWriteRequest.AddULong(CULng(writevalue))
                                Exit Select
                            Case eDataType.FLOAT
                                myWriteRequest.AddFloat(CSng(writevalue))
                                Exit Select
                            Case eDataType.[DOUBLE]
                                myWriteRequest.AddDouble(CDbl(writevalue))
                                Exit Select
                            Case eDataType.[STRING]
                                myWriteRequest.AddString(DirectCast(writevalue, String))
                                Exit Select
                            Case eDataType.PLC_INT
                                myWriteRequest.AddPLC_INT(CShort(writevalue))
                                Exit Select
                            Case eDataType.PLC_DINT
                                myWriteRequest.AddPLC_DINT(CInt(writevalue))
                                Exit Select
                            Case eDataType.PLC_LINT
                                myWriteRequest.AddPLC_LINT(CLng(writevalue))
                                Exit Select
                            Case eDataType.PLC_WORD
                                myWriteRequest.AddPLC_WORD(CUShort(writevalue))
                                Exit Select
                            Case eDataType.PLC_DWORD
                                myWriteRequest.AddPLC_DWORD(CUInt(writevalue))
                                Exit Select
                            Case eDataType.PLC_LWORD
                                myWriteRequest.AddPLC_LWORD(CULng(writevalue))
                                Exit Select
                            Case eDataType.PLC_BCD16
                                myWriteRequest.AddPLC_BCD16(CUShort(writevalue))
                                Exit Select
                            Case eDataType.PLC_BCD32
                                myWriteRequest.AddPLC_BCD32(CUInt(writevalue))
                                Exit Select
                            Case eDataType.BYTE
                                'abort message
                                MessageBox.Show(resources.GetString("wrong_datatype_byte") + " " + resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return
                            Case Else
                                'abort message
                                MessageBox.Show(resources.GetString("wrong_datatype") + " " + resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Return
                        End Select
                    Next

                    'write
                    Dim res As WriteResult = Device.Write(myWriteRequest)

                    'evaluate results

                    'set diagnostic output
                    lvLog.Items.Clear()
                    Dim lvi As New ListViewItem((DateTime.Now.ToString() & " Message: ") + res.Message)
                    lvi.ForeColor = If(res.Quality = OperationResult.eQuality.GOOD, Color.Black, Color.Red)
                    lvLog.Items.Add(lvi)
                    For Each le As LogEntry In res.GetDiagnosticLog()
                        lvi = New ListViewItem(le.ToString())
                        lvi.ForeColor = If(le.getLogLevel() = eLogLevel.Information, Color.Black, Color.Red)
                        lvLog.Items.Add(lvi)

                    Next
                Else
                    'abort message
                    MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                'parse error message
                lvLog.Items.Clear()
                Dim lvi As New ListViewItem(DateTime.Now.ToString() & " " & resources.GetString("ParseError"))
                lvi.ForeColor = Color.Red
                lvLog.Items.Add(lvi)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ExecReadWrite()
        Try
            Dim vtw As Utilities.sValues_to_Write = Utilities.CheckValues(ValuetoWrite, If(Device.RegisterMode.Equals(eRegisterMode._16Bit), eDataType.[USHORT], If(Device.RegisterMode.Equals(eRegisterMode._32Bit), eDataType.[UINTEGER], eDataType.[ULONG])))
            If Not vtw.ParseError Then
                If MessageBox.Show(resources.GetString("Continue_Warning_Write") + Environment.NewLine + resources.GetString("Continue_Question"), resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                    'declare a ReadRequest object
                    'and set the request parameters
                    'ReadWriteRequest will allways using FC23
                    'Slave ID
                    'ReadAddress
                    'Target Datattype
                    'quantity of objects to be read
                    Dim myReadWriteRequest As ReadWriteRegisterRequest = RequestBuilder.ReadWriteRequestBuilder.Create(Integer.Parse(cmbSlaveID.Text), UShort.Parse(txtReadAddress.Text), DirectCast(cmbDataType.SelectedItem, eDataType), Integer.Parse(txtQuantity.Text), UShort.Parse(txtWriteAddress.Text))
                    'WriteAddress
                    'set eventual byte order, standard = eByteOrder.AB_CD;
                    myReadWriteRequest.ByteOrder = DirectCast(cmbByteOrder.SelectedValue, eByteOrder)

                    For Each writevalue As Object In vtw.values
                        If Device.RegisterMode.Equals(eRegisterMode._16Bit) Then
                            myReadWriteRequest.AddUShort(CUShort(writevalue))
                        ElseIf Device.RegisterMode.Equals(eRegisterMode._32Bit) Then
                            myReadWriteRequest.AddUInteger(CUInt(writevalue))
                        Else
                            myReadWriteRequest.AddULong(CULng(writevalue))
                        End If
                    Next

                    'read from device
                    Dim res As ReadWriteRegisterResult = Device.ReadWrite(myReadWriteRequest)

                    'evaluate results

                    'set diagnostic output
                    lvLog.Items.Clear()
                    Dim lvi As New ListViewItem((DateTime.Now.ToString() & " Message: ") + res.Message)
                    lvi.ForeColor = If(res.Quality = OperationResult.eQuality.GOOD, Color.Black, Color.Red)
                    lvLog.Items.Add(lvi)
                    For Each le As LogEntry In res.GetDiagnosticLog()
                        lvi = New ListViewItem(le.ToString())
                        lvi.ForeColor = If(le.getLogLevel() = eLogLevel.Information, Color.Black, Color.Red)
                        lvLog.Items.Add(lvi)
                    Next

                    'evaluate values
                    lvValues.Items.Clear()
                    lvValues.Columns(1).Text = "Register"
                    If res.Quality = OperationResult.eQuality.GOOD Then
                        For Each item As ReadValue In res.FetchValues()
                            lvi = New ListViewItem()
                            lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, item.Address.ToString() & " / Pos" & item.AddressPosition.ToString()))
                            lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, (item.Value.ToString())))
                            lvValues.Items.Add(lvi)
                        Next
                    End If
                Else
                    MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                lvLog.Items.Clear()
                Dim lvi As New ListViewItem(DateTime.Now.ToString() & " " & resources.GetString("ParseError"))
                lvi.ForeColor = Color.Red
                lvLog.Items.Add(lvi)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ExecMaskWrite()
        Try
            'parse valuestring and add writable Data here
            Dim vtw As Utilities.sValues_to_Write = Utilities.CheckValues(txtAND.Text + Environment.NewLine + txtOR.Text, eDataType.[USHORT])
            If Not vtw.ParseError Then
                If MessageBox.Show(resources.GetString("Continue_Warning_Write") + Environment.NewLine + resources.GetString("Continue_Question"), resources.GetString("Important_question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

                    'declare a WriteRequest object and
                    'set the request parameters
                    'Mask write register will allway using FC22
                    'Slave ID
                    'AND Mask
                    Dim myWriteRequest As MaskWriteRegisterRequest = RequestBuilder.MaskWriteRequestBuilder.Create(Integer.Parse(cmbSlaveID.Text), UShort.Parse(txtWriteAddress.Text), CUShort(vtw.values(0)), CUShort(vtw.values(1)))
                    'OR mask
                    'write
                    Dim res As MaskWriteRegisterResult = Device.MaskWriteRegister(myWriteRequest)

                    'evaluate results

                    'set diagnostic output
                    lvLog.Items.Clear()
                    Dim lvi As New ListViewItem((DateTime.Now.ToString() & " Message: ") + res.Message)
                    lvi.ForeColor = If(res.Quality = OperationResult.eQuality.GOOD, Color.Black, Color.Red)
                    lvLog.Items.Add(lvi)
                    For Each le As LogEntry In res.GetDiagnosticLog()
                        lvi = New ListViewItem(le.ToString())
                        lvi.ForeColor = If(le.getLogLevel() = eLogLevel.Information, Color.Black, Color.Red)
                        lvLog.Items.Add(lvi)

                    Next
                Else
                    MessageBox.Show(resources.GetString("operation_aborted"), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                lvLog.Items.Clear()
                Dim lvi As New ListViewItem(DateTime.Now.ToString() & " " & resources.GetString("ParseError"))
                lvi.ForeColor = Color.Red
                lvLog.Items.Add(lvi)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chkSingleValue_CheckedChanged(sender As Object, e As EventArgs) Handles chkSingleValue.CheckedChanged
        'switch between txtMultipleValues and txtSingleValues
        If DirectCast(cmbFunction.SelectedItem, eMBFunction) = eMBFunction.F05_Write_Single_Coil OrElse DirectCast(cmbFunction.SelectedItem, eMBFunction) = eMBFunction.F15_Write_Multiple_Coils OrElse DirectCast(cmbFunction.SelectedItem, eMBFunction) = eMBFunction.Auto_Write_Coils Then
            txtSingleValues.Visible = False
            rbOn.Visible = chkSingleValue.Checked
            rbOff.Visible = chkSingleValue.Checked
            ValuetoWrite = If(chkSingleValue.Checked, rbOn.Checked.ToString(), txtMultipleValues.Text)
        Else
            txtSingleValues.Visible = chkSingleValue.Checked
            rbOn.Visible = False
            rbOff.Visible = False
            ValuetoWrite = If(chkSingleValue.Checked, txtSingleValues.Text, txtMultipleValues.Text)
        End If
        txtMultipleValues.Visible = Not chkSingleValue.Checked
        lblEnterValues.Visible = True
        Me.lblEnterValues.Text = If(chkSingleValue.Checked, resources.GetString("lblValues_Text"), resources.GetString("lblMultipleValues_Text"))

    End Sub

    Private Sub txtMultipleValues_TextChanged(sender As Object, e As EventArgs) Handles txtMultipleValues.TextChanged
        'set writable string
        ValuetoWrite = txtMultipleValues.Text
    End Sub

    Private Sub txtSingleValues_TextChanged(sender As Object, e As EventArgs) Handles txtSingleValues.TextChanged
        'set writable string
        ValuetoWrite = txtSingleValues.Text
    End Sub

    Private Sub rbOff_CheckedChanged(sender As Object, e As EventArgs) Handles rbOff.CheckedChanged
        'set writable string
        ValuetoWrite = rbOn.Checked.ToString()
    End Sub

    Private Sub rbOn_CheckedChanged(sender As Object, e As EventArgs) Handles rbOn.CheckedChanged
        'set writable string
        ValuetoWrite = rbOn.Checked.ToString()
    End Sub

    Private Sub btnSaveLogtoClipboard_Click(sender As Object, e As EventArgs) Handles btnSaveLogtoClipboard.Click
        'copy diagnostic log to clipboard
        Dim sb As New StringBuilder()
        For Each lvi As ListViewItem In lvLog.Items
            sb.Append(lvi.Text)
            sb.Append(Environment.NewLine)
        Next
        If Not String.IsNullOrEmpty(sb.ToString()) Then
            Clipboard.SetText(sb.ToString(), TextDataFormat.Text)
        End If
    End Sub

    Private Sub btnSaveLogtoFile_Click(sender As Object, e As EventArgs) Handles btnSaveLogtoFile.Click
        'copy diagnostic log to file
        Dim sb As New StringBuilder()
        For Each lvi As ListViewItem In lvLog.Items
            sb.Append(lvi.Text)
            sb.Append(Environment.NewLine)
        Next

        Dim fs As FileStream = File.Create(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusDiagnosticLog.log")
        Dim bw As New BinaryWriter(fs)

        If Not String.IsNullOrEmpty(sb.ToString()) Then
            bw.Write(System.Text.Encoding.[Default].GetBytes(sb.ToString()))
        End If
        bw.Close()
        fs.Close()

        MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine + "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusDiagnosticLog.log", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    <DebuggerNonUserCode>
    Private Sub btnSaveRequest_Click(sender As Object, e As EventArgs) Handles btnSaveRequest.Click
        'save actual request in file
        Try
            'Write Settings in PLCcomModbusSingleRequest.xml
            Using myXmlTextWriter As New XmlTextWriter(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSingleRequest.xml", System.Text.Encoding.UTF8)

                myXmlTextWriter.Formatting = Formatting.Indented
                myXmlTextWriter.WriteStartDocument(False)
                myXmlTextWriter.WriteStartElement("Requests")

                myXmlTextWriter.WriteStartElement("Request")
                myXmlTextWriter.WriteAttributeString("Function", cmbFunction.SelectedItem.ToString())
                myXmlTextWriter.WriteAttributeString("SlaveID", cmbSlaveID.SelectedItem.ToString())
                myXmlTextWriter.WriteAttributeString("Target_Datatype", cmbDataType.SelectedItem.ToString())
                myXmlTextWriter.WriteAttributeString("ByteOrder", cmbByteOrder.SelectedItem.ToString())
                myXmlTextWriter.WriteAttributeString("ReadAddress", txtReadAddress.Text)
                myXmlTextWriter.WriteAttributeString("Quantity", txtQuantity.Text)
                myXmlTextWriter.WriteAttributeString("StartBit", txtBit.Text)
                myXmlTextWriter.WriteAttributeString("WriteAddress", txtWriteAddress.Text)
                myXmlTextWriter.WriteAttributeString("isSingleValue", chkSingleValue.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SingleValueBool", rbOn.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SingleValues", txtSingleValues.Text)
                myXmlTextWriter.WriteAttributeString("MultipleValues", txtMultipleValues.Text)
                myXmlTextWriter.WriteAttributeString("AND", txtAND.Text)
                myXmlTextWriter.WriteAttributeString("OR", txtOR.Text)
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndDocument()
                myXmlTextWriter.Flush()
                myXmlTextWriter.Close()
                MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine + "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSingleRequest.xml", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    <DebuggerNonUserCode>
    Private Sub btnLoadRequest_Click(sender As Object, e As EventArgs) Handles btnLoadRequest.Click
        'load request from filoe
        Try
            If File.Exists(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSingleRequest.xml") Then
                Using reader As New XmlTextReader(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSingleRequest.xml")
                    While reader.Read()
                        Try
                            Select Case reader.NodeType
                                Case XmlNodeType.Element
                                    Select Case reader.Name
                                        Case "Request"

                                            Dim myFunction As eMBFunction = DirectCast([Enum].Parse(GetType(eMBFunction), reader.GetAttribute("Function")), eMBFunction)

                                            'set controls
                                            Select Case myFunction

                                                Case eMBFunction.F01_Read_Coils, eMBFunction.F02_Read_Discrete_Inputs, eMBFunction.F03_Read_Holding_Registers, eMBFunction.F04_Read_Input_Register
                                                    cmbFunction.SelectedItem = DirectCast(myFunction, eReadFunction)
                                                    Exit Select
                                                Case eMBFunction.Auto_Write_Coils, eMBFunction.Auto_Write_Register, eMBFunction.F05_Write_Single_Coil, eMBFunction.F06_Write_Single_Register, eMBFunction.F15_Write_Multiple_Coils, eMBFunction.F16_Write_Multiple_Registers
                                                    cmbFunction.SelectedItem = DirectCast(myFunction, eWriteFunction)
                                                    Exit Select
                                                Case eMBFunction.F22_Mask_Write_Register
                                                    cmbFunction.SelectedItem = DirectCast(myFunction, eMaskWriteRegisterFunction)
                                                    Exit Select
                                                Case eMBFunction.F23_Read_Write_Multiple_Registers
                                                    cmbFunction.SelectedItem = DirectCast(myFunction, eReadWriteFunction)
                                                    Exit Select
                                                Case Else
                                                    Return
                                            End Select

                                            cmbSlaveID.SelectedItem = Integer.Parse(reader.GetAttribute("SlaveID"))
                                            cmbDataType.SelectedItem = DirectCast([Enum].Parse(GetType(eDataType), reader.GetAttribute("Target_Datatype")), eDataType)
                                            cmbByteOrder.SelectedItem = DirectCast([Enum].Parse(GetType(eByteOrder), reader.GetAttribute("ByteOrder")), eByteOrder)
                                            txtReadAddress.Text = reader.GetAttribute("ReadAddress")
                                            txtQuantity.Text = reader.GetAttribute("Quantity")
                                            txtBit.Text = reader.GetAttribute("StartBit")
                                            txtWriteAddress.Text = reader.GetAttribute("WriteAddress")
                                            chkSingleValue.Checked = Boolean.Parse(reader.GetAttribute("isSingleValue"))
                                            rbOn.Checked = Boolean.Parse(reader.GetAttribute("SingleValueBool"))
                                            txtSingleValues.Text = reader.GetAttribute("SingleValues")
                                            txtMultipleValues.Text = reader.GetAttribute("MultipleValues")
                                            txtAND.Text = reader.GetAttribute("AND")
                                            txtOR.Text = reader.GetAttribute("OR")
                                            Exit Select
                                    End Select
                                    Exit Select
                            End Select
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End Try
                    End While
                End Using


                MessageBox.Show(resources.GetString("successfully_loaded") + Environment.NewLine + "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSingleRequest.xml", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    Private Sub cmbDataType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType.SelectedIndexChanged
        'switch byteorder depending on the selected function
        If cmbFunction.SelectedItem IsNot Nothing AndAlso cmbDataType.SelectedItem IsNot Nothing Then
            Dim functionCode As eMBFunction = DirectCast([Enum].Parse(GetType(eMBFunction), cmbFunction.SelectedItem.ToString()), eMBFunction)
            If functionCode = eMBFunction.F03_Read_Holding_Registers OrElse functionCode = eMBFunction.F04_Read_Input_Register OrElse functionCode = eMBFunction.F06_Write_Single_Register OrElse functionCode = eMBFunction.F16_Write_Multiple_Registers OrElse functionCode = eMBFunction.F23_Read_Write_Multiple_Registers OrElse functionCode = eMBFunction.Auto_Write_Register Then
                If DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BOOLEAN] OrElse DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BYTE] Then
                    cmbByteOrder.Enabled = False
                Else
                    cmbByteOrder.Enabled = True
                End If
            Else

                cmbByteOrder.Enabled = False
            End If
        End If
    End Sub

    Private Sub ReadWriteBox_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        main.CountOpenDialogs -= 1
    End Sub
End Class
