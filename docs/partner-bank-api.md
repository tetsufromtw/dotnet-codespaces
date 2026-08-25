# Partner Bank Transactions API

Base URL for local development: `http://localhost:8082`

## List account transactions

```http
GET /v1/accounts/{accountId}/transactions?from=YYYY-MM-DD&cursor=CURSOR
```

Both query parameters are optional. When `from` is supplied, only transactions
booked on or after that date are returned. When `next_cursor` is non-null, call
the endpoint again with that value as `cursor` to obtain the next page.

Example:

```http
GET /v1/accounts/ACC-1001/transactions?from=2026-08-01
```

Successful response (`200 OK`):

```json
{
  "account": {
    "account_id": "ACC-1001",
    "display_name": "Primary settlement account"
  },
  "transactions": [
    {
      "transaction_id": "TX-9001",
      "booked_at": "2026-08-24T02:15:00+00:00",
      "amount": {
        "value": 125000,
        "currency": "JPY"
      },
      "direction": "CREDIT",
      "description": "Merchant settlement"
    }
  ],
  "next_cursor": null
}
```

Documented error responses:

- `400 Bad Request`: invalid input
- `404 Not Found`: account does not exist
- `503 Service Unavailable`: temporary provider failure

The provider may add response fields in the future. Consumers should only rely
on fields they need.
