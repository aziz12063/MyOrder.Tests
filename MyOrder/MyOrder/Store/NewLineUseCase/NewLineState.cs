using Fluxor;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Store.Base;

namespace MyOrder.Store.NewLineUseCase;

[FeatureState]
public class NewLineState : StateBase
{
    public BasketLineDto? BasketLine { get; set; }

    public NewLineState() : base(true) { }

    public NewLineState(BasketLineDto? basketLine) : base(false)
    {
        BasketLine = basketLine;
    }
}
