using ERP.Application.Interfaces.Repositories;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public sealed class UsersService(IUsersRepository repo) : IUsersService
{
    public async Task<IReadOnlyList<UserDto>> GetAllAsync(CancellationToken ct)
        => (await repo.GetAllAsync(ct)).Select(ToDto).ToList();

    public async Task<UserDto?> GetByKeyAsync(string fran, string userId, CancellationToken ct)
    {
        var x = await repo.GetByKeyAsync(fran, userId, ct);
        return x is null ? null : ToDto(x);
    }

    public async Task<UserDto> CreateAsync(CreateUserRequest req, CancellationToken ct)
    {
        var entity = new UserAccount
        {
            Fran = req.Fran,
            UserId = req.UserId,
            Password = req.Password,
            Name = req.Name,
            Email = req.Email,
            EmailGroup = req.EmailGroup,
            Team = req.Team,
            Status = req.Status,
            CreateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            CreateTm = DateTime.UtcNow,
            CreateBy = "api",
            CreateRemarks = string.Empty,
            UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow),
            UpdateTm = DateTime.UtcNow,
            UpdateBy = "api",
            UpdateRemarks = string.Empty,
        };
        await repo.CreateAsync(entity, ct);
        return ToDto(entity);
    }

    public async Task<bool> UpdateAsync(string fran, string userId, UpdateUserRequest req, CancellationToken ct)
    {
        var current = await repo.GetByKeyAsync(fran, userId, ct);
        if (current is null) return false;
        current.Password = req.Password ?? current.Password;
        current.Name = req.Name ?? current.Name;
        current.Email = req.Email ?? current.Email;
        current.EmailGroup = req.EmailGroup ?? current.EmailGroup;
        current.Team = req.Team ?? current.Team;
        current.Status = req.Status ?? current.Status;
        current.UpdateDt = DateOnly.FromDateTime(DateTime.UtcNow);
        current.UpdateTm = DateTime.UtcNow;
        current.UpdateBy = "api";
        await repo.UpdateAsync(current, ct);
        return true;
    }

    public async Task<bool> DeleteAsync(string fran, string userId, CancellationToken ct)
    {
        var exists = await repo.GetByKeyAsync(fran, userId, ct);
        if (exists is null) return false;
        await repo.DeleteAsync(fran, userId, ct);
        return true;
    }

    private static UserDto ToDto(UserAccount x) => new()
    {
        Fran = x.Fran,
        UserId = x.UserId,
        Password = x.Password,
        Name = x.Name,
        Email = x.Email,
        EmailGroup = x.EmailGroup,
        Team = x.Team,
        Status = x.Status
    };
}
