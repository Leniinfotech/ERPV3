namespace ERP.Domain.Entities;

public sealed class ReceiptHeader
{
    // Key: { FRAN, BRCH, WHSE, RECTTYPE, RECTNO }
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string ReceiptType { get; set; } = null!;
    public string ReceiptNo { get; set; } = null!;

    public DateOnly ReceiptDate { get; set; }
    public decimal NoOfItems { get; set; }
    public decimal NetValue { get; set; }
    public string Currency { get; set; } = null!;
    public string Vendor { get; set; } = null!;
    public string SeqPrefix { get; set; } = string.Empty;
    public decimal SeqNo { get; set; }
    public string? Remarks { get; set; }
    public string Status { get; set; } = string.Empty;

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;

    public ICollection<ReceiptDetail> Lines { get; set; } = new List<ReceiptDetail>();
}
