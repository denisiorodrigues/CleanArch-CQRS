using ClenaArch.Application.Members.Commands.Validations;
using ClenaArch.Domain.Abstraction;
using ClenaArch.Infrastructure.Context;
using ClenaArch.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;

namespace ClenaArch.CrossCutting.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var myConnectinString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(myConnectinString,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new SqliteConnection(myConnectinString);
            connection.Open();
            return connection;
        });

        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

        var myHandlers = AppDomain.CurrentDomain.Load("ClenaArch.Application");
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(myHandlers);
            config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("ClenaArch.Application"));

        return services;
    }
}
