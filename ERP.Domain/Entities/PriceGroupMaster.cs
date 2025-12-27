namespace ERP.Domain.Entities;

public sealed class PriceGroupMaster
{
    // PK: FRAN, PRCTYPE, PRCGRP
    public string Fran { get; set; } = null!;
    public string PrcType { get; set; } = null!;
    public string PrcGrp { get; set; } = null!;
    
    public string Flag1 { get; set; } = string.Empty;
    public string Flag2 { get; set; } = string.Empty;
    public string Flag3 { get; set; } = string.Empty;
    public decimal Factor1 { get; set; }
    public decimal Factor2 { get; set; }
    public decimal Factor3 { get; set; }
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
}
