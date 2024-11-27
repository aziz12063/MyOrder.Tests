using MyOrder.Shared.Interfaces;

namespace MyOrder.Shared.Services;

public class BasketService : IBasketService
{
    public string BasketId { get; set; } = string.Empty;
}