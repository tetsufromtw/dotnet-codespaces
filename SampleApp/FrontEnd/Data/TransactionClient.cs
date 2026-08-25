using System.Net.Http.Json;

namespace FrontEnd.Data;

public sealed class TransactionClient
{
    private readonly HttpClient _httpClient;

    public TransactionClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TransactionView[]> GetTransactionsAsync(
        string accountId,
        DateOnly from,
        CancellationToken cancellationToken = default)
    {
        var encodedAccountId = Uri.EscapeDataString(accountId);
        var path = $"api/accounts/{encodedAccountId}/transactions?from={from:yyyy-MM-dd}";

        return await _httpClient.GetFromJsonAsync<TransactionView[]>(path, cancellationToken) ?? [];
    }
}
