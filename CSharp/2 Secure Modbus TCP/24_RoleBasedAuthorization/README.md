# 24 Role Based Authorization

Adds an authorization decision after the SecureTCP connection has been established.

## Before You Run

Enter your license data - or leave both fields blank for a first look - and run the project directly.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch the callback that receives role information and Modbus function context. This is the place where an integrator can allow or deny a request.

