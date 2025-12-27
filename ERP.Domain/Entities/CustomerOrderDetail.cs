namespace ERP.Domain.Entities;

public sealed class CustomerOrderDetail
{
    // PK: FRAN, BRCH, WHSE, CORDTYPE, CORDNO, CORDSRL
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string CordType { get; set; } = null!;
    public string CordNo { get; set; } = null!;
    public string CordSrl { get; set; } = null!;
    
    public DateOnly CordDate { get; set; }
    public string Make { get; set; } = string.Empty;
    public decimal Part { get; set; }
    public decimal Qty { get; set; }
    public decimal AccpQty { get; set; }
    public decimal NotAvlQty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal VatPercentage { get; set; }
    public decimal VatValue { get; set; }
    public decimal DiscountValue { get; set; }
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
    
    public CustomerOrderHeader? Header { get; set; }
}
