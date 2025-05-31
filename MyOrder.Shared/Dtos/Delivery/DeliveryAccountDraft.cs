using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public class DeliveryAccountDraft
{

    // ====================================================================
    public string? AccountSectionLabel { get; set; }

    public Field<string?>? AccountId { get; set; }
    public Field<string?>? AccountType { get; set; }
    public Field<string?>? Name { get; set; }
    public Field<string?>? Recipient { get; set; }

    // ====================================================================
    public string? AddressSectionLabel { get; set; }

    public Field<string?>? Building { get; set; }
    public Field<string?>? Street { get; set; }
    public Field<string?>? Locality { get; set; }
    public Field<string?>? Zipcode { get; set; }
    public Field<string?>? City { get; set; }
    public Field<BasketValueDto?>? Country { get; set; }

    // ====================================================================
    // Instruction de livraison

    public Field<bool?>? Lift { get; set; }
    public Field<string?>? Floor { get; set; }
    public Field<string?>? DigiCode { get; set; }
    public Field<BasketValueDto?>? CarrierType { get; set; }
    public Field<bool?>? AppointmentRequired { get; set; }
    public Field<string?>? DeliveryNote { get; set; }

    // ====================================================================
    // Calendrier de livraison
    public List<WeekDay?>? WeekDays { get; set; }

    // ====================================================================
    // Menus
    public Field<string?>? StatusMessage { get; set; }
    public DeliveryAccountDraftActions? Actions { get; set; }

    // ====================================================================
    // Lookup part
    public List<Address?>? AddressLookupResults { get; set; }
}
