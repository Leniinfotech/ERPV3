namespace ERP.Domain.Entities;

public sealed class SubsPart
{
    // PK: FRAN, MAKE, PART, FINLPART, GRPNO
    public string Fran { get; set; } = null!;
    public string Make { get; set; } = null!;
    public string Part { get; set; } = null!;
    public string FinalPart { get; set; } = null!;
    public decimal GrpNo { get; set; }
    
    public decimal PsSubSeq { get; set; }
    
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
