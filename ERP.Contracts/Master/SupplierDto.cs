namespace ERP.Contracts.Master
{
    /// <summary>Represents a Supplier master record.</summary>
    public sealed class SupplierDto
    {
        /// <summary>Supplier business code.</summary>
        public string SupplierCode { get; set; } = null!;
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? VatNo { get; set; }
    }
}