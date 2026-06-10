Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports PLCcomModbus.Slave
Imports PLCcomModbus.DataAdapter
Imports PLCcomModbus.Core
Imports System.IO.Ports
Imports System.Xml
Imports System.IO
Imports System.Diagnostics
Imports PLCcomModbus.Core.Security

Public Class main
    Public Sub New()
        InitializeComponent()
        initCheckBoxArray()
        txtAddress.Text = "0"
    End Sub

#Region "private member"

    Private slave As ModbusSlave = Nothing
    'init ResourceManager
    Private resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType().Namespace + ".Resources", Me.GetType().Assembly)
    Private myCheckBoxes As New CustomCheckBoxes()
    Private certificateAlertTimer As Timer
    Private certificateToolTip As ToolTip
    Private certificateManagerDefaultBackColor As Color
    Private certificateAlertBlinkState As Boolean
    Private certificateManagerOpen As Boolean
    Private certificateManagerAutoOpened As Boolean

#End Region


#Region "intit checkboxes"

    Private Sub initCheckBoxArray()
        'initialize checkbox array
        myCheckBoxes.addCheckBox(chkBit0)
        myCheckBoxes.addCheckBox(chkBit1)
        myCheckBoxes.addCheckBox(chkBit2)
        myCheckBoxes.addCheckBox(chkBit3)
        myCheckBoxes.addCheckBox(chkBit4)
        myCheckBoxes.addCheckBox(chkBit5)
        myCheckBoxes.addCheckBox(chkBit6)
        myCheckBoxes.addCheckBox(chkBit7)
        myCheckBoxes.addCheckBox(chkBit8)
        myCheckBoxes.addCheckBox(chkBit9)
        myCheckBoxes.addCheckBox(chkBit10)
        myCheckBoxes.addCheckBox(chkBit11)
        myCheckBoxes.addCheckBox(chkBit12)
        myCheckBoxes.addCheckBox(chkBit13)
        myCheckBoxes.addCheckBox(chkBit14)
        myCheckBoxes.addCheckBox(chkBit15)
        myCheckBoxes.addCheckBox(chkBit16)
        myCheckBoxes.addCheckBox(chkBit17)
        myCheckBoxes.addCheckBox(chkBit18)
        myCheckBoxes.addCheckBox(chkBit19)
        myCheckBoxes.addCheckBox(chkBit20)
        myCheckBoxes.addCheckBox(chkBit21)
        myCheckBoxes.addCheckBox(chkBit22)
        myCheckBoxes.addCheckBox(chkBit23)
        myCheckBoxes.addCheckBox(chkBit24)
        myCheckBoxes.addCheckBox(chkBit25)
        myCheckBoxes.addCheckBox(chkBit26)
        myCheckBoxes.addCheckBox(chkBit27)
        myCheckBoxes.addCheckBox(chkBit28)
        myCheckBoxes.addCheckBox(chkBit29)
        myCheckBoxes.addCheckBox(chkBit30)
        myCheckBoxes.addCheckBox(chkBit31)

    End Sub

