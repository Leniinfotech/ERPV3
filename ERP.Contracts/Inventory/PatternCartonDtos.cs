namespace ERP.Contracts.Inventory;

public record PatternCartonHeaderDto(
    string Fran,
    string Branch,
    string Warehouse,
    string CrtnType,
    string Crtn,
    decimal Length,
    decimal Width,
    decimal Height,
    decimal Volume,
    decimal NetWeight,
    decimal GrossWeight,
    string Customer,
    string PackType,
    string PackNo,
    string Status,
    DateTime CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreatePatternCartonHeaderRequest(
    string Fran,
    string Branch,
    string Warehouse,
    string CrtnType,
    string Crtn,
    decimal? Length = null,
    decimal? Width = null,
    decimal? Height = null,
    decimal? Volume = null,
    decimal? NetWeight = null,
    decimal? GrossWeight = null,
    string? Customer = null,
    string? PackType = null,
    string? PackNo = null,
    string? Status = null
);

public record UpdatePatternCartonHeaderRequest(
    decimal? Length = null,
    decimal? Width = null,
    decimal? Height = null,
    decimal? Volume = null,
    decimal? NetWeight = null,
    decimal? GrossWeight = null,
    string? Customer = null,
    string? PackType = null,
    string? PackNo = null,
    string? Status = null
);
