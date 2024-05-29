using Domain.Entities;

namespace Domain.Repositories;

public interface IRoleRepository : IRepository<RoleEntity>
{
    Task<bool> IsRoleExistAsync(string name);
    Task<RoleEntity?> GetRoleByNameAsync(string name);
}