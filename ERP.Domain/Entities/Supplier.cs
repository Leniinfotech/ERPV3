namespace ERP.Domain.Entities;

public sealed class Supplier
{
    // PK: VendorCode (string) → Domain: SupplierCode
    public string SupplierCode { get; set; } = null!;
    public string? Name { get; set; }
    public string? NameAr { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? VatNo { get; set; }

    // Nav
    public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
    public ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}