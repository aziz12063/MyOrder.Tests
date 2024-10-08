//using MyOrder.Shared.Dtos;
//using MyOrder.Shared.Dtos.Lines;
//using MyOrder.Shared.Dtos.SharedComponents;
//using Newtonsoft.Json.Linq;

//namespace MyOrder.Infrastructure.Data
//{
//    public static class SampleData
//    {
//        // P0130938

//        //api/orderContext/P0130938/generalInfo   P0130938
//        public static BasketGeneralInfoDto generalInfoP0130938 = new()
//        {
//            PageTitle = "Title",
//            OrderType = "Panier",
//            BasketId = "P0130938",
//            OrderId = "P0131323",
//            OrderStatus = "Annulé",
//            OrderDate = "2024-07-15 17:04:31",
//            SalesResponsible = "CEDRIC REVILLON"
//        };

//        public static List<BasketNotificationDto> NotificationP0130938 = new()
//        {
//            new BasketNotificationDto
//                    {
//                 NotificationId = 1,
//                 Severity = "Info",
//                 Message = "<strong>[Commande]</strong> Notes de commande: INDIQUER LE NOM DU DESTINATAIRE 0CA 14H50 18/01/16",
//                 CreatedDate = new DateTime(1, 1, 1, 0, 0, 0),
//                 ProcedureCall = new List<string?> { "RemoveLog", "1" }
//                 },
//                new BasketNotificationDto
//                {
//                    NotificationId = 2,
//                    Severity = "Warning",
//                    Message = "<strong>[Stock]</strong> Low stock warning for item XYZ123",
//                 CreatedDate = new DateTime(2024, 9, 1, 9, 30, 0),
//                 ProcedureCall = new List<string?> { "UpdateStock", "2" }
//                }

//        };


//        //orderInfo   P0130938
//        public static BasketOrderInfoDto orderInfoP0130938 = new BasketOrderInfoDto()
//        {
//            PanelLabel ="panel label",
//            ContactSection = " contact section",
//            InformationSectionLabel = "information section label",
//            Account = new Field<AccountDto?>
//            {
//                Name = "Compte commandeur",
//                Status = "onlyForDisplay",
//                Value = new AccountDto
//                {
//                    AccountId = "92156594",
//                    Name = "CHRONOPOST SAS",
//                    Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
//                    Building = "CC211093",
//                    Street = "3 BOULEVARD ROMAIN ROLLAND",
//                    Locality = "",
//                    ZipCode = "75680",
//                    City = "PARIS CEDEX 14",
//                    Country = "FRANCE",
//                    Email = "raja1234@raja.fr",
//                    Phone = "0120281279",
//                    CellularPhone = "0120281279",
//                    Blocked = false
//                }
//            },
//            Contact = new Field<ContactDto?>
//            {
//                Name = "Contact commandeur",
//                Status = "readWrite",
//                Value = new ContactDto
//                {
//                    ContactId = "I4035878",
//                    SocialTitle = "Mme",
//                    FirstName = "SANDRA",
//                    LastName = "TRABOUILLET",
//                    Email = "raja1234@raja.fr",
//                    Phone = "0120281279",
//                    CellularPhone = "0120281279"
//                },
//                ProcedureCall = new List<string?>
//                    {
//                        "UpdateContact",
//                        "OrderBy",
//                        "<one of /orderByContacts contactId>"
//                    }
//            },
//            ActivityArea = new Field<string?>
//            {
//                Name = "Secteur d'activité",
//                Status = "onlyForDisplay",
//                Value = "Messagerie, fret express",
//                Description = "Code NAF: 5229A"
//            },
//            CustomerTags = new List<BasketValueDto?>
//    {
//        new BasketValueDto
//        {
//            Description = "Client VIP",
//            Value = "vip"
//        },
//        new BasketValueDto
//        {
//            Description = "Pas de cadeaux",
//            Value = "noGift"
//        }
//    },
//            SalesOriginId = new Field<BasketValueDto?>
//            {
//                Name = "Canal de vente",
//                Status = "readWrite",
//                Value = new BasketValueDto
//                {
//                    Value = "Internet",
//                    Description = "Internet"
//                },
//                ProcedureCall = new List<string?>
//                    {
//                        "UpdateOrderTablePropertyValue",
//                        "SalesOriginId",
//                        "System.String",
//                        "<one of /salesOrigins value>"
//                    }
//            },
//            WebOriginId = new Field<BasketValueDto?>
//            {
//                Name = "Origine e-commerce",
//                Status = "readWrite",
//                Value = new BasketValueDto
//                {
//                    Value = "DESKTOP",
//                    Description = ""
//                },
                
//                ProcedureCall = new List<string?>
//                    {
//                        "UpdateOrderTablePropertyValue",
//                        "RAJ_WebOriginId",
//                        "System.String",
//                        "<one of /webOrigins value>"
//                    }
//            },
//            SalesPoolId = new Field<BasketValueDto?>
//            {
//                Name = "Type de transaction",
//                Status = "readWrite",
//                Value = new BasketValueDto
//                {
//                    Value = "LIE - Commande liée",
//                    Description = ""
//                },
                
//                ProcedureCall = new List<string?>
//                    {
//                        "UpdateOrderTablePropertyValue",
//                        "SalesPoolId",
//                        "System.String",
//                        "<one of /salesPools value>"
//                    }
//            },
//            CustomerOrderRef = new Field<string?>
//            {
//                Name = "Référence Client",
//                Status = "readWrite",
//                Value = "23/07/2024",
//                ProcedureCall = new List<string?>
//                    {
//                        "UpdateOrderTablePropertyValue",
//                        "PurchOrderFormNum",
//                        "System.String",
//                        "<value>"
//                    }
//            },
//            WebSalesId = new Field<string?>
//            {
//                Name = "Commande Web",
//                Status = "required",
//                Error = "Le numéro de commmande web est obligatoire",
//                Value = "",
//                ProcedureCall = new List<string?>
//        {
//            "UpdateOrderTablePropertyValue",
//            "RAJ_WebSalesId",
//            "System.String",
//            "<value>"
//        }
//            },
//            RelatedLink = new Field<string?>
//            {
//                Name = "Devis",
//                Status = "hidden",
//                Value = ""
//            },
//            Note = new Field<string?>
//            {
//                Name = "Note de RC",
//                Status = "onlyForDisplay",
//                Value = "29/10/2019 ******A TRAITER PAR L'EQUIPE VIP*******LORS DE LA SAISIE DES COMMANDES LE COMPTE D IMPUTATION ET LE NUMERO DE COMMANDE SONT OBLIGATOIRES 03/11/2022  SGR ATTENTION  SUR ORDRE DE MR ARINO NE PAS NOTER DANS LE NO DE CDE  BDC-  MAIS JUSTE LA SUITE CAR SINON NE VOIT PAS LES NUMEROS EN ENTIERS,"
//            }
//        };


//        //orderByContacts P0130938
//        public static List<ContactDto?> orderByContactsP0130938 = new List<ContactDto?>()
//            {
//                 new ContactDto
//    {
//        ContactId = "",
//        SocialTitle = null,
//        FirstName = null,
//        LastName = "-- Aucun contact renseigné --",
//        Email = null,
//        Phone = null,
//        CellularPhone = null
//    },
//    new ContactDto
//    {
//        ContactId = "I3116630",
//        SocialTitle = "Mme",
//        FirstName = "BELINDA",
//        LastName = "ABDESSADOK",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    },
//    new ContactDto
//    {
//        ContactId = "I4128716",
//        SocialTitle = "M.",
//        FirstName = "HICHAM",
//        LastName = "AIT ERRAMI",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    },
//    new ContactDto
//    {
//        ContactId = "I4325190",
//        SocialTitle = "Mme",
//        FirstName = "MARGOT",
//        LastName = "ALAIN",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    },
//    new ContactDto
//    {
//        ContactId = "X2561976",
//        SocialTitle = "Mme",
//        FirstName = "LOUESSARD",
//        LastName = "ALICIA",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    },
//    new ContactDto
//    {
//        ContactId = "I0815740",
//        SocialTitle = "M.",
//        FirstName = "PASCAL",
//        LastName = "ALLARD",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    },
//    new ContactDto
//    {
//        ContactId = "I1808036",
//        SocialTitle = "Mme",
//        FirstName = "SEVERINE",
//        LastName = "ANDREU",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    },
//    new ContactDto
//    {
//        ContactId = "I4170846",
//        SocialTitle = "M.",
//        FirstName = "",
//        LastName = "ARINO",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    }
//            };


//        //customerTags P0130938
//        public static List<BasketValueDto?> customerTagsP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto
//    {
//        Description = "Client VIP",
//        Value = "vip"
//    },
//    new BasketValueDto
//    {
//        Description = "Préparation spéciale",
//        Value = "specialPrep"
//    },
//    new BasketValueDto
//    {
//        Description = "Client Export",
//        Value = "export"
//    },
//    new BasketValueDto
//    {
//        Description = "Pas de cadeaux",
//        Value = "noGift"
//    },
//    new BasketValueDto
//    {
//        Description = "Livraison complète",
//        Value = "completeDelivery"
//    }
//            };


//        //salesPools P0130938
//        public static List<BasketValueDto?> salesPoolsP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto
//    {
//        Value = null
//    },
//    new BasketValueDto
//    {
//        Description = "Commande normale",
//        Value = "NOR"
//    },
//    new BasketValueDto
//    {
//        Description = "Commande liée",
//        Value = "LIE"
//    },
//    new BasketValueDto
//    {
//        Description = "Commande d'échantillons",
//        Value = "ECH"
//    }
//            };


//        //salesOrigins P0130938
//        public static List<BasketValueDto?> salesOriginsP0130938 = new List<BasketValueDto?>()
//            {
//                new BasketValueDto
//    {
//        Value = ""
//    },
//    new BasketValueDto
//    {
//        Value = "Téléphone"
//    },
//    new BasketValueDto
//    {
//        Value = "E-mail"
//    },
//    new BasketValueDto
//    {
//        Value = "Fax"
//    },
//    new BasketValueDto
//    {
//        Value = "Courrier"
//    },
//    new BasketValueDto
//    {
//        Value = "Comptoir"
//    },
//    new BasketValueDto
//    {
//        Value = "Chat"
//    },
//    new BasketValueDto
//    {
//        Value = "E-Proc"
//    },
//    new BasketValueDto
//    {
//        Value = "Sortant"
//    },
//    new BasketValueDto
//    {
//        Value = "Internet"
//    },
//    new BasketValueDto
//    {
//        Value = "Auto"
//    },
//    new BasketValueDto
//    {
//        Value = "EDI"
//    },
//    new BasketValueDto
//    {
//        Value = "Terrain"
//    },
//    new BasketValueDto
//    {
//        Value = "Interne"
//    }
//            };


