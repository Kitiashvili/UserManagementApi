using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoleRepository : Repository<RoleEntity>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsRoleExistAsync(string name)
    {
        return !await _dbContext.Set<RoleEntity>().AnyAsync(x => x.Name == name);
    }

    public async Task<RoleEntity?> GetRoleByNameAsync(string name)
    {
        return await _dbContext.Set<RoleEntity>().FirstOrDefaultAsync(x => x.Name == name);
    }
}