namespace ERP.Domain.Entities;

public sealed class FinalPart
{
    // PK: FRAN, MAKE, PART
    public string Fran { get; set; } = null!;
    public string Make { get; set; } = null!;
    public string Part { get; set; } = null!;
    
    public decimal OhQty { get; set; }
    public decimal OoQty { get; set; }
    public decimal CmSaleQty { get; set; }
    public decimal LmSaleQty { get; set; }
    public decimal M3SaleQty { get; set; }
    public decimal M6SaleQty { get; set; }
    public decimal M12SaleQty { get; set; }
    public decimal M24SaleQty { get; set; }
    
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
