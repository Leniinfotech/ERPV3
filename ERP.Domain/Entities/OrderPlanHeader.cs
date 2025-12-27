namespace ERP.Domain.Entities;

public sealed class OrderPlanHeader
{
    // PK: FRAN, BRCH, WHSE, PLANTYPE, PLANNO
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string PlanType { get; set; } = null!;
    public string PlanNo { get; set; } = null!;
    
    public DateTime PlanDate { get; set; }
    public string TranType { get; set; } = string.Empty;
    public decimal SeqNo { get; set; }
    public decimal NoItems { get; set; }
    public decimal NetValue { get; set; }
    public string PlanSelection { get; set; } = string.Empty;
    public string PlanCalculation { get; set; } = string.Empty;
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
    
    // Note: No navigation to Details because OPLNHDR.PLANNO is varchar and OPLNDET.PLANNO is numeric
}