//        //webOrigins P0130938
//        public static List<BasketValueDto?> webOriginsP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto { Value = "" },
//    new BasketValueDto { Value = "3M" },
//    new BasketValueDto { Value = "Air Liquide" },
//    new BasketValueDto { Value = "AIRBUS" },
//    new BasketValueDto { Value = "ALSTOM" },
//    new BasketValueDto { Value = "AMAZON" },
//    new BasketValueDto { Value = "ARIBA" },
//    new BasketValueDto { Value = "BIRCHSTREET" },
//    new BasketValueDto { Value = "BOSCH" },
//    new BasketValueDto { Value = "BURBERRY" },
//    new BasketValueDto { Value = "BUT" },
//    new BasketValueDto { Value = "Catalogue" },
//    new BasketValueDto { Value = "CEVA" },
//    new BasketValueDto { Value = "CHRHANSEN" },
//    new BasketValueDto { Value = "COUPA" },
//    new BasketValueDto { Value = "COUPAAdvantage" },
//    new BasketValueDto { Value = "CPO" },
//    new BasketValueDto { Value = "CPOSolution" },
//    new BasketValueDto { Value = "DAHER" },
//    new BasketValueDto { Value = "DBSCHENKER" },
//    new BasketValueDto { Value = "DECATHLON" },
//    new BasketValueDto { Value = "DESKTOP" },
//    new BasketValueDto { Value = "DETERMINE" },
//    new BasketValueDto { Value = "DFS" },
//    new BasketValueDto { Value = "EBAY" }
//            };


//        //procedureCall => MayLastColumnDiscount = true   P0130938
//        public static ProcedureCallResponseDto procedureCallResponseP0130938_3 = new ProcedureCallResponseDto()
//        {
//            Success = true,
//            Message = "Procedure completed successfully.",
//            ErrorCause = null,
//            UpdateDone = true,
//            RefreshCalls = new List<string?> { "generalInfo", "pricesInfo", "invoiceInfo", "orderInfo", "tradeInfo", "deliveryInfo" }
//        };


//        //deliveryInfo P0130938
//        public static BasketDeliveryInfoDto deliveryInfoP0130938 = new BasketDeliveryInfoDto()
//        {
//            Account = new Field<AccountDto?>
//            {
//                Name = "Compte de livraison",
//                Status = "readWrite",
//                Value = new AccountDto
//                {
//                    AccountId = "C0789324",
//                    Name = "CHRONOPOST AGENCE DE RENNES",
//                    Recipient = "0211135",
//                    Building = "P A LE GRAND RIGNE",
//                    Street = "1 RUE DE LA MAISON NEUVE",
//                    Locality = "",
//                    ZipCode = "35830",
//                    City = "BETTON",
//                    Country = "FRANCE",
//                    Email = "raja1234@raja.fr",
//                    Phone = "0120281279",
//                    CellularPhone = "0120281279",
//                    Blocked = false
//                },
//                ProcedureCall = new List<string?> { "UpdateCustomer", "DeliverTo", "<one of /deliverToAccounts accountId>" }

//            },
//            Contact = new Field<ContactDto?>
//            {
//                Name = "Contact de livraison",
//                Status = "readWrite",
//                Value = new ContactDto
//                {
//                    ContactId = null,
//                    SocialTitle = null,
//                    FirstName = null,
//                    LastName = null,
//                    Email = null,
//                    Phone = null,
//                    CellularPhone = null
//                },
//                ProcedureCall = new List<string?> { "UpdateContact", "DeliverTo", "<one of /deliverToContacts contactId>" }

//            },
//            DeliveryMode = new Field<BasketValueDto?>
//            {
//                Name = "Mode de livraison",
//                Status = "readWrite",
//                Value = new BasketValueDto()
//                {
//                    Value = "Catalogue",
//                    Description = ""
//                },
//                ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "RAJ_GenericDlvMode", "System.String", "<one of /deliveryModes value>" }

//            },
//            CompleteDelivery = new Field<bool?>
//            {
//                Name = "Livraison complète",
//                Status = "readWrite",
//                Value = false

//            },
//            ImperativeDate = new Field<DateTime?>
//            {
//                Name = "Date impérative",
//                Status = "required",
//                Value = DateTime.ParseExact("12/09/2024", "dd/MM/yyyy", null),
//                ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "RAJ_ImperativeDate", "DateTime", "<value>" }

//            },
//            OrderDocuments = new Field<string?>
//            {
//                Name = "BL / Factures",
//                Status = "hidden",
//                Value = ""

//            },
//            Note = new Field<string?>
//            {
//                Name = "Note de livraison",
//                Status = "readWrite",
//                Value = "",
//                ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue",
//                                                    "DeliveryNote",
//                                                    "System.DateTime",
//                                                    "<value>" }
//            },
//            NoteMustBeSaved = new Field<bool?>
//            {
//                Name = "Sauvegarde note de liv.",
//                Status = "readWrite",
//                Value = true,
//                ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "IsDeliveryNoteSaved", "System.Boolean", "<value>" }

//            }
//        };


//        //deliverToAccounts P0130938
//        public static List<AccountDto?> deliverToAccountsP0130938 = new List<AccountDto?>()
//            {
//                new AccountDto
//    {
//        AccountId = "",
//        Name = "-- Aucune adresse renseignée --",
//        Recipient = null,
//        Building = null,
//        Street = "-- Aucune adresse renseignée --",
//        Locality = null,
//        ZipCode = null,
//        City = null,
//        Country = null,
//        Email = null,
//        Phone = null,
//        CellularPhone = null,
//        Blocked = false
//    },
//    new AccountDto
//    {
//        AccountId = "92156594",
//        Name = "CHRONOPOST SAS",
//        Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
//        Building = "CC211093",
//        Street = "3 BOULEVARD ROMAIN ROLLAND",
//        Locality = "",
//        ZipCode = "75680",
//        City = "PARIS CEDEX 14",
//        Country = "FRANCE",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279",
//        Blocked = false
//    },
//    new AccountDto
//    {
//        AccountId = "D0057721",
//        Name = "CHRONOPOST SAS",
//        Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
//        Building = "",
//        Street = "3 BOULEVARD ROMAIN ROLLAND",
//        Locality = "",
//        ZipCode = "75014",
//        City = "PARIS",
//        Country = "FRANCE",
//        Email = null,
//        Phone = null,
//        CellularPhone = null,
//        Blocked = false
//    },
//    new AccountDto
//    {
//        AccountId = "D0057729",
//        Name = "CHRONOPOST SAS HUB CHRONOPOST",
//        Recipient = "CC 211296",
//        Building = "CARGO 9",
//        Street = "9 RUE DU HAUT DE LAVAL",
//        Locality = "",
//        ZipCode = "95700",
//        City = "ROISSY EN FRANCE",
//        Country = "DANEMARK",
//        Email = null,
//        Phone = null,
//        CellularPhone = null,
//        Blocked = false
//    },
//    new AccountDto
//    {
//        AccountId = "D0057728",
//        Name = "CHRONOPOST VILLENEUVE",
//        Recipient = "CC 211192",
//        Building = "",
//        Street = "155 BOULEVARD CHARLES DE GAULLE",
//        Locality = "",
//        ZipCode = "92390",
//        City = "VILLENEUVE LA GARENNE",
//        Country = "FRANCE",
//        Email = null,
//        Phone = null,
//        CellularPhone = null,
//        Blocked = false
//    },
//    new AccountDto
//    {
//        AccountId = "D0057723",
//        Name = "CHRONOPOST",
//        Recipient = "CC 211296",
//        Building = "CARGO 7",
//        Street = "9 RUE DU HAUT DE LAVAL",
//        Locality = "",
//        ZipCode = "95700",
//        City = "ROISSY CHARLES DE GAULLE",
//        Country = "FRANCE",
//        Email = null,
//        Phone = null,
//        CellularPhone = null,
//        Blocked = false
//    }
//            };


//        //deliverToContacts P0130938
//        public static List<ContactDto?> deliverToContactsP0130938 = new List<ContactDto?>()
//            {
//               new ContactDto
//    {
//        ContactId = "",
//        SocialTitle = null,
//        FirstName = null,
//        LastName = "-- Aucun contact renseigné --",
//        Email = null,
//        Phone = null,
//        CellularPhone = null
//    },
//    new ContactDto
//    {
//        ContactId = "I3789634",
//        SocialTitle = "Mme",
//        FirstName = "KARINE",
//        LastName = "DUROCHER",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    },
//    new ContactDto
//    {
//        ContactId = "I4041155",
//        SocialTitle = "Mme",
//        FirstName = "GWENOLA",
//        LastName = "HORVAIS",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279"
//    }
//            };


//        //deliveryModes P0130938
//        public static List<BasketValueDto?> deliveryModesP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto
//    {
//        Value = "Catalogue"
//    },
//    new BasketValueDto
//    {
//        Value = "Enlèvement"
//    },
//    new BasketValueDto
//    {
//        Value = "Express"
//    },
//    new BasketValueDto
//    {
//        Value = "Filiale"
//    },
//    new BasketValueDto
//    {
//        Value = "Interne"
//    },
//    new BasketValueDto
//    {
//        Value = "Normal"
//    },
//    new BasketValueDto
//    {
//        Value = "VCT"
//    }
//            };


//        //invoiceInfo P0130938
//        public static BasketInvoiceInfoDto invoiceInfoP0130938 = new BasketInvoiceInfoDto()
//        {

//            Account = new Field<AccountDto?>
//            {
//                Name = "Compte de facturation",
//                Status = "readWrite",
//                Value = new AccountDto
//                {
//                    AccountId = "92156594",
//                    Name = "CHRONOPOST SAS",
//                    Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
//                    Building = "CC211093",
//                    Street = "3 BOULEVARD ROMAIN ROLLAND",
//                    Locality = "",
//                    ZipCode = "75680",
//                    City = "PARIS CEDEX 14",
//                    Country = "FRANCE",
//                    Email = "raja1234@raja.fr",
//                    Phone = "0120281279",
//                    CellularPhone = "0120281279",
//                    Blocked = false
//                },
//                ProcedureCall = new List<string?>
//        {
//            "UpdateCustomer",
//            "InvoiceTo",
//            "<one of /invoiceToAccounts accountId>"
//        }

//            },
//            SiretId = new Field<string?>
//            {
//                Name = "Siret",
//                Status = "onlyForDisplay",
//                Value = "38396013502628"

//            },
//            TaxGroup = new Field<BasketValueDto?>
//            {
//                Name = "Groupe de taxe",
//                Status = "readWrite",
//                Value = new BasketValueDto()
//                {
//                    Value = "F-DEB",
//                    Description = ""
//                },
                
//                ProcedureCall = new List<string?>
//        {
//            "UpdateOrderTablePropertyValue",
//            "TaxGroup",
//            "System.String",
//            "<value>"
//        }
//            },
//            PaymentTerm = new Field<BasketValueDto?>
//            {
//                Name = "Conditions de paiement",
//                Status = "onlyForDisplay",
//                Value = new BasketValueDto()
//                {
//                    Value = "FDM45",
//                    Description = ""
//                },
                

//            },
//            PaymentMode = new Field<BasketValueDto?>
//            {
//                Name = "Mode de paiement",
//                Status = "readWrite",
//                Value = new BasketValueDto()
//                {
//                    Value = "VB",
//                    Description = ""
//                },
                
//                ProcedureCall = new List<string?>
//        {
//            "UpdateOrderTablePropertyValue",
//            "PaymMode",
//            "System.String",
//            "<value>"
//        }

//            },
//            IsPublicEntity = false,
//            PublicEntityExecutingService = new Field<string?>
//            {
//                Name = "Service exécutif",
//                Status = "readOnly",
//                Value = null
//            },
//            PublicEntityLegalCommitment = new Field<string?>
//            {
//                Name = "Engagement juridique",
//                Status = "readOnly",
//                Value = null
//            },
//            Note = new Field<string?>
//            {
//                Name = null,
//                Status = "onlyForDisplay",
//                Value = null
//            }
//        };


