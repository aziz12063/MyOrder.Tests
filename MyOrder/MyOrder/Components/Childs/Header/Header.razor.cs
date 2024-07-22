using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos.BKP;

namespace MyOrder.Components.Childs.Header
{
    public partial class Header
    {

        [Inject]
        private IBasketRepository BasketRepository { get; set; }

        public BasketHeaderDto? BasketHeaderDto { get; set; } = new();


        

    }
}
