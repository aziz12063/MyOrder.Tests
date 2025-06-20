using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Components.Common;
using MyOrder.Services;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Store.GeneralInfoUseCase;
using MyOrder.Store.GlobalOperationsUseCase;

namespace MyOrder.Components.Childs.GeneralInfo;

public partial class GeneralInfo : FluxorComponentBase<GeneralInfoState, FetchGeneralInfoAction>
{
    private const string _companyLogoSrc = "images/Raja-Logo.png";

    [Inject]
    private IState<GlobalOperationsState> GlobalOperationsState { get; set; } = null!;

    private GeneralInfoDto BasketGeneralInfo => State.Value.GeneralInfo;

    protected override FetchGeneralInfoAction CreateFetchAction() => new();
}