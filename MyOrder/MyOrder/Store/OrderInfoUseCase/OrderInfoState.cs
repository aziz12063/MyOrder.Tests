using Fluxor;
using MyOrder.Generator;
using MyOrder.Shared.Dtos;
using MyOrder.Store.Base;

namespace MyOrder.Store.OrderInfoUseCase;

[FeatureState]
[GenerateFieldReducers]
public record OrderInfoState(
    BasketOrderInfoDto BasketOrderInfo,
    List<BasketValueDto?> WebOrigins) : StateBase
{
    public OrderInfoState() : this(null!, []) { }
}

