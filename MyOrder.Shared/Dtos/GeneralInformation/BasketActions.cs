namespace MyOrder.Shared.Dtos.GeneralInformation;

public class BasketActions
{
    public OpenBasketActions? Open { get; set; }
    public ValidateBasketActions? Validate { get; set; }
    public BlockingBasketActions? Blocking { get; set; }
    public CancelBasketActions? Cancel { get; set; }
    public SendingBasketActions? Sending { get; set; }
    public NotesBasketActions? Notes { get; set; }
    public LogsBasketActions? Logs { get; set; }
    public SystemBasketActions? System { get; set; }
    public HistoryBasketActions? History { get; set; }
}