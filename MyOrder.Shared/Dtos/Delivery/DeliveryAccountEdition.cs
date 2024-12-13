using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public class DeliveryAccountEdition
{

    // ====================================================================
    public string? AccountSectionLabel { get; set; }

    public Field<string?>? AccountId { get; set; }
    public Field<string?>? OriginAccountId { get; set; }
    public Field<string?>? Name { get; set; }
    public Field<string?>? Recipient { get; set; }

    // ====================================================================
    public string? AddressSectionLabel { get; set; }

    public Field<string?>? Building { get; set; }
    public Field<string?>? Street { get; set; }
    public Field<string?>? Locality { get; set; }
    public Field<string?>? Zipcode { get; set; }
    public Field<string?>? City { get; set; }
    public Field<string?>? Country { get; set; }

    // ====================================================================
    // Menus
    public DeliveryAccountEditActions? Actions { get; set; }

    // ====================================================================
    // Lookup part
    public List<Address?>? AddressLookupResults { get; set; }
}
