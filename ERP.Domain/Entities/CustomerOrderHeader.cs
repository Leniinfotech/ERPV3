namespace ERP.Domain.Entities;

public sealed class CustomerOrderHeader
{
    // PK: FRAN, BRCH, WHSE, CORDTYPE, CORDNO
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string CordType { get; set; } = null!;
    public string CordNo { get; set; } = null!;
    
    public DateOnly CordDate { get; set; }
    public string Customer { get; set; } = string.Empty;
    public decimal SeqNo { get; set; }
    public string SeqPrefix { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public decimal NoOfItems { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal GrossValue { get; set; }
    public decimal NetValue { get; set; }
    public decimal VatValue { get; set; }
    public decimal TotalValue { get; set; }
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;
    
    public ICollection<CustomerOrderDetail> Lines { get; set; } = new List<CustomerOrderDetail>();
}
