using ERP.Contracts.Master;

namespace ERP.Application.Interfaces.Services;

public interface IAuthorityService
{
    Task<IReadOnlyList<AuthorityDto>> GetAllAsync(CancellationToken ct);
    Task<AuthorityDto?> GetByKeyAsync(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct);
    Task<AuthorityDto> CreateAsync(CreateAuthorityRequest request, CancellationToken ct);
    Task<AuthorityDto?> UpdateAsync(string fran, string type, string userId, string menu, string subMenu, UpdateAuthorityRequest request, CancellationToken ct);
    Task<bool> DeleteAsync(string fran, string type, string userId, string menu, string subMenu, CancellationToken ct);
    List<string> GetToken(UserDto user);
}
