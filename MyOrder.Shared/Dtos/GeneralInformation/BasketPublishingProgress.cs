namespace MyOrder.Shared.Dtos.GeneralInformation;

public record BasketPublishingProgress(
    bool IsRunning,
    int ProgressPercentage,
    string CurrentAction,
    int ActionElapsedTime,
    int ProcessElapsedTime);