using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Infrastructure.ApiClients
{
    public interface IBasketApiClient
    {

        [Get("/api/orderContext/{basketId}/header")]
        Task<BasketHeaderDto> GetBasketHeaderAsync(string basketId);

        //[Get("/api/orderContext/{basketId}/notifications")]
        //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);

        //[Get("/api/orderContext/{basketId}/lines")]
        //Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId);
    }
}
