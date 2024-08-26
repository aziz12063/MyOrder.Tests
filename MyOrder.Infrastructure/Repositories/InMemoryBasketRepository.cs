using MyOrder.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyOrder.Infrastructure.Data;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Shared.Dtos.Lines;

namespace MyOrder.Infrastructure.Repositories
{
    public class InMemoryBasketRepository : IBasketRepository
    {
        public const string _basketId = "P0130938";
        private static readonly Dictionary<string, BasketGeneralInfoDto> _basketsGeneralInfoDtos = [];
        private static readonly Dictionary<string, BasketOrderInfoDto> _basketsOrderInfoDtos = [];
        private static readonly Dictionary<string, BasketDeliveryInfoDto> _basketsDeliveryInfoDtos = [];
        private static readonly Dictionary<string, BasketInvoiceInfoDto> _basketsInvoiceInfoDtos = [];
        private static readonly Dictionary<string, BasketTradeInfoDto> _basketsTradeInfoDtos = [];
        private static readonly Dictionary<string, BasketPricesInfoDto> _basketsPricesInfoDtos = [];
        private static readonly Dictionary<string, List<ContactDto?>> _basketsOrderByContacts = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsCustomerTags = [];
        private static readonly Dictionary<string, List<SalesOriginDto?>> _basketsSalesOrigins = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsWebOrigins = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsSalesPool = [];
        private static readonly Dictionary<string, List<AccountDto?>> _basketsDeliverToAccounts = [];
        private static readonly Dictionary<string, List<ContactDto?>> _basketsDeliverToContacts = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsDeliveryModes = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsTaxGroups = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsPaymentModes = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsCoupons = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsWarrantyCostOptions = [];
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsShippingCostOptions = [];
        private static readonly Dictionary<string, ProcedureCallResponseDto> _basketsProcedureCall = [];
        private static readonly Dictionary<string, List<AccountDto?>> _basketsInvoiceToAccounts = [];
        private static readonly Dictionary<string, List<BasketLineDto?>> _basketsBasketLineDto = [];

        private int _millisecondsTimeout = 500;

        public InMemoryBasketRepository()
        {
            SeedBasketGeneralInfoData();
            SeedBasketOrderInfoData();
            SeedBasketDeliveryInfoData();
            SeedBasketInvoiceInfoData();
            SeedBasketTradeInfoData();
            SeedBasketPriceInfoData();
            SeedBasketOrderByContactsData();
            SeedBasketCustomerTagsData();
            SeedBasketSalesOriginsData();
            SeedBasketWebOriginsData();
            SeedBasketSalesPoolData();
            SeedBasketDeliverToAccountsData();
            SeedBasketDeliverToContactsData();
            SeedBasketDeliveryModesData();
            SeedBasketTaxGroupsData();
            SeedBasketPaymentModesData();
            SeedBasketCouponsData();
            SeedBasketWarrantyCostOptionsData();
            SeedBasketShippingCostOptionsData();
            SeedProcedureCallData();
            SeedInvoiceToAccountData();
            SeedbasketsBasketLineDtoData();
        }

        public async Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsGeneralInfoDtos[basketId];
        }

