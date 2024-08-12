using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.GeneralInfoUseCase
{
    public class FetchGeneralInfoAction(GeneralInfoState state, string basketId) : FetchDataActionBase(state)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchGeneralInfoSuccessAction(BasketGeneralInfoDto? basketGeneralInfo)
    {
        public BasketGeneralInfoDto? BasketGeneralInfo { get; } = basketGeneralInfo;
    }

    public class FetchGeneralInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}

