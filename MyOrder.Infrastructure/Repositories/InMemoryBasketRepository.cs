using MyOrder.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Infrastructure.Repositories
{
    public class InMemoryBasketRepository : IBasketRepository
    {
        private static readonly Dictionary<string, BasketGeneralInfoDto> _basketsGeneralInfoDtos = [];
        private static readonly Dictionary<string, BasketOrderInfoDto> _basketsOrderInfoDtos = [];

        private static readonly Dictionary<string, BasketDeliveryInfoDto> _basketsDeliveryInfoDtos = new();
        private static readonly Dictionary<string, BasketInvoiceInfoDto> _basketsInvoiceInfoDtos = new();
        private static readonly Dictionary<string, BasketTradeInfoDto> _basketsTradeInfoDtos = new();
        private static readonly Dictionary<string, BasketPricesInfoDto> _basketsPricesInfoDtos = new();
        private static readonly Dictionary<string, List<ContactDto?>> _basketsOrderByContacts = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsCustomerTags = new();
        private static readonly Dictionary<string, List<SalesOriginDto?>> _basketsSalesOrigins = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsWebOrigins = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsSalesPool = new();
        private static readonly Dictionary<string, List<AccountDto?>> _basketsDeliverToAccounts = new();
        private static readonly Dictionary<string, List<ContactDto?>> _basketsDeliverToContacts = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsDeliveryModes = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsTaxGroups = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsPaymentModes = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsCoupons = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsWarrantyCostOptions = new();
        private static readonly Dictionary<string, List<BasketValueDto?>> _basketsShippingCostOptions = new();

        public InMemoryBasketRepository()
        {
            SeedBasketGeneralInfoData();
            SeedBasketOrderInfoData();
        }

        public Task<BasketGeneralInfoDto> GetBasketGeneralInfoAsync(string basketId)
        {
            return Task.FromResult(_basketsGeneralInfoDtos[basketId]);
        }

        public Task<BasketOrderInfoDto> GetBasketOrderInfoAsync(string basketId)
        {
            return Task.FromResult(_basketsOrderInfoDtos[basketId]);
        }

        public Task<List<ContactDto?>> GetOrderByContactsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesOriginDto?>> GetSalesOriginsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetSalesPoolAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetCouponsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId)
        {
            throw new NotImplementedException();
        }

        public Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, List<string> procedureCall)
        {
            throw new NotImplementedException();
        }


        //==================================================================================================//
        // Seed Data
        //==================================================================================================//

        private static void SeedBasketGeneralInfoData()
        {
            _basketsGeneralInfoDtos.Add("P0130738", new BasketGeneralInfoDto()
            {

                OrderType = "Panier",
                BasketId = "P0130738",
                OrderId = "WC999075",
                OrderStatus = "Nouveau",
                OrderDate = "2024-07-15 17:04:31",
                SalesResponsible = "CEDRIC REVILLON"
            });
        }

        private static void SeedBasketOrderInfoData()
        {
            _basketsOrderInfoDtos.Add("P0130738", new BasketOrderInfoDto()
            {
                Account = new Field<AccountDto>
                {
                    Name = "Compte commandeur",
                    Status = "onlyForDisplay",
                    Value = new AccountDto
                    {
                        AccountId = "C0863306",
                        Name = "MINISTERE DE LA TRANSITION ECOLOGIQUE",
                        Recipient = "DGEC SCEE SSMVM",
                        Building = "TOUR SEQUOIA",
                        Street = "1 BIS PLACE CARPEAUX",
                        Locality = "PUTEAUX",
                        ZipCode = "92055",
                        City = "PARIS LA DEFENSE CEDEX",
                        Country = "FRANCE",
                        Email = "raja1234@raja.fr",
                        Phone = "0120281279",
                        CellularPhone = "0120281279",
                        Blocked = false
                    }
                },
                Contact = new Field<ContactDto>
                {
                    Name = "Contact commandeur",
                    Status = "readWrite",
                    Value = new ContactDto
                    {
                        ContactId = null,
                        SocialTitle = null,
                        FirstName = null,
                        LastName = null,
                        Email = null,
                        Phone = null,
                        CellularPhone = null
                    },
                    ProcedureCall = new List<string>
                    {
                        "UpdateContact",
                        "OrderBy",
                        "<one of /orderByContacts contactId>"
                    }
                },
                ActivityArea = new Field<string>
                {
                    Name = "Secteur d'activité",
                    Status = "onlyForDisplay",
                    Value = "Administration publique générale",
                    Description = "Code NAF: 8411Z"
                },
                CustomerTags = new List<BasketValueDto>(), // Empty list as per JSON data
                SalesOriginId = new Field<string>
                {
                    Name = "Canal de vente",
                    Status = "readWrite",
                    Value = "Internet",
                    ProcedureCall = new List<string>
                    {
                        "UpdateOrderTablePropertyValue",
                        "SalesOriginId",
                        "System.String",
                        "<one of /salesOrigins value>"
                    }
                },
                WebOriginId = new Field<string>
                {
                    Name = "Origine e-commerce",
                    Status = "readWrite",
                    Value = "DESKTOP",
                    ProcedureCall = new List<string>
                    {
                        "UpdateOrderTablePropertyValue",
                        "RAJ_WebOriginId",
                        "System.String",
                        "<one of /webOrigins value>"
                    }
                },
                SalesPoolId = new Field<string>
                {
                    Name = "Type de transaction",
                    Status = "readWrite",
                    Value = "NOR",
                    ProcedureCall = new List<string>
                    {
                        "UpdateOrderTablePropertyValue",
                        "SalesPoolId",
                        "System.String",
                        "<one of /salesPools value>"
                    }
                },
                CustomerOrderRef = new Field<string>
                {
                    Name = "Référence Client",
                    Status = "readWrite",
                    Value = "", // Empty as per JSON data
                    ProcedureCall = new List<string>
                    {
                        "UpdateOrderTablePropertyValue",
                        "PurchOrderFormNum",
                        "System.String",
                        "<value>"
                    }
                },
                WebSalesId = new Field<string>
                {
                    Name = "Commande Web",
                    Status = "readWrite",
                    Value = "WC999075",
                    ProcedureCall = new List<string>
                    {
                        "UpdateOrderTablePropertyValue",
                        "RAJ_WebSalesId",
                        "System.String",
                        "<value>"
                    }
                },
                RelatedLink = new Field<string>
                {
                    Name = "Devis",
                    Status = "hidden",
                    Value = "" // Empty as per JSON data
                },
                Note = new Field<string>
                {
                    Name = "Note de RC",
                    Status = "onlyForDisplay",
                    Value = "" // Empty as per JSON data
                }
            });
        }

        private static void SeedBasketDeliveryInfoData()
        {
        }
    }

    ////===========================================================================================//
    //    // Prices Info
    //    //===========================================================================================//
    //    public BasketPricesInfoDto? PricesInfo = new()
    //    {
    //        // Column 1
    //        Coupon = new Field<string?> { Value = null },
    //        //Coupon = new Field<string?> { Value = "DISCOUNT10" },
    //        FreeShippingAmountThreshold = new Field<decimal?> { Value = 50.00m },
    //        GiftAmountThreshold = new Field<decimal?> { Value = 100.00m },
    //        ProductsInfo = new Field<string?> { Value = "Product A, Product B" },

    //        // Column 2
    //        ProductsNetAmount = new Field<decimal?> { Value = 150.00m },
    //        WarrantyCostOption = new Field<string?> { Value = "Standard" },
    //        WarrantyCostAmount = new Field<decimal?> { Value = 20.00m },
    //        ShippingCostOption = new Field<string?> { Value = "Express" },
    //        ShippingCostAmount = new Field<decimal?> { Value = 10.00m },
    //        LogisticInfo = new Field<string?> { Value = "Warehouse 1" },

    //        // Column 3
    //        TotalNetAmount = new Field<decimal?> { Value = 180.00m },
    //        VatAmount = new Field<decimal?> { Value = 36.00m },
    //        TotalGrossAmount = new Field<decimal?> { Value = 216.00m },
    //        FirstDeliveryDate = new Field<string?> { Value = "2024-08-01" },
    //        LastDeliveryDate = new Field<string?> { Value = "2024-08-05" },

    //        // Column 4
    //        OrderDiscountRate = new Field<int?> { Value = 10 },
    //        OrderLastColumnDiscount = new Field<bool?> { Value = true },
    //        DiscountAmount = new Field<decimal?> { Value = 18.00m },
    //        AdditionalSalesAmount = new Field<decimal?> { Value = 5.00m },
    //        TotalWeight = new Field<decimal?> { Value = 15.00m },
    //        TotalVolume = new Field<decimal?> { Value = 0.50m }
    //    };

    //    public List<BasketValueDto?>? Coupons = null;

    //    //public List<BasketValueDto?>? Coupons = new List<BasketValueDto?>
    //    //{
    //    //    new BasketValueDto { Description = "10% Off", Value = "10PERCENT" },
    //    //    new BasketValueDto { Description = "Free Shipping", Value = "FREESHIP" },
    //    //    new BasketValueDto { Description = "Black Friday Deal", Value = "BLACKFRIDAY" }
    //    //};

    //    public List<BasketValueDto?>? WarrantyCostOptions = new List<BasketValueDto?>
    //    {
    //        new BasketValueDto { Description = "Standard Warranty", Value = "STANDARD" },
    //        new BasketValueDto { Description = "Extended Warranty", Value = "EXTENDED" }
    //    };
    //    public List<BasketValueDto?>? ShippingCostOptions = new List<BasketValueDto?>
    //    {
    //        new BasketValueDto { Description = "Standard Shipping", Value = "STANDARD" },
    //        null,
    //        new BasketValueDto { Description = "Express Shipping", Value = "EXPRESS" }

    //    };

    //    //============================================================================================//
    //    // TradeInfo
    //    //============================================================================================//
    //    public BasketTradeInfoDto? BasketTradeInfo = new()
    //    {
    //        Turnover = new Field<List<BasketTurnoverLineDto?>>()
    //        {
    //            Name = "TurnoverField",
    //            Status = "Active",
    //            Type = "List",
    //            Value = new List<BasketTurnoverLineDto?>
    //        {
    //            new BasketTurnoverLineDto
    //            {
    //                Name = "Product A",
    //                Ytd = "1000",
    //                YtdN1 = "900",
    //                N1 = "800",
    //                N2 = "700"
    //            },
    //            new BasketTurnoverLineDto
    //            {
    //                Name = "Product B",
    //                Ytd = "2000",
    //                YtdN1 = "1800",
    //                N1 = "1600",
    //                N2 = "1400"
    //            },
    //            new BasketTurnoverLineDto
    //            {
    //                Name = "Product C",
    //                Ytd = "1500",
    //                YtdN1 = "1300",
    //                N1 = "1200",
    //                N2 = "1100"
    //            }
    //        },
    //            ProcedureCall = new List<string?> { "Proc1", "Proc2" },
    //            Error = null,
    //            Description = "This is the turnover data",
    //            Url = "/api/turnover"
    //        },
    //        Contract = new BasketContractInfoDto
    //        {
    //            ContractId = new Field<string>
    //            {
    //                Name = "ContractId",
    //                Status = "Active",
    //                Type = "String",
    //                Value = "C-12345",
    //                ProcedureCall = new List<string?> { "GetContractId" },
    //                Error = null,
    //                Description = "The unique identifier of the contract",
    //                Url = "/api/contract/id"
    //            },
    //            ContractType = new Field<string>
    //            {
    //                Name = "ContractType",
    //                Status = "Active",
    //                Type = "String",
    //                Value = "Premium",
    //                ProcedureCall = new List<string?> { "GetContractType" },
    //                Error = null,
    //                Description = "The type of the contract",
    //                Url = "/api/contract/type"
    //            },
    //            ContractGroup = new Field<string>
    //            {
    //                Name = "ContractGroup",
    //                Status = "Active",
    //                Type = "String",
    //                Value = "Group A",
    //                ProcedureCall = new List<string?> { "GetContractGroup" },
    //                Error = null,
    //                Description = "The group associated with the contract",
    //                Url = "/api/contract/group"
    //            },
    //            Status = new Field<string>
    //            {
    //                Name = "Status",
    //                Status = "Active",
    //                Type = "String",
    //                Value = "Active",
    //                ProcedureCall = new List<string?> { "GetContractStatus" },
    //                Error = null,
    //                Description = "The status of the contract",
    //                Url = "/api/contract/status"
    //            },
    //            StartDate = new Field<string>
    //            {
    //                Name = "StartDate",
    //                Status = "Active",
    //                Type = "Date",
    //                Value = "2023-01-01",
    //                ProcedureCall = new List<string?> { "GetStartDate" },
    //                Error = null,
    //                Description = "The start date of the contract",
    //                Url = "/api/contract/startdate"
    //            },
    //            EndDate = new Field<string>
    //            {
    //                Name = "EndDate",
    //                Status = "Active",
    //                Type = "Date",
    //                Value = "2024-01-01",
    //                ProcedureCall = new List<string?> { "GetEndDate" },
    //                Error = null,
    //                Description = "The end date of the contract",
    //                Url = "/api/contract/enddate"
    //            },
    //            CampaignId = new Field<string>
    //            {
    //                Name = "CampaignId",
    //                Status = "Active",
    //                Type = "String",
    //                Value = "Campaign-X",
    //                ProcedureCall = new List<string?> { "GetCampaignId" },
    //                Error = null,
    //                Description = "The ID of the associated campaign",
    //                Url = "/api/contract/campaignid"
    //            },
    //            MainContact = new Field<string>
    //            {
    //                Name = "MainContact",
    //                Status = "Active",
    //                Type = "String",
    //                Value = "John Doe",
    //                ProcedureCall = new List<string?> { "GetMainContact" },
    //                Error = null,
    //                Description = "The main contact for the contract",
    //                Url = "/api/contract/maincontact"
    //            },
    //            OfficeExecutive = new Field<string>
    //            {
    //                Name = "OfficeExecutive",
    //                Status = "Active",
    //                Type = "String",
    //                Value = "Jane Smith",
    //                ProcedureCall = new List<string?> { "GetOfficeExecutive" },
    //                Error = null,
    //                Description = "The office executive handling the contract",
    //                Url = "/api/contract/officeexecutive"
    //            },
    //            DiscountList = new Field<List<string?>>()
    //            {
    //                Name = "DiscountList",
    //                Status = "Active",
    //                Type = "List",
    //                Value = new List<string?> { "10% off", "15% off", "Free Shipping" },
    //                ProcedureCall = new List<string?> { "GetDiscountList" },
    //                Error = null,
    //                Description = "List of discounts applied to the contract",
    //                Url = "/api/contract/discountlist"
    //            }
    //        }
    //    };

}
