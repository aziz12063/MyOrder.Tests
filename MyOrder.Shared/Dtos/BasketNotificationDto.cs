using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOrder.Shared.Dtos
{
    public class BasketNotificationDto
    {
        public List<NotificationDto?>? Notifications { get; set; }
    }

    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string? Severity { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string?>? ProcedureCall { get; set; }
    }
}
