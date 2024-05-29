using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRoleRepository : Repository<UserRoleEntity>, IUserRolesRepository
{
    public UserRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<UserRoleEntity>?> GetRolesByUserId(Guid id)
    {
        return await _dbContext.UserRoles.Where(x => x.UserId == id).ToListAsync();
    }
}