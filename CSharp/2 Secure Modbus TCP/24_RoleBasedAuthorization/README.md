# 24 Role Based Authorization

Adds an authorization decision after the SecureTCP connection has been established.

## Before You Run

Run the project directly after replacing the license placeholders.

Replace the license placeholders before connecting to a PLCcom Modbus endpoint.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch the callback that receives role information and Modbus function context. This is the place where an integrator can allow or deny a request.

