using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Contracts.UniqueKeys;
using ERP.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERP.Application.Services;

public  class AuthorityService: IAuthorityService
{
    private readonly JWT _jwt;
    private readonly IAuthorityRepository _repo;

    public AuthorityService(IAuthorityRepository repo, IOptions<JWT> jwt)
    {
        _repo = repo;
        _jwt = jwt.Value;   // ✔ Correct — because jwt is IOptions<Jwt>
    }

    public async Task<IReadOnlyList<AuthorityDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await _repo.GetAllAsync(ct);
        return items.Select(MapToDto).ToList();
    }

    public async Task<AuthorityDto?> GetByKeyAsync(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct)
    {
        var item = await _repo.GetByKeyAsync(fran, type, userId, menu, subMenu, ct);
        return item is null ? null : MapToDto(item);
    }

    public async Task<AuthorityDto> CreateAsync(
        CreateAuthorityRequest request,
        CancellationToken ct)
    {
        var entity = new Authority
        {
            Fran = request.Fran,
            Type = request.Type,
            UserId = request.UserId,
            Menu = request.Menu,
            SubMenu = request.SubMenu,
            MenuText = request.MenuText ?? string.Empty,
            SubMenuText = request.SubMenuText ?? string.Empty,
            Status = request.Status ?? string.Empty,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "SYSTEM",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = string.Empty,
            UpdateRemarks = string.Empty
        };

        await _repo.AddAsync(entity, ct);

        return MapToDto(entity);
    }

    public async Task<AuthorityDto?> UpdateAsync(
        string fran,
        string type,
        string userId,
        string menu,
        string subMenu,
        UpdateAuthorityRequest request,
        CancellationToken ct)
    {
        var existing = await _repo.GetByKeyAsync(fran, type, userId, menu, subMenu, ct);
        if (existing is null) return null;

        existing.MenuText = request.MenuText ?? existing.MenuText;
        existing.SubMenuText = request.SubMenuText ?? existing.SubMenuText;
        existing.Status = request.Status ?? existing.Status;
        existing.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        existing.UpdateTm = DateTime.UtcNow;
        existing.UpdateBy = "SYSTEM";

        await _repo.UpdateAsync(existing, ct);

        return MapToDto(existing);
    }

    public Task<bool> DeleteAsync(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct)
        => _repo.DeleteAsync(fran, type, userId, menu, subMenu, ct);

    private static AuthorityDto MapToDto(Authority e) => new(
        e.Fran, e.Type, e.UserId, e.Menu, e.SubMenu,
        e.MenuText, e.SubMenuText, e.Status,
        e.CreateDt, e.CreateTm, e.CreateBy);

    public List<string> GetToken(UserDto user)
    {
        if (_jwt == null)
            throw new Exception("JWT configuration is missing");

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, _jwt.Subject),
            new Claim("UserId", user.Name),
            new Claim("UserName", user.Password)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwt.ExpireTime),
            signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new List<string>
        {
            tokenString,
            token.ValidTo.ToString()
        };
    }

}
