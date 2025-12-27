namespace ERP.Domain.Entities;

public sealed class JournalEntryHeader
{
    // PK: FRAN + JOURNELTYPE + JOURNELENTRYID
    public string Fran { get; set; } = null!;
    public string JournalType { get; set; } = null!; // maps to JOURNELTYPE
    public decimal JournalEntryId { get; set; } // numeric(22,0)
    public DateOnly JournalEntryDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;

    // New Columns
    public string AccountCode { get; set; } = string.Empty;
    public string RefCustomer { get; set; } = string.Empty;
    public string RefType { get; set; } = string.Empty;
    public string RefNo { get; set; } = string.Empty;
    public DateTime? RefDt { get; set; }
    public decimal Amount { get; set; }
    public string? PaymentMethod { get; set; }
    public string? CardNumber { get; set; }
    public DateTime? ChequeDt { get; set; }
    public string? Remarks { get; set; }

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;

    public ICollection<JournalEntryLine> Lines { get; set; } = new List<JournalEntryLine>();
}
