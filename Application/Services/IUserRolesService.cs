using System.Security.Claims;

namespace Application.Services;

public interface IUserRolesService
{
    Task<List<Claim>> GetUserRolesAsync(Guid id);
}