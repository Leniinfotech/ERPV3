using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface IUsersService
{
    Task<IReadOnlyList<UserDto>> GetAllAsync(CancellationToken ct);
    Task<UserDto?> GetByKeyAsync(string fran, string userId, CancellationToken ct);
    Task<UserDto> CreateAsync(CreateUserRequest req, CancellationToken ct);
    Task<bool> UpdateAsync(string fran, string userId, UpdateUserRequest req, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string userId, CancellationToken ct);
}
