using Fluxor;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.GeneralInfoUseCase;

public static class GeneralInfoReducers
{
    [ReducerMethod]
    public static GeneralInfoState ReduceFetchGeneralInfoSuccessAction(GeneralInfoState state, FetchGeneralInfoSuccessAction action) =>
         new (action.BasketGeneralInfo, action.ClaimsPrincipal);
    
    [ReducerMethod]
    public static GeneralInfoState ReduceFetchGeneralInfoFailureAction(GeneralInfoState state, FetchGeneralInfoFailureAction action) =>
        new ();
}
