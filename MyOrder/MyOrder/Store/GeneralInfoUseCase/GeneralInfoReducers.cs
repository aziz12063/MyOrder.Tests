using Fluxor;

namespace MyOrder.Store.GeneralInfoUseCase;

public static class GeneralInfoReducers
{
    [ReducerMethod(typeof(FetchGeneralInfoAction))]
    public static GeneralInfoState ReduceFetchGeneralInfoAction(GeneralInfoState state)
    {
        return state with
        {
            IsLoading = true,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static GeneralInfoState ReduceFetchGeneralInfoSuccessAction(GeneralInfoState state, FetchGeneralInfoSuccessAction action)
    {
        return state with
        {
            GeneralInfo = action.BasketGeneralInfo,
            User = action.ClaimsPrincipal,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static GeneralInfoState ReduceFetchGeneralInfoFailureAction(GeneralInfoState state, FetchGeneralInfoFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }

    [ReducerMethod]
    public static BlockingReasonsState ReduceFetchBlockingReasonsSuccessAction(BlockingReasonsState state, FetchBlockingReasonsSuccessAction action)
    {
        return state with
        {
            BlockingReasons = action.BlockingReasons,
            Initialized = true,
            IsLoading = false,
            IsFaulted = false,
            ErrorMessage = string.Empty
        };
    }

    [ReducerMethod]
    public static BlockingReasonsState ReduceFetchBlockingReasonsFailureAction(BlockingReasonsState state, FetchBlockingReasonsFailureAction action)
    {
        return state with
        {
            Initialized = true,
            IsLoading = false,
            IsFaulted = true,
            ErrorMessage = action.ErrorMessage
        };
    }
}