namespace MyOrder.Shared.Dtos;

public class NewBasketResponseDto
{
    public bool? Success { get; set; }
    public string? Message { get; set; }
    public string? BasketId { get; set; }
    public string? Url { get; set; }

    public override string ToString() =>
    $"Success: {Success?.ToString() ?? "null"}, " +
    $"Message: {Message ?? "null"}, " +
    $"BasketId: {BasketId ?? "null"}, " +
    $"Url: {Url ?? "null"}";
}
