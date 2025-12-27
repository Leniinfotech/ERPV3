namespace ERP.Domain.Entities;

public sealed class ShipmentDetail
{
    // Key: { FRAN, BRCH, WHSE, SINVTYPE, SINVNO, SINVSRL }
    public string Fran { get; set; } = null!;
    public string Branch { get; set; } = null!;
    public string WarehouseCode { get; set; } = null!;
    public string ShipmentType { get; set; } = null!;
    public string ShipmentNumber { get; set; } = null!;
    public decimal ShipmentSerial { get; set; }

    public DateOnly ShipmentDate { get; set; }
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

    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;

    public Shipment Shipment { get; set; } = null!;
}
