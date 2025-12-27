using System;

namespace ERP.Domain.Entities
{
    public class RepairOrder
    {
        public string Fran { get; set; } = string.Empty;
        public string Brch { get; set; } = string.Empty;
        public string Workshop { get; set; } = string.Empty;
        public string RepairType { get; set; } = string.Empty;
        public string RepairNo { get; set; } = string.Empty;
        public string RepairSrl { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public decimal VehicleId { get; set; } = 0;
        public decimal WorkId { get; set; } = 0;
        public string WorkType { get; set; } = string.Empty;
        public DateTime WorkDt { get; set; } = DateTime.Parse("1900-01-01");
        public decimal NoOfWorks { get; set; } = 0;
        public decimal UnitPrice { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public decimal TotalValue { get; set; } = 0;
        public DateTime CreateTm { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public string CreateRemarks { get; set; } = string.Empty;
        public DateTime UpdateTm { get; set; } = DateTime.Parse("1900-01-01");
        public string UpdateBy { get; set; } = string.Empty;
        public string UpdateRemarks { get; set; } = string.Empty;
    }
}

