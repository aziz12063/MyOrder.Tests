using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MyOrder.Services;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.LinesUseCase;

namespace MyOrder.Components.Childs.Lines;

partial class LineStockQuantities
{
    [Inject]
    private IState<SuppliersState> SuppliersState { get; set; }
    [Inject]
    private IModalService ModalService { get; set; }

    [Parameter, EditorRequired]
    public BasketLineDto? BasketLine { get; set; }

    [Parameter, EditorRequired]
    public List<BasketValueDto?>? LogisticFlows { get; set; }

    private List<Supplier?>? Suppliers => SuppliersState.Value.Suppliers;

    private async Task<IDialogReference> OnSearchSupplierButtonClicked()
    {
        return await ModalService.OpenSearchSupplierDialog();
    }
}
