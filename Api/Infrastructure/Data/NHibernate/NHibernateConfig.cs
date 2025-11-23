using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infrastructure.Data.Mappings.Users;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Dialect;
using NHibernate.Driver;

public static class NHibernateConfig
{
    private static ISessionFactory _sessionFactory;

    public static ISessionFactory CreateSessionFactory(string connectionString)
    {
        if (_sessionFactory != null)
            return _sessionFactory;

        _sessionFactory = Fluently.Configure()
            .Database(
                PostgreSQLConfiguration.Standard
                    .ConnectionString(connectionString)
                    .Dialect<PostgreSQL82Dialect>()    // <-- USE ESTE
                    .ShowSql()
            )
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
            .ExposeConfiguration(cfg =>
            {
                // 1 — Gera arquivo
                var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schema.sql");
                new SchemaExport(cfg).SetOutputFile(file).Execute(false, false, false);

                // 2 — Atualiza o banco
                new SchemaUpdate(cfg).Execute(false, true);
            })
            .BuildSessionFactory();

        return _sessionFactory;
    }
}