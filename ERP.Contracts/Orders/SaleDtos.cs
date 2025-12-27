namespace ERP.Contracts.Orders;

public sealed class SaleHeaderDto
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string SaleType { get; set; } = null!;
    public string SaleNo { get; set; } = null!;
    public string SaleDate { get; set; } = null!;
    public string CustomerCode { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public decimal NoOfItems { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalValue { get; set; }
}

public sealed class SaleDetailDto
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string SaleType { get; set; } = null!;
    public string SaleNo { get; set; } = null!;
    public string SalesRl { get; set; } = null!;
    public string SaleDate { get; set; } = null!;
    public string Make { get; set; } = string.Empty;
    public decimal Part { get; set; }
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal VatPercentage { get; set; }
    public decimal VatValue { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal TotalValue { get; set; }
}

public sealed class CreateSaleHeaderRequest
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string SaleType { get; set; } = null!;
    public string SaleNo { get; set; } = null!;
    public string SaleDate { get; set; } = null!; // yyyy-MM-dd
    public string CustomerCode { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public decimal NoOfItems { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalValue { get; set; }
}

public sealed class UpdateSaleHeaderRequest
{
    public string? SaleDate { get; set; }
    public string? CustomerCode { get; set; }
    public string? Currency { get; set; }
    public decimal? NoOfItems { get; set; }
    public decimal? Discount { get; set; }
    public decimal? TotalValue { get; set; }
}

public sealed class CreateSaleDetailRequest
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string SaleType { get; set; } = null!;
    public string SaleNo { get; set; } = null!;
    public string SalesRl { get; set; } = null!;
    public string SaleDate { get; set; } = null!;
    public string Make { get; set; } = string.Empty;
    public decimal Part { get; set; }
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal VatPercentage { get; set; }
    public decimal VatValue { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal TotalValue { get; set; }
}

public sealed class UpdateSaleDetailRequest
{
    public string? SaleDate { get; set; }
    public string? Make { get; set; }
    public decimal? Part { get; set; }
    public decimal? Qty { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal? Discount { get; set; }
    public decimal? VatPercentage { get; set; }
    public decimal? VatValue { get; set; }
    public decimal? DiscountValue { get; set; }
    public decimal? TotalValue { get; set; }
}

// Added: Added class for receivable and payable
// Added by: Vaishnavi
// Added on: 15-12-2025


public sealed class SaleReceivablePayableDto
{
    public string Customer { get; set; } = string.Empty;
    public string InvoiceNo { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public DateTime DueDate { get; set; }
    public decimal TotalValue { get; set; }
    public decimal Paid { get; set; }
    public decimal Pending { get; set; }
    public string Status { get; set; } = string.Empty;
}
