using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.GeneralInformation;

namespace MyOrder.Infrastructure.Repositories;

public interface IGeneralInfoRepository
{
    Task<GeneralInfoDto?> GetBasketGeneralInfoAsync(CancellationToken cancellationToken = default);
    Task<List<BasketNotificationDto?>?> GetNotificationsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketBlockingReasonDto?>?> GetBlockingReasonsAsync(CancellationToken cancellationToken = default);
    Task<List<BasketNotificationDto?>?> GetValidationRulesAsync(CancellationToken cancellationToken = default);
}