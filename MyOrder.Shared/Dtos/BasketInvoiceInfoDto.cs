

using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;
public class BasketInvoiceInfoDto
{
    // ============================================
    // Facturation
    // ============================================

    // Compte de facturation (Ex: C0123456)
    // Modifiable + menu
    public Field<AccountDto>? Account { get; set; }

    // Pas de contact de facturation dans la version actuelle

    // N° de SIRET
    // Modifiable Resource taxGroup
    public Field<string>? SiretId { get; set; }

    // Groupe de taxe
    // Modifiable Resource taxGroup
    public Field<string>? TaxGroup { get; set; }

    // Condition de paiement  
    // Non modifiable Resource paymentTerms
    public Field<string>? PaymentTerm { get; set; }

    // Mode de paiement
    // Modifiable Obligatoire Resouce paymentModes
    public Field<string>? PaymentMode { get; set; }

    public bool? IsPublicEntity { get; set; }

    // Chorus / service exéc.
    // Modifiable et obligatoire uniquement si isPublicEntity = true
    // Vide et en lecture seule sinon

    public Field<string>? PublicEntityExecutingService { get; set; }

    // Chorus / engagement juridique
    // Modifiable et obligatoire uniquement si isPublicEntity = true
    // Vide et en lecture seule sinon
    public Field<string>? PublicEntityLegalCommitment { get; set; }
    public Field<string>? Note { get; set; }

}
