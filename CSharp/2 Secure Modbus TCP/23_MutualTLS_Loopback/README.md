# 23 Mutual TLS Loopback

Runs a SecureTCP master and slave in one process so the complete mutual TLS setup can be inspected without external devices.

## Before You Run

Replace the license placeholders and run the project directly. The workshop creates temporary certificates for the local scenario.

Replace the license placeholders before connecting to a PLCcom Modbus endpoint.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch how both peers receive certificates, trust the same issuer, and then execute a small read/write cycle.

