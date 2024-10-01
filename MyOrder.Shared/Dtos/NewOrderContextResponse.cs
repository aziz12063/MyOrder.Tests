namespace MyOrder.Shared.Dtos;

public class NewOrderContextResponse : MyOrderContextResponse
{
    public string? BasketId { get; set; }
    public string? Url { get; set; }

    public override string ToString() => base.ToString() +
        $"\nBasketId: {BasketId}" +
        $"\nUrl: {Url}";
}
