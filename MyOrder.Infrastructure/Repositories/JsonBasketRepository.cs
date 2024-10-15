using Microsoft.AspNetCore.Hosting;
using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.BasketItems;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos.SharedComponents;
using Newtonsoft.Json;
using System.Collections.Immutable;

namespace MyOrder.Infrastructure.Repositories
{
    public class JsonBasketRepository : IBasketRepository
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string baseDataPath;

        public JsonBasketRepository(IWebHostEnvironment environment)
        {
            _environment = environment;
            baseDataPath = Path.Combine(_environment.ContentRootPath, "..", "..", "MyOrder.infrastructure", "Data");
        }

        //=======================================================================================================
        public Task<ProcedureCallResponseDto> CommitAddNewLineAsync(string basketId)
        {
            throw new NotImplementedException();
        }


        public Task<NewOrderContextResponse> ReloadOrderContextAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        //=================================================================================================================================
        public async Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId)
        {
            //var jsonFilePath = Path.Combine(baseDataPath, "generalInfo.json");
            var jsonFilePath = Path.Combine(baseDataPath, "generalInfo.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<BasketGeneralInfoDto>(json);
        }

        //========================================================================================================================

        public async Task<List<BasketNotificationDto?>?> GetNotificationsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "notification.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketNotificationDto?>>(json);
        }


        //========================================================================================================================
        //Order Info Section
        //=======================================================================================================
        #region
        public async Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "orderInfo.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<BasketOrderInfoDto>(json);
        }

        public async Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "customerTags.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }

        public async Task<List<BasketValueDto?>> GetSalesOriginsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "salesOrigins.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }

        public async Task<List<BasketValueDto?>> GetSalesPoolAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "salesPools.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }
        public async Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "webOrigins.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }

        public async Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "orderByContacts.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<ContactDto?>>(json);
        }
        #endregion
        //========================================================================================================================
        //Delivery section
        //=======================================================================================================
        public async Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "deliveryInfo.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<BasketDeliveryInfoDto>(json);
        }


        public async Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "deliverToAccounts.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<AccountDto?>>(json);
        }

        public async Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "deliverToContacts.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<ContactDto?>>(json);
        }

        public async Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "deliveryModes.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }



        //========================================================================================================================
        //Invoice info section
        //=======================================================================================================
        public async Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "invoiceInfo.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<BasketInvoiceInfoDto>(json);
        }

        public async Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "paymentModes.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }
        public async Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "invoiceToAccounts.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<AccountDto?>>(json);
        }
        public async Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "taxGroups.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }

        //===================================================================================================================
        // Trade Info Section
        //=======================================================================================================
        public async Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "tradeInfo.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<BasketTradeInfoDto>(json);
        }

        //========================================================================================================================
        //Prices info section
        //=======================================================================================================
        public async Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "pricesInfo.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<BasketPricesInfoDto>(json);
        }
        public async Task<List<BasketValueDto?>> GetCouponsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "coupons.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }

        public async Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "shippingCostOptions.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }



        public async Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "warrantyCostOptions.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }





        //========================================================================================================================
        //Lines
        //=======================================================================================================

        public async Task<BasketOrderLinesDto> GetBasketLinesAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "orderLines.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<BasketOrderLinesDto>(json);
        }

        public async Task<List<BasketValueDto?>> GetlineUpdateReasonsAsync(string basketId)// this too
        {
            var jsonFilePath = Path.Combine(baseDataPath, "lineUpdateReasons.json");

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine($"the path of updateReason is: {jsonFilePath}");
                return null;
            }

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }

        public async Task<List<BasketValueDto?>> GetlogisticFlowsAsync(string basketId)// Logistic not logistic
        {
            var jsonFilePath = Path.Combine(baseDataPath, "logisticFlows.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<List<BasketValueDto?>>(json);
        }

        public async Task<BasketLineDto?> GetNewLineAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "newLine.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
            return JsonConvert.DeserializeObject<BasketLineDto>(json);
        }
        public Task<BasketLineDto> ResetNewLineStateAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BestSellerItemDto>> GetBasketBestSellersAsync(string basketId)
        {
            var jsonFilePath = Path.Combine(baseDataPath, "orderedItems.json");
            if (!File.Exists(jsonFilePath))
                return null;

            var json = await File.ReadAllTextAsync(jsonFilePath);
           
            return JsonConvert.DeserializeObject<List<BestSellerItemDto>>(json);
        }








        public Task<NewBasketResponseDto> PostNewBasketAsync(Dictionary<string, string> newBasketRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ProcedureCallResponseDto> PostProcedureCallAsync(IField field, object value, string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<ProcedureCallResponseDto?> PostProcedureCallAsync(ImmutableList<string> readToPostProcedureCall, string basketId)
        {
            throw new NotImplementedException();
        }
    }
}
