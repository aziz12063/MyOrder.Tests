using MyOrder.Shared.Dtos;

namespace MyOrder.Store.HeaderUseCase
{
    public class FetchGeneralInfoAction
    {
        public FetchGeneralInfoAction(string? basketId) => BasketId = basketId;

        public string? BasketId { get; set; }
    }

    public class FetchGeneralInfoSuccessAction
    {
        public FetchGeneralInfoSuccessAction(BasketGeneralInfoDto? basketGeneralInfo) => BasketGeneralInfo = basketGeneralInfo;

        public BasketGeneralInfoDto? BasketGeneralInfo { get; set; }
    }

    public class FetchGeneralInfoFailureAction
    {
        public FetchGeneralInfoFailureAction(string exceptionMessage) => ExceptionMessage = exceptionMessage;

        public string ExceptionMessage { get; set; }

    }
}