//        //invoiceToAccounts P0130938
//        public static List<AccountDto?> invoiceToAccountsP0130938 = new List<AccountDto?>()
//            {
//                new AccountDto
//    {
//        AccountId = "",
//        Name = "-- Aucune adresse renseignée --",
//        Recipient = null,
//        Building = null,
//        Street = "-- Aucune adresse renseignée --",
//        Locality = null,
//        ZipCode = null,
//        City = null,
//        Country = null,
//        Email = null,
//        Phone = null,
//        CellularPhone = null,
//        Blocked = false
//    },
//    new AccountDto
//    {
//        AccountId = "92156594",
//        Name = "CHRONOPOST SAS",
//        Recipient = "DEPARTEMENT COMPTABILITE FOURNISSEURS",
//        Building = "CC211093",
//        Street = "3 BOULEVARD ROMAIN ROLLAND",
//        Locality = "",
//        ZipCode = "75680",
//        City = "PARIS CEDEX 14",
//        Country = "FRANCE",
//        Email = "raja1234@raja.fr",
//        Phone = "0120281279",
//        CellularPhone = "0120281279",
//        Blocked = false
//    }
//            };


//        //TaxGroups P0130938
//        public static List<BasketValueDto?> taxGroupsP0130938 = new List<BasketValueDto?>()
//            {
//                  new BasketValueDto
//    {
//        Description = null,
//        Value = ""
//    },
//    new BasketValueDto
//    {
//        Description = "France Autoliquidation",
//        Value = "F-AUTOLIQ"
//    },
//    new BasketValueDto
//    {
//        Description = "France TVA sur les débits",
//        Value = "F-DEB"
//    },
//    new BasketValueDto
//    {
//        Description = "France TVA sur les débits Escompte",
//        Value = "F-DEBTVA"
//    },
//    new BasketValueDto
//    {
//        Description = "France TVA sur les encaissements",
//        Value = "F-ENC"
//    },
//    new BasketValueDto
//    {
//        Description = "France TVA sur les encaissements Escompte",
//        Value = "F-ENCTVA"
//    },
//    new BasketValueDto
//    {
//        Description = "France exonéré",
//        Value = "F-EXO"
//    },
//    new BasketValueDto
//    {
//        Description = "TVA sur factures à émettre",
//        Value = "F-FAE"
//    },
//    new BasketValueDto
//    {
//        Description = "France SMICTOM TVA 7%",
//        Value = "F-SMI"
//    },
//    new BasketValueDto
//    {
//        Description = "Tiers hors UE vente",
//        Value = "HUE"
//    },
//    new BasketValueDto
//    {
//        Description = "Tiers Hors UE achat",
//        Value = "HUE-AC"
//    },
//    new BasketValueDto
//    {
//        Description = "Monaco TVA sur les débits",
//        Value = "M-DEB"
//    },
//    new BasketValueDto
//    {
//        Description = "Monaco EXONERE (Attestation)",
//        Value = "M-EXO"
//    },
//    new BasketValueDto
//    {
//        Description = "TVA union européenne achat",
//        Value = "UE-AC"
//    },
//    new BasketValueDto
//    {
//        Description = "TVA union européenne vente",
//        Value = "UE-VE"
//    },
//    new BasketValueDto
//    {
//        Description = "TVA FNP à régulariser",
//        Value = "ZF-FNP"
//    }
//            };


//        //paymentModes P0130938
//        public static List<BasketValueDto?> paymentModesP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto
//    {
//        Description = null,
//        Value = ""
//    },
//    new BasketValueDto
//    {
//        Description = "Carte Bancaire",
//        Value = "CB"
//    },
//    new BasketValueDto
//    {
//        Description = "Chèque",
//        Value = "CH"
//    },
//    new BasketValueDto
//    {
//        Description = "Paypal",
//        Value = "PAYPAL"
//    },
//    new BasketValueDto
//    {
//        Description = "Préautorisation CB",
//        Value = "PCB"
//    },
//    new BasketValueDto
//    {
//        Description = "Carte Bancaire Manuelle",
//        Value = "TPE"
//    },
//    new BasketValueDto
//    {
//        Description = "Virement Bancaire",
//        Value = "VB"
//    },
//    new BasketValueDto
//    {
//        Description = "Virement Marketplace La Poste",
//        Value = "VMP"
//    },
//    new BasketValueDto
//    {
//        Description = "Préautorisation CB manuelle",
//        Value = "ZCB"
//    },
//    new BasketValueDto
//    {
//        Description = "Paypal sur Ebay",
//        Value = "ZEBAY"
//    },
//    new BasketValueDto
//    {
//        Description = "Préautorisation PC manuelle",
//        Value = "ZPC"
//    },
//    new BasketValueDto
//    {
//        Description = "Préautorisation Paypal manuelle",
//        Value = "ZPY"
//    }
//            };


//        //tradeInfo P0130938
//        public static BasketTradeInfoDto tradeInfoP0130938 = new BasketTradeInfoDto()
//        {
//            Turnover = new Field<List<BasketTurnoverLineDto?>>
//            {
//                Name = "Chiffre d'affaire",
//                Status = "onlyForDisplay",
//                Value = new List<BasketTurnoverLineDto?>
//                    {
//                        new BasketTurnoverLineDto
//            {
//                Name = "Classe",
//                Ytd = "16",
//                YtdN1 = "",
//                N1 = "16",
//                N2 = "16"
//            },
//                        new BasketTurnoverLineDto
//            {
//                Name = "CA.",
//                Ytd = "267 606 €",
//                YtdN1 = "214 342 €",
//                N1 = "790 128 €",
//                N2 = "657 368 €"
//            },
//                        new BasketTurnoverLineDto
//            {
//                Name = "Evol. CA.",
//                Ytd = "24,85 %",
//                YtdN1 = "",
//                N1 = "",
//                N2 = ""
//            }
//                },

//            },
//            Contract = new BasketContractInfoDto
//            {
//                ContractId = new Field<string?>
//                {
//                    Name = "Contrat",
//                    Status = "onlyForDisplay",
//                    Value = "CT072408"

//                },
//                ContractType = new Field<string?>
//                {
//                    Name = "Type",
//                    Status = "onlyForDisplay",
//                    Value = "Conditions Spéciales"

//                },
//                ContractGroup = new Field<string?>
//                {
//                    Name = "Groupe de contrat",
//                    Status = "onlyForDisplay",
//                    Value = "CHRONOPOST SA"
//                },
//                Status = new Field<string?>
//                {
//                    Name = "Statut",
//                    Status = "onlyForDisplay",
//                    Value = "En cours"
//                },
//                StartDate = new Field<string?>
//                {
//                    Name = "Date de début",
//                    Status = "onlyForDisplay",
//                    Value = "2024-04-08 00:00:00"
//                },
//                EndDate = new Field<string?>
//                {
//                    Name = "Date de fin",
//                    Status = "onlyForDisplay",
//                    Value = "2024-08-31 00:00:00"
//                },
//                CampaignId = new Field<string?>
//                {
//                    Name = "Campagne de prix",
//                    Status = "onlyForDisplay",

//                    Value = null
//                },
//                MainContact = new Field<string?>
//                {
//                    Name = "Commercial terrain",
//                    Status = "onlyForDisplay",

//                    Value = "ISABELLE LASNIER"
//                },
//                OfficeExecutive = new Field<string?>
//                {
//                    Name = "Commercial sédentaire",
//                    Status = "onlyForDisplay",

//                    Value = "CHRISTELLE BERNIER"
//                },
//                DiscountList = new Field<List<string?>>
//                {
//                    Name = "Description",
//                    Status = "onlyForDisplay",

//                    Value = new List<string?> { "Prix nets sur 49 article(s)", "10% DC sur tout le catalogue" }
//                }
//            }

//        };


//        //pricesInfo P0130938
//        public static BasketPricesInfoDto pricesInfoP0130938 = new BasketPricesInfoDto()
//        {
//            //Column 1
//            Coupon = new Field<BasketValueDto?>
//            {
//                Name = "Code Action",
//                Status = "readWrite",

//                Value = new BasketValueDto()
//                {
//                    Value = "G032400",
//                    Description = ""
//                },
                
//                ProcedureCall = new List<string?>
//        {
//            "UpdateOrderTablePropertyValue",
//            "CampaignId",
//            "System.String",
//            "<one of /coupons value>"
//        }
//            },
//            FreeShippingAmountThreshold = new Field<decimal?>
//            {
//                Name = "Diff Franco",
//                Status = "onlyForDisplay",

//                Value = null
//            },
//            GiftAmountThreshold = new Field<decimal?>
//            {
//                Name = "Diff KDO",
//                Status = "onlyForDisplay",

//                Value = null
//            },
//            ProductsInfo = new Field<string?>
//            {
//                Name = "Dispo. Marchandise",
//                Status = "onlyForDisplay",

//                Value = "78% en stock / Liv. Multiple"
//            },

//            //Column 2
//            ProductsNetAmount = new Field<decimal?>
//            {
//                Name = "Marchandise HT",
//                Status = "onlyForDisplay",

//                Value = 77.00m
//            },
//            WarrantyCostOption = new Field<BasketValueDto?>
//            {
//                Name = "Type de garantie optimale",
//                Status = "readWrite",
//                Value =  new BasketValueDto()
//                {
//                    Value = "Disabled",
//                    Description = ""
//                },
               
//                ProcedureCall = new List<string?>
//        {
//            "UpdateOrderTablePropertyValue",
//            "WarrantyMode",
//            "System.String",
//            "<one of /warrantyCostOptions value>"
//        }
//            },
//            WarrantyCostAmount = new Field<decimal?>
//            {
//                Name = "Montant de la garantie optimale",
//                Status = "onlyForDisplay",

//                Value = 0.00m
//            },
//            ShippingCostOption = new Field<BasketValueDto?>
//            {
//                Name = "Type de frais de port",
//                Status = "readWrite",

//                Value = new BasketValueDto()
//                {
//                    Value = "Disabled",
//                    Description = ""
//                },
                
//                ProcedureCall = new List<string?>
//        {
//            "UpdateOrderTablePropertyValue",
//            "DeliveryFeeMode",
//            "System.String",
//            "<one of /shippingCostOptions value>"
//        }
//            },
//            ShippingCostAmount = new Field<decimal?>
//            {
//                Name = "Montant des frais de port",
//                Status = "readWrite",

//                Value = 0.00m,
//                ProcedureCall = new List<string?>
//        {
//            "UpdateOrderTablePropertyValue",
//            "DeliveryAmount",
//            "System.Double",
//            "<value>"
//        }
//            },
//            LogisticInfo = null,

//            //Column 3
//            TotalNetAmount = new Field<decimal?>
//            {
//                Name = "Montant Total HT",
//                Status = "onlyForDisplay",

//                Value = 77.00m
//            },
//            VatAmount = new Field<decimal?>
//            {
//                Name = "Montant TVA",
//                Status = "onlyForDisplay",

//                Value = 15.40m
//            },
//            TotalGrossAmount = new Field<decimal?>
//            {
//                Name = "Montant TTC",
//                Status = "onlyForDisplay",

//                Value = 92.40m
//            },

//            //Column 4
//            OrderDiscountRate = new Field<int?>
//            {
//                Name = "Remise Cde (%)",
//                Status = "readWrite",
//                Value = 0,
//                ProcedureCall = new List<string?>
//                {
//                    "UpdateOrderTablePropertyValue",
//                    "MyDiscountPercent",
//                    "System.Int32",
//                    "<value>"
//                }
//            },
//            OrderLastColumnDiscount = new Field<bool?>
//            {
//                Name = "Remise Cde DC",
//                Status = "readWrite",

