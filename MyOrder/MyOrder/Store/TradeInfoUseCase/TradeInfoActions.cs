using MyOrder.Shared.Dtos;

namespace MyOrder.Store.TradeInfoUseCase
{
    public class FetchTradeInfoAction(string basketId)
    {
        public string BasketId { get; } = basketId;
    }

    public class FetchTradeInfoSuccessAction(BasketTradeInfoDto? basketTradeInfo)
    {
        public BasketTradeInfoDto? BasketTradeInfo { get; } = basketTradeInfo;
    }

    public class FetchTradeInfoFailureAction(string errorMessage)
    {
        public string ErrorMessage { get; } = errorMessage;
    }

    // to delete
    public class NoDataLoadedTradeInfoAction
    {
        public BasketTradeInfoDto? BasketTradeInfo = new()
        {
            Turnover = new Field<List<BasketTurnoverLineDto?>>()
            {
                Name = "TurnoverField",
                Status = "Active",
                Type = "List",
                Value = new List<BasketTurnoverLineDto?>
            {
                new BasketTurnoverLineDto
                {
                    Name = "Product A",
                    Ytd = "1000",
                    YtdN1 = "900",
                    N1 = "800",
                    N2 = "700"
                },
                new BasketTurnoverLineDto
                {
                    Name = "Product B",
                    Ytd = "2000",
                    YtdN1 = "1800",
                    N1 = "1600",
                    N2 = "1400"
                },
                new BasketTurnoverLineDto
                {
                    Name = "Product C",
                    Ytd = "1500",
                    YtdN1 = "1300",
                    N1 = "1200",
                    N2 = "1100"
                }
            },
                ProcedureCall = new List<string?> { "Proc1", "Proc2" },
                Error = null,
                Description = "This is the turnover data",
                Url = "/api/turnover"
            },
            Contract = new BasketContractInfoDto
            {
                ContractId = new Field<string>
                {
                    Name = "ContractId",
                    Status = "Active",
                    Type = "String",
                    Value = "C-12345",
                    ProcedureCall = new List<string?> { "GetContractId" },
                    Error = null,
                    Description = "The unique identifier of the contract",
                    Url = "/api/contract/id"
                },
                ContractType = new Field<string>
                {
                    Name = "ContractType",
                    Status = "Active",
                    Type = "String",
                    Value = "Premium",
                    ProcedureCall = new List<string?> { "GetContractType" },
                    Error = null,
                    Description = "The type of the contract",
                    Url = "/api/contract/type"
                },
                ContractGroup = new Field<string>
                {
                    Name = "ContractGroup",
                    Status = "Active",
                    Type = "String",
                    Value = "Group A",
                    ProcedureCall = new List<string?> { "GetContractGroup" },
                    Error = null,
                    Description = "The group associated with the contract",
                    Url = "/api/contract/group"
                },
                Status = new Field<string>
                {
                    Name = "Status",
                    Status = "Active",
                    Type = "String",
                    Value = "Active",
                    ProcedureCall = new List<string?> { "GetContractStatus" },
                    Error = null,
                    Description = "The status of the contract",
                    Url = "/api/contract/status"
                },
                StartDate = new Field<string>
                {
                    Name = "StartDate",
                    Status = "Active",
                    Type = "Date",
                    Value = "2023-01-01",
                    ProcedureCall = new List<string?> { "GetStartDate" },
                    Error = null,
                    Description = "The start date of the contract",
                    Url = "/api/contract/startdate"
                },
                EndDate = new Field<string>
                {
                    Name = "EndDate",
                    Status = "Active",
                    Type = "Date",
                    Value = "2024-01-01",
                    ProcedureCall = new List<string?> { "GetEndDate" },
                    Error = null,
                    Description = "The end date of the contract",
                    Url = "/api/contract/enddate"
                },
                CampaignId = new Field<string>
                {
                    Name = "CampaignId",
                    Status = "Active",
                    Type = "String",
                    Value = "Campaign-X",
                    ProcedureCall = new List<string?> { "GetCampaignId" },
                    Error = null,
                    Description = "The ID of the associated campaign",
                    Url = "/api/contract/campaignid"
                },
                MainContact = new Field<string>
                {
                    Name = "MainContact",
                    Status = "Active",
                    Type = "String",
                    Value = "John Doe",
                    ProcedureCall = new List<string?> { "GetMainContact" },
                    Error = null,
                    Description = "The main contact for the contract",
                    Url = "/api/contract/maincontact"
                },
                OfficeExecutive = new Field<string>
                {
                    Name = "OfficeExecutive",
                    Status = "Active",
                    Type = "String",
                    Value = "Jane Smith",
                    ProcedureCall = new List<string?> { "GetOfficeExecutive" },
                    Error = null,
                    Description = "The office executive handling the contract",
                    Url = "/api/contract/officeexecutive"
                },
                DiscountList = new Field<List<string?>>()
                {
                    Name = "DiscountList",
                    Status = "Active",
                    Type = "List",
                    Value = new List<string?> { "10% off", "15% off", "Free Shipping" },
                    ProcedureCall = new List<string?> { "GetDiscountList" },
                    Error = null,
                    Description = "List of discounts applied to the contract",
                    Url = "/api/contract/discountlist"
                }
            }
        };
    }


}
