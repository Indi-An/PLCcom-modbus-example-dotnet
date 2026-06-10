# 2 Secure Modbus TCP - C#

This chapter takes the same Modbus idea and puts a secure transport underneath it. The goal is not to hide TLS behind one checkbox. The goal is to make the certificate flow understandable: where the local certificate lives, why a remote certificate is rejected, how it becomes trusted, and where a project-specific validator can make the final decision.

## Workshops

| # | Project | What it demonstrates |
|---|---------|----------------------|
| 21 | `21_SecureTCP_Master` | Master-side SecureTCP options, TLS mode selection, PKI path, and validation hook. |
| 22 | `22_SecureTCP_Slave` | SecureTCP listener setup, endpoint certificate handling, and rejected/trusted certificate flow. |
| 23 | `23_MutualTLS_Loopback` | Master and slave in one process with mutual certificate authentication. |
| 24 | `24_RoleBasedAuthorization` | A slave-side authorization callback that receives role and function information. |

## The PKI Story

On first access, PLCcom creates the store structure. Unknown remote certificates go to `rejected`. Certificates that the application should trust belong in `trusted`. CA certificates belong in `issuer`. Local endpoint certificates live in `own`, with private keys in `own/private`.

If no custom certificate validator is assigned, PLCcom validates against this store. If a custom validator is assigned, the decision belongs to that validator. The workshops make this visible so integrators can decide what their production policy should look like.

The permissive validator in the samples is intentionally permissive. It belongs in a workshop because it shows the control flow. Production code should replace it with a real trust decision.