//                Value = true,
//                ProcedureCall = new List<string?>
//        {
//            "UpdateOrderTablePropertyValue",
//            "MyLastColumnDiscount",
//            "System.Boolean",
//            "<value>"
//        }
//            },
//            DiscountAmount = new Field<decimal?>
//            {
//                Name = "Remise Cde (€)",
//                Status = "onlyForDisplay",

//                Value = 0.00m
//            },
//            AdditionalSalesAmount = new Field<decimal?>
//            {
//                Name = "Ventes add. (€)",
//                Status = "onlyForDisplay",

//                Value = 0.00m
//            },
//            TotalWeight = new Field<decimal?>
//            {
//                Name = "Poids (kg)",
//                Status = "onlyForDisplay",

//                Value = 12.67m
//            },
//            TotalVolume = new Field<decimal?>
//            {
//                Name = "Volume (m3)",
//                Status = "onlyForDisplay",

//                Value = 0.095m
//            }
//        };



//        //coupons PriceLines info section   P0130938
//        public static List<BasketValueDto?> couponsP0130938 = new List<BasketValueDto?>()
//            {
//                new BasketValueDto
//    {
//        Description = "COMMANDES nefab 2010\nCODE PAR DEFAUT\nVALIDITE INDETERMINEE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis",
//        Value = "AC0100"
//    },
//    new BasketValueDto
//    {
//        Description = "COMMANDES AIRBUS 2011-2012\nCODE PAR DEFAUT\nVALIDITE INDETERMINE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis",
//        Value = "AIRBUS"
//    },
//    new BasketValueDto
//    {
//        Description = "OFFERT dès 200 EUROS : CADEAU COFFRET LA MERE POULARD\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
//        Value = "BISCUITS830"
//    },
//    new BasketValueDto
//    {
//        Description = "DEMANDES DE CATALOGUES",
//        Value = "CAT24"
//    },
//    new BasketValueDto
//    {
//        Description = "DEMANDES DE CATALOGUES CLIENTS",
//        Value = "CATC24"
//    },
//    new BasketValueDto
//    {
//        Description = "DEMANDES DE CATALOGUES PROSPECTS",
//        Value = "CATP24"
//    },
//    new BasketValueDto
//    {
//        Description = "Validité au 31/12/2024\nAucun cadeau\nPas de welcome pack",
//        Value = "CRC24R"
//    },
//    new BasketValueDto
//    {
//        Description = "DEMANDES DE CATALOGUES PROSPECTS",
//        Value = "ECATP24"
//    },
//    new BasketValueDto
//    {
//        Description = "DEMANDES D'ECHANTILLONS CLIENTS",
//        Value = "ECHC24"
//    },
//    new BasketValueDto
//    {
//        Description = "DEMANDES D'ECHANTILLONS PROSPECTS",
//        Value = "ECHP24"
//    },
//    new BasketValueDto
//    {
//        Description = "OFFERT dès 400 EUROS : CADEAU APPAREIL FONDUE\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
//        Value = "FONDUE172"
//    },
//    new BasketValueDto
//    {
//        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024",
//        Value = "G032400"
//    },
//    new BasketValueDto
//    {
//        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024",
//        Value = "G032401"
//    },
//    new BasketValueDto
//    {
//        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024",
//        Value = "G032408"
//    },
//    new BasketValueDto
//    {
//        Description = "TARIFS FILIALES MARS 24\nVALIDITE AU 31/08/2024",
//        Value = "Y032400"
//    }
//            };


//        //warrantyCostOptions PriceLines info section   P0130938
//        public static List<BasketValueDto?> warrantyCostOptionsP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto
//    {
//        Description = "GO non dispo.",
//        Value = "10Disabled"
//    }

//            };


//        //shippingCostOptions PriceLines info section   P0130938
//        public static List<BasketValueDto?> shippingCostOptionsP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto
//    {
//        Description = "Frais de livraison",
//        Value = "Standard"
//    },
//    new BasketValueDto
//    {
//        Description = "Frais de liv. offerts",
//        Value = "Offered"
//    }
//            };

//        //Lines P0130938
//        public static BasketOrderLinesDto basketLineDtosP0130938 = new()
//        {
//            lines = new List<BasketLineDto?>()
//            {
//            new BasketLineDto
//            {
//                LineNum = new Field<int?>
//                {
//                    Name = "N° de ligne",
//                    Status = "readWrite",
//                    Value = 1
//                },
//        IsCustomLineNum = false,
//        LineTags = new List<BasketValueDto?>(),
//        ItemId = new Field<string?>
//        {
//            Name = "Code article",
//            Status = "readWrite",
//            Value = "CAS12"
//        },
//        Name = new Field<string?>
//        {
//            Name = "Description",
//            Status = "readWrite",
//            Value = "C.A SC10 27X19X12 BRUN"
//        },
//        InventLocationId = new Field<string?>
//        {
//            Name = "Entrepôt",
//            Status = "readWrite",
//            Value = "PN2"
//        },
//        SalesQuantity = new Field<int?>
//        {
//            Name = "Quantité",
//            Status = "readWrite",
//            Value = 25
//        },
//        SalesPrice = new Field<decimal?>
//        {
//            Name = "Prix unitaire",
//            Status = "readWrite",
//            Value = 0.68m
//        },
//        DiscountType = new Field<BasketValueDto?>
//        {
//            Name = "Tarification",
//            Status = "readWrite",
//            Value = new BasketValueDto()
//                {
//                    Value = "Default",
//                    Description = ""
//                },
//        },
//        LineAmount = new Field<decimal?>
//        {
//            Name = "Montant HT",
//            Status = "readWrite",
//            Value = 17m
//        },
//        UpdateReason = new Field<BasketValueDto?>
//        {
//            Name = "Motif Modif.",
//            Status = "readWrite",
//            Value = new BasketValueDto
//            {
//                Value="testValue",
//                Description="testDescription"
//            }
//        },
//        InitialSalesQuantity = new Field<int?>
//        {
//            Name = "Qté initiale",
//            Status = "readWrite",
//            Value = 0
//        },
//        MultipleQuantity = null,
//        VatRate = new Field<decimal?>
//        {
//            Name = "Taux de TVA",
//            Status = "readWrite",
//            Value = 20
//        },
//        Note = new Field<string?>
//        {
//            Name = "Note",
//            Status = "OnlyForDisplay",
//            Value = ""
//        },
//        ProductInfo = new Field<string?>
//        {
//            Name = "Information produit",
//            Status = "OnlyForDisplay",
//            Value = ""
//        },
//        IsCustomLogisticFlow = false,
//        LogisticFlow = new Field<BasketValueDto?>
//        {
//            Name = "Flux logistique",
//            Status = "readWrite",
//            Value = new BasketValueDto
//            {
//                Value="Stock",
//                Description=""
//            }
//        },
//        PhysicalAvailableQuantity = new Field<int?>
//        {
//            Name = "Livré maintenant",
//            Status = "onlyForDisplay",
//            Value = 0
//        },
//        OnOrderQuantity = new Field<int?>
//        {
//            Name = "A livrer plus tard",
//            Status = "onlyForDisplay",
//            Value = 25
//        },
//        PaletteQuantity = new Field<int?>
//        {
//            Name = "Quantité/palette",
//            Status = "onlyForDisplay",
//            Value = 1100
//        },
//        QuantityAtPaletteThreshold = new Field<int?>
//        {
//            Name = "Diff Palette",
//            Status = "onlyForDisplay",
//            Value = 1075
//        },
//        ItemType = new Field<string?>
//        {
//            Name = "Type d'article",
//            Status = "onlyForDisplay",
//            Value = "Standard"
//        },
//        DeliveryDate = new Field<string?>
//        {
//            Name = "Date de liv.",
//            Status = "readWrite",
//            Value = null
//        },
//        IsCustomDeliveryDate = new Field<bool?>
//        {
//            Name = "Date de liv. manuelle",
//            Status = "readWrite",
//            Value = false
//        },
//        ItemPhysicalInventQuantity = new Field<int?>
//        {
//            Name = "Stock total",
//            Status = "onlyForDisplay",
//            Value = 3000
//        },
//        ItemReservPhysicalQuantity = new Field<int?>
//        {
//            Name = "Stock réservé",
//            Status = "onlyForDisplay",
//            Value = 3000
//        },
//        ItemPhysicalAvailableQuantity = new Field<int?>
//        {
//            Name = "Stock réservé",
//            Status = "onlyForDisplay",
//            Value = 0
//        },
//        ItemOnOrderQuantity = new Field<int?>
//        {
//            Name = "Commandé total",
//            Status = "onlyForDisplay",
//            Value = 700
//        },
//        ItemOrderedQuantity = new Field<int?>
//        {
//            Name = "Commandé total",
//            Status = "onlyForDisplay",
//            Value = 0
//        },
//        ItemOrderedAvailableQuantity = new Field<int?>
//        {
//            Name = "Commandé total",
//            Status = "onlyForDisplay",
//            Value = 0
//        },
//        SupplyFamily = new Field<string?>
//        {
//            Name = "Famille d'appro.",
//            Status = "onlyForDisplay",
//            Value = "C1 - CAISSES ET CONTAINERS"
//        },
//        ItemManager = new Field<string?>
//        {
//            Name = "Gestionnaire",
//            Status = "onlyForDisplay",
//            Value = "ERIC DAVACH"
//        },
//        TransportMode = new Field<string?>
//        {
//            Name = "Mode de transport",
//            Status = "onlyForDisplay",
//            Value = "PAR DÉFAUT"
//        },
//        PurchaseId = new Field<string?>
//        {
//            Name = "Commande d'achat",
//            Status = "hidden",
//            Value = ""
//        },
//        DiscountDescription = new Field<string?>
//        {
//            Name = "Description Tarif",
//            Status = "onlyForDisplay",
//            Value = "10% DC sur tout le Catalogue"
//        },
//        DiscountRate = new Field<decimal?>
//        {
//            Name = "Remise sup.",
//            Status = "readOnly",
//            Value = 35
//        },
//        DiscountPrice = new Field<decimal?>
//        {
//            Name = "PU HT",
//            Status = "readOnly",
//            Value = 0.68m
//        },
//         //in the api this PriceLines is null,  adding data for test
//        PriceLines = new List<BasketPriceLine?>()
//{
//    new BasketPriceLine
//    {
//        Quantity = 25,
//        CatalogPrice = 1.05m,
//        DiscountPrice = 1.00m,
//        MultiplePrice = 25.00m,
//        DiscountRate = 0
//    },
//     new BasketPriceLine
//    {
//        Quantity = 100,
//        CatalogPrice = 0.99m,
//        DiscountPrice = 0.94m,
//        MultiplePrice = 23.50m,
//        DiscountRate = 6
//    },
//    new BasketPriceLine
//    {
//        Quantity = 200,
//        CatalogPrice = 0.92m,
//        DiscountPrice = 0.87m,
//        MultiplePrice = 21.75m,
//        DiscountRate = 13
//    },
//    new BasketPriceLine
//    {
//        Quantity = 400,
//        CatalogPrice = 0.87m,
//        DiscountPrice = 0.83m,
//        MultiplePrice = 20.75m,
//        DiscountRate = 17
//    },
//    new BasketPriceLine
//    {
//        Quantity = 800,
//        CatalogPrice = 0.76m,
//        DiscountPrice = 0.72m,
//        MultiplePrice = 18.00m,
//        DiscountRate = 28
//    }
//        }
//    },

