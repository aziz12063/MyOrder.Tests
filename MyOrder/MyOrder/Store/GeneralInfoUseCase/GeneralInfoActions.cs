using MyOrder.Shared.Dtos;

namespace MyOrder.Store.GeneralInfoUseCase
{
    public class FetchGeneralInfoAction(string basketId)
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

