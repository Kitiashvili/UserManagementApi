namespace Application.Services;

public interface IAccountService
{
    bool IsValidCredentials(string email, string password);
    bool IsValidCredentials(Guid id, string password);
}