//    new BasketLineDto
//    {
//        LineNum = new Field<int?>
//        {
//            Name = "N° de ligne",
//            Status = "readWrite",
//            Value = 2
//        },
//        IsCustomLineNum = false,
//        LineTags = new List<BasketValueDto?>(),
//        ItemId = new Field<string?>
//        {
//            Name = "Code article",
//            Status = "readWrite",
//            Value = "CAS10"
//        },
//        Name = new Field<string?>
//        {
//            Name = "Description",
//            Status = "readWrite",
//            Value = "C.A SC10 25X25X25 BRUN"
//        },
//        InventLocationId = new Field<string?>
//        {
//            Name = "Entrepôt",
//            Status = "readWrite",
//            Value = "PN2"
//        },
//        SalesQuantity = new Field<int?>
//        {
//            Name = "Quantité",
//            Status = "readWrite",
//            Value = 50
//        },
//        SalesPrice = new Field<decimal?>
//        {
//            Name = "Prix unitaire",
//            Status = "readWrite",
//            Value = 1.2m
//        },
//        DiscountType = new Field<BasketValueDto?>
//        {
//            Name = "Tarification",
//            Status = "readWrite",
//            Value =new BasketValueDto()
//                {
//                    Value = "Default",
//                    Description = ""
//                }, 
//        },
//        LineAmount = new Field<decimal?>
//        {
//            Name = "Montant HT",
//            Status = "readWrite",
//            Value = 60m
//        },
//        UpdateReason = new Field<BasketValueDto?>
//        {
//            Name = "Motif Modif.",
//            Status = "readWrite",
//            Value =new BasketValueDto()
//                {
//                    Value = "",
//                    Description = ""
//                },
//        },
//        InitialSalesQuantity = new Field<int?>
//        {
//            Name = "Qté initiale",
//            Status = "readWrite",
//            Value = 0
//        },
//        MultipleQuantity = null,
//        VatRate = new Field<decimal?>
//        {
//            Name = "Taux de TVA",
//            Status = "readWrite",
//            Value = 20
//        },
//        Note = null,
//        ProductInfo = null,
//        IsCustomLogisticFlow = false,
//        LogisticFlow = new Field<BasketValueDto?>
//        {
//            Name = "Flux logistique",
//            Status = "readWrite",
//            Value =new BasketValueDto()
//                {
//                    Value = "Stock",
//                    Description = ""
//                }, 
//        },
//        PhysicalAvailableQuantity = new Field<int?>
//        {
//            Name = "Livré maintenant",
//            Status = "onlyForDisplay",
//            Value = 50
//        },
//        OnOrderQuantity = new Field<int?>
//        {
//            Name = "A livrer plus tard",
//            Status = "onlyForDisplay",
//            Value = 0
//        },
//        PaletteQuantity = new Field<int?>
//        {
//            Name = "Quantité/palette",
//            Status = "onlyForDisplay",
//            Value = 1100
//        },
//        QuantityAtPaletteThreshold = new Field<int?>
//        {
//            Name = "Diff Palette",
//            Status = "onlyForDisplay",
//            Value = 1050
//        },
//        ItemType = new Field<string?>
//        {
//            Name = "Type d'article",
//            Status = "onlyForDisplay",
//            Value = "Standard"
//        },
//        DeliveryDate = new Field<string?>
//        {
//            Name = "Date de liv.",
//            Status = "readWrite",
//            Value = null
//        },
//        IsCustomDeliveryDate = new Field<bool?>
//        {
//            Name = "Date de liv. manuelle",
//            Status = "readWrite",
//            Value = false
//        },
//        ItemPhysicalInventQuantity = new Field<int?>
//        {
//            Name = "Stock total",
//            Status = "onlyForDisplay",
//            Value = 9075
//        },
//        ItemReservPhysicalQuantity = new Field<int?>
//        {
//            Name = "Stock réservé",
//            Status = "onlyForDisplay",
//            Value = 1330
//        },
//        ItemPhysicalAvailableQuantity = new Field<int?>
//        {
//            Name = "Stock réservé",
//            Status = "onlyForDisplay",
//            Value = 7745
//        },
//        ItemOnOrderQuantity = new Field<int?>
//        {
//            Name = "Commandé total",
//            Status = "onlyForDisplay",
//            Value = 1045
//        },
//        ItemOrderedQuantity = new Field<int?>
//        {
//            Name = "Commandé total",
//            Status = "onlyForDisplay",
//            Value = 0
//        },
//        ItemOrderedAvailableQuantity = new Field<int?>
//        {
//            Name = "Commandé total",
//            Status = "onlyForDisplay",
//            Value = 0
//        },
//        SupplyFamily = new Field<string?>
//        {
//            Name = "Famille d'appro.",
//            Status = "onlyForDisplay",
//            Value = "C1 - CAISSES ET CONTAINERS"
//        },
//        ItemManager = new Field<string?>
//        {
//            Name = "Gestionnaire",
//            Status = "onlyForDisplay",
//            Value = "ANTOINE STEGEL"
//        },
//        TransportMode = new Field<string?>
//        {
//            Name = "Mode de transport",
//            Status = "onlyForDisplay",
//            Value = "PAR DÉFAUT"
//        },
//        PurchaseId = new Field<string?>
//        {
//            Name = "Commande d'achat",
//            Status = "hidden",
//            Value = ""
//        },
//        DiscountDescription = new Field<string?>
//        {
//            Name = "Description Tarif",
//            Status = "onlyForDisplay",
//            Value = "10% DC sur tout le Catalogue"
//        },
//        DiscountRate = new Field<decimal?>
//        {
//            Name = "Remise sup.",
//            Status = "readOnly",
//            Value = 34
//        },
//        DiscountPrice = new Field<decimal?>
//        {
//            Name = "PU HT",
//            Status = "readOnly",
//            Value = 1.2m
//        },
//        PriceLines = null
//    }
//        }
//        };


//        public static List<BasketValueDto?> UpdateReasonsP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto
//                {
//                    Value = ""
//                },
//new BasketValueDto
//{
//    Description = "ADD FOLIES",
//    Value = "ADD FOLIES"
//},
//new BasketValueDto
//{
//    Description = "ADD LIGNE",
//    Value = "ADD LIGNE"
//},
//new BasketValueDto
//{
//    Description = "ADD QTE",
//    Value = "ADD QTE"
//},
//new BasketValueDto
//{
//    Description = "ALS",
//    Value = "ALS"
//},
//new BasketValueDto
//{
//    Description = "ATT",
//    Value = "ATT"
//},
//new BasketValueDto
//{
//    Description = "BPS",
//    Value = "BPS"
//},
//new BasketValueDto
//{
//    Description = "BVN",
//    Value = "BVN"
//},
//new BasketValueDto
//{
//    Description = "CAD",
//    Value = "CAD"
//},
//new BasketValueDto
//{
//    Description = "CROSS",
//    Value = "CROSS"
//},
//new BasketValueDto
//{
//    Description = "CS",
//    Value = "CS"
//},
//new BasketValueDto
//{
//    Description = "DAV",
//    Value = "DAV"
//},
//new BasketValueDto
//{
//    Description = "DEF",
//    Value = "DEF"
//},
//new BasketValueDto
//{
//    Description = "ECH",
//    Value = "ECH"
//},
//new BasketValueDto
//{
//    Description = "EXP",
//    Value = "EXP"
//},
//new BasketValueDto
//{
//    Description = "FAC",
//    Value = "FAC"
//},
//new BasketValueDto
//{
//    Description = "FID",
//    Value = "FID"
//},
//new BasketValueDto
//{
//    Description = "FIN",
//    Value = "FIN"
//},
//new BasketValueDto
//{
//    Description = "FS",
//    Value = "FS"
//},
//new BasketValueDto
//{
//    Description = "GCO",
//    Value = "GCO"
//},
//new BasketValueDto
//{
//    Description = "GRT",
//    Value = "GRT"
//},
//new BasketValueDto
//{
//    Description = "GSC",
//    Value = "GSC"
//},
//new BasketValueDto
//{
//    Description = "KC",
//    Value = "KC"
//},
//new BasketValueDto
//{
//    Description = "LOC",
//    Value = "LOC"
//},
//new BasketValueDto
//{
//    Description = "MKG",
//    Value = "MKG"
//},
//new BasketValueDto
//{
//    Description = "MY ORDER",
//    Value = "MY ORDER"
//},
//new BasketValueDto
//{
//    Description = "NC",
//    Value = "NC"
//},
//new BasketValueDto
//{
//    Description = "NCM",
//    Value = "NCM"
//},
//new BasketValueDto
//{
//    Description = "NDI",
//    Value = "NDI"
//},
//new BasketValueDto
//{
//    Description = "OFF",
//    Value = "OFF"
//},
//new BasketValueDto
//{
//    Description = "PRA",
//    Value = "PRA"
//},
//new BasketValueDto
//{
//    Description = "PRV",
//    Value = "PRV"
//},
//new BasketValueDto
//{
//    Description = "PRW",
//    Value = "PRW"
//},
//new BasketValueDto
//{
//    Description = "REP",
//    Value = "REP"
//},
//new BasketValueDto
//{
//    Description = "RFA",
//    Value = "RFA"
//},
//new BasketValueDto
//{
//    Description = "RPL",
//    Value = "RPL"
//},
//new BasketValueDto
//{
//    Description = "SAV",
//    Value = "SAV"
//},
//new BasketValueDto
//{
//    Description = "VU",
//    Value = "VU"
//},
//new BasketValueDto
//{
//    Description = "WEB",
//    Value = "WEB"
//},
//new BasketValueDto
//{
//    Description = "XC",
//    Value = "XC"
//}

//            };


//        public static List<BasketValueDto?> logisticFlowsP0130938 = new List<BasketValueDto?>()
//            {
//                 new BasketValueDto
//                 {
//                     Description = "Stock",
//                     Value = "Stock"
//                 },
//                 new BasketValueDto
//                 {
//                     Description = "Livraison directe",
//                     Value = "DropShipped"
//                 },

//                 new BasketValueDto
//                 {
//                     Description = "Passage en stock",
//                     Value = "CrossDocked"
//                 }
//            };


//        //P0130140

//        //api/orderContext/P0130140/generalInfo P0130140

//        public static BasketGeneralInfoDto generalInfoP0130140 = new BasketGeneralInfoDto()
//        {
//            OrderType = "Panier",
//            BasketId = "P0130140",
//            OrderId = "WC999075",
//            OrderStatus = "Nouveau",
//            OrderDate = "2024-07-15 17:04:31",
//            SalesResponsible = "CEDRIC REVILLON"
//        };


//        //orderInfo P0130140
//        public static BasketOrderInfoDto orderInfoP0130140 = new BasketOrderInfoDto
//        {
//            Account = new Field<AccountDto?>
//            {
//                Name = "Compte commandeur",
//                Status = "onlyForDisplay",
//                Value = new AccountDto
//                {
//                    AccountId = "A1619563",
//                    Name = "COQUILLAGE NACRE",
//                    Recipient = "",
//                    Building = "",
//                    Street = "2 RUE BINET",
//                    Locality = "",
//                    ZipCode = "60000",
//                    City = "BEAUVAIS",
//                    Country = "FRANCE",
//                    Email = "",
//                    Phone = "0621434586",
//                    CellularPhone = "",
//                    Blocked = false
//                }
//            },
//            Contact = new Field<ContactDto?>
//            {
//                Name = "Contact commandeur",
//                Status = "readOnly",
//                Value = new ContactDto
//                {
//                    ContactId = "X4690210",
//                    SocialTitle = "M.",
//                    FirstName = "LUC",
//                    LastName = "DURAND",
//                    Email = "knouet@raja.fr",
//                    Phone = "0621434586",
//                    CellularPhone = "0621434586"
//                }
//            },
//            ActivityArea = new Field<string?>
//            {
//                Name = "Secteur d'activité",
//                Status = "onlyForDisplay",
//                Value = null
//            },
//            CustomerTags = new List<BasketValueDto?>(),
//            SalesOriginId = new Field<BasketValueDto?>
//            {
//                Name = "Canal de vente",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = "Téléphone",
//                    Description = ""
//                },
                
