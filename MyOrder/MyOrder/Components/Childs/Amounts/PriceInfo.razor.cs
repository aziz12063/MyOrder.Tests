using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;

namespace MyOrder.Components.Childs.Amounts
{
    public partial class PriceInfo : BaseFluxorComponent<PricesInfoState, FetchPricesInfoAction>
    {
        private BasketPricesInfoDto BasketPricesInfo => State.Value.PricesInfo;
        private List<BasketValueDto> Coupons => State.Value.Coupons;
        private List<BasketValueDto> WarrantyCostOptions => State.Value.WarrantyCostOptions;
        private List<BasketValueDto> ShippingCostOptions => State.Value.ShippingCostOptions;
       

        public string TotalVolumeAndWeight
        {
            // Cancatenation of TotalVolume and TotalWeight to string
             get => BasketPricesInfo.TotalVolume.Value.ToString() + "kg/" + @BasketPricesInfo.TotalWeight.Value.ToString();
        }

        protected override FetchPricesInfoAction CreateFetchAction(string basketId)
        {
            return new FetchPricesInfoAction(basketId);
        }

        // i think to make this as a method to avoid call it a lot
        private string CouponValue        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo.Coupon.Value);
            set
            {
                BasketPricesInfo.Coupon.Value = value;
                UpdateProcedureCall(value, BasketPricesInfo.Coupon.ProcedureCall);
            }
        }
        private string WarrantyCostOptionsValue
        { 
            get => NullOrWhiteSpaceHelper(BasketPricesInfo.WarrantyCostOption.Value);
            set
            {
                BasketPricesInfo.WarrantyCostOption.Value = value;
                UpdateProcedureCall(value, BasketPricesInfo.WarrantyCostOption.ProcedureCall);
            }
        }
        private string ShippingCostOptionValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo.ShippingCostOption.Value);
            set
            {
                BasketPricesInfo.ShippingCostOption.Value = value;
                UpdateProcedureCall(value, BasketPricesInfo.ShippingCostOption.ProcedureCall);
            }
        }

        private decimal ShippingCostAmountValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo.ShippingCostAmount.Value);
            set
            {
                BasketPricesInfo.ShippingCostAmount.Value = value;
                UpdateProcedureCall(value.ToString(), BasketPricesInfo.ShippingCostAmount.ProcedureCall);
            }
        }

        private int OrderDiscountRateValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo.OrderDiscountRate.Value);
            set
            {
                BasketPricesInfo.OrderDiscountRate.Value = value;
                UpdateProcedureCall(value.ToString(), BasketPricesInfo.OrderDiscountRate.ProcedureCall);
            }
        }

        private bool OrderLastColumnDiscountValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo.OrderLastColumnDiscount.Value); // check this
            set
            {
                BasketPricesInfo.OrderLastColumnDiscount.Value = value;
                UpdateProcedureCall(value.ToString(), BasketPricesInfo.OrderLastColumnDiscount.ProcedureCall);
            }
        }



        // make them in BaseFluxorComponent??
        private static decimal NullOrWhiteSpaceHelper(decimal value) => value == null || value == 0 ? 0 : value;
        private static int NullOrWhiteSpaceHelper(int value) => value == null || value == 0 ? 0 : value;
        private static bool NullOrWhiteSpaceHelper(bool value) => value == null || value == false ? false : value;// i make just value if we keep the init value as false
    }
}
