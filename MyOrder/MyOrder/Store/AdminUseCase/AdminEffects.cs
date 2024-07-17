using Fluxor;

namespace MyOrder.Store.AdminUseCase
{
    public class AdminEffects
    {
        private readonly IState<AdminState> _state;
        public AdminEffects(IState<AdminState> state)
        {
            _state = state;
        }

        [EffectMethod]
        public Task HandleUpdateNameAction(UpdateNameAction action, IDispatcher dispatcher)
        {
            return Task.CompletedTask;
        }

        [EffectMethod]
        public Task HandleInitializeComponentAction(InitializeComponentAction action, IDispatcher dispatcher)
        {
            
            return Task.CompletedTask;

        }

        [EffectMethod]
        public Task HandelLoadComponentAction(LoadComponentAction action, IDispatcher dispatcher)
        {
            //dispatcher.Dispatch(new LoadComponentAction(_state.Value.CurrentComponent, _state.Value.Parameters));
            return Task.CompletedTask;
        }
    }

}
