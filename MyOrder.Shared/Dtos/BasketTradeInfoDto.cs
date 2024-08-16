using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MyOrder.Shared.Dtos.SharedComponents;

namespace MyOrder.Shared.Dtos
{
    public class BasketTradeInfoDto
    {
        public Field<List<BasketTurnoverLineDto?>>? Turnover { get; set; }
        public BasketContractInfoDto? Contract { get; set; }
    }
    public class BasketTurnoverLineDto
    {
        public string? Name { get; set; }
        public string? Ytd { get; set; }
        public string? YtdN1 { get; set; }
        public string? N1 { get; set; }
        public string? N2 { get; set; }

    }

    public class BasketContractInfoDto
    {
        public Field<string>? ContractId { get; set; }// .Value => Contract and under the table position2
        public Field<string>? ContractType { get; set; }// under the table position1: ContractId.Name + ContractType.Value
        public Field<string>? ContractGroup { get; set; }// in the table .Valu => ContractGroup.Value
        public Field<string>? Status { get; set; }// on the table, Contracts + Status.Value
        public Field<string>? StartDate { get; set; }
        public Field<string>? EndDate { get; set; }
        public Field<string>? CampaignId { get; set; }
        public Field<string>? MainContact { get; set; }
        public Field<string>? OfficeExecutive { get; set; }
        public Field<List<string?>>? DiscountList { get; set; }
    }
}
