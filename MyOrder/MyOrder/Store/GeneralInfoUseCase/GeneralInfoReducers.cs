using Fluxor;
using MyOrder.Store.OrderInfoUseCase;

namespace MyOrder.Store.GeneralInfoUseCase;

public static class GeneralInfoReducers
{
    [ReducerMethod]
    public static GeneralInfoState ReduceFetchGeneralInfoSuccessAction(GeneralInfoState state, FetchGeneralInfoSuccessAction action)
    {
        return new GeneralInfoState(action.BasketGeneralInfo);
    }

    [ReducerMethod]
    public static GeneralInfoState ReduceFetchGeneralInfoFailureAction(GeneralInfoState state, FetchGeneralInfoFailureAction action)
    {
        return new GeneralInfoState();
    }
}
