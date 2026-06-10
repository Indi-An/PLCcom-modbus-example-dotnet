# 11 Simple Master TCP

Connects to a Modbus TCP slave, writes a small group of holding registers, reads the same area back, and prints the result.

## Before You Run

Start `12_Simple_Slave_TCP` first, or point the host and port in `Program.cs` to another Modbus TCP slave.

Replace the license placeholders before connecting to a PLCcom Modbus endpoint.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch how the master is constructed with the license data, how the request is created, and how the response quality is checked before values are used.

