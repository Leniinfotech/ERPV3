namespace ERP.Domain.Entities;

public sealed class PurchaseOrder
{
    // Key: { FRAN, BRCH, WHSE, POTYPE, PONO }
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string WarehouseCode { get; set; } = null!;
    public string PoType { get; set; } = null!;
    public string PoNumber { get; set; } = null!;

    public DateOnly PoDate { get; set; }
    public string SupplierCode { get; set; } = null!;
    public string? SupplierRefNo { get; set; }
    public string Currency { get; set; } = null!;
    public decimal NoOfItems { get; set; }
    public decimal Discount { get; set; }
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
    public Supplier Supplier { get; set; } = null!;
    public ICollection<PurchaseOrderLine> Lines { get; set; } = new List<PurchaseOrderLine>();
}