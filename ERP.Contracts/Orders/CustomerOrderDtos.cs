namespace ERP.Contracts.Orders;

public record CustomerOrderHeaderDto(
    string Fran,
    string Branch,
    string Warehouse,
    string CordType,
    string CordNo,
    DateOnly CordDate,
    string Customer,
    decimal SeqNo,
    string SeqPrefix,
    string Currency,
    decimal NoOfItems,
    decimal DiscountValue,
    decimal GrossValue,
    decimal NetValue,
    decimal VatValue,
    decimal TotalValue,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateCustomerOrderHeaderRequest(
    string Fran,
    string Branch,
    string Warehouse,
    string CordType,
    string CordNo,
    DateOnly? CordDate = null,
    string? Customer = null,
    decimal? SeqNo = null,
    string? SeqPrefix = null,
    string? Currency = null,
    decimal? NoOfItems = null,
    decimal? DiscountValue = null,
    decimal? GrossValue = null,
    decimal? NetValue = null,
    decimal? VatValue = null,
    decimal? TotalValue = null
);

public record UpdateCustomerOrderHeaderRequest(
    DateOnly? CordDate = null,
    string? Customer = null,
    decimal? SeqNo = null,
    string? SeqPrefix = null,
    string? Currency = null,
    decimal? NoOfItems = null,
    decimal? DiscountValue = null,
    decimal? GrossValue = null,
    decimal? NetValue = null,
    decimal? VatValue = null,
    decimal? TotalValue = null
);

public record CustomerOrderDetailDto(
    string Fran,
    string Branch,
    string Warehouse,
    string CordType,
    string CordNo,
    string CordSrl,
    DateOnly CordDate,
    string Make,
    decimal Part,
    decimal Qty,
    decimal AccpQty,
    decimal NotAvlQty,
    decimal Price,
    decimal Discount,
    decimal VatPercentage,
    decimal VatValue,
    decimal DiscountValue,
    decimal TotalValue,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateCustomerOrderDetailRequest(
    string Fran,
    string Branch,
    string Warehouse,
    string CordType,
    string CordNo,
    string CordSrl,
    DateOnly? CordDate = null,
    string? Make = null,
    decimal? Part = null,
    decimal? Qty = null,
    decimal? AccpQty = null,
    decimal? NotAvlQty = null,
    decimal? Price = null,
    decimal? Discount = null,
    decimal? VatPercentage = null,
    decimal? VatValue = null,
    decimal? DiscountValue = null,
    decimal? TotalValue = null
);

public record UpdateCustomerOrderDetailRequest(
    DateOnly? CordDate = null,
    string? Make = null,
    decimal? Part = null,
    decimal? Qty = null,
    decimal? AccpQty = null,
    decimal? NotAvlQty = null,
    decimal? Price = null,
    decimal? Discount = null,
    decimal? VatPercentage = null,
    decimal? VatValue = null,
    decimal? DiscountValue = null,
    decimal? TotalValue = null
);
