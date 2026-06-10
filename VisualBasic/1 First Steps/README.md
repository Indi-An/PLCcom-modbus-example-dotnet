# 1 First Steps - Visual Basic

This chapter introduces the basic Modbus TCP conversation in VB.NET. Keep both consoles open: the slave shows what it receives, the master shows what it asked for and what came back.

## Workshops

| # | Project | What to look for |
|---|---------|------------------|
| 11 | `11_Simple_Master_TCP` | License setup, connection setup, read/write requests, and byte order hints. |
| 12 | `12_Simple_Slave_TCP` | TCP listener setup, register values, and incoming request diagnostics. |

## Run Order

Start the slave first, then the master. If you later point the master at a real device, this local pair remains useful as a known-good reference.

