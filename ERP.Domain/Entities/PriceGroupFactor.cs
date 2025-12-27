namespace ERP.Domain.Entities;

public sealed class PriceGroupFactor
{
    // PK: FRAN, TYPE, PRCGRP, NAME, VALUE
    public string Fran { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string PrcGrp { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Value { get; set; } = null!;
    
    public decimal Factor1 { get; set; }
    public decimal Factor2 { get; set; }
    public decimal Factor3 { get; set; }
    
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
