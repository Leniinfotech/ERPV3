namespace ERP.Domain.Entities;

public sealed class PackingHeader
{
    // Key: { FRAN, BRCH, WHSE, PACKTYPE, PACKNO }
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string PackType { get; set; } = null!;
    public string PackNo { get; set; } = null!;

    public DateOnly PackDate { get; set; }
    public string Customer { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public decimal CurrFactor { get; set; }
    public decimal DespFactor { get; set; }
    public decimal NoOfCrtn { get; set; }
    public decimal GrossValue { get; set; }
    public decimal NetValue { get; set; }
    public decimal NetWeight { get; set; }
    public decimal GrossWeight { get; set; }
    public string SeqPrefix { get; set; } = string.Empty;
    public decimal SeqNo { get; set; }
    public decimal NoOfItems { get; set; }
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

    public ICollection<PackingDetail> Lines { get; set; } = new List<PackingDetail>();
}
