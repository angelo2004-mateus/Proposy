using NHibernate;

namespace Infrastructure.Data.NHibernate;

public static class SessionProvider
{
    private static ISessionFactory _factory;

    public static void Initialize(string connectionString)
    {
        _factory = NHibernateConfig.CreateSessionFactory(connectionString);
    }

    public static ISessionFactory SessionFactory => _factory;

    public static ISession OpenSession()
    {
        return _factory.OpenSession();
    }
}