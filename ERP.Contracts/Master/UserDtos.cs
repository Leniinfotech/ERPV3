namespace ERP.Contracts.Master;

public sealed class UserDto
{
    public string Fran { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string EmailGroup { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public sealed class CreateUserRequest
{
    public string Fran { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string EmailGroup { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public sealed class UpdateUserRequest
{
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? EmailGroup { get; set; }
    public string? Team { get; set; }
    public string? Status { get; set; }
}
