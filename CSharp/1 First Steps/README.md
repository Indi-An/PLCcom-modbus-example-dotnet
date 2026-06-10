# 1 First Steps - C#

This chapter is the clean table before the tools come out. One slave listens on Modbus TCP, one master connects to it, and the code shows the complete read/write path without security or UI noise.

## Workshops

| # | Project | What to look for |
|---|---------|------------------|
| 11 | `11_Simple_Master_TCP` | License setup, connection setup, read request, write request, byte order hints, and log output. |
| 12 | `12_Simple_Slave_TCP` | Listener setup, register storage, incoming request logging, and predictable local test data. |

## Run Order

1. Start `12_Simple_Slave_TCP`.
2. Start `11_Simple_Master_TCP`.
3. Watch both consoles: the master shows the application view, the slave shows what arrived.

When this pair is clear, SecureTCP becomes much easier because only the transport changes. The Modbus request idea stays the same.

