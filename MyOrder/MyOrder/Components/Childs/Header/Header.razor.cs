using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Components.Childs.Header
{
    public partial class Header
    {

        [Inject]
        private IBasketRepository BasketRepository { get; set; }
        
    }
}
