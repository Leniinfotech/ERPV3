namespace ERP.Domain.Entities;

public sealed class JournalEntryLine
{
    // PK: FRAN + JOURNELENTRYID + JOURNELENTRYLINEID
    public string Fran { get; set; } = null!;
    public decimal JournalEntryId { get; set; }
    public decimal JournalEntryLineId { get; set; }

    public decimal AccountCode { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public string Remarks { get; set; } = string.Empty;

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;

    public JournalEntryHeader? Header { get; set; }
}
