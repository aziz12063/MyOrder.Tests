using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;

public interface ITradeInfoRepository
{
    Task<BasketTradeInfoDto?> GetBasketTradeInfoAsync(CancellationToken cancellationToken = default);
}