        public async Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsOrderInfoDtos[basketId];
        }

        public async Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsOrderByContacts[basketId];
        }

        public async Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsCustomerTags[basketId];
        }

        public async Task<List<SalesOriginDto?>> GetSalesOriginsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsSalesOrigins[basketId];
        }

        public async Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsWebOrigins[basketId];
        }

        public async Task<List<BasketValueDto?>> GetSalesPoolAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsSalesPool[basketId];
        }

        public async Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsDeliveryInfoDtos[basketId];
        }

        public async Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsDeliverToAccounts[basketId];
        }

        public async Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsDeliverToContacts[basketId];
        }

        public async Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsDeliveryModes[basketId];
        }

        public async Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsInvoiceInfoDtos[basketId];
        }

        public async Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsInvoiceToAccounts[basketId];
        }

        public async Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsTaxGroups[basketId];
        }

        public async Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsPaymentModes[basketId];
        }

        public async Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsTradeInfoDtos[basketId];
        }

        public async Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsPricesInfoDtos[basketId];
        }

        public async Task<List<BasketValueDto?>> GetCouponsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsCoupons[basketId];
        }

        public async Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsWarrantyCostOptions[basketId];
        }

        public async Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId)
        {

            await Task.Delay(_millisecondsTimeout);
            return _basketsShippingCostOptions[basketId];
        }

        public async Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, List<string> procedureCall)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsProcedureCall[basketId];
        }

      
        public async Task<IEnumerable<BasketLineDto?>> GetBasketLinesAsync(string basketId)
        {
            await Task.Delay(_millisecondsTimeout);
            return _basketsBasketLineDto[basketId];
        }


        //**********************************************************//
        // Seed Data
        //*********************************************************//

        //=======================================================================================================
        //General Info Section
        //=======================================================================================================
        private static void SeedBasketGeneralInfoData()
        {
            _basketsGeneralInfoDtos.Clear();
            _basketsGeneralInfoDtos.Add("P0130938", SampleData.generalInfoP0130938);
            _basketsGeneralInfoDtos.Add("P0130140", SampleData.generalInfoP0130140);
            _basketsGeneralInfoDtos.Add("P0130512", SampleData.generalInfoP0130512);
            _basketsGeneralInfoDtos.Add("P0130863", SampleData.generalInfoP0130863);
            _basketsGeneralInfoDtos.Add("P0130652", SampleData.generalInfoP0130652);
        }  


        //=================================================================================================//
        //Order Info Section
        //============================================================================================//
        private static void SeedBasketOrderInfoData()
        {
            _basketsOrderInfoDtos.Clear();
            _basketsOrderInfoDtos.Add(_basketId, SampleData.orderInfoP0130938);
            _basketsOrderInfoDtos.Add("P0130140", SampleData.orderInfoP0130140);
            _basketsOrderInfoDtos.Add("P0130512", SampleData.orderInfoP0130512);
            _basketsOrderInfoDtos.Add("P0130863", SampleData.orderInfoP0130863);
            _basketsOrderInfoDtos.Add("P0130652", SampleData.orderInfoP0130652);
        }  
        private static void SeedBasketOrderByContactsData()
        {
            _basketsOrderByContacts.Clear();
            _basketsOrderByContacts.Add(_basketId, SampleData.orderByContactsP0130938);
            _basketsOrderByContacts.Add("P0130140", SampleData.orderByContactsP0130140);
            _basketsOrderByContacts.Add("P0130512", SampleData.orderByContactsP0130512);
            _basketsOrderByContacts.Add("P0130863", SampleData.orderByContactsP0130863);
            _basketsOrderByContacts.Add("P0130652", SampleData.orderByContactsP0130652);
        } 
        private static void SeedBasketCustomerTagsData()
        {
            _basketsCustomerTags.Clear();
            _basketsCustomerTags.Add(_basketId, SampleData.couponsP0130938);
            _basketsCustomerTags.Add("P0130140", SampleData.customerTagsP0130140);
            _basketsCustomerTags.Add("P0130512", SampleData.customerTagsP0130512);
            _basketsCustomerTags.Add("P0130863", SampleData.customerTagsP0130863);
            _basketsCustomerTags.Add("P0130652", SampleData.customerTagsP0130652);
        } 
        private static void SeedBasketSalesOriginsData()
        {
            _basketsSalesOrigins.Clear();
            _basketsSalesOrigins.Add(_basketId, SampleData.salesOriginsP0130938);
            _basketsSalesOrigins.Add("P0130140", SampleData.salesOriginsP0130140);
            _basketsSalesOrigins.Add("P0130512", SampleData.salesOriginsP0130512);
            _basketsSalesOrigins.Add("P0130863", SampleData.salesOriginsP0130863);
            _basketsSalesOrigins.Add("P0130652", SampleData.salesOriginsP0130652);
        } 
        private static void SeedBasketWebOriginsData()
        {
            _basketsWebOrigins.Clear();
            _basketsWebOrigins.Add(_basketId, SampleData.webOriginsP0130938);
            _basketsWebOrigins.Add("P0130140", SampleData.webOriginsP0130140);
            _basketsWebOrigins.Add("P0130512", SampleData.webOriginsP0130512);
            _basketsWebOrigins.Add("P0130863", SampleData.webOriginsP0130863);
            _basketsWebOrigins.Add("P0130652", SampleData.webOriginsP0130652);
        } 
        private static void SeedBasketSalesPoolData()
        {
            _basketsSalesPool.Clear();
            _basketsSalesPool.Add(_basketId, SampleData.salesPoolsP0130938);
            _basketsSalesPool.Add("P0130140", SampleData.salesPoolsP0130140);
            _basketsSalesPool.Add("P0130512", SampleData.salesPoolsP0130512);
            _basketsSalesPool.Add("P0130863", SampleData.salesPoolsP0130863);
            _basketsSalesPool.Add("P0130652", SampleData.salesPoolsP0130652);
        } 


        //=======================================================================================================
        //Delivery section
        //=======================================================================================================
        private static void SeedBasketDeliveryInfoData()
        {
            _basketsDeliveryInfoDtos.Clear();
            _basketsDeliveryInfoDtos.Add(_basketId,SampleData.deliveryInfoP0130938);
            _basketsDeliveryInfoDtos.Add("P0130140", SampleData.deliveryInfoP0130140);
            _basketsDeliveryInfoDtos.Add("P0130512", SampleData.deliveryInfoP0130512);
            _basketsDeliveryInfoDtos.Add("P0130863", SampleData.deliveryInfoP0130863);
            _basketsDeliveryInfoDtos.Add("P0130652", SampleData.deliveryInfoP0130652);
        } 
        private static void SeedBasketDeliverToAccountsData()
        {
            _basketsDeliverToAccounts.Clear();
            _basketsDeliverToAccounts.Add(_basketId, SampleData.deliverToAccountsP0130938);
            _basketsDeliverToAccounts.Add("P0130140", SampleData.deliverToAccountsP0130140);
            _basketsDeliverToAccounts.Add("P0130512", SampleData.deliverToAccountsP0130512);
            _basketsDeliverToAccounts.Add("P0130863", SampleData.deliverToAccountsP0130863);
            _basketsDeliverToAccounts.Add("P0130652", SampleData.deliverToAccountsP0130652);
        } 
        private static void SeedBasketDeliverToContactsData()
        {
            _basketsDeliverToContacts.Clear();
            _basketsDeliverToContacts.Add(_basketId, SampleData.deliverToContactsP0130938);
            _basketsDeliverToContacts.Add("P0130140", SampleData.deliverToContactsP0130140);
            _basketsDeliverToContacts.Add("P0130863", SampleData.deliverToContactsP0130863);
            _basketsDeliverToContacts.Add("P0130652", SampleData.deliverToContactsP0130652);
            _basketsDeliverToContacts.Add("P0130512", SampleData.deliverToContactsP0130512);
        }
        private static void SeedBasketDeliveryModesData()
        {
            _basketsDeliveryModes.Clear();
            _basketsDeliveryModes.Add(_basketId, SampleData.deliveryModesP0130938);
            _basketsDeliveryModes.Add("P0130140", SampleData.deliveryModesP0130140);
            _basketsDeliveryModes.Add("P0130512", SampleData.deliveryModesP0130512);
            _basketsDeliveryModes.Add("P0130863", SampleData.deliveryModesP0130863);
            _basketsDeliveryModes.Add("P0130652", SampleData.deliveryModesP0130652);
        } 

        //=======================================================================================================
        //Invoice info section
        //=======================================================================================================
        private static void SeedBasketInvoiceInfoData()
        {
            _basketsInvoiceInfoDtos.Clear();
            _basketsInvoiceInfoDtos.Add(_basketId, SampleData.invoiceInfoP0130938);
            _basketsInvoiceInfoDtos.Add("P0130140", SampleData.invoiceInfoP0130140);
            _basketsInvoiceInfoDtos.Add("P0130512", SampleData.invoiceInfoP0130512);
            _basketsInvoiceInfoDtos.Add("P0130863", SampleData.invoiceInfoP0130863);
            _basketsInvoiceInfoDtos.Add("P0130652", SampleData.invoiceInfoP0130652);
        } 
        private static void SeedBasketTaxGroupsData()
        {
            _basketsTaxGroups.Clear();
            _basketsTaxGroups.Add(_basketId, SampleData.taxGroupsP0130938);
            _basketsTaxGroups.Add("P0130140", SampleData.taxGroupsP0130140);
            _basketsTaxGroups.Add("P0130512", SampleData.taxGroupsP0130512);
            _basketsTaxGroups.Add("P0130863", SampleData.taxGroupsP0130863);
            _basketsTaxGroups.Add("P0130652", SampleData.taxGroupsP0130652);

        }
        private static void SeedBasketPaymentModesData()
        {
            _basketsPaymentModes.Clear();
            _basketsPaymentModes.Add(_basketId, SampleData.paymentModesP0130938);
            _basketsPaymentModes.Add("P0130140", SampleData.paymentModesP0130140);
            _basketsPaymentModes.Add("P0130512", SampleData.paymentModesP0130512);
            _basketsPaymentModes.Add("P0130863", SampleData.paymentModesP0130863);
            _basketsPaymentModes.Add("P0130652", SampleData.paymentModesP0130652);
        }
        private static void SeedInvoiceToAccountData()
        {
            _basketsInvoiceToAccounts.Clear();
            _basketsInvoiceToAccounts.Add(_basketId, SampleData.invoiceToAccountsP0130938);
            _basketsInvoiceToAccounts.Add("P0130140", SampleData.invoiceToAccountsP0130140);
            _basketsInvoiceToAccounts.Add("P0130512", SampleData.invoiceToAccountsP0130512);
            _basketsInvoiceToAccounts.Add("P0130863", SampleData.invoiceToAccountsP0130863);
            _basketsInvoiceToAccounts.Add("P0130652", SampleData.invoiceToAccountsP0130652);
        }


        //=======================================================================================================
        // Trade Info Section
        //=======================================================================================================
        private static void SeedBasketTradeInfoData()
        {
            _basketsTradeInfoDtos.Clear();
            _basketsTradeInfoDtos.Add(_basketId, SampleData.tradeInfoP0130938);
            _basketsTradeInfoDtos.Add("P0130140", SampleData.tradeInfoP0130140);
            _basketsTradeInfoDtos.Add("P0130512", SampleData.tradeInfoP0130512);
            _basketsTradeInfoDtos.Add("P0130863", SampleData.tradeInfoP0130863);
            _basketsTradeInfoDtos.Add("P0130652", SampleData.tradeInfoP0130652);
        }


        //=======================================================================================================
        //Prices info section
        //=======================================================================================================
        private static void SeedBasketPriceInfoData()
        {
            _basketsPricesInfoDtos.Clear();
            _basketsPricesInfoDtos.Add(_basketId, SampleData.pricesInfoP0130938);
            _basketsPricesInfoDtos.Add("P0130140", SampleData.pricesInfoP0130140);
            _basketsPricesInfoDtos.Add("P0130512", SampleData.pricesInfoP0130512);
            _basketsPricesInfoDtos.Add("P0130863", SampleData.pricesInfoP0130863);
            _basketsPricesInfoDtos.Add("P0130652", SampleData.pricesInfoP0130652);
        } 
        private static void SeedBasketCouponsData()
        {
            _basketsCoupons.Clear();
            _basketsCoupons.Add(_basketId, SampleData.couponsP0130938);
            _basketsCoupons.Add("P0130140", SampleData.couponsP0130140);
            _basketsCoupons.Add("P0130512", SampleData.couponsP0130512);
            _basketsCoupons.Add("P0130863", SampleData.couponsP0130863);
            _basketsCoupons.Add("P0130652", SampleData.couponsP0130652);
        }
        private static void SeedBasketWarrantyCostOptionsData()
        {
            _basketsWarrantyCostOptions.Clear();
            _basketsWarrantyCostOptions.Add(_basketId, SampleData.warrantyCostOptionsP0130938);
            _basketsWarrantyCostOptions.Add("P0130140", SampleData.warrantyCostOptionsP0130140);
            _basketsWarrantyCostOptions.Add("P0130512", SampleData.warrantyCostOptionsP0130512);
            _basketsWarrantyCostOptions.Add("P0130863", SampleData.warrantyCostOptionsP0130863);
            _basketsWarrantyCostOptions.Add("P0130652", SampleData.warrantyCostOptionsP0130652);
        }
        private static void SeedBasketShippingCostOptionsData()
        {
            _basketsShippingCostOptions.Clear();
            _basketsShippingCostOptions.Add(_basketId, SampleData.shippingCostOptionsP0130938);
            _basketsShippingCostOptions.Add("P0130140", SampleData.shippingCostOptionsP0130140);
            _basketsShippingCostOptions.Add("P0130512", SampleData.shippingCostOptionsP0130512);
            _basketsShippingCostOptions.Add("P0130863", SampleData.shippingCostOptionsP0130863);
            _basketsShippingCostOptions.Add("P0130652", SampleData.shippingCostOptionsP0130652);
        }


        //=======================================================================================================
        //Procedure Call
        //=======================================================================================================
        private static void SeedProcedureCallData()
        {
            _basketsProcedureCall.Clear();
            _basketsProcedureCall.Add(_basketId, SampleData.procedureCallResponseP0130938_3);
            _basketsProcedureCall.Add("P0130140", SampleData.procedureCallResponseP0130140_3);
            _basketsProcedureCall.Add("P0130512", SampleData.procedureCallResponseP0130512_3);
            _basketsProcedureCall.Add("P0130863", SampleData.procedureCallResponseP0130863_3);
            _basketsProcedureCall.Add("P0130652", SampleData.procedureCallResponseP0130652_3);
        }

        //=======================================================================================================
        //Lines
        //=======================================================================================================
        
        private static void SeedbasketsBasketLineDtoData()
        {
            _basketsBasketLineDto.Clear();
            _basketsBasketLineDto.Add(_basketId, SampleData.basketLineDtosP0130938);
        }




    }

}





