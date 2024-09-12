using MyOrder.Shared.Dtos;
using MyOrder.Shared.Dtos.Lines;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Infrastructure.Data
{
    public static class SampleData
    {
        // P0130938

        //  api/orderContext/P0130938/generalInfo   P0130938
        public static BasketGeneralInfoDto generalInfoP0130938 = new()
        {
            OrderType = "Panier",
            BasketId = "P0130938",
            OrderId = "P0131323",
            OrderStatus = "Annulé",
            OrderDate = "2024-07-15 17:04:31",
            SalesResponsible = "CEDRIC REVILLON"
        };

        public static BasketNotificationDto NotificationP0130938 = new()
        {
            Notifications = new List<NotificationDto?>()
            {
                  new NotificationDto
                    {
                    NotificationId = 1,
                 Severity = "Info",
                 Message = "<strong>[Commande]</strong> Notes de commande: INDIQUER LE NOM DU DESTINATAIRE 0CA 14H50 18/01/16",
                 CreatedDate = new DateTime(1, 1, 1, 0, 0, 0),
                 ProcedureCall = new List<string?> { "RemoveLog", "1" }
                 },
                new NotificationDto
                {
                    NotificationId = 2,
                    Severity = "Warning",
                    Message = "<strong>[Stock]</strong> Low stock warning for item XYZ123",
                 CreatedDate = new DateTime(2024, 9, 1, 9, 30, 0),
                 ProcedureCall = new List<string?> { "UpdateStock", "2" }
                }
            }
        };


        // orderInfo   P0130938
        public static BasketOrderInfoDto orderInfoP0130938 = new BasketOrderInfoDto()
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
            ActivityArea = new Field<string?>
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
            SalesOriginId = new Field<string?>
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
            WebOriginId = new Field<string?>
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
            SalesPoolId = new Field<string?>
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
            CustomerOrderRef = new Field<string?>
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
            WebSalesId = new Field<string?>
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
            RelatedLink = new Field<string?>
            {
                Name = "Devis",
                Status = "hidden",
                Value = ""
            },
            Note = new Field<string?>
            {
                Name = "Note de RC",
                Status = "onlyForDisplay",
                Value = "29/10/2019 ******A TRAITER PAR L'EQUIPE VIP*******LORS DE LA SAISIE DES COMMANDES LE COMPTE D IMPUTATION ET LE NUMERO DE COMMANDE SONT OBLIGATOIRES 03/11/2022  SGR ATTENTION  SUR ORDRE DE MR ARINO NE PAS NOTER DANS LE NO DE CDE  BDC-  MAIS JUSTE LA SUITE CAR SINON NE VOIT PAS LES NUMEROS EN ENTIERS,"
            }
        };


        // orderByContacts   P0130938
        public static List<ContactDto?> orderByContactsP0130938 = new List<ContactDto?>()
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
            };


        //customerTags   P0130938
        public static List<BasketValueDto?> customerTagsP0130938 = new List<BasketValueDto?>()
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
            };


        //salesPools   P0130938
        public static List<BasketValueDto?> salesPoolsP0130938 = new List<BasketValueDto?>()
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
            };


        //salesOrigins   P0130938
        public static List<SalesOriginDto?> salesOriginsP0130938 = new List<SalesOriginDto?>()
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
            };


        //webOrigins   P0130938
        public static List<BasketValueDto?> webOriginsP0130938 = new List<BasketValueDto?>()
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
            };


        //procedureCall => MayLastColumnDiscount = true   P0130938
        public static ProcedureCallResponseDto procedureCallResponseP0130938_3 = new ProcedureCallResponseDto()
        {
            Success = true,
            Message = "Procedure completed successfully.",
            ErrorCause = null,
            UpdateDone = true,
            RefreshCalls = new List<string?> { "generalInfo", "pricesInfo", "invoiceInfo", "orderInfo", "tradeInfo", "deliveryInfo" }
        };


        //deliveryInfo   P0130938                                                           
        public static BasketDeliveryInfoDto deliveryInfoP0130938 = new BasketDeliveryInfoDto()
        {
            Account = new Field<AccountDto?>
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
            Contact = new Field<ContactDto?>
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
            DeliveryMode = new Field<string?>
            {
                Name = "Mode de livraison",
                Status = "readWrite",
                Value = "Catalogue",
                ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "RAJ_GenericDlvMode", "System.String", "<one of /deliveryModes value>" }

            },
            CompleteDelivery = new Field<bool?>
            {
                Name = "Livraison complète",
                Status = "readWrite",
                Value = false

            },
            ImperativeDate = new Field<DateTime?>
            {
                Name = "Date impérative",
                Status = "required",
                Value = DateTime.ParseExact("12/09/2024", "dd/MM/yyyy", null),
                ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "RAJ_ImperativeDate", "DateTime", "<value>" }

            },
            OrderDocuments = new Field<List<string?>?>
            {
                Name = "BL / Factures",
                Status = "hidden",
                Value = new List<string?>()

            },
            Note = new Field<string?>
            {
                Name = "Note de livraison",
                Status = "readWrite",
                Value = "",
                ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", 
                                                    "DeliveryNote", 
                                                    "System.DateTime", 
                                                    "<value>" }
            },
            NoteMustBeSaved = new Field<bool?>
            {
                Name = "Sauvegarde note de liv.",
                Status = "readWrite",
                Value = true,
                ProcedureCall = new List<string?> { "UpdateOrderTablePropertyValue", "IsDeliveryNoteSaved", "System.Boolean", "<value>" }

            }
        };


        //deliverToAccounts   P0130938
        public static List<AccountDto?> deliverToAccountsP0130938 = new List<AccountDto?>()
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
            };


        //deliverToContacts   P0130938
        public static List<ContactDto?> deliverToContactsP0130938 = new List<ContactDto?>()
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
            };


        //deliveryModes   P0130938
        public static List<BasketValueDto?> deliveryModesP0130938 = new List<BasketValueDto?>()
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
            };


        //invoiceInfo   P0130938
        public static BasketInvoiceInfoDto invoiceInfoP0130938 = new BasketInvoiceInfoDto()
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
                Value = null
            }
        };


        //invoiceToAccounts   P0130938
        public static List<AccountDto?> invoiceToAccountsP0130938 = new List<AccountDto?>()
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
            };


        //TaxGroups   P0130938
        public static List<BasketValueDto?> taxGroupsP0130938 = new List<BasketValueDto?>()
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
            };


        //paymentModes   P0130938
        public static List<BasketValueDto?> paymentModesP0130938 = new List<BasketValueDto?>()
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
            };


        //tradeInfo   P0130938
        public static BasketTradeInfoDto tradeInfoP0130938 = new BasketTradeInfoDto()
        {
            Turnover = new Field<List<BasketTurnoverLineDto?>>
            {
                Name = "Chiffre d'affaire",
                Status = "onlyForDisplay",
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
                ContractId = new Field<string?>
                {
                    Name = "Contrat",
                    Status = "onlyForDisplay",
                    Value = "CT072408"

                },
                ContractType = new Field<string?>
                {
                    Name = "Type",
                    Status = "onlyForDisplay",
                    Value = "Conditions Spéciales"

                },
                ContractGroup = new Field<string?>
                {
                    Name = "Groupe de contrat",
                    Status = "onlyForDisplay",
                    Value = "CHRONOPOST SA"
                },
                Status = new Field<string?>
                {
                    Name = "Statut",
                    Status = "onlyForDisplay",
                    Value = "En cours"
                },
                StartDate = new Field<string?>
                {
                    Name = "Date de début",
                    Status = "onlyForDisplay",
                    Value = "2024-04-08 00:00:00"
                },
                EndDate = new Field<string?>
                {
                    Name = "Date de fin",
                    Status = "onlyForDisplay",
                    Value = "2024-08-31 00:00:00"
                },
                CampaignId = new Field<string?>
                {
                    Name = "Campagne de prix",
                    Status = "onlyForDisplay",

                    Value = null
                },
                MainContact = new Field<string?>
                {
                    Name = "Commercial terrain",
                    Status = "onlyForDisplay",

                    Value = "ISABELLE LASNIER"
                },
                OfficeExecutive = new Field<string?>
                {
                    Name = "Commercial sédentaire",
                    Status = "onlyForDisplay",

                    Value = "CHRISTELLE BERNIER"
                },
                DiscountList = new Field<List<string?>>
                {
                    Name = "Description",
                    Status = "onlyForDisplay",

                    Value = new List<string?> { "Prix nets sur 49 article(s)", "10% DC sur tout le catalogue" }
                }
            }

        };


        //pricesInfo   P0130938
        public static BasketPricesInfoDto pricesInfoP0130938 = new BasketPricesInfoDto()
        {
            // Column 1
            Coupon = new Field<string?>
            {
                Name = "Code Action",
                Status = "readWrite",

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

                Value = null
            },
            GiftAmountThreshold = new Field<decimal?>
            {
                Name = "Diff KDO",
                Status = "onlyForDisplay",

                Value = null
            },
            ProductsInfo = new Field<string?>
            {
                Name = "Dispo. Marchandise",
                Status = "onlyForDisplay",

                Value = "78% en stock / Liv. Multiple"
            },

            // Column 2
            ProductsNetAmount = new Field<decimal?>
            {
                Name = "Marchandise HT",
                Status = "onlyForDisplay",

                Value = 77.00m
            },
            WarrantyCostOption = new Field<string?>
            {
                Name = "Type de garantie optimale",
                Status = "readWrite",

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

                Value = 0.00m
            },
            ShippingCostOption = new Field<string?>
            {
                Name = "Type de frais de port",
                Status = "readWrite",

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

                Value = 77.00m
            },
            VatAmount = new Field<decimal?>
            {
                Name = "Montant TVA",
                Status = "onlyForDisplay",

                Value = 15.40m
            },
            TotalGrossAmount = new Field<decimal?>
            {
                Name = "Montant TTC",
                Status = "onlyForDisplay",

                Value = 92.40m
            },

            // Column 4
            OrderDiscountRate = new Field<int?>
            {
                Name = "Remise Cde (%)",
                Status = "readWrite",
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

                Value = 0.00m
            },
            AdditionalSalesAmount = new Field<decimal?>
            {
                Name = "Ventes add. (€)",
                Status = "onlyForDisplay",

                Value = 0.00m
            },
            TotalWeight = new Field<decimal?>
            {
                Name = "Poids (kg)",
                Status = "onlyForDisplay",

                Value = 12.67m
            },
            TotalVolume = new Field<decimal?>
            {
                Name = "Volume (m3)",
                Status = "onlyForDisplay",

                Value = 0.095m
            }
        };



    //coupons    Prices info section   P0130938
    public static List<BasketValueDto?> couponsP0130938 = new List<BasketValueDto?>()
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
            };


    //warrantyCostOptions   Prices info section   P0130938
    public static List<BasketValueDto?> warrantyCostOptionsP0130938 = new List<BasketValueDto?>()
            {
                 new BasketValueDto
    {
        Description = "GO non dispo.",
        Value = "10Disabled"
    }

            };


    //shippingCostOptions   Prices info section   P0130938
    public static List<BasketValueDto?> shippingCostOptionsP0130938 = new List<BasketValueDto?>()
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
            };

    // Lines P0130938
    public static BasketOrderLinesDto basketLineDtosP0130938 = new()
    {
        lines = new List<BasketLineDto?>()
            {
            new BasketLineDto
            {
                LineNum = new Field<int?>
                {
                    Name = "N° de ligne",
                    Status = "readWrite",
                    Value = 1
                },
        IsCustomLineNum = false,
        LineTags = new List<BasketValueDto?>(),
        ItemId = new Field<string?>
        {
            Name = "Code article",
            Status = "readWrite",
            Value = "CAS12"
        },
        Name = new Field<string?>
        {
            Name = "Description",
            Status = "readWrite",
            Value = "C.A SC10 27X19X12 BRUN"
        },
        InventLocationId = new Field<string?>
        {
            Name = "Entrepôt",
            Status = "readWrite",
            Value = "PN2"
        },
        SalesQuantity = new Field<int?>
        {
            Name = "Quantité",
            Status = "readWrite",
            Value = 25
        },
        SalesPrice = new Field<decimal?>
        {
            Name = "Prix unitaire",
            Status = "readWrite",
            Value = 0.68m
        },
        DiscountType = new Field<string?>
        {
            Name = "Tarification",
            Status = "readWrite",
            Value = "Default"
        },
        LineAmount = new Field<decimal?>
        {
            Name = "Montant HT",
            Status = "readWrite",
            Value = 17m
        },
        UpdateReason = new Field<string?>
        {
            Name = "Motif Modif.",
            Status = "readWrite",
            Value = ""
        },
        InitialSalesQuantity = new Field<int?>
        {
            Name = "Qté initiale",
            Status = "readWrite",
            Value = 0
        },
        MultipleQuantity = null,
        VatRate = new Field<decimal?>
        {
            Name = "Taux de TVA",
            Status = "readWrite",
            Value = 20
        },
        Note = new Field<string?>
        {
            Name = "Note",
            Status = "OnlyForDisplay",
            Value = ""
        },
        ProductInfo = new Field<string?>
        {
            Name = "Information produit",
            Status = "OnlyForDisplay",
            Value = ""
        },
        IsCustomLogisticFlow = false,
        LogisticFlow = new Field<string?>
        {
            Name = "Flux logistique",
            Status = "readWrite",
            Value = "Stock"
        },
        PhysicalAvailableQuantity = new Field<int?>
        {
            Name = "Livré maintenant",
            Status = "onlyForDisplay",
            Value = 0
        },
        OnOrderQuantity = new Field<int?>
        {
            Name = "A livrer plus tard",
            Status = "onlyForDisplay",
            Value = 25
        },
        PaletteQuantity = new Field<int?>
        {
            Name = "Quantité/palette",
            Status = "onlyForDisplay",
            Value = 1100
        },
        QuantityAtPaletteThreshold = new Field<int?>
        {
            Name = "Diff Palette",
            Status = "onlyForDisplay",
            Value = 1075
        },
        ItemType = new Field<string?>
        {
            Name = "Type d'article",
            Status = "onlyForDisplay",
            Value = "Standard"
        },
        DeliveryDate = new Field<string?>
        {
            Name = "Date de liv.",
            Status = "readWrite",
            Value = null
        },
        IsCustomDeliveryDate = new Field<bool?>
        {
            Name = "Date de liv. manuelle",
            Status = "readWrite",
            Value = false
        },
        ItemPhysicalInventQuantity = new Field<int?>
        {
            Name = "Stock total",
            Status = "onlyForDisplay",
            Value = 3000
        },
        ItemReservPhysicalQuantity = new Field<int?>
        {
            Name = "Stock réservé",
            Status = "onlyForDisplay",
            Value = 3000
        },
        ItemPhysicalAvailableQuantity = new Field<int?>
        {
            Name = "Stock réservé",
            Status = "onlyForDisplay",
            Value = 0
        },
        ItemOnOrderQuantity = new Field<int?>
        {
            Name = "Commandé total",
            Status = "onlyForDisplay",
            Value = 700
        },
        ItemOrderedQuantity = new Field<int?>
        {
            Name = "Commandé total",
            Status = "onlyForDisplay",
            Value = 0
        },
        ItemOrderedAvailableQuantity = new Field<int?>
        {
            Name = "Commandé total",
            Status = "onlyForDisplay",
            Value = 0
        },
        SupplyFamily = new Field<string?>
        {
            Name = "Famille d'appro.",
            Status = "onlyForDisplay",
            Value = "C1 - CAISSES ET CONTAINERS"
        },
        ItemManager = new Field<string?>
        {
            Name = "Gestionnaire",
            Status = "onlyForDisplay",
            Value = "ERIC DAVACH"
        },
        TransportMode = new Field<string?>
        {
            Name = "Mode de transport",
            Status = "onlyForDisplay",
            Value = "PAR DÉFAUT"
        },
        PurchaseId = new Field<string?>
        {
            Name = "Commande d'achat",
            Status = "hidden",
            Value = ""
        },
        DiscountDescription = new Field<string?>
        {
            Name = "Description Tarif",
            Status = "onlyForDisplay",
            Value = "10% DC sur tout le Catalogue"
        },
        DiscountRate = new Field<decimal?>
        {
            Name = "Remise sup.",
            Status = "readOnly",
            Value = 35
        },
        DiscountPrice = new Field<decimal?>
        {
            Name = "PU HT",
            Status = "readOnly",
            Value = 0.68m
        },
        // in the api this Prices is null,  adding data for test
        Prices = new List<BasketPriceLine?>()
{
    new BasketPriceLine
    {
        quantity = 25,
        catalogPrice = 1.05m,
        discountPrice = 1.00m,
        multiplePrice = 25.00m,
        discountRate = 0
    },
     new BasketPriceLine
    {
        quantity = 100,
        catalogPrice = 0.99m,
        discountPrice = 0.94m,
        multiplePrice = 23.50m,
        discountRate = 6
    },
    new BasketPriceLine
    {
        quantity = 200,
        catalogPrice = 0.92m,
        discountPrice = 0.87m,
        multiplePrice = 21.75m,
        discountRate = 13
    },
    new BasketPriceLine
    {
        quantity = 400,
        catalogPrice = 0.87m,
        discountPrice = 0.83m,
        multiplePrice = 20.75m,
        discountRate = 17
    },
    new BasketPriceLine
    {
        quantity = 800,
        catalogPrice = 0.76m,
        discountPrice = 0.72m,
        multiplePrice = 18.00m,
        discountRate = 28
    }
        }
    },

    new BasketLineDto
    {
        LineNum = new Field<int?>
        {
            Name = "N° de ligne",
            Status = "readWrite",
            Value = 2
        },
        IsCustomLineNum = false,
        LineTags = new List<BasketValueDto?>(),
        ItemId = new Field<string?>
        {
            Name = "Code article",
            Status = "readWrite",
            Value = "CAS10"
        },
        Name = new Field<string?>
        {
            Name = "Description",
            Status = "readWrite",
            Value = "C.A SC10 25X25X25 BRUN"
        },
        InventLocationId = new Field<string?>
        {
            Name = "Entrepôt",
            Status = "readWrite",
            Value = "PN2"
        },
        SalesQuantity = new Field<int?>
        {
            Name = "Quantité",
            Status = "readWrite",
            Value = 50
        },
        SalesPrice = new Field<decimal?>
        {
            Name = "Prix unitaire",
            Status = "readWrite",
            Value = 1.2m
        },
        DiscountType = new Field<string?>
        {
            Name = "Tarification",
            Status = "readWrite",
            Value = "Default"
        },
        LineAmount = new Field<decimal?>
        {
            Name = "Montant HT",
            Status = "readWrite",
            Value = 60m
        },
        UpdateReason = new Field<string?>
        {
            Name = "Motif Modif.",
            Status = "readWrite",
            Value = ""
        },
        InitialSalesQuantity = new Field<int?>
        {
            Name = "Qté initiale",
            Status = "readWrite",
            Value = 0
        },
        MultipleQuantity = null,
        VatRate = new Field<decimal?>
        {
            Name = "Taux de TVA",
            Status = "readWrite",
            Value = 20
        },
        Note = null,
        ProductInfo = null,
        IsCustomLogisticFlow = false,
        LogisticFlow = new Field<string?>
        {
            Name = "Flux logistique",
            Status = "readWrite",
            Value = "Stock"
        },
        PhysicalAvailableQuantity = new Field<int?>
        {
            Name = "Livré maintenant",
            Status = "onlyForDisplay",
            Value = 50
        },
        OnOrderQuantity = new Field<int?>
        {
            Name = "A livrer plus tard",
            Status = "onlyForDisplay",
            Value = 0
        },
        PaletteQuantity = new Field<int?>
        {
            Name = "Quantité/palette",
            Status = "onlyForDisplay",
            Value = 1100
        },
        QuantityAtPaletteThreshold = new Field<int?>
        {
            Name = "Diff Palette",
            Status = "onlyForDisplay",
            Value = 1050
        },
        ItemType = new Field<string?>
        {
            Name = "Type d'article",
            Status = "onlyForDisplay",
            Value = "Standard"
        },
        DeliveryDate = new Field<string?>
        {
            Name = "Date de liv.",
            Status = "readWrite",
            Value = null
        },
        IsCustomDeliveryDate = new Field<bool?>
        {
            Name = "Date de liv. manuelle",
            Status = "readWrite",
            Value = false
        },
        ItemPhysicalInventQuantity = new Field<int?>
        {
            Name = "Stock total",
            Status = "onlyForDisplay",
            Value = 9075
        },
        ItemReservPhysicalQuantity = new Field<int?>
        {
            Name = "Stock réservé",
            Status = "onlyForDisplay",
            Value = 1330
        },
        ItemPhysicalAvailableQuantity = new Field<int?>
        {
            Name = "Stock réservé",
            Status = "onlyForDisplay",
            Value = 7745
        },
        ItemOnOrderQuantity = new Field<int?>
        {
            Name = "Commandé total",
            Status = "onlyForDisplay",
            Value = 1045
        },
        ItemOrderedQuantity = new Field<int?>
        {
            Name = "Commandé total",
            Status = "onlyForDisplay",
            Value = 0
        },
        ItemOrderedAvailableQuantity = new Field<int?>
        {
            Name = "Commandé total",
            Status = "onlyForDisplay",
            Value = 0
        },
        SupplyFamily = new Field<string?>
        {
            Name = "Famille d'appro.",
            Status = "onlyForDisplay",
            Value = "C1 - CAISSES ET CONTAINERS"
        },
        ItemManager = new Field<string?>
        {
            Name = "Gestionnaire",
            Status = "onlyForDisplay",
            Value = "ANTOINE STEGEL"
        },
        TransportMode = new Field<string?>
        {
            Name = "Mode de transport",
            Status = "onlyForDisplay",
            Value = "PAR DÉFAUT"
        },
        PurchaseId = new Field<string?>
        {
            Name = "Commande d'achat",
            Status = "hidden",
            Value = ""
        },
        DiscountDescription = new Field<string?>
        {
            Name = "Description Tarif",
            Status = "onlyForDisplay",
            Value = "10% DC sur tout le Catalogue"
        },
        DiscountRate = new Field<decimal?>
        {
            Name = "Remise sup.",
            Status = "readOnly",
            Value = 34
        },
        DiscountPrice = new Field<decimal?>
        {
            Name = "PU HT",
            Status = "readOnly",
            Value = 1.2m
        },
        Prices = null
    }
        }
    };


    public static List<BasketValueDto?> UpdateReasonsP0130938 = new List<BasketValueDto?>()
            {
                 new BasketValueDto
                {
                    Value = ""
                },
new BasketValueDto
{
    Description = "ADD FOLIES",
    Value = "ADD FOLIES"
},
new BasketValueDto
{
    Description = "ADD LIGNE",
    Value = "ADD LIGNE"
},
new BasketValueDto
{
    Description = "ADD QTE",
    Value = "ADD QTE"
},
new BasketValueDto
{
    Description = "ALS",
    Value = "ALS"
},
new BasketValueDto
{
    Description = "ATT",
    Value = "ATT"
},
new BasketValueDto
{
    Description = "BPS",
    Value = "BPS"
},
new BasketValueDto
{
    Description = "BVN",
    Value = "BVN"
},
new BasketValueDto
{
    Description = "CAD",
    Value = "CAD"
},
new BasketValueDto
{
    Description = "CROSS",
    Value = "CROSS"
},
new BasketValueDto
{
    Description = "CS",
    Value = "CS"
},
new BasketValueDto
{
    Description = "DAV",
    Value = "DAV"
},
new BasketValueDto
{
    Description = "DEF",
    Value = "DEF"
},
new BasketValueDto
{
    Description = "ECH",
    Value = "ECH"
},
new BasketValueDto
{
    Description = "EXP",
    Value = "EXP"
},
new BasketValueDto
{
    Description = "FAC",
    Value = "FAC"
},
new BasketValueDto
{
    Description = "FID",
    Value = "FID"
},
new BasketValueDto
{
    Description = "FIN",
    Value = "FIN"
},
new BasketValueDto
{
    Description = "FS",
    Value = "FS"
},
new BasketValueDto
{
    Description = "GCO",
    Value = "GCO"
},
new BasketValueDto
{
    Description = "GRT",
    Value = "GRT"
},
new BasketValueDto
{
    Description = "GSC",
    Value = "GSC"
},
new BasketValueDto
{
    Description = "KC",
    Value = "KC"
},
new BasketValueDto
{
    Description = "LOC",
    Value = "LOC"
},
new BasketValueDto
{
    Description = "MKG",
    Value = "MKG"
},
new BasketValueDto
{
    Description = "MY ORDER",
    Value = "MY ORDER"
},
new BasketValueDto
{
    Description = "NC",
    Value = "NC"
},
new BasketValueDto
{
    Description = "NCM",
    Value = "NCM"
},
new BasketValueDto
{
    Description = "NDI",
    Value = "NDI"
},
new BasketValueDto
{
    Description = "OFF",
    Value = "OFF"
},
new BasketValueDto
{
    Description = "PRA",
    Value = "PRA"
},
new BasketValueDto
{
    Description = "PRV",
    Value = "PRV"
},
new BasketValueDto
{
    Description = "PRW",
    Value = "PRW"
},
new BasketValueDto
{
    Description = "REP",
    Value = "REP"
},
new BasketValueDto
{
    Description = "RFA",
    Value = "RFA"
},
new BasketValueDto
{
    Description = "RPL",
    Value = "RPL"
},
new BasketValueDto
{
    Description = "SAV",
    Value = "SAV"
},
new BasketValueDto
{
    Description = "VU",
    Value = "VU"
},
new BasketValueDto
{
    Description = "WEB",
    Value = "WEB"
},
new BasketValueDto
{
    Description = "XC",
    Value = "XC"
}

            };


    public static List<BasketValueDto?> logisticFlowsP0130938 = new List<BasketValueDto?>()
            {
                 new BasketValueDto
                 {
                     Description = "Stock",
                     Value = "Stock"
                 },
                 new BasketValueDto
                 {
                     Description = "Livraison directe",
                     Value = "DropShipped"
                 },

                 new BasketValueDto
                 {
                     Description = "Passage en stock",
                     Value = "CrossDocked"
                 }
            };


    //P0130140

    //  api/orderContext/P0130140/generalInfo   P0130140

    public static BasketGeneralInfoDto generalInfoP0130140 = new BasketGeneralInfoDto()
    {
        OrderType = "Panier",
        BasketId = "P0130140",
        OrderId = "WC999075",
        OrderStatus = "Nouveau",
        OrderDate = "2024-07-15 17:04:31",
        SalesResponsible = "CEDRIC REVILLON"
    };


    // orderInfo   P0130140
    public static BasketOrderInfoDto orderInfoP0130140 = new BasketOrderInfoDto
    {
        Account = new Field<AccountDto?>
        {
            Name = "Compte commandeur",
            Status = "onlyForDisplay",
            Value = new AccountDto
            {
                AccountId = "A1619563",
                Name = "COQUILLAGE NACRE",
                Recipient = "",
                Building = "",
                Street = "2 RUE BINET",
                Locality = "",
                ZipCode = "60000",
                City = "BEAUVAIS",
                Country = "FRANCE",
                Email = "",
                Phone = "0621434586",
                CellularPhone = "",
                Blocked = false
            }
        },
        Contact = new Field<ContactDto?>
        {
            Name = "Contact commandeur",
            Status = "readOnly",
            Value = new ContactDto
            {
                ContactId = "X4690210",
                SocialTitle = "M.",
                FirstName = "LUC",
                LastName = "DURAND",
                Email = "knouet@raja.fr",
                Phone = "0621434586",
                CellularPhone = "0621434586"
            }
        },
        ActivityArea = new Field<string>
        {
            Name = "Secteur d'activité",
            Status = "onlyForDisplay",
            Value = null
        },
        CustomerTags = new List<BasketValueDto?>(),
        SalesOriginId = new Field<string>
        {
            Name = "Canal de vente",
            Status = "readOnly",
            Value = "Téléphone"
        },
        WebOriginId = new Field<string>
        {
            Name = "Origine e-commerce",
            Status = "readOnly",
            Value = ""
        },
        SalesPoolId = new Field<string>
        {
            Name = "Type de transaction",
            Status = "readOnly",
            Value = "NOR"
        },
        CustomerOrderRef = new Field<string>
        {
            Name = "Référence Client",
            Status = "readOnly",
            Value = "visa"
        },
        WebSalesId = new Field<string>
        {
            Name = "Commande Web",
            Status = "readOnly",
            Value = ""
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
            Value = ""
        }
    };


    // orderByContacts   P0130140
    public static List<ContactDto?> orderByContactsP0130140 = new List<ContactDto?>
        {
            new ContactDto
            {
                    ContactId = "X4690210",
        SocialTitle = "M.",
        FirstName = "LUC",
        LastName = "DURAND",
        Email = "knouet@raja.fr",
        Phone = "0621434586",
        CellularPhone = "0621434586"
            }
        };


    //customerTags   P0130140
    public static List<BasketValueDto?> customerTagsP0130140 = new List<BasketValueDto?>
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
        };


    //salesPools   P0130140
    public static List<BasketValueDto?> salesPoolsP0130140 = new List<BasketValueDto?>
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
        };


    //salesOrigins   P0130140
    public static List<SalesOriginDto?> salesOriginsP0130140 = new List<SalesOriginDto?>
        {
    new SalesOriginDto { Value = "" },
    new SalesOriginDto { Value = "Téléphone" },
    new SalesOriginDto { Value = "E-mail" },
    new SalesOriginDto { Value = "Fax" },
    new SalesOriginDto { Value = "Courrier" },
    new SalesOriginDto { Value = "Comptoir" },
    new SalesOriginDto { Value = "Chat" },
    new SalesOriginDto { Value = "E-Proc" },
    new SalesOriginDto { Value = "Sortant" },
    new SalesOriginDto { Value = "Internet" },
    new SalesOriginDto { Value = "Auto" },
    new SalesOriginDto { Value = "EDI" },
    new SalesOriginDto { Value = "Terrain" },
    new SalesOriginDto { Value = "Interne" }
        };


    //webOrigins   P0130140
    public static List<BasketValueDto?> webOriginsP0130140 = new List<BasketValueDto?>
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
    new BasketValueDto { Value = "EBAY" },
    new BasketValueDto { Value = "EDILIANS" },
    new BasketValueDto { Value = "ELCO" },
    new BasketValueDto { Value = "E-PROC" },
    new BasketValueDto { Value = "ESKER" },
    new BasketValueDto { Value = "ETEX" },
    new BasketValueDto { Value = "EUROFINS" },
    new BasketValueDto { Value = "HAXONEO" },
    new BasketValueDto { Value = "HAXONEO_C0152435" },
    new BasketValueDto { Value = "HAXONEO-C0152435" },
    new BasketValueDto { Value = "HERMES" },
    new BasketValueDto { Value = "IKEA" },
    new BasketValueDto { Value = "IKEA_ARIBA" },
    new BasketValueDto { Value = "KERRY" },
    new BasketValueDto { Value = "LaPoste" },
    new BasketValueDto { Value = "LEROY-SOMER" },
    new BasketValueDto { Value = "M. BRICOLAGE" },
    new BasketValueDto { Value = "MOBILE" },
    new BasketValueDto { Value = "MONOPRIX" },
    new BasketValueDto { Value = "MyPlatform" },
    new BasketValueDto { Value = "NEWELL" },
    new BasketValueDto { Value = "NEXANS" },
    new BasketValueDto { Value = "NIKE" },
    new BasketValueDto { Value = "OPELLA" },
    new BasketValueDto { Value = "ORANGE" },
    new BasketValueDto { Value = "ORANGE-OTL" },
    new BasketValueDto { Value = "RAJA_AT" },
    new BasketValueDto { Value = "RAJA_BE" },
    new BasketValueDto { Value = "RAJA_CENPAC" },
    new BasketValueDto { Value = "RAJA_CH" },
    new BasketValueDto { Value = "RAJA_CZ" },
    new BasketValueDto { Value = "RAJA_DE" },
    new BasketValueDto { Value = "RAJA_DK" },
    new BasketValueDto { Value = "RAJA_ES" },
    new BasketValueDto { Value = "RAJA_IT" },
    new BasketValueDto { Value = "RAJA_NEQST" },
    new BasketValueDto { Value = "RAJA_NO" },
    new BasketValueDto { Value = "RAJA_PL" },
    new BasketValueDto { Value = "RAJA_PT" },
    new BasketValueDto { Value = "RAJA_SE" },
    new BasketValueDto { Value = "RAJA_SK" },
    new BasketValueDto { Value = "RAJA_TCENPAC" },
    new BasketValueDto { Value = "RAJA_UK" },
    new BasketValueDto { Value = "RAJABUTTON" },
    new BasketValueDto { Value = "SAFRAN" },
    new BasketValueDto { Value = "SANOFI" },
    new BasketValueDto { Value = "SGS" },
    new BasketValueDto { Value = "SIEMENS" },
    new BasketValueDto { Value = "SIEMENS GAMESA" },
    new BasketValueDto { Value = "SIEMENSE" },
    new BasketValueDto { Value = "SIEMENSFR" },
    new BasketValueDto { Value = "SKF" },
    new BasketValueDto { Value = "SOLVAYRHODIA" },
    new BasketValueDto { Value = "SOR_BUTTON" },
    new BasketValueDto { Value = "STACI" },
    new BasketValueDto { Value = "TASTER" },
    new BasketValueDto { Value = "TOTAL" },
    new BasketValueDto { Value = "UNILEVER" },
    new BasketValueDto { Value = "URGO" },
    new BasketValueDto { Value = "VAILLANT" },
    new BasketValueDto { Value = "WELCOMEOFFICE" },
    new BasketValueDto { Value = "XPO" },
    new BasketValueDto { Value = "YVES ROCHER" }
};


    //procedureCall => SalesOrigin = Internet   P0130140
    public static ProcedureCallResponseDto procedureCallResponseP0130140_1 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property SalesOriginId updated with value Internet",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "orderInfo",
        "pricesInfo",
        "invoiceInfo"
    }
    };


    //procedureCall => RAJ_WebSalesId = W01234567   P0130140
    public static ProcedureCallResponseDto procedureCallResponseP0130140_2 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property RAJ_WebSalesId updated with value W01234567",
        UpdateDone = true,
        RefreshCalls = new List<string?>
                {
                    "generalInfo",
                    "notifications"
                }
    };


    //procedureCall => MayLastColumnDiscount = true   P0130140
    public static ProcedureCallResponseDto procedureCallResponseP0130140_3 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property MyLastColumnDiscount updated with value True",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "pricesInfo",
        "orderLines"
    }
    };


    //procedureCall => UpdateContact(OrderBy, X2567124   P0130140
    public static ProcedureCallResponseDto procedureCallResponseP0130140_4 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Contact X2567124 updated",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications"
    }
    };


    //procedureCall => addorderLine(CAS10,100)   P0130140
    public static ProcedureCallResponseDto procedureCallResponseP0130140_5 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "No line added",
        UpdateDone = false,
        RefreshCalls = new List<string?>()
    };


    //orderInfo => Check update values   P0130140
    public static BasketOrderInfoDto orderInfoP0130140_2 = new BasketOrderInfoDto
    {
        Account = new Field<AccountDto?>
        {
            Name = "Compte commandeur",
            Status = "onlyForDisplay",
            Value = new AccountDto
            {
                AccountId = "A1619563",
                Name = "COQUILLAGE NACRE",
                Recipient = "",
                Building = "",
                Street = "2 RUE BINET",
                Locality = "",
                ZipCode = "60000",
                City = "BEAUVAIS",
                Country = "FRANCE",
                Email = "",
                Phone = "0621434586",
                CellularPhone = "",
                Blocked = false
            }
        },
        Contact = new Field<ContactDto>
        {
            Name = "Contact commandeur",
            Status = "readOnly",
            Value = new ContactDto
            {
                ContactId = null,
                SocialTitle = null,
                FirstName = null,
                LastName = null,
                Email = null,
                Phone = null,
                CellularPhone = null
            }
        },
        ActivityArea = new Field<string>
        {
            Name = "Secteur d'activité",
            Status = "onlyForDisplay",
            Value = null
        },
        CustomerTags = new List<BasketValueDto>
    {

         new BasketValueDto { Description = "Client VIP", Value = "vip" }
    },
        SalesOriginId = new Field<string>
        {
            Name = "Canal de vente",
            Status = "readOnly",
            Value = "Internet"
        },
        WebOriginId = new Field<string>
        {
            Name = "Origine e-commerce",
            Status = "readWrite",
            Value = "DESKTOP"
        },
        SalesPoolId = new Field<string>
        {
            Name = "Type de transaction",
            Status = "readOnly",
            Value = "NOR"
        },
        CustomerOrderRef = new Field<string>
        {
            Name = "Référence Client",
            Status = "readOnly",
            Value = "visa"
        },
        WebSalesId = new Field<string>
        {
            Name = "Commande Web",
            Status = "readWrite",
            Value = "W01234567"
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
            Value = ""
        }
    };


    //deliveryInfo   P0130140
    public static BasketDeliveryInfoDto deliveryInfoP0130140 = new BasketDeliveryInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte de livraison",
            Status = "readOnly",
            Value = new AccountDto
            {
                AccountId = null,
                Name = null,
                Recipient = null,
                Building = null,
                Street = null,
                Locality = null,
                ZipCode = null,
                City = null,
                Country = null,
                Email = null,
                Phone = null,
                CellularPhone = null,
                Blocked = false
            }
        },
        Contact = new Field<ContactDto>
        {
            Name = "Contact de livraison",
            Status = "readOnly",
            Value = new ContactDto
            {
                ContactId = null,
                SocialTitle = null,
                FirstName = null,
                LastName = null,
                Email = null,
                Phone = null,
                CellularPhone = null
            }
        },
        DeliveryMode = new Field<string>
        {
            Name = "Mode de livraison",
            Status = "readOnly",
            Value = null
        },
        CompleteDelivery = new Field<bool?>
        {
            Name = "Livraison complète",
            Status = "readOnly",
            Value = false
        },
        ImperativeDate = new Field<DateTime?>
        {
            Name = "Date impérative",
            Status = "readOnly",
            Value = null
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
            Status = "readOnly",
            Value = null
        },
        NoteMustBeSaved = new Field<bool?>
        {
            Name = "Sauvegarde note de liv.",
            Status = "readOnly",
            Value = false,
            Description = "Sauvegarde pour les prochaines commandes"
        }
    };


    //deliverToAccounts   P0130140
    public static List<AccountDto?> deliverToAccountsP0130140 = new List<AccountDto?>
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
    }
};


    //deliverToContacts   P0130140
    public static List<ContactDto?> deliverToContactsP0130140 = new List<ContactDto?>
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
    }
};


    //deliveryModes   P0130140
    public static List<BasketValueDto?> deliveryModesP0130140 = new List<BasketValueDto?>
{
    new BasketValueDto { Value = "Catalogue" },
    new BasketValueDto { Value = "Enlèvement" },
    new BasketValueDto { Value = "Export" },
    new BasketValueDto { Value = "Filiale" },
    new BasketValueDto { Value = "Interne" },
    new BasketValueDto { Value = "VCT" }
};


    //invoiceInfo   P0130140
    public static BasketInvoiceInfoDto invoiceInfoP0130140 = new BasketInvoiceInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte de facturation",
            Status = "readOnly",
            Value = new AccountDto
            {
                AccountId = null,
                Name = null,
                Recipient = null,
                Building = null,
                Street = null,
                Locality = null,
                ZipCode = null,
                City = null,
                Country = null,
                Email = null,
                Phone = null,
                CellularPhone = null,
                Blocked = false
            }
        },
        SiretId = new Field<string>
        {
            Name = "Siret",
            Status = "onlyForDisplay",
            Value = null
        },
        TaxGroup = new Field<string>
        {
            Name = "Groupe de taxe",
            Status = "readOnly",
            Value = null
        },
        PaymentTerm = new Field<string>
        {
            Name = "Conditions de paiement",
            Status = "onlyForDisplay",
            Value = null
        },
        PaymentMode = new Field<string>
        {
            Name = "Mode de paiement",
            Status = "readOnly",
            Value = null
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
            Value = ""
        }
    };


    //invoiceToAccounts   P0130140
    public static List<AccountDto?> invoiceToAccountsP0130140 = new List<AccountDto?>
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
    }
};


    //TaxGroups   P0130140
    public static List<BasketValueDto?> taxGroupsP0130140 = new List<BasketValueDto?>
{
    new BasketValueDto { Value = "" },
    new BasketValueDto { Description = "France Autoliquidation", Value = "F-AUTOLIQ" },
    new BasketValueDto { Description = "France TVA sur les débits", Value = "F-DEB" },
    new BasketValueDto { Description = "France TVA sur les débits Escompte", Value = "F-DEBTVA" },
    new BasketValueDto { Description = "France TVA sur les encaissements", Value = "F-ENC" },
    new BasketValueDto { Description = "France TVA sur les encaissements Escompte", Value = "F-ENCTVA" },
    new BasketValueDto { Description = "France exonéré", Value = "F-EXO" },
    new BasketValueDto { Description = "TVA sur factures à émettre", Value = "F-FAE" },
    new BasketValueDto { Description = "France SMICTOM TVA 7%", Value = "F-SMI" },
    new BasketValueDto { Description = "Tiers hors UE vente", Value = "HUE" },
    new BasketValueDto { Description = "Tiers Hors UE achat", Value = "HUE-AC" },
    new BasketValueDto { Description = "Monaco TVA sur les débits", Value = "M-DEB" },
    new BasketValueDto { Description = "Monaco EXONERE (Attestation)", Value = "M-EXO" },
    new BasketValueDto { Description = "TVA union européenne achat", Value = "UE-AC" },
    new BasketValueDto { Description = "TVA union européenne vente", Value = "UE-VE" },
    new BasketValueDto { Description = "TVA FNP à régulariser", Value = "ZF-FNP" }
};


    //paymentModes   P0130140
    public static List<BasketValueDto?> paymentModesP0130140 = new List<BasketValueDto?>
{
    new BasketValueDto { Description = null, Value = "" },
    new BasketValueDto { Description = "Carte Bancaire", Value = "CB" },
    new BasketValueDto { Description = "Chèque", Value = "CH" },
    new BasketValueDto { Description = "Paypal", Value = "PAYPAL" },
    new BasketValueDto { Description = "Préautorisation CB", Value = "PCB" },
    new BasketValueDto { Description = "Carte Bancaire Manuelle", Value = "TPE" },
    new BasketValueDto { Description = "Virement Marketplace La Poste", Value = "VMP" },
    new BasketValueDto { Description = "Préautorisation CB manuelle", Value = "ZCB" },
    new BasketValueDto { Description = "Paypal sur Ebay", Value = "ZEBAY" },
    new BasketValueDto { Description = "Préautorisation PC manuelle", Value = "ZPC" },
    new BasketValueDto { Description = "Préautorisation Paypal manuelle", Value = "ZPY" }
};


    //tradeInfo   P0130140
    public static BasketTradeInfoDto tradeInfoP0130140 = new BasketTradeInfoDto
    {
        Turnover = new Field<List<BasketTurnoverLineDto?>>
        {
            Name = "Chiffre d'affaire",
            Status = "onlyForDisplay",
            Value = new List<BasketTurnoverLineDto?>
        {
            new BasketTurnoverLineDto
            {
                Name = "Classe",
                Ytd = "99",
                YtdN1 = "",
                N1 = "99",
                N2 = "99"
            },
            new BasketTurnoverLineDto
            {
                Name = "CA.",
                Ytd = "€",
                YtdN1 = "€",
                N1 = "€",
                N2 = "€"
            },
            new BasketTurnoverLineDto
            {
                Name = "Evol. CA.",
                Ytd = "%",
                YtdN1 = "",
                N1 = "",
                N2 = ""
            }
        }
        },
        Contract = new BasketContractInfoDto
        {
            ContractId = new Field<string>
            {
                Name = "Contrat",
                Status = "onlyForDisplay",
                Value = null
            },
            ContractType = new Field<string>
            {
                Name = "Type",
                Status = "onlyForDisplay",
                Value = null
            },
            ContractGroup = new Field<string>
            {
                Name = "Groupe de contrat",
                Status = "onlyForDisplay",
                Value = ""
            },
            Status = new Field<string>
            {
                Name = "Statut",
                Status = "onlyForDisplay",
                Value = null
            },
            StartDate = new Field<string>
            {
                Name = "Date de début",
                Status = "onlyForDisplay",
                Value = null
            },
            EndDate = new Field<string>
            {
                Name = "Date de fin",
                Status = "onlyForDisplay",
                Value = null
            },
            CampaignId = new Field<string>
            {
                Name = "Campagne de prix",
                Status = "onlyForDisplay",
                Value = null
            },
            MainContact = new Field<string>
            {
                Name = "Commercial terrain",
                Status = "onlyForDisplay",
                Value = null
            },
            OfficeExecutive = new Field<string>
            {
                Name = "Commercial sédentaire",
                Status = "onlyForDisplay",
                Value = null
            },
            DiscountList = new Field<List<string?>>
            {
                Name = "Description",
                Status = "onlyForDisplay",
                Value = new List<string?>()
            }
        }
    };


    //pricesInfo   P0130140
    public static BasketPricesInfoDto pricesInfoP0130140 = new BasketPricesInfoDto
    {
        Coupon = new Field<string?>
        {
            Name = "Code Action",
            Status = "readOnly",
            Value = ""
        },
        FreeShippingAmountThreshold = new Field<decimal?>
        {
            Name = "Diff Franco",
            Status = "onlyForDisplay",
            Value = null
        },
        GiftAmountThreshold = new Field<decimal?>
        {
            Name = "Diff KDO",
            Status = "onlyForDisplay",
            Value = null
        },
        ProductsInfo = new Field<string?>
        {
            Name = "Dispo. Marchandise",
            Status = "onlyForDisplay",
            Value = null
        },
        ProductsNetAmount = new Field<decimal?>
        {
            Name = "Marchandise HT",
            Status = "onlyForDisplay",
            Value = 0
        },
        WarrantyCostOption = new Field<string?>
        {
            Name = "Type de garantie optimale",
            Status = "readOnly",
            Value = "Disabled"
        },
        WarrantyCostAmount = new Field<decimal?>
        {
            Name = "Montant de la garantie optimale",
            Status = "onlyForDisplay",
            Value = 0
        },
        ShippingCostOption = new Field<string?>
        {
            Name = "Type de frais de port",
            Status = "readOnly",
            Value = "Disabled"
        },
        ShippingCostAmount = new Field<decimal?>
        {
            Name = "Montant des frais de port",
            Status = "readOnly",
            Value = 0
        },
        LogisticInfo = null,
        TotalNetAmount = new Field<decimal?>
        {
            Name = "Montant Total HT",
            Status = "onlyForDisplay",
            Value = 0
        },
        VatAmount = new Field<decimal?>
        {
            Name = "Montant TVA",
            Status = "onlyForDisplay",
            Value = 0
        },
        TotalGrossAmount = new Field<decimal?>
        {
            Name = "Montant TTC",
            Status = "onlyForDisplay",
            Value = 0
        },
               OrderDiscountRate = new Field<int?>
        {
            Name = "Remise Cde (%)",
            Status = "readOnly",
            Value = 0
        },
        OrderLastColumnDiscount = new Field<bool?>
        {
            Name = "Remise Cde DC",
            Status = "readOnly",
            Value = false
        },
        AdditionalSalesAmount = new Field<decimal?>
        {
            Name = "Ventes add. (€)",
            Status = "onlyForDisplay",
            Value = 0
        },
        DiscountAmount = new Field<decimal?>
        {
            Name = "Remise Cde (€)",
            Status = "onlyForDisplay",
            Value = 0
        },
        TotalWeight = new Field<decimal?>
        {
            Name = "Poids (kg)",
            Status = "onlyForDisplay",
            Value = 0
        },
        TotalVolume = new Field<decimal?>
        {
            Name = "Volume (m3)",
            Status = "onlyForDisplay",
            Value = 0
        }
    };


    //coupons    Prices info section   P0130140
    public static List<BasketValueDto?> couponsP0130140 = new List<BasketValueDto?>
{
    new BasketValueDto { Description = null, Value = "" },
    new BasketValueDto { Description = "COMMANDES nefab  2010\nCODE PAR DEFAUT\nVALIDITE INDETERMINEE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis", Value = "AC0100" },
    new BasketValueDto { Description = "COMMANDES AIRBUS  2011-2012\nCODE PAR DEFAUT\nVALIDITE INDETERMINE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis", Value = "AIRBUS" },
    new BasketValueDto { Description = "OFFERT dès 200 EUROS : CADEAU COFFRET LA MERE POULARD\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "BISCUITS830" },
    new BasketValueDto { Description = "DEMANDES DE CATALOGUES", Value = "CAT24" },
    new BasketValueDto { Description = "DEMANDES DE CATALOGUES CLIENTS", Value = "CATC24" },
    new BasketValueDto { Description = "DEMANDES DE CATALOGUES PROSPECTS", Value = "CATP24" },
    new BasketValueDto { Description = "Validité au 31/12/2024\nAucun cadeau\nPas de welcome pack", Value = "CRC24R" },
    new BasketValueDto { Description = "DEMANDES DE CATALOGUES PROSPECTS", Value = "ECATP24" },
    new BasketValueDto { Description = "DEMANDES D'ECHANTILLONS CLIENTS", Value = "ECHC24" },
    new BasketValueDto { Description = "DEMANDES D'ECHANTILLONS PROSPECTS", Value = "ECHP24" },
    new BasketValueDto { Description = "OFFERT dès 400 EUROS : CADEAU APPAREIL FONDUE\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "FONDUE172" },
    new BasketValueDto { Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024", Value = "G032400" },
    new BasketValueDto { Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024", Value = "G032401" },
    new BasketValueDto { Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024", Value = "G032408" },
    new BasketValueDto { Description = "OFFERT dès 300 EUROS : CADEAU GAUFFRIER\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "GAUFFRES211" },
    new BasketValueDto { Description = "catalogue entretien et hygiène avril 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024", Value = "J042401" },
    new BasketValueDto { Description = "Commandes export 2024\nCode par défaut\n350€ HT minimum marchandises\nValidité au 31/12/2024\nAucun cadeau\nPas de welcome pack", Value = "L012400" },
    new BasketValueDto { Description = "MARKET PLACE LAPOSTE\nFrais de port 9,90€", Value = "LAPOSTE" },
    new BasketValueDto { Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS", Value = "NWELCOME" },
    new BasketValueDto { Description = "OFFERT dès 99 EUROS : CADEAU TROUSSE A OUTILS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "OUTILS830" },
    new BasketValueDto { Description = "OFFERT dès 300 EUROS : CADEAU MACHINE POP CORN\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "POPCORN293" },
    new BasketValueDto { Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS", Value = "PRIVILEGE" },
    new BasketValueDto { Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025", Value = "RAJABLOG" },
    new BasketValueDto { Description = "OFFERT dès 400 EUROS : CADEAU COFFRET RITUALS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "RITUALS162" },
    new BasketValueDto { Description = "OFFERT dès 99 EUROS : CADEAU BOUTEILLE ISOTHERME YOKO \nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "SOIF483" },
    new BasketValueDto { Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025", Value = "THANKYOU" },
    new BasketValueDto { Description = "OFFERT dès 200 EUROS : CADEAU THEIERE NOMADE YOKO\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients", Value = "THEIERE749" },
    new BasketValueDto { Description = "WEB  MARS 24\nwelcome pack si nouveaux clients", Value = "W032400" },
    new BasketValueDto { Description = "WEB  AVRIL 24\nwelcome pack si nouveaux clients", Value = "W042400" },
    new BasketValueDto { Description = "WEB  MAI 24\nwelcome pack si nouveaux clients", Value = "W052400" },
    new BasketValueDto { Description = "WEB  JUIN 24\nwelcome pack si nouveaux clients", Value = "W062400" },
    new BasketValueDto { Description = "WEB  JUILLET 24\nwelcome pack si nouveaux clients", Value = "W072400" },
    new BasketValueDto { Description = "WEB  AOUT 24\nwelcome pack si nouveaux clients", Value = "W082400" },
    new BasketValueDto { Description = "WEB CATALOGUES ELECTRONIQUES CODE PAR DEFAUT VALIDITE AU 31/12/2024 AUCUN CADEAU PAS DE WELCOME PACK", Value = "W24999" },
    new BasketValueDto { Description = "Offre de bienvenue : livraison offerte dès 149€ ht + 15% remise", Value = "WBIENVENUE" },
    new BasketValueDto { Description = "Offre nouveaux clients : SEPT22 CLIENTS\nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS\nVALIDITE AU 28/02/2023", Value = "WELCOMEPACK" },
    new BasketValueDto { Description = "TARIFS FILIALES MARS 24\nVALIDITE AU 31/08/2024", Value = "Y032400" }
};


    //warrantyCostOptions   Prices info section   P0130140
    public static List<BasketValueDto?> warrantyCostOptionsP0130140 = new List<BasketValueDto?>
{
    new BasketValueDto { Description = "GO activée", Value = "Enabled" },
    new BasketValueDto { Description = "GO désactivée", Value = "Disabled" },
    new BasketValueDto { Description = "GO offerte", Value = "Offered" }
};


    //shippingCostOptions   Prices info section   P0130140
    public static List<BasketValueDto?> shippingCostOptionsP0130140 = new List<BasketValueDto?>
{
    new BasketValueDto { Description = "Frais de livraison", Value = "Standard" },
    new BasketValueDto { Description = "Frais de liv. offerts", Value = "Offered" }
};



    //===========================================================================================================


    /*"P0130512" */// info commercial, 16


    //  api/orderContext/P0130512/generalInfo   P0130512
    public static BasketGeneralInfoDto generalInfoP0130512 = new BasketGeneralInfoDto
    {
        OrderType = "Commande",
        BasketId = "P0130512",
        OrderId = "24136778",
        OrderStatus = "Lancée",
        OrderDate = "2024-06-18 15:44:42",
        SalesResponsible = "JOSEPH TU"
    };


    // orderInfo   P0130512
    public static BasketOrderInfoDto orderInfoP0130512 = new BasketOrderInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte commandeur",
            Status = "onlyForDisplay",
            Value = new AccountDto
            {
                AccountId = "51141525",
                Name = "PRECICULTURE SAS",
                Recipient = "",
                Building = "",
                Street = "165 RUE DES VERRIERS",
                Locality = "",
                ZipCode = "51230",
                City = "FERE CHAMPENOISE",
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
            Status = "readOnly",
            Value = new ContactDto
            {
                ContactId = null,
                SocialTitle = null,
                FirstName = null,
                LastName = null,
                Email = null,
                Phone = null,
                CellularPhone = null
            }
        },
        ActivityArea = new Field<string>
        {
            Name = "Secteur d'activité",
            Status = "onlyForDisplay",
            Value = "Fabrication de machines agricoles et forestières",
            Description = "Code NAF: 2830Z"
        },
        CustomerTags = new List<BasketValueDto>(),
        SalesOriginId = new Field<string>
        {
            Name = "Canal de vente",
            Status = "readOnly",
            Value = "Téléphone"
        },
        WebOriginId = new Field<string>
        {
            Name = "Origine e-commerce",
            Status = "readOnly",
            Value = ""
        },
        SalesPoolId = new Field<string>
        {
            Name = "Type de transaction",
            Status = "readOnly",
            Value = "NOR"
        },
        CustomerOrderRef = new Field<string>
        {
            Name = "Référence Client",
            Status = "readOnly",
            Value = "18/06/2024"
        },
        WebSalesId = new Field<string>
        {
            Name = "Commande Web",
            Status = "readOnly",
            Value = ""
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
            Value = "CS/SMO/VALIDITE AU 31/12/2011**** ATTENTION MR COCHART NE VEUT PLUS DE CONFIRMATIONS PAR E MAIL CLO **IMPERATIF ENVOYER KDO SEPAREMENT A L'ATTENTION DE LA DIRECTION**"
        }
    };


    //orderByContacts   P0130512

    public static List<ContactDto?> orderByContactsP0130512 = new List<ContactDto?>
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
    }
};


    //customerTags   P0130512
    public static List<BasketValueDto?> customerTagsP0130512 = new List<BasketValueDto?>
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
};


    //salesPools   P0130512
    public static List<BasketValueDto?> salesPoolsP0130512 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = null,
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
};


    //salesOrigins   P0130512
    public static List<SalesOriginDto?> salesOriginsP0130512 = new List<SalesOriginDto?>
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
};


    //webOrigins   P0130512
    public static List<BasketValueDto?> webOriginsP0130512 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Value = ""
    },
    new BasketValueDto
    {
        Value = "3M"
    },
    new BasketValueDto
    {
        Value = "Air Liquide"
    },
    new BasketValueDto
    {
        Value = "AIRBUS"
    },
    new BasketValueDto
    {
        Value = "ALSTOM"
    },
    new BasketValueDto
    {
        Value = "AMAZON"
    },
    new BasketValueDto
    {
        Value = "ARIBA"
    },
    new BasketValueDto
    {
        Value = "BIRCHSTREET"
    },
    new BasketValueDto
    {
        Value = "BOSCH"
    },
    new BasketValueDto
    {
        Value = "BURBERRY"
    },
    new BasketValueDto
    {
        Value = "BUT"
    },
    new BasketValueDto
    {
        Value = "Catalogue"
    },
    new BasketValueDto
    {
        Value = "CEVA"
    },
    new BasketValueDto
    {
        Value = "CHRHANSEN"
    },
    new BasketValueDto
    {
        Value = "COUPA"
    },
    new BasketValueDto
    {
        Value = "COUPAAdvantage"
    },
    new BasketValueDto
    {
        Value = "CPO"
    },
    new BasketValueDto
    {
        Value = "CPOSolution"
    },
    new BasketValueDto
    {
        Value = "DAHER"
    },
    new BasketValueDto
    {
        Value = "DBSCHENKER"
    },
    new BasketValueDto
    {
        Value = "DECATHLON"
    },
    new BasketValueDto
    {
        Value = "DESKTOP"
    },
    new BasketValueDto
    {
        Value = "DETERMINE"
    },
    new BasketValueDto
    {
        Value = "DFS"
    },
    new BasketValueDto
    {
        Value = "EBAY"
    },
    new BasketValueDto
    {
        Value = "EDILIANS"
    },
    new BasketValueDto
    {
        Value = "ELCO"
    },
    new BasketValueDto
    {
        Value = "E-PROC"
    },
    new BasketValueDto
    {
        Value = "ESKER"
    },
    new BasketValueDto
    {
        Value = "ETEX"
    },
    new BasketValueDto
    {
        Value = "EUROFINS"
    },
    new BasketValueDto
    {
        Value = "HAXONEO"
    },
    new BasketValueDto
    {
        Value = "HAXONEO_C0152435"
    },
    new BasketValueDto
    {
        Value = "HAXONEO-C0152435"
    },
    new BasketValueDto
    {
        Value = "HERMES"
    },
    new BasketValueDto
    {
        Value = "IKEA"
    },
    new BasketValueDto
    {
        Value = "IKEA_ARIBA"
    },
    new BasketValueDto
    {
        Value = "KERRY"
    },
    new BasketValueDto
    {
        Value = "LaPoste"
    },
    new BasketValueDto
    {
        Value = "LEROY-SOMER"
    },
    new BasketValueDto
    {
        Value = "M. BRICOLAGE"
    },
    new BasketValueDto
    {
        Value = "MOBILE"
    },
    new BasketValueDto
    {
        Value = "MONOPRIX"
    },
    new BasketValueDto
    {
        Value = "MyPlatform"
    },
    new BasketValueDto
    {
        Value = "NEWELL"
    },
    new BasketValueDto
    {
        Value = "NEXANS"
    },
    new BasketValueDto
    {
        Value = "NIKE"
    },
    new BasketValueDto
    {
        Value = "OPELLA"
    },
    new BasketValueDto
    {
        Value = "ORANGE"
    },
    new BasketValueDto
    {
        Value = "ORANGE-OTL"
    },
    new BasketValueDto
    {
        Value = "RAJA_AT"
    },
    new BasketValueDto
    {
        Value = "RAJA_BE"
    },
    new BasketValueDto
    {
        Value = "RAJA_CENPAC"
    },
    new BasketValueDto
    {
        Value = "RAJA_CH"
    },
    new BasketValueDto
    {
        Value = "RAJA_CZ"
    },
    new BasketValueDto
    {
        Value = "RAJA_DE"
    },
    new BasketValueDto
    {
        Value = "RAJA_DK"
    },
    new BasketValueDto
    {
        Value = "RAJA_ES"
    },
    new BasketValueDto
    {
        Value = "RAJA_IT"
    },
    new BasketValueDto
    {
        Value = "RAJA_NEQST"
    },
    new BasketValueDto
    {
        Value = "RAJA_NO"
    },
    new BasketValueDto
    {
        Value = "RAJA_PL"
    },
    new BasketValueDto
    {
        Value = "RAJA_PT"
    },
    new BasketValueDto
    {
        Value = "RAJA_SE"
    },
    new BasketValueDto
    {
        Value = "RAJA_SK"
    },
    new BasketValueDto
    {
        Value = "RAJA_TCENPAC"
    },
    new BasketValueDto
    {
        Value = "RAJA_UK"
    },
    new BasketValueDto
    {
        Value = "RAJABUTTON"
    },
    new BasketValueDto
    {
        Value = "SAFRAN"
    },
    new BasketValueDto
    {
        Value = "SANOFI"
    },
    new BasketValueDto
    {
        Value = "SGS"
    },
    new BasketValueDto
    {
        Value = "SIEMENS"
    },
    new BasketValueDto
    {
        Value = "SIEMENS GAMESA"
    },
    new BasketValueDto
    {
        Value = "SIEMENSE"
    },
    new BasketValueDto
    {
        Value = "SIEMENSFR"
    },
    new BasketValueDto
    {
        Value = "SKF"
    },
    new BasketValueDto
    {
        Value = "SOLVAYRHODIA"
    },
    new BasketValueDto
    {
        Value = "SOR_BUTTON"
    },
    new BasketValueDto
    {
        Value = "STACI"
    },
    new BasketValueDto
    {
        Value = "TASTER"
    },
    new BasketValueDto
    {
        Value = "TOTAL"
    },
    new BasketValueDto
    {
        Value = "UNILEVER"
    },
    new BasketValueDto
    {
        Value = "URGO"
    },
    new BasketValueDto
    {
        Value = "VAILLANT"
    },
    new BasketValueDto
    {
        Value = "WELCOMEOFFICE"
    },
    new BasketValueDto
    {
        Value = "XPO"
    },
    new BasketValueDto
    {
        Value = "YVES ROCHER"
    }
};


    //procedureCall => SalesOrigin = Internet   P0130512
    public static ProcedureCallResponseDto procedureCallResponseP0130512_1 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property SalesOriginId updated with value Internet",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "orderInfo",
        "pricesInfo",
        "invoiceInfo"
    }
    };


    //procedureCall => RAJ_WebSalesId = W01234567   P0130512
    public static ProcedureCallResponseDto procedureCallResponseP0130512_2 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property RAJ_WebSalesId updated with value W01234567",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications"
    }
    };


    //procedureCall => MayLastColumnDiscount = true   P0130512
    public static ProcedureCallResponseDto procedureCallResponseP0130512_3 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property MyLastColumnDiscount updated with value True",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "pricesInfo",
        "orderLines"
    }
    };


    //procedureCall => UpdateContact(OrderBy, X2567124   P0130512
    public static ProcedureCallResponseDto procedureCallResponseP0130512_4 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Contact X2567124 updated",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications"
    }
    };


    //procedureCall => addorderLine(CAS10,100)   P0130512
    public static ProcedureCallResponseDto procedureCallResponseP0130512_5 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "No line added",
        UpdateDone = false,
        RefreshCalls = new List<string?>()
    };


    //orderInfo => Check update values   P0130512
    public static BasketOrderInfoDto orderInfoP0130512_2 = new BasketOrderInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte commandeur",
            Status = "onlyForDisplay",
            Value = new AccountDto
            {
                AccountId = "51141525",
                Name = "PRECICULTURE SAS",
                Recipient = "",
                Building = "",
                Street = "165 RUE DES VERRIERS",
                Locality = "",
                ZipCode = "51230",
                City = "FERE CHAMPENOISE",
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
            Status = "readOnly",
            Value = new ContactDto
            {
                ContactId = null,
                SocialTitle = null,
                FirstName = null,
                LastName = null,
                Email = null,
                Phone = null,
                CellularPhone = null
            }
        },
        ActivityArea = new Field<string>
        {
            Name = "Secteur d'activité",
            Status = "onlyForDisplay",
            Value = "Fabrication de machines agricoles et forestières",
            Description = "Code NAF: 2830Z"
        },
        CustomerTags = new List<BasketValueDto>(),
        SalesOriginId = new Field<string>
        {
            Name = "Canal de vente",
            Status = "readOnly",
            Value = "Internet"
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
            Status = "readOnly",
            Value = "NOR"
        },
        CustomerOrderRef = new Field<string>
        {
            Name = "Référence Client",
            Status = "readOnly",
            Value = "18/06/2024"
        },
        WebSalesId = new Field<string>
        {
            Name = "Commande Web",
            Status = "readWrite",
            Value = "W01234567",
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
            Value = "CS/SMO/VALIDITE AU 31/12/2011**** ATTENTION MR COCHART NE VEUT PLUS DE CONFIRMATIONS PAR E MAIL CLO **IMPERATIF ENVOYER KDO SEPAREMENT A L'ATTENTION DE LA DIRECTION**"
        }
    };


    //api/orderContext/{{basketId}}/deliveryInfo   P0130512
    public static BasketDeliveryInfoDto deliveryInfoP0130512 = new BasketDeliveryInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte de livraison",
            Status = "readOnly",
            Value = new AccountDto
            {
                AccountId = "D0057691",
                Name = "PRECICULTURE SAS TESTSOR",
                Recipient = "",
                Building = "",
                Street = "80 ROUTE D ENTRAIGUES",
                Locality = "",
                ZipCode = "84700",
                City = "SORGUES",
                Country = "FRANCE",
                Email = null,
                Phone = null,
                CellularPhone = null,
                Blocked = false
            }
        },
        Contact = new Field<ContactDto>
        {
            Name = "Contact de livraison",
            Status = "readOnly",
            Value = new ContactDto
            {
                ContactId = null,
                SocialTitle = null,
                FirstName = null,
                LastName = null,
                Email = null,
                Phone = null,
                CellularPhone = null
            }
        },
        DeliveryMode = new Field<string>
        {
            Name = "Mode de livraison",
            Status = "readOnly",
            Value = "Normal"
        },
        CompleteDelivery = new Field<bool?>
        {
            Name = "Livraison complète",
            Status = "readOnly",
            Value = false
        },
        ImperativeDate = new Field<DateTime?>
        {
            Name = "Date impérative",
            Status = "readOnly",
            Value = null
        },
        OrderDocuments = new Field<List<string?>>
        {
            Name = "BL / Factures",
            Status = "onlyForDisplay",
            Value = new List<string?>
        {
            "18/06/24 - BP 24215215 - SOR - Activé"
        }
        },
        Note = new Field<string>
        {
            Name = "Note de livraison",
            Status = "readOnly",
            Value = ""
        },
        NoteMustBeSaved = new Field<bool?>
        {
            Name = "Sauvegarde note de liv.",
            Status = "readOnly",
            Value = false,
            Description = "Sauvegarde pour les prochaines commandes"
        }
    };


    //deliverToAccounts   P0130512
    public static List<AccountDto?> deliverToAccountsP0130512 = new List<AccountDto?>
{
    new AccountDto
    {
        AccountId = "D0057691",
        Name = "PRECICULTURE SAS TESTSOR",
        Recipient = "",
        Building = "",
        Street = "80 ROUTE D ENTRAIGUES",
        Locality = "",
        ZipCode = "84700",
        City = "SORGUES",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    }
};


    //deliverToContacts   P0130512
    public static List<ContactDto?> deliverToContactsP0130512 = new List<ContactDto?>
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
    }
};


    //deliveryModes   P0130512
    public static List<BasketValueDto?> deliveryModesP0130512 = new List<BasketValueDto?>
{
    new BasketValueDto { Value = "Catalogue" },
    new BasketValueDto { Value = "Enlèvement" },
    new BasketValueDto { Value = "Express" },
    new BasketValueDto { Value = "Filiale" },
    new BasketValueDto { Value = "Interne" },
    new BasketValueDto { Value = "Normal" },
    new BasketValueDto { Value = "VCT" }
};


    //invoiceInfo   P0130512
    public static BasketInvoiceInfoDto invoiceInfoP0130512 = new BasketInvoiceInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte de facturation",
            Status = "readOnly",
            Value = new AccountDto
            {
                AccountId = "51141525",
                Name = "PRECICULTURE SAS",
                Recipient = "",
                Building = "",
                Street = "165 RUE DES VERRIERS",
                Locality = "",
                ZipCode = "51230",
                City = "FERE CHAMPENOISE",
                Country = "FRANCE",
                Email = "raja1234@raja.fr",
                Phone = "0120281279",
                CellularPhone = "0120281279",
                Blocked = false
            }
        },
        SiretId = new Field<string>
        {
            Name = "Siret",
            Status = "onlyForDisplay",
            Value = "09715035300031"
        },
        TaxGroup = new Field<string>
        {
            Name = "Groupe de taxe",
            Status = "readOnly",
            Value = "F-DEB"
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
            Status = "readOnly",
            Value = "VB"
        },
        IsPublicEntity = false,
        PublicEntityExecutingService = new Field<string>
        {
            Name = "Service exécutif",
            Status = "readOnly",
            Value = ""
        },
        PublicEntityLegalCommitment = new Field<string>
        {
            Name = "Engagement juridique",
            Status = "readOnly",
            Value = ""
        },
        Note = new Field<string>
        {
            Name = null,
            Status = "onlyForDisplay",
            Value = null
        }
    };


    //invoiceToAccounts   P0130512
    public static List<AccountDto?> invoiceToAccountsP0130512 = new List<AccountDto?>
{
    new AccountDto
    {
        AccountId = "51141525",
        Name = "PRECICULTURE SAS",
        Recipient = "",
        Building = "",
        Street = "165 RUE DES VERRIERS",
        Locality = "",
        ZipCode = "51230",
        City = "FERE CHAMPENOISE",
        Country = "FRANCE",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    }
};


    //TaxGroups   P0130512
    public static List<BasketValueDto?> taxGroupsP0130512 = new List<BasketValueDto?>
{
    new BasketValueDto { Value = "" },
    new BasketValueDto { Value = "F-AUTOLIQ", Description = "France Autoliquidation" },
    new BasketValueDto { Value = "F-DEB", Description = "France TVA sur les débits" },
    new BasketValueDto { Value = "F-DEBTVA", Description = "France TVA sur les débits Escompte" },
    new BasketValueDto { Value = "F-ENC", Description = "France TVA sur les encaissements" },
    new BasketValueDto { Value = "F-ENCTVA", Description = "France TVA sur les encaissements Escompte" },
    new BasketValueDto { Value = "F-EXO", Description = "France exonéré" },
    new BasketValueDto { Value = "F-FAE", Description = "TVA sur factures à émettre" },
    new BasketValueDto { Value = "F-SMI", Description = "France SMICTOM TVA 7%" },
    new BasketValueDto { Value = "HUE", Description = "Tiers hors UE vente" },
    new BasketValueDto { Value = "HUE-AC", Description = "Tiers Hors UE achat" },
    new BasketValueDto { Value = "M-DEB", Description = "Monaco TVA sur les débits" },
    new BasketValueDto { Value = "M-EXO", Description = "Monaco EXONERE (Attestation)" },
    new BasketValueDto { Value = "UE-AC", Description = "TVA union européenne achat" },
    new BasketValueDto { Value = "UE-VE", Description = "TVA union européenne vente" },
    new BasketValueDto { Value = "ZF-FNP", Description = "TVA FNP à régulariser" }
};


    //paymentModes   P0130512
    public static List<BasketValueDto?> paymentModesP0130512 = new List<BasketValueDto?>
{
    new BasketValueDto { Value = "" },
    new BasketValueDto { Value = "CB", Description = "Carte Bancaire" },
    new BasketValueDto { Value = "CH", Description = "Chèque" },
    new BasketValueDto { Value = "PAYPAL", Description = "Paypal" },
    new BasketValueDto { Value = "PCB", Description = "Préautorisation CB" },
    new BasketValueDto { Value = "TPE", Description = "Carte Bancaire Manuelle" },
    new BasketValueDto { Value = "VB", Description = "Virement Bancaire" },
    new BasketValueDto { Value = "VMP", Description = "Virement Marketplace La Poste" },
    new BasketValueDto { Value = "ZCB", Description = "Préautorisation CB manuelle" },
    new BasketValueDto { Value = "ZEBAY", Description = "Paypal sur Ebay" },
    new BasketValueDto { Value = "ZPC", Description = "Préautorisation PC manuelle" },
    new BasketValueDto { Value = "ZPY", Description = "Préautorisation Paypal manuelle" }
};


    //tradeInfo   P0130512
    public static BasketTradeInfoDto tradeInfoP0130512 = new BasketTradeInfoDto
    {
        Turnover = new Field<List<BasketTurnoverLineDto?>>
        {
            Name = "Chiffre d'affaire",
            Status = "onlyForDisplay",
            Value = new List<BasketTurnoverLineDto?>
        {
            new BasketTurnoverLineDto
            {
                Name = "Classe",
                Ytd = "11",
                YtdN1 = "",
                N1 = "13",
                N2 = "11"
            },
            new BasketTurnoverLineDto
            {
                Name = "CA.",
                Ytd = "10 139 €",
                YtdN1 = "24 184 €",
                N1 = "38 997 €",
                N2 = "12 687 €"
            },
            new BasketTurnoverLineDto
            {
                Name = "Evol. CA.",
                Ytd = "-58,08 %",
                YtdN1 = "",
                N1 = "",
                N2 = ""
            }
        }
        },
        Contract = new BasketContractInfoDto
        {
            ContractId = new Field<string>
            {
                Name = "Contrat",
                Status = "onlyForDisplay",
                Value = "CT068593"
            },
            ContractType = new Field<string>
            {
                Name = "Type",
                Status = "onlyForDisplay",
                Value = "Conditions Spéciales"
            },
            ContractGroup = new Field<string>
            {
                Name = "Groupe de contrat",
                Status = "onlyForDisplay",
                Value = "PRECICULTURE SAS",
                Description = "Groupe de contrat 51141525"
            },
            Status = new Field<string>
            {
                Name = "Statut",
                Status = "onlyForDisplay",
                Value = "En cours"
            },
            StartDate = new Field<string>
            {
                Name = "Date de début",
                Status = "onlyForDisplay",
                Value = "2023-03-06 00:00:00"
            },
            EndDate = new Field<string>
            {
                Name = "Date de fin",
                Status = "onlyForDisplay",
                Value = "2024-08-31 00:00:00"
            },
            CampaignId = new Field<string>
            {
                Name = "Campagne de prix",
                Status = "onlyForDisplay",
                Value = null
            },
            MainContact = new Field<string>
            {
                Name = "Commercial terrain",
                Status = "onlyForDisplay",
                Value = "LOIC GUSMINI-HUREAU"
            },
            OfficeExecutive = new Field<string>
            {
                Name = "Commercial sédentaire",
                Status = "onlyForDisplay",
                Value = "LINDA BOUHALI"
            },
            DiscountList = new Field<List<string?>>
            {
                Name = "Description",
                Status = "onlyForDisplay",
                Value = new List<string?>
                {
                    "Prix nets sur 15 article(s)",
                    "DC sur tout le catalogue"
                }
            }
        }
    };


    //pricesInfo   P0130512
    public static BasketPricesInfoDto pricesInfoP0130512 = new BasketPricesInfoDto
    {
        Coupon = new Field<string?>
        {
            Name = "Code Action",
            Status = "readOnly",
            Value = "G032400"
        },
        FreeShippingAmountThreshold = new Field<decimal?>
        {
            Name = "Diff Franco",
            Status = "onlyForDisplay",
            Value = null
        },
        GiftAmountThreshold = new Field<decimal?>
        {
            Name = "Diff KDO",
            Status = "onlyForDisplay",
            Value = null
        },
        ProductsInfo = new Field<string?>
        {
            Name = "Dispo. Marchandise",
            Status = "onlyForDisplay",
            Value = "55% en stock / Liv. Multiple"
        },
        ProductsNetAmount = new Field<decimal?>
        {
            Name = "Marchandise HT",
            Status = "onlyForDisplay",
            Value = 123.45m
        },
        WarrantyCostOption = new Field<string?>
        {
            Name = "Type de garantie optimale",
            Status = "readOnly",
            Value = "Disabled"
        },
        WarrantyCostAmount = new Field<decimal?>
        {
            Name = "Montant de la garantie optimale",
            Status = "onlyForDisplay",
            Value = 0m
        },
        ShippingCostOption = new Field<string?>
        {
            Name = "Type de frais de port",
            Status = "readOnly",
            Value = "Disabled"
        },
        ShippingCostAmount = new Field<decimal?>
        {
            Name = "Montant des frais de port",
            Status = "readOnly",
            Value = 14.9m
        },
        LogisticInfo = null,
        TotalNetAmount = new Field<decimal?>
        {
            Name = "Montant Total HT",
            Status = "onlyForDisplay",
            Value = 138.35m
        },
        VatAmount = new Field<decimal?>
        {
            Name = "Montant TVA",
            Status = "onlyForDisplay",
            Value = 27.67m
        },
        TotalGrossAmount = new Field<decimal?>
        {
            Name = "Montant TTC",
            Status = "onlyForDisplay",
            Value = 166.02m
        },
        OrderDiscountRate = new Field<int?>
        {
            Name = "Remise Cde (%)",
            Status = "readOnly",
            Value = 0
        },
        OrderLastColumnDiscount = new Field<bool?>
        {
            Name = "Remise Cde DC",
            Status = "readOnly",
            Value = true
        },
        AdditionalSalesAmount = new Field<decimal?>
        {
            Name = "Ventes add. (€)",
            Status = "onlyForDisplay",
            Value = 0m
        },
        DiscountAmount = new Field<decimal?>
        {
            Name = "Remise Cde (€)",
            Status = "onlyForDisplay",
            Value = 0m
        },
        TotalWeight = new Field<decimal?>
        {
            Name = "Poids (kg)",
            Status = "onlyForDisplay",
            Value = 16.7m
        },
        TotalVolume = new Field<decimal?>
        {
            Name = "Volume (m3)",
            Status = "onlyForDisplay",
            Value = 0.214m
        }
    };


    //coupons   P0130512
    public static List<BasketValueDto?> couponsP0130512 = new List<BasketValueDto?>
{
    new BasketValueDto { Value = "" },
    new BasketValueDto
    {
        Value = "AC0100",
        Description = "COMMANDES nefab 2010\nCODE PAR DEFAUT\nVALIDITE INDETERMINEE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis"
    },
    new BasketValueDto
    {
        Value = "AIRBUS",
        Description = "COMMANDES AIRBUS 2011-2012\nCODE PAR DEFAUT\nVALIDITE INDETERMINE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis"
    },
    new BasketValueDto
    {
        Value = "BISCUITS830",
        Description = "OFFERT dès 200 EUROS : CADEAU COFFRET LA MERE POULARD\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "CAT24",
        Description = "DEMANDES DE CATALOGUES"
    },
    new BasketValueDto
    {
        Value = "CATC24",
        Description = "DEMANDES DE CATALOGUES CLIENTS"
    },
    new BasketValueDto
    {
        Value = "CATP24",
        Description = "DEMANDES DE CATALOGUES PROSPECTS"
    },
    new BasketValueDto
    {
        Value = "CRC24R",
        Description = "Validité au 31/12/2024\nAucun cadeau\nPas de welcome pack"
    },
    new BasketValueDto
    {
        Value = "ECATP24",
        Description = "DEMANDES DE CATALOGUES PROSPECTS"
    },
    new BasketValueDto
    {
        Value = "ECHC24",
        Description = "DEMANDES D'ECHANTILLONS CLIENTS"
    },
    new BasketValueDto
    {
        Value = "ECHP24",
        Description = "DEMANDES D'ECHANTILLONS PROSPECTS"
    },
    new BasketValueDto
    {
        Value = "FONDUE172",
        Description = "OFFERT dès 400 EUROS : CADEAU APPAREIL FONDUE\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "G032400",
        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024"
    },
    new BasketValueDto
    {
        Value = "G032401",
        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024"
    },
    new BasketValueDto
    {
        Value = "G032408",
        Description = "catalogue général MARS 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024"
    },
    new BasketValueDto
    {
        Value = "GAUFFRES211",
        Description = "OFFERT dès 300 EUROS : CADEAU GAUFFRIER\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "J042401",
        Description = "catalogue entretien et hygiène avril 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024"
    },
    new BasketValueDto
    {
        Value = "L012400",
        Description = "Commandes export 2024\nCode par défaut\n350€ HT minimum marchandises\nValidité au 31/12/2024\nAucun cadeau\nPas de welcome pack"
    },
    new BasketValueDto
    {
        Value = "LAPOSTE",
        Description = "MARKET PLACE LAPOSTE\nFrais de port 9,90€"
    },
    new BasketValueDto
    {
        Value = "NWELCOME",
        Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS"
    },
    new BasketValueDto
    {
        Value = "OUTILS830",
        Description = "OFFERT dès 99 EUROS : CADEAU TROUSSE A OUTILS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "POPCORN293",
        Description = "OFFERT dès 300 EUROS : CADEAU MACHINE POP CORN\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "PRIVILEGE",
        Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS"
    },
    new BasketValueDto
    {
        Value = "RAJABLOG",
        Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025"
    },
    new BasketValueDto
    {
        Value = "RITUALS162",
        Description = "OFFERT dès 400 EUROS : CADEAU COFFRET RITUALS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "SOIF483",
        Description = "OFFERT dès 99 EUROS : CADEAU BOUTEILLE ISOTHERME YOKO \nvalidité au 1/04/2027\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "THANKYOU",
        Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025"
    },
    new BasketValueDto
    {
        Value = "THEIERE749",
        Description = "OFFERT dès 200 EUROS : CADEAU THEIERE NOMADE YOKO\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "W032400",
        Description = "WEB  MARS 24\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "W042400",
        Description = "WEB  AVRIL 24\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "W052400",
        Description = "WEB  MAI 24\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "W062400",
        Description = "WEB  JUIN 24\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "W072400",
        Description = "WEB  JUILLET 24\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "W082400",
        Description = "WEB  AOUT 24\nwelcome pack si nouveaux clients"
    },
    new BasketValueDto
    {
        Value = "W24999",
        Description = "WEB CATALOGUES ELECTRONIQUES CODE PAR DEFAUT VALIDITE AU 31/12/2024 AUCUN CADEAU PAS DE WELCOME PACK"
    },
    new BasketValueDto
    {
        Value = "WBIENVENUE",
        Description = "Offre de bienvenue : livraison offerte dès 149€ ht + 15% remise"
    },
    new BasketValueDto
    {
        Value = "WELCOMEPACK",
        Description = "Offre nouveaux clients : SEPT22 CLIENTS\nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS\nVALIDITE AU 28/02/2023"
    },
    new BasketValueDto
    {
        Value = "Y032400",
        Description = "TARIFS FILIALES MARS 24\nVALIDITE AU 31/08/2024"
    }
};


    //warrantyCostOptions   P0130512
    public static List<BasketValueDto?> warrantyCostOptionsP0130512 = new List<BasketValueDto>
{
    new BasketValueDto
    {
        Description = "GO activée",
        Value = "Enabled"
    },
    new BasketValueDto
    {
        Description = "GO désactivée",
        Value = "Disabled"
    },
    new BasketValueDto
    {
        Description = "GO offerte",
        Value = "Offered"
    }
};


    //shippingCostOptions   P0130512
    public static List<BasketValueDto?> shippingCostOptionsP0130512 = new List<BasketValueDto>
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
};


    //===========================================================================================================

    //"P0130652" // 
    //  api/orderContext/P0130652/generalInfo
    public static BasketGeneralInfoDto generalInfoP0130652 = new BasketGeneralInfoDto
    {
        OrderType = "Panier",
        BasketId = "P0130652",
        OrderId = "P0130652",
        OrderStatus = "Nouveau",
        OrderDate = "2024-07-09 15:01:37",
        SalesResponsible = "Imad.BOUGATAIA.ext"
    };


    // orderInfo   P0130652
    public static BasketOrderInfoDto orderInfoP0130652 = new BasketOrderInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte commandeur",
            Status = "onlyForDisplay",
            Value = new AccountDto
            {
                AccountId = "A1619588",
                Name = "TRUE BEAUTY",
                Recipient = "",
                Building = "",
                Street = "25 CHEMIN DE LA PIERRE",
                Locality = "",
                ZipCode = "95260",
                City = "BEAUMONT SUR OISE CEDEX",
                Country = "FRANCE",
                Email = "true.beauty@test.fr",
                Phone = "0102326252",
                CellularPhone = "0621434586",
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
            Value = null
        },
        CustomerTags = new List<BasketValueDto>(),
        SalesOriginId = new Field<string>
        {
            Name = "Canal de vente",
            Status = "readWrite",
            Value = "Auto",
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
            Status = "required",
            Error = "L'origine e-commerce est obligatoire pour le canal de vente sélectionné",
            Value = "",
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
            Value = null,
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
            Status = "readOnly",
            Value = null
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
            Value = ""
        }
    };


    //orderByContacts   P0130652
    public static List<ContactDto?> orderByContactsP0130652 = new List<ContactDto?>
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
        ContactId = "X4699725",
        SocialTitle = "Mme",
        FirstName = "",
        LastName = "BIBIBI",
        Email = "",
        Phone = "",
        CellularPhone = "0621434586"
    },
    new ContactDto
    {
        ContactId = "X4690278",
        SocialTitle = "M.",
        FirstName = "KIM",
        LastName = "LIM",
        Email = "kim.lim@test.fr",
        Phone = "0136251425",
        CellularPhone = "0621325465"
    }
};


    //customerTags   P0130652
    public static List<BasketValueDto?> customerTagsP0130652 = new List<BasketValueDto?>
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
};


    //salesPools   P0130652
    public static List<BasketValueDto?> salesPoolsP0130652 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = null,
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
};


    //salesOrigins   P0130652
    public static List<SalesOriginDto?> salesOriginsP0130652 = new List<SalesOriginDto?>
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
};

    //webOrigins    // orderInfo   P0130652
    public static List<BasketValueDto?> webOriginsP0130652 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = null,
        Value = ""
    },
    new BasketValueDto
    {
        Description = null,
        Value = "3M"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "Air Liquide"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "AIRBUS"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "ALSTOM"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "AMAZON"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "ARIBA"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "BIRCHSTREET"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "BOSCH"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "BURBERRY"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "BUT"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "Catalogue"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "CEVA"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "CHRHANSEN"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "COUPA"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "COUPAAdvantage"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "CPO"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "CPOSolution"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "DAHER"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "DBSCHENKER"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "DECATHLON"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "DESKTOP"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "DETERMINE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "DFS"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "EBAY"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "EDILIANS"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "ELCO"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "E-PROC"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "ESKER"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "ETEX"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "EUROFINS"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "HAXONEO"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "HAXONEO_C0152435"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "HAXONEO-C0152435"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "HERMES"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "IKEA"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "IKEA_ARIBA"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "KERRY"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "LaPoste"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "LEROY-SOMER"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "M. BRICOLAGE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "MOBILE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "MONOPRIX"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "MyPlatform"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "NEWELL"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "NEXANS"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "NIKE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "OPELLA"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "ORANGE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "ORANGE-OTL"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_AT"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_BE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_CENPAC"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_CH"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_CZ"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_DE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_DK"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_ES"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_IT"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_NEQST"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_NO"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_PL"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_PT"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_SE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_SK"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_TCENPAC"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJA_UK"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "RAJABUTTON"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SAFRAN"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SANOFI"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SGS"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SIEMENS"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SIEMENS GAMESA"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SIEMENSE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SIEMENSFR"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SKF"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SOLVAYRHODIA"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "SOR_BUTTON"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "STACI"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "TASTER"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "TOTAL"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "UNILEVER"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "URGO"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "VAILLANT"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "WELCOMEOFFICE"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "XPO"
    },
    new BasketValueDto
    {
        Description = null,
        Value = "YVES ROCHER"
    }
};


    //procedureCall => SalesOrigin = Internet   P0130652
    public static ProcedureCallResponseDto procedureCallResponseP0130652_1 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property SalesOriginId updated with value Internet",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "orderInfo",
        "pricesInfo",
        "invoiceInfo"
    }
    };


    //procedureCall => RAJ_WebSalesId = W01234567   P0130652
    public static ProcedureCallResponseDto procedureCallResponseP0130652_2 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property RAJ_WebSalesId updated with value W01234567",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications"
    }
    };


    //procedureCall => MayLastColumnDiscount = true   P0130652
    public static ProcedureCallResponseDto procedureCallResponseP0130652_3 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property MyLastColumnDiscount updated with value True",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "pricesInfo",
        "orderLines"
    }
    };


    //procedureCall => UpdateContact(OrderBy, X2567124   P0130652
    public static ProcedureCallResponseDto procedureCallResponseP0130652_4 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Contact X2567124 updated",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications"
    }
    };


    //procedureCall => addorderLine(CAS10,100)   P0130652
    public static ProcedureCallResponseDto procedureCallResponseP0130652_5 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Article CAS10 added with quantity 100",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "pricesInfo",
        "orderLines"
    }
    };


    //orderInfo => Check update values   P0130652
    public static BasketOrderInfoDto orderInfoP0130652_2 = new BasketOrderInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte commandeur",
            Status = "onlyForDisplay",
            Value = new AccountDto
            {
                AccountId = "A1619588",
                Name = "TRUE BEAUTY",
                Recipient = "",
                Building = "",
                Street = "25 CHEMIN DE LA PIERRE",
                Locality = "",
                ZipCode = "95260",
                City = "BEAUMONT SUR OISE CEDEX",
                Country = "FRANCE",
                Email = "true.beauty@test.fr",
                Phone = "0102326252",
                CellularPhone = "0621434586",
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
            Value = null
        },
        CustomerTags = new List<BasketValueDto>(),
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
            Value = null,
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
            Value = "W01234567",
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
            Value = ""
        }
    };


    //deliveryInfo   P0130652
    public static BasketDeliveryInfoDto deliveryInfoP0130652 = new BasketDeliveryInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte de livraison",
            Status = "readWrite",
            Value = new AccountDto
            {
                AccountId = "A1619588",
                Name = "TRUE BEAUTY",
                Recipient = "",
                Building = "",
                Street = "25 CHEMIN DE LA PIERRE",
                Locality = "",
                ZipCode = "95260",
                City = "BEAUMONT SUR OISE CEDEX",
                Country = "FRANCE",
                Email = "true.beauty@test.fr",
                Phone = "0102326252",
                CellularPhone = "0621434586",
                Blocked = false
            },
            ProcedureCall = new List<string?>
        {
            "UpdateCustomer",
            "DeliverTo",
            "<one of /deliverToAccounts accountId>"
        }
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
            ProcedureCall = new List<string?>
        {
            "UpdateContact",
            "DeliverTo",
            "<one of /deliverToContacts contactId>"
        }
        },
        DeliveryMode = new Field<string>
        {
            Name = "Mode de livraison",
            Status = "readWrite",
            Value = "Normal",
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "RAJ_GenericDlvMode",
            "System.String",
            "<one of /deliveryModes value>"
        }
        },
        CompleteDelivery = new Field<bool?>
        {
            Name = "Livraison complète",
            Status = "readWrite",
            Value = false
        },
        ImperativeDate = new Field<DateTime?>
        {
            Name = "Date impérative",
            Status = "required",
            Value = null,
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "RAJ_ImperativeDate",
            "DateTime",
            "<value>"
        }
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
            Value = null,
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "DeliveryNote",
            "System.DateTime",
            "<value>"
        }
        },
        NoteMustBeSaved = new Field<bool?>
        {
            Name = "Sauvegarde note de liv.",
            Status = "readWrite",
            Value = true,
            Description = "Sauvegarde pour les prochaines commandes",
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "IsDeliveryNoteSaved",
            "System.Boolean",
            "<value>"
        }
        }
    };


    //deliverToAccounts   P0130652
    public static List<AccountDto?> deliverToAccountsP0130652 = new List<AccountDto?>
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
        AccountId = "A1619588",
        Name = "TRUE BEAUTY",
        Recipient = "",
        Building = "",
        Street = "25 CHEMIN DE LA PIERRE",
        Locality = "",
        ZipCode = "95260",
        City = "BEAUMONT SUR OISE CEDEX",
        Country = "FRANCE",
        Email = "true.beauty@test.fr",
        Phone = "0102326252",
        CellularPhone = "0621434586",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057731",
        Name = "TRUE BEAUTY",
        Recipient = "",
        Building = "",
        Street = "25 CHEMIN DE LA PIERRE",
        Locality = "",
        ZipCode = "95260",
        City = "BEAUMONT SUR OISE",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057609",
        Name = "TRUE BEAUTY",
        Recipient = "",
        Building = "",
        Street = "15 ROUTE TOURNANTE DU GRAND PARC",
        Locality = "",
        ZipCode = "60200",
        City = "COMPIEGNE",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057627",
        Name = "TRUE BEAUTY",
        Recipient = "",
        Building = "",
        Street = "12 RUE EDMOND BAILLEUX",
        Locality = "",
        ZipCode = "59000",
        City = "LILLE",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057615",
        Name = "TRUE BEAUTY",
        Recipient = "",
        Building = "",
        Street = "10 RUE DE LA BELLE ETOILE",
        Locality = "",
        ZipCode = "83000",
        City = "TOULON",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057722",
        Name = "TRUE BEAUTY",
        Recipient = "",
        Building = "",
        Street = "PASEO DE LA CASTELLANA 57",
        Locality = "",
        ZipCode = "28046",
        City = "MADRID",
        Country = "ESPAGNE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "D0057631",
        Name = "TRUE BEAUTY",
        Recipient = "",
        Building = "",
        Street = "15 IMPASSE DE LA FERME ROSE",
        Locality = "",
        ZipCode = "93200",
        City = "ST DENIS",
        Country = "FRANCE",
        Email = null,
        Phone = null,
        CellularPhone = null,
        Blocked = false
    }
};


    //deliverToContacts   P0130652
    public static List<ContactDto?> deliverToContactsP0130652 = new List<ContactDto?>
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
        ContactId = "J0021176",
        SocialTitle = "M.",
        FirstName = "BRYAN",
        LastName = "",
        Email = "",
        Phone = "",
        CellularPhone = "0631955031"
    },
    new ContactDto
    {
        ContactId = "J0021168",
        SocialTitle = "M.",
        FirstName = "SEV",
        LastName = "",
        Email = "",
        Phone = "",
        CellularPhone = "0621434586"
    },
    new ContactDto
    {
        ContactId = "X4699725",
        SocialTitle = "Mme",
        FirstName = "",
        LastName = "BIBIBI",
        Email = "",
        Phone = "",
        CellularPhone = "0621434586"
    },
    new ContactDto
    {
        ContactId = "X4690278",
        SocialTitle = "M.",
        FirstName = "KIM",
        LastName = "LIM",
        Email = "kim.lim@test.fr",
        Phone = "0136251425",
        CellularPhone = "0621325465"
    },
    new ContactDto
    {
        ContactId = "J0021064",
        SocialTitle = "M.",
        FirstName = "SEV",
        LastName = "TEST",
        Email = "severine.courcelle@raja.fr",
        Phone = "",
        CellularPhone = ""
    }
};


    //deliveryModes   P0130652
    public static List<BasketValueDto?> deliveryModesP0130652 = new List<BasketValueDto?>
{
    new BasketValueDto { Value = "Catalogue" },
    new BasketValueDto { Value = "Enlèvement" },
    new BasketValueDto { Value = "Express" },
    new BasketValueDto { Value = "Filiale" },
    new BasketValueDto { Value = "Interne" },
    new BasketValueDto { Value = "Normal" },
    new BasketValueDto { Value = "VCT" }
};


    //invoiceInfo   P0130652
    public static BasketInvoiceInfoDto invoiceInfoP0130652 = new BasketInvoiceInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte de facturation",
            Status = "readWrite",
            Value = new AccountDto
            {
                AccountId = "A1619588",
                Name = "TRUE BEAUTY",
                Recipient = "",
                Building = "",
                Street = "25 CHEMIN DE LA PIERRE",
                Locality = "",
                ZipCode = "95260",
                City = "BEAUMONT SUR OISE CEDEX",
                Country = "FRANCE",
                Email = "true.beauty@test.fr",
                Phone = "0102326252",
                CellularPhone = "0621434586",
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
            Value = ""
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
            Value = "COMPTANT"
        },
        PaymentMode = new Field<string>
        {
            Name = "Mode de paiement",
            Status = "readWrite",
            Value = "CH",
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
            Value = "cccc"
        }
    };


    //invoiceToAccounts   P0130652
    public static List<AccountDto?> invoiceToAccountsP0130652 = new List<AccountDto?>
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
        AccountId = "A1619588",
        Name = "TRUE BEAUTY",
        Recipient = "",
        Building = "",
        Street = "25 CHEMIN DE LA PIERRE",
        Locality = "",
        ZipCode = "95260",
        City = "BEAUMONT SUR OISE CEDEX",
        Country = "FRANCE",
        Email = "true.beauty@test.fr",
        Phone = "0102326252",
        CellularPhone = "0621434586",
        Blocked = false
    }
};

    //TaxGroups   P0130652
    public static List<BasketValueDto?> taxGroupsP0130652 = new List<BasketValueDto?>
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
};


    //paymentModes   P0130652
    public static List<BasketValueDto?> paymentModesP0130652 = new List<BasketValueDto?>
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
};


    //tradeInfo   P0130652
    public static BasketTradeInfoDto tradeInfoP0130652 = new BasketTradeInfoDto
    {
        Turnover = new Field<List<BasketTurnoverLineDto?>>
        {
            Name = "Chiffre d'affaire",
            Status = "onlyForDisplay",
            Value = new List<BasketTurnoverLineDto?>
        {
            new BasketTurnoverLineDto
            {
                Name = "Classe",
                Ytd = "",
                YtdN1 = "",
                N1 = "",
                N2 = ""
            },
            new BasketTurnoverLineDto
            {
                Name = "CA.",
                Ytd = "0 €",
                YtdN1 = "0 €",
                N1 = "0 €",
                N2 = "0 €"
            },
            new BasketTurnoverLineDto
            {
                Name = "Evol. CA.",
                Ytd = "0 %",
                YtdN1 = "",
                N1 = "",
                N2 = ""
            }
        }
        },
        Contract = new BasketContractInfoDto
        {
            ContractId = new Field<string>
            {
                Name = "Contrat",
                Status = "onlyForDisplay",
                Value = null
            },
            ContractType = new Field<string>
            {
                Name = "Type",
                Status = "onlyForDisplay",
                Value = null
            },
            ContractGroup = new Field<string>
            {
                Name = "Groupe de contrat",
                Status = "onlyForDisplay",
                Value = ""
            },
            Status = new Field<string>
            {
                Name = "Statut",
                Status = "onlyForDisplay",
                Value = null
            },
            StartDate = new Field<string>
            {
                Name = "Date de début",
                Status = "onlyForDisplay",
                Value = null
            },
            EndDate = new Field<string>
            {
                Name = "Date de fin",
                Status = "onlyForDisplay",
                Value = null
            },
            CampaignId = new Field<string>
            {
                Name = "Campagne de prix",
                Status = "onlyForDisplay",
                Value = null
            },
            MainContact = new Field<string>
            {
                Name = "Commercial terrain",
                Status = "onlyForDisplay",
                Value = null
            },
            OfficeExecutive = new Field<string>
            {
                Name = "Commercial sédentaire",
                Status = "onlyForDisplay",
                Value = null
            },
            DiscountList = new Field<List<string?>>
            {
                Name = "Description",
                Status = "onlyForDisplay",
                Value = new List<string?>()
            }
        }
    };


    //pricesInfo   P0130652
    public static BasketPricesInfoDto pricesInfoP0130652 = new BasketPricesInfoDto
    {
        // Column 1
        Coupon = new Field<string?>
        {
            Name = "Code Action",
            Status = "readWrite",
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
            Value = 2.5m
        },
        GiftAmountThreshold = new Field<decimal?>
        {
            Name = "Diff KDO",
            Status = "onlyForDisplay",
            Value = null
        },
        ProductsInfo = new Field<string?>
        {
            Name = "Dispo. Marchandise",
            Status = "onlyForDisplay",
            Value = "En stock"
        },

        // Column 2
        ProductsNetAmount = new Field<decimal?>
        {
            Name = "Marchandise HT",
            Status = "onlyForDisplay",
            Value = 197.5m
        },
        WarrantyCostOption = new Field<string?>
        {
            Name = "Type de garantie optimale",
            Status = "readWrite",
            Value = "Enabled",
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
            Value = 4.94m
        },
        ShippingCostOption = new Field<string?>
        {
            Name = "Type de frais de port",
            Status = "readWrite",
            Value = "Enabled",
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
            Value = 9.9m,
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
            Value = 212.34m
        },
        VatAmount = new Field<decimal?>
        {
            Name = "Montant TVA",
            Status = "onlyForDisplay",
            Value = 42.47m
        },
        TotalGrossAmount = new Field<decimal?>
        {
            Name = "Montant TTC",
            Status = "onlyForDisplay",
            Value = 254.81m
        },
        // Column 4
        OrderDiscountRate = new Field<int?>
        {
            Name = "Remise Cde (%)",
            Status = "readWrite",
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
            Value = true,
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "MyLastColumnDiscount",
            "System.Boolean",
            "<value>"
        }
        },
        AdditionalSalesAmount = new Field<decimal?>
        {
            Name = "Ventes add. (€)",
            Status = "onlyForDisplay",
            Value = 0m
        },
        DiscountAmount = new Field<decimal?>
        {
            Name = "Remise Cde (€)",
            Status = "onlyForDisplay",
            Value = 31.5m
        },
        TotalWeight = new Field<decimal?>
        {
            Name = "Poids (kg)",
            Status = "onlyForDisplay",
            Value = 39.3m
        },
        TotalVolume = new Field<decimal?>
        {
            Name = "Volume (m3)",
            Status = "onlyForDisplay",
            Value = 0.302m
        }
    };


    //coupons   P0130652
    public static List<BasketValueDto?> couponsP0130652 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = null,
        Value = ""
    },
    new BasketValueDto
    {
        Description = "COMMANDES nefab  2010\nCODE PAR DEFAUT\nVALIDITE INDETERMINEE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis",
        Value = "AC0100"
    },
    new BasketValueDto
    {
        Description = "COMMANDES AIRBUS  2011-2012\nCODE PAR DEFAUT\nVALIDITE INDETERMINE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis",
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
        Description = "OFFERT dès 300 EUROS : CADEAU GAUFFRIER\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "GAUFFRES211"
    },
    new BasketValueDto
    {
        Description = "catalogue entretien et hygiène avril 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024",
        Value = "J042401"
    },
    new BasketValueDto
    {
        Description = "Commandes export 2024\nCode par défaut\n350€ HT minimum marchandises\nValidité au 31/12/2024\nAucun cadeau\nPas de welcome pack",
        Value = "L012400"
    },
    new BasketValueDto
    {
        Description = "MARKET PLACE LAPOSTE\nFrais de port 9,90€",
        Value = "LAPOSTE"
    },
    new BasketValueDto
    {
        Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS",
        Value = "NWELCOME"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 99 EUROS : CADEAU TROUSSE A OUTILS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "OUTILS830"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 300 EUROS : CADEAU MACHINE POP CORN\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "POPCORN293"
    },
    new BasketValueDto
    {
        Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS",
        Value = "PRIVILEGE"
    },
    new BasketValueDto
    {
        Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025",
        Value = "RAJABLOG"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 400 EUROS : CADEAU COFFRET RITUALS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "RITUALS162"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 99 EUROS : CADEAU BOUTEILLE ISOTHERME YOKO \nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "SOIF483"
    },
    new BasketValueDto
    {
        Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025",
        Value = "THANKYOU"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 200 EUROS : CADEAU THEIERE NOMADE YOKO\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "THEIERE749"
    },
    new BasketValueDto
    {
        Description = "WEB  MARS 24\nwelcome pack si nouveaux clients",
        Value = "W032400"
    },
    new BasketValueDto
    {
        Description = "WEB  AVRIL 24\nwelcome pack si nouveaux clients",
        Value = "W042400"
    },
    new BasketValueDto
    {
        Description = "WEB  MAI 24\nwelcome pack si nouveaux clients",
        Value = "W052400"
    },
    new BasketValueDto
    {
        Description = "WEB  JUIN 24\nwelcome pack si nouveaux clients",
        Value = "W062400"
    },
    new BasketValueDto
    {
        Description = "WEB  JUILLET 24\nwelcome pack si nouveaux clients",
        Value = "W072400"
    },
    new BasketValueDto
    {
        Description = "WEB  AOUT 24\nwelcome pack si nouveaux clients",
        Value = "W082400"
    },
    new BasketValueDto
    {
        Description = "WEB CATALOGUES ELECTRONIQUES CODE PAR DEFAUT VALIDITE AU 31/12/2024 AUCUN CADEAU PAS DE WELCOME PACK",
        Value = "W24999"
    },
    new BasketValueDto
    {
        Description = "Offre de bienvenue : livraison offerte dès 149€ ht + 15% remise",
        Value = "WBIENVENUE"
    },
    new BasketValueDto
    {
        Description = "Offre nouveaux clients : SEPT22 CLIENTS\nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS\nVALIDITE AU 28/02/2023",
        Value = "WELCOMEPACK"
    },
    new BasketValueDto
    {
        Description = "TARIFS FILIALES MARS 24\nVALIDITE AU 31/08/2024",
        Value = "Y032400"
    }
};


    //warrantyCostOptions   P0130652
    public static List<BasketValueDto?> warrantyCostOptionsP0130652 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = "GO activée",
        Value = "Enabled"
    },
    new BasketValueDto
    {
        Description = "GO désactivée",
        Value = "Disabled"
    },
    new BasketValueDto
    {
        Description = "GO offerte",
        Value = "Offered"
    }
};


    //shippingCostOptions   P0130652
    public static List<BasketValueDto?> shippingCostOptionsP0130652 = new List<BasketValueDto>
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
};


    //===========================================================================================================

    //"P0130863" // secteur d'activité
    // generalInfo  P0130863
    public static BasketGeneralInfoDto generalInfoP0130863 = new BasketGeneralInfoDto
    {
        OrderType = "Avoir/Retour",
        BasketId = "P0130863",
        OrderId = "P0130863",
        OrderStatus = "Nouveau",
        OrderDate = "2024-07-20 20:08:38",
        SalesResponsible = "CEDRIC REVILLON"
    };


    // orderInfo  P0130863
    public static BasketOrderInfoDto orderInfoP0130863 = new BasketOrderInfoDto
    {
        Account = new Field<AccountDto>
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
        Contact = new Field<ContactDto>
        {
            Name = "Contact commandeur",
            Status = "readOnly",
            Value = new ContactDto
            {
                ContactId = "X2505625",
                SocialTitle = "M.",
                FirstName = "AYMERIC",
                LastName = "BESSON",
                Email = "raja1234@raja.fr",
                Phone = "0120281279",
                CellularPhone = "0120281279"
            }
        },
        ActivityArea = new Field<string>
        {
            Name = "Secteur d'activité",
            Status = "onlyForDisplay",
            Value = "Messagerie, fret express",
            Description = "Code NAF: 5229A"
        },
        CustomerTags = new List<BasketValueDto>
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
            Status = "readOnly",
            Value = "E-mail"
        },
        WebOriginId = new Field<string>
        {
            Name = "Origine e-commerce",
            Status = "readOnly",
            Value = ""
        },
        SalesPoolId = new Field<string>
        {
            Name = "Type de transaction",
            Status = "readOnly",
            Value = "NOR"
        },
        CustomerOrderRef = new Field<string>
        {
            Name = "Référence Client",
            Status = "readOnly",
            Value = "BDC-CHR-2024-003027"
        },
        WebSalesId = new Field<string>
        {
            Name = "Commande Web",
            Status = "readOnly",
            Value = ""
        },
        RelatedLink = new Field<string>
        {
            Name = "Dossier SAV / Commande",
            Status = "onlyForDisplay",
            Value = "R0031591 / 24136045",
            Url = "SalesId=24136045"
        },
        Note = new Field<string>
        {
            Name = "Note de RC",
            Status = "onlyForDisplay",
            Value = "29/10/2019 ******A TRAITER PAR L'EQUIPE VIP*******LORS DE LA SAISIE DES COMMANDES LE COMPTE D IMPUTATION ET LE NUMERO DE COMMANDE SONT OBLIGATOIRES 03/11/2022  SGR ATTENTION  SUR ORDRE DE MR ARINO NE PAS NOTER DANS LE NO DE CDE  BDC-  MAIS JUSTE LA SUITE CAR SINON NE VOIT PAS LES NUMEROS EN ENTIERS,"
        }
    };


    //orderByContacts   P0130863
    public static List<ContactDto?> orderByContactsP0130863 = new List<ContactDto>
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
    },
    new ContactDto
    {
        ContactId = "61447000",
        SocialTitle = "M.",
        FirstName = "PASCAL",
        LastName = "ARINO",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I4113428",
        SocialTitle = "M.",
        FirstName = "MOHAMMED",
        LastName = "AZAMI IDRISSI",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "X2586595",
        SocialTitle = "Mme",
        FirstName = "LENA",
        LastName = "AZZOUG",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3835469",
        SocialTitle = "Mme",
        FirstName = "MICHELE BLANCHE",
        LastName = "BARBAT",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I4205195",
        SocialTitle = "Mme",
        FirstName = "IMEN",
        LastName = "BAROUDI",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3617901",
        SocialTitle = "M.",
        FirstName = "GILLES",
        LastName = "BATIN",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3188748",
        SocialTitle = "M.",
        FirstName = "DAMIEN",
        LastName = "BEAUCHAMP",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3385996",
        SocialTitle = "Mme",
        FirstName = "CAROLINE",
        LastName = "BEAUDRON",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I1245606",
        SocialTitle = "Mme",
        FirstName = "MARIE",
        LastName = "BENGIO",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I2744857",
        SocialTitle = "M.",
        FirstName = "OLIVIER",
        LastName = "BENGUI",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3044664",
        SocialTitle = "Mme",
        FirstName = "SORAYA",
        LastName = "BENIDDER",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3807710",
        SocialTitle = "I",
        FirstName = "",
        LastName = "BENYACOUB",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "X2239428",
        SocialTitle = "M.",
        FirstName = "FREDERIC",
        LastName = "BERNARD",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I1488565",
        SocialTitle = "Mme",
        FirstName = "VIRGINIE",
        LastName = "BERNARD",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3114547",
        SocialTitle = "Mme",
        FirstName = "MARINE",
        LastName = "BERTHIER",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I2751491",
        SocialTitle = "Mme",
        FirstName = "AMELIE",
        LastName = "BERTOLLIN",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I2723298",
        SocialTitle = "Mme",
        FirstName = "HERMELINE",
        LastName = "BESSE",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "X2505625",
        SocialTitle = "M.",
        FirstName = "AYMERIC",
        LastName = "BESSON",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "X2583853",
        SocialTitle = "M.",
        FirstName = "AYMERIC",
        LastName = "BESSON",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I2728676",
        SocialTitle = "M.",
        FirstName = "DIDIER",
        LastName = "BEYER",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I2213439",
        SocialTitle = "Mme",
        FirstName = "",
        LastName = "BEZIER",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I1760290",
        SocialTitle = "Mme",
        FirstName = "LAURIE",
        LastName = "BEZIER",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I1912650",
        SocialTitle = "Mme",
        FirstName = "DELPHINE",
        LastName = "BIARDEAU",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3103722",
        SocialTitle = "Mme",
        FirstName = "DELPHINE",
        LastName = "BIARDEAU",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I4366300",
        SocialTitle = "M.",
        FirstName = "ALEXANDRE",
        LastName = "BIDAL",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3828161",
        SocialTitle = "M.",
        FirstName = "YANNICK",
        LastName = "BLANCHARD",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    }
};

    //customerTags   P0130863
    public static List<BasketValueDto?> customerTagsP0130863 = new List<BasketValueDto>
{
    new BasketValueDto
    {
        Value = "vip",
        Description = "Client VIP"
    },
    new BasketValueDto
    {
        Value = "specialPrep",
        Description = "Préparation spéciale"
    },
    new BasketValueDto
    {
        Value = "export",
        Description = "Client Export"
    },
    new BasketValueDto
    {
        Value = "noGift",
        Description = "Pas de cadeaux"
    },
    new BasketValueDto
    {
        Value = "completeDelivery",
        Description = "Livraison complète"
    }
};


    //salesPools   P0130863
    public static List<BasketValueDto?> salesPoolsP0130863 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Value = null, // or use an empty string if null is not acceptable
        Description = null // or an empty string if null is not acceptable
    },
    new BasketValueDto
    {
        Value = "NOR",
        Description = "Commande normale"
    },
    new BasketValueDto
    {
        Value = "LIE",
        Description = "Commande liée"
    },
    new BasketValueDto
    {
        Value = "ECH",
        Description = "Commande d'échantillons"
    }
};


    //salesOrigins   P0130863
    public static List<SalesOriginDto?> salesOriginsP0130863 = new List<SalesOriginDto?>
{
    new SalesOriginDto { Value = "" },
    new SalesOriginDto { Value = "Téléphone" },
    new SalesOriginDto { Value = "E-mail" },
    new SalesOriginDto { Value = "Fax" },
    new SalesOriginDto { Value = "Courrier" },
    new SalesOriginDto { Value = "Comptoir" },
    new SalesOriginDto { Value = "Chat" },
    new SalesOriginDto { Value = "E-Proc" },
    new SalesOriginDto { Value = "Sortant" },
    new SalesOriginDto { Value = "Internet" },
    new SalesOriginDto { Value = "Auto" },
    new SalesOriginDto { Value = "EDI" },
    new SalesOriginDto { Value = "Terrain" },
    new SalesOriginDto { Value = "Interne" }
};


    //webOrigins   P0130863
    public static List<BasketValueDto?> webOriginsP0130863 = new List<BasketValueDto?>
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
    new BasketValueDto { Value = "EBAY" },
    new BasketValueDto { Value = "EDILIANS" },
    new BasketValueDto { Value = "ELCO" },
    new BasketValueDto { Value = "E-PROC" },
    new BasketValueDto { Value = "ESKER" },
    new BasketValueDto { Value = "ETEX" },
    new BasketValueDto { Value = "EUROFINS" },
    new BasketValueDto { Value = "HAXONEO" },
    new BasketValueDto { Value = "HAXONEO_C0152435" },
    new BasketValueDto { Value = "HAXONEO-C0152435" },
    new BasketValueDto { Value = "HERMES" },
    new BasketValueDto { Value = "IKEA" },
    new BasketValueDto { Value = "IKEA_ARIBA" },
    new BasketValueDto { Value = "KERRY" },
    new BasketValueDto { Value = "LaPoste" },
    new BasketValueDto { Value = "LEROY-SOMER" },
    new BasketValueDto { Value = "M. BRICOLAGE" },
    new BasketValueDto { Value = "MOBILE" },
    new BasketValueDto { Value = "MONOPRIX" },
    new BasketValueDto { Value = "MyPlatform" },
    new BasketValueDto { Value = "NEWELL" },
    new BasketValueDto { Value = "NEXANS" },
    new BasketValueDto { Value = "NIKE" },
    new BasketValueDto { Value = "OPELLA" },
    new BasketValueDto { Value = "ORANGE" },
    new BasketValueDto { Value = "ORANGE-OTL" },
    new BasketValueDto { Value = "RAJA_AT" },
    new BasketValueDto { Value = "RAJA_BE" },
    new BasketValueDto { Value = "RAJA_CENPAC" },
    new BasketValueDto { Value = "RAJA_CH" },
    new BasketValueDto { Value = "RAJA_CZ" },
    new BasketValueDto { Value = "RAJA_DE" },
    new BasketValueDto { Value = "RAJA_DK" },
    new BasketValueDto { Value = "RAJA_ES" },
    new BasketValueDto { Value = "RAJA_IT" },
    new BasketValueDto { Value = "RAJA_NEQST" },
    new BasketValueDto { Value = "RAJA_NO" },
};


    //procedureCall => SalesOrigin = Internet   P0130863
    public static ProcedureCallResponseDto procedureCallResponseP0130863_1 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property SalesOriginId updated with value Internet",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "orderInfo",
        "pricesInfo",
        "invoiceInfo"
    }
    };


    //procedureCall => RAJ_WebSalesId = W01234567   P0130863
    public static ProcedureCallResponseDto procedureCallResponseP0130863_2 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property RAJ_WebSalesId updated with value W01234567",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications"
    }
    };


    //procedureCall => MayLastColumnDiscount = true   P0130863
    public static ProcedureCallResponseDto procedureCallResponseP0130863_3 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Property MyLastColumnDiscount updated with value True",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "pricesInfo",
        "orderLines"
    }
    };


    //procedureCall => UpdateContact(OrderBy, X2567124   P0130863
    public static ProcedureCallResponseDto procedureCallResponseP0130863_4 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Contact X2567124 updated",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications"
    }
    };


    //procedureCall => addorderLine(CAS10,100)   P0130863
    public static ProcedureCallResponseDto procedureCallResponseP0130863_5 = new ProcedureCallResponseDto
    {
        Success = true,
        Message = "Article CAS10 added with quantity 50",
        UpdateDone = true,
        RefreshCalls = new List<string?>
    {
        "generalInfo",
        "notifications",
        "pricesInfo",
        "orderLines"
    }
    };


    //orderInfo => Check update values   P0130863
    public static BasketOrderInfoDto orderInfoP0130863_2 = new BasketOrderInfoDto
    {
        Account = new Field<AccountDto>
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
        Contact = new Field<ContactDto>
        {
            Name = "Contact commandeur",
            Status = "readOnly",
            Value = new ContactDto
            {
                ContactId = null,
                SocialTitle = null,
                FirstName = null,
                LastName = null,
                Email = null,
                Phone = null,
                CellularPhone = null
            }
        },
        ActivityArea = new Field<string>
        {
            Name = "Secteur d'activité",
            Status = "onlyForDisplay",
            Value = "Messagerie, fret express",
            Description = "Code NAF: 5229A"
        },
        CustomerTags = new List<BasketValueDto>
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
            Status = "readOnly",
            Value = "Internet"
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
            Status = "readOnly",
            Value = "NOR"
        },
        CustomerOrderRef = new Field<string>
        {
            Name = "Référence Client",
            Status = "readOnly",
            Value = "BDC-CHR-2024-003027"
        },
        WebSalesId = new Field<string>
        {
            Name = "Commande Web",
            Status = "readWrite",
            Value = "W01234567",
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
            Name = "Dossier SAV / Commande",
            Status = "onlyForDisplay",
            Value = "R0031591 / 24136045",
            Url = "SalesId=2"
        }
    };


    //deliveryInfo   P0130863
    public static BasketDeliveryInfoDto deliveryInfoP0130863 = new BasketDeliveryInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte de livraison",
            Status = "readWrite",
            Value = new AccountDto
            {
                AccountId = "95145761",
                Name = "CHRONOPOST",
                Recipient = "CC 211296",
                Building = "CARGO 7",
                Street = "9 RUE DU HAUT DE LAVAL",
                Locality = "BP 10506",
                ZipCode = "95709",
                City = "ROISSY CHARLES DE GAULLE CEDEX 1",
                Country = null,
                Email = "raja1234@raja.fr",
                Phone = "0120281279",
                CellularPhone = "0120281279",
                Blocked = false
            },
            ProcedureCall = new List<string?>
        {
            "UpdateCustomer",
            "DeliverTo",
            "<one of /deliverToAccounts accountId>"
        }
        },
        Contact = new Field<ContactDto>
        {
            Name = "Contact de livraison",
            Status = "readWrite",
            Value = new ContactDto
            {
                ContactId = "I1894692",
                SocialTitle = "M.",
                FirstName = "AYMERIC",
                LastName = "BESSON",
                Email = "raja1234@raja.fr",
                Phone = "0120281279",
                CellularPhone = "0120281279"
            },
            ProcedureCall = new List<string?>
        {
            "UpdateContact",
            "DeliverTo",
            "<one of /deliverToContacts contactId>"
        }
        },
        DeliveryMode = new Field<string>
        {
            Name = "Mode de livraison",
            Status = "readWrite",
            Value = "Normal",
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "RAJ_GenericDlvMode",
            "System.String",
            "<one of /deliveryModes value>"
        }
        },
        CompleteDelivery = new Field<bool?>
        {
            Name = "Livraison complète",
            Status = "readWrite",
            Value = false
        },
        ImperativeDate = new Field<DateTime?>
        {
            Name = "Date impérative",
            Status = "required",
            Value = null,
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "RAJ_ImperativeDate",
            "DateTime",
            "<value>"
        }
        },
        OrderDocuments = new Field<List<string?>>
        {
            Name = "BL / Factures",
            Status = "onlyForDisplay",
            Value = new List<string?>
        {
            "07/05/24 - BL 24213216 - PN2 - Chargé",
            "30/06/24 - Facture 24F171476",
            "19/07/24 - Avoir 24A006866"
        }
        },
        Note = new Field<string>
        {
            Name = "Note de livraison",
            Status = "readWrite",
            Value = "LES LIVRAISONS SONT A REMETTRE A LA PERSONNE D INDIQUEE SUR LE BL CLH",
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "DeliveryNote",
            "System.DateTime",
            "<value>"
        }
        },
        NoteMustBeSaved = new Field<bool?>
        {
            Name = "Sauvegarde note de liv.",
            Status = "readWrite",
            Value = false,
            Description = "Sauvegarde pour les prochaines commandes",
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "IsDeliveryNoteSaved",
            "System.Boolean",
            "<value>"
        }
        }
    };


    //deliverToAccounts   P0130863
    public static List<AccountDto?> deliverToAccountsP0130863 = new List<AccountDto?>
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
    },
    new AccountDto
    {
        AccountId = "C0211553",
        Name = "CHRONOPOST",
        Recipient = "CC 0211169",
        Building = "",
        Street = "6 AVENUE GABRIEL PERI",
        Locality = "",
        ZipCode = "69960",
        City = "CORBAS",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "C0298281",
        Name = "CHRONOPOST SAS",
        Recipient = "AGENCE DE ALBI CC 211181",
        Building = "ZONE ALBIPOLE",
        Street = "23 AVENUE DE LA MARTELLE",
        Locality = "",
        ZipCode = "81150",
        City = "TERSSAC",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "C0666686",
        Name = "CHRONOPOST SAS HUB CHRONOPOST",
        Recipient = "CC 211296",
        Building = "CARGO 9",
        Street = "9 RUE DU HAUT DE LAVAL",
        Locality = "",
        ZipCode = "95709",
        City = "ROISSY CHARLES DE GAULLE CEDEX 1",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "95145761",
        Name = "CHRONOPOST",
        Recipient = "CC 211296",
        Building = "CARGO 7",
        Street = "9 RUE DU HAUT DE LAVAL",
        Locality = "BP 10506",
        ZipCode = "95709",
        City = "ROISSY CHARLES DE GAULLE CEDEX 1",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "C0215090",
        Name = "CHRONOPOST",
        Recipient = "CC 211168",
        Building = "ZAC N 2 PARC DES COLLINES 2",
        Street = "2 RUE DE ROME",
        Locality = "DIDENHEIM",
        ZipCode = "68350",
        City = "BRUNSTATT DIDENHEIM",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "C0503265",
        Name = "CHRONOPOST AGENCE DE BRIVE",
        Recipient = "CC 211119",
        Building = "ZONE INDUSTRIELLE LA ROCHE BRIVE",
        Street = "100 RUE DES LEVADES",
        Locality = "",
        ZipCode = "19600",
        City = "ST PANTALEON DE LARCHE",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "C0213653",
        Name = "CHRONOPOST",
        Recipient = "CC 211176",
        Building = "",
        Street = "72C RUE ARISTIDE BRIAND",
        Locality = "",
        ZipCode = "76650",
        City = "PETIT COURONNE",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "C0678708",
        Name = "CHRONOPOST LA ROCHE S YON",
        Recipient = "CC 211285",
        Building = "PARC ECO 85 ZONE ARTISANALE ACTI EST",
        Street = "40 RUE PIERRE ALLUT",
        Locality = "",
        ZipCode = "85000",
        City = "LA ROCHE SUR YON",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "92155227",
        Name = "CHRONOPOST VILLENEUVE",
        Recipient = "CC 211192",
        Building = "",
        Street = "155 BOULEVARD CHARLES DE GAULLE",
        Locality = "",
        ZipCode = "92396",
        City = "VILLENEUVE LA GARENNE CEDEX",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    },
    new AccountDto
    {
        AccountId = "C0680397",
        Name = "CHRONOPOST PAU",
        Recipient = "0211165",
        Building = "",
        Street = "11 RUE DE L AYGUELONGUE",
        Locality = "",
        ZipCode = "64160",
        City = "MORLAAS",
        Country = null,
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279",
        Blocked = false
    }
};


    //deliverToContacts   P0130863
    public static List<ContactDto?> deliverToContactsP0130863 = new List<ContactDto?>
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
        ContactId = "I3598798",
        SocialTitle = "M.",
        FirstName = "JACQUES",
        LastName = "ARIAS",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "61502299",
        SocialTitle = "Mme",
        FirstName = "MARIE",
        LastName = "BENGIO",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I2750510",
        SocialTitle = "M.",
        FirstName = "OLIVIER",
        LastName = "BENGUI",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I1894692",
        SocialTitle = "M.",
        FirstName = "AYMERIC",
        LastName = "BESSON",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "61502295",
        SocialTitle = "M.",
        FirstName = "DIDIER",
        LastName = "CADASSE",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "61120512",
        SocialTitle = "I",
        FirstName = "",
        LastName = "COULON",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3717428",
        SocialTitle = "Mme",
        FirstName = "GRACIETE",
        LastName = "DA ROCHA",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "61395535",
        SocialTitle = "M.",
        FirstName = "FILIPE",
        LastName = "DA SILVA",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "61308791",
        SocialTitle = "M.",
        FirstName = "",
        LastName = "DERPIERRE",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I2012719",
        SocialTitle = "Mme",
        FirstName = "CHRISTINE",
        LastName = "FRILLAY",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "61202367",
        SocialTitle = "M.",
        FirstName = "D",
        LastName = "LAKROUT",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "61021238",
        SocialTitle = "Mme",
        FirstName = "CHRISTINE MARIA",
        LastName = "LAVERGNE",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I2714552",
        SocialTitle = "M.",
        FirstName = "XAVIER",
        LastName = "MORVAN",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I3109481",
        SocialTitle = "M.",
        FirstName = "FLORENT",
        LastName = "PAILHAS",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "61251328",
        SocialTitle = "Mme",
        FirstName = "LAETITIA",
        LastName = "PHILIPPE",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    },
    new ContactDto
    {
        ContactId = "I1627558",
        SocialTitle = "Mme",
        FirstName = "ANGE",
        LastName = "POGNON",
        Email = "raja1234@raja.fr",
        Phone = "0120281279",
        CellularPhone = "0120281279"
    }
};


    //deliveryModes   P0130863
    public static List<BasketValueDto?> deliveryModesP0130863 = new List<BasketValueDto?>
{
    new BasketValueDto { Value = "Catalogue" },
    new BasketValueDto { Value = "Enlèvement" },
    new BasketValueDto { Value = "Express" },
    new BasketValueDto { Value = "Filiale" },
    new BasketValueDto { Value = "Interne" },
    new BasketValueDto { Value = "Normal" },
    new BasketValueDto { Value = "VCT" }
};


    //invoiceInfo   P0130863
    public static BasketInvoiceInfoDto invoiceInfoP0130863 = new BasketInvoiceInfoDto
    {
        Account = new Field<AccountDto>
        {
            Name = "Compte de facturation",
            Status = "readOnly",
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
        SiretId = new Field<string>
        {
            Name = "Siret",
            Status = "onlyForDisplay",
            Value = "38396013502628"
        },
        TaxGroup = new Field<string>
        {
            Name = "Groupe de taxe",
            Status = "readOnly",
            Value = "F-DEB"
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
            Status = "readOnly",
            Value = "VB"
        },
        IsPublicEntity = false,
        PublicEntityExecutingService = new Field<string>
        {
            Name = "Service exécutif",
            Status = "readOnly",
            Value = ""
        },
        PublicEntityLegalCommitment = new Field<string>
        {
            Name = "Engagement juridique",
            Status = "readOnly",
            Value = ""
        },
        Note = new Field<string>
        {
            Name = null,
            Status = "onlyForDisplay",
            Value = null
        }
    };


    //invoiceToAccounts   P0130863
    public static List<AccountDto?> invoiceToAccountsP0130863 = new List<AccountDto?>
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
};


    //TaxGroups   P0130863
    public static List<BasketValueDto?> taxGroupsP0130863 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = "",
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
};


    //paymentModes   P0130863
    public static List<BasketValueDto?> paymentModesP0130863 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = "",
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
};


    //tradeInfo   P0130863
    public static BasketTradeInfoDto tradeInfoP0130863 = new BasketTradeInfoDto
    {
        Turnover = new Field<List<BasketTurnoverLineDto?>>
        {
            Name = "Chiffre d'affaire",
            Status = "onlyForDisplay",
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
        }
        },
        Contract = new BasketContractInfoDto
        {
            ContractId = new Field<string>
            {
                Name = "Contrat",
                Status = "onlyForDisplay",
                Value = null
            },
            ContractType = new Field<string>
            {
                Name = "Type",
                Status = "onlyForDisplay",
                Value = null
            },
            ContractGroup = new Field<string>
            {
                Name = "Groupe de contrat",
                Status = "onlyForDisplay",
                Value = ""
            },
            Status = new Field<string>
            {
                Name = "Statut",
                Status = "onlyForDisplay",
                Value = null
            },
            StartDate = new Field<string>
            {
                Name = "Date de début",
                Status = "onlyForDisplay",
                Value = null
            },
            EndDate = new Field<string>
            {
                Name = "Date de fin",
                Status = "onlyForDisplay",
                Value = null
            },
            CampaignId = new Field<string>
            {
                Name = "Campagne de prix",
                Status = "onlyForDisplay",
                Value = null
            },
            MainContact = new Field<string>
            {
                Name = "Commercial terrain",
                Status = "onlyForDisplay",
                Value = null
            },
            OfficeExecutive = new Field<string>
            {
                Name = "Commercial sédentaire",
                Status = "onlyForDisplay",
                Value = null
            },
            DiscountList = new Field<List<string?>>
            {
                Name = "Description",
                Status = "onlyForDisplay",
                Value = new List<string?>()
            }
        }
    };


    //pricesInfo   P0130863
    public static BasketPricesInfoDto pricesInfoP0130863 = new BasketPricesInfoDto
    {
        Coupon = new Field<string?>
        {
            Name = "Code Action",
            Status = "readWrite",
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
            Value = null
        },
        GiftAmountThreshold = new Field<decimal?>
        {
            Name = "Diff KDO",
            Status = "onlyForDisplay",
            Value = null
        },
        ProductsInfo = new Field<string?>
        {
            Name = "Dispo. Marchandise",
            Status = "onlyForDisplay",
            Value = "En stock"
        },
        ProductsNetAmount = new Field<decimal?>
        {
            Name = "Marchandise HT",
            Status = "onlyForDisplay",
            Value = 0
        },
        WarrantyCostOption = new Field<string?>
        {
            Name = "Type de garantie optimale",
            Status = "readWrite",
            Value = "Offered",
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
            Value = 0
        },
        ShippingCostOption = new Field<string?>
        {
            Name = "Type de frais de port",
            Status = "readWrite",
            Value = "Offered",
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
            Value = 0,
            ProcedureCall = new List<string?>
        {
            "UpdateOrderTablePropertyValue",
            "DeliveryAmount",
            "System.Double",
            "<value>"
        }
        },
        LogisticInfo = null,
        TotalNetAmount = new Field<decimal?>
        {
            Name = "Montant Total HT",
            Status = "onlyForDisplay",
            Value = 0
        },
        VatAmount = new Field<decimal?>
        {
            Name = "Montant TVA",
            Status = "onlyForDisplay",
            Value = 0
        },
        TotalGrossAmount = new Field<decimal?>
        {
            Name = "Montant TTC",
            Status = "onlyForDisplay",
            Value = 0
        },
        OrderDiscountRate = new Field<int?>
        {
            Name = "Remise Cde (%)",
            Status = "readOnly",
            Value = 0
        },
        OrderLastColumnDiscount = new Field<bool?>
        {
            Name = "Remise Cde DC",
            Status = "readOnly",
            Value = true
        },
        AdditionalSalesAmount = new Field<decimal?>
        {
            Name = "Ventes add. (€)",
            Status = "onlyForDisplay",
            Value = 0
        },
        DiscountAmount = new Field<decimal?>
        {
            Name = "Remise Cde (€)",
            Status = "onlyForDisplay",
            Value = 90.5m
        },
        TotalWeight = new Field<decimal?>
        {
            Name = "Poids (kg)",
            Status = "onlyForDisplay",
            Value = 12
        },
        TotalVolume = new Field<decimal?>
        {
            Name = "Volume (m3)",
            Status = "onlyForDisplay",
            Value = 0.076m
        }
    };


    //coupons   P0130863
    public static List<BasketValueDto?> couponsP0130863 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = "",
        Value = ""
    },
    new BasketValueDto
    {
        Description = "COMMANDES nefab  2010\nCODE PAR DEFAUT\nVALIDITE INDETERMINEE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis",
        Value = "AC0100"
    },
    new BasketValueDto
    {
        Description = "COMMANDES AIRBUS  2011-2012\nCODE PAR DEFAUT\nVALIDITE INDETERMINE\nAUCUN CADEAU\nPAS DE WELCOME PACK\npas d'asile colis",
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
        Description = "OFFERT dès 300 EUROS : CADEAU GAUFFRIER\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "GAUFFRES211"
    },
    new BasketValueDto
    {
        Description = "catalogue entretien et hygiène avril 24\nDefaut \nwelcome pack si nouveaux clients\nvalidité au 31/08/2024",
        Value = "J042401"
    },
    new BasketValueDto
    {
        Description = "Commandes export 2024\nCode par défaut\n350€ HT minimum marchandises\nValidité au 31/12/2024\nAucun cadeau\nPas de welcome pack",
        Value = "L012400"
    },
    new BasketValueDto
    {
        Description = "MARKET PLACE LAPOSTE\nFrais de port 9,90€",
        Value = "LAPOSTE"
    },
    new BasketValueDto
    {
        Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS",
        Value = "NWELCOME"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 99 EUROS : CADEAU TROUSSE A OUTILS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "OUTILS830"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 300 EUROS : CADEAU MACHINE POP CORN\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "POPCORN293"
    },
    new BasketValueDto
    {
        Description = "Offre nouveaux clients : \nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS",
        Value = "PRIVILEGE"
    },
    new BasketValueDto
    {
        Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025",
        Value = "RAJABLOG"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 400 EUROS : CADEAU COFFRET RITUALS\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "RITUALS162"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 99 EUROS : CADEAU BOUTEILLE ISOTHERME YOKO \nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "SOIF483"
    },
    new BasketValueDto
    {
        Description = "Offre  :\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nVALIDITE AU 28/02/2025",
        Value = "THANKYOU"
    },
    new BasketValueDto
    {
        Description = "OFFERT dès 200 EUROS : CADEAU THEIERE NOMADE YOKO\nvalidité au 1/04/2027\nwelcome pack si nouveaux clients",
        Value = "THEIERE749"
    },
    new BasketValueDto
    {
        Description = "WEB  MARS 24\nwelcome pack si nouveaux clients",
        Value = "W032400"
    },
    new BasketValueDto
    {
        Description = "WEB  AVRIL 24\nwelcome pack si nouveaux clients",
        Value = "W042400"
    },
    new BasketValueDto
    {
        Description = "WEB  MAI 24\nwelcome pack si nouveaux clients",
        Value = "W052400"
    },
    new BasketValueDto
    {
        Description = "WEB  JUIN 24\nwelcome pack si nouveaux clients",
        Value = "W062400"
    },
    new BasketValueDto
    {
        Description = "WEB  JUILLET 24\nwelcome pack si nouveaux clients",
        Value = "W072400"
    },
    new BasketValueDto
    {
        Description = "WEB  AOUT 24\nwelcome pack si nouveaux clients",
        Value = "W082400"
    },
    new BasketValueDto
    {
        Description = "WEB CATALOGUES ELECTRONIQUES CODE PAR DEFAUT VALIDITE AU 31/12/2024 AUCUN CADEAU PAS DE WELCOME PACK",
        Value = "W24999"
    },
    new BasketValueDto
    {
        Description = "Offre de bienvenue : livraison offerte dès 149€ ht + 15% remise",
        Value = "WBIENVENUE"
    },
    new BasketValueDto
    {
        Description = "Offre nouveaux clients : SEPT22 CLIENTS\nFRANCO 149€\n*****REMISE EXCEPTIONNELLE DE 15%\nEN AUTOMATIQUE***********\nWELCOME PACK SI NX CLIENTS\nVALIDITE AU 28/02/2023",
        Value = "WELCOMEPACK"
    },
    new BasketValueDto
    {
        Description = "TARIFS FILIALES MARS 24\nVALIDITE AU 31/08/2024",
        Value = "Y032400"
    }
};


    //warrantyCostOptions   P0130863
    public static List<BasketValueDto?> warrantyCostOptionsP0130863 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = "GO remboursée",
        Value = "Enabled"
    },
    new BasketValueDto
    {
        Description = "GO désactivée",
        Value = "Disabled"
    },
    new BasketValueDto
    {
        Description = "GO facturée",
        Value = "Offered"
    }
};


    //shippingCostOptions   P0130863
    public static List<BasketValueDto?> shippingCostOptionsP0130863 = new List<BasketValueDto?>
{
    new BasketValueDto
    {
        Description = "Frais de liv. remboursée",
        Value = "Standard"
    },
    new BasketValueDto
    {
        Description = "Frais de liv. facturée",
        Value = "Offered"
    },
    new BasketValueDto
    {
        Description = "Frais de liv. manuels",
        Value = "Custom"
    }
};
}



    // not yet inmplemented: orderContext: /api/orderContext?ContactId={{contactId}}

    //"success": true,
    //"message": "Basket P0131276 created",
    //"basketId": "P0131276",
    //"url": "http://aliasiisq:86/MyOrderPage?BasketId=P0131276"
    // ================notifications   P0130140

    //var notifications = new List<NotificationDto>
    //{
    //    new NotificationDto
    //    {
    //        NotificationId = 2,
    //        Severity = "Warn",
    //        Message = "<strong>[Commande] Activité commerciale sur le client depuis une semaine:</strong><br/><strong>Commande</strong> <a href=\"/MyOrderPage?SalesId=24137007\" target=\"_blank\">24137007</a> \r\n                            (Réf. KN # TEST)\r\n                            créé(e)\r\n                            \r\n                            jeudi 08 août à 16:02 par KRISTELLE NOUET \r\n                            au statut <strong>Facturée</strong>\r\n                            <br/><strong>Commande</strong> <a href=\"/MyOrderPage?SalesId=24137006\" target=\"_blank\">24137006</a> \r\n                            (Réf. 08/08/2024)\r\n                            créé(e)\r\n                            \r\n                            jeudi 08 août à 14:32 par KRISTELLE NOUET \r\n                            au statut <strong>Facturée</strong>\r\n                            <br/>",
    //        CreatedDate = DateTime.Parse("0001-01-01 00:00:00"),
    //        ProcedureCall = new List<string> { "RemoveLog", "2" }
    //    },
    //    new NotificationDto
    //    {
    //        NotificationId = 1,
    //        Severity = "Info",
    //        Message = "<strong>[Paiement]</strong> Règlement effectué par <strong>Carte Bancaire</strong> pour un montant de <strong>51,48 €</strong> (Autorisation N°4144930086)",
    //        CreatedDate = DateTime.Parse("0001-01-01 00:00:00"),
    //        ProcedureCall = new List<string> { "RemoveLog", "1" }
    //    }
    //};
    //orderLines   P0130140
    //{
    //"lines": []
    //}



    //lineUpdateReasons   P0130140

    //    var lineUpdateReasons = new List<LineUpdateReasonDto>
    //{
    //    new LineUpdateReasonDto { Description = null, Value = "" },
    //    new LineUpdateReasonDto { Description = "ADD FOLIES", Value = "ADD FOLIES" },
    //    new LineUpdateReasonDto { Description = "ADD LIGNE", Value = "ADD LIGNE" },
    //    new LineUpdateReasonDto { Description = "ADD QTE", Value = "ADD QTE" },
    //    new LineUpdateReasonDto { Description = "ALS", Value = "ALS" },
    //    new LineUpdateReasonDto { Description = "ATT", Value = "ATT" },
    //    new LineUpdateReasonDto { Description = "BPS", Value = "BPS" },
    //    new LineUpdateReasonDto { Description = "BVN", Value = "BVN" },
    //    new LineUpdateReasonDto { Description = "CAD", Value = "CAD" },
    //    new LineUpdateReasonDto { Description = "CROSS", Value = "CROSS" },
    //    new LineUpdateReasonDto { Description = "CS", Value = "CS" },
    //    new LineUpdateReasonDto { Description = "DAV", Value = "DAV" },
    //    new LineUpdateReasonDto { Description = "DEF", Value = "DEF" },
    //    new LineUpdateReasonDto { Description = "ECH", Value = "ECH" },
    //    new LineUpdateReasonDto { Description = "EXP", Value = "EXP" },
    //    new LineUpdateReasonDto { Description = "FAC", Value = "FAC" },
    //    new LineUpdateReasonDto { Description = "FID", Value = "FID" },
    //    new LineUpdateReasonDto { Description = "FIN", Value = "FIN" },
    //    new LineUpdateReasonDto { Description = "FS", Value = "FS" },
    //    new LineUpdateReasonDto { Description = "GCO", Value = "GCO" },
    //    new LineUpdateReasonDto { Description = "GRT", Value = "GRT" },
    //    new LineUpdateReasonDto { Description = "GSC", Value = "GSC" },
    //    new LineUpdateReasonDto { Description = "KC", Value = "KC" },
    //    new LineUpdateReasonDto { Description = "LOC", Value = "LOC" },
    //    new LineUpdateReasonDto { Description = "MKG", Value = "MKG" },
    //    new LineUpdateReasonDto { Description = "MY ORDER", Value = "MY ORDER" },
    //    new LineUpdateReasonDto { Description = "NC", Value = "NC" },
    //    new LineUpdateReasonDto { Description = "NCM", Value = "NCM" },
    //    new LineUpdateReasonDto { Description = "NDI", Value = "NDI" },
    //    new LineUpdateReasonDto { Description = "OFF", Value = "OFF" },
    //    new LineUpdateReasonDto { Description = "PRA", Value = "PRA" },
    //    new LineUpdateReasonDto { Description = "PRV", Value = "PRV" },
    //    new LineUpdateReasonDto { Description = "PRW", Value = "PRW" },
    //    new LineUpdateReasonDto { Description = "REP", Value = "REP" },
    //    new LineUpdateReasonDto { Description = "RFA", Value = "RFA" },
    //    new LineUpdateReasonDto { Description = "RPL", Value = "RPL" },
    //    new LineUpdateReasonDto { Description = "SAV", Value = "SAV" },
    //    new LineUpdateReasonDto { Description = "VU", Value = "VU" },
    //    new LineUpdateReasonDto { Description = "WEB", Value = "WEB" },
    //    new LineUpdateReasonDto { Description = "XC", Value = "XC" }
    //};



    //logisticFlows   P0130140


    //    var logisticFlows = new List<LogisticFlowDto>
    //{
    //    new LogisticFlowDto { Description = "Stock", Value = "Stock" },
    //    new LogisticFlowDto { Description = "Livraison directe", Value = "DropShipped" },
    //    new LogisticFlowDto { Description = "Passage en stock", Value = "CrossDocked" }
    //};


    //orderLines   P0130512
    //        var orderLines = new List<OrderLineDto>
    //{
    //    new OrderLineDto
    //    {
    //        LineNum = new Field<int>
    //        {
    //            Name = "N° de ligne",
    //            Status = "readOnly",
    //            Value = 1
    //        },
    //        IsCustomLineNum = false,
    //        LineTags = new List<string>(),
    //        ItemId = new Field<string>
    //        {
    //            Name = "Code article",
    //            Status = "readOnly",
    //            Value = "PMBL5C"
    //        },
    //        Name = new Field<string>
    //        {
    //            Name = "Description",
    //            Status = "readOnly",
    //            Value = "CO100 PO BULLE RAJA ECO27X36CM"
    //        },
    //        InventLocationId = new Field<string>
    //        {
    //            Name = "Entrepôt",
    //            Status = "readOnly",
    //            Value = "SOR"
    //        },
    //        SalesQuantity = new Field<int>
    //        {
    //            Name = "Quantité",
    //            Status = "readOnly",
    //            Value = 1
    //        },
    //        SalesPrice = new Field<decimal>
    //        {
    //            Name = "Prix unitaire",
    //            Status = "readOnly",
    //            Value = 37.2m
    //        },
    //        DiscountType = new Field<string>
    //        {
    //            Name = "Tarification",
    //            Status = "readOnly",
    //            Value = "Default"
    //        },
    //        LineAmount = new Field<decimal>
    //        {
    //            Name = "Montant HT",
    //            Status = "readOnly",
    //            Value = 37.2m
    //        },
    //        UpdateReason = new Field<string>
    //        {
    //            Name = "Motif Modif.",
    //            Status = "readOnly",
    //            Value = ""
    //        },
    //        InitialSalesQuantity = new Field<int>
    //        {
    //            Name = "Qté initiale",
    //            Status = "readOnly",
    //            Value = 0
    //        },
    //        MultipleQuantity = null,
    //        VatRate = new Field<int>
    //        {
    //            Name = "Taux de TVA",
    //            Status = "readOnly",
    //            Value = 20
    //        },
    //        Note = null,
    //        ProductInfo = null,
    //        IsCustomLogisticFlow = false,
    //        LogisticFlow = new Field<string>
    //        {
    //            Name = "Flux logistique",
    //            Status = "readOnly",
    //            Value = "Stock"
    //        },
    //        PhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Livré maintenant",
    //            Status = "onlyForDisplay",
    //            Value = 1
    //        },
    //        OnOrderQuantity = new Field<int>
    //        {
    //            Name = "A livrer plus tard",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        PaletteQuantity = new Field<int>
    //        {
    //            Name = "Quantité/palette",
    //            Status = "onlyForDisplay",
    //            Value = 12
    //        },
    //        QuantityAtPaletteThreshold = new Field<int>
    //        {
    //            Name = "Diff Palette",
    //            Status = "onlyForDisplay",
    //            Value = 11
    //        },
    //        ItemType = new Field<string>
    //        {
    //            Name = "Type d'article",
    //            Status = "onlyForDisplay",
    //            Value = "Standard"
    //        },
    //        DeliveryDate = new Field<DateTime?>
    //        {
    //            Name = "Date de liv.",
    //            Status = "readOnly",
    //            Value = null
    //        },
    //        IsCustomDeliveryDate = new Field<bool?>
    //        {
    //            Name = "Date de liv. manuelle",
    //            Status = "readOnly",
    //            Value = false
    //        },
    //        ItemPhysicalInventQuantity = new Field<int>
    //        {
    //            Name = "Stock total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemReservPhysicalQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemPhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOnOrderQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedAvailableQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        SupplyFamily = new Field<string>
    //        {
    //            Name = "Famille d'appro.",
    //            Status = "onlyForDisplay",
    //            Value = "B1 - ENVELOPPES ET POCHETTES"
    //        },
    //        ItemManager = new Field<string>
    //        {
    //            Name = "Gestionnaire",
    //            Status = "onlyForDisplay",
    //            Value = "PUNEET SIDHU"
    //        },
    //        TransportMode = new Field<string>
    //        {
    //            Name = "Mode de transport",
    //            Status = "onlyForDisplay",
    //            Value = "PAR DÉFAUT"
    //        },
    //        PurchaseId = new Field<string>
    //        {
    //            Name = "Commande d'achat",
    //            Status = "hidden",
    //            Value = ""
    //        },
    //        DiscountDescription = new Field<string>
    //        {
    //            Name = "Description Tarif",
    //            Status = "onlyForDisplay",
    //            Value = "DC sur tout le Catalogue"
    //        },
    //        DiscountRate = new Field<decimal>
    //        {
    //            Name = "Remise sup.",
    //            Status = "readOnly",
    //            Value = 25m
    //        },
    //        DiscountPrice = new Field<decimal>
    //        {
    //            Name = "PU HT",
    //            Status = "readOnly",
    //            Value = 37.2m
    //        },
    //        Prices = null
    //    },
    //    new OrderLineDto
    //    {
    //        LineNum = new Field<int>
    //        {
    //            Name = "N° de ligne",
    //            Status = "readOnly",
    //            Value = 2
    //        },
    //        IsCustomLineNum = false,
    //        LineTags = new List<string>(),
    //        ItemId = new Field<string>
    //        {
    //            Name = "Code article",
    //            Status = "readOnly",
    //            Value = "PMBL4C"
    //        },
    //        Name = new Field<string>
    //        {
    //            Name = "Description",
    //            Status = "readOnly",
    //            Value = "CO100 PO BULLE RAJA ECO24X33CM"
    //        },
    //        InventLocationId = new Field<string>
    //        {
    //            Name = "Entrepôt",
    //            Status = "readOnly",
    //            Value = "SOR"
    //        },
    //        SalesQuantity = new Field<int>
    //        {
    //            Name = "Quantité",
    //            Status = "readOnly",
    //            Value = 1
    //        },
    //        SalesPrice = new Field<decimal>
    //        {
    //            Name = "Prix unitaire",
    //            Status = "readOnly",
    //            Value = 31.25m
    //        },
    //        DiscountType = new Field<string>
    //        {
    //            Name = "Tarification",
    //            Status = "readOnly",
    //            Value = "Default"
    //        },
    //        LineAmount = new Field<decimal>
    //        {
    //            Name = "Montant HT",
    //            Status = "readOnly",
    //            Value = 31.25m
    //        },
    //        UpdateReason = new Field<string>
    //        {
    //            Name = "Motif Modif.",
    //            Status = "readOnly",
    //            Value = ""
    //        },
    //        InitialSalesQuantity = new Field<int>
    //        {
    //            Name = "Qté initiale",
    //            Status = "readOnly",
    //            Value = 0
    //        },
    //        MultipleQuantity = null,
    //        VatRate = new Field<int>
    //        {
    //            Name = "Taux de TVA",
    //            Status = "readOnly",
    //            Value = 20
    //        },
    //        Note = null,
    //        ProductInfo = null,
    //        IsCustomLogisticFlow = false,
    //        LogisticFlow = new Field<string>
    //        {
    //            Name = "Flux logistique",
    //            Status = "readOnly",
    //            Value = "Stock"
    //        },
    //        PhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Livré maintenant",
    //            Status = "onlyForDisplay",
    //            Value = 1
    //        },
    //        OnOrderQuantity = new Field<int>
    //        {
    //            Name = "A livrer plus tard",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        PaletteQuantity = new Field<int>
    //        {
    //            Name = "Quantité/palette",
    //            Status = "onlyForDisplay",
    //            Value = 20
    //        },
    //        QuantityAtPaletteThreshold = new Field<int>
    //        {
    //            Name = "Diff Palette",
    //            Status = "onlyForDisplay",
    //            Value = 19
    //        },
    //        ItemType = new Field<string>
    //        {
    //            Name = "Type d'article",
    //            Status = "onlyForDisplay",
    //            Value = "Standard"
    //        },
    //        DeliveryDate = new Field<DateTime?>
    //        {
    //            Name = "Date de liv.",
    //            Status = "readOnly",
    //            Value = null
    //        },
    //        IsCustomDeliveryDate = new Field<bool?>
    //        {
    //            Name = "Date de liv. manuelle",
    //            Status = "readOnly",
    //            Value = false
    //        },
    //        ItemPhysicalInventQuantity = new Field<int>
    //        {
    //            Name = "Stock total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemReservPhysicalQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemPhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOnOrderQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedAvailableQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        SupplyFamily = new Field<string>
    //        {
    //            Name = "Famille d'appro.",
    //            Status = "onlyForDisplay",
    //            Value = "B1 - ENVELOPPES ET POCHETTES"
    //        },
    //        ItemManager = new Field<string>
    //        {
    //            Name = "Gestionnaire",
    //            Status = "onlyForDisplay",
    //            Value = "PUNEET SIDHU"
    //        },
    //        TransportMode = new Field<string>
    //        {
    //            Name = "Mode de transport",
    //            Status = "onlyForDisplay",
    //            Value = "PAR DÉFAUT"
    //        },
    //        PurchaseId = new Field<string>
    //        {
    //            Name = "Commande d'achat",
    //            Status = "hidden",
    //            Value = ""
    //        },
    //        DiscountDescription = new Field<string>
    //        {
    //            Name = "Description Tarif",
    //            Status = "onlyForDisplay",
    //            Value = "DC sur tout le Catalogue"
    //        },
    //        DiscountRate = new Field<decimal>
    //        {
    //            Name = "Remise sup.",
    //            Status = "readOnly",
    //            Value = 25m
    //        },
    //        DiscountPrice = new Field<decimal>
    //        {
    //            Name = "PU HT",
    //            Status = "readOnly",
    //            Value = 31.25m
    //        },
    //        Prices = null
    //    }
    //};





    //        //lineUpdateReasons   P0130512

    //        var lineUpdateReasons = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = null,
    //        Value = ""
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD FOLIES",
    //        Value = "ADD FOLIES"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD LIGNE",
    //        Value = "ADD LIGNE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD QTE",
    //        Value = "ADD QTE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ALS",
    //        Value = "ALS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ATT",
    //        Value = "ATT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BPS",
    //        Value = "BPS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BVN",
    //        Value = "BVN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CAD",
    //        Value = "CAD"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CROSS",
    //        Value = "CROSS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CS",
    //        Value = "CS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DAV",
    //        Value = "DAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DEF",
    //        Value = "DEF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ECH",
    //        Value = "ECH"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "EXP",
    //        Value = "EXP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FAC",
    //        Value = "FAC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FID",
    //        Value = "FID"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FIN",
    //        Value = "FIN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FS",
    //        Value = "FS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GCO",
    //        Value = "GCO"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GRT",
    //        Value = "GRT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GSC",
    //        Value = "GSC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "KC",
    //        Value = "KC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "LOC",
    //        Value = "LOC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MKG",
    //        Value = "MKG"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MY ORDER",
    //        Value = "MY ORDER"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NC",
    //        Value = "NC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NCM",
    //        Value = "NCM"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NDI",
    //        Value = "NDI"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "OFF",
    //        Value = "OFF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRA",
    //        Value = "PRA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRV",
    //        Value = "PRV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRW",
    //        Value = "PRW"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "REP",
    //        Value = "REP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RFA",
    //        Value = "RFA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RPL",
    //        Value = "RPL"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "SAV",
    //        Value = "SAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "VU",
    //        Value = "VU"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "WEB",
    //        Value = "WEB"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "XC",
    //        Value = "XC"
    //    }
    //};


    // not yet inmplemented: orderContext: /api/orderContext?ContactId={{contactId}}

    //"success": true,
    //"message": "Basket P0131276 created",
    //"basketId": "P0131276",
    //"url": "http://aliasiisq:86/MyOrderPage?BasketId=P0131276"
    // ================notifications   P0130140

    //var notifications = new List<NotificationDto>
    //{
    //    new NotificationDto
    //    {
    //        NotificationId = 2,
    //        Severity = "Warn",
    //        Message = "<strong>[Commande] Activité commerciale sur le client depuis une semaine:</strong><br/><strong>Commande</strong> <a href=\"/MyOrderPage?SalesId=24137007\" target=\"_blank\">24137007</a> \r\n                            (Réf. KN # TEST)\r\n                            créé(e)\r\n                            \r\n                            jeudi 08 août à 16:02 par KRISTELLE NOUET \r\n                            au statut <strong>Facturée</strong>\r\n                            <br/><strong>Commande</strong> <a href=\"/MyOrderPage?SalesId=24137006\" target=\"_blank\">24137006</a> \r\n                            (Réf. 08/08/2024)\r\n                            créé(e)\r\n                            \r\n                            jeudi 08 août à 14:32 par KRISTELLE NOUET \r\n                            au statut <strong>Facturée</strong>\r\n                            <br/>",
    //        CreatedDate = DateTime.Parse("0001-01-01 00:00:00"),
    //        ProcedureCall = new List<string> { "RemoveLog", "2" }
    //    },
    //    new NotificationDto
    //    {
    //        NotificationId = 1,
    //        Severity = "Info",
    //        Message = "<strong>[Paiement]</strong> Règlement effectué par <strong>Carte Bancaire</strong> pour un montant de <strong>51,48 €</strong> (Autorisation N°4144930086)",
    //        CreatedDate = DateTime.Parse("0001-01-01 00:00:00"),
    //        ProcedureCall = new List<string> { "RemoveLog", "1" }
    //    }
    //};
    //orderLines   P0130140
    //{
    //"lines": []
    //}



    //lineUpdateReasons   P0130140

    //    var lineUpdateReasons = new List<LineUpdateReasonDto>
    //{
    //    new LineUpdateReasonDto { Description = null, Value = "" },
    //    new LineUpdateReasonDto { Description = "ADD FOLIES", Value = "ADD FOLIES" },
    //    new LineUpdateReasonDto { Description = "ADD LIGNE", Value = "ADD LIGNE" },
    //    new LineUpdateReasonDto { Description = "ADD QTE", Value = "ADD QTE" },
    //    new LineUpdateReasonDto { Description = "ALS", Value = "ALS" },
    //    new LineUpdateReasonDto { Description = "ATT", Value = "ATT" },
    //    new LineUpdateReasonDto { Description = "BPS", Value = "BPS" },
    //    new LineUpdateReasonDto { Description = "BVN", Value = "BVN" },
    //    new LineUpdateReasonDto { Description = "CAD", Value = "CAD" },
    //    new LineUpdateReasonDto { Description = "CROSS", Value = "CROSS" },
    //    new LineUpdateReasonDto { Description = "CS", Value = "CS" },
    //    new LineUpdateReasonDto { Description = "DAV", Value = "DAV" },
    //    new LineUpdateReasonDto { Description = "DEF", Value = "DEF" },
    //    new LineUpdateReasonDto { Description = "ECH", Value = "ECH" },
    //    new LineUpdateReasonDto { Description = "EXP", Value = "EXP" },
    //    new LineUpdateReasonDto { Description = "FAC", Value = "FAC" },
    //    new LineUpdateReasonDto { Description = "FID", Value = "FID" },
    //    new LineUpdateReasonDto { Description = "FIN", Value = "FIN" },
    //    new LineUpdateReasonDto { Description = "FS", Value = "FS" },
    //    new LineUpdateReasonDto { Description = "GCO", Value = "GCO" },
    //    new LineUpdateReasonDto { Description = "GRT", Value = "GRT" },
    //    new LineUpdateReasonDto { Description = "GSC", Value = "GSC" },
    //    new LineUpdateReasonDto { Description = "KC", Value = "KC" },
    //    new LineUpdateReasonDto { Description = "LOC", Value = "LOC" },
    //    new LineUpdateReasonDto { Description = "MKG", Value = "MKG" },
    //    new LineUpdateReasonDto { Description = "MY ORDER", Value = "MY ORDER" },
    //    new LineUpdateReasonDto { Description = "NC", Value = "NC" },
    //    new LineUpdateReasonDto { Description = "NCM", Value = "NCM" },
    //    new LineUpdateReasonDto { Description = "NDI", Value = "NDI" },
    //    new LineUpdateReasonDto { Description = "OFF", Value = "OFF" },
    //    new LineUpdateReasonDto { Description = "PRA", Value = "PRA" },
    //    new LineUpdateReasonDto { Description = "PRV", Value = "PRV" },
    //    new LineUpdateReasonDto { Description = "PRW", Value = "PRW" },
    //    new LineUpdateReasonDto { Description = "REP", Value = "REP" },
    //    new LineUpdateReasonDto { Description = "RFA", Value = "RFA" },
    //    new LineUpdateReasonDto { Description = "RPL", Value = "RPL" },
    //    new LineUpdateReasonDto { Description = "SAV", Value = "SAV" },
    //    new LineUpdateReasonDto { Description = "VU", Value = "VU" },
    //    new LineUpdateReasonDto { Description = "WEB", Value = "WEB" },
    //    new LineUpdateReasonDto { Description = "XC", Value = "XC" }
    //};



    //logisticFlows   P0130140


    //    var logisticFlows = new List<LogisticFlowDto>
    //{
    //    new LogisticFlowDto { Description = "Stock", Value = "Stock" },
    //    new LogisticFlowDto { Description = "Livraison directe", Value = "DropShipped" },
    //    new LogisticFlowDto { Description = "Passage en stock", Value = "CrossDocked" }
    //};


    //orderLines   P0130512
    //        var orderLines = new List<OrderLineDto>
    //{
    //    new OrderLineDto
    //    {
    //        LineNum = new Field<int>
    //        {
    //            Name = "N° de ligne",
    //            Status = "readOnly",
    //            Value = 1
    //        },
    //        IsCustomLineNum = false,
    //        LineTags = new List<string>(),
    //        ItemId = new Field<string>
    //        {
    //            Name = "Code article",
    //            Status = "readOnly",
    //            Value = "PMBL5C"
    //        },
    //        Name = new Field<string>
    //        {
    //            Name = "Description",
    //            Status = "readOnly",
    //            Value = "CO100 PO BULLE RAJA ECO27X36CM"
    //        },
    //        InventLocationId = new Field<string>
    //        {
    //            Name = "Entrepôt",
    //            Status = "readOnly",
    //            Value = "SOR"
    //        },
    //        SalesQuantity = new Field<int>
    //        {
    //            Name = "Quantité",
    //            Status = "readOnly",
    //            Value = 1
    //        },
    //        SalesPrice = new Field<decimal>
    //        {
    //            Name = "Prix unitaire",
    //            Status = "readOnly",
    //            Value = 37.2m
    //        },
    //        DiscountType = new Field<string>
    //        {
    //            Name = "Tarification",
    //            Status = "readOnly",
    //            Value = "Default"
    //        },
    //        LineAmount = new Field<decimal>
    //        {
    //            Name = "Montant HT",
    //            Status = "readOnly",
    //            Value = 37.2m
    //        },
    //        UpdateReason = new Field<string>
    //        {
    //            Name = "Motif Modif.",
    //            Status = "readOnly",
    //            Value = ""
    //        },
    //        InitialSalesQuantity = new Field<int>
    //        {
    //            Name = "Qté initiale",
    //            Status = "readOnly",
    //            Value = 0
    //        },
    //        MultipleQuantity = null,
    //        VatRate = new Field<int>
    //        {
    //            Name = "Taux de TVA",
    //            Status = "readOnly",
    //            Value = 20
    //        },
    //        Note = null,
    //        ProductInfo = null,
    //        IsCustomLogisticFlow = false,
    //        LogisticFlow = new Field<string>
    //        {
    //            Name = "Flux logistique",
    //            Status = "readOnly",
    //            Value = "Stock"
    //        },
    //        PhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Livré maintenant",
    //            Status = "onlyForDisplay",
    //            Value = 1
    //        },
    //        OnOrderQuantity = new Field<int>
    //        {
    //            Name = "A livrer plus tard",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        PaletteQuantity = new Field<int>
    //        {
    //            Name = "Quantité/palette",
    //            Status = "onlyForDisplay",
    //            Value = 12
    //        },
    //        QuantityAtPaletteThreshold = new Field<int>
    //        {
    //            Name = "Diff Palette",
    //            Status = "onlyForDisplay",
    //            Value = 11
    //        },
    //        ItemType = new Field<string>
    //        {
    //            Name = "Type d'article",
    //            Status = "onlyForDisplay",
    //            Value = "Standard"
    //        },
    //        DeliveryDate = new Field<DateTime?>
    //        {
    //            Name = "Date de liv.",
    //            Status = "readOnly",
    //            Value = null
    //        },
    //        IsCustomDeliveryDate = new Field<bool?>
    //        {
    //            Name = "Date de liv. manuelle",
    //            Status = "readOnly",
    //            Value = false
    //        },
    //        ItemPhysicalInventQuantity = new Field<int>
    //        {
    //            Name = "Stock total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemReservPhysicalQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemPhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOnOrderQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedAvailableQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        SupplyFamily = new Field<string>
    //        {
    //            Name = "Famille d'appro.",
    //            Status = "onlyForDisplay",
    //            Value = "B1 - ENVELOPPES ET POCHETTES"
    //        },
    //        ItemManager = new Field<string>
    //        {
    //            Name = "Gestionnaire",
    //            Status = "onlyForDisplay",
    //            Value = "PUNEET SIDHU"
    //        },
    //        TransportMode = new Field<string>
    //        {
    //            Name = "Mode de transport",
    //            Status = "onlyForDisplay",
    //            Value = "PAR DÉFAUT"
    //        },
    //        PurchaseId = new Field<string>
    //        {
    //            Name = "Commande d'achat",
    //            Status = "hidden",
    //            Value = ""
    //        },
    //        DiscountDescription = new Field<string>
    //        {
    //            Name = "Description Tarif",
    //            Status = "onlyForDisplay",
    //            Value = "DC sur tout le Catalogue"
    //        },
    //        DiscountRate = new Field<decimal>
    //        {
    //            Name = "Remise sup.",
    //            Status = "readOnly",
    //            Value = 25m
    //        },
    //        DiscountPrice = new Field<decimal>
    //        {
    //            Name = "PU HT",
    //            Status = "readOnly",
    //            Value = 37.2m
    //        },
    //        Prices = null
    //    },
    //    new OrderLineDto
    //    {
    //        LineNum = new Field<int>
    //        {
    //            Name = "N° de ligne",
    //            Status = "readOnly",
    //            Value = 2
    //        },
    //        IsCustomLineNum = false,
    //        LineTags = new List<string>(),
    //        ItemId = new Field<string>
    //        {
    //            Name = "Code article",
    //            Status = "readOnly",
    //            Value = "PMBL4C"
    //        },
    //        Name = new Field<string>
    //        {
    //            Name = "Description",
    //            Status = "readOnly",
    //            Value = "CO100 PO BULLE RAJA ECO24X33CM"
    //        },
    //        InventLocationId = new Field<string>
    //        {
    //            Name = "Entrepôt",
    //            Status = "readOnly",
    //            Value = "SOR"
    //        },
    //        SalesQuantity = new Field<int>
    //        {
    //            Name = "Quantité",
    //            Status = "readOnly",
    //            Value = 1
    //        },
    //        SalesPrice = new Field<decimal>
    //        {
    //            Name = "Prix unitaire",
    //            Status = "readOnly",
    //            Value = 31.25m
    //        },
    //        DiscountType = new Field<string>
    //        {
    //            Name = "Tarification",
    //            Status = "readOnly",
    //            Value = "Default"
    //        },
    //        LineAmount = new Field<decimal>
    //        {
    //            Name = "Montant HT",
    //            Status = "readOnly",
    //            Value = 31.25m
    //        },
    //        UpdateReason = new Field<string>
    //        {
    //            Name = "Motif Modif.",
    //            Status = "readOnly",
    //            Value = ""
    //        },
    //        InitialSalesQuantity = new Field<int>
    //        {
    //            Name = "Qté initiale",
    //            Status = "readOnly",
    //            Value = 0
    //        },
    //        MultipleQuantity = null,
    //        VatRate = new Field<int>
    //        {
    //            Name = "Taux de TVA",
    //            Status = "readOnly",
    //            Value = 20
    //        },
    //        Note = null,
    //        ProductInfo = null,
    //        IsCustomLogisticFlow = false,
    //        LogisticFlow = new Field<string>
    //        {
    //            Name = "Flux logistique",
    //            Status = "readOnly",
    //            Value = "Stock"
    //        },
    //        PhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Livré maintenant",
    //            Status = "onlyForDisplay",
    //            Value = 1
    //        },
    //        OnOrderQuantity = new Field<int>
    //        {
    //            Name = "A livrer plus tard",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        PaletteQuantity = new Field<int>
    //        {
    //            Name = "Quantité/palette",
    //            Status = "onlyForDisplay",
    //            Value = 20
    //        },
    //        QuantityAtPaletteThreshold = new Field<int>
    //        {
    //            Name = "Diff Palette",
    //            Status = "onlyForDisplay",
    //            Value = 19
    //        },
    //        ItemType = new Field<string>
    //        {
    //            Name = "Type d'article",
    //            Status = "onlyForDisplay",
    //            Value = "Standard"
    //        },
    //        DeliveryDate = new Field<DateTime?>
    //        {
    //            Name = "Date de liv.",
    //            Status = "readOnly",
    //            Value = null
    //        },
    //        IsCustomDeliveryDate = new Field<bool?>
    //        {
    //            Name = "Date de liv. manuelle",
    //            Status = "readOnly",
    //            Value = false
    //        },
    //        ItemPhysicalInventQuantity = new Field<int>
    //        {
    //            Name = "Stock total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemReservPhysicalQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemPhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOnOrderQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedAvailableQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        SupplyFamily = new Field<string>
    //        {
    //            Name = "Famille d'appro.",
    //            Status = "onlyForDisplay",
    //            Value = "B1 - ENVELOPPES ET POCHETTES"
    //        },
    //        ItemManager = new Field<string>
    //        {
    //            Name = "Gestionnaire",
    //            Status = "onlyForDisplay",
    //            Value = "PUNEET SIDHU"
    //        },
    //        TransportMode = new Field<string>
    //        {
    //            Name = "Mode de transport",
    //            Status = "onlyForDisplay",
    //            Value = "PAR DÉFAUT"
    //        },
    //        PurchaseId = new Field<string>
    //        {
    //            Name = "Commande d'achat",
    //            Status = "hidden",
    //            Value = ""
    //        },
    //        DiscountDescription = new Field<string>
    //        {
    //            Name = "Description Tarif",
    //            Status = "onlyForDisplay",
    //            Value = "DC sur tout le Catalogue"
    //        },
    //        DiscountRate = new Field<decimal>
    //        {
    //            Name = "Remise sup.",
    //            Status = "readOnly",
    //            Value = 25m
    //        },
    //        DiscountPrice = new Field<decimal>
    //        {
    //            Name = "PU HT",
    //            Status = "readOnly",
    //            Value = 31.25m
    //        },
    //        Prices = null
    //    }
    //};





    //        //lineUpdateReasons   P0130512

    //        var lineUpdateReasons = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = null,
    //        Value = ""
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD FOLIES",
    //        Value = "ADD FOLIES"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD LIGNE",
    //        Value = "ADD LIGNE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD QTE",
    //        Value = "ADD QTE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ALS",
    //        Value = "ALS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ATT",
    //        Value = "ATT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BPS",
    //        Value = "BPS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BVN",
    //        Value = "BVN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CAD",
    //        Value = "CAD"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CROSS",
    //        Value = "CROSS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CS",
    //        Value = "CS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DAV",
    //        Value = "DAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DEF",
    //        Value = "DEF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ECH",
    //        Value = "ECH"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "EXP",
    //        Value = "EXP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FAC",
    //        Value = "FAC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FID",
    //        Value = "FID"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FIN",
    //        Value = "FIN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FS",
    //        Value = "FS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GCO",
    //        Value = "GCO"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GRT",
    //        Value = "GRT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GSC",
    //        Value = "GSC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "KC",
    //        Value = "KC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "LOC",
    //        Value = "LOC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MKG",
    //        Value = "MKG"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MY ORDER",
    //        Value = "MY ORDER"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NC",
    //        Value = "NC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NCM",
    //        Value = "NCM"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NDI",
    //        Value = "NDI"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "OFF",
    //        Value = "OFF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRA",
    //        Value = "PRA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRV",
    //        Value = "PRV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRW",
    //        Value = "PRW"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "REP",
    //        Value = "REP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RFA",
    //        Value = "RFA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RPL",
    //        Value = "RPL"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "SAV",
    //        Value = "SAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "VU",
    //        Value = "VU"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "WEB",
    //        Value = "WEB"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "XC",
    //        Value = "XC"
    //    }
    //};







    //        //logisticFlows   P0130512

    //        var logisticFlows = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = "Stock",
    //        Value = "Stock"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Livraison directe",
    //        Value = "DropShipped"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Passage en stock",
    //        Value = "CrossDocked"
    //    }
    //};
    //orderLines   P0130863

    //var orderLines = new List<OrderLine>
    //        {
    //            new OrderLine
    //            {
    //                LineNum = new Field<int> { Name = "N° de ligne", Status = "readWrite", Value = 1 },
    //                IsCustomLineNum = false,
    //                LineTags = new List<BasketValueDto>(),
    //                ItemId = new Field<string> { Name = "Code article", Status = "readWrite", Value = "BL50RT" },
    //                Name = new Field<string> { Name = "Description", Status = "readWrite", Value = "RL BULLE RECYCLE 50CMX100M" },
    //                InventLocationId = new Field<string> { Name = "Entrepôt", Status = "readWrite", Value = "PN2" },
    //                SalesQuantity = new Field<int> { Name = "Quantité", Status = "readWrite", Value = 0 },
    //                SalesPrice = new Field<double> { Name = "Prix unitaire", Status = "readWrite", Value = 27.27 },
    //                DiscountType = new Field<string> { Name = "Tarification", Status = "readWrite", Value = "OriginPrice" },
    //                LineAmount = new Field<double> { Name = "Montant HT", Status = "readWrite", Value = 0 },
    //                UpdateReason = new Field<BasketValueDto>
    //                {
    //                    Name = "Motif Modif.",
    //                    Status = "readWrite",
    //                    Value = new BasketValueDto { Description = "GCO", Value = "GCO" }
    //                },
    //                InitialSalesQuantity = new Field<int> { Name = "Qté initiale", Status = "readWrite", Value = 0 },
    //                MultipleQuantity = null,
    //                VatRate = new Field<int> { Name = "Taux de TVA", Status = "readWrite", Value = 20 },
    //                Note = null,
    //                ProductInfo = null,
    //                IsCustomlogisticFlow = false,
    //                LogisticFlow = new Field<string> { Name = "Flux logistique", Status = "readWrite", Value = "Stock" },
    //                PhysicalAvailableQuantity = new Field<int> { Name = "Livré maintenant", Status = "onlyForDisplay", Value = 0 },
    //                OnOrderQuantity = new Field<int> { Name = "A livrer plus tard", Status = "onlyForDisplay", Value = 0 },
    //                PaletteQuantity = new Field<int> { Name = "Quantité/palette", Status = "onlyForDisplay", Value = 36 },
    //                QuantityAtPaletteThreshold = new Field<int> { Name = "Diff Palette", Status = "onlyForDisplay", Value = 0 },
    //                ItemType = new Field<string> { Name = "Type d'article", Status = "onlyForDisplay", Value = "Standard" },
    //                DeliveryDate = new Field<DateTime?> { Name = "Date de liv.", Status = "readOnly", Value = null },
    //                IsCustomDeliveryDate = new Field<bool?> { Name = "Date de liv. manuelle", Status = "readWrite", Value = false },
    //                ItemPhysicalInventQuantity = new Field<int> { Name = "Stock total", Status = "onlyForDisplay", Value = 0 },
    //                ItemReservPhysicalQuantity = new Field<int> { Name = "Stock réservé", Status = "onlyForDisplay", Value = 0 },
    //                ItemPhysicalAvailableQuantity = new Field<int> { Name = "Stock réservé", Status = "onlyForDisplay", Value = 0 },
    //                ItemOnOrderQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                ItemOrderedQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                ItemOrderedAvailableQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                SupplyFamily = new Field<string> { Name = "Famille d'appro.", Status = "onlyForDisplay", Value = "E4 - VRAC VOLUMINEUX (RLX BULLE ET MOUSSE)" },
    //                ItemManager = new Field<string> { Name = "Gestionnaire", Status = "onlyForDisplay", Value = "FAIZANN HUSSAIN" },
    //                TransportMode = new Field<string> { Name = "Mode de transport", Status = "onlyForDisplay", Value = "PAR DÉFAUT" },
    //                PurchaseId = new Field<string> { Name = "Commande d'achat", Status = "hidden", Value = "" },
    //                DiscountDescription = new Field<string> { Name = "Description Tarif", Status = "onlyForDisplay", Value = "" },
    //                DiscountRate = new Field<int> { Name = "Remise sup.", Status = "readOnly", Value = 33 },
    //                DiscountPrice = new Field<double> { Name = "PU HT", Status = "readOnly", Value = 27.27 },
    //                Prices = null
    //            },
    //            new OrderLine
    //            {
    //                LineNum = new Field<int> { Name = "N° de ligne", Status = "readWrite", Value = 2 },
    //                IsCustomLineNum = false,
    //                LineTags = new List<BasketValueDto>(),
    //                ItemId = new Field<string> { Name = "Code article", Status = "readWrite", Value = "PKR7250" },
    //                Name = new Field<string> { Name = "Description", Status = "readWrite", Value = "RL KRAFT RECY 50CMX300M 70G" },
    //                InventLocationId = new Field<string> { Name = "Entrepôt", Status = "readWrite", Value = "PN2" },
    //                SalesQuantity = new Field<int> { Name = "Quantité", Status = "readWrite", Value = 0 },
    //                SalesPrice = new Field<double> { Name = "Prix unitaire", Status = "readWrite", Value = 34.83 },
    //                DiscountType = new Field<string> { Name = "Tarification", Status = "readWrite", Value = "OriginPrice" },
    //                LineAmount = new Field<double> { Name = "Montant HT", Status = "readWrite", Value = 0 },
    //                UpdateReason = new Field<BasketValueDto>
    //                {
    //                    Name = "Motif Modif.",
    //                    Status = "readWrite",
    //                    Value = new BasketValueDto { Description = "GCO", Value = "GCO" }
    //                },
    //                InitialSalesQuantity = new Field<int> { Name = "Qté initiale", Status = "readWrite", Value = 0 },
    //                MultipleQuantity = null,
    //                VatRate = new Field<int> { Name = "Taux de TVA", Status = "readWrite", Value = 20 },
    //                Note = null,
    //                ProductInfo = null,
    //                IsCustomlogisticFlow = false,
    //                LogisticFlow = new Field<string> { Name = "Flux logistique", Status = "readWrite", Value = "Stock" },
    //                PhysicalAvailableQuantity = new Field<int> { Name = "Livré maintenant", Status = "onlyForDisplay", Value = 0 },
    //                OnOrderQuantity = new Field<int> { Name = "A livrer plus tard", Status = "onlyForDisplay", Value = 0 },
    //                PaletteQuantity = new Field<int> { Name = "Quantité/palette", Status = "onlyForDisplay", Value = 0 },
    //                QuantityAtPaletteThreshold = new Field<int> { Name = "Diff Palette", Status = "onlyForDisplay", Value = 0 },
    //                ItemType = new Field<string> { Name = "Type d'article", Status = "onlyForDisplay", Value = "Standard" },
    //                DeliveryDate = new Field<DateTime?> { Name = "Date de liv.", Status = "readOnly", Value = null },
    //                IsCustomDeliveryDate = new Field<bool?> { Name = "Date de liv. manuelle", Status = "readWrite", Value = false },
    //                ItemPhysicalInventQuantity = new Field<int> { Name = "Stock total", Status = "onlyForDisplay", Value = 0 },
    //                ItemReservPhysicalQuantity = new Field<int> { Name = "Stock réservé", Status = "onlyForDisplay", Value = 0 },
    //                ItemPhysicalAvailableQuantity = new Field<int> { Name = "Stock réservé", Status = "onlyForDisplay", Value = 0 },
    //                ItemOnOrderQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                ItemOrderedQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                ItemOrderedAvailableQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                SupplyFamily = new Field<string> { Name = "Famille d'appro.", Status = "onlyForDisplay", Value = "E4 - VRAC VOLUMINEUX (RLX BULLE ET MOUSSE)" },
    //                ItemManager = new Field<string> { Name = "Gestionnaire", Status = "onlyForDisplay", Value = "FAIZANN HUSSAIN" },
    //                TransportMode = new Field<string> { Name = "Mode de transport", Status = "onlyForDisplay", Value = "PAR DÉFAUT" },
    //                PurchaseId = new Field<string> { Name = "Commande d'achat", Status = "hidden", Value = "" },
    //                DiscountDescription = new Field<string> { Name = "Description Tarif", Status = "onlyForDisplay", Value = "" },
    //                DiscountRate = new Field<int> { Name = "Remise sup.", Status = "readOnly", Value = 33 },
    //                DiscountPrice = new Field<double> { Name = "PU HT", Status = "readOnly", Value = 34.83 },
    //                Prices = null
    //            }
    //        };


    ////lineUpdateReasons   P0130863


    //private List<BasketValueDto> lineUpdateReasons = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = "",
    //        Value = ""
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD FOLIES",
    //        Value = "ADD FOLIES"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD LIGNE",
    //        Value = "ADD LIGNE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD QTE",
    //        Value = "ADD QTE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ALS",
    //        Value = "ALS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ATT",
    //        Value = "ATT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BPS",
    //        Value = "BPS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BVN",
    //        Value = "BVN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CAD",
    //        Value = "CAD"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CROSS",
    //        Value = "CROSS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CS",
    //        Value = "CS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DAV",
    //        Value = "DAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DEF",
    //        Value = "DEF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ECH",
    //        Value = "ECH"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "EXP",
    //        Value = "EXP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FAC",
    //        Value = "FAC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FID",
    //        Value = "FID"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FIN",
    //        Value = "FIN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FS",
    //        Value = "FS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GCO",
    //        Value = "GCO"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GRT",
    //        Value = "GRT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GSC",
    //        Value = "GSC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "KC",
    //        Value = "KC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "LOC",
    //        Value = "LOC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MKG",
    //        Value = "MKG"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MY ORDER",
    //        Value = "MY ORDER"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NC",
    //        Value = "NC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NCM",
    //        Value = "NCM"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NDI",
    //        Value = "NDI"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "OFF",
    //        Value = "OFF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRA",
    //        Value = "PRA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRV",
    //        Value = "PRV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRW",
    //        Value = "PRW"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "REP",
    //        Value = "REP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RFA",
    //        Value = "RFA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RPL",
    //        Value = "RPL"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "SAV",
    //        Value = "SAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "VU",
    //        Value = "VU"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "WEB",
    //        Value = "WEB"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "XC",
    //        Value = "XC"
    //    }
    //};



    ////logisticFlows   P0130863
    //private List<BasketValueDto> logisticFlows = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = "Stock",
    //        Value = "Stock"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Livraison directe",
    //        Value = "DropShipped"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Passage en stock",
    //        Value = "CrossDocked"
    //    }
    //};


    //orderContext/{{basketId}}/notifications   P0130863

    //var notifications = new List<NotificationDto>
    //{
    //    new NotificationDto
    //    {
    //        NotificationId = 1,
    //        Severity = "Warn",
    //        Message = "<strong>[Commande] Activité SAV sur la commande 24136045 depuis une semaine:</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gp5HNYAZ/view\" target=\"_blank\">R0031596</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> lundi 22 juillet \r\n                    à 14:22 \r\n                    pour le motif <strong>M05 - Produit abimé</strong> \r\n                    au statut <strong>Escaladé</strong><br/><strong>Avoir financier</strong> <a href=\"/MyOrderPage?InvoiceId=24A006866\" target=\"_blank\">24A006866</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gh19PYAR/view\" target=\"_blank\">R0031587</a>\r\n                            vendredi 19 juillet à 10:12 par SEVERINE COURCELLE \r\n                            au statut <strong>Facturé</strong>\r\n                            <br/><strong>Retour avec avoir</strong> <a href=\"/MyOrderPage?SalesId=24136860\" target=\"_blank\">24136860</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gh19PYAR/view\" target=\"_blank\">R0031587</a>\r\n                            vendredi 19 juillet à 10:08 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Réexpédition</strong> <a href=\"/MyOrderPage?SalesId=24136859\" target=\"_blank\">24136859</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a>\r\n                            jeudi 18 juillet à 18:21 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Retour simple</strong> <a href=\"/MyOrderPage?SalesId=24136858\" target=\"_blank\">24136858</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a>\r\n                            jeudi 18 juillet à 18:20 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 18:08 \r\n                    pour le motif <strong>M05 - Produit abimé</strong> \r\n                    au statut <strong>Attente Info</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhIYLYA3/view\" target=\"_blank\">R0031589</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 10:50 \r\n                    pour le motif <strong>M05 - Produit manquant</strong> \r\n                    au statut <strong>Escaladé</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhHu1YAF/view\" target=\"_blank\">R0031588</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 10:46 \r\n                    pour le motif <strong>M05 - Produit manquant</strong> \r\n                    au statut <strong>Attente Info</strong><br/>",
    //        CreatedDate = DateTime.Parse("0001-01-01 00:00:00"),
    //        ProcedureCall = new List<string> { "RemoveLog", "1" }
    //    }
    //}; var notifications = new List<NotificationDto>
    //{
    //    new NotificationDto
    //    {
    //        NotificationId = 1,
    //        Severity = "Warn",
    //        Message = "<strong>[Commande] Activité SAV sur la commande 24136045 depuis une semaine:</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gp5HNYAZ/view\" target=\"_blank\">R0031596</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> lundi 22 juillet \r\n                    à 14:22 \r\n                    pour le motif <strong>M05 - Produit abimé</strong> \r\n                    au statut <strong>Escaladé</strong><br/><strong>Avoir financier</strong> <a href=\"/MyOrderPage?InvoiceId=24A006866\" target=\"_blank\">24A006866</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gh19PYAR/view\" target=\"_blank\">R0031587</a>\r\n                            vendredi 19 juillet à 10:12 par SEVERINE COURCELLE \r\n                            au statut <strong>Facturé</strong>\r\n                            <br/><strong>Retour avec avoir</strong> <a href=\"/MyOrderPage?SalesId=24136860\" target=\"_blank\">24136860</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gh19PYAR/view\" target=\"_blank\">R0031587</a>\r\n                            vendredi 19 juillet à 10:08 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Réexpédition</strong> <a href=\"/MyOrderPage?SalesId=24136859\" target=\"_blank\">24136859</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a>\r\n                            jeudi 18 juillet à 18:21 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Retour simple</strong> <a href=\"/MyOrderPage?SalesId=24136858\" target=\"_blank\">24136858</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a>\r\n                            jeudi 18 juillet à 18:20 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 18:08 \r\n                    pour le motif <strong>M05 - Produit abimé</strong> \r\n                    au statut <strong>Attente Info</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhIYLYA3/view\" target=\"_blank\">R0031589</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 10:50 \r\n                    pour le motif <strong>M05 - Produit manquant</strong> \r\n                    au statut <strong>Escaladé</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhHu1YAF/view\" target=\"_blank\">R0031588</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 10:46 \r\n                    pour le motif <strong>M05 - Produit manquant</strong> \r\n                    au statut <strong>Attente Info</strong><br/>",
    //        CreatedDate = DateTime.Parse("0001-01-01 00:00:00"),
    //        ProcedureCall = new List<string> { "RemoveLog", "1" }
    //    }
    //};


    ////orderLines   P0130652
    //var orderLines = new List<OrderLineDto>
    //{
    //    new OrderLineDto
    //    {
    //        LineNum = new Field<int>
    //        {
    //            Name = "N° de ligne",
    //            Status = "readWrite",
    //            Value = 1
    //        },
    //        IsCustomLineNum = false,
    //        LineTags = new List<string>(),
    //        ItemId = new Field<string>
    //        {
    //            Name = "Code article",
    //            Status = "readWrite",
    //            Value = "CAS15"
    //        },
    //        Name = new Field<string>
    //        {
    //            Name = "Description",
    //            Status = "readWrite",
    //            Value = "C.A SC10 31X21,5X10 BRUN"
    //        },
    //        InventLocationId = new Field<string>
    //        {
    //            Name = "Entrepôt",
    //            Status = "readWrite",
    //            Value = "PN2"
    //        },
    //        SalesQuantity = new Field<int>
    //        {
    //            Name = "Quantité",
    //            Status = "readWrite",
    //            Value = 150
    //        },
    //        SalesPrice = new Field<decimal>
    //        {
    //            Name = "Prix unitaire",
    //            Status = "readWrite",
    //            Value = 0.76m
    //        },
    //        DiscountType = new Field<string>
    //        {
    //            Name = "Tarification",
    //            Status = "readWrite",
    //            Value = "NoDiscount"
    //        },
    //        LineAmount = new Field<decimal>
    //        {
    //            Name = "Montant HT",
    //            Status = "readWrite",
    //            Value = 114m
    //        },
    //        UpdateReason = new Field<string>
    //        {
    //            Name = "Motif Modif.",
    //            Status = "readWrite",
    //            Value = ""
    //        },
    //        InitialSalesQuantity = new Field<int>
    //        {
    //            Name = "Qté initiale",
    //            Status = "readWrite",
    //            Value = 0
    //        },
    //        MultipleQuantity = null,
    //        VatRate = new Field<int>
    //        {
    //            Name = "Taux de TVA",
    //            Status = "readWrite",
    //            Value = 20
    //        },
    //        Note = null,
    //        ProductInfo = null,
    //        IsCustomlogisticFlow = false,
    //        LogisticFlow = new Field<string>
    //        {
    //            Name = "Flux logistique",
    //            Status = "readWrite",
    //            Value = "Stock"
    //        },
    //        PhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Livré maintenant",
    //            Status = "onlyForDisplay",
    //            Value = 150
    //        },
    //        OnOrderQuantity = new Field<int>
    //        {
    //            Name = "A livrer plus tard",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        PaletteQuantity = new Field<int>
    //        {
    //            Name = "Quantité/palette",
    //            Status = "onlyForDisplay",
    //            Value = 1100
    //        },
    //        QuantityAtPaletteThreshold = new Field<int>
    //        {
    //            Name = "Diff Palette",
    //            Status = "onlyForDisplay",
    //            Value = 950
    //        },
    //        ItemType = new Field<string>
    //        {
    //            Name = "Type d'article",
    //            Status = "onlyForDisplay",
    //            Value = "Standard"
    //        },
    //        DeliveryDate = new Field<DateTime?>
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
    //        ItemPhysicalInventQuantity = new Field<int>
    //        {
    //            Name = "Stock total",
    //            Status = "onlyForDisplay",
    //            Value = 43250
    //        },
    //        ItemReservPhysicalQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 925
    //        },
    //        ItemPhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 42325
    //        },
    //        ItemOnOrderQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 575
    //        },
    //        ItemOrderedQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedAvailableQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        SupplyFamily = new Field<string>
    //        {
    //            Name = "Famille d'appro.",
    //            Status = "onlyForDisplay",
    //            Value = "C1 - CAISSES ET CONTAINERS"
    //        },
    //        ItemManager = new Field<string>
    //        {
    //            Name = "Gestionnaire",
    //            Status = "onlyForDisplay",
    //            Value = "JEROME TARGET"
    //        },
    //        TransportMode = new Field<string>
    //        {
    //            Name = "Mode de transport",
    //            Status = "onlyForDisplay",
    //            Value = "PAR DÉFAUT"
    //        },
    //        PurchaseId = new Field<string>
    //        {
    //            Name = "Commande d'achat",
    //            Status = "hidden",
    //            Value = ""
    //        },
    //        DiscountDescription = new Field<string>
    //        {
    //            Name = "Description Tarif",
    //            Status = "onlyForDisplay",
    //            Value = ""
    //        },
    //        DiscountRate = new Field<decimal>
    //        {
    //            Name = "Remise sup.",
    //            Status = "readOnly",
    //            Value = 0
    //        },
    //        DiscountPrice = new Field<decimal>
    //        {
    //            Name = "PU HT",
    //            Status = "readOnly",
    //            Value = 0.76m
    //        },
    //        Prices = null
    //    },
    //    new OrderLineDto
    //    {
    //        LineNum = new Field<int>
    //        {
    //            Name = "N° de ligne",
    //            Status = "readWrite",
    //            Value = 2
    //        },
    //        IsCustomLineNum = false,
    //        LineTags = new List<string>(),
    //        ItemId = new Field<string>
    //        {
    //            Name = "Code article",
    //            Status = "readWrite",
    //            Value = "CAS14"
    //        },
    //        Name = new Field<string>
    //        {
    //            Name = "Description",
    //            Status = "readWrite",
    //            Value = "C.A SC10 31X21,5X5,5 BRUN"
    //        },
    //        InventLocationId = new Field<string>
    //        {
    //            Name = "Entrepôt",
    //            Status = "readWrite",
    //            Value = "PN2"
    //        },
    //        SalesQuantity = new Field<int>
    //        {
    //            Name = "Quantité",
    //            Status = "readWrite",
    //            Value = 25
    //        },
    //        SalesPrice = new Field<decimal>
    //        {
    //            Name = "Prix unitaire",
    //            Status = "readWrite",
    //            Value = 0.68m
    //        },
    //        DiscountType = new Field<string>
    //        {
    //            Name = "Tarification",
    //            Status = "readWrite",
    //            Value = "Default"
    //        },
    //        LineAmount = new Field<decimal>
    //        {
    //            Name = "Montant HT",
    //            Status = "readWrite",
    //            Value = 17m
    //        },
    //        UpdateReason = new Field<string>
    //        {
    //            Name = "Motif Modif.",
    //            Status = "readWrite",
    //            Value = ""
    //        },
    //        InitialSalesQuantity = new Field<int>
    //        {
    //            Name = "Qté initiale",
    //            Status = "readWrite",
    //            Value = 0
    //        },
    //        MultipleQuantity = null,
    //        VatRate = new Field<int>
    //        {
    //            Name = "Taux de TVA",
    //            Status = "readWrite",
    //            Value = 20
    //        },
    //        Note = null,
    //        ProductInfo = null,
    //        IsCustomlogisticFlow = false,
    //        LogisticFlow = new Field<string>
    //        {
    //            Name = "Flux logistique",
    //            Status = "readWrite",
    //            Value = "Stock"
    //        },
    //        PhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Livré maintenant",
    //            Status = "onlyForDisplay",
    //            Value = 25
    //        },
    //        OnOrderQuantity = new Field<int>
    //        {
    //            Name = "A livrer plus tard",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        PaletteQuantity = new Field<int>
    //        {
    //            Name = "Quantité/palette",
    //            Status = "onlyForDisplay",
    //            Value = 2100
    //        },
    //        QuantityAtPaletteThreshold = new Field<int>
    //        {
    //            Name = "Diff Palette",
    //            Status = "onlyForDisplay",
    //            Value = 2075
    //        },
    //        ItemType = new Field<string>
    //        {
    //            Name = "Type d'article",
    //            Status = "onlyForDisplay",
    //            Value = "Standard"
    //        },
    //        DeliveryDate = new Field<DateTime?>
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
    //        ItemPhysicalInventQuantity = new Field<int>
    //        {
    //            Name = "Stock total",
    //            Status = "onlyForDisplay",
    //            Value = 7050
    //        },
    //        ItemReservPhysicalQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 900
    //        },
    //        ItemPhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 6150
    //        },
    //        ItemOnOrderQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedAvailableQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        SupplyFamily = new Field<string>
    //        {
    //            Name = "Famille d'appro.",
    //            Status = "onlyForDisplay",
    //            Value = "C1 - CAISSES ET CONTAINERS"
    //        },
    //        ItemManager = new Field<string>
    //        {
    //            Name = "Gestionnaire",
    //            Status = "onlyForDisplay",
    //            Value = "JEROME TARGET"
    //        },
    //        TransportMode = new Field<string>
    //        {
    //            Name = "Mode de transport",
    //            Status = "onlyForDisplay",
    //            Value = "PAR DÉFAUT"
    //        },
    //        PurchaseId = new Field<string>
    //        {
    //            Name = "Commande d'achat",
    //            Status = "hidden",
    //            Value = ""
    //        },
    //        DiscountDescription = new Field<string>
    //        {
    //            Name = "Description Tarif",
    //            Status = "onlyForDisplay",
    //            Value = ""
    //        },
    //        DiscountRate = new Field<decimal>
    //        {
    //            Name = "Remise sup.",
    //            Status = "readOnly",
    //            Value = 0
    //        },
    //        DiscountPrice = new Field<decimal>
    //        {
    //            Name = "PU HT",
    //            Status = "readOnly",
    //            Value = 0.68m
    //        },
    //        Prices = null
    //    }
    //};




    ////lineUpdateReasons   P0130652

    //]
    //var lineUpdateReasons = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = null,
    //        Value = ""
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD FOLIES",
    //        Value = "ADD FOLIES"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD LIGNE",
    //        Value = "ADD LIGNE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD QTE",
    //        Value = "ADD QTE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ALS",
    //        Value = "ALS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ATT",
    //        Value = "ATT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BPS",
    //        Value = "BPS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BVN",
    //        Value = "BVN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CAD",
    //        Value = "CAD"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CROSS",
    //        Value = "CROSS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CS",
    //        Value = "CS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DAV",
    //        Value = "DAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DEF",
    //        Value = "DEF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ECH",
    //        Value = "ECH"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "EXP",
    //        Value = "EXP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FAC",
    //        Value = "FAC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FID",
    //        Value = "FID"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FIN",
    //        Value = "FIN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FS",
    //        Value = "FS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GCO",
    //        Value = "GCO"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GRT",
    //        Value = "GRT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GSC",
    //        Value = "GSC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "KC",
    //        Value = "KC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "LOC",
    //        Value = "LOC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MKG",
    //        Value = "MKG"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MY ORDER",
    //        Value = "MY ORDER"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NC",
    //        Value = "NC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NCM",
    //        Value = "NCM"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NDI",
    //        Value = "NDI"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "OFF",
    //        Value = "OFF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRA",
    //        Value = "PRA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRV",
    //        Value = "PRV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRW",
    //        Value = "PRW"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "REP",
    //        Value = "REP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RFA",
    //        Value = "RFA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RPL",
    //        Value = "RPL"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "SAV",
    //        Value = "SAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "VU",
    //        Value = "VU"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "WEB",
    //        Value = "WEB"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "XC",
    //        Value = "XC"
    //    }
    //};



    ////logisticFlows   P0130652

    //var logisticFlows = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = "Stock",
    //        Value = "Stock"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Livraison directe",
    //        Value = "DropShipped"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Passage en stock",
    //        Value = "CrossDocked"
    //    }
    //};


    //        //logisticFlows   P0130512

    //        var logisticFlows = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = "Stock",
    //        Value = "Stock"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Livraison directe",
    //        Value = "DropShipped"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Passage en stock",
    //        Value = "CrossDocked"
    //    }
    //};
    //orderLines   P0130863

    //var orderLines = new List<OrderLine>
    //        {
    //            new OrderLine
    //            {
    //                LineNum = new Field<int> { Name = "N° de ligne", Status = "readWrite", Value = 1 },
    //                IsCustomLineNum = false,
    //                LineTags = new List<BasketValueDto>(),
    //                ItemId = new Field<string> { Name = "Code article", Status = "readWrite", Value = "BL50RT" },
    //                Name = new Field<string> { Name = "Description", Status = "readWrite", Value = "RL BULLE RECYCLE 50CMX100M" },
    //                InventLocationId = new Field<string> { Name = "Entrepôt", Status = "readWrite", Value = "PN2" },
    //                SalesQuantity = new Field<int> { Name = "Quantité", Status = "readWrite", Value = 0 },
    //                SalesPrice = new Field<double> { Name = "Prix unitaire", Status = "readWrite", Value = 27.27 },
    //                DiscountType = new Field<string> { Name = "Tarification", Status = "readWrite", Value = "OriginPrice" },
    //                LineAmount = new Field<double> { Name = "Montant HT", Status = "readWrite", Value = 0 },
    //                UpdateReason = new Field<BasketValueDto>
    //                {
    //                    Name = "Motif Modif.",
    //                    Status = "readWrite",
    //                    Value = new BasketValueDto { Description = "GCO", Value = "GCO" }
    //                },
    //                InitialSalesQuantity = new Field<int> { Name = "Qté initiale", Status = "readWrite", Value = 0 },
    //                MultipleQuantity = null,
    //                VatRate = new Field<int> { Name = "Taux de TVA", Status = "readWrite", Value = 20 },
    //                Note = null,
    //                ProductInfo = null,
    //                IsCustomlogisticFlow = false,
    //                LogisticFlow = new Field<string> { Name = "Flux logistique", Status = "readWrite", Value = "Stock" },
    //                PhysicalAvailableQuantity = new Field<int> { Name = "Livré maintenant", Status = "onlyForDisplay", Value = 0 },
    //                OnOrderQuantity = new Field<int> { Name = "A livrer plus tard", Status = "onlyForDisplay", Value = 0 },
    //                PaletteQuantity = new Field<int> { Name = "Quantité/palette", Status = "onlyForDisplay", Value = 36 },
    //                QuantityAtPaletteThreshold = new Field<int> { Name = "Diff Palette", Status = "onlyForDisplay", Value = 0 },
    //                ItemType = new Field<string> { Name = "Type d'article", Status = "onlyForDisplay", Value = "Standard" },
    //                DeliveryDate = new Field<DateTime?> { Name = "Date de liv.", Status = "readOnly", Value = null },
    //                IsCustomDeliveryDate = new Field<bool?> { Name = "Date de liv. manuelle", Status = "readWrite", Value = false },
    //                ItemPhysicalInventQuantity = new Field<int> { Name = "Stock total", Status = "onlyForDisplay", Value = 0 },
    //                ItemReservPhysicalQuantity = new Field<int> { Name = "Stock réservé", Status = "onlyForDisplay", Value = 0 },
    //                ItemPhysicalAvailableQuantity = new Field<int> { Name = "Stock réservé", Status = "onlyForDisplay", Value = 0 },
    //                ItemOnOrderQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                ItemOrderedQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                ItemOrderedAvailableQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                SupplyFamily = new Field<string> { Name = "Famille d'appro.", Status = "onlyForDisplay", Value = "E4 - VRAC VOLUMINEUX (RLX BULLE ET MOUSSE)" },
    //                ItemManager = new Field<string> { Name = "Gestionnaire", Status = "onlyForDisplay", Value = "FAIZANN HUSSAIN" },
    //                TransportMode = new Field<string> { Name = "Mode de transport", Status = "onlyForDisplay", Value = "PAR DÉFAUT" },
    //                PurchaseId = new Field<string> { Name = "Commande d'achat", Status = "hidden", Value = "" },
    //                DiscountDescription = new Field<string> { Name = "Description Tarif", Status = "onlyForDisplay", Value = "" },
    //                DiscountRate = new Field<int> { Name = "Remise sup.", Status = "readOnly", Value = 33 },
    //                DiscountPrice = new Field<double> { Name = "PU HT", Status = "readOnly", Value = 27.27 },
    //                Prices = null
    //            },
    //            new OrderLine
    //            {
    //                LineNum = new Field<int> { Name = "N° de ligne", Status = "readWrite", Value = 2 },
    //                IsCustomLineNum = false,
    //                LineTags = new List<BasketValueDto>(),
    //                ItemId = new Field<string> { Name = "Code article", Status = "readWrite", Value = "PKR7250" },
    //                Name = new Field<string> { Name = "Description", Status = "readWrite", Value = "RL KRAFT RECY 50CMX300M 70G" },
    //                InventLocationId = new Field<string> { Name = "Entrepôt", Status = "readWrite", Value = "PN2" },
    //                SalesQuantity = new Field<int> { Name = "Quantité", Status = "readWrite", Value = 0 },
    //                SalesPrice = new Field<double> { Name = "Prix unitaire", Status = "readWrite", Value = 34.83 },
    //                DiscountType = new Field<string> { Name = "Tarification", Status = "readWrite", Value = "OriginPrice" },
    //                LineAmount = new Field<double> { Name = "Montant HT", Status = "readWrite", Value = 0 },
    //                UpdateReason = new Field<BasketValueDto>
    //                {
    //                    Name = "Motif Modif.",
    //                    Status = "readWrite",
    //                    Value = new BasketValueDto { Description = "GCO", Value = "GCO" }
    //                },
    //                InitialSalesQuantity = new Field<int> { Name = "Qté initiale", Status = "readWrite", Value = 0 },
    //                MultipleQuantity = null,
    //                VatRate = new Field<int> { Name = "Taux de TVA", Status = "readWrite", Value = 20 },
    //                Note = null,
    //                ProductInfo = null,
    //                IsCustomlogisticFlow = false,
    //                LogisticFlow = new Field<string> { Name = "Flux logistique", Status = "readWrite", Value = "Stock" },
    //                PhysicalAvailableQuantity = new Field<int> { Name = "Livré maintenant", Status = "onlyForDisplay", Value = 0 },
    //                OnOrderQuantity = new Field<int> { Name = "A livrer plus tard", Status = "onlyForDisplay", Value = 0 },
    //                PaletteQuantity = new Field<int> { Name = "Quantité/palette", Status = "onlyForDisplay", Value = 0 },
    //                QuantityAtPaletteThreshold = new Field<int> { Name = "Diff Palette", Status = "onlyForDisplay", Value = 0 },
    //                ItemType = new Field<string> { Name = "Type d'article", Status = "onlyForDisplay", Value = "Standard" },
    //                DeliveryDate = new Field<DateTime?> { Name = "Date de liv.", Status = "readOnly", Value = null },
    //                IsCustomDeliveryDate = new Field<bool?> { Name = "Date de liv. manuelle", Status = "readWrite", Value = false },
    //                ItemPhysicalInventQuantity = new Field<int> { Name = "Stock total", Status = "onlyForDisplay", Value = 0 },
    //                ItemReservPhysicalQuantity = new Field<int> { Name = "Stock réservé", Status = "onlyForDisplay", Value = 0 },
    //                ItemPhysicalAvailableQuantity = new Field<int> { Name = "Stock réservé", Status = "onlyForDisplay", Value = 0 },
    //                ItemOnOrderQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                ItemOrderedQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                ItemOrderedAvailableQuantity = new Field<int> { Name = "Commandé total", Status = "onlyForDisplay", Value = 0 },
    //                SupplyFamily = new Field<string> { Name = "Famille d'appro.", Status = "onlyForDisplay", Value = "E4 - VRAC VOLUMINEUX (RLX BULLE ET MOUSSE)" },
    //                ItemManager = new Field<string> { Name = "Gestionnaire", Status = "onlyForDisplay", Value = "FAIZANN HUSSAIN" },
    //                TransportMode = new Field<string> { Name = "Mode de transport", Status = "onlyForDisplay", Value = "PAR DÉFAUT" },
    //                PurchaseId = new Field<string> { Name = "Commande d'achat", Status = "hidden", Value = "" },
    //                DiscountDescription = new Field<string> { Name = "Description Tarif", Status = "onlyForDisplay", Value = "" },
    //                DiscountRate = new Field<int> { Name = "Remise sup.", Status = "readOnly", Value = 33 },
    //                DiscountPrice = new Field<double> { Name = "PU HT", Status = "readOnly", Value = 34.83 },
    //                Prices = null
    //            }
    //        };


    ////lineUpdateReasons   P0130863


    //private List<BasketValueDto> lineUpdateReasons = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = "",
    //        Value = ""
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD FOLIES",
    //        Value = "ADD FOLIES"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD LIGNE",
    //        Value = "ADD LIGNE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD QTE",
    //        Value = "ADD QTE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ALS",
    //        Value = "ALS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ATT",
    //        Value = "ATT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BPS",
    //        Value = "BPS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BVN",
    //        Value = "BVN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CAD",
    //        Value = "CAD"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CROSS",
    //        Value = "CROSS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CS",
    //        Value = "CS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DAV",
    //        Value = "DAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DEF",
    //        Value = "DEF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ECH",
    //        Value = "ECH"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "EXP",
    //        Value = "EXP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FAC",
    //        Value = "FAC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FID",
    //        Value = "FID"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FIN",
    //        Value = "FIN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FS",
    //        Value = "FS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GCO",
    //        Value = "GCO"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GRT",
    //        Value = "GRT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GSC",
    //        Value = "GSC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "KC",
    //        Value = "KC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "LOC",
    //        Value = "LOC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MKG",
    //        Value = "MKG"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MY ORDER",
    //        Value = "MY ORDER"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NC",
    //        Value = "NC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NCM",
    //        Value = "NCM"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NDI",
    //        Value = "NDI"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "OFF",
    //        Value = "OFF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRA",
    //        Value = "PRA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRV",
    //        Value = "PRV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRW",
    //        Value = "PRW"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "REP",
    //        Value = "REP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RFA",
    //        Value = "RFA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RPL",
    //        Value = "RPL"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "SAV",
    //        Value = "SAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "VU",
    //        Value = "VU"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "WEB",
    //        Value = "WEB"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "XC",
    //        Value = "XC"
    //    }
    //};



    ////logisticFlows   P0130863
    //private List<BasketValueDto> logisticFlows = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = "Stock",
    //        Value = "Stock"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Livraison directe",
    //        Value = "DropShipped"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Passage en stock",
    //        Value = "CrossDocked"
    //    }
    //};


    //orderContext/{{basketId}}/notifications   P0130863

    //var notifications = new List<NotificationDto>
    //{
    //    new NotificationDto
    //    {
    //        NotificationId = 1,
    //        Severity = "Warn",
    //        Message = "<strong>[Commande] Activité SAV sur la commande 24136045 depuis une semaine:</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gp5HNYAZ/view\" target=\"_blank\">R0031596</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> lundi 22 juillet \r\n                    à 14:22 \r\n                    pour le motif <strong>M05 - Produit abimé</strong> \r\n                    au statut <strong>Escaladé</strong><br/><strong>Avoir financier</strong> <a href=\"/MyOrderPage?InvoiceId=24A006866\" target=\"_blank\">24A006866</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gh19PYAR/view\" target=\"_blank\">R0031587</a>\r\n                            vendredi 19 juillet à 10:12 par SEVERINE COURCELLE \r\n                            au statut <strong>Facturé</strong>\r\n                            <br/><strong>Retour avec avoir</strong> <a href=\"/MyOrderPage?SalesId=24136860\" target=\"_blank\">24136860</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gh19PYAR/view\" target=\"_blank\">R0031587</a>\r\n                            vendredi 19 juillet à 10:08 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Réexpédition</strong> <a href=\"/MyOrderPage?SalesId=24136859\" target=\"_blank\">24136859</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a>\r\n                            jeudi 18 juillet à 18:21 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Retour simple</strong> <a href=\"/MyOrderPage?SalesId=24136858\" target=\"_blank\">24136858</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a>\r\n                            jeudi 18 juillet à 18:20 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 18:08 \r\n                    pour le motif <strong>M05 - Produit abimé</strong> \r\n                    au statut <strong>Attente Info</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhIYLYA3/view\" target=\"_blank\">R0031589</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 10:50 \r\n                    pour le motif <strong>M05 - Produit manquant</strong> \r\n                    au statut <strong>Escaladé</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhHu1YAF/view\" target=\"_blank\">R0031588</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 10:46 \r\n                    pour le motif <strong>M05 - Produit manquant</strong> \r\n                    au statut <strong>Attente Info</strong><br/>",
    //        CreatedDate = DateTime.Parse("0001-01-01 00:00:00"),
    //        ProcedureCall = new List<string> { "RemoveLog", "1" }
    //    }
    //}; var notifications = new List<NotificationDto>
    //{
    //    new NotificationDto
    //    {
    //        NotificationId = 1,
    //        Severity = "Warn",
    //        Message = "<strong>[Commande] Activité SAV sur la commande 24136045 depuis une semaine:</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gp5HNYAZ/view\" target=\"_blank\">R0031596</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> lundi 22 juillet \r\n                    à 14:22 \r\n                    pour le motif <strong>M05 - Produit abimé</strong> \r\n                    au statut <strong>Escaladé</strong><br/><strong>Avoir financier</strong> <a href=\"/MyOrderPage?InvoiceId=24A006866\" target=\"_blank\">24A006866</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gh19PYAR/view\" target=\"_blank\">R0031587</a>\r\n                            vendredi 19 juillet à 10:12 par SEVERINE COURCELLE \r\n                            au statut <strong>Facturé</strong>\r\n                            <br/><strong>Retour avec avoir</strong> <a href=\"/MyOrderPage?SalesId=24136860\" target=\"_blank\">24136860</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000Gh19PYAR/view\" target=\"_blank\">R0031587</a>\r\n                            vendredi 19 juillet à 10:08 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Réexpédition</strong> <a href=\"/MyOrderPage?SalesId=24136859\" target=\"_blank\">24136859</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a>\r\n                            jeudi 18 juillet à 18:21 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Retour simple</strong> <a href=\"/MyOrderPage?SalesId=24136858\" target=\"_blank\">24136858</a> \r\n                            \r\n                            créé(e)\r\n                            sur la réclamation <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a>\r\n                            jeudi 18 juillet à 18:20 par SEVERINE COURCELLE \r\n                            au statut <strong>Lancée</strong>\r\n                            <br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhxBiYAJ/view\" target=\"_blank\">R0031592</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 18:08 \r\n                    pour le motif <strong>M05 - Produit abimé</strong> \r\n                    au statut <strong>Attente Info</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhIYLYA3/view\" target=\"_blank\">R0031589</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 10:50 \r\n                    pour le motif <strong>M05 - Produit manquant</strong> \r\n                    au statut <strong>Escaladé</strong><br/><strong>Réclamation</strong> <a href=\"https://raja-group-1--uat.sandbox.my.salesforce.com/lightning/r/Case/500AW00000GhHu1YAF/view\" target=\"_blank\">R0031588</a> \r\n                    créé(e) sur la commande <strong>24136045</strong> jeudi 18 juillet \r\n                    à 10:46 \r\n                    pour le motif <strong>M05 - Produit manquant</strong> \r\n                    au statut <strong>Attente Info</strong><br/>",
    //        CreatedDate = DateTime.Parse("0001-01-01 00:00:00"),
    //        ProcedureCall = new List<string> { "RemoveLog", "1" }
    //    }
    //};


    ////orderLines   P0130652
    //var orderLines = new List<OrderLineDto>
    //{
    //    new OrderLineDto
    //    {
    //        LineNum = new Field<int>
    //        {
    //            Name = "N° de ligne",
    //            Status = "readWrite",
    //            Value = 1
    //        },
    //        IsCustomLineNum = false,
    //        LineTags = new List<string>(),
    //        ItemId = new Field<string>
    //        {
    //            Name = "Code article",
    //            Status = "readWrite",
    //            Value = "CAS15"
    //        },
    //        Name = new Field<string>
    //        {
    //            Name = "Description",
    //            Status = "readWrite",
    //            Value = "C.A SC10 31X21,5X10 BRUN"
    //        },
    //        InventLocationId = new Field<string>
    //        {
    //            Name = "Entrepôt",
    //            Status = "readWrite",
    //            Value = "PN2"
    //        },
    //        SalesQuantity = new Field<int>
    //        {
    //            Name = "Quantité",
    //            Status = "readWrite",
    //            Value = 150
    //        },
    //        SalesPrice = new Field<decimal>
    //        {
    //            Name = "Prix unitaire",
    //            Status = "readWrite",
    //            Value = 0.76m
    //        },
    //        DiscountType = new Field<string>
    //        {
    //            Name = "Tarification",
    //            Status = "readWrite",
    //            Value = "NoDiscount"
    //        },
    //        LineAmount = new Field<decimal>
    //        {
    //            Name = "Montant HT",
    //            Status = "readWrite",
    //            Value = 114m
    //        },
    //        UpdateReason = new Field<string>
    //        {
    //            Name = "Motif Modif.",
    //            Status = "readWrite",
    //            Value = ""
    //        },
    //        InitialSalesQuantity = new Field<int>
    //        {
    //            Name = "Qté initiale",
    //            Status = "readWrite",
    //            Value = 0
    //        },
    //        MultipleQuantity = null,
    //        VatRate = new Field<int>
    //        {
    //            Name = "Taux de TVA",
    //            Status = "readWrite",
    //            Value = 20
    //        },
    //        Note = null,
    //        ProductInfo = null,
    //        IsCustomlogisticFlow = false,
    //        LogisticFlow = new Field<string>
    //        {
    //            Name = "Flux logistique",
    //            Status = "readWrite",
    //            Value = "Stock"
    //        },
    //        PhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Livré maintenant",
    //            Status = "onlyForDisplay",
    //            Value = 150
    //        },
    //        OnOrderQuantity = new Field<int>
    //        {
    //            Name = "A livrer plus tard",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        PaletteQuantity = new Field<int>
    //        {
    //            Name = "Quantité/palette",
    //            Status = "onlyForDisplay",
    //            Value = 1100
    //        },
    //        QuantityAtPaletteThreshold = new Field<int>
    //        {
    //            Name = "Diff Palette",
    //            Status = "onlyForDisplay",
    //            Value = 950
    //        },
    //        ItemType = new Field<string>
    //        {
    //            Name = "Type d'article",
    //            Status = "onlyForDisplay",
    //            Value = "Standard"
    //        },
    //        DeliveryDate = new Field<DateTime?>
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
    //        ItemPhysicalInventQuantity = new Field<int>
    //        {
    //            Name = "Stock total",
    //            Status = "onlyForDisplay",
    //            Value = 43250
    //        },
    //        ItemReservPhysicalQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 925
    //        },
    //        ItemPhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 42325
    //        },
    //        ItemOnOrderQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 575
    //        },
    //        ItemOrderedQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedAvailableQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        SupplyFamily = new Field<string>
    //        {
    //            Name = "Famille d'appro.",
    //            Status = "onlyForDisplay",
    //            Value = "C1 - CAISSES ET CONTAINERS"
    //        },
    //        ItemManager = new Field<string>
    //        {
    //            Name = "Gestionnaire",
    //            Status = "onlyForDisplay",
    //            Value = "JEROME TARGET"
    //        },
    //        TransportMode = new Field<string>
    //        {
    //            Name = "Mode de transport",
    //            Status = "onlyForDisplay",
    //            Value = "PAR DÉFAUT"
    //        },
    //        PurchaseId = new Field<string>
    //        {
    //            Name = "Commande d'achat",
    //            Status = "hidden",
    //            Value = ""
    //        },
    //        DiscountDescription = new Field<string>
    //        {
    //            Name = "Description Tarif",
    //            Status = "onlyForDisplay",
    //            Value = ""
    //        },
    //        DiscountRate = new Field<decimal>
    //        {
    //            Name = "Remise sup.",
    //            Status = "readOnly",
    //            Value = 0
    //        },
    //        DiscountPrice = new Field<decimal>
    //        {
    //            Name = "PU HT",
    //            Status = "readOnly",
    //            Value = 0.76m
    //        },
    //        Prices = null
    //    },
    //    new OrderLineDto
    //    {
    //        LineNum = new Field<int>
    //        {
    //            Name = "N° de ligne",
    //            Status = "readWrite",
    //            Value = 2
    //        },
    //        IsCustomLineNum = false,
    //        LineTags = new List<string>(),
    //        ItemId = new Field<string>
    //        {
    //            Name = "Code article",
    //            Status = "readWrite",
    //            Value = "CAS14"
    //        },
    //        Name = new Field<string>
    //        {
    //            Name = "Description",
    //            Status = "readWrite",
    //            Value = "C.A SC10 31X21,5X5,5 BRUN"
    //        },
    //        InventLocationId = new Field<string>
    //        {
    //            Name = "Entrepôt",
    //            Status = "readWrite",
    //            Value = "PN2"
    //        },
    //        SalesQuantity = new Field<int>
    //        {
    //            Name = "Quantité",
    //            Status = "readWrite",
    //            Value = 25
    //        },
    //        SalesPrice = new Field<decimal>
    //        {
    //            Name = "Prix unitaire",
    //            Status = "readWrite",
    //            Value = 0.68m
    //        },
    //        DiscountType = new Field<string>
    //        {
    //            Name = "Tarification",
    //            Status = "readWrite",
    //            Value = "Default"
    //        },
    //        LineAmount = new Field<decimal>
    //        {
    //            Name = "Montant HT",
    //            Status = "readWrite",
    //            Value = 17m
    //        },
    //        UpdateReason = new Field<string>
    //        {
    //            Name = "Motif Modif.",
    //            Status = "readWrite",
    //            Value = ""
    //        },
    //        InitialSalesQuantity = new Field<int>
    //        {
    //            Name = "Qté initiale",
    //            Status = "readWrite",
    //            Value = 0
    //        },
    //        MultipleQuantity = null,
    //        VatRate = new Field<int>
    //        {
    //            Name = "Taux de TVA",
    //            Status = "readWrite",
    //            Value = 20
    //        },
    //        Note = null,
    //        ProductInfo = null,
    //        IsCustomlogisticFlow = false,
    //        LogisticFlow = new Field<string>
    //        {
    //            Name = "Flux logistique",
    //            Status = "readWrite",
    //            Value = "Stock"
    //        },
    //        PhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Livré maintenant",
    //            Status = "onlyForDisplay",
    //            Value = 25
    //        },
    //        OnOrderQuantity = new Field<int>
    //        {
    //            Name = "A livrer plus tard",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        PaletteQuantity = new Field<int>
    //        {
    //            Name = "Quantité/palette",
    //            Status = "onlyForDisplay",
    //            Value = 2100
    //        },
    //        QuantityAtPaletteThreshold = new Field<int>
    //        {
    //            Name = "Diff Palette",
    //            Status = "onlyForDisplay",
    //            Value = 2075
    //        },
    //        ItemType = new Field<string>
    //        {
    //            Name = "Type d'article",
    //            Status = "onlyForDisplay",
    //            Value = "Standard"
    //        },
    //        DeliveryDate = new Field<DateTime?>
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
    //        ItemPhysicalInventQuantity = new Field<int>
    //        {
    //            Name = "Stock total",
    //            Status = "onlyForDisplay",
    //            Value = 7050
    //        },
    //        ItemReservPhysicalQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 900
    //        },
    //        ItemPhysicalAvailableQuantity = new Field<int>
    //        {
    //            Name = "Stock réservé",
    //            Status = "onlyForDisplay",
    //            Value = 6150
    //        },
    //        ItemOnOrderQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        ItemOrderedAvailableQuantity = new Field<int>
    //        {
    //            Name = "Commandé total",
    //            Status = "onlyForDisplay",
    //            Value = 0
    //        },
    //        SupplyFamily = new Field<string>
    //        {
    //            Name = "Famille d'appro.",
    //            Status = "onlyForDisplay",
    //            Value = "C1 - CAISSES ET CONTAINERS"
    //        },
    //        ItemManager = new Field<string>
    //        {
    //            Name = "Gestionnaire",
    //            Status = "onlyForDisplay",
    //            Value = "JEROME TARGET"
    //        },
    //        TransportMode = new Field<string>
    //        {
    //            Name = "Mode de transport",
    //            Status = "onlyForDisplay",
    //            Value = "PAR DÉFAUT"
    //        },
    //        PurchaseId = new Field<string>
    //        {
    //            Name = "Commande d'achat",
    //            Status = "hidden",
    //            Value = ""
    //        },
    //        DiscountDescription = new Field<string>
    //        {
    //            Name = "Description Tarif",
    //            Status = "onlyForDisplay",
    //            Value = ""
    //        },
    //        DiscountRate = new Field<decimal>
    //        {
    //            Name = "Remise sup.",
    //            Status = "readOnly",
    //            Value = 0
    //        },
    //        DiscountPrice = new Field<decimal>
    //        {
    //            Name = "PU HT",
    //            Status = "readOnly",
    //            Value = 0.68m
    //        },
    //        Prices = null
    //    }
    //};



    ////lineUpdateReasons   P0130652

    //]
    //var lineUpdateReasons = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = null,
    //        Value = ""
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD FOLIES",
    //        Value = "ADD FOLIES"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD LIGNE",
    //        Value = "ADD LIGNE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ADD QTE",
    //        Value = "ADD QTE"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ALS",
    //        Value = "ALS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ATT",
    //        Value = "ATT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BPS",
    //        Value = "BPS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "BVN",
    //        Value = "BVN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CAD",
    //        Value = "CAD"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CROSS",
    //        Value = "CROSS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "CS",
    //        Value = "CS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DAV",
    //        Value = "DAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "DEF",
    //        Value = "DEF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "ECH",
    //        Value = "ECH"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "EXP",
    //        Value = "EXP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FAC",
    //        Value = "FAC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FID",
    //        Value = "FID"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FIN",
    //        Value = "FIN"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "FS",
    //        Value = "FS"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GCO",
    //        Value = "GCO"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GRT",
    //        Value = "GRT"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "GSC",
    //        Value = "GSC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "KC",
    //        Value = "KC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "LOC",
    //        Value = "LOC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MKG",
    //        Value = "MKG"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "MY ORDER",
    //        Value = "MY ORDER"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NC",
    //        Value = "NC"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NCM",
    //        Value = "NCM"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "NDI",
    //        Value = "NDI"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "OFF",
    //        Value = "OFF"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRA",
    //        Value = "PRA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRV",
    //        Value = "PRV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "PRW",
    //        Value = "PRW"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "REP",
    //        Value = "REP"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RFA",
    //        Value = "RFA"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "RPL",
    //        Value = "RPL"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "SAV",
    //        Value = "SAV"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "VU",
    //        Value = "VU"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "WEB",
    //        Value = "WEB"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "XC",
    //        Value = "XC"
    //    }
    //};



    ////logisticFlows   P0130652

    //var logisticFlows = new List<BasketValueDto>
    //{
    //    new BasketValueDto
    //    {
    //        Description = "Stock",
    //        Value = "Stock"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Livraison directe",
    //        Value = "DropShipped"
    //    },
    //    new BasketValueDto
    //    {
    //        Description = "Passage en stock",
    //        Value = "CrossDocked"
    //    }
    //};
}





