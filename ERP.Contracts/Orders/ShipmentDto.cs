namespace ERP.Contracts.Orders
{
    /// <summary>Represents a shipment (sales invoice header).</summary>
    public sealed class ShipmentDto
    {
        public string Fran { get; set; } = null!;
        public string Branch { get; set; } = null!;
        public string WarehouseCode { get; set; } = null!;
        public string ShipmentType { get; set; } = null!;
        public string ShipmentNumber { get; set; } = null!;
        /// <summary>ISO date string (yyyy-MM-dd).</summary>
        public string ShipmentDate { get; set; } = null!;
        public string SupplierCode { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public string? BlNumber { get; set; }
        public string? BlDate { get; set; }
        public string? BuyerCode { get; set; }
        public string? ShippingStatus { get; set; }
        public string? ShipCompanyCode { get; set; }
    }
}