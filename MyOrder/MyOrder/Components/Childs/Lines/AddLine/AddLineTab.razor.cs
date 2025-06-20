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
    private BasketLineDto? NewLine => State.Value.BasketLine;
    private List<BasketValueDto?>? LogisticFlows { get; set; }
    private GenericTextField<string?>? ItemIdField { get; set; }

    private bool _isBusy = false;

    protected override FetchNewLineAction CreateFetchAction() =>
        new();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        LogisticFlows = ResourcesState?.Value.LogisticFlows
            ?? throw new ArgumentNullException("Unexpected null for LogisticFlows object.");
        State.StateChanged += State_StateChanged;
    }

    private void State_StateChanged(object? sender, EventArgs e)
    {
        _isBusy = State.Value.IsLoading && Initialized;
        StateHasChanged();
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

    public void ItemIdValueChangedCallback() =>
        _isBusy = true;

    private async Task EnterPressed(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
            await OnEnterPressed.InvokeAsync();
    }
}
