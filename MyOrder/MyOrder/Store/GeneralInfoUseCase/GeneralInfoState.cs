using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Store.Base;
using System.Security.Claims;

namespace MyOrder.Store.GeneralInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record GeneralInfoState(
    GeneralInfoDto GeneralInfo,
    ClaimsPrincipal User) : StateBase
{
    public GeneralInfoState() : this(null!, default!) { }
}
