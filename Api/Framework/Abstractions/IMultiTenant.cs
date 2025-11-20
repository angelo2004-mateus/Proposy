namespace Framework.Abstractions;

public interface IMultiTenant
{
    Guid TenantId { get; }
}