namespace Domain.Entities;

public class RoleEntity : Entity
{
    public string Name { get; private set; }

    private RoleEntity(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public static RoleEntity Create(string name)
    {
        return new(Guid.NewGuid(), name);
    }
    
    private RoleEntity()
    {
        
    }
}