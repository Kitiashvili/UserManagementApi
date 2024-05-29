using Application.Authentication;
using Application.Services;
using Domain.Repositories;

namespace Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    
    public AccountService(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public  bool IsValidCredentials(string email, string password)
    {
        var user =  _userRepository.GetByEmailAsync(email);
        if (user.Result != null && !_passwordHasher.Verify(password, user.Result.Password))
            return false;

        return true;
    }

    public bool IsValidCredentials(Guid id, string password)
    {
        var user = _userRepository.GetByIdAsync(id);
        if (user.Result != null && !_passwordHasher.Verify(password, user.Result.Password))
            return false;

        return true;
    }
}