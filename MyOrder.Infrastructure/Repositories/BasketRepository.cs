using Microsoft.Extensions.Logging;
using MyOrder.Infrastructure.ApiClients;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Dtos.GeneralInformation;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos.SharedComponents;
using Newtonsoft.Json;
using System.Collections.Immutable;

namespace MyOrder.Infrastructure.Repositories;

public class BasketRepository(IBasketApiClient apiClient,
    ILogger<BasketRepository> logger) : IBasketRepository
{
    //=======================================================================================================
    //General Info Section
    //=======================================================================================================
    #region GeneralInfo
    public async Task<GeneralInfoDto> GetBasketGeneralInfoAsync(string basketId)
    {
        logger.LogDebug("Fetching basket general info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketGeneralInfoAsync(basketId);
    }
    public async Task<List<BasketNotificationDto?>?> GetNotificationsAsync(string basketId)
    {
        logger.LogDebug("Fetching basket notification for {BasketId} from repository", basketId);
        return await apiClient.GetNotificationsAsync(basketId);
    }
    public async Task<List<BasketBlockingReasonDto?>?> GetBlockingReasonsAsync(string basketId)
    {
        logger.LogDebug("Fetching blocking reasons for {BasketId} from repository", basketId);
        return await apiClient.GetBlockingReasonsAsync(basketId);
    }
    public async Task<List<BasketNotificationDto?>?> GetValudationRulesAsync(string basketId)
    {
        logger.LogDebug("Fetching validation rules for {BasketId} from repository", basketId);
        return await apiClient.GetValudationRulesAsync(basketId);
    }

    #endregion
    //=======================================================================================================
    //Actions
    //=======================================================================================================
    #region Actions

    public async Task<NewBasketResponseDto> PostNewBasketAsync(Dictionary<string, string> newBasketRequest)
    {
        logger.LogInformation("Posting new basket request {newBasketRequest}", newBasketRequest);
        var response = await apiClient.CreateNewBasketAsync(newBasketRequest);
        logger.LogInformation("New basket response : \n{response}", response);
        return response;
    }

    #region PostProcedureCall

    public async Task<ProcedureCallResponseDto?> PostProcedureCallAsync(ImmutableList<string?> readyToPostProcedureCall, string basketId)
    {
        logger.LogInformation("Posting procedure call : \n{readyProcedureCall} " +
            "\nfor {BasketId} from repository", string.Join("\n", readyToPostProcedureCall), basketId);

        var response = await apiClient.PostProcedureCallAsync(basketId, readyToPostProcedureCall);

        logger.LogInformation("Procedure call response : \n{response}", response);

        return response;
    }

    public async Task<ProcedureCallResponseDto?> PostProcedureCallAsync(IField field, object value, string basketId)
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

        var response = await PostProcedureCallAsync(procedureCall, basketId);

        logger.LogInformation("Procedure call response : \n{response}", response);

        return response;
    }

    private static string ProcedureCallValueToString(object? value)
    {
        string? str = value switch
        {
            BasketValueDto basketValue => basketValue.Value,
            AccountDto account => account.AccountId,
            ContactDto contact => contact.ContactId,
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

    #endregion

    public async Task<NewOrderContextResponse> ReloadOrderContextAsync(string basketId)
    {
        logger.LogDebug("Reloading order context for {BasketId} from repository", basketId);
        return await apiClient.ReloadOrderContextAsync(basketId);
    }

    #endregion
    //=======================================================================================================
    //Order Info Section
    //=======================================================================================================
    #region OrderInfo

    public async Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId)
    {
        logger.LogDebug("Fetching basket order info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketOrderInfoAsync(basketId);
    }

    public async Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId)
    {
        logger.LogDebug("Fetching order by contacts for {BasketId} from repository", basketId);
        return await apiClient.GetOrderByContactsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId)
    {
        logger.LogDebug("Fetching customer tags for {BasketId} from repository", basketId);
        return await apiClient.GetCustomerTagsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetSalesOriginsAsync(string basketId)
    {
        logger.LogDebug("Fetching SalesOrigins info for {BasketId} from repository", basketId);
        return await apiClient.GetSalesOriginsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId)
    {
        logger.LogDebug("Fetching WebOrigins info for {BasketId} from repository", basketId);
        return await apiClient.GetWebOriginsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetSalesPoolAsync(string basketId)
    {
        logger.LogDebug("Fetching SalesPools info for {BasketId} from repository", basketId);
        return await apiClient.GetSalesPoolsAsync(basketId);
    }

    #endregion
    //=======================================================================================================
    //Delivery section
    //=======================================================================================================
    #region DeliveryInfo

    public async Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId)
    {
        logger.LogDebug("Fetching basket delivery info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketDeliveryInfoAsync(basketId);
    }

    public async Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId)
    {
        logger.LogDebug("Fetching deliver to accounts for {BasketId} from repository", basketId);
        return await apiClient.GetDeliverToAccountsAsync(basketId);
    }

    public async Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId)
    {
        logger.LogDebug("Fetching deliver to contacts for {BasketId} from repository", basketId);
        return await apiClient.GetDeliverToContactsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId)
    {
        logger.LogDebug("Fetching delivery modes for {BasketId} from repository", basketId);
        return await apiClient.GetDeliveryModesAsync(basketId);
    }

    #endregion
    //=======================================================================================================
    //Invoice info section
    //=======================================================================================================
    #region InvoiceInfo

    public async Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId)
    {
        logger.LogDebug("Fetching basket invoice info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketInvoiceInfoAsync(basketId);
    }

    public async Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId)
    {
        logger.LogDebug("Fetching invoice to accounts for {BasketId} from repository", basketId);
        return await apiClient.GetInvoiceToAccountsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId)
    {
        logger.LogDebug("Fetching tax groups for {BasketId} from repository", basketId);
        return await apiClient.GetTaxGroupsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId)
    {
        logger.LogDebug("Fetching payment modes for {BasketId} from repository", basketId);
        return await apiClient.GetPaymentModesAsync(basketId);
    }

    #endregion
    //=======================================================================================================
    // Trade Info Section
    //=======================================================================================================
    #region TradeInfo
    public async Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId)
    {
        logger.LogDebug("Fetching basket trade info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketTradeInfoAsync(basketId);
    }
    #endregion
    //=======================================================================================================
    //PriceLines info section
    //=======================================================================================================
    #region PricesInfo

    public async Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId)
    {
        logger.LogDebug("Fetching basket prices info for {BasketId} from repository", basketId);
        return await apiClient.GetBasketPricesInfoAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetCouponsAsync(string basketId)
    {
        logger.LogDebug("Fetching coupons for {BasketId} from repository", basketId);
        return await apiClient.GetCouponsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId)
    {
        logger.LogDebug("Fetching warranty cost options for {BasketId} from repository", basketId);
        return await apiClient.GetWarrantyCostOptionsAsync(basketId);
    }

    public async Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId)
    {
        logger.LogDebug("Fetching shipping cost options for {BasketId} from repository", basketId);
        return await apiClient.GetShippingCostOptionsAsync(basketId);
    }

    #endregion
    //=======================================================================================================
    //Lines
    //=======================================================================================================
    #region Lines

    public async Task<BasketOrderLinesDto> GetBasketLinesAsync(string basketId)
    {
        logger.LogDebug("Fetching basket lines for {BasketId} from repository", basketId);
        return await apiClient.GetBasketLinesAsync(basketId);
    }
    public async Task<List<BasketValueDto?>> GetlineUpdateReasonsAsync(string basketId)
    {
        logger.LogDebug("Fetching UpdateReasons for {BasketId} from repository", basketId);
        return await apiClient.GetlineUpdateReasonsAsync(basketId);
    }
    public async Task<List<BasketValueDto?>> GetlogisticFlowsAsync(string basketId)
    {
        logger.LogDebug("Fetching logisticFlows for {BasketId} from repository", basketId);
        return await apiClient.GetlogisticFlowsAsync(basketId);
    }
    public async Task<ProcedureCallResponseDto> DuplicateOrderLinesAsync(string basketId, List<int> linesIds)
    {
        logger.LogDebug("Duplicating order lines for {BasketId} from repository", basketId);
        return await apiClient.DuplicateOrderLinesAsync(basketId, linesIds);
    }
    public async Task<ProcedureCallResponseDto> DeleteOrderLinesAsync(string basketId, List<int> linesIds)
    {
        logger.LogDebug("Deleting order lines for {BasketId} from repository", basketId);
        return await apiClient.DeleteOrderLinesAsync(basketId, linesIds);
    }
    public async Task<BasketLineDto?> GetNewLineAsync(string basketId)
    {
        logger.LogDebug("Fetching new line for {BasketId} from repository", basketId);
        return await apiClient.GetNewLineAsync(basketId);
    }
    public async Task<BasketLineDto> ResetNewLineStateAsync(string basketId)
    {
        logger.LogDebug("Resetting new line state for {BasketId} from repository", basketId);
        return await apiClient.ResetNewLineStateAsync(basketId);
    }
    public async Task<ProcedureCallResponseDto> CommitAddNewLineAsync(string basketId)
    {
        logger.LogDebug("Committing new line for {BasketId} from repository", basketId);

        var response = await apiClient.CommitAddNewLineAsync(basketId);

        logger.LogInformation("Procedure call response : \n{response}", response);
        return response;
    }

    public async Task<ProcedureCallResponseDto?> CommitAddFreeTextLineAsync(string basketId, List<string?> freeTexts )
    {
        logger.LogInformation("Posting free texts : \n{freeTexts} " +
            "\nfor {BasketId} from repository", string.Join("\n", freeTexts), basketId);

        return await apiClient.CommitAddFreeTextLineAsync(basketId, freeTexts);
    }

    public async Task<List<BestSellerItemDto?>?> GetBasketBestSellersAsync(string basketId, string? filter = null)
    {
        logger.LogDebug("Fetching BestSellerItems for {BasketId} from repository", basketId);
        return await apiClient.GetBasketBestSellersAsync(basketId, filter);
    }

    public async Task<List<OrderedItemDto?>?> GetBasketOrderedItemsAsync(string basketId, string? filter = null)
    {
        logger.LogDebug("Fetching OrderedItems for {BasketId} from repository", basketId);
        return await apiClient.GetBasketOrderedItemsAsync(basketId, filter);
    }
    public async Task<List<BasketItemDto?>?> GetBasketSearchItemsAsync(string basketId, string? filter = null)
    {
        logger.LogDebug("Fetching BasketItems for {BasketId} from repository", basketId);
        return await apiClient.GetBasketSearchItemsAsync(basketId, filter);
    }
    #endregion
}