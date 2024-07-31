using MyOrder.Shared.Dtos;

namespace MyOrder.Infrastructure.Repositories;
public interface IBasketRepository
{
    Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);

    //Order Info Section
    Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);
    Task<List<SalesOriginDto>> GetSalesOriginsAsync(string basketId);
    Task<List<SalesPoolsDto>> GetSalesPoolAsync(string basketId);

    //Prices info section
    Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId);

    //Delivery section
    Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId);

    //Procedure Call
    Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, List<string> procedureCall);


    //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);
    //Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId);
}
