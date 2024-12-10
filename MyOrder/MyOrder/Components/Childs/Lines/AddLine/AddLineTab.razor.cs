using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyOrder.Components.Common;
using MyOrder.Components.Common.Input;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.NewLineUseCase;
using MyOrder.Store.ProcedureCallUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class AddLineTab : FluxorComponentBase<NewLineState, FetchNewLineAction>
{
    [Parameter, EditorRequired]
    public EventCallback OnEnterPressed { get; set; }
    private BasketLineDto? NewLine { get; set; }
    private List<BasketValueDto?>? LogisticFlows { get; set; }
    private GenericTextField<string?>? ItemIdField { get; set; }
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

    public void LoadItem(string itemIdToLoad)
    {
        if (string.IsNullOrEmpty(itemIdToLoad))
            throw new ArgumentNullException(nameof(itemIdToLoad));

        if (NewLine?.ItemId is null)
            throw new InvalidOperationException($"Field {nameof(NewLine.ItemId)} cannot be null.");

        Dispatcher.Dispatch(new UpdateFieldAction(NewLine.ItemId, itemIdToLoad, FetchActionType));
    }

    public async ValueTask FocusItemIdFieldAsync()
    {
        if (ItemIdField is null)
            throw new InvalidOperationException("ItemIdField is null. Are you missing a reference?");
        await ItemIdField!.FocusAsync();
    }

    private async Task EnterPressed(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
            await OnEnterPressed.InvokeAsync();
    }
}
