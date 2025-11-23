using Domain.Users;
using Framework.Infrastructure.NHibernate.Mappings;

namespace Infrastructure.Data.Mappings.Users;

public class UserMap : AuditedEntityClassMap<User>
{
    public UserMap()
    {
        Id(c => c.Id).GeneratedBy.GuidComb();
        
        Map(c => c.Name).Not.Nullable();
        Map(c => c.Email).Not.Nullable();
        Map(c => c.PasswordHash).Not.Nullable();
    }
}