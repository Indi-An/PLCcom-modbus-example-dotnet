# 23 Mutual TLS Loopback

Runs a SecureTCP master and slave in one process so the complete mutual TLS setup can be inspected without external devices.

## Before You Run

Enter your license data - or leave both fields blank for a first look - and run the project directly. The workshop creates temporary certificates for the local scenario.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch how both peers receive certificates, trust the same issuer, and then execute a small read/write cycle.

