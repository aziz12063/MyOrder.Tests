using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.NewLineUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class AddLineTab : FluxorComponentBase<NewLineState, FetchNewLineAction>
{
    [Inject]
    private IDialogService DialogService { get; set; }
    [CascadingParameter]
    private MudDialogInstance DialogInstance { get; set; }
    private BasketLineDto? NewLine { get; set; }
    private List<BasketValueDto?>? LogisticFlows { get; set; }
    private bool _isLoading = true;

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

    private void ResetLine()
    {
        Dispatcher.Dispatch(new ResetNewLineAction(BasketId));
        DialogInstance.Close(DialogResult.Ok(true));
    }

    private void CommitNewLineAndClose()
    {
        Dispatcher.Dispatch(new CommitNewLineAction(BasketId));
        DialogInstance.Close(DialogResult.Ok(true));
    }

    private void CommitNewLine() =>
        Dispatcher.Dispatch(new CommitNewLineAction(BasketId));
}
