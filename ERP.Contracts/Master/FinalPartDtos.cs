namespace ERP.Contracts.Master;

public record FinalPartDto(
    string Fran,
    string Make,
    string Part,
    decimal OhQty,
    decimal OoQty,
    decimal CmSaleQty,
    decimal LmSaleQty,
    decimal M3SaleQty,
    decimal M6SaleQty,
    decimal M12SaleQty,
    decimal M24SaleQty,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateFinalPartRequest(
    string Fran,
    string Make,
    string Part,
    decimal? OhQty = null,
    decimal? OoQty = null,
    decimal? CmSaleQty = null,
    decimal? LmSaleQty = null,
    decimal? M3SaleQty = null,
    decimal? M6SaleQty = null,
    decimal? M12SaleQty = null,
    decimal? M24SaleQty = null
);

public record UpdateFinalPartRequest(
    decimal? OhQty = null,
    decimal? OoQty = null,
    decimal? CmSaleQty = null,
    decimal? LmSaleQty = null,
    decimal? M3SaleQty = null,
    decimal? M6SaleQty = null,
    decimal? M12SaleQty = null,
    decimal? M24SaleQty = null
);
