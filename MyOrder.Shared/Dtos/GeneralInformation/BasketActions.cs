namespace MyOrder.Shared.Dtos.GeneralInformation;

public record BasketActions(
    OpenBasketActions? Open,
    ValidateBasketActions? Validate,
    BlockingBasketActions? Blocking,
    CancelBasketActions? Cancel,
    SendingBasketActions? Sending,
    NotesBasketActions? Notes,
    LogsBasketActions? Logs,
    SystemBasketActions? System,
    HistoryBasketActions? History);