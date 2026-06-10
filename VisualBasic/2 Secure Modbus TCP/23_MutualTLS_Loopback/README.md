# 23 Mutual TLS Loopback

Runs a SecureTCP master and slave in one VB.NET process to show mutual TLS without external devices.

## Before You Run

Replace the license placeholders and run the project directly.

Replace the license placeholders before connecting to a PLCcom Modbus endpoint.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch how the local certificates are created, trusted, and then used for a small read/write cycle.

