namespace ERP.Domain.Entities;

public sealed class PoB2B
{
    // PK: FRAN, BRCH, WHSE, B2BTYPE, B2BNO, B2BSRL
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string B2BType { get; set; } = null!;
    public string B2BNo { get; set; } = null!;
    public decimal B2BSrl { get; set; }
    
    public DateOnly B2BDate { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Part { get; set; } = string.Empty;
    public string? OrdPart { get; set; }
    public decimal Qty { get; set; }
    public decimal OrdQty { get; set; }
    public decimal PoQty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal NetValue { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string RefType { get; set; } = string.Empty;
    public string RefNo { get; set; } = string.Empty;
    public decimal RefSrl { get; set; }
    public decimal UnitPack { get; set; }
    public string PoType { get; set; } = string.Empty;
    public string PoNo { get; set; } = string.Empty;
    public decimal PoSrl { get; set; }
    public string Vendor { get; set; } = string.Empty;
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
