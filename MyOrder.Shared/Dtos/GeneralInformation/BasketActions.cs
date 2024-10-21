namespace MyOrder.Shared.Dtos.GeneralInformation;

public class BasketActions
{
    public OpenBasketActions? Open { get; set; }
    public BlockingBasketActions? Blocking { get; set; }
    public ValidateBasketActions? Validate { get; set; }
    public CancelBasketActions? Cancel { get; set; }
    public MiscBasketActions? Misc { get; set; }
    public SystemBasketActions? System { get; set; }
}