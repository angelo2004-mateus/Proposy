using NHibernate;

namespace Infrastructure.Data.NHibernate;

public class SessionProvider
{
    private static ISessionFactory _factory;

    public static void Initialize(string connectionString)
    {
        _factory = NHibernateConfig.CreateSessionFactory(connectionString);
    }

    public static ISession OpenSession()
    {
        return _factory.OpenSession();
    }
}