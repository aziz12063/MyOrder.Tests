using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;

namespace MyOrder.Store.AmountsUseCase
{
    public static class Reducers
    {

        [ReducerMethod]
        public static AmountsState ReduceFetchAmountDataAction(AmountsState amountsState, FetchAmountsDataAction action)
        {
            return new AmountsState(null);
        }
    }
}
