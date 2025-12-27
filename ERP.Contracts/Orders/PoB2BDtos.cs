namespace ERP.Contracts.Orders;

public record PoB2BDto(
    string Fran,
    string Branch,
    string Warehouse,
    string B2BType,
    string B2BNo,
    decimal B2BSrl,
    DateOnly B2BDate,
    string Make,
    string Part,
    string? OrdPart,
    decimal Qty,
    decimal OrdQty,
    decimal PoQty,
    decimal UnitPrice,
    decimal NetValue,
    string Currency,
    string Customer,
    string Status,
    string Vendor,
    string StoreId,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreatePoB2BRequest(
    string Fran,
    string Branch,
    string Warehouse,
    string B2BType,
    string B2BNo,
    decimal B2BSrl,
    DateOnly? B2BDate = null,
    string? Make = null,
    string? Part = null,
    string? OrdPart = null,
    decimal? Qty = null,
    decimal? OrdQty = null,
    decimal? PoQty = null,
    decimal? UnitPrice = null,
    decimal? NetValue = null,
    string? Currency = null,
    string? Customer = null,
    string? Status = null,
    string? Vendor = null,
    string? StoreId = null
);

public record UpdatePoB2BRequest(
    DateOnly? B2BDate = null,
    string? Make = null,
    string? Part = null,
    string? OrdPart = null,
    decimal? Qty = null,
    decimal? OrdQty = null,
    decimal? PoQty = null,
    decimal? UnitPrice = null,
    decimal? NetValue = null,
    string? Currency = null,
    string? Customer = null,
    string? Status = null,
    string? Vendor = null,
    string? StoreId = null
);
