namespace ERP.Contracts.Master;

public record CompetitorDto(
    decimal Id,
    string CompetitorCode,
    string Name,
    string NameAr,
    string Phone,
    string Email,
    string Address,
    string VatNo,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateCompetitorRequest(
    string CompetitorCode,
    string? Name = null,
    string? NameAr = null,
    string? Phone = null,
    string? Email = null,
    string? Address = null,
    string? VatNo = null
);

public record UpdateCompetitorRequest(
    string? Name = null,
    string? NameAr = null,
    string? Phone = null,
    string? Email = null,
    string? Address = null,
    string? VatNo = null
);
