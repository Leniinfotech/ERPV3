using System;

namespace ERP.Domain.Entities
{
    public class EmployeeMaster
    {
        public string Fran { get; set; } = string.Empty;
        public string Employee { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public DateTime HireDate { get; set; } = DateTime.Parse("1900-01-01");
        public string IsActive { get; set; } = string.Empty;
        public DateTime CreateTm { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public string CreateRemarks { get; set; } = string.Empty;
        public DateTime UpdateTm { get; set; } = DateTime.Parse("1900-01-01");
        public string UpdateBy { get; set; } = string.Empty;
        public string UpdateMarks { get; set; } = string.Empty;
    }
}

