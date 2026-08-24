# 12 Simple Slave TCP

Hosts a small Modbus TCP slave that can be used by the master workshop.

## Before You Run

Run this workshop before `11_Simple_Master_TCP`. Keep the console open so incoming traffic is visible.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch the listener setup, the initial register values, and the diagnostic output for incoming requests.

