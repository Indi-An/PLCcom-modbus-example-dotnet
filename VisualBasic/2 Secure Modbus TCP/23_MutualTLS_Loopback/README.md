# 23 Mutual TLS Loopback

Runs a SecureTCP master and slave in one VB.NET process to show mutual TLS without external devices.

## Before You Run

Enter your license data - or leave both fields blank for a first look - and run the project directly.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch how the local certificates are created, trusted, and then used for a small read/write cycle.

