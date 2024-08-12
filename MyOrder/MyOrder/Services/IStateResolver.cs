using Fluxor;
using MyOrder.Store.Base;

namespace MyOrder.Services;
public interface IStateResolver
{
    void DispatchRefreshAction(string key, IDispatcher dispatcher, string basketId);
}

