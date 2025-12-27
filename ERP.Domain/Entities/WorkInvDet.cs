using System;

namespace ERP.Domain.Entities
{
    public class WorkInvDet
    {
        public string Fran { get; set; } = string.Empty;
        public string Brch { get; set; } = string.Empty;
        public string Workshop { get; set; } = string.Empty;
        public string WorkInvType { get; set; } = string.Empty;
        public string WorkInvNo { get; set; } = string.Empty;
        public decimal WorkInvSrl { get; set; } = 0;
        public DateTime WorkInvDt { get; set; } = DateTime.Parse("1900-01-01");
        public string BillType { get; set; } = string.Empty;
        public string WorkType { get; set; } = string.Empty;
        public decimal WorkId { get; set; } = 0;
        public string Make { get; set; } = string.Empty;
        public decimal Part { get; set; } = 0;
        public decimal Qty { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public decimal VatPercentage { get; set; } = 0;
        public decimal VatValue { get; set; } = 0;
        public decimal TotalValue { get; set; } = 0;
        public string ReapairType { get; set; } = string.Empty;
        public string ReapairNo { get; set; } = string.Empty;
        public decimal RepairSrl { get; set; } = 0;
        public string SaleType { get; set; } = string.Empty;
        public string SaleNo { get; set; } = string.Empty;
        public DateTime CreateTm { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public string CreateRemarks { get; set; } = string.Empty;
        public DateTime UpdateTm { get; set; } = DateTime.Parse("1900-01-01");
        public string UpdateBy { get; set; } = string.Empty;
        public string UpdateRemarks { get; set; } = string.Empty;
    }
}

