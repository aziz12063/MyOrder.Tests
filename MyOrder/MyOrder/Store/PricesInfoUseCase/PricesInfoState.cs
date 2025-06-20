using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.PricesInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record PricesInfoState(
    BasketPricesInfoDto PricesInfo) : StateBase
{
    public PricesInfoState() : this((BasketPricesInfoDto)null!) { }
}
