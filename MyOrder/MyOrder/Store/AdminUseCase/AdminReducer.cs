using Fluxor;
using Microsoft.AspNetCore.Components.Rendering;
using MyOrder.Components.Pages.Admin;

namespace MyOrder.Store.AdminUseCase
{
    public static class AdminReducer
    {
        [ReducerMethod]
        public static AdminState ReducerUpdateNameAction(AdminState state, UpdateNameAction action)
        {
            return new AdminState(action.NewName);
            //return new AdminState { Name = action.NewName, Component = state.Component };
        }

        [ReducerMethod]
        public static AdminState ReducerInitialzeComponentAction(AdminState state, InitializeComponentAction action)
        {
            return new AdminState(action.Component);
            //return new AdminState { Name = state.Name, Component = action.Component };
        }

        [ReducerMethod]
        public static AdminState ReduceLoadComponentAction(AdminState state, LoadComponentAction action)
        {
            return new AdminState(action.ComponentType, action.Parameters ?? new Dictionary<string, object>());
        }
    }

}
