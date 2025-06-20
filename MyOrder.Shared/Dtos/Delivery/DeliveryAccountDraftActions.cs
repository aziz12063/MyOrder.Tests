using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos.Delivery;

public sealed record DeliveryAccountDraftActions(
    Field<string?>? DeliveryInstructions,
    Field<string?>? AddAddress,
    Field<string?>? EditAddress,
    Field<string?>? CancelAddress,
    Field<string?>? UpdateDeliveryInstructions,
    Field<string?>? AddressLookup,
    Field<string?>? SalesforceLink,
    Field<string?>? ClickToCall,
    Field<string?>? OrderInfo) 
    : AccountActions(
        AddressLookup,
        SalesforceLink,
        ClickToCall,
        OrderInfo);