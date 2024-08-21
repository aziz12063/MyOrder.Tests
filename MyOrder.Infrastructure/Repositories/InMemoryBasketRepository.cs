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
                OrderId = "P0131323",
                OrderStatus = "Annulé",
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
                Account = new Field<AccountDto?>
                {
                    Name = "Compte commandeur",
                    Status = "onlyForDisplay",
                    Value = new AccountDto
                    {
                        AccountId = "92156594",
                        Name = "CHRONOPOST SAS",
                        Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
                        Building = "CC211093",
                        Street = "3 BOULEVARD ROMAIN ROLLAND",
                        Locality = "",
                        ZipCode = "75680",
                        City = "PARIS CEDEX 14",
                        Country = "FRANCE",
                        Email = "raja1234@raja.fr",
                        Phone = "0120281279",
                        CellularPhone = "0120281279",
                        Blocked = false
                    }
                },
                Contact = new Field<ContactDto?>
                {
                    Name = "Contact commandeur",
                    Status = "readWrite",
                    Value = new ContactDto
                    {
                        ContactId = "I4035878",
                        SocialTitle = "Mme",
                        FirstName = "SANDRA",
                        LastName = "TRABOUILLET",
                        Email = "raja1234@raja.fr",
                        Phone = "0120281279",
                        CellularPhone = "0120281279"
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
                    Value = "Messagerie, fret express",
                    Description = "Code NAF: 5229A"
                },
                CustomerTags = new List<BasketValueDto?>
    {
        new BasketValueDto
        {
            Description = "Client VIP",
            Value = "vip"
        },
        new BasketValueDto
        {
            Description = "Pas de cadeaux",
            Value = "noGift"
        }
    },
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
                    Value = "LIE - Commande liée",
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
                    Value = "23/07/2024",
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
                    Status = "required",
                    Error = "Le numéro de commmande web est obligatoire",
                    Value = "",
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
                    Value = ""
                },
                Note = new Field<string>
                {
                    Name = "Note de RC",
                    Status = "onlyForDisplay",
                    Value = "29/10/2019 ******A TRAITER PAR L'EQUIPE VIP*******LORS DE LA SAISIE DES COMMANDES LE COMPTE D IMPUTATION ET LE NUMERO DE COMMANDE SONT OBLIGATOIRES 03/11/2022  SGR ATTENTION  SUR ORDRE DE MR ARINO NE PAS NOTER DANS LE NO DE CDE  BDC-  MAIS JUSTE LA SUITE CAR SINON NE VOIT PAS LES NUMEROS EN ENTIERS,"
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
        ContactId = "",
        SocialTitle = null,
        FirstName = null,
        LastName = "-- Aucun contact renseigné --",
        Email = null,
        Phone = null,
        CellularPhone = null
    },
    new ContactDto
    {
        ContactId = "I3116630",
        SocialTitle = "Mme",
        FirstName = "BELINDA",
        LastName = "ABDESSADOK",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I4128716",
        SocialTitle = "M.",
        FirstName = "HICHAM",
        LastName = "AIT ERRAMI",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I4325190",
        SocialTitle = "Mme",
        FirstName = "MARGOT",
        LastName = "ALAIN",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "X2561976",
        SocialTitle = "Mme",
        FirstName = "LOUESSARD",
        LastName = "ALICIA",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I0815740",
        SocialTitle = "M.",
        FirstName = "PASCAL",
        LastName = "ALLARD",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I1808036",
        SocialTitle = "Mme",
        FirstName = "SEVERINE",
        LastName = "ANDREU",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I4170846",
        SocialTitle = "M.",
        FirstName = "",
        LastName = "ARINO",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    }
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
        Description = "Client VIP",
        Value = "vip"
    },
    new BasketValueDto
    {
        Description = "Préparation spéciale",
        Value = "specialPrep"
    },
    new BasketValueDto
    {
        Description = "Client Export",
        Value = "export"
    },
    new BasketValueDto
    {
        Description = "Pas de cadeaux",
        Value = "noGift"
    },
    new BasketValueDto
    {
        Description = "Livraison complète",
        Value = "completeDelivery"
    }
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
        Value = ""
    },
    new SalesOriginDto
    {
        Value = "Téléphone"
    },
    new SalesOriginDto
    {
        Value = "E-mail"
    },
    new SalesOriginDto
    {
        Value = "Fax"
    },
    new SalesOriginDto
    {
        Value = "Courrier"
    },
    new SalesOriginDto
    {
        Value = "Comptoir"
    },
    new SalesOriginDto
    {
        Value = "Chat"
    },
    new SalesOriginDto
    {
        Value = "E-Proc"
    },
    new SalesOriginDto
    {
        Value = "Sortant"
    },
    new SalesOriginDto
    {
        Value = "Internet"
    },
    new SalesOriginDto
    {
        Value = "Auto"
    },
    new SalesOriginDto
    {
        Value = "EDI"
    },
    new SalesOriginDto
    {
        Value = "Terrain"
    },
    new SalesOriginDto
    {
        Value = "Interne"
    }
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
                 new BasketValueDto { Value = "" },
    new BasketValueDto { Value = "3M" },
    new BasketValueDto { Value = "Air Liquide" },
    new BasketValueDto { Value = "AIRBUS" },
    new BasketValueDto { Value = "ALSTOM" },
    new BasketValueDto { Value = "AMAZON" },
    new BasketValueDto { Value = "ARIBA" },
    new BasketValueDto { Value = "BIRCHSTREET" },
    new BasketValueDto { Value = "BOSCH" },
    new BasketValueDto { Value = "BURBERRY" },
    new BasketValueDto { Value = "BUT" },
    new BasketValueDto { Value = "Catalogue" },
    new BasketValueDto { Value = "CEVA" },
    new BasketValueDto { Value = "CHRHANSEN" },
    new BasketValueDto { Value = "COUPA" },
    new BasketValueDto { Value = "COUPAAdvantage" },
    new BasketValueDto { Value = "CPO" },
    new BasketValueDto { Value = "CPOSolution" },
    new BasketValueDto { Value = "DAHER" },
    new BasketValueDto { Value = "DBSCHENKER" },
    new BasketValueDto { Value = "DECATHLON" },
    new BasketValueDto { Value = "DESKTOP" },
    new BasketValueDto { Value = "DETERMINE" },
    new BasketValueDto { Value = "DFS" },
    new BasketValueDto { Value = "EBAY" }
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
        Value = null
    },
    new BasketValueDto
    {
        Description = "Commande normale",
        Value = "NOR"
    },
    new BasketValueDto
    {
        Description = "Commande liée",
        Value = "LIE"
    },
    new BasketValueDto
    {
        Description = "Commande d'échantillons",
        Value = "ECH"
    }
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
                    Name = "Compte de livraison",
                    Status = "readWrite",                    
                    Value = new AccountDto
                    {
                        AccountId = "C0789324",
                        Name = "CHRONOPOST AGENCE DE RENNES",
                        Recipient = "0211135",
                        Building = "P A LE GRAND RIGNE",
                        Street = "1 RUE DE LA MAISON NEUVE",
                        Locality = "",
                        ZipCode = "35830",
                        City = "BETTON",
                        Country = "FRANCE",
                        Email = "raja1234@raja.fr",
                        Phone = "0120281279",
                        CellularPhone = "0120281279",
                        Blocked = false
                    },
                    ProcedureCall = new List<string?> { "UpdateCustomer", "DeliverTo", "<one of /deliverToAccounts accountId>" }
                   
                },
                Contact = new Field<ContactDto>
                {
                    Name = "Contact de livraison",
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
                    ProcedureCall = new List<string?> { "UpdateContact", "DeliverTo", "<one of /deliverToContacts contactId>" }
                    
                },
                DeliveryMode = new Field<string>
                {
                    Name = "Mode de livraison",
                    Status = "readWrite",
                    Type = "String",
                    Value = "Catalogue",
                    ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "RAJ_GenericDlvMode", "System.String", "<one of /deliveryModes value>" }
                    
                },
                CompleteDelivery = new Field<bool>
                {
                    Name = "Livraison complète",
                    Status = "readWrite",
                    Type = "Boolean",
                    Value = false
                   
                },
                ImperativeDate = new Field<string>
                {
                    Name = "Date impérative",
                    Status = "required",                   
                    Value = null,
                    ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "RAJ_ImperativeDate", "DateTime", "<value>" }
                    
                },
                OrderDocuments = new Field<List<string?>>
                {
                    Name = "BL / Factures",
                    Status = "hidden",
                    Value = new List<string?>()
                    
                },
                Note = new Field<string>
                {
                    Name = "Note de livraison",
                    Status = "readWrite",                    
                    Value = "",
                    ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "DeliveryNote", "System.DateTime", "<value>" }
                    
                },
                NoteMustBeSaved = new Field<bool>
                {
                    Name = "Sauvegarde note de liv.",
                    Status = "readWrite",                    
                    Value = true,
                    ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "IsDeliveryNoteSaved", "System.Boolean", "<value>" }
                    
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
        AccountId = "",
        Name = "-- Aucune adresse renseignée --",
        Recipient = null,
        Building = null,
        Street = "-- Aucune adresse renseignée --",
        Locality = null,
        ZipCode = null,
        City = null,
        Country = null,
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "92156594",
        Name = "CHRONOPOST SAS",
        Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
        Building = "CC211093",
        Street = "3 BOULEVARD ROMAIN ROLLAND",
        Locality = "",
        ZipCode = "75680",
        City = "PARIS CEDEX 14",
        Country = "FRANCE",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057721",
        Name = "CHRONOPOST SAS",
        Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
        Building = "",
        Street = "3 BOULEVARD ROMAIN ROLLAND",
        Locality = "",
        ZipCode = "75014",
        City = "PARIS",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057729",
        Name = "CHRONOPOST SAS HUB CHRONOPOST",
        Recipient = "CC 211296",
        Building = "CARGO 9",
        Street = "9 RUE DU HAUT DE LAVAL",
        Locality = "",
        ZipCode = "95700",
        City = "ROISSY EN FRANCE",
        Country = "DANEMARK",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057728",
        Name = "CHRONOPOST VILLENEUVE",
        Recipient = "CC 211192",
        Building = "",
        Street = "155 BOULEVARD CHARLES DE GAULLE",
        Locality = "",
        ZipCode = "92390",
        City = "VILLENEUVE LA GARENNE",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057723",
        Name = "CHRONOPOST",
        Recipient = "CC 211296",
        Building = "CARGO 7",
        Street = "9 RUE DU HAUT DE LAVAL",
        Locality = "",
        ZipCode = "95700",
        City = "ROISSY CHARLES DE GAULLE",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    }
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
        ContactId = "",
        SocialTitle = null,
        FirstName = null,
        LastName = "-- Aucun contact renseigné --",
        Email = null,
        Phone = null,
        CellularPhone = null
    },
    new ContactDto
    {
        ContactId = "I3789634",
        SocialTitle = "Mme",
        FirstName = "KARINE",
        LastName = "DUROCHER",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I4041155",
        SocialTitle = "Mme",
        FirstName = "GWENOLA",
        LastName = "HORVAIS",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    }
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
        Value = "Catalogue"
    },
    new BasketValueDto
    {
        Value = "Enlèvement"
    },
    new BasketValueDto
    {
        Value = "Express"
    },
    new BasketValueDto
    {
        Value = "Filiale"
    },
    new BasketValueDto
    {
        Value = "Interne"
    },
    new BasketValueDto
    {
        Value = "Normal"
    },
    new BasketValueDto
    {
        Value = "VCT"
    }
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
                    Name = "Compte de facturation",
                    Status = "readWrite",
                    Value = new AccountDto
                    {
                        AccountId = "92156594",
                        Name = "CHRONOPOST SAS",
                        Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
                        Building = "CC211093",
                        Street = "3 BOULEVARD ROMAIN ROLLAND",
                        Locality = "",
                        ZipCode = "75680",
                        City = "PARIS CEDEX 14",
                        Country = "FRANCE",
                        Email = "raja1234@raja.fr",
                        Phone = "0120281279",
                        CellularPhone = "0120281279",
                        Blocked = false
                    },
                    ProcedureCall = new List<string?>
        {
            "UpdateCustomer",
            "InvoiceTo",
            "<one of /invoiceToAccounts accountId>"
        }
                    
                },
                SiretId = new Field<string>
                {
                    Name = "Siret",
                    Status = "onlyForDisplay",
                    Value = "38396013502628"
                    
                },
                TaxGroup = new Field<string>
                {
                    Name = "Groupe de taxe",
                    Status = "readWrite",
                    Value = "F-DEB",
                    ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "TaxGroup",
            "System.String",
            "<value>"
        }
                },
                PaymentTerm = new Field<string>
                {
                    Name = "Conditions de paiement",
                    Status = "onlyForDisplay",
                    Value = "FDM45"
                    
                },
                PaymentMode = new Field<string>
                {
                    Name = "Mode de paiement",
                    Status = "readWrite",
                    Value = "VB",
                    ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "PaymMode",
            "System.String",
            "<value>"
        }
                   
                },
                IsPublicEntity = false,
                PublicEntityExecutingService = new Field<string>
                {
                    Name = "Service exécutif",
                    Status = "readOnly",
                    Value = null
                },
                PublicEntityLegalCommitment = new Field<string>
                {
                    Name = "Engagement juridique",
                    Status = "readOnly",
                    Value = null
                },
                Note = new Field<string>
                {
                    Name = null,
                    Status = "onlyForDisplay",
                    Type = "String",
                    Value = null
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
        Description = null,
        Value = ""
    },
    new BasketValueDto
    {
        Description = "France Autoliquidation",
        Value = "F-AUTOLIQ"
    },
    new BasketValueDto
    {
        Description = "France TVA sur les débits",
        Value = "F-DEB"
    },
    new BasketValueDto
    {
        Description = "France TVA sur les débits Escompte",
        Value = "F-DEBTVA"
    },
    new BasketValueDto
    {
        Description = "France TVA sur les encaissements",
        Value = "F-ENC"
    },
    new BasketValueDto
    {
        Description = "France TVA sur les encaissements Escompte",
        Value = "F-ENCTVA"
    },
    new BasketValueDto
    {
        Description = "France exonéré",
        Value = "F-EXO"
    },
    new BasketValueDto
    {
        Description = "TVA sur factures à émettre",
        Value = "F-FAE"
    },
    new BasketValueDto
    {
        Description = "France SMICTOM TVA 7%",
        Value = "F-SMI"
    },
    new BasketValueDto
    {
        Description = "Tiers hors UE vente",
        Value = "HUE"
    },
    new BasketValueDto
    {
        Description = "Tiers Hors UE achat",
        Value = "HUE-AC"
    },
    new BasketValueDto
    {
        Description = "Monaco TVA sur les débits",
        Value = "M-DEB"
    },
    new BasketValueDto
    {
        Description = "Monaco EXONERE (Attestation)",
        Value = "M-EXO"
    },
    new BasketValueDto
    {
        Description = "TVA union européenne achat",
        Value = "UE-AC"
    },
    new BasketValueDto
    {
        Description = "TVA union européenne vente",
        Value = "UE-VE"
    },
    new BasketValueDto
    {
        Description = "TVA FNP à régulariser",
        Value = "ZF-FNP"
    }
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
        Description = null,
        Value = ""
    },
    new BasketValueDto
    {
        Description = "Carte Bancaire",
        Value = "CB"
    },
    new BasketValueDto
    {
        Description = "Chèque",
        Value = "CH"
    },
    new BasketValueDto
    {
        Description = "Paypal",
        Value = "PAYPAL"
    },
    new BasketValueDto
    {
        Description = "Préautorisation CB",
        Value = "PCB"
    },
    new BasketValueDto
    {
        Description = "Carte Bancaire Manuelle",
        Value = "TPE"
    },
    new BasketValueDto
    {
        Description = "Virement Bancaire",
        Value = "VB"
    },
    new BasketValueDto
    {
        Description = "Virement Marketplace La Poste",
        Value = "VMP"
    },
    new BasketValueDto
    {
        Description = "Préautorisation CB manuelle",
        Value = "ZCB"
    },
    new BasketValueDto
    {
        Description = "Paypal sur Ebay",
        Value = "ZEBAY"
    },
    new BasketValueDto
    {
        Description = "Préautorisation PC manuelle",
        Value = "ZPC"
    },
    new BasketValueDto
    {
        Description = "Préautorisation Paypal manuelle",
        Value = "ZPY"
    }
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
        AccountId = "",
        Name = "-- Aucune adresse renseignée --",
        Recipient = null,
        Building = null,
        Street = "-- Aucune adresse renseignée --",
        Locality = null,
        ZipCode = null,
        City = null,
        Country = null,
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "92156594",
        Name = "CHRONOPOST SAS",
        Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
        Building = "CC211093",
        Street = "3 BOULEVARD ROMAIN ROLLAND",
        Locality = "",
        ZipCode = "75680",
        City = "PARIS CEDEX 14",
        Country = "FRANCE",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
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
                    Name = "Chiffre d'affaire",
                    Status = "onlyForDisplay",
                    Type = "List<BasketTurnoverLineDto>",
                    Value = new List<BasketTurnoverLineDto?>
                    {
                        new BasketTurnoverLineDto
            {
                Name = "Classe",
                Ytd = "16",
                YtdN1 = "",
                N1 = "16",
                N2 = "16"
            },
                        new BasketTurnoverLineDto
            {
                Name = "CA.",
                Ytd = "267 606 €",
                YtdN1 = "214 342 €",
                N1 = "790 128 €",
                N2 = "657 368 €"
            },
                        new BasketTurnoverLineDto
            {
                Name = "Evol. CA.",
                Ytd = "24,85 %",
                YtdN1 = "",
                N1 = "",
                N2 = ""
            }
                },
                    
                },
                Contract = new BasketContractInfoDto
                {
                    ContractId = new Field<string>
                    {
                        Name = "Contrat",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = "CT072408"

                    },
                    ContractType = new Field<string>
                    {
                        Name = "Type",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = "Conditions Spéciales"

                    },
                    ContractGroup = new Field<string>
                    {
                        Name = "Groupe de contrat",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = "CHRONOPOST SA"
                    },
                    Status = new Field<string>
                    {
                        Name = "Statut",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = "En cours"
                    },
                    StartDate = new Field<string>
                    {
                        Name = "Date de début",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = "2024-04-08 00:00:00"
                    },
                    EndDate = new Field<string>
                    {
                        Name = "Date de fin",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = "2024-08-31 00:00:00"
                    },
                    CampaignId = new Field<string>
                    {
                        Name = "Campagne de prix",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = null
                    },
                    MainContact = new Field<string>
                    {
                        Name = "Commercial terrain",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = "ISABELLE LASNIER"
                    },
                    OfficeExecutive = new Field<string>
                    {
                        Name = "Commercial sédentaire",
                        Status = "onlyForDisplay",
                        Type = "String",
                        Value = "CHRISTELLE BERNIER"
                    },
                    DiscountList = new Field<List<string?>>
                    {
                        Name = "Description",
                        Status = "onlyForDisplay",
                        Type = "List<string>",
                        Value = new List<string?> { "Prix nets sur 49 article(s)", "10% DC sur tout le catalogue" }
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
                    Name = "Code Action",
                    Status = "readWrite",
                    Type = "String",
                    Value = "G032400",
                    ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "CampaignId",
            "System.String",
            "<one of /coupons value>"
        }
                },
                FreeShippingAmountThreshold = new Field<decimal?>
                {
                    Name = "Diff Franco",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = null
                },
                GiftAmountThreshold = new Field<decimal?>
                {
                    Name = "Diff KDO",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = null
                },
                ProductsInfo = new Field<string?>
                {
                    Name = "Dispo. Marchandise",
                    Status = "onlyForDisplay",
                    Type = "String",
                    Value = "78% en stock / Liv. Multiple"
                },

                // Column 2
                ProductsNetAmount = new Field<decimal?>
                {
                    Name = "Marchandise HT",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 77.00m
                },
                WarrantyCostOption = new Field<string?>
                {
                    Name = "Type de garantie optimale",
                    Status = "readWrite",
                    Type = "String",
                    Value = "Disabled",
                    ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "WarrantyMode",
            "System.String",
            "<one of /warrantyCostOptions value>"
        }
                },
                WarrantyCostAmount = new Field<decimal?>
                {
                    Name = "Montant de la garantie optimale",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 0.00m
                },
                ShippingCostOption = new Field<string?>
                {
                    Name = "Type de frais de port",
                    Status = "readWrite",
                    Type = "String",
                    Value = "Disabled",
                    ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "DeliveryFeeMode",
            "System.String",
            "<one of /shippingCostOptions value>"
        }
                },
                ShippingCostAmount = new Field<decimal?>
                {
                    Name = "Montant des frais de port",
                    Status = "readWrite",
                    Type = "Decimal",
                    Value = 0.00m,
                    ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "DeliveryAmount",
            "System.Double",
            "<value>"
        }
                },
                LogisticInfo = null,

                // Column 3
                TotalNetAmount = new Field<decimal?>
                {
                    Name = "Montant Total HT",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 77.00m
                },
                VatAmount = new Field<decimal?>
                {
                    Name = "Montant TVA",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 15.40m
                },
                TotalGrossAmount = new Field<decimal?>
                {
                    Name = "Montant TTC",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 92.40m
                },
                FirstDeliveryDate = new Field<string?>
                {
                    Name = "Première date de livraison",
                    Status = "onlyForDisplay",
                    Type = "String",
                    Value = "2024-08-20 00:00:00"
                },
                LastDeliveryDate = new Field<string?>
                {
                    Name = "Dernière date de livraison",
                    Status = "onlyForDisplay",
                    Type = "String",
                    Value = "2024-08-30 00:00:00"
                },

                // Column 4
                OrderDiscountRate = new Field<int?>
                {
                    Name = "Remise Cde (%)",
                    Status = "readWrite",
                    Type = "Int",
                    Value = 0,
                    ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "MyDiscountPercent",
            "System.Int32",
            "<value>"
        }
                },
                OrderLastColumnDiscount = new Field<bool?>
                {
                    Name = "Remise Cde DC",
                    Status = "readWrite",
                    Type = "Bool",
                    Value = true,
                    ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "MyLastColumnDiscount",
            "System.Boolean",
            "<value>"
        }
                },
                DiscountAmount = new Field<decimal?>
                {
                    Name = "Remise Cde (€)",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 0.00m
                },
                AdditionalSalesAmount = new Field<decimal?>
                {
                    Name = "Ventes add. (€)",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 0.00m
                },
                TotalWeight = new Field<decimal?>
                {
                    Name = "Poids (kg)",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 12.67m
                },
                TotalVolume = new Field<decimal?>
                {
                    Name = "Volume (m3)",
                    Status = "onlyForDisplay",
                    Type = "Decimal",
                    Value = 0.095m
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
        Description = "COMMANDES nefab 2010\nCODE PAR DEFAUT\nVALIDITE INDETERMINEE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis",
        Value = "AC0100"
    },
    new BasketValueDto
    {
        Description = "COMMANDES AIRBUS 2011-2012\nCODE PAR DEFAUT\nVALIDITE INDETERMINE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis",
        Value = "AIRBUS"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 200 EUROS : CADEAU COFFRET LA MERE POULARD\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "BISCUITS830"
    },
    new BasketValueDto
    {
        Description = "DEMANDES DE CATALOGUES",
        Value = "CAT24"
    },
    new BasketValueDto
    {
        Description = "DEMANDES DE CATALOGUES CLIENTS",
        Value = "CATC24"
    },
    new BasketValueDto
    {
        Description = "DEMANDES DE CATALOGUES PROSPECTS",
        Value = "CATP24"
    },
    new BasketValueDto
    {
        Description = "Validité au 31/12/2024\nAucun cadeau\nPas de welcome pack",
        Value = "CRC24R"
    },
    new BasketValueDto
    {
        Description = "DEMANDES DE CATALOGUES PROSPECTS",
        Value = "ECATP24"
    },
    new BasketValueDto
    {
        Description = "DEMANDES D'ECHANTILLONS CLIENTS",
        Value = "ECHC24"
    },
    new BasketValueDto
    {
        Description = "DEMANDES D'ECHANTILLONS PROSPECTS",
        Value = "ECHP24"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 400 EUROS : CADEAU APPAREIL FONDUE\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "FONDUE172"
    },
    new BasketValueDto
    {
        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024",
        Value = "G032400"
    },
    new BasketValueDto
    {
        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024",
        Value = "G032401"
    },
    new BasketValueDto
    {
        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024",
        Value = "G032408"
    },
    new BasketValueDto
    {
        Description = "TARIFS FILIALES MARS 24\nVALIDITE AU 31/08/2024",
        Value = "Y032400"
    }
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
        Description = "GO non dispo.",
        Value = "10Disabled"
    }
    
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
        Description = "Frais de livraison",
        Value = "Standard"
    },
    new BasketValueDto
    {
        Description = "Frais de liv. offerts",
        Value = "Offered"
    }
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
                RefreshCalls = new List<string?> { "generalInfo", "pricesInfo", "invoiceInfo" }
            });
            _basketsProcedureCall.Add("P0130140", SampleData.procedureCallResponseP0130140_3);
            _basketsProcedureCall.Add("P0130512", SampleData.procedureCallResponseP0130512_3);
            _basketsProcedureCall.Add("P0130863", SampleData.procedureCallResponseP0130863_3);
            _basketsProcedureCall.Add("P0130652", SampleData.procedureCallResponseP0130652_3);
        }







    }

}





