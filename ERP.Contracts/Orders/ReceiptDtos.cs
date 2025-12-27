namespace ERP.Contracts.Orders;

public sealed class ReceiptHeaderDto
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string ReceiptType { get; set; } = null!;
    public string ReceiptNo { get; set; } = null!;
    public string ReceiptDate { get; set; } = null!;
    public decimal NoOfItems { get; set; }
    public decimal NetValue { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
    public string SeqPrefix { get; set; } = string.Empty;
    public decimal SeqNo { get; set; }
    public string? Remarks { get; set; }
    public string Status { get; set; } = string.Empty;
}

public sealed class CreateReceiptHeaderRequest
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string ReceiptType { get; set; } = null!;
    public string ReceiptNo { get; set; } = null!;
    public string ReceiptDate { get; set; } = null!; // yyyy-MM-dd
    public decimal NoOfItems { get; set; }
    public decimal NetValue { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
    public string SeqPrefix { get; set; } = string.Empty;
    public decimal SeqNo { get; set; }
    public string? Remarks { get; set; }
    public string Status { get; set; } = string.Empty;
}

public sealed class UpdateReceiptHeaderRequest
{
    public string? ReceiptDate { get; set; }
    public decimal? NoOfItems { get; set; }
    public decimal? NetValue { get; set; }
    public string? Currency { get; set; }
    public string? Vendor { get; set; }
    public string? SeqPrefix { get; set; }
    public decimal? SeqNo { get; set; }
    public string? Remarks { get; set; }
    public string? Status { get; set; }
}

public sealed class ReceiptDetailDto
{
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
}

public sealed class CreateReceiptDetailRequest
{
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
}

public sealed class UpdateReceiptDetailRequest
{
    public string? Make { get; set; }
    public string? Part { get; set; }
    public decimal? Qty { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal? NetValue { get; set; }
    public string? Currency { get; set; }
    public string? StoreId { get; set; }
    public string? Vendor { get; set; }
    public string? PoType { get; set; }
    public string? PoNo { get; set; }
    public decimal? PoSrl { get; set; }
    public string? Remarks { get; set; }
    public string? Status { get; set; }
}
