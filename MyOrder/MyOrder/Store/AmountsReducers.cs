using MyOrder.Store.AmountsUseCase;

namespace MyOrder.Store
{
    public class AmountsReducers
    {
        public static AmountsState ReduceFetchAmountsData(AmountsState state, FetchAmountsDataAction action)
        {
            return new AmountsState(action.BasketAmountsDto);
        }
    }
}
