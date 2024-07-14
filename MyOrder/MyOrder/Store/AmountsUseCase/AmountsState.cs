using Fluxor;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.AmountsUseCase
{
    [FeatureState]
    public class AmountsState
    {
        public BasketAmountsDto BasketAmountsDto { get; }

        private AmountsState() { }

        public AmountsState(BasketAmountsDto basketAmountsDto)
        {
            BasketAmountsDto = basketAmountsDto;
        }
    }

  
}
