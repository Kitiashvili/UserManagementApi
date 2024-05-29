namespace Domain.Entities;

public class UserRoleEntity : Entity
{
    public Guid UserId { get; private set; }
    public Guid RoleId { get; private set; }

    public UserRoleEntity(Guid id, Guid userId, Guid roleId) : base(id)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public static UserRoleEntity Create(
        Guid userId, Guid roleId)
    {
        return new(Guid.NewGuid(), userId, roleId);
    }
}