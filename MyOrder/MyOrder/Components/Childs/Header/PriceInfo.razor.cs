using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using System.Formats.Asn1;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos.SharedComponents;
using MyOrder.Utils;
using static MudBlazor.Colors;

namespace MyOrder.Components.Childs.Header
{
    public partial class PriceInfo : BaseFluxorComponent<PricesInfoState, FetchPricesInfoAction>
    {
        private BasketPricesInfoDto? BasketPricesInfo { get; set; }
        private List<BasketValueDto?>? Coupons { get; set; }
        private List<BasketValueDto?>? WarrantyCostOptions { get; set; }
        private List<BasketValueDto?>? ShippingCostOptions { get; set; }
        private bool IsLoading { get; set; }


        protected override void CacheNewFields()
        {
            BasketPricesInfo = State.Value.PricesInfo ?? throw new NullReferenceException("Unexpected null for BasketOrderInfo object.");
            Coupons = State.Value.Coupons;
            WarrantyCostOptions = State.Value.WarrantyCostOptions;
            ShippingCostOptions = State.Value.ShippingCostOptions;
            IsLoading = State.Value.IsLoading;
        }

        public string TotalVolumeAndWeight
        {
            // Cancatenation of TotalVolume and TotalWeight to string
            get => BasketPricesInfo.TotalVolume.Value.ToString() + "kg/" + @BasketPricesInfo.TotalWeight.Value.ToString();
        }

        protected override FetchPricesInfoAction CreateFetchAction(PricesInfoState state, string basketId)
        {
            return new FetchPricesInfoAction(state, basketId);
        }

        // i think to make this as a method to avoid call it a lot
        // we already checked the obj in the razor page, so check only the field.
        private bool SetValue<T>(Field<T> field, object obj)
        {
            if (obj == null)
            {
                Logger.LogWarning($"the obj is null .");
                return false;
            }
            else if (field == null)
            {
                Logger.LogWarning($"the field is null .");
                return false;
            }
            else if (field.Value == null)
            {
                Logger.LogWarning($"the field.Value is null .");
                //return false;
                return true; // i will test this later
            }
            else return true;
        }
        private string CouponValue
        {
            get => GetFieldValue(BasketPricesInfo?.Coupon?.Value);
            set
            {
                if(SetValue<string>(BasketPricesInfo.Coupon, BasketPricesInfo))
                {
                    SetBasketOrderValue(field: BasketPricesInfo.Coupon, value: value, procedureCallValue: value);
                    
                }
            }
        }

        private decimal? FreeShippingAmountThresholdValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.FreeShippingAmountThreshold?.Value);
        }

        private decimal? GiftAmountThresholdValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.GiftAmountThreshold?.Value);
        }

        private string? ProductsInfoValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.ProductsInfo?.Value);
        }

        private decimal? ProductsNetAmountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.ProductsNetAmount?.Value);
        }

        private decimal? WarrantyCostAmountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.WarrantyCostAmount?.Value);
        }

        private string? LogisticInfoValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.LogisticInfo?.Value);
        }

        private decimal? TotalNetAmountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.TotalNetAmount?.Value);
        }

        private decimal? VatAmountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.VatAmount?.Value);
        }

        private decimal? TotalGrossAmountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.TotalGrossAmount?.Value);
        }

        private string? FirstDeliveryDateValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.FirstDeliveryDate?.Value);
        }

        private string? LastDeliveryDateValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.LastDeliveryDate?.Value);
        }

        private decimal? AdditionalSalesAmountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.AdditionalSalesAmount?.Value);
        }

        private decimal? DiscountAmountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.DiscountAmount?.Value);
        }

        private decimal? TotalWeightValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.TotalWeight?.Value);
        }

        private decimal? TotalVolumeValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.TotalVolume?.Value);
        }


        private string WarrantyCostOptionsValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.WarrantyCostOption?.Value);
            set
            {
                if (BasketPricesInfo == null)
                    throw new InvalidOperationException("BasketPricesInfo is null");

                SetBasketOrderValue(field: BasketPricesInfo.WarrantyCostOption, value: value, procedureCallValue: value);
            }
        }

        private string ShippingCostOptionValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.ShippingCostOption?.Value);
            set
            {
                if (BasketPricesInfo == null)
                    throw new InvalidOperationException("BasketPricesInfo is null");
                SetBasketOrderValue(field: BasketPricesInfo.ShippingCostOption, value: value, procedureCallValue: value);
            }
        }

        private decimal? ShippingCostAmountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.ShippingCostAmount?.Value);
            set
            {
                if (BasketPricesInfo == null)
                    throw new InvalidOperationException("BasketPricesInfo is null");
                
                SetBasketOrderValue(field: BasketPricesInfo.ShippingCostAmount, value: value, procedureCallValue: value.ToString());
            }
        }

        private int? OrderDiscountRateValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.OrderDiscountRate?.Value);
            set
            {
                if (BasketPricesInfo == null)
                    throw new InvalidOperationException("BasketPricesInfo is null");

                SetBasketOrderValue(field: BasketPricesInfo.OrderDiscountRate, value: value, procedureCallValue: value.ToString());
            }
        }

        private bool? OrderLastColumnDiscountValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketPricesInfo?.OrderLastColumnDiscount?.Value); // check this
            set
            {
                if (BasketPricesInfo == null)
                    throw new InvalidOperationException("BasketPricesInfo is null");
            
                SetBasketOrderValue(field: BasketPricesInfo.OrderLastColumnDiscount, value: value, procedureCallValue: value.ToString());
            }
        }

        
    }
}
