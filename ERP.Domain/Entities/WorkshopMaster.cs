using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Domain.Entities
{
    public class WorkshopMaster
    {
        public string Fran { get; set; } = string.Empty;
        public string Brch { get; set; } = string.Empty;
        public decimal Workshop { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public DateTime CreateTm { get; set; } = DateTime.Now;
        public string CreateBy { get; set; } = string.Empty;
        public string CreateRemarks { get; set; } = string.Empty;
        public DateTime UpdateTm { get; set; } = DateTime.Parse("1900-01-01");
        public string UpdateBy { get; set; } = "1900-01-01";
        public string UpdateRemarks { get; set; } = string.Empty;
    }
}

