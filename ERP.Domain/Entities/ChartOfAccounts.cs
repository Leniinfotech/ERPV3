namespace ERP.Domain.Entities;

public sealed class ChartOfAccounts
{
    // PK: FRAN, ACCOUNTTYPE, ACCOUNTCODE
    public string Fran { get; set; } = null!;
    public string AccountType { get; set; } = null!;
    public string AccountCode { get; set; } = null!;
    
    public string AccountName { get; set; } = string.Empty;
    public decimal AccountBalance { get; set; }
    public string Remarks { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateOnly UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateMarks { get; set; } = string.Empty;
}
