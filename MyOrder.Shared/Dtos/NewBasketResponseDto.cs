namespace MyOrder.Shared.Dtos;

public record NewBasketResponseDto(
    bool? Success,
    string? Message,
    string? BasketId,
    string? Url)
{
    public override string ToString() =>
        $"Success: {Success?.ToString() ?? "null"}, " +
        $"Message: {Message ?? "null"}, " +
        $"BasketId: {BasketId ?? "null"}, " +
        $"Url: {Url ?? "null"}";
}