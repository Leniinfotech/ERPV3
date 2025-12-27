namespace ERP.Domain.Entities;

public sealed class LoadingAdviceHeader
{
    // PK: FRAN, BRCH, WHSE, LATYPE, LANO
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string LaType { get; set; } = null!;
    public string LaNo { get; set; } = null!;
    
    public DateTime LaDate { get; set; }
    public string InvType { get; set; } = string.Empty;
    public string InvNo { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public decimal SeqNo { get; set; }
    public string Vessel { get; set; } = string.Empty;
    public string PortDest { get; set; } = string.Empty;
    public DateTime Etd { get; set; }
    public DateTime Eta { get; set; }
    public DateTime LoadDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal NoOfCrtn { get; set; }
    public string Remarks { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;
    
    public ICollection<LoadingAdviceDetail> Details { get; set; } = new List<LoadingAdviceDetail>();
}
