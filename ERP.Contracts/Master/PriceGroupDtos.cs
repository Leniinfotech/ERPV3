namespace ERP.Contracts.Master;

public record PriceGroupMasterDto(
    string Fran,
    string PrcType,
    string PrcGrp,
    string Flag1,
    string Flag2,
    string Flag3,
    decimal Factor1,
    decimal Factor2,
    decimal Factor3,
    string Remarks,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreatePriceGroupMasterRequest(
    string Fran,
    string PrcType,
    string PrcGrp,
    string? Flag1 = null,
    string? Flag2 = null,
    string? Flag3 = null,
    decimal? Factor1 = null,
    decimal? Factor2 = null,
    decimal? Factor3 = null,
    string? Remarks = null
);

public record UpdatePriceGroupMasterRequest(
    string? Flag1 = null,
    string? Flag2 = null,
    string? Flag3 = null,
    decimal? Factor1 = null,
    decimal? Factor2 = null,
    decimal? Factor3 = null,
    string? Remarks = null
);

public record PriceGroupFactorDto(
    string Fran,
    string Type,
    string PrcGrp,
    string Name,
    string Value,
    decimal Factor1,
    decimal Factor2,
    decimal Factor3,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreatePriceGroupFactorRequest(
    string Fran,
    string Type,
    string PrcGrp,
    string Name,
    string Value,
    decimal? Factor1 = null,
    decimal? Factor2 = null,
    decimal? Factor3 = null
);

public record UpdatePriceGroupFactorRequest(
    decimal? Factor1 = null,
    decimal? Factor2 = null,
    decimal? Factor3 = null
);
