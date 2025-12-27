namespace ERP.Domain.Entities;

public sealed class OrderPlanMaster
{
    // PK: FRAN, TYPE, NAME (ID is identity but not used as PK)
    public decimal Id { get; set; }
    public string Fran { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Name { get; set; } = null!;
    
    public string SelectSql { get; set; } = string.Empty;
    public string FilterSql { get; set; } = string.Empty;
    public string GroupBySql { get; set; } = string.Empty;
    public string OrderBySql { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;
}
