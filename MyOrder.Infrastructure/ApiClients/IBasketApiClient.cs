using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.BKP;
using Refit;

namespace MyOrder.Infrastructure.ApiClients
{
    public interface IBasketApiClient
    {

        [Get("/api/orderContext/{basketId}/basketGeneralInfo")]
        Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/basketOrderInfo")]
        Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);

        [Get("/api/orderContext/{basketId}/salesOrigins")]
        Task<List<SalesOriginDto>> GetSalesOriginsAsync(string basketId);

        [Get("/api/orderContext/{basketId}/salesPools")]
        Task<List<SalesPoolsDto>> GetSalesPoolsAsync(string basketId);

        //[Get("/api/orderContext/{basketId}/notifications")]
        //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);

        //[Get("/api/orderContext/{basketId}/lines")]
        //Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId);
    }
}
