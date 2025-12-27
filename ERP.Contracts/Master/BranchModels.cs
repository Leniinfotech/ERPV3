namespace ERP.Contracts.Master
{
    public sealed record CreateBranchRequest(string Fran, string Name, string NameAr, string RefNo);
    public sealed record UpdateBranchRequest(string? Name, string? NameAr, string? RefNo);
}
