namespace ERP.Domain.Entities;

public sealed class Authority
{
    // PK: FRAN, TYPE, USERID, MENU, SUBMENU
    public string Fran { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Menu { get; set; } = null!;
    public string SubMenu { get; set; } = null!;
    
    public string MenuText { get; set; } = string.Empty;
    public string SubMenuText { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    
    // Audit
    public DateOnly CreateDt { get; set; }
    public DateTime CreateTm { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string CreateRemarks { get; set; } = string.Empty;
    public DateOnly UpdateDt { get; set; }
    public DateTime UpdateTm { get; set; }
    public string UpdateBy { get; set; } = string.Empty;
    public string UpdateRemarks { get; set; } = string.Empty;
}
