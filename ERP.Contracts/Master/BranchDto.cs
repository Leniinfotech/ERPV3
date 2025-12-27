namespace ERP.Contracts.Master
{
    /// <summary>Represents a Branch (dbo.BRCH).</summary>
    public sealed class BranchDto
    {
        public decimal BranchCode { get; set; }
        public string Fran { get; set; } = string.Empty;
        public string RefNo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
    }
}
