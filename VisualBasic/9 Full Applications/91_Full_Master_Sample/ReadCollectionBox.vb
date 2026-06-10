Imports PLCcomModbus.Core
Imports System.Text
Imports System.Resources
Imports PLCcomModbus.Master
Imports System.IO
Imports System.Xml

Public Class ReadCollectionBox

    Public Sub New(Device As ModbusMaster)
        Me.Device = Device
        InitializeComponent()
    End Sub

#Region "Private Member"
    Dim Device As ModbusMaster
    Dim resources As System.Resources.ResourceManager
    Dim RequestCollection As New ReadRequestCollection()
#End Region


    Private Sub ReadCollectionBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblDeviceGUID.Text = "Device Guid: " & Device.DeviceGuid.ToString()
            lblDeviceType.Text = "Adapter Type: " & Device.Connector.[GetType]().ToString()

            cmbByteOrder.DataSource = [Enum].GetValues(GetType(eByteOrder))
            cmbDataType.DataSource = [Enum].GetValues(GetType(eDataType))
            cmbFunction.DataSource = [Enum].GetValues(GetType(eReadFunction))

            'set ressources
            resources = New ResourceManager(Me.GetType().Namespace + ".Resources", Me.GetType().Assembly)
            Me.lblLog.Text = resources.GetString("lblLog_Text")
            Me.grpAddress.Text = resources.GetString("grpAddress_Text")
            Me.grpAction.Text = resources.GetString("grpAction_Text")
            Me.lblFunction.Text = resources.GetString("lblFunction_Text")
            Me.lblSlaveID.Text = resources.GetString("lblSlaveID_Text")
            Me.btnClose.Text = resources.GetString("btnClose_Text")
            Me.btnAddRequest.Text = resources.GetString("btnAddRequest_Text")
            Me.btnRemoveRequest.Text = resources.GetString("btnRemoveRequest_Text")
            Me.btnReadCollection.Text = resources.GetString("btnReadCollection_Text")
            Me.btnLoadRequests.Text = resources.GetString("btnLoadRequests_Text")
            Me.btnSaveRequests.Text = resources.GetString("btnSaveRequests_Text")
            Me.txtInfoRCB.Text = resources.GetString("txtInfoRCB_Text")
            Me.lblByteOrder.Text = resources.GetString("lblByteOrder_Text")
            Me.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveSlaveLogtoClipboard_Text")
            Me.btnSaveLogtoFile.Text = resources.GetString("btnSaveSlaveLogtoFile_Text")
            Me.lblDataType.Text = resources.GetString("lblDataType_Text")
            Me.lblReadAddress.Text = resources.GetString("lblReadAddress_Text")
            Me.lblQuantity.Text = resources.GetString("lblQuantity_Text")

            'init slave id
            Dim lisSlaveID As New List(Of Object)()
            For i As Integer = 0 To 247
                lisSlaveID.Add(i)
            Next
            cmbSlaveID.DataSource = lisSlaveID
            cmbSlaveID.SelectedItem = 1

            txtRequestKey.Text = "Request_" & (RequestCollection.GetReadRequests().Length + 1).ToString("00")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnAddRequest_Click(sender As Object, e As EventArgs) Handles btnAddRequest.Click
        Try
            'define new request
            Dim RequestItem As ReadRequest = Nothing

            If DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BOOLEAN] AndAlso (DirectCast(cmbFunction.SelectedItem, eReadFunction) = eReadFunction.F03_Read_Holding_Registers OrElse DirectCast(cmbFunction.SelectedItem, eReadFunction) = eReadFunction.F04_Read_Input_Register) Then
                'Slave ID
                'modbus function
                'Read start adress
                'Target Datatype
                'quantity of objects to be read
                'Address of first Bit by reading register
                RequestItem = RequestBuilder.ReadRequestBuilder.Create(CInt(cmbSlaveID.Text), DirectCast(cmbFunction.SelectedItem, eReadFunction), UShort.Parse(txtReadAddress.Text), DirectCast(cmbDataType.SelectedItem, eDataType), Integer.Parse(txtQuantity.Text), Byte.Parse(txtBit.Text))
            Else
                'Slave ID
                'modbus function
                'Read start adress
                'Target Datatype
                'quantity of objects to be read)
                RequestItem = RequestBuilder.ReadRequestBuilder.Create(CInt(cmbSlaveID.Text), DirectCast(cmbFunction.SelectedItem, eReadFunction), UShort.Parse(txtReadAddress.Text), DirectCast(cmbDataType.SelectedItem, eDataType), Integer.Parse(txtQuantity.Text))
            End If

            'set eventual byte order, standard = eByteOrder.AB_CD;
            RequestItem.ByteOrder = DirectCast(cmbByteOrder.SelectedValue, eByteOrder)

            'add new request to request collection
            RequestCollection.AddReadRequest(txtRequestKey.Text, RequestItem)

            txtRequestKey.Text = "Request_" & (RequestCollection.GetReadRequests().Length + 1).ToString("00")

            'update listview
            fillRequestListView()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

    End Sub

    Private Sub btnRemoveRequest_Click(sender As Object, e As EventArgs) Handles btnRemoveRequest.Click
        'remove request from request collection
        Try
            If lvRequests.SelectedItems.Count <> 0 Then
                RequestCollection.RemoveReadItemRequest(lvRequests.SelectedItems(0).Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            fillRequestListView()
        End Try

    End Sub

    Private Sub lvRequests_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvRequests.SelectedIndexChanged
        btnRemoveRequest.Enabled = lvRequests.SelectedItems.Count <> 0
    End Sub

    Private Sub fillRequestListView()
        'clear ListView initial
        lvRequests.Items.Clear()

        'fill ListView with current ReadRequests
        For Each rr As ReadRequest In RequestCollection.GetReadRequests()
            Dim lvi As New ListViewItem(rr.RequestKey)
            lvi.SubItems.Add(rr.ToString())
            lvRequests.Items.Add(lvi)
        Next
    End Sub

    Private Sub btnReadCollection_Click(sender As Object, e As EventArgs) Handles btnReadCollection.Click
        Try
            ' Optmize Mode
            RequestCollection.Optmize = True

            'read from device
            Dim ResultCollection As ReadResultCollection = Device.Read(RequestCollection)

            lvValues.Items.Clear()
            lvLog.Items.Clear()
            lvValues.Columns(1).Text = "Address"

            'find itemresult with foreach-loop

            Dim lvi As ListViewItem = Nothing

            'getting readrequestcollection diagnoctic logs           
            lvi = New ListViewItem(((DateTime.Now.ToString() & " ") + ResultCollection.[GetType]().Name & " Message: ") + ResultCollection.Message)
            lvi.ForeColor = If(ResultCollection.Quality = OperationResult.eQuality.GOOD, Color.Black, Color.Red)
            lvLog.Items.Add(lvi)

            For Each le As LogEntry In ResultCollection.GetDiagnosticLog()
                lvi = New ListViewItem(le.ToString())
                lvi.ForeColor = If(le.getLogLevel() = eLogLevel.Information, Color.Black, Color.Red)
                lvLog.Items.Add(lvi)
            Next

            'evaluate results
            For Each res As ReadResult In ResultCollection.GetReadItemResult()
                If res.Quality = OperationResult.eQuality.GOOD Then
                    Dim sb As New StringBuilder()
                    sb.Append("Start Item:")
                    sb.Append(res.RequestKey)
                    sb.Append(" ")
                    sb.Append("Quality:")
                    sb.Append(" ")
                    sb.Append(res.Quality.ToString())
                    sb.Append(Environment.NewLine)

                    lvi = New ListViewItem()
                    lvi.ForeColor = If(res.Quality.Equals(OperationResult.eQuality.GOOD), Color.Black, Color.Red)
                    lvi.SubItems.Add(sb.ToString())
                    lvValues.Items.Add(lvi)

                    For Each item As ReadValue In res.FetchValues()
                        lvi = New ListViewItem()
                        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, "Address => " & item.Address.ToString() & " Position => " & item.AddressPosition.ToString()))
                        lvi.SubItems.Add(New ListViewItem.ListViewSubItem(lvi, (item.Value.ToString())))
                        lvValues.Items.Add(lvi)
                    Next

                    sb = New StringBuilder()
                    sb.Append("End Item:")
                    sb.Append(res.RequestKey)
                    lvi = New ListViewItem()
                    lvi.ForeColor = If(res.Quality.Equals(OperationResult.eQuality.GOOD), Color.Black, Color.Red)
                    lvi.SubItems.Add(sb.ToString())
                    lvValues.Items.Add(lvi)
                    lvValues.Items.Add(New ListViewItem())
                End If

                'getting readrequest diagnoctic logs           
                lvi = New ListViewItem((DateTime.Now.ToString() & (If(Not [String].IsNullOrEmpty(res.RequestKey), " " + res.RequestKey, "")) & " Message: ") + res.Message)
                lvi.ForeColor = If(res.Quality = OperationResult.eQuality.GOOD, Color.Black, Color.Red)
                lvLog.Items.Add(lvi)
                For Each le As LogEntry In res.GetDiagnosticLog()
                    lvi = New ListViewItem(le.ToString())
                    lvi.ForeColor = If(le.getLogLevel() = eLogLevel.Information, Color.Black, Color.Red)
                    lvLog.Items.Add(lvi)
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmbFunction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFunction.SelectedIndexChanged
        'switch byteorder depending on the selected function
        If DirectCast(cmbFunction.SelectedItem, eReadFunction) = eReadFunction.F03_Read_Holding_Registers OrElse DirectCast(cmbFunction.SelectedItem, eReadFunction) = eReadFunction.F04_Read_Input_Register Then
            If DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BOOLEAN] OrElse DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BYTE] OrElse DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[STRING] Then
                cmbByteOrder.Enabled = False
            Else
                cmbByteOrder.Enabled = True
            End If
            cmbDataType.Enabled = True
        Else
            cmbByteOrder.Enabled = False
            cmbDataType.Enabled = False
            cmbDataType.SelectedItem = eDataType.[BOOLEAN]
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbDataType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDataType.SelectedIndexChanged
        'switch byteorder depending on the selected data type
        If DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BOOLEAN] OrElse DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BYTE] Then
            cmbByteOrder.Enabled = False
        Else
            cmbByteOrder.Enabled = True
        End If
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
    Private Sub btnLoadRequests_Click(sender As Object, e As EventArgs) Handles btnLoadRequests.Click
        'load settings from file
        RequestCollection = New ReadRequestCollection()

        Try
            If File.Exists(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusCoreExSettings.xml") Then
                Using reader As New XmlTextReader(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusRequestCollection.xml")
                    While reader.Read()
                        Try
                            Select Case reader.NodeType

                                Case XmlNodeType.Element
                                    ' The node is an element
                                    Select Case reader.Name
                                        Case "Request"
                                            Dim RequestItem As ReadRequest = Nothing

                                            Dim rfc As eReadFunction = DirectCast([Enum].Parse(GetType(eReadFunction), reader.GetAttribute("Function")), eReadFunction)

                                            If DirectCast(cmbDataType.SelectedItem, eDataType) = eDataType.[BOOLEAN] AndAlso (rfc = eReadFunction.F03_Read_Holding_Registers OrElse (rfc = eReadFunction.F04_Read_Input_Register)) Then
                                                'Slave ID
                                                'modbus function
                                                'Read start adress
                                                'Target Datatype
                                                'quantity of objects to be read
                                                'Address of first Bit by reading register
                                                RequestItem = RequestBuilder.ReadRequestBuilder.Create(Integer.Parse(reader.GetAttribute("SlaveID")), rfc, UShort.Parse(reader.GetAttribute("ReadAddress")), DirectCast([Enum].Parse(GetType(eDataType), reader.GetAttribute("Target_Datatype")), eDataType), Integer.Parse(reader.GetAttribute("Quantity")), Byte.Parse(reader.GetAttribute("StartBit")))
                                            Else
                                                'Slave ID
                                                'modbus function
                                                'Read start adress
                                                'Target Datatype
                                                'quantity of objects to be read
                                                RequestItem = RequestBuilder.ReadRequestBuilder.Create(Integer.Parse(reader.GetAttribute("SlaveID")), rfc, UShort.Parse(reader.GetAttribute("ReadAddress")), DirectCast([Enum].Parse(GetType(eDataType), reader.GetAttribute("Target_Datatype")), eDataType), Integer.Parse(reader.GetAttribute("Quantity")))
                                            End If

                                            RequestCollection.AddReadRequest(reader.GetAttribute("RequestKey"), RequestItem)
                                            Exit Select
                                    End Select
                                    Exit Select
                            End Select
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        End Try
                    End While
                End Using

                'Refresh listview
                fillRequestListView()

                MessageBox.Show(resources.GetString("successfully_loaded") + Environment.NewLine + "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusRequestCollection.xml", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

    End Sub

    <DebuggerNonUserCode>
    Private Sub btnSaveRequests_Click(sender As Object, e As EventArgs) Handles btnSaveRequests.Click
        Try
            'save and write Settings in PLCcomModbusRequestCollection.xml
            Using myXmlTextWriter As New XmlTextWriter(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusRequestCollection.xml", System.Text.Encoding.UTF8)

                myXmlTextWriter.Formatting = Formatting.Indented
                myXmlTextWriter.WriteStartDocument(False)
                myXmlTextWriter.WriteStartElement("Requests")

                For Each rreq As ReadRequest In RequestCollection.GetReadRequests()
                    myXmlTextWriter.WriteStartElement("Request")
                    myXmlTextWriter.WriteAttributeString("RequestKey", rreq.RequestKey)
                    myXmlTextWriter.WriteAttributeString("Function", rreq.[Function].ToString())
                    myXmlTextWriter.WriteAttributeString("SlaveID", rreq.SlaveID.ToString())
                    myXmlTextWriter.WriteAttributeString("Target_Datatype", rreq.Target_Datatype.ToString())
                    myXmlTextWriter.WriteAttributeString("ByteOrder", rreq.ByteOrder.ToString())
                    myXmlTextWriter.WriteAttributeString("ReadAddress", rreq.ReadAddress.ToString())
                    myXmlTextWriter.WriteAttributeString("Quantity", rreq.Quantity.ToString())
                    myXmlTextWriter.WriteAttributeString("StartBit", rreq.StartBit.ToString())
                    myXmlTextWriter.WriteEndElement()
                Next
                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndDocument()
                myXmlTextWriter.Flush()
                myXmlTextWriter.Close()
                MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine + "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusRequestCollection.xml", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    Private Sub ReadCollectionBox_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        main.CountOpenDialogs -= 1
    End Sub
End Class