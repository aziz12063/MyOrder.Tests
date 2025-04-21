using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients;

public interface IGeneralInfoApiClient
{
    [Get("/api/myorder/{companyId}/{basketId}/generalInfo")]
    Task<GeneralInfoDto?> GetBasketGeneralInfoAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/notifications")]
    Task<List<BasketNotificationDto?>?> GetNotificationsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/blockingReasons")]
    Task<List<BasketBlockingReasonDto?>?> GetBlockingReasonsAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/validationRules")]
    Task<List<BasketNotificationDto?>?> GetValidationRulesAsync(string companyId, string basketId, CancellationToken cancellationToken = default);

    [Get("/api/myorder/{companyId}/{basketId}/publicationState")]
    Task<BasketPublishingProgress?> BasketPublicationStateAsync(string companyId, string basketId, CancellationToken cancellationToken = default);
}