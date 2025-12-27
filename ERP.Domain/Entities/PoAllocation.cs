namespace ERP.Domain.Entities;

public sealed class PoAllocation
{
    // PK: FRAN, BRCH, WHSE, ALOCSRL (ALOCSRL is IDENTITY)
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public decimal AlocSrl { get; set; }
    
    public string AlocType { get; set; } = string.Empty;
    public DateTime AlocDate { get; set; }
    public string Part { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public string OrdPart { get; set; } = string.Empty;
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal NetValue { get; set; }
    public string Status { get; set; } = string.Empty;
    public string RefType { get; set; } = string.Empty;
    public string RefNo { get; set; } = string.Empty;
    public decimal RefSrl { get; set; }
    public string RefSource { get; set; } = string.Empty;
    public string StoreId { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;
}
