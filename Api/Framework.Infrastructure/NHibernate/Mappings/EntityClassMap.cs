using FluentNHibernate.Mapping;

namespace Framework.Infrastructure.NHibernate.Mappings;

public class EntityClassMap<T> : ClassMap<T>
{
    protected EntityClassMap()
    { }
}