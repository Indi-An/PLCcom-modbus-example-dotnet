# 11 Simple Master TCP

Connects from VB.NET to a Modbus TCP slave, writes holding registers, reads them back, and prints the result.

## Before You Run

Start `12_Simple_Slave_TCP` first, or point the host and port in the source code to another slave.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch the master construction, request creation, response quality check, and value output.

