using Fluxor;
using MyOrder.Infrastructure.Repositories;

namespace MyOrder.Store.HeaderUseCase
{
    public class HeaderReducers
    {
        [ReducerMethod]
        public static GeneralInfoState ReduceFetchGeneralInfoAction(GeneralInfoState state, FetchGeneralInfoAction action)
        {
            return new GeneralInfoState(null, true);
        }

        [ReducerMethod]
        public static GeneralInfoState ReduceFetchGeneralInfoAction(GeneralInfoState state, FetchGeneralInfoSuccessAction action)
        {
            return new GeneralInfoState(action.BasketGeneralInfo, false);
        }

        [ReducerMethod]
        public static GeneralInfoState ReduceFetchGeneralInfoErrorAction(GeneralInfoState state, FetchGeneralInfoFailureAction action)
        {
            // set an error flag and message in your state
            return state;
        }
    }
}
