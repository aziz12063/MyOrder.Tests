namespace MyOrder.Shared.Dtos;

public record NewOrderContextResponse(
    string? BasketId,
    string? Url,
    bool? Success,
    string? Message,
    string? ErrorCause)
    : MyOrderContextResponse(
        Success,
        Message,
        ErrorCause)
{
    public override string ToString() => base.ToString() +
        $"\nBasketId: {BasketId}" +
        $"\nUrl: {Url}";
}