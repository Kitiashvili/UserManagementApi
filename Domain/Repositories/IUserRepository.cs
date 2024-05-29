using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<UserEntity>
{
    Task<bool> IsEmailExistAsync(string email);
    Task<bool> IsUsernameExistAsync(string email);
    Task<UserEntity?> GetByEmailAsync(string email);
}