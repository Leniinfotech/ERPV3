namespace ERP.Contracts.Master;

public record AuthorityDto(
    string Fran,
    string Type,
    string UserId,
    string Menu,
    string SubMenu,
    string MenuText,
    string SubMenuText,
    string Status,
    DateOnly CreateDt,
    DateTime CreateTm,
    string CreateBy
);

public record CreateAuthorityRequest(
    string Fran,
    string Type,
    string UserId,
    string Menu,
    string SubMenu,
    string? MenuText = null,
    string? SubMenuText = null,
    string? Status = null
);

public record UpdateAuthorityRequest(
    string? MenuText = null,
    string? SubMenuText = null,
    string? Status = null
);
