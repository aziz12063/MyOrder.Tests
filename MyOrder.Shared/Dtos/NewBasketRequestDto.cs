namespace MyOrder.Shared.Dtos;

public class NewBasketRequestDto
{
    public string? BasketId { get; set; }
    public string? ContactId { get; set; }
    public string? AccountId { get; set; }
    public string? SalesId { get; set; }
    public string? QuotationId { get; set; }
    public string? InvoiceId { get; set; }
    public string? ApiSalesId { get; set; }
    public string? OrderId { get; set; }
    public string? CaseNumber { get; set; }
    public string? SavType { get; set; }
    public string? FsRequestId { get; set; }

    public override string ToString() =>
        $"BasketId: {BasketId ?? "null"}, " +
        $"ContactId: {ContactId ?? "null"}, " +
        $"AccountId: {AccountId ?? "null"}, " +
        $"SalesId: {SalesId ?? "null"}, " +
        $"QuotationId: {QuotationId ?? "null"}, " +
        $"InvoiceId: {InvoiceId ?? "null"}, " +
        $"ApiSalesId: {ApiSalesId ?? "null"}, " +
        $"OrderId: {OrderId ?? "null"}, " +
        $"CaseNumber: {CaseNumber ?? "null"}, " +
        $"SavType: {SavType ?? "null"}, " +
        $"FsRequestId: {FsRequestId ?? "null"}";
}
