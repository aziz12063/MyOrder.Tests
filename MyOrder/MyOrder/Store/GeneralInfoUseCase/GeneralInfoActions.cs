using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;
using System.Security.Claims;

namespace MyOrder.Store.GeneralInfoUseCase;

public class FetchGeneralInfoAction(GeneralInfoState state, string basketId) : FetchDataActionBase(state)
{
    public string BasketId { get; } = basketId;
}

public class FetchGeneralInfoSuccessAction(BasketGeneralInfoDto? basketGeneralInfo, ClaimsPrincipal? claimsPrincipal)
{
    public BasketGeneralInfoDto? BasketGeneralInfo { get; } = basketGeneralInfo;
    public ClaimsPrincipal? ClaimsPrincipal { get; } = claimsPrincipal;
}

public class FetchGeneralInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

