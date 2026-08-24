# 31 CANopen Master

Demonstrates CANopen-style object dictionary access through Modbus.

## Before You Run

Review the serial port, slave id, and object dictionary entries before running against hardware.

Enter your license user name and serial before connecting to a PLCcom Modbus endpoint, or leave both fields blank to run for 15 minutes during a debug session.

## Run

~~~powershell
dotnet run
~~~

## What To Look At

Watch the difference between read and write handling, especially the quality checks before values are trusted.

