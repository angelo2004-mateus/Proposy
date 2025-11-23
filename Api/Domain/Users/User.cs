using Framework.Domain.Entities;

namespace Domain.Users;

public class User : Audited<Guid>
{
    public virtual string Name { get; set; }
    
    public virtual string Email { get; set; }
    
    public virtual string PasswordHash { get; set; }

    public User()
    {
        
    }
}