# Backend Pair Programming Exercise

You have about 50 minutes. Please think aloud, ask questions when something is
unclear, and verify each meaningful change as you go.

## Context

The internal Transaction Console currently reads placeholder transaction data
from `BackEnd`. A partner bank now provides the authoritative data through an
HTTP API represented locally by `PartnerBankStub`.

## First task: happy path only

Change the existing endpoint below so it calls the partner API and maps the
partner response to the response shape already used by `FrontEnd`:

```text
GET /api/accounts/{accountId}/transactions?from=YYYY-MM-DD
```

The partner contract is documented in
`docs/partner-bank-api.md`. Its base URL is already present in the backend
configuration.

Do not modify `FrontEnd` or `PartnerBankStub`.

Before editing code:

1. Inspect the solution and run it.
2. Explain what each project does.
3. Restate the requirement and describe your intended first step.

Start with the successful response only. The interviewer will introduce any
additional requirements later.
