using System;

namespace ERP.Domain.Entities
{
    public class WorkMaster
    {
        public string Fran { get; set; } = string.Empty;
        public decimal WorkId { get; set; } = 0;
        public string WorkType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = 0;
        public decimal Estimated { get; set; } = 0;
        public DateTime CreateTm { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public string CreateRemarks { get; set; } = string.Empty;
        public DateTime UpdateTm { get; set; } = DateTime.Parse("1900-01-01");
        public string UpdateBy { get; set; } = string.Empty;
        public string UpdateMarks { get; set; } = string.Empty;
    }
}

