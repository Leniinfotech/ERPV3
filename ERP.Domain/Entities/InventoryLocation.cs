namespace ERP.Domain.Entities;

public sealed class InventoryLocation
{
    // Key = WHSE (string) for now
    public string WarehouseCode { get; set; } = null!;
    public string? Name { get; set; }
    public string? NameAr { get; set; }

    // Required DB columns (NOT NULL) — set via service defaults
    public string Fran { get; set; } = null!;      // FRAN (varchar 10)
    public string Branch { get; set; } = null!;    // BRCH (varchar 10)

    // Audit fields
    public DateOnly CreateDt { get; set; }         // CREATEDT (date)
    public DateTime CreateTm { get; set; }         // CREATETM (datetime)
    public string CreateBy { get; set; } = null!;  // CREATEBY (varchar 10)
    public string CreateRemarks { get; set; } = null!; // CREATEREMARKS (varchar 200)
    public DateOnly UpdateDt { get; set; }         // UPDATEDT (date)
    public DateTime UpdateTm { get; set; }         // UPDATETM (datetime)
    public string UpdateBy { get; set; } = null!;  // UPDATEBY (varchar 10)
    public string UpdateRemarks { get; set; } = null!; // UPDATEMARKS (varchar 200)
}