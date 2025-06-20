using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Store.Base;
using System.Collections.Immutable;
using System.Security.Claims;

namespace MyOrder.Store.GeneralInfoUseCase;

public record FetchGeneralInfoAction() : FetchDataActionBase;

public record FetchGeneralInfoSuccessAction(GeneralInfoDto BasketGeneralInfo, ClaimsPrincipal ClaimsPrincipal);

public record FetchGeneralInfoFailureAction(string ErrorMessage);

public record PublishBasketAction(ImmutableList<string?> ProcedureCall);

public record FetchBlockingReasonsAction() : FetchDataActionBase;

public record FetchBlockingReasonsSuccessAction(BasketBlockingReasonsDto BlockingReasons);

public record FetchBlockingReasonsFailureAction(string ErrorMessage);