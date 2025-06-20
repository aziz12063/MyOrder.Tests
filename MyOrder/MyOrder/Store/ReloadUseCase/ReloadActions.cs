using MyOrder.Shared.Dtos;

namespace MyOrder.Store.ReloadUseCase;

public record ReloadAction { }

public record ReloadSuccessAction(NewOrderContextResponse Response);

public record ReloadFailureAction(NewOrderContextResponse Response);