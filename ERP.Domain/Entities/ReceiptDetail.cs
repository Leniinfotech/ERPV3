namespace ERP.Domain.Entities;

public sealed class ReceiptDetail
{
    // Key: { FRAN, BRCH, WHSE, RECTTYPE, RECTNO, RECTSRL }
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string ReceiptType { get; set; } = null!;
    public string ReceiptNo { get; set; } = null!;
    public decimal ReceiptSerial { get; set; }

    public string Make { get; set; } = string.Empty;
    public string Part { get; set; } = null!;
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal NetValue { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string StoreId { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
    public string PoType { get; set; } = string.Empty;
    public string PoNo { get; set; } = string.Empty;
    public decimal PoSrl { get; set; }
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

    public ReceiptHeader Header { get; set; } = null!;
}
