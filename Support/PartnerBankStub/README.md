# Partner Bank Stub

This directory contains a prebuilt, local-only test double for the external
partner API. Keeping it as a black box makes the pair-programming exercise closer
to integrating with a real third-party service.

Run it with:

```bash
dotnet PartnerBankStub.dll --urls http://localhost:8082
```

It opens no external network connections and stores no user data. Use the public
contract in `../../docs/partner-bank-api.md`; its internal implementation is not
part of the exercise.

SHA-256 of `PartnerBankStub.dll`:
`d52d035f752e169ab86ac9959fb9e503d0be421a121804df4a51ab6047d16723`.
