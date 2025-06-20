using MyOrder.Generator;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Invoice;
public record InvoicePanelDto(
    // ============================================
    // Facturation
    // ============================================
    string? PanelLabel,
    string? AccountSectionLabel,
    AccountActions? AccountActions,
    string? PaymentSectionLabel,
    string? InformationSectionLabel,


    // Compte de facturation (Ex: C0123456)
    // Modifiable + menu
    Field<AccountDto?>? Account,

    // Pas de contact de facturation dans la version actuelle

    // N° de SIRET
    // Modifiable Resource taxGroup
    [property: DisplayOnlyField]
    Field<string?>? SiretId,

    // Groupe de taxe
    // Modifiable Resource taxGroup
    Field<BasketValueDto?>? TaxGroup,

    Field<string?>? CostCenter,

    Field<string?>? PaymentAuthorizationAction,

    // Condition de paiement  
    // Non modifiable Resource paymentTerms
    Field<BasketValueDto?>? PaymentTerm,

    // Mode de paiement
    // Modifiable Obligatoire Resouce paymentModes
    Field<BasketValueDto?>? PaymentMode,

    // Chorus / service exéc.
    // Modifiable et obligatoire uniquement si isEntity = true
    // Vide et en lecture seule sinon

    Field<string?>? PublicEntityExecutingService,

    // Chorus / engagement juridique
    // Modifiable et obligatoire uniquement si isEntity = true
    // Vide et en lecture seule sinon
    Field<string?>? PublicEntityLegalCommitment,

    [property: DisplayOnlyField]
    Field<string?>? Note
);