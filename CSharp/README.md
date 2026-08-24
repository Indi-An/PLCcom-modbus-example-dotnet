# C# Workshops

This is the C# learning path for PLCcom Modbus. Start small, keep the telegram flow visible, and only add security, certificates, and full UI tooling once the plain master/slave conversation feels familiar.

The examples are written as workshop code, not as hidden framework magic. Important settings are deliberately close to the code that uses them: host, port, unit id, license data, register addresses, TLS options, and PKI paths.

## Chapters

| Chapter | What you learn |
|---------|----------------|
| `1 First Steps` | The plain Modbus TCP conversation: slave first, master second, read and write requests. |
| `2 Secure Modbus TCP` | TLS, certificate stores, rejected/trusted certificates, mutual TLS, and authorization callbacks. |
| `3 CANopen` | CANopen-style object dictionary access through Modbus. |
| `9 Full Applications` | Full Windows Forms applications for manual validation and troubleshooting. |

## Good First Run

1. Run `1 First Steps/12_Simple_Slave_TCP`.
2. Run `1 First Steps/11_Simple_Master_TCP`.
3. Change one register value or address.
4. Run both again and compare the output.

That small loop is the foundation for the rest of the repository.

