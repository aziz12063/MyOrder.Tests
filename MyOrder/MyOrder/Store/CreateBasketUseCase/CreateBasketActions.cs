using MyOrder.Shared.Dtos;

namespace MyOrder.Store.CreateBasketUseCase
{
    public class CreateBasketAction(NewBasketRequestDto newBasketRequest)
    {
        public NewBasketRequestDto NewBasketReques { get; set; } = newBasketRequest;
    }
    public class CreateBasketSuccessAction(NewBasketResponseDto newBasketResponse)
    {
        public NewBasketResponseDto NewBasketResponse { get; set; } = newBasketResponse;
    }

    public class CreateBasketFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }
}
