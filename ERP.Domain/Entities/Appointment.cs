using System;

namespace ERP.Domain.Entities
{
    public class Appointment
    {
        public string Fran { get; set; } = string.Empty;
        public decimal AppointId { get; set; } = 0;
        public DateTime AppointDt { get; set; } = DateTime.Parse("1900-01-01");
        public string Customer { get; set; } = string.Empty;
        public decimal VehicleId { get; set; } = 0;
        public string AssaignedTo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public DateTime CreateTm { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public string CreateRemarks { get; set; } = string.Empty;
        public DateTime UpdateTm { get; set; } = DateTime.Parse("1900-01-01");
        public string UpdateBy { get; set; } = string.Empty;
        public string UpdateMarks { get; set; } = string.Empty;
    }
}

