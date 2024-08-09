using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using System.Formats.Asn1;
using static MudBlazor.Colors;

namespace MyOrder.Components.Childs.Header
{
    public partial class PriceInfo : BaseFluxorComponent<PricesInfoState, FetchPricesInfoAction>
    {
        private BasketPricesInfoDto? BasketPricesInfo => State.Value.PricesInfo;
        private List<BasketValueDto?>? Coupons => State.Value.Coupons;
        private List<BasketValueDto?>? WarrantyCostOptions => State.Value.WarrantyCostOptions;
        private List<BasketValueDto?>? ShippingCostOptions => State.Value.ShippingCostOptions;
        private bool IsLoading => State.Value.IsLoading;
        

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
        private bool SetValue<T>(Field<T> field, object obj)
        {
            if (obj == null)
            {
                logger.LogWarning($"the obj is null .");
                return false;
            }
            else if (field == null)
            {
                logger.LogWarning($"the field is null .");
                return false;
            }
            else if (field.Value == null)
            {
                logger.LogWarning($"the field.Value is null .");
                return false;
            }
            else return true;
           
        }

        
        private string CouponValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo?.Coupon?.Value);
            set
            {
               
                if(SetValue<string>(BasketPricesInfo.Coupon, BasketPricesInfo))
                {
                    logger.LogWarning($"the CouponValue  is not null .");
                    BasketPricesInfo.Coupon.Value = value;
                    UpdateProcedureCall(value, BasketPricesInfo.Coupon.ProcedureCall);
                }

            }
        }
        private string WarrantyCostOptionsValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo?.WarrantyCostOption?.Value);
            set
            {
                BasketPricesInfo.WarrantyCostOption.Value = value;
                UpdateProcedureCall(value, BasketPricesInfo.WarrantyCostOption.ProcedureCall);
            }
        }
        private string ShippingCostOptionValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo?.ShippingCostOption?.Value);
            set
            {
                BasketPricesInfo.ShippingCostOption.Value = value;
                UpdateProcedureCall(value, BasketPricesInfo.ShippingCostOption.ProcedureCall);
            }
        }

        private decimal? ShippingCostAmountValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo?.ShippingCostAmount?.Value);
            set
            {
                BasketPricesInfo.ShippingCostAmount.Value = value;
                UpdateProcedureCall(value.ToString(), BasketPricesInfo.ShippingCostAmount.ProcedureCall);
            }
        }

        private int? OrderDiscountRateValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo?.OrderDiscountRate?.Value);
            set
            {
                BasketPricesInfo.OrderDiscountRate.Value = value;
             
                UpdateProcedureCall(value.ToString(), BasketPricesInfo.OrderDiscountRate.ProcedureCall);
            }
        }

        private bool? OrderLastColumnDiscountValue
        {
            get => NullOrWhiteSpaceHelper(BasketPricesInfo?.OrderLastColumnDiscount?.Value); // check this
            set
            {
                BasketPricesInfo.OrderLastColumnDiscount.Value = value;
                UpdateProcedureCall(value.ToString(), BasketPricesInfo.OrderLastColumnDiscount.ProcedureCall);
            }
        }

        // make them in BaseFluxorComponent??
        private static decimal? NullOrWhiteSpaceHelper(decimal? value) => value == null || value == 0 ? 0 : value;
        private static int? NullOrWhiteSpaceHelper(int? value) => value == null || value == 0 ? 0 : value;
        private static bool? NullOrWhiteSpaceHelper(bool? value) => value == null || value == false ? false : value;// i make just value if we keep the init value as false
    }
}
