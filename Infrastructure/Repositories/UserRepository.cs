using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : Repository<UserEntity>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsEmailExistAsync(string email)
    {
        return await _dbContext.Set<UserEntity>().AnyAsync(x => x.Email == email);
    }

    public async Task<bool> IsUsernameExistAsync(string username)
    {
        return await _dbContext.Set<UserEntity>().AnyAsync(x => x.Username == username);
    }

    public async Task<UserEntity?> GetByEmailAsync(string email)
    {
        return await _dbContext.Set<UserEntity>().FirstOrDefaultAsync(x => x.Email == email);

    }
}