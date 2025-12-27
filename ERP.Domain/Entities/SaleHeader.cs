namespace ERP.Domain.Entities;

public sealed class SaleHeader
{
    // PK: FRAN+BRCH+WHSE+SALETYPE+SALENO
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!; // BRCH
    public string Warehouse { get; set; } = null!; // WHSE
    public string SaleType { get; set; } = null!;
    public string SaleNo { get; set; } = null!;

    public DateOnly SaleDate { get; set; }
    public string CustomerCode { get; set; } = string.Empty; // CUSTOMER
    public string Currency { get; set; } = string.Empty;
    public decimal NoOfItems { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalValue { get; set; }
    public decimal SeqNo { get; set; }
    public string SeqPrefix { get; set; } = string.Empty;
    public string SalesChannel { get; set; } = string.Empty;

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;

    // NEW COLUMNS
    public string InvoiceNo { get; set; } = string.Empty;
    public DateOnly InvoiceDate { get; set; }
    public DateTime DueDate { get; set; } 
    public ICollection<SaleDetail> Lines { get; set; } = new List<SaleDetail>();
}
