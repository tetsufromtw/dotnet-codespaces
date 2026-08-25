using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    // current workaround for port forwarding in codespaces
    // https://github.com/dotnet/aspnetcore/issues/57332
    options.AddDocumentTransformer((document, context, ct) =>
    {
        document.Servers = [];
        return Task.CompletedTask;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

var placeholderTransactions = new[]
{
    new TransactionView(
        "LOCAL-001",
        DateTimeOffset.UtcNow.AddDays(-2),
        10000m,
        "JPY",
        "CREDIT",
        "Placeholder transaction"),
    new TransactionView(
        "LOCAL-002",
        DateTimeOffset.UtcNow.AddDays(-1),
        2500m,
        "JPY",
        "DEBIT",
        "Placeholder fee")
};

app.MapGet("/api/accounts/{accountId}/transactions", (
    string accountId,
    DateOnly? from) =>
{
    if (!accountId.Equals("ACC-1001", StringComparison.OrdinalIgnoreCase))
    {
        return Results.NotFound();
    }

    var transactions = from is null
        ? placeholderTransactions
        : placeholderTransactions
            .Where(transaction => DateOnly.FromDateTime(transaction.BookedAt.UtcDateTime) >= from.Value)
            .ToArray();

    return Results.Ok(transactions);
})
.WithName("GetAccountTransactions");

app.Run();

internal record TransactionView(
    string Id,
    DateTimeOffset BookedAt,
    decimal Amount,
    string Currency,
    string Direction,
    string Description);
