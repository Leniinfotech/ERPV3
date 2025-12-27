namespace ERP.Domain.Entities;

public sealed class UserAccount
{
    // PK: FRAN + USERID
    public string Fran { get; set; } = null!;
    public string UserId { get; set; } = null!;

    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string EmailGroup { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;
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
