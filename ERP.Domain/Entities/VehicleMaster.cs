using System;

namespace ERP.Domain.Entities
{
    public class VehicleMaster
    {
        public string Fran { get; set; } = string.Empty;
        public decimal VechileId { get; set; } = 0;
        public string Vin { get; set; } = string.Empty;
        public string Customer { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int ModelYear { get; set; } = 0;
        public string PlateNo { get; set; } = string.Empty;
        public decimal Mileage { get; set; } = 0;
        public DateTime CreateDt { get; set; } = DateTime.Now;
        public DateTime CreateTm { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public string CreateRemarks { get; set; } = string.Empty;
        public DateTime UpdateDt { get; set; } = DateTime.Parse("1900-01-01");
        public DateTime UpdateTm { get; set; } = DateTime.Parse("1900-01-01");
        public string UpdateBy { get; set; } = string.Empty;
        public string UpdateMarks { get; set; } = string.Empty;
    }
}

