# 3 CANopen - C#

This chapter is for devices that expose CANopen-style object dictionary data through Modbus. The workshop keeps the setup compact and focuses on the shape of the access: choose the object, read it, write it, and check the returned quality.

## Workshop

| # | Project | What to look for |
|---|---------|------------------|
| 31 | `31_CANopen_Master` | Serial/RTU settings, object dictionary addressing, read quality, write quality, and value conversion. |

Before running against real hardware, review the port name, baud rate, slave id, and object dictionary entries in `Program.cs`.

