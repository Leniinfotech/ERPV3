namespace ERP.Contracts.Master;

public sealed record CreateMakeRequest(string Fran, string MakeCode, string Name, string NameAr);
public sealed record UpdateMakeRequest(string? Name, string? NameAr);
