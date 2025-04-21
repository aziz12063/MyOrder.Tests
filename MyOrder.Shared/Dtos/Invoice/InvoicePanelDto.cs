using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Invoice;
public class InvoicePanelDto
{
    // ============================================
    // Facturation
    // ============================================
    public string? PanelLabel { get; set; }
    public string? AccountSectionLabel { get; set; }
    public string? PaymentSectionLabel { get; set; }
    public string? InformationSectionLabel { get; set; }


    // Compte de facturation (Ex: C0123456)
    // Modifiable + menu
    public Field<AccountDto?>? Account { get; set; }

    // Pas de contact de facturation dans la version actuelle

    // N° de SIRET
    // Modifiable Resource taxGroup
    public Field<string?>? SiretId { get; set; }

    // Groupe de taxe
    // Modifiable Resource taxGroup
    public Field<BasketValueDto?>? TaxGroup { get; set; }

    public Field<string?>? PaymentAuthorizationAction { get; set; }

    // Condition de paiement  
    // Non modifiable Resource paymentTerms
    public Field<BasketValueDto?>? PaymentTerm { get; set; }

    // Mode de paiement
    // Modifiable Obligatoire Resouce paymentModes
    public Field<BasketValueDto?>? PaymentMode { get; set; }

    // Chorus / service exéc.
    // Modifiable et obligatoire uniquement si isPublicEntity = true
    // Vide et en lecture seule sinon

    public Field<string?>? PublicEntityExecutingService { get; set; }

    // Chorus / engagement juridique
    // Modifiable et obligatoire uniquement si isPublicEntity = true
    // Vide et en lecture seule sinon
    public Field<string?>? PublicEntityLegalCommitment { get; set; }
    public Field<string?>? Note { get; set; }

}
