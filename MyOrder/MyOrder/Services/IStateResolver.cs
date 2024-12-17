using Fluxor;

namespace MyOrder.Services;
public interface IStateResolver
{
#warning refactor to remove basketId
    void DispatchRefreshCalls(IDispatcher dispatcher, List<string?>? refreshCalls, string? basketId = null);
    void DispatchRefreshAction(string key, IDispatcher dispatcher, string basketId);
}