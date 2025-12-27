namespace ERP.Domain.Entities;

public sealed class PurchaseOrderLine
{
    // Key: { FRAN, BRCH, WHSE, POTYPE, PONO, POSRL }
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string WarehouseCode { get; set; } = null!;
    public string PoType { get; set; } = null!;
    public string PoNumber { get; set; } = null!;
    public string PoLineNumber { get; set; } = null!; // POSRL

    public DateOnly PoDate { get; set; }
    public string SupplierCode { get; set; } = null!;
    public string? PlanType { get; set; }
    public string? PlanNo { get; set; }
    public decimal? PlanSerial { get; set; }
    public string? Make { get; set; }
    public string PartCode { get; set; } = null!;
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal VatPercentage { get; set; }
    public decimal VatValue { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal TotalValue { get; set; }

    // Audit fields (NOT NULL in DB)
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;

    // Nav
    public PurchaseOrder PurchaseOrder { get; set; } = null!;
    public Part? Part { get; set; }
}