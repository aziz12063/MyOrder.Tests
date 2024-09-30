using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Components.Common.Dialogs;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.NewLineUseCase;
using MyOrder.Store.RessourcesUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class AddLineTab : FluxorComponentBase<NewLineState, FetchNewLineAction>
{
    [Inject]
    private IDialogService DialogService { get; set; }

    [Inject]
    private IState<RessourcesState> RessourcesState { get; set; }
    private BasketLineDto? NewLine { get; set; }
    private List<BasketValueDto?>? LogisticFlows { get; set; }
    private bool _isLoading = true;

    private Task<IDialogReference> ResetLine()
    {
        var parameters = new DialogParameters<ConfirmationDialog>
        {
            { dialog => dialog.OnConfirmation,
                EventCallback.Factory.Create(this, () => Dispatcher.Dispatch(new ResetNewLineAction(BasketId))) },
            { dialog => dialog.Content, "Etes-vous sûr vouloir réinitialiser la ligne?" },
        };

        var options = new DialogOptions { NoHeader = true };

        return DialogService.ShowAsync<ConfirmationDialog>("Confirmation", parameters, options);
    }

    private async Task<IDialogReference> CommitNewLine()
    {
        var parameters = new DialogParameters<ConfirmationDialog>
        {
            { dialog => dialog.OnConfirmation,
                EventCallback.Factory.Create(this, () => Dispatcher.Dispatch(new CommitNewLineAction(BasketId))) },
            { dialog => dialog.Content, "Etes-vous sûr vouloir ajouter la ligne?" },
        };

        var options = new DialogOptions { NoHeader = true };

        return await DialogService.ShowAsync<ConfirmationDialog>("Confirmation", parameters, options);
    }

    protected override FetchNewLineAction CreateFetchAction(NewLineState state, string basketId) =>
        new(state, basketId);

    protected override void OnInitialized()
    {
        base.OnInitialized();
        LogisticFlows = RessourcesState?.Value.LogisticFlows
            ?? throw new ArgumentNullException("Unexpected null for LogisticFlows object.");
    }

    protected override void CacheNewFields()
    {
        NewLine = State?.Value.BasketLine
            ?? throw new ArgumentNullException("BasketLine is null in NewLineState");
        _isLoading = State.Value.IsLoading || RessourcesState.Value.IsLoading;
    }
}
