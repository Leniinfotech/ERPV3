namespace ERP.Domain.Entities;

public sealed class Currency
{
    // DB: dbo.CURRENCY
    public string CurrencyCode { get; set; } = string.Empty; // PK maps to CURRENCY (varchar 10)
    public string BaseCurrency { get; set; } = string.Empty; // varchar 10
    public decimal Factor1 { get; set; } // numeric(22,3)
    public decimal Factor2 { get; set; } // numeric(22,3)
    public decimal DecimalPlace { get; set; } // numeric(22,3)

    // Identity column exists but is not PK
    public decimal Id { get; set; }

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty; // UPDATEMARKS
}
