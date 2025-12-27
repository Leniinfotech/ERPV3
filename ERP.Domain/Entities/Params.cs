namespace ERP.Domain.Entities;

public sealed class Params
{
    // PK: FRAN, PARAMTYPE, PARAMVALUE (ID is identity but not used as PK)
    public decimal Id { get; set; }
    public string Fran { get; set; } = null!;
    public string ParamType { get; set; } = null!;
    public string ParamValue { get; set; } = null!;
    
    public string ParamValueStr1 { get; set; } = string.Empty;
    public decimal ParamValueNum1 { get; set; }
    public string ParamDesc { get; set; } = string.Empty;
    public string ParamCategory { get; set; } = string.Empty;
    public string ParamRemarks { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateMarks { get; set; } = string.Empty;
}
