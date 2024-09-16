namespace MyOrder.Shared.Dtos;

public class BasketNotificationDto
{
    public int NotificationId { get; set; }
    public string? Severity { get; set; }
    public string? Message { get; set; }
    public DateTime CreatedDate { get; set; }
    public List<string?>? ProcedureCall { get; set; }
}
