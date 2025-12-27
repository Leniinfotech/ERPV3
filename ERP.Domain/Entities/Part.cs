namespace ERP.Domain.Entities;

public sealed class Part
{
    // PK: PART (string; len 28) → Domain: PartCode
    public string PartCode { get; set; } = null!;
    public string? Description { get; set; }
    public string? Make { get; set; }
    public string? StockKey { get; set; }
    public string? Barcode { get; set; }
    public string? SubsPart { get; set; }
    public string? FinalPart { get; set; }
    public string? InvClass { get; set; }
    public string? Category { get; set; }
    public string? Group { get; set; }
    public string? CountryOfOrigin { get; set; }
    public decimal Lc { get; set; }
    public decimal Fob { get; set; }
    public decimal NetWeight { get; set; }
    public decimal Stock { get; set; }
    public decimal Cmsale { get; set; }
    public decimal Lmsale { get; set; }
    public decimal M3sale { get; set; }
    public decimal M6sale { get; set; }
    public decimal M12sale { get; set; }
    public decimal Avgm6 { get; set; }
    public bool Active { get; set; }

    // Added: Added additional columns
    // Added by: Vaishnavi
    // Added on: 10-12-2025
    public decimal Id { get; set; }
    public string Fran { get; set; } = null!;
    public DateTime Createdt { get; set; }
    public string Createby { get; set; } = null!;
    public string? Createremarks { get; set; }
    public DateTime Updatedt { get; set; }
    public string Updateby { get; set; } = null!;
    public string? Updatemarks { get; set; }

    // Nav
    public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();
}