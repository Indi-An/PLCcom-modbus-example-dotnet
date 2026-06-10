# 22 SecureTCP Slave

Hosts a SecureTCP slave listener and demonstrates how certificates enter the PKI workflow.

## Before You Run

Run this workshop before `21_SecureTCP_Master` when testing locally.

Replace the license placeholders before connecting to a PLCcom Modbus endpoint.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch where the endpoint certificate is configured and how unknown remote certificates are handled.

