using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public class DeliveryAccountDraftActions : AccountActions
{
    public Field<string?>? DeliveryInstructions { get; set; }
    public Field<string?>? AddAddress { get; set; }
    public Field<string?>? EditAddress { get; set; }
    public Field<string?>? CancelAddress { get; set; }
    public Field<string?>? UpdateDeliveryInstructions { get; set; }

}