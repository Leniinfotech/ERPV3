namespace ERP.Contracts.Orders;

public sealed class ShipmentDetailDto
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string WarehouseCode { get; set; } = null!;
    public string ShipmentType { get; set; } = null!;
    public string ShipmentNumber { get; set; } = null!;
    public decimal ShipmentSerial { get; set; }
    public string ShipmentDate { get; set; } = null!;
    public string Vendor { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public string Part { get; set; } = string.Empty;
    public string OrdPart { get; set; } = string.Empty;
    public decimal Qty { get; set; }
    public decimal OrdQty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal VatPercentage { get; set; }
    public decimal VatValue { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal TotalValue { get; set; }
    public string CaseNo { get; set; } = string.Empty;
    public string ContainerNo { get; set; } = string.Empty;
    public string PoType { get; set; } = string.Empty;
    public string PoNo { get; set; } = string.Empty;
    public decimal PoSrl { get; set; }
}

public sealed class CreateShipmentDetailRequest
{
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string WarehouseCode { get; set; } = null!;
    public string ShipmentType { get; set; } = null!;
    public string ShipmentNumber { get; set; } = null!;
    public decimal ShipmentSerial { get; set; }
    public string ShipmentDate { get; set; } = null!;
    public string Vendor { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public string Part { get; set; } = string.Empty;
    public string OrdPart { get; set; } = string.Empty;
    public decimal Qty { get; set; }
    public decimal OrdQty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal VatPercentage { get; set; }
    public decimal VatValue { get; set; }
    public decimal DiscountValue { get; set; }
    public decimal TotalValue { get; set; }
    public string CaseNo { get; set; } = string.Empty;
    public string ContainerNo { get; set; } = string.Empty;
    public string PoType { get; set; } = string.Empty;
    public string PoNo { get; set; } = string.Empty;
    public decimal PoSrl { get; set; }
}

public sealed class UpdateShipmentDetailRequest
{
    public string? ShipmentDate { get; set; }
    public string? Vendor { get; set; }
    public string? Make { get; set; }
    public string? Part { get; set; }
    public string? OrdPart { get; set; }
    public decimal? Qty { get; set; }
    public decimal? OrdQty { get; set; }
    public decimal? UnitPrice { get; set; }
    public decimal? Discount { get; set; }
    public decimal? VatPercentage { get; set; }
    public decimal? VatValue { get; set; }
    public decimal? DiscountValue { get; set; }
    public decimal? TotalValue { get; set; }
    public string? CaseNo { get; set; }
    public string? ContainerNo { get; set; }
    public string? PoType { get; set; }
    public string? PoNo { get; set; }
    public decimal? PoSrl { get; set; }
}
