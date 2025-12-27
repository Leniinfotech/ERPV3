namespace ERP.Domain.Entities;

public sealed class Competitor
{
    // PK: COMPETITOR (natural key), ID is identity but not PK
    public decimal Id { get; set; }
    public string CompetitorCode { get; set; } = null!;
    
    public string Name { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string VatNo { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateMarks { get; set; } = string.Empty;
}