//            },
//            WebOriginId = new Field<BasketValueDto?>
//            {
//                Name = "Origine e-commerce",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = "",
//                    Description = ""
//                },
                
//            },
//            SalesPoolId = new Field<BasketValueDto?>
//            {
//                Name = "Type de transaction",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = "NOR",
//                    Description = ""
//                },
                
//            },
//            CustomerOrderRef = new Field<string?>
//            {
//                Name = "Référence Client",
//                Status = "readOnly",
//                Value = "visa"
//            },
//            WebSalesId = new Field<string?>
//            {
//                Name = "Commande Web",
//                Status = "readOnly",
//                Value = ""
//            },
//            RelatedLink = new Field<string?>
//            {
//                Name = "Devis",
//                Status = "hidden",
//                Value = ""
//            },
//            Note = new Field<string?>
//            {
//                Name = "Note de RC",
//                Status = "onlyForDisplay",
//                Value = ""
//            }
//        };


//        //orderByContacts P0130140
//        public static List<ContactDto?> orderByContactsP0130140 = new List<ContactDto?>
//        {
//            new ContactDto
//            {
//                    ContactId = "X4690210",
//        SocialTitle = "M.",
//        FirstName = "LUC",
//        LastName = "DURAND",
//        Email = "knouet@raja.fr",
//        Phone = "0621434586",
//        CellularPhone = "0621434586"
//            }
//        };


//        //customerTags P0130140
//        public static List<BasketValueDto?> customerTagsP0130140 = new List<BasketValueDto?>
//        {
//    new BasketValueDto
//    {
//        Description = "Client VIP",
//        Value = "vip"
//    },
//    new BasketValueDto
//    {
//        Description = "Préparation spéciale",
//        Value = "specialPrep"
//    },
//    new BasketValueDto
//    {
//        Description = "Client Export",
//        Value = "export"
//    },
//    new BasketValueDto
//    {
//        Description = "Pas de cadeaux",
//        Value = "noGift"
//    },
//    new BasketValueDto
//    {
//        Description = "Livraison complète",
//        Value = "completeDelivery"
//    }
//        };


//        //salesPools P0130140
//        public static List<BasketValueDto?> salesPoolsP0130140 = new List<BasketValueDto?>
//        {
//    new BasketValueDto
//    {

//        Value = null
//    },
//    new BasketValueDto
//    {
//        Description = "Commande normale",
//        Value = "NOR"
//    },
//    new BasketValueDto
//    {
//        Description = "Commande liée",
//        Value = "LIE"
//    },
//    new BasketValueDto
//    {
//        Description = "Commande d'échantillons",
//        Value = "ECH"
//    }
//        };


//        //salesOrigins P0130140
//        public static List<BasketValueDto?> salesOriginsP0130140 = new List<BasketValueDto?>
//        {
//    new BasketValueDto { Value = "" },
//    new BasketValueDto { Value = "Téléphone" },
//    new BasketValueDto { Value = "E-mail" },
//    new BasketValueDto { Value = "Fax" },
//    new BasketValueDto { Value = "Courrier" },
//    new BasketValueDto { Value = "Comptoir" },
//    new BasketValueDto { Value = "Chat" },
//    new BasketValueDto { Value = "E-Proc" },
//    new BasketValueDto { Value = "Sortant" },
//    new BasketValueDto { Value = "Internet" },
//    new BasketValueDto { Value = "Auto" },
//    new BasketValueDto { Value = "EDI" },
//    new BasketValueDto { Value = "Terrain" },
//    new BasketValueDto { Value = "Interne" }
//        };


//        //webOrigins P0130140
//        public static List<BasketValueDto?> webOriginsP0130140 = new List<BasketValueDto?>
//{
//    new BasketValueDto { Value = "" },
//    new BasketValueDto { Value = "3M" },
//    new BasketValueDto { Value = "Air Liquide" },
//    new BasketValueDto { Value = "AIRBUS" },
//    new BasketValueDto { Value = "ALSTOM" },
//    new BasketValueDto { Value = "AMAZON" },
//    new BasketValueDto { Value = "ARIBA" },
//    new BasketValueDto { Value = "BIRCHSTREET" },
//    new BasketValueDto { Value = "BOSCH" },
//    new BasketValueDto { Value = "BURBERRY" },
//    new BasketValueDto { Value = "BUT" },
//    new BasketValueDto { Value = "Catalogue" },
//    new BasketValueDto { Value = "CEVA" },
//    new BasketValueDto { Value = "CHRHANSEN" },
//    new BasketValueDto { Value = "COUPA" },
//    new BasketValueDto { Value = "COUPAAdvantage" },
//    new BasketValueDto { Value = "CPO" },
//    new BasketValueDto { Value = "CPOSolution" },
//    new BasketValueDto { Value = "DAHER" },
//    new BasketValueDto { Value = "DBSCHENKER" },
//    new BasketValueDto { Value = "DECATHLON" },
//    new BasketValueDto { Value = "DESKTOP" },
//    new BasketValueDto { Value = "DETERMINE" },
//    new BasketValueDto { Value = "DFS" },
//    new BasketValueDto { Value = "EBAY" },
//    new BasketValueDto { Value = "EDILIANS" },
//    new BasketValueDto { Value = "ELCO" },
//    new BasketValueDto { Value = "E-PROC" },
//    new BasketValueDto { Value = "ESKER" },
//    new BasketValueDto { Value = "ETEX" },
//    new BasketValueDto { Value = "EUROFINS" },
//    new BasketValueDto { Value = "HAXONEO" },
//    new BasketValueDto { Value = "HAXONEO_C0152435" },
//    new BasketValueDto { Value = "HAXONEO-C0152435" },
//    new BasketValueDto { Value = "HERMES" },
//    new BasketValueDto { Value = "IKEA" },
//    new BasketValueDto { Value = "IKEA_ARIBA" },
//    new BasketValueDto { Value = "KERRY" },
//    new BasketValueDto { Value = "LaPoste" },
//    new BasketValueDto { Value = "LEROY-SOMER" },
//    new BasketValueDto { Value = "M. BRICOLAGE" },
//    new BasketValueDto { Value = "MOBILE" },
//    new BasketValueDto { Value = "MONOPRIX" },
//    new BasketValueDto { Value = "MyPlatform" },
//    new BasketValueDto { Value = "NEWELL" },
//    new BasketValueDto { Value = "NEXANS" },
//    new BasketValueDto { Value = "NIKE" },
//    new BasketValueDto { Value = "OPELLA" },
//    new BasketValueDto { Value = "ORANGE" },
//    new BasketValueDto { Value = "ORANGE-OTL" },
//    new BasketValueDto { Value = "RAJA_AT" },
//    new BasketValueDto { Value = "RAJA_BE" },
//    new BasketValueDto { Value = "RAJA_CENPAC" },
//    new BasketValueDto { Value = "RAJA_CH" },
//    new BasketValueDto { Value = "RAJA_CZ" },
//    new BasketValueDto { Value = "RAJA_DE" },
//    new BasketValueDto { Value = "RAJA_DK" },
//    new BasketValueDto { Value = "RAJA_ES" },
//    new BasketValueDto { Value = "RAJA_IT" },
//    new BasketValueDto { Value = "RAJA_NEQST" },
//    new BasketValueDto { Value = "RAJA_NO" },
//    new BasketValueDto { Value = "RAJA_PL" },
//    new BasketValueDto { Value = "RAJA_PT" },
//    new BasketValueDto { Value = "RAJA_SE" },
//    new BasketValueDto { Value = "RAJA_SK" },
//    new BasketValueDto { Value = "RAJA_TCENPAC" },
//    new BasketValueDto { Value = "RAJA_UK" },
//    new BasketValueDto { Value = "RAJABUTTON" },
//    new BasketValueDto { Value = "SAFRAN" },
//    new BasketValueDto { Value = "SANOFI" },
//    new BasketValueDto { Value = "SGS" },
//    new BasketValueDto { Value = "SIEMENS" },
//    new BasketValueDto { Value = "SIEMENS GAMESA" },
//    new BasketValueDto { Value = "SIEMENSE" },
//    new BasketValueDto { Value = "SIEMENSFR" },
//    new BasketValueDto { Value = "SKF" },
//    new BasketValueDto { Value = "SOLVAYRHODIA" },
//    new BasketValueDto { Value = "SOR_BUTTON" },
//    new BasketValueDto { Value = "STACI" },
//    new BasketValueDto { Value = "TASTER" },
//    new BasketValueDto { Value = "TOTAL" },
//    new BasketValueDto { Value = "UNILEVER" },
//    new BasketValueDto { Value = "URGO" },
//    new BasketValueDto { Value = "VAILLANT" },
//    new BasketValueDto { Value = "WELCOMEOFFICE" },
//    new BasketValueDto { Value = "XPO" },
//    new BasketValueDto { Value = "YVES ROCHER" }
//};


//        //procedureCall => SalesOrigin = Internet P0130140
//        public static ProcedureCallResponseDto procedureCallResponseP0130140_1 = new ProcedureCallResponseDto
//        {
//            Success = true,
//            Message = "Property SalesOriginId updated with value Internet",
//            UpdateDone = true,
//            RefreshCalls = new List<string?>
//    {
//        "generalInfo",
//        "notifications",
//        "orderInfo",
//        "pricesInfo",
//        "invoiceInfo"
//    }
//        };


//        //procedureCall => RAJ_WebSalesId = W01234567 P0130140
//        public static ProcedureCallResponseDto procedureCallResponseP0130140_2 = new ProcedureCallResponseDto
//        {
//            Success = true,
//            Message = "Property RAJ_WebSalesId updated with value W01234567",
//            UpdateDone = true,
//            RefreshCalls = new List<string?>
//                {
//                    "generalInfo",
//                    "notifications"
//                }
//        };


//        //procedureCall => MayLastColumnDiscount = true   P0130140
//        public static ProcedureCallResponseDto procedureCallResponseP0130140_3 = new ProcedureCallResponseDto
//        {
//            Success = true,
//            Message = "Property MyLastColumnDiscount updated with value True",
//            UpdateDone = true,
//            RefreshCalls = new List<string?>
//    {
//        "generalInfo",
//        "notifications",
//        "pricesInfo",
//        "orderLines"
//    }
//        };


//        //procedureCall => UpdateContact(OrderBy, X2567124 P0130140
//        public static ProcedureCallResponseDto procedureCallResponseP0130140_4 = new ProcedureCallResponseDto
//        {
//            Success = true,
//            Message = "Contact X2567124 updated",
//            UpdateDone = true,
//            RefreshCalls = new List<string?>
//    {
//        "generalInfo",
//        "notifications"
//    }
//        };


//        // procedureCall => addorderLine(CAS10,100)   P0130140
//        public static ProcedureCallResponseDto procedureCallResponseP0130140_5 = new ProcedureCallResponseDto
//        {
//            Success = true,
//            Message = "No line added",
//            UpdateDone = false,
//            RefreshCalls = new List<string?>()
//        };


