namespace ERP.Domain.Entities;

public sealed class PatternCartonHeader
{
    // PK: CHFRAN, CHBRCH, CHWHSE, CHCRTNTYPE, CHCRTN
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string CrtnType { get; set; } = null!;
    public string Crtn { get; set; } = null!;
    
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Volume { get; set; }
    public decimal NetWeight { get; set; }
    public decimal LocnId { get; set; }
    public decimal NoItems { get; set; }
    public decimal TotQty { get; set; }
    public string Customer { get; set; } = string.Empty;
    public string PakGrp { get; set; } = string.Empty;
    public string PackType { get; set; } = string.Empty;
    public string PackNo { get; set; } = string.Empty;
    public string CntrId { get; set; } = string.Empty;
    public string SourType { get; set; } = string.Empty;
    public string SourNo { get; set; } = string.Empty;
    public decimal GrossWeight { get; set; }
    public string CaseMark { get; set; } = string.Empty;
    public string PackIns { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string CrtnCatg { get; set; } = string.Empty;
    public string CrtnPrefix { get; set; } = string.Empty;
    public decimal CrtnSeqNo { get; set; }
    public string ShipCaseMark { get; set; } = string.Empty;
    public decimal KeyInGrossWeight { get; set; }
    public string LaType { get; set; } = string.Empty;
    public string LaNo { get; set; } = string.Empty;
    public string? LotNo { get; set; }
    public string SinvNo { get; set; } = string.Empty;
    public string StoreId { get; set; } = string.Empty;
    public string InvType { get; set; } = string.Empty;
    public string InvNo { get; set; } = string.Empty;
    public string DespStatus { get; set; } = string.Empty;
    
    // Audit
    public DateTime CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateTime UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;
}
