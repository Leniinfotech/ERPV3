namespace ERP.Domain.Entities;

public sealed class Store
{
    // DB: dbo.STORE
    public string Fran { get; set; } = string.Empty; // PK1 (varchar 10)
    public string Branch { get; set; } = string.Empty; // PK2 maps to BRCH (varchar 50)
    public string WarehouseCode { get; set; } = string.Empty; // PK3 maps to WHSE (varchar 10)
    public string StoreCode { get; set; } = string.Empty; // PK4 maps to STORE (varchar 250)
    public string Name { get; set; } = string.Empty; // varchar 250

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty; // CREATEREMARKS (varchar 100)
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty; // UPDATEREMARKS (varchar 100)
}
