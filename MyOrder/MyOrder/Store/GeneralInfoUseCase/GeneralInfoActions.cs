using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Store.Base;
using System.Security.Claims;

namespace MyOrder.Store.GeneralInfoUseCase;

public class FetchGeneralInfoAction(GeneralInfoState state, string basketId) : FetchDataActionBase(state)
{
    public string BasketId { get; } = basketId;
}

public class FetchGeneralInfoSuccessAction(GeneralInfoDto? basketGeneralInfo, ClaimsPrincipal? claimsPrincipal)
{
    public GeneralInfoDto? BasketGeneralInfo { get; } = basketGeneralInfo;
    public ClaimsPrincipal? ClaimsPrincipal { get; } = claimsPrincipal;
}

public class FetchGeneralInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

