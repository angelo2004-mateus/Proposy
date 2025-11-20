using Framework.Abstractions;

namespace Domain.Users;

public class User : Entity<Guid>//, IHasCreationTime
{
    public virtual string Name { get; set; }
    
    public virtual string Email { get; set; }
    
    public virtual string PasswordHash { get; set; }
    
   // public virtual DateTime CreationTime { get; set; }
}