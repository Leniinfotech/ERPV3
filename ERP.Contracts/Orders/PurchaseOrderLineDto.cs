namespace ERP.Contracts.Orders
{
    /// <summary>Represents a purchase order line.</summary>
    public sealed class PurchaseOrderLineDto
    {
        public string Fran { get; set; } = null!;
        public string Branch { get; set; } = null!;
        public string WarehouseCode { get; set; } = null!;
        public string PoType { get; set; } = null!;
        public string PoNumber { get; set; } = null!;
        public string PoLineNumber { get; set; } = null!;
        /// <summary>ISO date string (yyyy-MM-dd).</summary>
        public string PoDate { get; set; } = null!;
        public string SupplierCode { get; set; } = null!;
        public string? PlanType { get; set; }
        public string? PlanNo { get; set; }
        public long? PlanSerial { get; set; }
        public string? Make { get; set; }
        public string PartCode { get; set; } = null!;
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal VatPercentage { get; set; }
        public decimal VatValue { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalValue { get; set; }
    }
}