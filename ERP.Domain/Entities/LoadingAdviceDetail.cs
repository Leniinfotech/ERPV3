namespace ERP.Domain.Entities;

public sealed class LoadingAdviceDetail
{
    // PK: FRAN, BRCH, WHSE, LATYPE, LANO, CRTNTYPE, CRTN
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string LaType { get; set; } = null!;
    public string LaNo { get; set; } = null!;
    public string CrtnType { get; set; } = null!;
    public string Crtn { get; set; } = null!;
    
    public DateTime DocDate { get; set; }
    public string CntrNo { get; set; } = string.Empty;
    public DateOnly CntrDate { get; set; }
    public string MsCrtn { get; set; } = string.Empty;
    public string PackType { get; set; } = string.Empty;
    public string PackNo { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public string InvType { get; set; } = string.Empty;
    public string InvNo { get; set; } = string.Empty;
    public string SubInvNo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;
    
    public LoadingAdviceHeader? Header { get; set; }
}
