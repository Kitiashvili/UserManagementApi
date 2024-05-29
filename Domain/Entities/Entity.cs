using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public abstract class Entity
{
    [Key]
    public Guid Id { get; private set; }
    
    protected Entity(Guid id) => Id = id;


    public Entity()
    {
        
    }

}