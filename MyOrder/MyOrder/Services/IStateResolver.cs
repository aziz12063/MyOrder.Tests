using Fluxor;
using MyOrder.Store.Base;

namespace MyOrder.Services;
public interface IStateResolver
{
    void DispatchRefreshCalls(IDispatcher dispatcher, List<string?>? refreshCalls, string? basketId);
    void DispatchRefreshAction(string key, IDispatcher dispatcher, string basketId);

}

