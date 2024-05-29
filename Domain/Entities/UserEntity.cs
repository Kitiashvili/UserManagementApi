namespace Domain.Entities;

public class UserEntity : Entity
{
    public string Username { get; private set; }
    public string Email { get; private set; } 
    public string Password { get;private set; }

    public UserEntity(Guid id, string username, string email, string password) : base(id)
    {
        Username = username;
        Email = email;
        Password = password;
    }

    public static UserEntity Create(
        string username,
        string email, 
        string password)
    {
        return new(Guid.NewGuid(), username, email, password);
    }
    
    public void Update( string username, string email)
    {
        // if (!Username.Equals(username) || !Email.Equals(email))
        // {
        //     
        // }

        Username = username;
        email = email;
    }
}