using Application.Contracts;
using Application.Services;
using Domain.Users;
using Framework.Application.Services;
using Framework.Domain.Repositories;
using Framework.Infrastructure.Core;
using Infrastructure.Data.NHibernate;
using Infrastructure.Data.Repositories;
using NHibernate;
using ISession = NHibernate.ISession;


var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// NHibernate Init
string supabaseConn = builder.Configuration.GetConnectionString("Supabase");
SessionProvider.Initialize(supabaseConn);

// Register NHibernate SessionFactory
builder.Services.AddSingleton<ISessionFactory>(sp =>
    SessionProvider.SessionFactory
);

// Session (scoped)
builder.Services.AddScoped<ISession>(sp =>
{
    var factory = sp.GetRequiredService<ISessionFactory>();
    return factory.OpenSession();
});

// Repositories
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

// AppServices
// ❗ Aqui preciso confirmar quantos generics o seu AppService tem!
builder.Services.AddScoped<IUserAppService, UserAppService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        config =>
        {
            config
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();