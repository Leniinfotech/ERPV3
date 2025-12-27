using System;

namespace ERP.Domain.Entities
{
    public class RepairHdr
    {
        public string Fran { get; set; } = string.Empty;
        public string Brch { get; set; } = string.Empty;
        public string Workshop { get; set; } = string.Empty;
        public string RepairType { get; set; } = string.Empty;
        public string RepairNo { get; set; } = string.Empty;
        public DateTime RepairDt { get; set; } = DateTime.Now;
        public string Customer { get; set; } = string.Empty;
        public decimal VehicleId { get; set; } = 0;
        public string Currency { get; set; } = string.Empty;
        public decimal NoOfParts { get; set; } = 0;
        public decimal NoOfJobs { get; set; } = 0;
        public decimal Discount { get; set; } = 0;
        public decimal TotalValue { get; set; } = 0;
        public decimal SeqNo { get; set; } = 0;
        public string SeqPrefix { get; set; } = string.Empty;
        public DateTime CreateTm { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public string CreateRemarks { get; set; } = string.Empty;
        public DateTime UpdateTm { get; set; } = DateTime.Now;
        public string UpdateBy { get; set; } = string.Empty;
        public string UpdateRemarks { get; set; } = string.Empty;
    }
}

