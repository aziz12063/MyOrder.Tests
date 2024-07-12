using MyOrder.Shared.Dtos;

namespace MyOrder.Store
{
    public class FetchAmountsDataAction
    {
        public BasketAmountsDto BasketAmountsDto { get; }

        public FetchAmountsDataAction(BasketAmountsDto basketAmountsDto)
        {
            BasketAmountsDto = basketAmountsDto;
        }
    }

    // in a complexe type i add those classes
    public class FetchAmountsDataRequestAction
    {
        public string BasketId { get; }

        public FetchAmountsDataRequestAction(string basketId)
        {
            BasketId = basketId;
        }
    }

    public class FetchAmountsDataErrorAction
    {
        public string ErrorMessage { get; }

        public FetchAmountsDataErrorAction(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}

    