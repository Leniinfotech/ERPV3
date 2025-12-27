namespace ERP.Contracts.Orders;

public record PoAllocationDto(
    string Fran,
    string Branch,
    string Warehouse,
    decimal AlocSrl,
    string AlocType,
    DateTime AlocDate,
    string Part,
    string Make,
    string OrdPart,
    decimal Qty,
    decimal UnitPrice,
    decimal NetValue,
    string Status,
    string RefType,
    string RefNo,
    decimal RefSrl,
    string RefSource,
    string StoreId,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreatePoAllocationRequest(
    string Fran,
    string Branch,
    string Warehouse,
    // AlocSrl is IDENTITY - not required in create
    string? AlocType = null,
    DateTime? AlocDate = null,
    string? Part = null,
    string? Make = null,
    string? OrdPart = null,
    decimal? Qty = null,
    decimal? UnitPrice = null,
    decimal? NetValue = null,
    string? Status = null,
    string? RefType = null,
    string? RefNo = null,
    decimal? RefSrl = null,
    string? RefSource = null,
    string? StoreId = null
);

public record UpdatePoAllocationRequest(
    string? AlocType = null,
    DateTime? AlocDate = null,
    string? Part = null,
    string? Make = null,
    string? OrdPart = null,
    decimal? Qty = null,
    decimal? UnitPrice = null,
    decimal? NetValue = null,
    string? Status = null,
    string? RefType = null,
    string? RefNo = null,
    decimal? RefSrl = null,
    string? RefSource = null,
    string? StoreId = null
);
