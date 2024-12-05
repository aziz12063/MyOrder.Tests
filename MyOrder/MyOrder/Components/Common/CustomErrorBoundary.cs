using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyOrder.Shared.Enums;
using MyOrder.Shared.Interfaces;

namespace MyOrder.Components.Common;

public class CustomErrorBoundary : ErrorBoundary
{
    [Inject]
    ILogger<CustomErrorBoundary> Logger { get; set; } = default!;
    [Inject]
    INotificationService NotificationService { get; set; } = default!;

    protected override Task OnErrorAsync(Exception ex)
    {
        Logger.LogCritical("An unhandled exception occurred.");

        Logger.LogError(ex, "An unhandled exception occurred.");

        NotificationService.ShowMessage("An unexpected error occurred. Please try again later.", NotificationType.Error);

        // Display different messages based on exception type
        // if (exception is SpecificExceptionType)
        // {
        //     NotificationService.ShowMessage("A specific error occurred.", NotificationType.Error);
        // }

        Recover();

        return Task.CompletedTask;
    }
}
