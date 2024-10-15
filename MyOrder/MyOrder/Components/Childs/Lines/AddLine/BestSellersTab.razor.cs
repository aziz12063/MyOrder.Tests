using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Store.BasketItemsUseCase;

namespace MyOrder.Components.Childs.Lines.AddLine;

public partial class BestSellersTab : FluxorComponentBase<BestSellersState, FetchBestSellersAction>
{
    private List<BestSellerItemDto?>? BestSellers { get; set; }

    protected override FetchBestSellersAction CreateFetchAction(BestSellersState state, string basketId) =>
        new(state, basketId);

    protected override void CacheNewFields()
    {
        BestSellers = State.Value.BestSellers;
    }
}