//        //orderInfo => Check update values P0130140
//        public static BasketOrderInfoDto orderInfoP0130140_2 = new BasketOrderInfoDto
//        {
//            Account = new Field<AccountDto?>
//            {
//                Name = "Compte commandeur",
//                Status = "onlyForDisplay",
//                Value = new AccountDto
//                {
//                    AccountId = "A1619563",
//                    Name = "COQUILLAGE NACRE",
//                    Recipient = "",
//                    Building = "",
//                    Street = "2 RUE BINET",
//                    Locality = "",
//                    ZipCode = "60000",
//                    City = "BEAUVAIS",
//                    Country = "FRANCE",
//                    Email = "",
//                    Phone = "0621434586",
//                    CellularPhone = "",
//                    Blocked = false
//                }
//            },
//            Contact = new Field<ContactDto?>
//            {
//                Name = "Contact commandeur",
//                Status = "readOnly",
//                Value = new ContactDto
//                {
//                    ContactId = null,
//                    SocialTitle = null,
//                    FirstName = null,
//                    LastName = null,
//                    Email = null,
//                    Phone = null,
//                    CellularPhone = null
//                }
//            },
//            ActivityArea = new Field<string?>
//            {
//                Name = "Secteur d'activité",
//                Status = "onlyForDisplay",
//                Value = null
//            },
//            CustomerTags = new List<BasketValueDto?>
//    {

//         new BasketValueDto { Description = "Client VIP", Value = "vip" }
//    },
//            SalesOriginId = new Field<BasketValueDto?>
//            {
//                Name = "Canal de vente",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = "Internet",
//                    Description = ""
//                },
                
//            },
//            WebOriginId = new Field<BasketValueDto?>
//            {
//                Name = "Origine e-commerce",
//                Status = "readWrite",
//                Value = new BasketValueDto()
//                {
//                    Value = "DESKTOP",
//                    Description = ""
//                },
               
//            },
//            SalesPoolId = new Field<BasketValueDto?>
//            {
//                Name = "Type de transaction",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = "NOR",
//                    Description = ""
//                },
               
//            },
//            CustomerOrderRef = new Field<string?>
//            {
//                Name = "Référence Client",
//                Status = "readOnly",
//                Value = "visa"
//            },
//            WebSalesId = new Field<string?>
//            {
//                Name = "Commande Web",
//                Status = "readWrite",
//                Value = "W01234567"
//            },
//            RelatedLink = new Field<string?>
//            {
//                Name = "Devis",
//                Status = "hidden",
//                Value = ""
//            },
//            Note = new Field<string?>
//            {
//                Name = "Note de RC",
//                Status = "onlyForDisplay",
//                Value = ""
//            }
//        };


//        //deliveryInfo P0130140
//        public static BasketDeliveryInfoDto deliveryInfoP0130140 = new BasketDeliveryInfoDto
//        {
//            Account = new Field<AccountDto?>
//            {
//                Name = "Compte de livraison",
//                Status = "readOnly",
//                Value = new AccountDto
//                {
//                    AccountId = null,
//                    Name = null,
//                    Recipient = null,
//                    Building = null,
//                    Street = null,
//                    Locality = null,
//                    ZipCode = null,
//                    City = null,
//                    Country = null,
//                    Email = null,
//                    Phone = null,
//                    CellularPhone = null,
//                    Blocked = false
//                }
//            },
//            Contact = new Field<ContactDto?>
//            {
//                Name = "Contact de livraison",
//                Status = "readOnly",
//                Value = new ContactDto
//                {
//                    ContactId = null,
//                    SocialTitle = null,
//                    FirstName = null,
//                    LastName = null,
//                    Email = null,
//                    Phone = null,
//                    CellularPhone = null
//                }
//            },
//            DeliveryMode = new Field<BasketValueDto?>
//            {
//                Name = "Mode de livraison",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = null,
//                    Description = ""
//                },
              
//            },
//            CompleteDelivery = new Field<bool?>
//            {
//                Name = "Livraison complète",
//                Status = "readOnly",
//                Value = false
//            },
//            ImperativeDate = new Field<DateTime?>
//            {
//                Name = "Date impérative",
//                Status = "readOnly",
//                Value = null
//            },
//            OrderDocuments = new Field<string?>
//            {
//                Name = "BL / Factures",
//                Status = "hidden",
//                Value = ""
              
//            },
//            Note = new Field<string?>
//            {
//                Name = "Note de livraison",
//                Status = "readOnly",
//                Value = null
//            },
//            NoteMustBeSaved = new Field<bool?>
//            {
//                Name = "Sauvegarde note de liv.",
//                Status = "readOnly",
//                Value = false,
//                Description = "Sauvegarde pour les prochaines commandes"
//            }
//        };


//        //deliverToAccounts P0130140
//        public static List<AccountDto?> deliverToAccountsP0130140 = new List<AccountDto?>
//{
//    new AccountDto
//    {
//        AccountId = "",
//        Name = "-- Aucune adresse renseignée --",
//        Recipient = null,
//        Building = null,
//        Street = "-- Aucune adresse renseignée --",
//        Locality = null,
//        ZipCode = null,
//        City = null,
//        Country = null,
//        Email = null,
//        Phone = null,
//        CellularPhone = null,
//        Blocked = false
//    }
//};


//        //deliverToContacts P0130140
//        public static List<ContactDto?> deliverToContactsP0130140 = new List<ContactDto?>
//{
//    new ContactDto
//    {
//        ContactId = "",
//        SocialTitle = null,
//        FirstName = null,
//        LastName = "-- Aucun contact renseigné --",
//        Email = null,
//        Phone = null,
//        CellularPhone = null
//    }
//};


//        //deliveryModes P0130140
//        public static List<BasketValueDto?> deliveryModesP0130140 = new List<BasketValueDto?>
//{
//    new BasketValueDto { Value = "Catalogue" },
//    new BasketValueDto { Value = "Enlèvement" },
//    new BasketValueDto { Value = "Export" },
//    new BasketValueDto { Value = "Filiale" },
//    new BasketValueDto { Value = "Interne" },
//    new BasketValueDto { Value = "VCT" }
//};


//        //invoiceInfo P0130140
//        public static BasketInvoiceInfoDto invoiceInfoP0130140 = new BasketInvoiceInfoDto
//        {
//            Account = new Field<AccountDto?>
//            {
//                Name = "Compte de facturation",
//                Status = "readOnly",
//                Value = new AccountDto
//                {
//                    AccountId = null,
//                    Name = null,
//                    Recipient = null,
//                    Building = null,
//                    Street = null,
//                    Locality = null,
//                    ZipCode = null,
//                    City = null,
//                    Country = null,
//                    Email = null,
//                    Phone = null,
//                    CellularPhone = null,
//                    Blocked = false
//                }
//            },
//            SiretId = new Field<string?>
//            {
//                Name = "Siret",
//                Status = "onlyForDisplay",
//                Value = null
//            },
//            TaxGroup = new Field<BasketValueDto?>
//            {
//                Name = "Groupe de taxe",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = null,
//                    Description = ""
//                }
               
//            },
//            PaymentTerm = new Field<BasketValueDto?>
//            {
//                Name = "Conditions de paiement",
//                Status = "onlyForDisplay",
//                Value = new BasketValueDto()
//                {
//                    Value = null,
//                    Description = ""
//                },
               
//            },
//            PaymentMode = new Field<BasketValueDto?>
//            {
//                Name = "Mode de paiement",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = null,
//                    Description = ""
//                },
                
//            },
//            IsPublicEntity = false,
//            PublicEntityExecutingService = new Field<string?>
//            {
//                Name = "Service exécutif",
//                Status = "readOnly",
//                Value = null
//            },
//            PublicEntityLegalCommitment = new Field<string?>
//            {
//                Name = "Engagement juridique",
//                Status = "readOnly",
//                Value = null
//            },
//            Note = new Field<string?>
//            {
//                Name = null,
//                Status = "onlyForDisplay",
//                Value = ""
//            }
//        };


//        //invoiceToAccounts P0130140
//        public static List<AccountDto?> invoiceToAccountsP0130140 = new List<AccountDto?>
//{
//    new AccountDto
//    {
//        AccountId = "",
//        Name = "-- Aucune adresse renseignée --",
//        Recipient = null,
//        Building = null,
//        Street = "-- Aucune adresse renseignée --",
//        Locality = null,
//        ZipCode = null,
//        City = null,
//        Country = null,
//        Email = null,
//        Phone = null,
//        CellularPhone = null,
//        Blocked = false
//    }
//};


//        //TaxGroups P0130140
//        public static List<BasketValueDto?> taxGroupsP0130140 = new List<BasketValueDto?>
//{
//    new BasketValueDto { Value = "" },
//    new BasketValueDto { Description = "France Autoliquidation", Value = "F-AUTOLIQ" },
//    new BasketValueDto { Description = "France TVA sur les débits", Value = "F-DEB" },
//    new BasketValueDto { Description = "France TVA sur les débits Escompte", Value = "F-DEBTVA" },
//    new BasketValueDto { Description = "France TVA sur les encaissements", Value = "F-ENC" },
//    new BasketValueDto { Description = "France TVA sur les encaissements Escompte", Value = "F-ENCTVA" },
//    new BasketValueDto { Description = "France exonéré", Value = "F-EXO" },
//    new BasketValueDto { Description = "TVA sur factures à émettre", Value = "F-FAE" },
//    new BasketValueDto { Description = "France SMICTOM TVA 7%", Value = "F-SMI" },
//    new BasketValueDto { Description = "Tiers hors UE vente", Value = "HUE" },
//    new BasketValueDto { Description = "Tiers Hors UE achat", Value = "HUE-AC" },
//    new BasketValueDto { Description = "Monaco TVA sur les débits", Value = "M-DEB" },
//    new BasketValueDto { Description = "Monaco EXONERE (Attestation)", Value = "M-EXO" },
//    new BasketValueDto { Description = "TVA union européenne achat", Value = "UE-AC" },
//    new BasketValueDto { Description = "TVA union européenne vente", Value = "UE-VE" },
//    new BasketValueDto { Description = "TVA FNP à régulariser", Value = "ZF-FNP" }
//};


//        //paymentModes P0130140
//        public static List<BasketValueDto?> paymentModesP0130140 = new List<BasketValueDto?>
//{
//    new BasketValueDto { Description = null, Value = "" },
//    new BasketValueDto { Description = "Carte Bancaire", Value = "CB" },
//    new BasketValueDto { Description = "Chèque", Value = "CH" },
//    new BasketValueDto { Description = "Paypal", Value = "PAYPAL" },
//    new BasketValueDto { Description = "Préautorisation CB", Value = "PCB" },
//    new BasketValueDto { Description = "Carte Bancaire Manuelle", Value = "TPE" },
//    new BasketValueDto { Description = "Virement Marketplace La Poste", Value = "VMP" },
//    new BasketValueDto { Description = "Préautorisation CB manuelle", Value = "ZCB" },
//    new BasketValueDto { Description = "Paypal sur Ebay", Value = "ZEBAY" },
//    new BasketValueDto { Description = "Préautorisation PC manuelle", Value = "ZPC" },
//    new BasketValueDto { Description = "Préautorisation Paypal manuelle", Value = "ZPY" }
//};


