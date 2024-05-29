namespace Application.Authentication;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string inputPassword, string passwordHash);
}