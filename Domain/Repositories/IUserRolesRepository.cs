using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRolesRepository : IRepository<UserRoleEntity>
{
    Task<List<UserRoleEntity>?> GetRolesByUserId(Guid id);
}