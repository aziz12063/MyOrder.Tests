using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Shared.Dtos;
using Refit;

namespace MyOrder.Store.AmountsUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static AmountsState ReduceFetchAmountDataAction(AmountsState state, FetchAmountsDataAction action)
        {
            return new AmountsState(action.BasketAmountsDto);
        }

        // Optional: Handle error state
        [ReducerMethod]
        public static AmountsState ReduceFetchAmountDataErrorAction(AmountsState state, FetchAmountsDataErrorAction action)
        {
            // You might want to set an error flag or message in your state
            return state;
        }
    }
}
