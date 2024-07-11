using MyOrder.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Infrastructure.Repositories
{
    public interface IBasketRepository
    {
        Task<BasketHeaderDto> GetBasketHeaderAsync(string basketId);
        Task<BasketAmountsDto> GetBasketAmountsAsync(string basketId);

        //Task<IEnumerable<NotificationDto>> GetNotificationsAsync(string basketId);
        //Task<IEnumerable<LineItemDto>> GetBasketLinesAsync(string basketId);
    }
}
