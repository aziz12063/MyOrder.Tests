using Fluxor;

namespace MyOrder.Store.Configuration
{
    public class ActionMapping
    {


        public Type ActionType { get; }
        public Action<object, object> Reducer { get; }
        public Func<object, object, IDispatcher, Task> Effect { get; }

        public ActionMapping(Type actionType, Action<object, object> reducer, Func<object, object, IDispatcher, Task> effect = null)
        {
            ActionType = actionType;
            Reducer = reducer;
            Effect = effect;
        }
    }
}

