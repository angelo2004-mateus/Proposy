using FluentNHibernate.Mapping;

namespace Framework.Infrastructure.NHibernate.Mappings.Extensions;

public static class MappingExtensions
{
    public static PropertyPart Indexable(this PropertyPart propertyPart)
    {
        return propertyPart.Index("___indexable");
    }
}