using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface IPricesInfoRepository
{
    Task<BasketPricesInfoDto?> GetBasketPricesInfoAsync(CancellationToken cancellationToken = default);
}
