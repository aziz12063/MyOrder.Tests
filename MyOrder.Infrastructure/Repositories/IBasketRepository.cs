using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;
public interface IBasketRepository
{
    Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);

    //Order Info Section
    Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);
    Task<List<SalesOriginDto>> GetSalesOriginsAsync(string basketId);
    Task<List<SalesPoolsDto>> GetSalesPoolAsync(string basketId);

    //Delivery section
    Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId);


    //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);
    //Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId);
}
