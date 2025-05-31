using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Shared.Interfaces;
using System.Collections.Immutable;
using System.Globalization;

namespace MyOrder.Infrastructure.Repositories.Implementations;

public class BasketActionsRepository(IBasketActionsApiClient basketActionsApiClient,
    IEventAggregator eventAggregator, IBasketService basketService,
    ILogger<GeneralInfoRepository> logger)
    : BaseApiRepository(eventAggregator, basketService, logger), IBasketActionsRepository
{

    private readonly IBasketActionsApiClient _basketActionsApiClient = basketActionsApiClient ?? throw new ArgumentNullException(nameof(basketActionsApiClient));

    public async Task<NewBasketResponseDto?> PostNewBasketAsync(Dictionary<string, string?> newBasketRequest, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Posting new basket {basketRequest} from repository", newBasketRequest);
        var logString = string.Join(", ", newBasketRequest.Select(kvp => $"{kvp.Key}:{kvp.Value}"));
        logger.LogInformation("Dictionary contents: {dict}", logString);
        var operationDescription = "PostNewBasketAsync :\n" +
            $"{logString}";
        return await ExecuteAsync(
             async (token) =>
             {
                 var response = await _basketActionsApiClient.CreateNewBasketAsync(CompanyId, newBasketRequest, token);
                 logger.LogInformation("New basket response : \n{response}", response);
                 return response;
             },
            operationDescription,
            cancellationToken);
    }

    public async Task<NewOrderContextResponse?> ReloadOrderContextAsync(CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Reloading order context for {BasketId} from repository", BasketId);
        var operationDescription = $"ReloadOrderContextAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) =>
            {
                var response = await _basketActionsApiClient.ReloadOrderContextAsync(CompanyId, BasketId, token);
                logger.LogInformation("Reload Order context response : \n{response}", response);
                return response;
            },
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> PostProcedureCallAsync(ImmutableList<string?> readyToPostProcedureCall, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Posting procedure call for {BasketId} from repository", BasketId);

        var operationDescription = $"PostProcedureCallAsync for basketId {BasketId} with :\n" +
            $"{string.Join("\n ", readyToPostProcedureCall)}";

        return await ExecuteAsync(
            async (token) =>
            {
                var response = await _basketActionsApiClient.PostProcedureCallAsync(readyToPostProcedureCall, CompanyId, BasketId, token);
                logger.LogInformation("Procedure call response : \n{response}", response);
                return response;
            },
            operationDescription,
            cancellationToken);
    }

    public async Task<ProcedureCallResponseDto?> PostProcedureCallAsync(IField field, object value, CancellationToken cancellationToken = default)
    {
        logger.LogDebug("Preparing procedure call for {BasketId} from repository to update field", BasketId);
        var operationDescription = $"PostProcedureCallAsync for basketId {BasketId}";
        return await ExecuteAsync(
            async (token) =>
            {
                var procedureCall = PrepareFieldUpdateProcedureCall(field, value);

                if (procedureCall is null || procedureCall.Count < 1)
                    return null;

                return await PostProcedureCallAsync(procedureCall, token);
            },
            operationDescription,
            cancellationToken);
    }

    private ImmutableList<string?>? PrepareFieldUpdateProcedureCall(IField field, object value)
    {
        // Get the runtime type of the field and value
        var fieldType = field.GetType();
        if (!fieldType.IsGenericType || fieldType.GetGenericTypeDefinition() != typeof(Field<>))
        {
            throw new InvalidOperationException("Field is not of type Field<T>.");
        }

        // Retrieve the value's type
        var valueType = value?.GetType();

        // Retrieve the field's value
        var fieldValueProperty = fieldType.GetProperty(nameof(Field<object>.Value));
        var fieldValue = fieldValueProperty?.GetValue(field);

        if (value != null && fieldValue != null)
        {
            var fieldValueType = fieldValue.GetType();

            if (fieldValueType != valueType)
            {
                throw new InvalidOperationException($"Field and value types do not match. " +
                    $"Field type: {fieldValueType}, Value type: {valueType}");
            }
        }

        // Check if the current field value equals the new value
        if (EqualityComparer<object>.Default.Equals(fieldValue, value))
        {
            logger.LogWarning("No changes detected while updating the field {Field} value is the same as the new value.\n" +
                "Old value: {OldValue}, new value: {NewValue}.", field, fieldValue, value);
            return null;
        }

        string procedureCallValue = ProcedureCallValueToString(value);

        GetProcedureCallTemplate(field, fieldType,
            out ImmutableList<string?>? procedureCallTemplate,
            out bool pcdCallTemplateContainsNull);

        if (pcdCallTemplateContainsNull)
            logger.LogWarning("ProcedureCall contains a null item.");

        var procedureCall = procedureCallTemplate!.SetItem(procedureCallTemplate.Count - 1, procedureCallValue);

        return procedureCall;
    }

    private static string ProcedureCallValueToString(object? value)
    {
        string? str = value switch
        {
            BasketValueDto basketValue => basketValue.Value,
            AccountDto account => account.AccountId,
            ContactDto contact => contact.ContactId,
            TimeSpan ts => ts.ToString(@"hh\:mm", CultureInfo.InvariantCulture),
            _ => value?.ToString(),
        };
        return str ?? string.Empty;
    }

    private static void GetProcedureCallTemplate(IField field, Type fieldType,
        out ImmutableList<string?>? procedureCallTemplate,
        out bool pcdCallTemplateContainsNull)
    {
        procedureCallTemplate = fieldType.GetProperty(nameof(Field<object>.ProcedureCall))
            ?.GetValue(field) as ImmutableList<string?>;

        if (procedureCallTemplate is null || procedureCallTemplate.Count < 1)
        {
            throw new InvalidOperationException("ProcedureCallTemplate is either null or empty.");
        }

        pcdCallTemplateContainsNull = procedureCallTemplate
           .Take(procedureCallTemplate.Count - 2)
           .Any(item => string.IsNullOrWhiteSpace(item));
    }
}