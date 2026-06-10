Imports PLCcomModbus.Core
Imports System.Text
Imports System.Resources
Imports PLCcomModbus.Master
Imports System.IO

Public Class OtherFunctions

    Public Sub New(Device As ModbusMaster)
        Me.Device = Device
        InitializeComponent()
    End Sub

#Region "Private Member"
    Dim Device As ModbusMaster
    Dim resources As System.Resources.ResourceManager
#End Region


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub OtherFunctions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDeviceGUID.Text = "Device Guid: " & Device.DeviceGuid.ToString()
        lblDeviceType.Text = "Adapter Type: " & Device.Connector.[GetType]().ToString()

        'set ressources
        resources = New ResourceManager(Me.GetType().Namespace + ".Resources", Me.GetType().Assembly)
        Me.lblLog.Text = resources.GetString("lblLog_Text")
        Me.btnClose.Text = resources.GetString("btnClose_Text")
        Me.lblBroadcast.Text = resources.GetString("lblBroadcast_Text")
        Me.btnExecute.Text = resources.GetString("btnExecute_Text")
        Me.btnSaveLogtoClipboard.Text = resources.GetString("btnSaveSlaveLogtoClipboard_Text")
        Me.btnSaveLogtoFile.Text = resources.GetString("btnSaveSlaveLogtoFile_Text")
        Me.lblFunction.Text = resources.GetString("lblFunction_Text")
        Me.grpAction.Text = resources.GetString("grpAction_Text")
        Me.txtInfoOF.Text = resources.GetString("txtInfoOF_Text")

        'Set cmbFunction datasource
        Dim lisAllFunctions As New List(Of Object)()
        For Each FunctionEntry As eOperationFunction In [Enum].GetValues(GetType(eOperationFunction))
            cmbFunction.Items.Add(FunctionEntry)
        Next

        cmbFunction.Sorted = True
        cmbFunction.SelectedItem = eOperationFunction.F08_Diagnostic

        'init slave id
        Dim lisSlaveID As New List(Of Object)()
        For i As Integer = 0 To 247
            lisSlaveID.Add(i)
        Next
        cmbSlaveID.DataSource = lisSlaveID
        cmbSlaveID.SelectedItem = 1
        lblBroadcast.Visible = CInt(cmbSlaveID.SelectedItem) = 0


    End Sub

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click
        'execute desired function
        Select Case DirectCast(cmbFunction.SelectedItem, eOperationFunction)
            Case eOperationFunction.F07_Read_Exception_status
                getExceptionStatus()
                Exit Select
            Case eOperationFunction.F08_Diagnostic
                GetDiagnostic()
                Exit Select
            Case eOperationFunction.F11_Get_Com_event_counter
                getCommEventCounter()
                Exit Select
            Case eOperationFunction.F12_Get_Com_Event_Log
                getCommEventlog()
                Exit Select
            Case eOperationFunction.F17_Report_Server_ID
                ReportServerID()
                Exit Select
            Case eOperationFunction.UserFunction
                MBUserFunction()
                Exit Select
        End Select
    End Sub

    Private Sub getExceptionStatus()
        'declare a OperationRequest object
        'and set the request parameters
        'Slave ID
        Dim myRequest As OperationRequest = RequestBuilder.OperationRequestBuilder.Create(Integer.Parse(cmbSlaveID.SelectedValue.ToString()), eOperationFunction.F07_Read_Exception_status)

        'execute function
        Dim res As ExceptionStatusResult = Device.GetExceptionStatus(myRequest)

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

        txtResult.Text = String.Empty
        If res.Quality = OperationResult.eQuality.GOOD Then
            Dim sb As New StringBuilder()
            sb.Append("Data >> ")
            sb.Append(res.Data.ToString())
            sb.Append(Environment.NewLine)
            txtResult.Text = sb.ToString()
        End If
    End Sub

    Private Sub GetDiagnostic()
        'declare a ReadRequest object
        'and set the request parameters
        'Slave ID
        Dim myDiagnosticRequest As DiagnosticRequest = RequestBuilder.DiagnosticRequestBuilder.Create(Integer.Parse(cmbSlaveID.SelectedValue.ToString()), 0, New Byte() {3, 4})
        'quantity of objects to be read
        'execute function
        Dim res As DiagnosticResult = Device.GetDiagnostics(myDiagnosticRequest)


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

        txtResult.Text = String.Empty
        If res.Quality = OperationResult.eQuality.GOOD Then
            Dim counter As UShort = 0
            Dim sb As New StringBuilder()
            For Each value As Object In res.ResultData
                sb.Append(counter.ToString("0000"))
                sb.Append(" >> ")
                sb.Append(value.ToString())
                sb.Append(Environment.NewLine)
                counter += 1
            Next
            txtResult.Text = sb.ToString()
        End If

    End Sub

    Private Sub getCommEventCounter()
        'declare a OperationRequest object
        'and set the request parameters
        'Slave ID
        Dim myRequest As OperationRequest = RequestBuilder.OperationRequestBuilder.Create(Integer.Parse(cmbSlaveID.SelectedValue.ToString()), eOperationFunction.F11_Get_Com_event_counter)

        'execute function
        Dim res As CommEventCounterResult = Device.GetCommEventCounter(myRequest)

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

        txtResult.Text = String.Empty
        If res.Quality = OperationResult.eQuality.GOOD Then
            Dim sb As New StringBuilder()
            sb.Append("Status >> ")
            sb.Append(res.Status.ToString())
            sb.Append(Environment.NewLine)
            sb.Append("EventCount >> ")
            sb.Append(res.EventCount.ToString())
            txtResult.Text = sb.ToString()
        End If
    End Sub

    Private Sub getCommEventlog()
        'declare a OperationRequest object
        'and set the request parameters
        'Slave ID
        Dim myRequest As OperationRequest = RequestBuilder.OperationRequestBuilder.Create(Integer.Parse(cmbSlaveID.SelectedValue.ToString()), eOperationFunction.F12_Get_Com_Event_Log)

        'execute function
        Dim res As CommEventLogResult = Device.GetCommEventLog(myRequest)

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

        txtResult.Text = String.Empty
        If res.Quality = OperationResult.eQuality.GOOD Then
            Dim sb As New StringBuilder()
            sb.Append("Status >> ")
            sb.Append(res.Status.ToString())
            sb.Append(Environment.NewLine)
            sb.Append("EventCount >> ")
            sb.Append(res.EventCount.ToString())
            sb.Append(Environment.NewLine)
            sb.Append("MessageCount >> ")
            sb.Append(res.MessageCount.ToString())
            Dim counter As Integer = 0
            For Each value As Byte In res.Events
                sb.Append("Event ")
                sb.Append(System.Math.Max(System.Threading.Interlocked.Increment(counter), counter - 1).ToString("0000"))
                sb.Append(" >> ")
                sb.Append(value.ToString())
                sb.Append(Environment.NewLine)
            Next
            txtResult.Text = sb.ToString()
        End If
    End Sub

    Private Sub ReportServerID()
        'declare a OperationRequest object
        'and set the request parameters
        'Slave ID
        Dim myRequest As OperationRequest = RequestBuilder.OperationRequestBuilder.Create(Integer.Parse(cmbSlaveID.SelectedValue.ToString()), eOperationFunction.F17_Report_Server_ID)

        'execute function
        Dim res As ReportServerIDResult = Device.GetReportServerID(myRequest)

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

        txtResult.Text = String.Empty
        If res.Quality = OperationResult.eQuality.GOOD Then
            Dim sb As New StringBuilder()
            sb.Append("ServerID >> ")
            sb.Append(res.ServerID.ToString())
            sb.Append(Environment.NewLine)
            sb.Append("Run Indicator Status >> ")
            sb.Append(res.RunIndicatorStatus.ToString())
            Dim counter As Integer = 0
            For Each value As Byte In res.AdditionalData
                sb.Append("Event ")
                sb.Append(System.Math.Max(System.Threading.Interlocked.Increment(counter), counter - 1).ToString("0000"))
                sb.Append(" >> ")
                sb.Append(value.ToString())
                sb.Append(Environment.NewLine)
            Next
            txtResult.Text = sb.ToString()
        End If
    End Sub

    Private Sub MBUserFunction()
        'declare a OperationRequest object
        'and set the request parameters
        'Slave ID
        Dim myRequest As OperationRequest = RequestBuilder.OperationRequestBuilder.CreateUserRequest(Integer.Parse(cmbSlaveID.SelectedValue.ToString()), 65, New Byte() {0, 2, 0, 10})
        ' fictional user function 65 with data
        'execute function
        Dim res As UserFunctionResult = Device.callUserFunction(myRequest)

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

        txtResult.Text = String.Empty
        If res.Quality = OperationResult.eQuality.GOOD Then
            Dim sb As New StringBuilder()
            Dim counter As Integer = 0
            For Each value As Byte In res.ResultData
                sb.Append("return byte ")
                sb.Append(System.Math.Max(System.Threading.Interlocked.Increment(counter), counter - 1).ToString("0000"))
                sb.Append(" >> ")
                sb.Append(value.ToString())
                sb.Append(Environment.NewLine)
            Next
            txtResult.Text = sb.ToString()
        End If
    End Sub

    Private Sub cmbSlaveID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSlaveID.SelectedIndexChanged
        lblBroadcast.Visible = CInt(cmbSlaveID.SelectedItem) = 0
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

    Private Sub OtherFunctions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        main.CountOpenDialogs -= 1
    End Sub
End Class