namespace ERP.Contracts.Master;

public sealed record CreateFranchiseRequest(string Fran, string Name, string NameAr);
public sealed record UpdateFranchiseRequest(string? Name, string? NameAr);
