using System.Security.Claims;
using Application.Services;
using Domain.Repositories;

namespace Infrastructure.Services;

public class UserRolesService : IUserRolesService
{
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository
        ;
    public UserRolesService(IRoleRepository roleRepository, 
        IUserRepository userRepository, 
        IUserRolesRepository userRolesRepository)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _userRolesRepository = userRolesRepository;
    }

    public async Task<List<Claim>> GetUserRolesAsync(Guid id)
    {
        List<Claim> roleClaim = new List<Claim>();
        var userRoles = await _userRolesRepository.GetRolesByUserId(id);
        if (userRoles != null)
        {

            foreach (var role in userRoles)
            {        
                var rolename = await _roleRepository.GetByIdAsync(role.RoleId);
                roleClaim.Add(new Claim(ClaimTypes.Role, rolename.Name));
            }
        }

        return roleClaim;
    }
}