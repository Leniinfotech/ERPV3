namespace ERP.Contracts.Inventory;

public sealed class PackingHeaderDto
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string PackType { get; set; } = null!;
    public string PackNo { get; set; } = null!;
    public string PackDate { get; set; } = null!;
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
}

public sealed class CreatePackingHeaderRequest
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string Warehouse { get; set; } = null!;
    public string PackType { get; set; } = null!;
    public string PackNo { get; set; } = null!;
    public string PackDate { get; set; } = null!;
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
}

public sealed class UpdatePackingHeaderRequest
{
    public string? PackDate { get; set; }
    public string? Customer { get; set; }
    public string? Currency { get; set; }
    public decimal? CurrFactor { get; set; }
    public decimal? DespFactor { get; set; }
    public decimal? NoOfCrtn { get; set; }
    public decimal? GrossValue { get; set; }
    public decimal? NetValue { get; set; }
    public decimal? NetWeight { get; set; }
    public decimal? GrossWeight { get; set; }
    public string? SeqPrefix { get; set; }
    public decimal? SeqNo { get; set; }
    public decimal? NoOfItems { get; set; }
    public string? Status { get; set; }
}

public sealed class PackingDetailDto
{
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
}

public sealed class CreatePackingDetailRequest
{
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
}

public sealed class UpdatePackingDetailRequest
{
    public string? Customer { get; set; }
    public string? CrtnType { get; set; }
    public string? Crtn { get; set; }
    public string? MsCrtn { get; set; }
    public decimal? CrtnSrl { get; set; }
    public string? Make { get; set; }
    public string? Part { get; set; }
    public decimal? Qty { get; set; }
    public decimal? UnitRate { get; set; }
    public decimal? NetValue { get; set; }
    public string? PickType { get; set; }
    public decimal? PickNo { get; set; }
    public decimal? PickSrl { get; set; }
    public string? CordType { get; set; }
    public string? CordNo { get; set; }
    public decimal? CordSrl { get; set; }
    public string? LotNo { get; set; }
    public string? PdCoo { get; set; }
    public string? PdHsCode { get; set; }
    public decimal? NetWeight { get; set; }
    public decimal? GrossWeight { get; set; }
    public decimal? UnitNetWeight { get; set; }
    public decimal? UnitGrossWeight { get; set; }
    public decimal? GrossValue { get; set; }
    public string? PdStoreId { get; set; }
    public string? Status { get; set; }
}
