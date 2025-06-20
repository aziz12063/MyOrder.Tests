using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using MyOrder.Shared.Interfaces;
using MyOrder.Store.Base;
using MyOrder.Store.ResourcesUseCase;

namespace MyOrder.Components.Common;

public abstract class FluxorComponentBase<TState, TAction> : FluxorComponent
    where TState : StateBase
{
    [Inject]
    protected IState<TState> State { get; set; } = null!;
    [Inject]
    protected IState<ResourcesState> ResourcesState { get; set; } = null!;
    [Inject]
    protected IDispatcher Dispatcher { get; set; } = null!;
    [Inject]
    protected IBasketService BasketService { get; set; } = null!;
    [Inject]
    protected ILogger<FluxorComponentBase<TState, TAction>> Logger { get; set; } = null!;

    protected Type FetchActionType { get; } = typeof(TAction);
    protected bool Initialized => State.Value.Initialized && ResourcesState.Value.Initialized;
    protected bool IsLoading => State.Value.IsLoading;
    protected bool IsFaulted => State.Value.IsFaulted;
    protected string ErrorMessage => State.Value.ErrorMessage;

    protected override void OnInitialized()
    {
        Dispatcher.Dispatch(CreateFetchAction());

        base.OnInitialized();
    }

    protected abstract TAction CreateFetchAction();
}