using Fluxor;
using Microsoft.AspNetCore.Components;
using MyOrder.Services;

namespace MyOrder.Store.GlobalOperationsUseCase;

public class GlobalOperationsEffects(
    NavigationManager navigationManager,
    AppFaultedTicket appFaultedTicket)
{
    private readonly NavigationManager _navigationManager = navigationManager
        ?? throw new ArgumentNullException(nameof(navigationManager));
    private readonly AppFaultedTicket _appFaultedTicket = appFaultedTicket
        ?? throw new ArgumentNullException(nameof(appFaultedTicket));

    [EffectMethod]
    public Task HandleFaultApplicationAction(FaultAppAction action, IDispatcher _)
    {
        var sourceUri = _navigationManager.ToBaseRelativePath(navigationManager.Uri);
        _appFaultedTicket.Issue(action.ErrorMessage, sourceUri);

        _navigationManager.NavigateTo(
            uri: "/error",
            forceLoad: false,
            replace: true);

        return Task.CompletedTask;
    }

}
