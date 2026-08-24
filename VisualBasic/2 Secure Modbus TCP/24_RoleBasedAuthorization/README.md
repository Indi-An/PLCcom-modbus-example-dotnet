# 24 Role Based Authorization

Demonstrates the slave-side authorization decision after SecureTCP validation.

## Before You Run

Enter your license data - or leave both fields blank for a first look - and run the project directly.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch the callback that receives role and function information and returns the application decision.

