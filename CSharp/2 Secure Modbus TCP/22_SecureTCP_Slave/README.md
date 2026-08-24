# 22 SecureTCP Slave

Hosts a SecureTCP slave listener and demonstrates how certificates enter the PKI workflow.

## Before You Run

Run this workshop before `21_SecureTCP_Master` when testing locally.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch where the endpoint certificate is configured and how unknown remote certificates are handled.

