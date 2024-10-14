using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Services;
using MyOrder.Store.NewLineUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class AddLineDialog
{
    [CascadingParameter]
    private MudDialogInstance DialogInstance { get; set; }

    [Inject]
    public ILogger<AddLineDialog> Logger { get; set; }
    [Inject]
    public IDispatcher Dispatcher { get; set; }
    [Inject]
    public BasketService BasketService { get; set; }

    public int CurrentTab { get; set; }

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
}