//        //tradeInfo P0130140
//        public static BasketTradeInfoDto tradeInfoP0130140 = new BasketTradeInfoDto
//        {
//            Turnover = new Field<List<BasketTurnoverLineDto?>>
//            {
//                Name = "Chiffre d'affaire",
//                Status = "onlyForDisplay",
//                Value = new List<BasketTurnoverLineDto?>
//        {
//            new BasketTurnoverLineDto
//            {
//                Name = "Classe",
//                Ytd = "99",
//                YtdN1 = "",
//                N1 = "99",
//                N2 = "99"
//            },
//            new BasketTurnoverLineDto
//            {
//                Name = "CA.",
//                Ytd = "€",
//                YtdN1 = "€",
//                N1 = "€",
//                N2 = "€"
//            },
//            new BasketTurnoverLineDto
//            {
//                Name = "Evol. CA.",
//                Ytd = "%",
//                YtdN1 = "",
//                N1 = "",
//                N2 = ""
//            }
//        }
//            },
//            Contract = new BasketContractInfoDto
//            {
//                ContractId = new Field<string>
//                {
//                    Name = "Contrat",
//                    Status = "onlyForDisplay",
//                    Value = null
//                },
//                ContractType = new Field<string>
//                {
//                    Name = "Type",
//                    Status = "onlyForDisplay",
//                    Value = null
//                },
//                ContractGroup = new Field<string>
//                {
//                    Name = "Groupe de contrat",
//                    Status = "onlyForDisplay",
//                    Value = ""
//                },
//                Status = new Field<string>
//                {
//                    Name = "Statut",
//                    Status = "onlyForDisplay",
//                    Value = null
//                },
//                StartDate = new Field<string>
//                {
//                    Name = "Date de début",
//                    Status = "onlyForDisplay",
//                    Value = null
//                },
//                EndDate = new Field<string>
//                {
//                    Name = "Date de fin",
//                    Status = "onlyForDisplay",
//                    Value = null
//                },
//                CampaignId = new Field<string>
//                {
//                    Name = "Campagne de prix",
//                    Status = "onlyForDisplay",
//                    Value = null
//                },
//                MainContact = new Field<string>
//                {
//                    Name = "Commercial terrain",
//                    Status = "onlyForDisplay",
//                    Value = null
//                },
//                OfficeExecutive = new Field<string>
//                {
//                    Name = "Commercial sédentaire",
//                    Status = "onlyForDisplay",
//                    Value = null
//                },
//                DiscountList = new Field<List<string?>>
//                {
//                    Name = "Description",
//                    Status = "onlyForDisplay",
//                    Value = new List<string?>()
//                }
//            }
//        };


//        //pricesInfo P0130140
//        public static BasketPricesInfoDto pricesInfoP0130140 = new BasketPricesInfoDto
//        {
//            Coupon = new Field<BasketValueDto?>
//            {
//                Name = "Code Action",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = "",
//                    Description = ""
//                },
                
//            },
//            FreeShippingAmountThreshold = new Field<decimal?>
//            {
//                Name = "Diff Franco",
//                Status = "onlyForDisplay",
//                Value = null
//            },
//            GiftAmountThreshold = new Field<decimal?>
//            {
//                Name = "Diff KDO",
//                Status = "onlyForDisplay",
//                Value = null
//            },
//            ProductsInfo = new Field<string?>
//            {
//                Name = "Dispo. Marchandise",
//                Status = "onlyForDisplay",
//                Value = null
//            },
//            ProductsNetAmount = new Field<decimal?>
//            {
//                Name = "Marchandise HT",
//                Status = "onlyForDisplay",
//                Value = 0
//            },
//            WarrantyCostOption = new Field<BasketValueDto?>
//            {
//                Name = "Type de garantie optimale",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = "Disabled",
//                    Description = ""
//                },
               
//            },
//            WarrantyCostAmount = new Field<decimal?>
//            {
//                Name = "Montant de la garantie optimale",
//                Status = "onlyForDisplay",
//                Value = 0
//            },
//            ShippingCostOption = new Field<BasketValueDto?>
//            {
//                Name = "Type de frais de port",
//                Status = "readOnly",
//                Value = new BasketValueDto()
//                {
//                    Value = "Disabled",
//                    Description = ""
//                },
                
//            },
//            ShippingCostAmount = new Field<decimal?>
//            {
//                Name = "Montant des frais de port",
//                Status = "readOnly",
//                Value = 0
//            },
//            LogisticInfo = null,
//            TotalNetAmount = new Field<decimal?>
//            {
//                Name = "Montant Total HT",
//                Status = "onlyForDisplay",
//                Value = 0
//            },
//            VatAmount = new Field<decimal?>
//            {
//                Name = "Montant TVA",
//                Status = "onlyForDisplay",
//                Value = 0
//            },
//            TotalGrossAmount = new Field<decimal?>
//            {
//                Name = "Montant TTC",
//                Status = "onlyForDisplay",
//                Value = 0
//            },
//            OrderDiscountRate = new Field<int?>
//            {
//                Name = "Remise Cde (%)",
//                Status = "readOnly",
//                Value = 0
//            },
//            OrderLastColumnDiscount = new Field<bool?>
//            {
//                Name = "Remise Cde DC",
//                Status = "readOnly",
//                Value = false
//            },
//            AdditionalSalesAmount = new Field<decimal?>
//            {
//                Name = "Ventes add. (€)",
//                Status = "onlyForDisplay",
//                Value = 0
//            },
//            DiscountAmount = new Field<decimal?>
//            {
//                Name = "Remise Cde (€)",
//                Status = "onlyForDisplay",
//                Value = 0
//            },
//            TotalWeight = new Field<decimal?>
//            {
//                Name = "Poids (kg)",
//                Status = "onlyForDisplay",
//                Value = 0
//            },
//            TotalVolume = new Field<decimal?>
//            {
//                Name = "Volume (m3)",
//                Status = "onlyForDisplay",
//                Value = 0
//            }
//        };


//        //coupons PriceLines info section   P0130140
//        public static List<BasketValueDto?> couponsP0130140 = new List<BasketValueDto?>
//{
//    new BasketValueDto { Description = null, Value = "" },
//    new BasketValueDto { Description = "COMMANDES nefab  2010\nCODE PAR DEFAUT\nVALIDITE INDETERMINEE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis", Value = "AC0100" },
//    new BasketValueDto { Description = "COMMANDES AIRBUS  2011-2012\nCODE PAR DEFAUT\nVALIDITE INDETERMINE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis", Value = "AIRBUS" },
//    new BasketValueDto { Description = "OFFERT dès 200 EUROS : CADEAU COFFRET LA MERE POULARD\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "BISCUITS830" },
//    new BasketValueDto { Description = "DEMANDES DE CATALOGUES", Value = "CAT24" },
//    new BasketValueDto { Description = "DEMANDES DE CATALOGUES CLIENTS", Value = "CATC24" },
//    new BasketValueDto { Description = "DEMANDES DE CATALOGUES PROSPECTS", Value = "CATP24" },
//    new BasketValueDto { Description = "Validité au 31/12/2024\nAucun cadeau\nPas de welcome pack", Value = "CRC24R" },
//    new BasketValueDto { Description = "DEMANDES DE CATALOGUES PROSPECTS", Value = "ECATP24" },
//    new BasketValueDto { Description = "DEMANDES D'ECHANTILLONS CLIENTS", Value = "ECHC24" },
//    new BasketValueDto { Description = "DEMANDES D'ECHANTILLONS PROSPECTS", Value = "ECHP24" },
//    new BasketValueDto { Description = "OFFERT dès 400 EUROS : CADEAU APPAREIL FONDUE\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "FONDUE172" },
//    new BasketValueDto { Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024", Value = "G032400" },
//    new BasketValueDto { Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024", Value = "G032401" },
//    new BasketValueDto { Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024", Value = "G032408" },
//    new BasketValueDto { Description = "OFFERT dès 300 EUROS : CADEAU GAUFFRIER\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "GAUFFRES211" },
//    new BasketValueDto { Description = "catalogue entretien et hygiène avril 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024", Value = "J042401" },
//    new BasketValueDto { Description = "Commandes export 2024\nCode par défaut\n350€ HT minimum marchandises\nValidité au 31/12/2024\nAucun cadeau\nPas de welcome pack", Value = "L012400" },
//    new BasketValueDto { Description = "MARKET PLACE LAPOSTE\nFrais de port 9,90€", Value = "LAPOSTE" },
//    new BasketValueDto { Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS", Value = "NWELCOME" },
//    new BasketValueDto { Description = "OFFERT dès 99 EUROS : CADEAU TROUSSE A OUTILS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "OUTILS830" },
//    new BasketValueDto { Description = "OFFERT dès 300 EUROS : CADEAU MACHINE POP CORN\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "POPCORN293" },
//    new BasketValueDto { Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS", Value = "PRIVILEGE" },
//    new BasketValueDto { Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025", Value = "RAJABLOG" },
//    new BasketValueDto { Description = "OFFERT dès 400 EUROS : CADEAU COFFRET RITUALS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "RITUALS162" },
//    new BasketValueDto { Description = "OFFERT dès 99 EUROS : CADEAU BOUTEILLE ISOTHERME YOKO \nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "SOIF483" },
//    new BasketValueDto { Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025", Value = "THANKYOU" },
//    new BasketValueDto { Description = "OFFERT dès 200 EUROS : CADEAU THEIERE NOMADE YOKO\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "THEIERE749" },
//    new BasketValueDto { Description = "WEB  MARS 24\nwelcome pack si nouveaux clients", Value = "W032400" },
//    new BasketValueDto { Description = "WEB  AVRIL 24\nwelcome pack si nouveaux clients", Value = "W042400" },
//    new BasketValueDto { Description = "WEB  MAI 24\nwelcome pack si nouveaux clients", Value = "W052400" },
//    new BasketValueDto { Description = "WEB  JUIN 24\nwelcome pack si nouveaux clients", Value = "W062400" },
//    new BasketValueDto { Description = "WEB  JUILLET 24\nwelcome pack si nouveaux clients", Value = "W072400" },
//    new BasketValueDto { Description = "WEB  AOUT 24\nwelcome pack si nouveaux clients", Value = "W082400" },
//    new BasketValueDto { Description = "WEB CATALOGUES ELECTRONIQUES CODE PAR DEFAUT VALIDITE AU 31/12/2024 AUCUN CADEAU PAS DE WELCOME PACK", Value = "W24999" },
//    new BasketValueDto { Description = "Offre de bienvenue : livraison offerte dès 149€ ht + 15% remise", Value = "WBIENVENUE" },
//    new BasketValueDto { Description = "Offre nouveaux clients : SEPT22 CLIENTS\nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS\nVALIDITE AU 28/02/2023", Value = "WELCOMEPACK" },
//    new BasketValueDto { Description = "TARIFS FILIALES MARS 24\nVALIDITE AU 31/08/2024", Value = "Y032400" }
//};


//        //warrantyCostOptions PriceLines info section   P0130140
//        public static List<BasketValueDto?> warrantyCostOptionsP0130140 = new List<BasketValueDto?>
//{
//    new BasketValueDto { Description = "GO activée", Value = "Enabled" },
//    new BasketValueDto { Description = "GO désactivée", Value = "Disabled" },
//    new BasketValueDto { Description = "GO offerte", Value = "Offered" }
//};


//        //shippingCostOptions PriceLines info section   P0130140
//        public static List<BasketValueDto?> shippingCostOptionsP0130140 = new List<BasketValueDto?>
//{
//    new BasketValueDto { Description = "Frais de livraison", Value = "Standard" },
//    new BasketValueDto { Description = "Frais de liv. offerts", Value = "Offered" }
//};

//    }

       
//}
