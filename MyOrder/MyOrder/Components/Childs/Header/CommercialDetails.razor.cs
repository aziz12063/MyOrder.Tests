using Fluxor;
using MyOrder.Components.Childs.Shared;
using MyOrder.Shared.Dtos;
using MyOrder.Store.PricesInfoUseCase;
using MyOrder.Store.TradeInfoUseCase;

namespace MyOrder.Components.Childs.Header
{
    public partial class CommercialDetails : BaseFluxorComponent<TradeInfoState, FetchTradeInfoAction>
    {
        private BasketTradeInfoDto? BasketTradeInfoDto => State.Value.BasketTradeInfo;
        private List<BasketTurnoverLineDto?>? Turnover => BasketTradeInfoDto?.Turnover?.Value;
        private BasketContractInfoDto? Contract => BasketTradeInfoDto?.Contract;

        protected override FetchTradeInfoAction CreateFetchAction(TradeInfoState state, string basketId)
        {
            return new FetchTradeInfoAction(state, basketId); ;
        }

        private string DateValue
        {
            get => $"{Contract.StartDate.Value}  - {Contract.EndDate.Value}";
        }

        private string ContractDescription
        {
            get => $"{Contract.ContractId.Name} {Contract.ContractType.Value}";
        }


        private string DiscountListValue
        {
            get
            {
                // log some thing if account is null
                var discount = Contract?.DiscountList?.Value ?? new();
                return string.Join("", discount); ;
            }
            set { }
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

