namespace ERP.Domain.Entities;

public sealed class Workshop
{
    // PK: FRAN + WORKSHOP
    public string Fran { get; set; } = null!;
    public decimal WorkshopId { get; set; }
    public string Name { get; set; } = string.Empty;

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
