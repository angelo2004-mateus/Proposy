using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Data.Mappings.Users;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Infrastructure.Data.NHibernate;

public static class NHibernateConfig
{
    private static ISessionFactory _sessionFactory;

    public static ISessionFactory CreateSessionFactory(string connectionString)
    {
        if (_sessionFactory != null)
        {
            return _sessionFactory;
        }
        
        _sessionFactory = Fluently.Configure()
            .Database(
                PostgreSQLConfiguration.Standard
                    .ConnectionString("Host=52.21.113.96;Port=5432;Database=postgres;Username=postgres;Password=5q3B-%8eR@fVctj;SSL Mode=Require;Trust Server Certificate=true;")
                    .ShowSql()
            )
            .Mappings(c =>
            {
                c.FluentMappings.AddFromAssemblyOf<UserMap>();
            })
            .ExposeConfiguration(cfg =>
            {
                new SchemaUpdate(cfg).Execute(false, true);
            })
            .BuildSessionFactory();
        
        return _sessionFactory;
    }
}