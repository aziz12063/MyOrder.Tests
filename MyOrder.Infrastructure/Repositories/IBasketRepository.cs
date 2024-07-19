using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.BKP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Infrastructure.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId);
        Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId);
        Task<List<SalesOriginDto>> GetSalesOriginsAsync(string basketId);
        Task<List<SalesPoolsDto>> GetSalesPoolAsync(string basketId);


        //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);
        //Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId);
    }
}
