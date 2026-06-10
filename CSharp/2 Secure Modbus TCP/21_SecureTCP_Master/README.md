# 21 SecureTCP Master

Shows how a master connects through Secure Modbus TCP instead of plain TCP.

## Before You Run

Run `22_SecureTCP_Slave` first or provide another SecureTCP endpoint.

Replace the license placeholders before connecting to a PLCcom Modbus endpoint.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch the TLS options, PKI path, certificate handling, and the validator callback.

