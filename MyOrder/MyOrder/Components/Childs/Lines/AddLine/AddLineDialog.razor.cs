using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Services;
using MyOrder.Shared.Utils;
using MyOrder.Store.NewLineUseCase;
using static MudBlazor.CategoryTypes;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class AddLineDialog
{
    [CascadingParameter]
    private MudDialogInstance DialogInstance { get; set; }
    private AddLineTab? AddLineTab { get; set; }
    private FreeText? FreeText { get; set; }

    [Inject]
    public ILogger<AddLineDialog> Logger { get; set; }
    [Inject]
    public IDispatcher Dispatcher { get; set; }
    [Inject]
    public BasketService BasketService { get; set; }

    private MudMessageBox? messageBox { get; set; }
    private string? Message { get; set; }

    public int CurrentTab { get; set; }

    private void ItemClicked(string? itemId)
    {
        if (string.IsNullOrEmpty(itemId))
        {
            Logger.LogWarning("ItemClicked: itemId is null or empty. {StackTrace}", LogUtility.GetStackTrace());
            return;
        }
        AddLineTab?.LoadItem(itemId);
        CurrentTab = 0;
    }

    private void ResetLine()
    {
        Dispatcher.Dispatch(new ResetNewLineAction(BasketService.BasketId));
        DialogInstance.Close(DialogResult.Ok(true));
    }

    private void CommitNewLineAndClose()
    {
        Dispatcher.Dispatch(new CommitNewLineAction(BasketService.BasketId));
        DialogInstance.Close(DialogResult.Ok(true));
    }

    private void CommitNewLine() =>
        Dispatcher.Dispatch(new CommitNewLineAction(BasketService.BasketId));

    private void OnTextSubmited()
    {
        FreeText?.OnAddFreeTexts();
    }
}
