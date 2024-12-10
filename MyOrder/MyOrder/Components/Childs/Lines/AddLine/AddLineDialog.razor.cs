using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MyOrder.Services;
using MyOrder.Shared.Extensions;
using MyOrder.Shared.Interfaces;
using MyOrder.Shared.Utils;
using MyOrder.Store.NewLineUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class AddLineDialog
{
    [CascadingParameter]
    private MudDialogInstance DialogInstance { get; set; }
    private AddLineTab? AddLineTab { get; set; }
    private string? FreeText { get; set; }

    [Inject]
    public ILogger<AddLineDialog> Logger { get; set; }
    [Inject]
    public IDispatcher Dispatcher { get; set; }
    [Inject]
    public IBasketService BasketService { get; set; }
    [Inject]
    public IModalService ModalService { get; set; }

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
#warning TODO: Add validation
        if (false)
            return; 

        Dispatcher.Dispatch(new CommitNewLineAction(BasketService.BasketId));
        DialogInstance.Close(DialogResult.Ok(true));
    }

    private async Task CommitNewLine(MouseEventArgs e)
    {
        Dispatcher.Dispatch(new CommitNewLineAction(BasketService.BasketId));

        //Set focus back to the ItemIdField
        await AddLineTab!.FocusItemIdFieldAsync();
    }

#warning TODO: Show message to the user if lines is null or empty
    private void CommitFreetextAndClose()
    {
        var lines = FreeText.ParseTextToList();
        if (lines is null || lines.Count == 0)
        {
            //ModalService.ShowModal();
            return;
        }

        Dispatcher.Dispatch(new PostFreeTextAction(BasketService.BasketId, lines!));
        DialogInstance.Close(DialogResult.Ok(true));
    }

}
