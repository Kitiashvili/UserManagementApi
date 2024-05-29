using Domain.Entities;

namespace Application.Authentication;

public interface IJwtGenerator
{
    public Task<string> GenerateTokenAsync(UserEntity user);
}