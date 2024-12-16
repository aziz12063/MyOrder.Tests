using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public class DeliveryAccountDraftActions
{
    // ====================================================================
    // Menu intermédiaire
    public Field<string?>? EditMode { get; set; }
    public Field<string?>? AddressLookup { get; set; }

    // ====================================================================
    // Final menu part
    public Field<string?>? AddAddress { get; set; }
    public Field<string?>? CancelAddress { get; set; }
}