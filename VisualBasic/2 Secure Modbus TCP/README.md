# 2 Secure Modbus TCP - Visual Basic

This chapter shows Secure Modbus TCP from VB.NET. It uses the same structure as the C# chapter: first the master, then the slave, then a loopback scenario, and finally role-based authorization.

## Workshops

| # | Project | What it demonstrates |
|---|---------|----------------------|
| 21 | `21_SecureTCP_Master` | Master-side TLS options, PKI path, and validation hook. |
| 22 | `22_SecureTCP_Slave` | SecureTCP listener setup and certificate trust handling. |
| 23 | `23_MutualTLS_Loopback` | Master and slave in one process with mutual certificate authentication. |
| 24 | `24_RoleBasedAuthorization` | A callback where the application can allow or deny a Modbus function for a role. |

## The PKI Story

PLCcom creates the PKI folder structure when it is first needed. Unknown certificates are written to `rejected`; trusted remote certificates belong in `trusted`; issuer certificates belong in `issuer`; local endpoint certificates and private keys live under `own` and `own/private`.

The sample validator is intentionally simple so the decision point is easy to see. Replace it in real applications.

