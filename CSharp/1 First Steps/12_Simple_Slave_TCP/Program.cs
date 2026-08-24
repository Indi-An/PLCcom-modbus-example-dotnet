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
// PLCcom for Modbus - Workshop 12: Simple Modbus TCP Slave
//
// This workshop starts a small Modbus TCP slave with a few prepared holding
// register values. Use it together with Workshop 11 or any Modbus master tool to
// see how PLCcom exposes an in-memory data store through Modbus TCP.
//
// Essentials:
//   * Replace the license placeholders before running the sample.
//   * The slave listens on 127.0.0.1:502.
//   * Holding registers 0..3 are prefilled with easy-to-recognize values.
// ==============================================================================

using System;
using PLCcomModbus.Core;
using PLCcomModbus.DataAdapter;
using PLCcomModbus.Slave;

namespace PLCcomModbus.Workshops.FirstSteps.SimpleSlaveTcp
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

        private const string ListenerId = "workshop-tcp";
        private const int ListenPort = 502;
        private const byte SlaveId = 1;

        private static void Main()
        {
            PrintHeader();

            try
            {
                using (ModbusSlave slave = new ModbusSlave(LicenseUserName, LicenseSerial, SlaveId))
                {
                    // -- Step 1: Register diagnostic events -----------------
                    // The port-state event shows listener lifecycle changes.
                    // The log event shows incoming telegrams and request handling details.
                    slave.OnPortStateChange += OnPortStateChange;
                    slave.OnIncomingLogEntry += OnIncomingLogEntry;

                    // -- Step 2: Prepare readable sample data --------------
                    // A master can read these values with function code 03 (Read Holding Registers).
                    slave.SetValue(0, eModbusRegion.HoldingRegister, (ushort)100);
                    slave.SetValue(1, eModbusRegion.HoldingRegister, (ushort)101);
                    slave.SetValue(2, eModbusRegion.HoldingRegister, (ushort)102);
                    slave.SetValue(3, eModbusRegion.HoldingRegister, (ushort)103);

                    // -- Step 3: Start the TCP listener --------------------
                    // The listener name is the application key for replacing or removing it later.
                    slave.AddOrReplaceListener_TCP(ListenerId, ListenPort);

                    Console.WriteLine("The Modbus TCP slave is listening on port {0}.", ListenPort);
                    Console.WriteLine("Start Workshop 11 in a second console window to read the values.");
                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to stop the listener.");
                    Console.ReadLine();

                    slave.RemoveListener(ListenerId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Workshop failed: " + ex.Message);
                Console.WriteLine("Press ENTER to exit.");
                Console.ReadLine();
            }
        }

        // -- Console output ---------------------------------------------------
        private static void PrintHeader()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ PLCcom for Modbus - Workshop 12: Simple Modbus TCP Slave             ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Starts a local Modbus TCP slave and publishes a small in-memory data ║");
            Console.WriteLine("║ store.                                                               ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ What you will learn:                                                 ║");
            Console.WriteLine("║   * Create a ModbusSlave with a clear slave id                       ║");
            Console.WriteLine("║   * Preload holding-register values                                  ║");
            Console.WriteLine("║   * Open and close a TCP listener safely                             ║");
            Console.WriteLine("║                                                                      ║");
            Console.WriteLine("║ Used by Workshop 11 and any local Modbus TCP master                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        private static void OnPortStateChange(object sender, eConnectionState state)
        {
            Console.WriteLine("Listener state: " + state);
        }

        private static void OnIncomingLogEntry(LogEntry[] entries)
        {
            foreach (LogEntry entry in entries)
                Console.WriteLine(entry);
        }
    }
}
