' MIT License
' Copyright (c) Indi.An GmbH
'
' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

' ==============================================================================
' PLCcom for Modbus - Workshop 31: Encapsulated CANopen Master
'
' PLCcom for Modbus can transport CANopen requests through Modbus by using the
' CANopen transport request builder. This workshop keeps the whole flow in one
' file so SDK users can follow setup, read, write and diagnostics top to bottom.
'
' Essentials:
'   * Replace the license placeholders before running the sample.
'   * Configure the serial port or switch to a TCP/UDP connector below.
'   * The target device must support the encapsulated CANopen transport function.
' ==============================================================================

Imports System.Text
Imports PLCcomModbus.Core
Imports PLCcomModbus.DataAdapter
Imports PLCcomModbus.Master

Module Program
    ' Important !!!!!!!!!!!!!!!!!!
    ' Enter your Username + Serial here! Please note: with blank fields the library runs
    ' for 15 minutes during a debug session. Both values can also come
    ' from configuration or an environment variable.
    ' Free trial license (14 days, uninterrupted): https://www.indi-an.com/en/plccom/modbus/modbus-download/
    Private Const LicenseUserName As String = ""
    Private Const LicenseSerial As String = ""

    Sub Main()
        PrintHeader()

        Try
            ' Keep the learning flow linear: initialize connector, run read, run write.
            ' This is the same order we use in production checks: prove read path
            ' before enabling write behavior.
            Using device As ModbusMaster = CreateAndInitDevice()
                RunCanopenRead(device)
                RunCanopenWrite(device)
            End Using
        Catch ex As Exception
            Console.WriteLine("Workshop failed: " & ex.Message)
        End Try

        Console.WriteLine()
        Console.WriteLine("Press ENTER to exit.")
        Console.ReadLine()
    End Sub

    Private Function CreateAndInitDevice() As ModbusMaster
        ' Credentials are required for all PLCcom API operations and are passed
        ' directly into the master constructor.
        Dim device As New ModbusMaster(LicenseUserName, LicenseSerial)

        ' Choose the physical transport used to reach your Modbus/CANopen
        ' gateway. The old examples used RTU; TCP and UDP are often easier
        ' during integration tests.
        device.SetConnector_RTU(
            "COM2",
            eBaudrate.b9600,
            eDataBits.DataBits8,
            System.IO.Ports.Parity.None,
            System.IO.Ports.StopBits.One,
            System.IO.Ports.Handshake.None)

        ' Alternative connector examples:
        ' device.SetConnector_TCP("192.168.1.21", 502)
        ' device.SetConnector_UDP("192.168.1.21", 502)

        device.Connector.SetMaxIdleTime(5000)

        ' Keep the register mapping simple for beginners.
        device.RegisterMode = eRegisterMode._16Bit

        ' Optional connection-state logging for serial transport visibility.
        AddHandler device.Connector.OnConnectionStateChange, AddressOf OnConnectionStateChange
        Return device
    End Function

    Private Sub RunCanopenRead(device As ModbusMaster)
        Console.WriteLine("Starting encapsulated CANopen read request.")

        ' This request reads four bytes from node id 1, index 0x0002,
        ' subindex 0, start address 10. Adapt these addresses to your
        ' CANopen device manual.
        ' The transport wrapper carries the protocol control + index/subindex +
        ' start address before the application payload.
        Dim request As CANopenTransportRequest = RequestBuilder.CANopenTransportRequestBuilder.Create(
            1,
            New CANopenProtocolControl(False, 0, False, 0, False, 0, eCANopenAccessFlag.read),
            1,
            2,
            0,
            10,
            4)

        Console.WriteLine(request.ToString())

        Dim response As CANopenTransportResult = device.CANopenTransport(request)

        ' Print full response first to show exact status flags.
        ' Response contains transport quality and the decoded byte payload from the device.
        Console.WriteLine(response.ToString())
        Console.WriteLine("{0}: Quality => {1} {2}", DateTime.Now, response.Quality, response.Message)

        If response.Quality = OperationResult.eQuality.GOOD Then
            Dim builder As New StringBuilder()
            Dim counter As UShort = 0

            ' Print one deterministic byte index per line so you can compare
            ' against external traces quickly.
            For Each value As Byte In response.ReadingData
                builder.AppendLine(counter.ToString("0000") & " >> " & value.ToString("X02"))
                counter = CUShort(counter + 1)
            Next

            Console.WriteLine(builder.ToString())
        End If
    End Sub

    Private Sub RunCanopenWrite(device As ModbusMaster)
        Console.WriteLine("Starting encapsulated CANopen write request.")

        ' This request writes four bytes to node id 1, index 0x0002,
        ' subindex 0, start address 10.
        ' Start with a tiny payload to keep the roundtrip easy to inspect.
        Dim request As CANopenTransportRequest = RequestBuilder.CANopenTransportRequestBuilder.Create(
            1,
            New CANopenProtocolControl(False, 0, False, 0, False, 0, eCANopenAccessFlag.write),
            1,
            2,
            0,
            10,
            New Byte() {&H0, &H1, &H2, &H3})

        Console.WriteLine(request.ToString())

        Dim response As CANopenTransportResult = device.CANopenTransport(request)

        ' Write success is confirmed by transport quality and peer-side response.
        ' In a real workflow, follow this with a read-back check before continuing automation.
        Console.WriteLine(response.ToString())
        Console.WriteLine("{0}: Quality => {1} {2}", DateTime.Now, response.Quality, response.Message)
    End Sub

    Private Sub OnConnectionStateChange(sender As Object, state As eConnectionState)
        ' Useful in workshop runs where serial links can delay link-state transitions.
        Console.WriteLine("Connection state: " & state.ToString())
    End Sub

    ' -- Console output ---------------------------------------------------
    Private Sub PrintHeader()
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗")
        Console.WriteLine("║ PLCcom for Modbus - Workshop 31: Encapsulated CANopen Master         ║")
        Console.WriteLine("║                                                                      ║")
        Console.WriteLine("║ Uses the Modbus CANopen transport function to send CANopen-style     ║")
        Console.WriteLine("║ requests.                                                            ║")
        Console.WriteLine("║                                                                      ║")
        Console.WriteLine("║ What you will learn:                                                 ║")
        Console.WriteLine("║   * Configure the physical connector before talking to hardware      ║")
        Console.WriteLine("║   * Create encapsulated CANopen read and write requests              ║")
        Console.WriteLine("║   * Inspect CANopen requests before sending them to real devices     ║")
        Console.WriteLine("║                                                                      ║")
        Console.WriteLine("║ Requires a target that supports encapsulated CANopen transport       ║")
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝")
        Console.WriteLine()
    End Sub
End Module
