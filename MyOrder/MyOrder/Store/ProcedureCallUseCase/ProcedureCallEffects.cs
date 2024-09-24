using Fluxor;
using MyOrder.Infrastructure.Repositories;
using MyOrder.Services;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Shared.Utils;
using MyOrder.Store.OrderInfoUseCase;
using System.Collections.Immutable;

namespace MyOrder.Store.ProcedureCallUseCase;

public class ProcedureCallEffects(IBasketRepository basketRepository,
    ILogger<OrderInfoEffects> logger, IStateResolver stateResolver, BasketService basket)
{
    [EffectMethod]
    public async Task HandlePostProcedureCallAction(UpdateFieldAction action,
        IDispatcher dispatcher)
    {
        var field = action.Field;
        var value = action.Value;

        if (field == null)
        {
            logger.LogError("Trying to update a null field at {StackTrace}",
                LogUtility.GetStackTrace());
            return;
        }

        try
        {
            var response = await basketRepository.PostProcedureCallAsync(field, value, basket.BasketId);
            dispatcher.Dispatch(new PostProcedureCallSuccessAction(basket.BasketId, response));
        }
        catch (InvalidOperationException e)
        {
            logger.LogError(e, "Error while updating procedure call for {Field}", field);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error while posting procedure call");
            dispatcher.Dispatch(new PostProcedureCallFailureAction(e.Message));
        }
    }
    public static dynamic GetConcreteField(IField genericField)
    {
        // Get the runtime type of the genericField object (which implements IField)
        var concreteType = genericField.GetType();

        // Ensure that the type is a generic Field<T>
        if (concreteType.IsGenericType && concreteType.GetGenericTypeDefinition() == typeof(Field<>))
        {
            // Get the generic type argument (T)
            var genericArgument = concreteType.GetGenericArguments()[0];

            // Use reflection to access the constructor of Field<T>
            var constructor = concreteType.GetConstructor(new[]
            {
            typeof(string), genericArgument, typeof(string), typeof(string),
            typeof(string), typeof(ImmutableList<string?>), typeof(string)
        });

            if (constructor == null)
            {
                throw new InvalidOperationException("Cannot find a matching constructor for Field<T>.");
            }

            // Extract the values of the properties from the genericField
            var name = concreteType.GetProperty(nameof(Field<object>.Name))?.GetValue(genericField);
            var value = concreteType.GetProperty(nameof(Field<object>.Value))?.GetValue(genericField);
            var description = concreteType.GetProperty(nameof(Field<object>.Description))?.GetValue(genericField);
            var status = concreteType.GetProperty(nameof(Field<object>.Status))?.GetValue(genericField);
            var error = concreteType.GetProperty(nameof(Field<object>.Error))?.GetValue(genericField);
            var procedureCall = concreteType.GetProperty(nameof(Field<object>.ProcedureCall))?.GetValue(genericField);
            var url = concreteType.GetProperty(nameof(Field<object>.Url))?.GetValue(genericField);

            // Create a new instance of Field<T> with the extracted values
            var newField = constructor.Invoke(new object[] { name, value, description, status, error, procedureCall, url });

            return newField;
        }

        throw new InvalidOperationException("The provided IField is not of type Field<T>.");
    }

    [EffectMethod]
    public async Task HandlePostProcedureCallSuccessAction(PostProcedureCallSuccessAction receivedAction,
        IDispatcher dispatcher)
    {
        if (receivedAction?.ProcedureCallResponse?.RefreshCalls is null
            || receivedAction.ProcedureCallResponse.RefreshCalls.Count < 1)
        {
            logger.LogInformation("RefreshCall property is empty. No refresh calls to make.");
            return;
        }

        foreach (var call in receivedAction.ProcedureCallResponse.RefreshCalls)
        {
            if (string.IsNullOrWhiteSpace(call))
            {
                logger.LogError("Refresh call is null");
                continue;
            }
            logger.LogInformation("Dispatching refresh action for {Call}", call);
            stateResolver.DispatchRefreshAction(call, dispatcher, receivedAction.BasketId);
        }
    }
}
