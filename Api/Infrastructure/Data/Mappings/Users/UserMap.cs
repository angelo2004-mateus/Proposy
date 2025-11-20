using Domain.Users;
using FluentNHibernate.Mapping;

namespace Infrastructure.Data.Mappings.Users;

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        Id(c => c.Id).GeneratedBy.GuidComb();
        
        Map(c => c.Name).Not.Nullable();
        Map(c => c.Email).Not.Nullable();
        Map(c => c.PasswordHash).Not.Nullable();
    }
}