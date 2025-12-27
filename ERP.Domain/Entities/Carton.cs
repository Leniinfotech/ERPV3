namespace ERP.Domain.Entities;

public sealed class Carton
{
    // PK: { FRAN, CRTNTYPE, CRTNCATG }
    public string Fran { get; set; } = null!;
    public string CrtnType { get; set; } = null!;
    public string CrtnCatg { get; set; } = null!;

    public decimal Id { get; set; } // not key
    public string CrtnDesc { get; set; } = string.Empty;
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Volume { get; set; }
    public decimal MinWeight { get; set; }
    public decimal MaxWeight { get; set; }

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateMarks { get; set; } = string.Empty;

    public ICollection<CartonDetail> Lines { get; set; } = new List<CartonDetail>();
}
