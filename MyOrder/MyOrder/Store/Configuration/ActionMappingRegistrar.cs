using Fluxor;
using MyOrder.Store.AmountsUseCase;

namespace MyOrder.Store.Configuration
{
    public static class ActionMappingRegistrar
    {
        
        public static void RegisterAllMappings()
        {
            // Reducers
            ActionMappingConfiguration.RegisterMapping<FetchAmountsDataAction>(
                (state, action) => Reducers.ReduceFetchAmountDataAction((AmountsState)state, action)
            );

            ActionMappingConfiguration.RegisterMapping<FetchAmountsDataErrorAction>(
                (state, action) => Reducers.ReduceFetchAmountDataErrorAction((AmountsState)state, action)
            );

            // Effects
            ActionMappingConfiguration.RegisterMapping<FetchAmountsDataRequestAction>(
                null,
                async (state, action, dispatcher) => await AmountsEffect.HandleFetchAmountsDataRequest((AmountsState)state ,action, dispatcher));
        }
    }
}
