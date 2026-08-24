# 21 SecureTCP Master

Shows how a master connects through Secure Modbus TCP instead of plain TCP.

## Before You Run

Run `22_SecureTCP_Slave` first or provide another SecureTCP endpoint.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch the TLS options, PKI path, certificate handling, and the validator callback.

