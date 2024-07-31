using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients
{
    public interface IBasketApiClient
    {

        [Get("/api/orderContext/{basketId}/generalInfo")]
        Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/orderInfo")]
        Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/salesOrigins")]
        Task<List<SalesOriginDto>> GetSalesOriginsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/salesPools")]
        Task<List<SalesPoolsDto>> GetSalesPoolsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/deliveryInfo")]
        Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/pricesInfo")]
        Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId);

        [Post("/api/orderContext/{basketId}/procedureCall")]
        Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, [Body] List<string> procedureCall);

        //[Get("/api/orderContext/{basketId}/notifications")]
        //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);

        //[Get("/api/orderContext/{basketId}/lines")]
        //Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId);
    }
}
