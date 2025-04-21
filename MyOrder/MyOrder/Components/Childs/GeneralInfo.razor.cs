using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Store.GlobalOperationsUseCase;
using MyOrder.Utils;
using System.Security.Claims;

namespace MyOrder.Components.Childs;

public partial class GeneralInfo : FluxorComponentBase<GeneralInfoState, FetchGeneralInfoAction>
{
    private const string _companyLogoSrc = "images/Raja-Logo.png";

    [Inject]
    private IState<GlobalOperationsState> GlobalOperationsState { get; set; } = null!;
    [Inject]
    private ICurrencyService? CurrencyService { get; set; }
    private GeneralInfoDto? BasketGeneralInfo { get; set; }

    protected override FetchGeneralInfoAction CreateFetchAction(GeneralInfoState state) => new(state);

    protected override void CacheNewFields()
    {
        BasketGeneralInfo = State?.Value.GeneralInfo
                             ?? throw new ArgumentNullException(nameof(State.Value.GeneralInfo), "Unexpected null for BasketGeneralInfo object.");
        CurrencyService?.SetCurrency(BasketGeneralInfo?.Company?.Locale ?? "fr-FR");
    }
}
