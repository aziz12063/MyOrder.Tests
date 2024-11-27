using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IGeneralInfoApiClient
{
    [Get("/api/orderContext/{basketId}/generalInfxo")]
    Task<GeneralInfoDto?> GetBasketGeneralInfoAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/notifications")]
    Task<List<BasketNotificationDto?>?> GetNotificationsAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/blockingReasons")]
    Task<List<BasketBlockingReasonDto?>?> GetBlockingReasonsAsync(string basketId, CancellationToken cancellationToken = default);

    [Get("/api/orderContext/{basketId}/validationRules")]
    Task<List<BasketNotificationDto?>?> GetValidationRulesAsync(string basketId, CancellationToken cancellationToken = default);
}