// MIT License
// Copyright (c) Indi.An GmbH
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// ==============================================================================
// PLCcom for Modbus - Workshop 31: Encapsulated CANopen Master
//
// PLCcom for Modbus can transport CANopen requests through Modbus by using the
// CANopen transport request builder. This workshop keeps the whole flow in one
// file so SDK users can follow setup, read, write and diagnostics top to bottom.
//
// Essentials:
//   * Replace the license placeholders before running the sample.
//   * Configure the serial port or switch to a TCP/UDP connector below.
//   * The target device must support the encapsulated CANopen transport function.
// ==============================================================================

using System;
using System.Text;
using PLCcomModbus.Core;
using PLCcomModbus.DataAdapter;
using PLCcomModbus.Master;

namespace PLCComMB_CANopen_Master_CSharp
{
    internal static class Program
    {
        // -- License ----------------------------------------------------------
        // TODO: Replace with your PLCcom Modbus license credentials.
        // Keep the placeholders visible so SDK users see where credentials enter.
        private const string LicenseUserName = "<Enter your UserName here>";
        private const string LicenseSerial = "<Enter your Serial here>";

        // TODO: Set the serial port name for your Modbus/CANopen gateway.
        // Alternatives: use SetConnector_TCP or SetConnector_UDP below.
        private const string ComPort = "COM3";

        private static void Main()
        {
            PrintHeader();

            try
            {
                // One entry-point flow keeps the learning path easy:
                // initialize once, run read, then run write.
                // This sequence mirrors how integration tests usually validate
                // one function before enabling the next in a real commissioning script.
                using (ModbusMaster device = CreateAndInitDevice())
                {
                    RunCanopenRead(device);
                    RunCanopenWrite(device);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Workshop failed: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static ModbusMaster CreateAndInitDevice()
        {
            // Provide credentials directly at construction so every request uses
            // the same license context from the first connector call onward.
            ModbusMaster device = new ModbusMaster(LicenseUserName, LicenseSerial);

            // Choose the physical transport used to reach your Modbus/CANopen
            // gateway. The old examples used RTU; TCP and UDP are often easier
            // during integration tests.
            device.SetConnector_RTU(
                ComPort,
                eBaudrate.b9600,
                eDataBits.DataBits8,
                System.IO.Ports.Parity.None,
                System.IO.Ports.StopBits.One,
                System.IO.Ports.Handshake.None);

            // Alternative connector examples:
            // device.SetConnector_TCP("192.168.1.21", 502);
            // device.SetConnector_UDP("192.168.1.21", 502);

            device.Connector.SetMaxIdleTime(5000);

            // Keep one common register layout for this transport demo.
            device.RegisterMode = eRegisterMode._16Bit;

            // Connection-state callback helps during field debugging.
            device.Connector.OnConnectionStateChange += OnConnectionStateChange;
            return device;
        }

        private static void RunCanopenRead(ModbusMaster device)
        {
            Console.WriteLine("Starting encapsulated CANopen read request.");

            // This request reads two bytes from node id 1, index 0x3032,
            // subindex 1. Adapt these addresses to your CANopen device manual.
            // The Modbus/Canopen bridge request includes protocol-control bytes and
            // index/subindex before payload, then wraps into a normal Modbus frame.
            CANopenTransportRequest request = RequestBuilder.CANopenTransportRequestBuilder.Create(
                1,
                new CANopenProtocolControl(false, 0, false, 0, false, eCANopenDataTypes.unsigned8, eCANopenAccessFlag.read),
                0x01,
                0x3032,
                0x01,
                0,
                2);

            Console.WriteLine(request);

            CANopenTransportResult response = device.CANopenTransport(request);

            // Printing the request gives you a copy-paste artifact for ticketing or manual comparison.
            // The response object contains status, function code echo and decoded payload
            // bytes from the CANopen layer so you can compare before/after changes.
            Console.WriteLine(response);
            Console.WriteLine("{0}: Quality => {1} {2}", DateTime.Now, response.Quality, response.Message);

            if (response.Quality == OperationResult.eQuality.GOOD)
            {
                StringBuilder builder = new StringBuilder();
                ushort counter = 0;
                foreach (byte value in response.ReadingData)
                    builder.AppendLine(counter++.ToString("0000") + " >> " + value.ToString("X02"));

                Console.WriteLine(builder.ToString());
            }
        }

        private static void RunCanopenWrite(ModbusMaster device)
        {
            Console.WriteLine("Starting encapsulated CANopen write request.");

            // This request writes four bytes to node id 1, index 0x0002,
            // subindex 0, start address 10.
            CANopenTransportRequest request = RequestBuilder.CANopenTransportRequestBuilder.Create(
                1,
                new CANopenProtocolControl(false, 0, false, 0, false, 0, eCANopenAccessFlag.write),
                0x01,
                0x0002,
                0x00,
                10,
                new byte[] { 0x00, 0x01, 0x02, 0x03 });

            Console.WriteLine(request);

            CANopenTransportResult response = device.CANopenTransport(request);

            // For writes, transport quality is the main checkpoint before checking peer-side effects.
            // In production samples you typically validate quality here and then poll
            // readback values before continuing with the next automation step.
            // The sample keeps this second step short to focus on the request API.
            Console.WriteLine(response);
            Console.WriteLine("{0}: Quality => {1} {2}", DateTime.Now, response.Quality, response.Message);
        }

        private static void OnConnectionStateChange(object sender, eConnectionState state)
        {
            // Keep the sample readable and avoid silent adapter/serial errors.
            Console.WriteLine("Connection state: " + state);
        }

        // -- Console output ---------------------------------------------------
        private static void PrintHeader()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ PLCcom for Modbus - Workshop 31: Encapsulated CANopen Master         ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Uses the Modbus CANopen transport function to send CANopen-style     ║");
            Console.WriteLine("║ requests.                                                            ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ What you will learn:                                                 ║");
            Console.WriteLine("║   * Configure the physical connector before talking to hardware      ║");
            Console.WriteLine("║   * Create encapsulated CANopen read and write requests              ║");
            Console.WriteLine("║   * Inspect CANopen requests before sending them to real devices     ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Requires a target that supports encapsulated CANopen transport       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }
    }
}
