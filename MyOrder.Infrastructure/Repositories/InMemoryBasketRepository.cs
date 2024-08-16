using MyOrder.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyOrder.Infrastructure.Data;
using MyOrder.Shared.Dtos.SharedComponents;

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
            return Task.FromResult(_basketsOrderByContacts[basketId]);
        }

        public Task<List<BasketValueDto?>> GetCustomerTagsAsync(string basketId)
        {
            return Task.FromResult(_basketsCustomerTags[basketId]);
        }

        public Task<List<SalesOriginDto?>> GetSalesOriginsAsync(string basketId)
        {
            return Task.FromResult(_basketsSalesOrigins[basketId]);
        }

        public Task<List<BasketValueDto?>> GetWebOriginsAsync(string basketId)
        {
            return Task.FromResult(_basketsWebOrigins[basketId]);
        }

        public Task<List<BasketValueDto?>> GetSalesPoolAsync(string basketId)
        {
            return Task.FromResult(_basketsSalesPool[basketId]);
        }

        public Task<BasketDeliveryInfoDto> GetBasketDeliveryInfoAsync(string basketId)
        {
            return Task.FromResult(_basketsDeliveryInfoDtos[basketId]);
        }

        public Task<List<AccountDto?>> GetDeliverToAccountsAsync(string basketId)
        {
            return Task.FromResult(_basketsDeliverToAccounts[basketId]);
        }

        public Task<List<ContactDto?>> GetDeliverToContactsAsync(string basketId)
        {
            return Task.FromResult(_basketsDeliverToContacts[basketId]);
        }

        public Task<List<BasketValueDto?>> GetDeliveryModesAsync(string basketId)
        {
            return Task.FromResult(_basketsDeliveryModes[basketId]);
        }

        public Task<BasketInvoiceInfoDto> GetBasketInvoiceInfoAsync(string basketId)
        {
            return Task.FromResult(_basketsInvoiceInfoDtos[basketId]);
        }

        public Task<List<AccountDto?>> GetInvoiceToAccountsAsync(string basketId)
        {
            return Task.FromResult(_basketsInvoiceToAccounts[basketId]);
        }

        public Task<List<BasketValueDto?>> GetTaxGroupsAsync(string basketId)
        {
            return Task.FromResult(_basketsTaxGroups[basketId]);
        }

        public Task<List<BasketValueDto?>> GetPaymentModesAsync(string basketId)
        {
            return Task.FromResult(_basketsPaymentModes[basketId]);
        }

        public Task<BasketTradeInfoDto> GetBasketTradeInfoAsync(string basketId)
        {
            return Task.FromResult(_basketsTradeInfoDtos[basketId]);
        }

        public Task<BasketPricesInfoDto> GetBasketPricesInfoAsync(string basketId)
        {
            return Task.FromResult(_basketsPricesInfoDtos[basketId]);
        }

        public Task<List<BasketValueDto?>> GetCouponsAsync(string basketId)
        {
            return Task.FromResult(_basketsCoupons[basketId]);
        }

        public Task<List<BasketValueDto?>> GetWarrantyCostOptionsAsync(string basketId)
        {
            return Task.FromResult(_basketsWarrantyCostOptions[basketId]);
        }

        public Task<List<BasketValueDto?>> GetShippingCostOptionsAsync(string basketId)
        {

            return Task.FromResult(_basketsShippingCostOptions[basketId]);
        }

        public Task<ProcedureCallResponseDto> PostProcedureCallAsync(string basketId, List<string> procedureCall)
        {
            return Task.FromResult(_basketsProcedureCall[basketId]);
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
            _basketsGeneralInfoDtos.Add(_basketId, new BasketGeneralInfoDto()
            {

                OrderType = "Panier",
                BasketId = _basketId,
                OrderId = "WC999075",
                OrderStatus = "Nouveau",
                OrderDate = "2024-07-15 17:04:31",
                SalesResponsible = "CEDRIC REVILLON"
            });
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
            _basketsOrderInfoDtos.Add(_basketId, new BasketOrderInfoDto()
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
                    ProcedureCall = new List<string?>
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
                    ProcedureCall = new List<string?>
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
                    ProcedureCall = new List<string?>
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
                    ProcedureCall = new List<string?>
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
                    Value = "",
                    ProcedureCall = new List<string?>
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
                    ProcedureCall = new List<string?>
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
            _basketsOrderInfoDtos.Add("P0130140", SampleData.orderInfoP0130140);
            _basketsOrderInfoDtos.Add("P0130512", SampleData.orderInfoP0130512);
            _basketsOrderInfoDtos.Add("P0130863", SampleData.orderInfoP0130863);
            _basketsOrderInfoDtos.Add("P0130652", SampleData.orderInfoP0130652);
        }
        private static void SeedBasketOrderByContactsData()
        {
            _basketsOrderByContacts.Clear();
            _basketsOrderByContacts.Add(_basketId, new List<ContactDto?>()
            {
                new ContactDto
    {
        ContactId = "C001",
        SocialTitle = "Mr.",
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        Phone = "123-456-7890",
        CellularPhone = "987-654-3210"
    },
    new ContactDto
    {
        ContactId = "C002",
        SocialTitle = "Ms.",
        FirstName = "Jane",
        LastName = "Smith",
        Email = "jane.smith@example.com",
        Phone = "234-567-8901",
        CellularPhone = "876-543-2109"
    },
    null // Example of a nullable ContactDto
            });
            _basketsOrderByContacts.Add("P0130140", SampleData.orderByContactsP0130140);
            _basketsOrderByContacts.Add("P0130512", SampleData.orderByContactsP0130512);
            _basketsOrderByContacts.Add("P0130863", SampleData.orderByContactsP0130863);
            _basketsOrderByContacts.Add("P0130652", SampleData.orderByContactsP0130652);
        }
        private static void SeedBasketCustomerTagsData()
        {
            _basketsCustomerTags.Clear();
            _basketsCustomerTags.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
            _basketsCustomerTags.Add("P0130140", SampleData.customerTagsP0130140);
            _basketsCustomerTags.Add("P0130512", SampleData.customerTagsP0130512);
            _basketsCustomerTags.Add("P0130863", SampleData.customerTagsP0130863);
            _basketsCustomerTags.Add("P0130652", SampleData.customerTagsP0130652);
        }
        private static void SeedBasketSalesOriginsData()
        {
            _basketsSalesOrigins.Clear();
            _basketsSalesOrigins.Add(_basketId, new List<SalesOriginDto?>()
            {
                new SalesOriginDto
    {
        Value = "Online"
    },
    new SalesOriginDto
    {
        Value = "In-Store"
    },
    new SalesOriginDto
    {
        Value = "Referral"
    },
    null // Example of a nullable SalesOriginDto
            });
            _basketsSalesOrigins.Add("P0130140", SampleData.salesOriginsP0130140);
            _basketsSalesOrigins.Add("P0130512", SampleData.salesOriginsP0130512);
            _basketsSalesOrigins.Add("P0130863", SampleData.salesOriginsP0130863);
            _basketsSalesOrigins.Add("P0130652", SampleData.salesOriginsP0130652);
        }
        private static void SeedBasketWebOriginsData()
        {
            _basketsWebOrigins.Clear();
            _basketsWebOrigins.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
            _basketsWebOrigins.Add("P0130140", SampleData.webOriginsP0130140);
            _basketsWebOrigins.Add("P0130512", SampleData.webOriginsP0130512);
            _basketsWebOrigins.Add("P0130863", SampleData.webOriginsP0130863);
            _basketsWebOrigins.Add("P0130652", SampleData.webOriginsP0130652);
        }
        private static void SeedBasketSalesPoolData()
        {
            _basketsSalesPool.Clear();
            _basketsSalesPool.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
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
            _basketsDeliveryInfoDtos.Add(_basketId, new BasketDeliveryInfoDto()
            {
                Account = new Field<AccountDto>
                {
                    Name = "Account",
                    Status = "Active",
                    Type = "AccountDto",
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
                    },
                    ProcedureCall = new List<string?> { "Procedure1", "Procedure2" },
                    Error = null,
                    Description = "Primary Account",
                    Url = "http://example.com/account"
                },
                Contact = new Field<ContactDto>
                {
                    Name = "Contact",
                    Status = "Active",
                    Type = "ContactDto",
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
                    ProcedureCall = new List<string?> { "ProcedureA", "ProcedureB" },
                    Error = null,
                    Description = "Primary Contact",
                    Url = "http://example.com/contact"
                },
                DeliveryMode = new Field<string>
                {
                    Name = "Delivery Mode",
                    Status = "Active",
                    Type = "String",
                    Value = "Standard Shipping",
                    ProcedureCall = new List<string?> { "DeliveryProcedure1" },
                    Error = null,
                    Description = "Mode of Delivery",
                    Url = null
                },
                CompleteDelivery = new Field<bool>
                {
                    Name = "Complete Delivery",
                    Status = "Pending",
                    Type = "Boolean",
                    Value = true,
                    ProcedureCall = new List<string?> { "CompleteDeliveryProcedure" },
                    Error = null,
                    Description = "Complete Delivery required",
                    Url = null
                },
                ImperativeDate = new Field<string>
                {
                    Name = "Imperative Date",
                    Status = "Active",
                    Type = "String",
                    Value = "2024-08-15",
                    ProcedureCall = new List<string?> { "DateProcedure1" },
                    Error = null,
                    Description = "Required Delivery Date",
                    Url = null
                },
                OrderDocuments = new Field<List<string?>>
                {
                    Name = "Order Documents",
                    Status = "Complete",
                    Type = "List<string>",
                    Value = new List<string?> { "Doc1", "Doc2", "Doc3" },
                    ProcedureCall = new List<string?> { "DocumentProcedure1" },
                    Error = null,
                    Description = "Associated Order Documents",
                    Url = null
                },
                Note = new Field<string>
                {
                    Name = "Note",
                    Status = "Active",
                    Type = "String",
                    Value = "Handle with care",
                    ProcedureCall = new List<string?> { "NoteProcedure1" },
                    Error = null,
                    Description = "Delivery Note",
                    Url = null
                },
                NoteMustBeSaved = new Field<bool>
                {
                    Name = "Note Must Be Saved",
                    Status = "Active",
                    Type = "Boolean",
                    Value = true,
                    ProcedureCall = new List<string?> { "SaveNoteProcedure" },
                    Error = null,
                    Description = "Flag to save note",
                    Url = null
                }
            });
            _basketsDeliveryInfoDtos.Add("P0130140", SampleData.deliveryInfoP0130140);
            _basketsDeliveryInfoDtos.Add("P0130512", SampleData.deliveryInfoP0130512);
            _basketsDeliveryInfoDtos.Add("P0130863", SampleData.deliveryInfoP0130863);
            _basketsDeliveryInfoDtos.Add("P0130652", SampleData.deliveryInfoP0130652);
        }
        private static void SeedBasketDeliverToAccountsData()
        {
            _basketsDeliverToAccounts.Clear();
            _basketsDeliverToAccounts.Add(_basketId, new List<AccountDto?>()
            {
                new AccountDto
    {
        AccountId = "A001",
        Name = "John Doe",
        Recipient = "John Doe",
        Building = "Building 1",
        Street = "123 Main St",
        Locality = "Downtown",
        ZipCode = "12345",
        City = "Metropolis",
        Country = "USA",
        Email = "john.doe@example.com",
        Phone = "123-456-7890",
        CellularPhone = "987-654-3210",
        Blocked = false
    },
                new AccountDto
    {
        AccountId = "A002",
        Name = "Jane Smith",
        Recipient = "Jane Smith",
        Building = "Building 2",
        Street = "456 Elm St",
        Locality = "Uptown",
        ZipCode = "67890",
        City = "Gotham",
        Country = "USA",
        Email = "jane.smith@example.com",
        Phone = "234-567-8901",
        CellularPhone = "876-543-2109",
        Blocked = false
    },
                null // Example of a nullable AccountDto
            });
            _basketsDeliverToAccounts.Add("P0130140", SampleData.deliverToAccountsP0130140);
            _basketsDeliverToAccounts.Add("P0130512", SampleData.deliverToAccountsP0130512);
            _basketsDeliverToAccounts.Add("P0130863", SampleData.deliverToAccountsP0130863);
            _basketsDeliverToAccounts.Add("P0130652", SampleData.deliverToAccountsP0130652);
        }
        private static void SeedBasketDeliverToContactsData()
        {
            _basketsDeliverToContacts.Clear();
            _basketsDeliverToContacts.Add(_basketId, new List<ContactDto?>()
            {
                new ContactDto
    {
        ContactId = "C001",
        SocialTitle = "Mr.",
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        Phone = "123-456-7890",
        CellularPhone = "987-654-3210"
    },
    new ContactDto
    {
        ContactId = "C002",
        SocialTitle = "Ms.",
        FirstName = "Jane",
        LastName = "Smith",
        Email = "jane.smith@example.com",
        Phone = "234-567-8901",
        CellularPhone = "876-543-2109"
    },
    null // Example of a nullable ContactDto
            });
            _basketsDeliverToContacts.Add("P0130140", SampleData.deliverToContactsP0130140);
            _basketsDeliverToContacts.Add("P0130863", SampleData.deliverToContactsP0130863);
            _basketsDeliverToContacts.Add("P0130652", SampleData.deliverToContactsP0130652);
            _basketsDeliverToContacts.Add("P0130512", SampleData.deliverToContactsP0130512);
        }
        private static void SeedBasketDeliveryModesData()
        {
            _basketsDeliveryModes.Clear();
            _basketsDeliveryModes.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
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
            _basketsInvoiceInfoDtos.Add(_basketId, new BasketInvoiceInfoDto()
            {
                Account = new Field<AccountDto>
                {
                    Name = "Billing Account",
                    Status = "Active",
                    Type = "AccountDto",
                    Value = new AccountDto
                    {
                        AccountId = "C0123456",
                        Name = "Company XYZ",
                        Recipient = "Billing Department",
                        Building = "Headquarters",
                        Street = "456 Business Rd",
                        Locality = "Financial District",
                        ZipCode = "67890",
                        City = "Business City",
                        Country = "Countryland",
                        Email = "billing@companyxyz.com",
                        Phone = "234-567-8901",
                        CellularPhone = "345-678-9012",
                        Blocked = false
                    },
                    ProcedureCall = new List<string?> { "AccountProcedure1" },
                    Error = null,
                    Description = "Primary billing account",
                    Url = "http://example.com/billingaccount"
                },
                SiretId = new Field<string>
                {
                    Name = "SIRET ID",
                    Status = "Active",
                    Type = "String",
                    Value = "12345678900012",
                    ProcedureCall = new List<string?> { "SiretProcedure" },
                    Error = null,
                    Description = "Company SIRET ID",
                    Url = null
                },
                TaxGroup = new Field<string>
                {
                    Name = "Tax Group",
                    Status = "Active",
                    Type = "String",
                    Value = "Standard VAT",
                    ProcedureCall = new List<string?> { "TaxGroupProcedure" },
                    Error = null,
                    Description = "Applicable tax group",
                    Url = null
                },
                PaymentTerm = new Field<string>
                {
                    Name = "Payment Term",
                    Status = "Fixed",
                    Type = "String",
                    Value = "Net 30",
                    ProcedureCall = new List<string?> { "PaymentTermProcedure" },
                    Error = null,
                    Description = "Payment term for invoices",
                    Url = null
                },
                PaymentMode = new Field<string>
                {
                    Name = "Payment Mode",
                    Status = "Active",
                    Type = "String",
                    Value = "Bank Transfer",
                    ProcedureCall = new List<string?> { "PaymentModeProcedure" },
                    Error = null,
                    Description = "Preferred payment mode",
                    Url = null
                },
                IsPublicEntity = true,
                PublicEntityExecutingService = new Field<string>
                {
                    Name = "Executing Service",
                    Status = "Active",
                    Type = "String",
                    Value = "Public Works Department",
                    ProcedureCall = new List<string?> { "ExecutingServiceProcedure" },
                    Error = null,
                    Description = "Service responsible for execution",
                    Url = null
                },
                PublicEntityLegalCommitment = new Field<string>
                {
                    Name = "Legal Commitment",
                    Status = "Active",
                    Type = "String",
                    Value = "Legal Document XYZ",
                    ProcedureCall = new List<string?> { "LegalCommitmentProcedure" },
                    Error = null,
                    Description = "Legal commitment document",
                    Url = null
                },
                Note = new Field<string>
                {
                    Name = "Invoice Note",
                    Status = "Active",
                    Type = "String",
                    Value = "Please process this invoice promptly.",
                    ProcedureCall = new List<string?> { "InvoiceNoteProcedure" },
                    Error = null,
                    Description = "Additional notes for the invoice",
                    Url = null
                }
            });
            _basketsInvoiceInfoDtos.Add("P0130140", SampleData.invoiceInfoP0130140);
            _basketsInvoiceInfoDtos.Add("P0130512", SampleData.invoiceInfoP0130512);
            _basketsInvoiceInfoDtos.Add("P0130863", SampleData.invoiceInfoP0130863);
            _basketsInvoiceInfoDtos.Add("P0130652", SampleData.invoiceInfoP0130652);
        }
        private static void SeedBasketTaxGroupsData()
        {
            _basketsTaxGroups.Clear();
            _basketsTaxGroups.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
            _basketsTaxGroups.Add("P0130140", SampleData.taxGroupsP0130140);
            _basketsTaxGroups.Add("P0130512", SampleData.taxGroupsP0130512);
            _basketsTaxGroups.Add("P0130863", SampleData.taxGroupsP0130863);
            _basketsTaxGroups.Add("P0130652", SampleData.taxGroupsP0130652);

        }
        private static void SeedBasketPaymentModesData()
        {
            _basketsPaymentModes.Clear();
            _basketsPaymentModes.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
            _basketsPaymentModes.Add("P0130140", SampleData.paymentModesP0130140);
            _basketsPaymentModes.Add("P0130512", SampleData.paymentModesP0130512);
            _basketsPaymentModes.Add("P0130863", SampleData.paymentModesP0130863);
            _basketsPaymentModes.Add("P0130652", SampleData.paymentModesP0130652);
        }
        private static void SeedInvoiceToAccountData()
        {
            _basketsInvoiceToAccounts.Clear();
            _basketsInvoiceToAccounts.Add(_basketId, new List<AccountDto?>()
            {
                new AccountDto
    {
        AccountId = "A001",
        Name = "John Doe",
        Recipient = "John Doe",
        Building = "Building 1",
        Street = "123 Main St",
        Locality = "Downtown",
        ZipCode = "12345",
        City = "Metropolis",
        Country = "USA",
        Email = "john.doe@example.com",
        Phone = "123-456-7890",
        CellularPhone = "987-654-3210",
        Blocked = false
    },
                new AccountDto
    {
        AccountId = "A002",
        Name = "Jane Smith",
        Recipient = "Jane Smith",
        Building = "Building 2",
        Street = "456 Elm St",
        Locality = "Uptown",
        ZipCode = "67890",
        City = "Gotham",
        Country = "USA",
        Email = "jane.smith@example.com",
        Phone = "234-567-8901",
        CellularPhone = "876-543-2109",
        Blocked = false
    }
            });
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
            _basketsTradeInfoDtos.Add(_basketId, new BasketTradeInfoDto()
            {
                Turnover = new Field<List<BasketTurnoverLineDto?>>
                {
                    Name = "Turnover Lines",
                    Status = "Active",
                    Type = "List<BasketTurnoverLineDto>",
                    Value = new List<BasketTurnoverLineDto?>
        {
            new BasketTurnoverLineDto
            {
                Name = "Q1 2024",
                Ytd = "10000",
                YtdN1 = "9500",
                N1 = "2500",
                N2 = "3000"
            },
            new BasketTurnoverLineDto
            {
                Name = "Q2 2024",
                Ytd = "15000",
                YtdN1 = "14000",
                N1 = "3500",
                N2 = "4000"
            }
        },
                    ProcedureCall = new List<string?> { "TurnoverProcedure" },
                    Error = null,
                    Description = "List of turnover lines for the basket",
                    Url = null
                },
                Contract = new BasketContractInfoDto
                {
                    ContractId = new Field<string>
                    {
                        Name = "Contract ID",
                        Status = "Active",
                        Type = "String",
                        Value = "C123456",
                        ProcedureCall = new List<string?> { "ContractIdProcedure" },
                        Error = null,
                        Description = "Unique identifier for the contract",
                        Url = null
                    },
                    ContractType = new Field<string>
                    {
                        Name = "Contract Type",
                        Status = "Active",
                        Type = "String",
                        Value = "Service",
                        ProcedureCall = new List<string?> { "ContractTypeProcedure" },
                        Error = null,
                        Description = "Type of the contract",
                        Url = null
                    },
                    ContractGroup = new Field<string>
                    {
                        Name = "Contract Group",
                        Status = "Active",
                        Type = "String",
                        Value = "Premium",
                        ProcedureCall = new List<string?> { "ContractGroupProcedure" },
                        Error = null,
                        Description = "Group classification of the contract",
                        Url = null
                    },
                    Status = new Field<string>
                    {
                        Name = "Status",
                        Status = "Active",
                        Type = "String",
                        Value = "Active",
                        ProcedureCall = new List<string?> { "StatusProcedure" },
                        Error = null,
                        Description = "Current status of the contract",
                        Url = null
                    },
                    StartDate = new Field<string>
                    {
                        Name = "Start Date",
                        Status = "Active",
                        Type = "String",
                        Value = "2024-01-01",
                        ProcedureCall = new List<string?> { "StartDateProcedure" },
                        Error = null,
                        Description = "Start date of the contract",
                        Url = null
                    },
                    EndDate = new Field<string>
                    {
                        Name = "End Date",
                        Status = "Active",
                        Type = "String",
                        Value = "2024-12-31",
                        ProcedureCall = new List<string?> { "EndDateProcedure" },
                        Error = null,
                        Description = "End date of the contract",
                        Url = null
                    },
                    CampaignId = new Field<string>
                    {
                        Name = "Campaign ID",
                        Status = "Active",
                        Type = "String",
                        Value = "CAM2024",
                        ProcedureCall = new List<string?> { "CampaignIdProcedure" },
                        Error = null,
                        Description = "Identifier for the associated campaign",
                        Url = null
                    },
                    MainContact = new Field<string>
                    {
                        Name = "Main Contact",
                        Status = "Active",
                        Type = "String",
                        Value = "John Doe",
                        ProcedureCall = new List<string?> { "MainContactProcedure" },
                        Error = null,
                        Description = "Primary contact person for the contract",
                        Url = null
                    },
                    OfficeExecutive = new Field<string>
                    {
                        Name = "Office Executive",
                        Status = "Active",
                        Type = "String",
                        Value = "Jane Smith",
                        ProcedureCall = new List<string?> { "OfficeExecutiveProcedure" },
                        Error = null,
                        Description = "Office executive responsible for the contract",
                        Url = null
                    },
                    DiscountList = new Field<List<string?>>
                    {
                        Name = "Discount List",
                        Status = "Active",
                        Type = "List<string>",
                        Value = new List<string?> { "10% off", "Buy 1 Get 1 Free" },
                        ProcedureCall = new List<string?> { "DiscountListProcedure" },
                        Error = null,
                        Description = "List of discounts applicable to the contract",
                        Url = null
                    }
                }
            });
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
            _basketsPricesInfoDtos.Add(_basketId, new BasketPricesInfoDto()
            {
                // Column 1
                Coupon = new Field<string?>
                {
                    Name = "Coupon",
                    Status = "Active",
                    Type = "String",
                    Value = "SUMMER2024",
                    ProcedureCall = new List<string?> { "CouponProcedure" },
                    Error = null,
                    Description = "Seasonal discount coupon",
                    Url = null
                },
                FreeShippingAmountThreshold = new Field<decimal?>
                {
                    Name = "Free Shipping Threshold",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 50.00m,
                    ProcedureCall = new List<string?> { "FreeShippingAmountThresholdProcedure" },
                    Error = null,
                    Description = "Minimum amount for free shipping",
                    Url = null
                },
                GiftAmountThreshold = new Field<decimal?>
                {
                    Name = "Gift Threshold",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 100.00m,
                    ProcedureCall = new List<string?> { "GiftAmountThresholdProcedure" },
                    Error = null,
                    Description = "Minimum amount for gift eligibility",
                    Url = null
                },
                ProductsInfo = new Field<string?>
                {
                    Name = "Products Info",
                    Status = "Active",
                    Type = "String",
                    Value = "Includes all items in the basket",
                    ProcedureCall = new List<string?> { "ProductsInfoProcedure" },
                    Error = null,
                    Description = "Information about the products",
                    Url = null
                },

                // Column 2
                ProductsNetAmount = new Field<decimal?>
                {
                    Name = "Products Net Amount",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 200.00m,
                    ProcedureCall = new List<string?> { "ProductsNetAmountProcedure" },
                    Error = null,
                    Description = "Net amount of the products",
                    Url = null
                },
                WarrantyCostOption = new Field<string?>
                {
                    Name = "Warranty Cost Option",
                    Status = "Active",
                    Type = "String",
                    Value = "Extended Warranty",
                    ProcedureCall = new List<string?> { "WarrantyCostOptionProcedure" },
                    Error = null,
                    Description = "Option for warranty cost",
                    Url = null
                },
                WarrantyCostAmount = new Field<decimal?>
                {
                    Name = "Warranty Cost Amount",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 20.00m,
                    ProcedureCall = new List<string?> { "WarrantyCostAmountProcedure" },
                    Error = null,
                    Description = "Cost associated with warranty",
                    Url = null
                },
                ShippingCostOption = new Field<string?>
                {
                    Name = "Shipping Cost Option",
                    Status = "Active",
                    Type = "String",
                    Value = "Standard Shipping",
                    ProcedureCall = new List<string?> { "ShippingCostOptionProcedure" },
                    Error = null,
                    Description = "Shipping cost option selected",
                    Url = null
                },
                ShippingCostAmount = new Field<decimal?>
                {
                    Name = "Shipping Cost Amount",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 10.00m,
                    ProcedureCall = new List<string?> { "ShippingCostAmountProcedure" },
                    Error = null,
                    Description = "Amount for shipping cost",
                    Url = null
                },
                LogisticInfo = new Field<string?>
                {
                    Name = "Logistic Info",
                    Status = "Active",
                    Type = "String",
                    Value = "Shipped via courier",
                    ProcedureCall = new List<string?> { "LogisticInfoProcedure" },
                    Error = null,
                    Description = "Logistics information for the shipment",
                    Url = null
                },

                // Column 3
                TotalNetAmount = new Field<decimal?>
                {
                    Name = "Total Net Amount",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 200.00m,
                    ProcedureCall = new List<string?> { "TotalNetAmountProcedure" },
                    Error = null,
                    Description = "Total net amount after discounts",
                    Url = null
                },
                VatAmount = new Field<decimal?>
                {
                    Name = "VAT Amount",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 40.00m,
                    ProcedureCall = new List<string?> { "VatAmountProcedure" },
                    Error = null,
                    Description = "VAT amount for the order",
                    Url = null
                },
                TotalGrossAmount = new Field<decimal?>
                {
                    Name = "Total Gross Amount",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 250.00m,
                    ProcedureCall = new List<string?> { "TotalGrossAmountProcedure" },
                    Error = null,
                    Description = "Total amount including VAT",
                    Url = null
                },
                FirstDeliveryDate = new Field<string?>
                {
                    Name = "First Delivery Date",
                    Status = "Active",
                    Type = "String",
                    Value = "2024-08-15",
                    ProcedureCall = new List<string?> { "FirstDeliveryDateProcedure" },
                    Error = null,
                    Description = "First expected delivery date",
                    Url = null
                },
                LastDeliveryDate = new Field<string?>
                {
                    Name = "Last Delivery Date",
                    Status = "Active",
                    Type = "String",
                    Value = "2024-08-20",
                    ProcedureCall = new List<string?> { "LastDeliveryDateProcedure" },
                    Error = null,
                    Description = "Last expected delivery date",
                    Url = null
                },

                // Column 4
                OrderDiscountRate = new Field<int?>
                {
                    Name = "Order Discount Rate",
                    Status = "Active",
                    Type = "Int",
                    Value = 10,
                    ProcedureCall = new List<string?> { "OrderDiscountRateProcedure" },
                    Error = null,
                    Description = "Discount rate applied to the order",
                    Url = null
                },
                OrderLastColumnDiscount = new Field<bool?>
                {
                    Name = "Order Last Column Discount",
                    Status = "Active",
                    Type = "Bool",
                    Value = true,
                    ProcedureCall = new List<string?> { "OrderLastColumnDiscountProcedure" },
                    Error = null,
                    Description = "Indicates if a discount is applied to the last column",
                    Url = null
                },
                DiscountAmount = new Field<decimal?>
                {
                    Name = "Discount Amount",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 25.00m,
                    ProcedureCall = new List<string?> { "DiscountAmountProcedure" },
                    Error = null,
                    Description = "Total discount amount applied",
                    Url = null
                },
                AdditionalSalesAmount = new Field<decimal?>
                {
                    Name = "Additional Sales Amount",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 15.00m,
                    ProcedureCall = new List<string?> { "AdditionalSalesAmountProcedure" },
                    Error = null,
                    Description = "Additional amount from sales",
                    Url = null
                },
                TotalWeight = new Field<decimal?>
                {
                    Name = "Total Weight",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 5.00m,
                    ProcedureCall = new List<string?> { "TotalWeightProcedure" },
                    Error = null,
                    Description = "Total weight of the items",
                    Url = null
                },
                TotalVolume = new Field<decimal?>
                {
                    Name = "Total Volume",
                    Status = "Active",
                    Type = "Decimal",
                    Value = 0.50m,
                    ProcedureCall = new List<string?> { "TotalVolumeProcedure" },
                    Error = null,
                    Description = "Total volume of the items",
                    Url = null
                }
            });
            _basketsPricesInfoDtos.Add("P0130140", SampleData.pricesInfoP0130140);
            _basketsPricesInfoDtos.Add("P0130512", SampleData.pricesInfoP0130512);
            _basketsPricesInfoDtos.Add("P0130863", SampleData.pricesInfoP0130863);
            _basketsPricesInfoDtos.Add("P0130652", SampleData.pricesInfoP0130652);
        }
        private static void SeedBasketCouponsData()
        {
            _basketsCoupons.Clear();
            _basketsCoupons.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
            _basketsCoupons.Add("P0130140", SampleData.couponsP0130140);
            _basketsCoupons.Add("P0130512", SampleData.couponsP0130512);
            _basketsCoupons.Add("P0130863", SampleData.couponsP0130863);
            _basketsCoupons.Add("P0130652", SampleData.couponsP0130652);
        }
        private static void SeedBasketWarrantyCostOptionsData()
        {
            _basketsWarrantyCostOptions.Clear();
            _basketsWarrantyCostOptions.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
            _basketsWarrantyCostOptions.Add("P0130140", SampleData.warrantyCostOptionsP0130140);
            _basketsWarrantyCostOptions.Add("P0130512", SampleData.warrantyCostOptionsP0130512);
            _basketsWarrantyCostOptions.Add("P0130863", SampleData.warrantyCostOptionsP0130863);
            _basketsWarrantyCostOptions.Add("P0130652", SampleData.warrantyCostOptionsP0130652);
        }
        private static void SeedBasketShippingCostOptionsData()
        {
            _basketsShippingCostOptions.Clear();
            _basketsShippingCostOptions.Add(_basketId, new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "Discount",
        Value = "10%"
    },
    new BasketValueDto
    {
        Description = "Shipping Cost",
        Value = "$5.99"
    },
    new BasketValueDto
    {
        Description = "Total",
        Value = "$100.00"
    },
    null // Example of a nullable BasketValueDto
            });
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
            _basketsProcedureCall.Add(_basketId, new ProcedureCallResponseDto()
            {
                Success = true,
                Message = "Procedure completed successfully.",
                ErrorCause = null,
                UpdateDone = true,
                RefreshCalls = new List<string?> { "Call1", "Call2", null }
            });
            _basketsProcedureCall.Add("P0130140", SampleData.procedureCallResponseP0130140_3);
            _basketsProcedureCall.Add("P0130512", SampleData.procedureCallResponseP0130512_3);
            _basketsProcedureCall.Add("P0130863", SampleData.procedureCallResponseP0130863_3);
            _basketsProcedureCall.Add("P0130652", SampleData.procedureCallResponseP0130652_3);
        }







    }

}





