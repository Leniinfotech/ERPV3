namespace ERP.Domain.Entities;

public sealed class OrderPlanDetail
{
    // PK: FRAN, BRCH, WHSE, PLANTYPE, PLANNO, PLANSRL
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string PlanType { get; set; } = null!;
    public decimal PlanNo { get; set; }
    public decimal PlanSrl { get; set; }
    
    public DateTime PlanDate { get; set; }
    public string Vendor { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public string Part { get; set; } = string.Empty;
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal NetValue { get; set; }
    public decimal SuggQty { get; set; }
    public decimal SuggValue { get; set; }
    public string Currency { get; set; } = string.Empty;
    public decimal OhQty { get; set; }
    public decimal OoQty { get; set; }
    public string PoType { get; set; } = string.Empty;
    public string PoNo { get; set; } = string.Empty;
    public decimal PoSrl { get; set; }
    public string Pmc { get; set; } = string.Empty;
    public string FlagParent { get; set; } = string.Empty;
    public string SubsPart { get; set; } = string.Empty;
    public string FinalPart { get; set; } = string.Empty;
    public string NoReorderCode { get; set; } = string.Empty;
    public string StopSaleCode { get; set; } = string.Empty;
    public string PlanSelection { get; set; } = string.Empty;
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
    
    // Note: No navigation to Header because OPLNHDR.PLANNO is varchar and OPLNDET.PLANNO is numeric
}

