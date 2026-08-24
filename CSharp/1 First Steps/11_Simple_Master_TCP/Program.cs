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
// PLCcom for Modbus - Workshop 11: Simple Modbus TCP Master
//
// This workshop is only the master side. Start Workshop 12 first in a second
// console window; it provides the Modbus TCP slave on 127.0.0.1:502.
//
// What you will learn:
//   * How to create a licensed ModbusMaster instance
//   * How to configure the standard Modbus TCP connector
//   * How to read, write and verify holding registers
//   * How to inspect result quality and returned values
//
// Required peer: Workshop 12 on 127.0.0.1:502
// ==============================================================================

using System;
using PLCcomModbus.Core;
using PLCcomModbus.Master;

namespace PLCcomModbus.Workshops.FirstSteps.SimpleMasterTcp
{
    internal static class Program
    {
        // Important !!!!!!!!!!!!!!!!!!
        // Enter your Username + Serial here! Please note: with blank fields the library runs
        // for 15 minutes during a debug session. Both values can also come
        // from configuration or an environment variable.
        // Free trial license (14 days, uninterrupted): https://www.indi-an.com/en/plccom/modbus/modbus-download/
        private const string LicenseUserName = "";
        private const string LicenseSerial = "";

        private const string SlaveHost = "127.0.0.1";
        private const int SlavePort = 502;
        private const byte SlaveId = 1;

        private static void Main()
        {
            PrintHeader();

            try
            {
                using (ModbusMaster master = new ModbusMaster(LicenseUserName, LicenseSerial))
                {
                    // -- Step 1: Connect to the slave ----------------------
                    // The master does not start a slave. Workshop 12 must already
                    // be running and listening on the official Modbus TCP port.
                    master.SetConnector_TCP(SlaveHost, SlavePort);
                    master.RegisterMode = eRegisterMode._16Bit;

                    master.Connector.OnConnectionStateChange += OnConnectionStateChange;

                    // -- Step 2: Read holding registers --------------------
                    // Function 03 reads holding registers. Address 0 and
                    // quantity 4 mean: read registers 0, 1, 2 and 3.
                    ReadRequest readRequest = RequestBuilder.ReadRequestBuilder.Create(
                        SlaveId,
                        eReadFunction.F03_Read_Holding_Registers,
                        0,
                        eDataType.USHORT,
                        4);

                    // Keep byte order explicit. It does not change 16-bit
                    // values, but it introduces the conversion setting before
                    // larger values are used in real projects.
                    readRequest.ByteOrder = eByteOrder.AB_CD;
                    PrintReadResult("Initial read", master.Read(readRequest));

                    // -- Step 3: Write two holding registers ----------------
                    // Function 16 writes one or more holding registers. The
                    // start address is 0, so the two values go to 0 and 1.
                    WriteRequest writeRequest = RequestBuilder.WriteRequestBuilder.Create(
                        SlaveId,
                        eWriteFunction.F16_Write_Multiple_Registers,
                        0);
                    writeRequest.AddRange(new ushort[] { 2100, 2101 });
                    PrintWriteResult("Write holding registers 0..1", master.Write(writeRequest));

                    // -- Step 4: Verify the write with the same read request
                    // Reusing the request makes the before/after comparison
                    // obvious and avoids changing more than one thing at once.
                    PrintReadResult("Read back after write", master.Read(readRequest));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Workshop failed: " + ex.Message);
                Console.WriteLine("Make sure Workshop 12 is running on 127.0.0.1:502.");
            }

            Console.WriteLine();
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static void PrintHeader()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ PLCcom for Modbus - Workshop 11: Simple Modbus TCP Master            ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Connects to a Modbus TCP slave, reads holding registers, writes      ║");
            Console.WriteLine("║ two values and verifies the result with a second read.               ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ What you will learn:                                                 ║");
            Console.WriteLine("║   * Create a licensed ModbusMaster instance                          ║");
            Console.WriteLine("║   * Configure the standard Modbus TCP connector                      ║");
            Console.WriteLine("║   * Read, write and verify holding registers                         ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Required peer: Workshop 12 on 127.0.0.1:502                          ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        private static void PrintReadResult(string title, ReadResult result)
        {
            Console.WriteLine(title + ": " + result.Message);

            if (result.Quality != OperationResult.eQuality.GOOD)
            {
                Console.WriteLine();
                return;
            }

            foreach (ReadValue value in result.FetchValues())
            {
                Console.WriteLine("  Holding register {0} = {1}", value.Address, value.Value);
            }

            Console.WriteLine();
        }

        private static void PrintWriteResult(string title, WriteResult result)
        {
            Console.WriteLine(title + ": " + result.Message);
            Console.WriteLine();
        }

        private static void OnConnectionStateChange(object sender, eConnectionState state)
        {
            Console.WriteLine("Connection state: " + state);
        }
    }
}
