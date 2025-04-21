using MyOrder.Shared.Interfaces;

namespace MyOrder.Shared.Services;

public class BasketService : IBasketService
{
    public string CompanyId { get; set; } = string.Empty;
    public string BasketId { get; set; } = string.Empty;
}