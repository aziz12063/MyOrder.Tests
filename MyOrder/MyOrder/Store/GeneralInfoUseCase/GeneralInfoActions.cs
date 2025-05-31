using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Store.Base;
using System.Collections.Immutable;
using System.Security.Claims;

namespace MyOrder.Store.GeneralInfoUseCase;

public class FetchGeneralInfoAction(GeneralInfoState state) : FetchDataActionBase(state)
{ }

public class FetchGeneralInfoSuccessAction(GeneralInfoDto? basketGeneralInfo, ClaimsPrincipal? claimsPrincipal)
{
    public GeneralInfoDto? BasketGeneralInfo { get; } = basketGeneralInfo;
    public ClaimsPrincipal? ClaimsPrincipal { get; } = claimsPrincipal;
}

public class FetchGeneralInfoFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}

public record PublishBasketAction(ImmutableList<string?>? ProcedureCall);

public class FetchBlockingReasonsAction(BlockingReasonsState state) : FetchDataActionBase(state);
public record FetchBlockingReasonsSuccessAction(BasketBlockingReasonsDto? BlockingReasons);
public record FetchBlockingReasonsFailureAction(string ErrorMessage);