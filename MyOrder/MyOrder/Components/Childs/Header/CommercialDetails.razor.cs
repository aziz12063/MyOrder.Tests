using Fluxor;
using MyOrder.Components.Common;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Store.TradeInfoUseCase;
using MyOrder.Utils;

namespace MyOrder.Components.Childs.Header
{
    public partial class CommercialDetails : BaseFluxorComponent<TradeInfoState, FetchTradeInfoAction>
    {

        private BasketTradeInfoDto? BasketTradeInfoDto { get; set; }
        private List<BasketTurnoverLineDto?>? Turnover { get; set; }
        private BasketContractInfoDto? Contract { get; set; }
        private string? DiscountDetails { get; set; }

        protected override FetchTradeInfoAction CreateFetchAction(TradeInfoState state, string basketId)
        {
            return new FetchTradeInfoAction(state, basketId); ;
        }
        protected override void CacheNewFields()
        {
            BasketTradeInfoDto = State.Value.BasketTradeInfo ?? throw new NullReferenceException("Unexpected null for BasketOrderInfo object.");
            Turnover = BasketTradeInfoDto?.Turnover?.Value;
            Contract = BasketTradeInfoDto?.Contract;    
            DiscountDetails = FieldUtility.DisplayListNoSpace(Contract?.DiscountList?.Value);
        }
       
        private string DateValue
        {
            get
            {
                var startDate = FieldUtility.NullOrWhiteSpaceHelper(Contract?.StartDate?.Value);
                var endDate = FieldUtility.NullOrWhiteSpaceHelper(Contract?.EndDate?.Value);
                return $"{startDate}  - {endDate}";
            }
        }

        private string CampaignIdValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketTradeInfoDto?.Contract?.CampaignId?.Value);
        }

        private string MainContactValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketTradeInfoDto?.Contract?.MainContact?.Value);
        }

        private string OfficeExecutiveValue
        {
            get => FieldUtility.NullOrWhiteSpaceHelper(BasketTradeInfoDto?.Contract?.OfficeExecutive?.Value);
        }

        private string ContractDescription
        {
            get => $"{Contract?.ContractId?.Name} {Contract?.ContractType?.Value}";
        }

        private List<BasketContractInfoDto> ContractList
        {
            get
            {
                var list = new List<BasketContractInfoDto>();

                if (Contract != null)
                {
                    if (Contract.ContractId != null  && Contract.ContractGroup != null && Contract.Status != null)
                    {
                        if (Contract.ContractId.Value != null && Contract.Status.Value != null && Contract.ContractGroup.Name != null)
                        {
                            list.Add(Contract);

                        }
                    }
                }
                return list;
            }
        }
    }
}

