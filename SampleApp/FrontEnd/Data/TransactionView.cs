namespace FrontEnd.Data;

public sealed class TransactionView
{
    public string Id { get; set; } = string.Empty;

    public DateTimeOffset BookedAt { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public string Direction { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
