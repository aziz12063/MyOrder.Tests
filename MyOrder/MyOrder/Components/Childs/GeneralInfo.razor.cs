using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Utils;
using System.Security.Claims;

namespace MyOrder.Components.Childs;

public partial class GeneralInfo : BaseFluxorComponent<GeneralInfoState, FetchGeneralInfoAction>
{
    private BasketGeneralInfoDto? BasketGeneralInfo { get; set; }
    private ClaimsPrincipal? User { get; set; }

    protected override FetchGeneralInfoAction CreateFetchAction(GeneralInfoState state, string basketId) => new(state, basketId);

    protected override void CacheNewFields()
    {
        BasketGeneralInfo = State.Value.GeneralInfo
                             ?? throw new ArgumentNullException(nameof(State.Value.GeneralInfo), "Unexpected null for BasketGeneralInfo object.");
        User = State.Value.User;
    }

    private string AuthentifiedUser => $"Utilisateur: {FieldUtility.NullOrWhiteSpaceHelperWithDash(User?.Identity?.Name)}"
        + $"\n Authentifié: {User?.Identity?.IsAuthenticated}"
        + $"\n Type d'authentification: {FieldUtility.NullOrWhiteSpaceHelperWithDash(User?.Identity?.AuthenticationType)}";

}
