Imports System.Collections.Generic
Imports System.IO.Ports
Imports System.Windows.Forms
Imports PLCcomModbus.Core

Public Class ListenerCreator

#Region "private member"

    Private Args As New Dictionary(Of String, Object)()
    Private resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(Me.GetType().Namespace + ".Resources", Me.GetType().Assembly)

#End Region

    Private Sub ListenerCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'init controls
        Me.Text = resources.GetString("create_listener_Text")
        Me.lblListenerName.Text = resources.GetString("lblListenerName_Text")
        Me.lblConnectionType.Text = resources.GetString("lblConnectionType_Text")
        Me.grbListenerSettings.Text = resources.GetString("grbListenerSettings_Text")
        Me.btnAccept.Text = resources.GetString("btnAccept_Text")
        Me.btnAbort.Text = resources.GetString("btnAbort_Text")
        Me.txtInfoCreateListener.Text = resources.GetString("txtInfoCreateListener_Text")

        cmbConnectionType.DataSource = [Enum].GetValues(GetType(eTypeOfCommunication))
        cmbBaudrate.DataSource = [Enum].GetValues(GetType(eBaudrate))
        cmbBaudrate.SelectedItem = eBaudrate.b9600
        cmbParity.DataSource = [Enum].GetValues(GetType(Parity))
        cmbParity.SelectedItem = Parity.None
        cmbDataBits.DataSource = [Enum].GetValues(GetType(eDataBits))
        cmbDataBits.SelectedItem = eDataBits.DataBits8
        cmbHandshake.DataSource = [Enum].GetValues(GetType(Handshake))
        cmbHandshake.SelectedItem = Handshake.None

        Dim lisStopbits As New List(Of Object)()
        For Each stb As StopBits In [Enum].GetValues(GetType(StopBits))
            'StopBits.None is not supported
            If stb <> StopBits.None Then
                lisStopbits.Add(stb)
            End If
        Next
        cmbStopbits.DataSource = lisStopbits
        cmbStopbits.SelectedItem = 1

        Dim ports As String() = System.IO.Ports.SerialPort.GetPortNames()
        If ports.Length > 0 Then
            cmbSerialPort.DataSource = ports
        Else
            cmbSerialPort.Items.Clear()
            cmbSerialPort.Text = "No serial ports detected"
        End If

    End Sub

    Friend Function CreateListener(ListenerNumber As Integer) As Dictionary(Of String, Object)
        txtListenerName.Text = "Listener_" & (ListenerNumber + 1).ToString("00")
        Args.Clear()
        Me.ShowDialog()
        Return Args
    End Function

    Private Sub cmbConnectionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConnectionType.SelectedIndexChanged
        Try
            Select Case DirectCast(Me.cmbConnectionType.SelectedValue, eTypeOfCommunication)
                Case eTypeOfCommunication.TCP, eTypeOfCommunication.UDP, eTypeOfCommunication.RTU_over_TCP, eTypeOfCommunication.SecureTCP
                    grbIPSettings.Enabled = True
                    grbSerialSettings.Enabled = False
                    Dim selectedCommunication As eTypeOfCommunication = DirectCast(Me.cmbConnectionType.SelectedValue, eTypeOfCommunication)
                    If selectedCommunication = eTypeOfCommunication.SecureTCP AndAlso txtLocalPort.Text = "502" Then
                        txtLocalPort.Text = "802"
                    ElseIf selectedCommunication <> eTypeOfCommunication.SecureTCP AndAlso txtLocalPort.Text = "802" Then
                        txtLocalPort.Text = "502"
                    End If
                    Exit Select
                Case eTypeOfCommunication.RTU, eTypeOfCommunication.ASCII
                    grbIPSettings.Enabled = False
                    grbSerialSettings.Enabled = True
                    Exit Select
                Case Else
                    grbIPSettings.Enabled = False
                    grbSerialSettings.Enabled = False
                    Exit Select
            End Select
        Catch generatedExceptionName As Exception
            MessageBox.Show(resources.GetString("undefinend_Connectiontype"), "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Try
            Args.Add("TypeOfCommunication", DirectCast(cmbConnectionType.SelectedItem, eTypeOfCommunication))
            Args.Add("ListerName", txtListenerName.Text)
            Select Case DirectCast(cmbConnectionType.SelectedItem, eTypeOfCommunication)
                Case eTypeOfCommunication.TCP, eTypeOfCommunication.UDP, eTypeOfCommunication.RTU_over_TCP, eTypeOfCommunication.SecureTCP
                    Args.Add("LocalPort", Integer.Parse(txtLocalPort.Text))
                    Exit Select
                Case eTypeOfCommunication.RTU, eTypeOfCommunication.ASCII
                    Args.Add("SerialPortName", cmbSerialPort.Text)
                    Args.Add("Baudrate", DirectCast(cmbBaudrate.SelectedItem, eBaudrate))
                    Args.Add("DataBits", DirectCast(cmbDataBits.SelectedItem, eDataBits))
                    Args.Add("Parity", DirectCast(cmbParity.SelectedItem, Parity))
                    Args.Add("StopBits", DirectCast(cmbStopbits.SelectedItem, StopBits))
                    Args.Add("Handshake", DirectCast(cmbHandshake.SelectedItem, Handshake))
                    Exit Select
                Case Else
                    Args.Clear()
                    Exit Select
            End Select
        Catch generatedExceptionName As Exception
            Args.Clear()
        End Try

        Me.Close()

    End Sub

    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Me.Close()
    End Sub
End Class
