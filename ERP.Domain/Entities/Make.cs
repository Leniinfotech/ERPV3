namespace ERP.Domain.Entities;

public sealed class Make
{
    // DB: dbo.MAKE
    public string Fran { get; set; } = string.Empty; // PK1 (varchar 10)
    public string MakeCode { get; set; } = string.Empty; // PK2 maps to MAKE (varchar 10)
    public string Name { get; set; } = string.Empty; // varchar 100
    public string NameAr { get; set; } = string.Empty; // nvarchar 100

    // Identity column exists but not PK
    public decimal Id { get; set; }

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty; // UPDATEREMARKS
}
