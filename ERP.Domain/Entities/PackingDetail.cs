namespace ERP.Domain.Entities;

public sealed class PackingDetail
{
    // Key: { FRAN, BRCH, WHSE, PACKTYPE, PACKNO, PACKSRL }
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string PackType { get; set; } = null!;
    public string PackNo { get; set; } = null!;
    public decimal PackSrl { get; set; }

    public string Customer { get; set; } = string.Empty;
    public string CrtnType { get; set; } = string.Empty;
    public string Crtn { get; set; } = string.Empty;
    public string MsCrtn { get; set; } = string.Empty;
    public decimal CrtnSrl { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Part { get; set; } = string.Empty;
    public decimal Qty { get; set; }
    public decimal UnitRate { get; set; }
    public decimal NetValue { get; set; }
    public string PickType { get; set; } = string.Empty;
    public decimal PickNo { get; set; }
    public decimal PickSrl { get; set; }
    public string CordType { get; set; } = string.Empty;
    public string CordNo { get; set; } = string.Empty;
    public decimal CordSrl { get; set; }
    public string LotNo { get; set; } = string.Empty;
    public string PdCoo { get; set; } = string.Empty;
    public string PdHsCode { get; set; } = string.Empty;
    public decimal NetWeight { get; set; }
    public decimal GrossWeight { get; set; }
    public decimal UnitNetWeight { get; set; }
    public decimal UnitGrossWeight { get; set; }
    public decimal GrossValue { get; set; }
    public string PdStoreId { get; set; } = string.Empty;
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

    public PackingHeader Header { get; set; } = null!;
}