#End Region

    Private Sub SetCertificateManagerText()
        If btnCertificateManager Is Nothing Then
            Return
        End If

        btnCertificateManager.Text = GetResourceString("btnCertificateManager_Text", "show" & vbCrLf & "certificates")
    End Sub

    Private Function GetResourceString(name As String, fallback As String) As String
        If resources Is Nothing Then
            Return fallback
        End If

        Dim value As String = resources.GetString(name)
        If String.IsNullOrEmpty(value) Then
            Return fallback
        End If

        Return value
    End Function

    Private Sub InitializeCertificateAlert()
        certificateManagerDefaultBackColor = btnCertificateManager.BackColor
        certificateToolTip = New ToolTip()
        certificateAlertTimer = New Timer()
        certificateAlertTimer.Interval = 550
        AddHandler certificateAlertTimer.Tick, AddressOf certificateAlertTimer_Tick
        UpdateCertificateAlertState()
    End Sub

    Private Sub certificateAlertTimer_Tick(sender As Object, e As EventArgs)
        certificateAlertBlinkState = Not certificateAlertBlinkState
        btnCertificateManager.UseVisualStyleBackColor = False
        btnCertificateManager.BackColor = If(certificateAlertBlinkState, Color.LightCoral, Color.MistyRose)
    End Sub

    Private Sub UpdateCertificateAlertState()
        Dim rejectedCertificateCount As Integer = CountRejectedCertificates()
        If rejectedCertificateCount > 0 Then
            certificateToolTip.SetToolTip(btnCertificateManager, String.Format(GetResourceString("btnCertificateManager_RejectedToolTip_Text", "{0} rejected SecureTCP certificate(s) require review."), rejectedCertificateCount))
            If Not certificateAlertTimer.Enabled Then
                certificateAlertTimer.Start()
            End If
        Else
            If certificateAlertTimer.Enabled Then
                certificateAlertTimer.Stop()
            End If

            certificateAlertBlinkState = False
            btnCertificateManager.UseVisualStyleBackColor = True
            btnCertificateManager.BackColor = certificateManagerDefaultBackColor
            certificateToolTip.SetToolTip(btnCertificateManager, GetResourceString("btnCertificateManager_ToolTip_Text", "Open SecureTCP certificate manager."))
        End If
    End Sub

    Private Function CountRejectedCertificates() As Integer
        Try
            Dim pkiStore As SecureModbusPkiStore = SecureTcpExampleOptions.CreatePkiStore()
            If Not Directory.Exists(pkiStore.RejectedCertificatesPath) Then
                Return 0
            End If

            Dim count As Integer = 0
            For Each filePath As String In Directory.EnumerateFiles(pkiStore.RejectedCertificatesPath)
                If HasCertificateExtension(filePath) Then
                    count += 1
                End If
            Next

            Return count
        Catch
            Return 0
        End Try
    End Function

    Private Shared Function HasCertificateExtension(filePath As String) As Boolean
        Dim extension As String = Path.GetExtension(filePath)
        Return String.Equals(extension, ".der", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".cer", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".cert", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".crt", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".pem", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".pfx", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".p12", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function PrepareSecureTcpOptionsForUi(options As SecureModbusTcpOptions) As SecureModbusTcpOptions
        If options IsNot Nothing AndAlso options.PkiStore IsNot Nothing Then
            AddHandler options.PkiStore.CertificateStored, AddressOf pkiStore_CertificateStored
        End If

        Return options
    End Function

    Private Sub pkiStore_CertificateStored(sender As Object, e As SecureModbusPkiCertificateStoredEventArgs)
        If e Is Nothing OrElse e.StoreKind <> SecureModbusPkiStoreKind.Rejected Then
            Return
        End If

        If IsDisposed Then
            Return
        End If

        Try
            Dim action As MethodInvoker = Sub() OnRejectedCertificateStored(e.IsNewFile)
            If InvokeRequired Then
                BeginInvoke(action)
            Else
                action()
            End If
        Catch
            ' UI notification must not change the SecureTCP certificate validation result.
        End Try
    End Sub

    Private Sub OnRejectedCertificateStored(isNewFile As Boolean)
        UpdateCertificateAlertState()
        If Not isNewFile OrElse certificateManagerOpen OrElse certificateManagerAutoOpened Then
            Return
        End If

        certificateManagerAutoOpened = True
        OpenCertificateManager()
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'english ressources test
        'Dim culture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture("en")
        'System.Threading.Thread.CurrentThread.CurrentCulture = culture
        'System.Threading.Thread.CurrentThread.CurrentUICulture = culture

        'set language combobox
        Dim lisCultureInfo As New List(Of System.Globalization.CultureInfo)()
        If System.Threading.Thread.CurrentThread.CurrentCulture.Parent.TwoLetterISOLanguageName = "de" Then
            lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("de").Parent)
            lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("en").Parent)
        Else
            lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("en").Parent)
            lisCultureInfo.Add(System.Globalization.CultureInfo.CreateSpecificCulture("de").Parent)
        End If
        cmbLanguage.DataSource = lisCultureInfo

        'set UI language
        SetLanguage(System.Threading.Thread.CurrentThread.CurrentCulture)
        InitializeCertificateAlert()

        'init virtual lvValues listview filler 
        AddHandler lvValues.RetrieveVirtualItem, AddressOf lvValues_RetrieveVirtualItem

        'set DataSource to comboboxes
        cmbRegisterMode.DataSource = [Enum].GetValues(GetType(eRegisterMode))
        cmbLogLevel.DataSource = [Enum].GetValues(GetType(eLogLevel))
        cmbByteOrder.DataSource = [Enum].GetValues(GetType(eByteOrder))

        'init cmbSlaveID and set DataSource to combobox
        Dim lisSlaveID As New List(Of Object)()
        For i As Integer = 1 To 247
            lisSlaveID.Add(i)
        Next
        cmbSlaveID.DataSource = lisSlaveID
        cmbSlaveID.SelectedItem = 1
    End Sub

    Private Sub SetLanguage(culture As System.Globalization.CultureInfo)
        'set UI-Controls with actual CultureInfo information

        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture.TwoLetterISOLanguageName)
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.CreateSpecificCulture(culture.TwoLetterISOLanguageName)

        'set controls 
        Me.Text = resources.GetString("main_Text")
        Me.lblSerialCode.Text = resources.GetString("lblSerialCode_Text")
        Me.grbListener.Text = resources.GetString("grbListener_Text")
        Me.grbSlaveSettings.Text = resources.GetString("grbSlaveSettings_Text")
        Me.lblByteOrder.Text = resources.GetString("lblByteOrder_Text")
        Me.grbSupportedFunctions.Text = resources.GetString("grbSupportedFunctions_Text")
        Me.grbStatistics.Text = resources.GetString("grbStatistics_Text")
        Me.lblIncomingBytes.Text = resources.GetString("lblIncomingBytes_Text")
        Me.lblOutgoingBytes.Text = resources.GetString("lblOutgoingBytes_Text")
        Me.lblIncomingRequests.Text = resources.GetString("lblIncomingRequests_Text")
        Me.lblIncorrectRequests.Text = resources.GetString("lblIncorrectRequests_Text")
        Me.lblUnparseableRequests.Text = resources.GetString("lblUnparseableRequests_Text")
        Me.grbDataStore.Text = resources.GetString("grbDataStore_Text")
        Me.grbAddressType.Text = resources.GetString("grbAddressType_Text")
        Me.grbValues.Text = resources.GetString("grbValues_Text")
        Me.lblAddress.Text = resources.GetString("lblAddress_Text")
        Me.lblValue.Text = resources.GetString("lblValue_Text")
        Me.btnSetValue.Text = resources.GetString("btnSetValue_Text")
        Me.colAddress.Text = resources.GetString("colAddress_Text")
        Me.colValue.Text = resources.GetString("colValue_Text")
        Me.colName.Text = resources.GetString("colName_Text")
        Me.colType.Text = resources.GetString("colType_Text")
        Me.colParameter.Text = resources.GetString("colParameter_Text")
        Me.grbLog.Text = resources.GetString("grbLog_Text")
        Me.chkLogging.Text = resources.GetString("chkLogging_Text")
        Me.btnCopyLogtoFile.Text = resources.GetString("btnCopySlaveLogtoFile_Text")
        Me.btnCopyLogtoClipboard.Text = resources.GetString("btnSaveLogtoClipboard_Text")
        Me.btnLoadSettings.Text = resources.GetString("btnLoadSettings_Text")
        Me.btnSaveSettings.Text = resources.GetString("btnSaveSettings_Text")
        Me.btnClose.Text = resources.GetString("btnClose_Text")
        Me.btnStartSlave.Text = resources.GetString("btnStartSlave_Text")
        Me.btnStopSlave.Text = resources.GetString("btnStopSlave_Text")
        Me.btnAddListener.Text = resources.GetString("btnAddListener_Text")
        Me.btnRemoveListener.Text = resources.GetString("btnRemoveListener_Text")
        Me.lblRegisterMode.Text = resources.GetString("lblRegisterMode_Text")
        Me.lblSlaveID.Text = resources.GetString("lblSlaveID_Text")
        Me.lblLanguage.Text = resources.GetString("lblLanguage_Text")
        SetCertificateManagerText()
        If certificateToolTip IsNot Nothing Then
            UpdateCertificateAlertState()
        End If
    End Sub

    Private Sub btnStartSlave_Click(sender As Object, e As EventArgs) Handles btnStartSlave.Click
        Try
            lvLog.Items.Clear()

            'create new modbus slave
            slave = New ModbusSlave(txtUser.Text, txtSerial.Text, CInt(cmbSlaveID.SelectedItem), DirectCast(cmbRegisterMode.SelectedItem, eRegisterMode), DirectCast(cmbByteOrder.SelectedItem, eByteOrder))

            lvValues.VirtualListSize = slave.GetMaxCountOfCoils()

            'adding slave events
            AddHandler slave.OnPortStateChange, AddressOf Slave_OnPortStateChange
            AddHandler slave.OnIncomingLogEntry, AddressOf Slave_OnIncomingLogEntry
            AddHandler slave.OnDataStoreItemChange, AddressOf Slave_OnDataStoreItemChange
            AddHandler slave.OnDataStoreItemRead, AddressOf Slave_OnDataStoreItemRead

            'set controls
            btnStartSlave.Enabled = False
            grbSlaveSettings.Enabled = False
            grbSupportedFunctions.Enabled = True
            grbDataStore.Enabled = True
            rbRegisterTypeCoils.Checked = True
            lvValues.Refresh()
            btnStopSlave.Enabled = True
            btnAddListener.Enabled = True
            txtValue.Text = 0.ToString()
            txtUser.Enabled = False
            txtSerial.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnStopSlave_Click(sender As Object, e As EventArgs) Handles btnStopSlave.Click
        Try
            Cursor = Cursors.WaitCursor

            'unregister Datastore events
            RemoveHandler slave.OnDataStoreItemChange, AddressOf Slave_OnDataStoreItemChange
            RemoveHandler slave.OnDataStoreItemRead, AddressOf Slave_OnDataStoreItemRead


            'unload existing listener
            Dim ModbusListenerItems As New List(Of ModbusListener)(slave.Listener.Values)
            For Each ml As ModbusListener In ModbusListenerItems
                slave.RemoveListener(ml.Name)
            Next

            'unregister slave events
            RemoveHandler slave.OnIncomingLogEntry, AddressOf Slave_OnIncomingLogEntry
            RemoveHandler slave.OnPortStateChange, AddressOf Slave_OnPortStateChange

            slave.Listener.Clear()
            lvListener.Items.Clear()

            'dispose modbus slave
            slave.Dispose()
            slave = Nothing

            'set controls
            grbDataStore.Enabled = False
            grbSlaveSettings.Enabled = True
            grbSupportedFunctions.Enabled = False
            btnStartSlave.Enabled = True
            cmbRegisterMode.Enabled = True
            cmbSlaveID.Enabled = True
            lvValues.Refresh()
            btnStopSlave.Enabled = False
            btnAddListener.Enabled = False
            btnRemoveListener.Enabled = False
            txtValue.Text = 0.ToString()
            txtUser.Enabled = True
            txtSerial.Enabled = True
        Finally
            Cursor = Cursors.[Default]
        End Try
    End Sub

    Private Delegate Sub OnDataStoreReadChangeCallback(args As List(Of DataStoreItemReadEventArgs))
    Private Sub Slave_OnDataStoreItemRead(args As List(Of DataStoreItemReadEventArgs))
        'incoming OnDataStoreItemRead event
        If txtIncomingBytes.InvokeRequired Then
            'invoke required
            Dim callInvoke As New OnDataStoreReadChangeCallback(AddressOf Slave_OnDataStoreItemRead)
            txtIncomingBytes.Invoke(callInvoke, New Object() {args})
        Else
            'get statistics
            Dim st As Statistics = slave.GetStatistics()
            txtIncomingBytes.Text = st.GetNumberIncomingBytes().ToString()
            txtOutgoingBytes.Text = st.GetNumberOutgoingBytes().ToString()
            txtIncomingRequests.Text = st.GetNumberIncomingRequests().ToString()
            txtIncorectRequests.Text = st.GetNumberIncorrectRequests().ToString()
            txtUnparseableRequests.Text = st.GetNumberUnparseableRequests().ToString()
        End If
    End Sub

    Private Delegate Sub OnDataStoreItemChangeCallback(args As List(Of DataStoreItemChangeEventArgs))
    Private Sub Slave_OnDataStoreItemChange(args As List(Of DataStoreItemChangeEventArgs))
        'incoming OnDataStoreItemChange event
        If lvValues.InvokeRequired Then
            'invoke required
            Dim callInvoke As New OnDataStoreItemChangeCallback(AddressOf Slave_OnDataStoreItemChange)
            lvValues.Invoke(callInvoke, New Object() {args})
        Else
            'set new values in listview
            For Each e As DataStoreItemChangeEventArgs In args
                Select Case e.ModbusRegion
                    Case eModbusRegion.Coil
                        If Not rbRegisterTypeCoils.Checked Then
                            Return
                        End If
                        Exit Select
                    Case eModbusRegion.Input
                        If Not rbRegisterTypeDiscreteInputs.Checked Then
                            Return
                        End If
                        Exit Select
                    Case eModbusRegion.HoldingRegister
                        If Not rbRegisterTypeHoldingRegister.Checked Then
                            Return
                        End If
                        Exit Select
                    Case eModbusRegion.InputRegister
                        If Not rbRegisterTypeInputRegister.Checked Then
                            Return
                        End If
                        Exit Select
                    Case Else
                        Return
                End Select
                Dim oldValue As String = lvValues.Items(e.Address).SubItems(2).Text
                lvValues.Items(e.Address).SubItems(2).Text = e.NewValue.ToString()

                'refresh ListView only by change of values 
                If Not e.OldValue.Equals(e.NewValue) Then
                    lvValues.Refresh()
                End If

                'get statistics
                Dim st As Statistics = slave.GetStatistics()
                txtIncomingBytes.Text = st.GetNumberIncomingBytes().ToString()
                txtOutgoingBytes.Text = st.GetNumberOutgoingBytes().ToString()
                txtIncomingRequests.Text = st.GetNumberIncomingRequests().ToString()
                txtIncorectRequests.Text = st.GetNumberIncorrectRequests().ToString()
                txtUnparseableRequests.Text = st.GetNumberUnparseableRequests().ToString()
            Next
        End If
    End Sub


    Private Sub Slave_OnPortStateChange(sender As Object, e As eConnectionState)
        'this event occurs when changing the connection status
    End Sub


    Private Delegate Sub OnIncomingLogEntryCallback(e As LogEntry())
    <DebuggerStepThrough>
    Private Sub Slave_OnIncomingLogEntry(e As LogEntry())
        'incoming OnIncomingLogEntry event
        'loading Logentrys in ListView
        If Not chkLogging.Checked Then
            Return
        End If

        If lvLog.InvokeRequired Then
            'invoke required
            Try
                Dim callInvoke As New OnIncomingLogEntryCallback(AddressOf Slave_OnIncomingLogEntry)
                lvLog.Invoke(callInvoke, New Object() {e})
                'occurs during shutdown
            Catch generatedExceptionName As InvalidOperationException
            End Try
        Else
            'write LogEntry into listview
            For Each le As LogEntry In e
                If le.getLogLevel() < DirectCast(cmbLogLevel.SelectedItem, eLogLevel) Then
                    Return
                End If
                SyncLock lvLog
                    Dim lvi As New ListViewItem(le.ToString())
                    lvi.ForeColor = If(le.getLogLevel().Equals(eLogLevel.[Error]), Color.Red, Color.Black)
                    lvLog.Items.Add(lvi)

                    While lvLog.Items.Count > 100
                        lvLog.Items.RemoveAt(0)
                    End While
                    If chkAutoScroll.Checked AndAlso lvLog.Items.Count > 1 Then
                        lvLog.Items(lvLog.Items.Count - 1).EnsureVisible()
                    End If
                End SyncLock
            Next
        End If
    End Sub

    Private Sub btnAddListener_Click(sender As Object, e As EventArgs) Handles btnAddListener.Click
        Try
            'create new listener
            Dim frmCreateListener As New ListenerCreator()
            Dim Args As Dictionary(Of String, Object) = frmCreateListener.CreateListener(slave.Listener.Count)

            'add or replace listener
            If Args.Count > 0 AndAlso Not String.IsNullOrEmpty(Args("ListerName").ToString()) Then
                Select Case DirectCast(Args("TypeOfCommunication"), eTypeOfCommunication)
                    Case eTypeOfCommunication.TCP
                        slave.AddOrReplaceListener_TCP(Args("ListerName").ToString(), CInt(Args("LocalPort")))
                        Exit Select
                    Case eTypeOfCommunication.UDP
                        slave.AddOrReplaceListener_UDP(Args("ListerName").ToString(), CInt(Args("LocalPort")))
                        Exit Select
                    Case eTypeOfCommunication.RTU_over_TCP
                        slave.AddOrReplaceListener_RTU_over_TCP(Args("ListerName").ToString(), CInt(Args("LocalPort")))
                        Exit Select
                    Case eTypeOfCommunication.SecureTCP
                        slave.AddOrReplaceListener_SecureTCP(Args("ListerName").ToString(), CInt(Args("LocalPort")), PrepareSecureTcpOptionsForUi(SecureTcpExampleOptions.Create()))
                        Exit Select
                    Case eTypeOfCommunication.RTU
                        slave.AddOrReplaceListener_RTU(DirectCast(Args("ListerName"), String), DirectCast(Args("SerialPortName"), String), DirectCast(Args("Baudrate"), eBaudrate), DirectCast(Args("DataBits"), eDataBits), DirectCast(Args("Parity"), Parity), DirectCast(Args("StopBits"), StopBits),
                            DirectCast(Args("Handshake"), Handshake))
                        Exit Select
                    Case eTypeOfCommunication.ASCII
                        slave.AddOrReplaceListener_ASCII(DirectCast(Args("ListerName"), String), DirectCast(Args("SerialPortName"), String), DirectCast(Args("Baudrate"), eBaudrate), DirectCast(Args("DataBits"), eDataBits), DirectCast(Args("Parity"), Parity), DirectCast(Args("StopBits"), StopBits),
                            DirectCast(Args("Handshake"), Handshake))
                        Exit Select
                    Case Else
                        Exit Select
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            RefreshListViewListener()
        End Try
    End Sub


    Private Sub btnRemoveListener_Click(sender As Object, e As EventArgs) Handles btnRemoveListener.Click
        Try
            'removed named listener
            If lvListener.SelectedItems.Count <> 0 Then
                slave.RemoveListener(lvListener.SelectedItems(0).Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            RefreshListViewListener()
        End Try

    End Sub

    Private Sub lvListener_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvListener.SelectedIndexChanged
        'enable or disable btnRemoveListener
        btnRemoveListener.Enabled = lvListener.SelectedItems.Count <> 0
    End Sub

    Private Sub RefreshListViewListener()
        'refresh listener listview
        Try
            If slave Is Nothing Then
                Return
            End If
            Cursor = Cursors.WaitCursor
            lvListener.BeginUpdate()
            lvListener.Items.Clear()
            For Each ml As ModbusListener In slave.Listener.Values
                Dim lvi As New ListViewItem(ml.Name)
                lvi.SubItems.Add(ml.TypeOfCommunication.ToString())
                lvi.SubItems.Add(ml.GetListenerParameterString())
                lvListener.Items.Add(lvi)
            Next
        Finally
            lvListener.EndUpdate()
            Cursor = Cursors.[Default]
        End Try
    End Sub

    Private Sub rbRegisterTypeCoils_CheckedChanged(sender As Object, e As EventArgs) Handles rbRegisterTypeCoils.CheckedChanged
        'select Coils
        clearLvValues()
        If (Not IsNothing(slave)) Then
            lvValues.VirtualListSize = slave.GetMaxCountOfCoils()
        End If
        rbValueOn.Visible = True
        rbValueOFF.Visible = True
        txtValue.Visible = False
        grbValues.Text = resources.GetString("grbValues_Text")
        myCheckBoxes.EnableBitBarComplete(False, False)
    End Sub

    Private Sub rbRegisterTypeDiscreteInputs_CheckedChanged(sender As Object, e As EventArgs) Handles rbRegisterTypeDiscreteInputs.CheckedChanged
        'select Discrete Inputs
        clearLvValues()
        If (Not IsNothing(slave)) Then
            lvValues.VirtualListSize = slave.GetMaxCountOfInputs()
        End If
        rbValueOn.Visible = True
        rbValueOFF.Visible = True
        txtValue.Visible = False
        grbValues.Text = resources.GetString("grbValues_Text")
        myCheckBoxes.EnableBitBarComplete(False, False)
    End Sub

    Private Sub rbRegisterTypeHoldingRegister_CheckedChanged(sender As Object, e As EventArgs) Handles rbRegisterTypeHoldingRegister.CheckedChanged
        'select Holding Register
        clearLvValues()
        If (Not IsNothing(slave)) Then
            lvValues.VirtualListSize = slave.GetMaxCountOfHoldingRegister()
        End If
        rbValueOn.Visible = False
        rbValueOFF.Visible = False
        txtValue.Visible = True
        grbValues.Text = resources.GetString("grbValues_Text_between") & (slave.GetMaxCountOfHoldingRegister() - 1).ToString()
        Dim registerMode As eRegisterMode = DirectCast(cmbRegisterMode.SelectedItem, eRegisterMode)
        myCheckBoxes.EnableBitBarComplete(registerMode = eRegisterMode._16Bit OrElse registerMode = eRegisterMode._32Bit, registerMode = eRegisterMode._32Bit)
    End Sub

    Private Sub rbRegisterTypeInputRegister_CheckedChanged(sender As Object, e As EventArgs) Handles rbRegisterTypeInputRegister.CheckedChanged
        'select Input Register
        clearLvValues()
        If (Not IsNothing(slave)) Then
            lvValues.VirtualListSize = slave.GetMaxCountOfInputRegister()
        End If
        rbValueOn.Visible = False
        rbValueOFF.Visible = False
        txtValue.Visible = True
        grbValues.Text = resources.GetString("grbValues_Text_between") & (slave.GetMaxCountOfInputRegister() - 1).ToString()
        Dim registerMode As eRegisterMode = DirectCast(cmbRegisterMode.SelectedItem, eRegisterMode)
        myCheckBoxes.EnableBitBarComplete(registerMode = eRegisterMode._16Bit OrElse registerMode = eRegisterMode._32Bit, registerMode = eRegisterMode._32Bit)
    End Sub

    Private Sub clearLvValues()
        'clear lvValues
        Try
            Cursor = Cursors.WaitCursor
            lvValues.BeginUpdate()
            lvValues.Items.Clear()
            lvValues.Refresh()
        Finally
            lvValues.EndUpdate()
            Cursor = Cursors.[Default]
        End Try
    End Sub

    Private Sub lvValues_RetrieveVirtualItem(sender As Object, e As RetrieveVirtualItemEventArgs) Handles lvValues.RetrieveVirtualItem
        'load data in virtual listview mode
        If slave IsNot Nothing Then
            e.Item = New ListViewItem()
            e.Item.SubItems.Add(e.ItemIndex.ToString())
            Dim value As Object = Nothing

            Dim lvsi As New ListViewItem.ListViewSubItem()
            If rbRegisterTypeCoils.Checked Then
                value = slave.GetValue(CUShort(e.ItemIndex), eModbusRegion.Coil)
            ElseIf rbRegisterTypeDiscreteInputs.Checked Then
                value = slave.GetValue(CUShort(e.ItemIndex), eModbusRegion.Input)
            ElseIf rbRegisterTypeHoldingRegister.Checked Then
                value = slave.GetValue(CUShort(e.ItemIndex), eModbusRegion.HoldingRegister)
            ElseIf rbRegisterTypeInputRegister.Checked Then
                value = slave.GetValue(CUShort(e.ItemIndex), eModbusRegion.InputRegister)
            End If
            If value IsNot Nothing Then
                e.Item.ForeColor = If(TypeOf value Is Boolean AndAlso CBool(value) = True, Color.Blue, Color.Black)
                lvsi.Text = value.ToString()
                e.Item.SubItems.Add(lvsi)
            Else
                e.Item = New ListViewItem()
                e.Item.SubItems.Add(e.ItemIndex.ToString())
                e.Item.SubItems.Add("value is null")

            End If
        Else
            e.Item = New ListViewItem()
            e.Item.SubItems.Add(e.ItemIndex.ToString())
            e.Item.SubItems.Add(resources.GetString("slave_is_null"))
        End If
    End Sub

    Private Sub btnSetValue_Click(sender As Object, e As EventArgs) Handles btnSetValue.Click
        Try
            'set value in datastore to desired value
            If slave Is Nothing Then
                MessageBox.Show(resources.GetString("slave_is_null"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If rbRegisterTypeCoils.Checked Then
                slave.SetValue(UShort.Parse(txtAddress.Text), eModbusRegion.Coil, If(rbValueOn.Checked, True, False))
            ElseIf rbRegisterTypeDiscreteInputs.Checked Then
                slave.SetValue(UShort.Parse(txtAddress.Text), eModbusRegion.Input, If(rbValueOn.Checked, True, False))
            ElseIf rbRegisterTypeHoldingRegister.Checked Then
                Select Case DirectCast(cmbRegisterMode.SelectedItem, eRegisterMode)
                    Case eRegisterMode._16Bit
                        '16Bit = ushort
                        slave.SetValue(UShort.Parse(txtAddress.Text), eModbusRegion.HoldingRegister, UShort.Parse(txtValue.Text))
                        Exit Select
                    Case eRegisterMode._32Bit
                        '32Bit = uint
                        slave.SetValue(UShort.Parse(txtAddress.Text), eModbusRegion.HoldingRegister, UInteger.Parse(txtValue.Text))
                        Exit Select
                    Case eRegisterMode._64Bit
                        '64Bit = ulong
                        slave.SetValue(UShort.Parse(txtAddress.Text), eModbusRegion.HoldingRegister, ULong.Parse(txtValue.Text))
                        Exit Select
                    Case Else
                        Exit Select

                End Select
            ElseIf rbRegisterTypeInputRegister.Checked Then
                Select Case DirectCast(cmbRegisterMode.SelectedItem, eRegisterMode)
                    Case eRegisterMode._16Bit
                        '16Bit = ushort
                        slave.SetValue(UShort.Parse(txtAddress.Text), eModbusRegion.InputRegister, UShort.Parse(txtValue.Text))
                        Exit Select
                    Case eRegisterMode._32Bit
                        '32Bit = uint
                        slave.SetValue(UShort.Parse(txtAddress.Text), eModbusRegion.InputRegister, UInteger.Parse(txtValue.Text))
                        Exit Select
                    Case eRegisterMode._64Bit
                        '64Bit = ulong
                        slave.SetValue(UShort.Parse(txtAddress.Text), eModbusRegion.InputRegister, ULong.Parse(txtValue.Text))
                        Exit Select
                    Case Else
                        Exit Select
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged
        'check textbox to numeric values
        If CheckAddressField(txtAddress.Text, lvValues.Items.Count) Then
            txtAddress.BackColor = SystemColors.Window
            If lvValues.Items.Count > Integer.Parse(txtAddress.Text) Then
                lvValues.Items(Integer.Parse(txtAddress.Text)).EnsureVisible()
            End If
        Else
            txtAddress.BackColor = Color.Red
        End If

        If CheckAddressField(txtAddress.Text, lvValues.Items.Count) AndAlso CheckValueField(txtValue.Text) Then
            btnSetValue.Enabled = True
        Else
            btnSetValue.Enabled = False
        End If
    End Sub

    Private Sub txtValue_TextChanged(sender As Object, e As EventArgs) Handles txtValue.TextChanged
        If String.IsNullOrEmpty(txtValue.Text) Then
            txtValue.Text = "0"
        End If
        'check textbox to numeric values
        If CheckValueField(txtValue.Text) Then
            txtValue.BackColor = SystemColors.Window

            Select Case DirectCast(cmbRegisterMode.SelectedItem, eRegisterMode)
                Case eRegisterMode._16Bit
                    myCheckBoxes.SetCheckBoxesfromValue(UShort.Parse(txtValue.Text))
                    Exit Select
                Case eRegisterMode._32Bit
                    myCheckBoxes.SetCheckBoxesfromValue(UInteger.Parse(txtValue.Text))
                    Exit Select
                Case eRegisterMode._64Bit
                    myCheckBoxes.SetBitBarComplete(False)
                    Exit Select
            End Select
        Else
            txtValue.BackColor = Color.Red
        End If

        If CheckAddressField(txtAddress.Text, lvValues.Items.Count) AndAlso CheckValueField(txtValue.Text) Then
            btnSetValue.Enabled = True
        Else
            btnSetValue.Enabled = False
        End If
    End Sub

    Private Function CheckAddressField(Text As String, MaxAddress As Int32) As Boolean
        'check AddressField on allowed values
        Dim u As UShort

        If Not String.IsNullOrEmpty(txtAddress.Text) AndAlso UShort.TryParse(txtAddress.Text, u) Then

            Return u < MaxAddress
        Else
            Return False
        End If

    End Function

    Private Function CheckValueField(Text As String) As Boolean
        'check ValueField on allowed values
        Try
            If rbRegisterTypeCoils.Checked OrElse rbRegisterTypeDiscreteInputs.Checked Then
                Return True
            ElseIf rbRegisterTypeHoldingRegister.Checked OrElse rbRegisterTypeInputRegister.Checked Then
                Select Case DirectCast(cmbRegisterMode.SelectedItem, eRegisterMode)
                    Case eRegisterMode._16Bit
                        '16Bit = ushort
                        Dim u As UShort
                        Return Not String.IsNullOrEmpty(txtValue.Text) AndAlso UShort.TryParse(txtValue.Text, u)
                    Case eRegisterMode._32Bit
                        '32Bit = uint
                        Dim i As UInteger
                        Return Not String.IsNullOrEmpty(txtValue.Text) AndAlso UInteger.TryParse(txtValue.Text, i)
                    Case eRegisterMode._64Bit
                        '64Bit = ulong
                        Dim l As ULong
                        Return Not String.IsNullOrEmpty(txtValue.Text) AndAlso ULong.TryParse(txtValue.Text, l)
                    Case Else
                        Return False
                End Select
            Else
                Return False
            End If
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function

    Private Sub lvValues_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvValues.SelectedIndexChanged
        'set value fields from lvValues.SelectedItem
        If lvValues.SelectedIndices.Count > 0 Then
            txtAddress.Text = lvValues.SelectedIndices(0).ToString()
            If rbRegisterTypeCoils.Checked Then
                If CBool(slave.GetValue(CUShort(lvValues.SelectedIndices(0)), eModbusRegion.Coil)) Then
                    rbValueOn.Checked = True
                Else
                    rbValueOFF.Checked = True
                End If
            ElseIf rbRegisterTypeDiscreteInputs.Checked Then
                If CBool(slave.GetValue(CUShort(lvValues.SelectedIndices(0)), eModbusRegion.Input)) Then
                    rbValueOn.Checked = True
                Else
                    rbValueOFF.Checked = True
                End If
            ElseIf rbRegisterTypeHoldingRegister.Checked Then
                txtValue.Text = slave.GetValue(CUShort(lvValues.SelectedIndices(0)), eModbusRegion.HoldingRegister).ToString()
            ElseIf rbRegisterTypeInputRegister.Checked Then
                txtValue.Text = slave.GetValue(CUShort(lvValues.SelectedIndices(0)), eModbusRegion.InputRegister).ToString()
            End If
        Else
            txtAddress.Text = String.Empty
            txtValue.Text = String.Empty
        End If
    End Sub

    Private Sub chkBit_CheckedChanged(sender As Object, e As EventArgs) Handles chkBit0.CheckedChanged,
                                                                                chkBit1.CheckedChanged,
                                                                                chkBit2.CheckedChanged,
                                                                                chkBit3.CheckedChanged,
                                                                                chkBit4.CheckedChanged,
                                                                                chkBit5.CheckedChanged,
                                                                                chkBit6.CheckedChanged,
                                                                                chkBit7.CheckedChanged,
                                                                                chkBit8.CheckedChanged,
                                                                                chkBit9.CheckedChanged,
                                                                                chkBit10.CheckedChanged,
                                                                                chkBit11.CheckedChanged,
                                                                                chkBit12.CheckedChanged,
                                                                                chkBit13.CheckedChanged,
                                                                                chkBit14.CheckedChanged,
                                                                                chkBit15.CheckedChanged,
                                                                                chkBit16.CheckedChanged,
                                                                                chkBit17.CheckedChanged,
                                                                                chkBit18.CheckedChanged,
                                                                                chkBit19.CheckedChanged,
                                                                                chkBit20.CheckedChanged,
                                                                                chkBit21.CheckedChanged,
                                                                                chkBit22.CheckedChanged,
                                                                                chkBit23.CheckedChanged,
                                                                                chkBit24.CheckedChanged,
                                                                                chkBit25.CheckedChanged,
                                                                                chkBit26.CheckedChanged,
                                                                                chkBit27.CheckedChanged,
                                                                                chkBit28.CheckedChanged,
                                                                                chkBit29.CheckedChanged,
                                                                                chkBit30.CheckedChanged,
                                                                                chkBit31.CheckedChanged

        Dim temptext As String = myCheckBoxes.getValue().ToString()
        If Not txtValue.Text.Equals(temptext) Then
            txtValue.Text = temptext
        End If
    End Sub

#Region "check supported functions"

    Private Sub chkFC01_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC01.CheckedChanged
        'check if FC01 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction01 = chkSupportsFC01.Checked
        Else
            chkSupportsFC01.Checked = True
        End If
    End Sub

    Private Sub chkFC02_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC02.CheckedChanged
        'check if FC02 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction02 = chkSupportsFC02.Checked
        Else
            chkSupportsFC02.Checked = True
        End If
    End Sub

    Private Sub chkFC03_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC03.CheckedChanged
        'check if FC03 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction03 = chkSupportsFC03.Checked
        Else
            chkSupportsFC03.Checked = True
        End If
    End Sub

    Private Sub chkFC04_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC04.CheckedChanged
        'check if FC04 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction04 = chkSupportsFC04.Checked
        Else
            chkSupportsFC04.Checked = True
        End If
    End Sub

    Private Sub chkFC05_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC05.CheckedChanged
        'check if FC05 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction05 = chkSupportsFC05.Checked
        Else
            chkSupportsFC05.Checked = True
        End If
    End Sub

    Private Sub chkFC06_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC06.CheckedChanged
        'check if FC06 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction06 = chkSupportsFC06.Checked
        Else
            chkSupportsFC06.Checked = True
        End If
    End Sub

    Private Sub chkFC08_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC08.CheckedChanged
        'check if FC08 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction08 = chkSupportsFC08.Checked
        Else
            chkSupportsFC08.Checked = True
        End If
    End Sub

    Private Sub chkFC15_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC15.CheckedChanged
        'check if FC15 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction15 = chkSupportsFC15.Checked
        Else
            chkSupportsFC15.Checked = True
        End If
    End Sub

    Private Sub chkFC16_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC16.CheckedChanged
        'check if FC16 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction16 = chkSupportsFC16.Checked
        Else
            chkSupportsFC16.Checked = True
        End If
    End Sub

    Private Sub chkFC23_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupportsFC23.CheckedChanged
        'check if FC23 supported
        If slave IsNot Nothing Then
            slave.SupportsFunction23 = chkSupportsFC23.Checked
        Else
            chkSupportsFC23.Checked = True
        End If
    End Sub

#End Region

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Cursor = Cursors.WaitCursor
            If slave IsNot Nothing Then
                RemoveHandler slave.OnDataStoreItemChange, AddressOf Slave_OnDataStoreItemChange
                RemoveHandler slave.OnDataStoreItemRead, AddressOf Slave_OnDataStoreItemRead
                'unload and dispose all Listener
                Dim ModbusListenerItems As New List(Of ModbusListener)(slave.Listener.Values)
                For Each ml As ModbusListener In ModbusListenerItems
                    slave.RemoveListener(ml.Name)
                Next
                slave.Listener.Clear()
                lvListener.Items.Clear()
                slave.Dispose()
                slave = Nothing
            End If

            'set UI controls
            grbDataStore.Enabled = False
            btnStartSlave.Enabled = True
            cmbRegisterMode.Enabled = True
            cmbSlaveID.Enabled = True
            lvValues.Refresh()
            btnStopSlave.Enabled = False
            btnAddListener.Enabled = False
            btnRemoveListener.Enabled = False

            txtValue.Text = 0.ToString()
        Finally
            Cursor = Cursors.[Default]
        End Try
        Me.Close()
    End Sub

    <DebuggerNonUserCode>
    Private Sub btnLoadSettings_Click(sender As Object, e As EventArgs) Handles btnLoadSettings.Click
        If File.Exists(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSlaveSettings.xml") Then
            Try

                If slave IsNot Nothing Then
                    'unload ModbusSlave
                    btnStopSlave_Click(Nothing, Nothing)
                End If

                'load saved settiungs from PLCcomModbusSlaveSettings.xml
                Using reader As New XmlTextReader(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSlaveSettings.xml")
                    While reader.Read()
                        Select Case reader.NodeType
                            Case XmlNodeType.Element
                                Select Case reader.Name
                                    Case "SlaveSettings"
                                        txtUser.Text = reader.GetAttribute("user")
                                        txtSerial.Text = reader.GetAttribute("serial")
                                        cmbSlaveID.SelectedItem = reader.GetAttribute("SlaveID")
                                        cmbRegisterMode.SelectedItem = DirectCast([Enum].Parse(GetType(eRegisterMode), reader.GetAttribute("RegisterMode")), eRegisterMode)
                                        cmbByteOrder.SelectedItem = DirectCast([Enum].Parse(GetType(eByteOrder), reader.GetAttribute("ByteOrder")), eByteOrder)
                                        btnStartSlave_Click(Nothing, Nothing)
                                        chkSupportsFC01.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction01"))
                                        chkSupportsFC02.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction02"))
                                        chkSupportsFC03.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction03"))
                                        chkSupportsFC04.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction04"))
                                        chkSupportsFC05.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction05"))
                                        chkSupportsFC06.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction06"))
                                        chkSupportsFC08.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction08"))
                                        chkSupportsFC15.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction15"))
                                        chkSupportsFC16.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction16"))
                                        chkSupportsFC23.Checked = Boolean.Parse(reader.GetAttribute("SupportsFunction23"))
                                        Exit Select
                                    Case "Listener"
                                        Dim ToC As eTypeOfCommunication = DirectCast([Enum].Parse(GetType(eTypeOfCommunication), reader.GetAttribute("TypeOfCommunication")), eTypeOfCommunication)
                                        Select Case ToC
                                            Case eTypeOfCommunication.TCP
                                                slave.AddOrReplaceListener_TCP(reader.GetAttribute("ListenerName"), Integer.Parse(reader.GetAttribute("LocalPort")))
                                                Exit Select
                                            Case eTypeOfCommunication.UDP
                                                slave.AddOrReplaceListener_UDP(reader.GetAttribute("ListenerName"), Integer.Parse(reader.GetAttribute("LocalPort")))
                                                Exit Select
                                            Case eTypeOfCommunication.RTU_over_TCP
                                                slave.AddOrReplaceListener_RTU_over_TCP(reader.GetAttribute("ListenerName"), Integer.Parse(reader.GetAttribute("LocalPort")))
                                                Exit Select
                                            Case eTypeOfCommunication.SecureTCP
                                                slave.AddOrReplaceListener_SecureTCP(reader.GetAttribute("ListenerName"), Integer.Parse(reader.GetAttribute("LocalPort")), PrepareSecureTcpOptionsForUi(SecureTcpExampleOptions.Create()))
                                                Exit Select
                                            Case eTypeOfCommunication.RTU
                                                slave.AddOrReplaceListener_RTU(reader.GetAttribute("ListenerName"), reader.GetAttribute("SerialPortName"), DirectCast([Enum].Parse(GetType(eBaudrate), reader.GetAttribute("Baudrate")), eBaudrate), DirectCast([Enum].Parse(GetType(eDataBits), reader.GetAttribute("DataBits")), eDataBits), DirectCast([Enum].Parse(GetType(Parity), reader.GetAttribute("Parity")), Parity), DirectCast([Enum].Parse(GetType(StopBits), reader.GetAttribute("StopBits")), StopBits),
                                                    DirectCast([Enum].Parse(GetType(Handshake), reader.GetAttribute("Handshake")), Handshake))
                                                Exit Select
                                            Case eTypeOfCommunication.ASCII
                                                slave.AddOrReplaceListener_ASCII(reader.GetAttribute("ListenerName"), reader.GetAttribute("SerialPortName"), DirectCast([Enum].Parse(GetType(eBaudrate), reader.GetAttribute("Baudrate")), eBaudrate), DirectCast([Enum].Parse(GetType(eDataBits), reader.GetAttribute("DataBits")), eDataBits), DirectCast([Enum].Parse(GetType(Parity), reader.GetAttribute("Parity")), Parity), DirectCast([Enum].Parse(GetType(StopBits), reader.GetAttribute("StopBits")), StopBits),
                                                    DirectCast([Enum].Parse(GetType(Handshake), reader.GetAttribute("Handshake")), Handshake))
                                                Exit Select
                                            Case Else
                                                Exit Select
                                        End Select
                                        Exit Select
                                    Case "FormSettings"

                                        chkAutoScroll.Checked = Boolean.Parse(reader.GetAttribute("AutoScroll"))
                                        chkLogging.Checked = Boolean.Parse(reader.GetAttribute("LogEnabled"))
                                        cmbLogLevel.SelectedItem = DirectCast([Enum].Parse(GetType(eLogLevel), reader.GetAttribute("LogLevel")), eLogLevel)
                                        Exit Select
                                End Select
                                Exit Select
                        End Select

                    End While
                End Using
                MessageBox.Show(resources.GetString("successfully_loaded") + Environment.NewLine + "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSlaveSettings.xml", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error: " + ex.Message & "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSlaveSettings.xml", "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Finally
                RefreshListViewListener()
            End Try
        End If

    End Sub

    <DebuggerNonUserCode>
    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Try
            If slave Is Nothing Then
                MessageBox.Show(resources.GetString("action_not_possible_slave_is_null"), "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Return
            End If
            'Write Settings in PLCcomModbusSlaveSettings.xml
            Using myXmlTextWriter As New XmlTextWriter(System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSlaveSettings.xml", System.Text.Encoding.UTF8)

                myXmlTextWriter.Formatting = Formatting.Indented
                myXmlTextWriter.WriteStartDocument(False)
                myXmlTextWriter.WriteStartElement("SlaveSettings")
                myXmlTextWriter.WriteAttributeString("SlaveID", cmbSlaveID.SelectedItem.ToString())
                myXmlTextWriter.WriteAttributeString("RegisterMode", cmbRegisterMode.SelectedItem.ToString())
                myXmlTextWriter.WriteAttributeString("ByteOrder", cmbByteOrder.SelectedItem.ToString())
                myXmlTextWriter.WriteAttributeString("user", txtUser.Text)
                myXmlTextWriter.WriteAttributeString("serial", txtSerial.Text)
                myXmlTextWriter.WriteAttributeString("SupportsFunction01", chkSupportsFC01.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction02", chkSupportsFC02.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction03", chkSupportsFC03.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction04", chkSupportsFC04.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction05", chkSupportsFC05.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction06", chkSupportsFC06.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction08", chkSupportsFC08.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction15", chkSupportsFC15.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction16", chkSupportsFC16.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("SupportsFunction23", chkSupportsFC23.Checked.ToString())

                For Each mbl As ModbusListener In slave.Listener.Values
                    myXmlTextWriter.WriteStartElement("Listener")
                    myXmlTextWriter.WriteAttributeString("TypeOfCommunication", (mbl.TypeOfCommunication.ToString()))
                    myXmlTextWriter.WriteAttributeString("ListenerName", (mbl.Name))
                    Select Case mbl.TypeOfCommunication
                        Case eTypeOfCommunication.TCP, eTypeOfCommunication.UDP, eTypeOfCommunication.RTU_over_TCP, eTypeOfCommunication.SecureTCP
                            myXmlTextWriter.WriteAttributeString("LocalPort", mbl.GetListenerParameter()("LocalPort").ToString())
                            Exit Select
                        Case eTypeOfCommunication.RTU, eTypeOfCommunication.ASCII
                            myXmlTextWriter.WriteAttributeString("SerialPortName", mbl.GetListenerParameter()("SerialPortName").ToString())
                            myXmlTextWriter.WriteAttributeString("Baudrate", mbl.GetListenerParameter()("Baudrate").ToString())
                            myXmlTextWriter.WriteAttributeString("DataBits", mbl.GetListenerParameter()("DataBits").ToString())
                            myXmlTextWriter.WriteAttributeString("Parity", mbl.GetListenerParameter()("Parity").ToString())
                            myXmlTextWriter.WriteAttributeString("StopBits", mbl.GetListenerParameter()("StopBits").ToString())
                            myXmlTextWriter.WriteAttributeString("Handshake", mbl.GetListenerParameter()("Handshake").ToString())
                            Exit Select
                        Case Else
                            Exit Select
                    End Select
                    myXmlTextWriter.WriteEndElement()
                Next


                myXmlTextWriter.WriteStartElement("FormSettings")
                myXmlTextWriter.WriteAttributeString("AutoScroll", chkAutoScroll.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("LogEnabled", chkLogging.Checked.ToString())
                myXmlTextWriter.WriteAttributeString("LogLevel", cmbLogLevel.SelectedItem.ToString())
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteEndElement()
                myXmlTextWriter.WriteEndDocument()
                myXmlTextWriter.Flush()
                myXmlTextWriter.Close()
                MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine + "File: " & System.Threading.Thread.GetDomain().BaseDirectory & "PLCcomModbusSlaveSettings.xml", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

    End Sub

    Private Sub btnCopyLogtoClipboard_Click(sender As Object, e As EventArgs) Handles btnCopyLogtoClipboard.Click
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

    Private Sub btnCopyLogtoFile_Click(sender As Object, e As EventArgs) Handles btnCopyLogtoFile.Click
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

        MessageBox.Show(resources.GetString("successfully_saved") + Environment.NewLine +
                                            "File: " + System.Threading.Thread.GetDomain().BaseDirectory + "PLCcomModbusDiagnosticLog.log", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLanguage.SelectedIndexChanged
        'change UI language
        SetLanguage(DirectCast(cmbLanguage.SelectedItem, System.Globalization.CultureInfo))
    End Sub

    Private Sub btnCertificateManager_Click(sender As Object, e As EventArgs) Handles btnCertificateManager.Click
        OpenCertificateManager()
    End Sub

    Private Sub OpenCertificateManager()
        If certificateManagerOpen Then
            Return
        End If

        certificateManagerOpen = True
        Try
            Using certificateManager As New CertificateManagerForm()
                certificateManager.ShowDialog(Me)
            End Using
        Finally
            certificateManagerOpen = False
            UpdateCertificateAlertState()
        End Try
    End Sub
End Class
