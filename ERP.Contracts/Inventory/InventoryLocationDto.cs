namespace ERP.Contracts.Inventory
{
    /// <summary>Represents an inventory location (warehouse).</summary>
    public sealed class InventoryLocationDto
    {
        public string WarehouseCode { get; set; } = null!;
        public string? Name { get; set; }
        public string? NameAr { get; set; }
    }
}