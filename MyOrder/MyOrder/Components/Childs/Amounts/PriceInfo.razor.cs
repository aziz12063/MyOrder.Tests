using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;

namespace MyOrder.Components.Childs.Amounts
{
    public partial class PriceInfo : BaseFluxorComponent<PricesInfoState, FetchPricesInfoAction>
    {
        private BasketPricesInfoDto BasketPricesInfo => State.Value.PricesInfo;
       

        public string TotalVolumeAndWeight
        {
            // Cancatenation of TotalVolume and TotalWeight to string
             get => BasketPricesInfo.TotalVolume.Value.ToString() + "kg/" + @BasketPricesInfo.TotalWeight.Value.ToString();
        }

        protected override FetchPricesInfoAction CreateFetchAction(string basketId)
        {
            return new FetchPricesInfoAction(basketId);
        }


        private string CouponValue        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo.Coupon.Value);
            set
            {
                BasketPricesInfo.Coupon.Value = value;
                UpdateProcedureCall(value, BasketPricesInfo.Coupon.ProcedureCall);
            }
        }

        private static string NullOrWhiteSpaceHelper(string? value) => string.IsNullOrWhiteSpace(value) ? "-" : value;
        // make it in BaseFluxorComponent, we use it twice 
        private void UpdateProcedureCall(string? newValue, List<string> procedureCall)
        {
            if (procedureCall is { Count: > 0 })
            {
                procedureCall[^1] = newValue ?? string.Empty; // Update with the new value or empty string if null
                OnPropertyUpdatedHandler(procedureCall);
            }
        }
    }
}
