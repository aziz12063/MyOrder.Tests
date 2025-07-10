using MyOrder.Shared.Dtos;

namespace MyOrder.Store.CreateBasketUseCase;

public record CreateBasketAction(Dictionary<string, string> NewBasketRequest, string OperationName);

public class CloneBasketAction { }

public class CreateBasketSuccessAction(NewBasketResponseDto newBasketResponse)
{
    public NewBasketResponseDto NewBasketResponse { get; set; } = newBasketResponse;
}

public class CreateBasketFailureAction(string errorMessage)
{
    public string ErrorMessage { get; } = errorMessage;
}
