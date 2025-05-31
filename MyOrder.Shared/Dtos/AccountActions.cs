using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos;

public class AccountActions
{
    public Field<string?>? AddressLookup { get; set; }
    public Field<string?>? SalesforceLink { get; set; }
    public Field<string?>? ClickToCall { get; set; }
    public Field<string?>? OrderInfo { get; set; }

}