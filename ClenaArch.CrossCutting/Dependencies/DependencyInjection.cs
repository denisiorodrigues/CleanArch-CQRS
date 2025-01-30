using ClenaArch.Domain.Abstraction;
using ClenaArch.Infrastructure.Context;
using ClenaArch.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClenaArch.CrossCutting.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var myConnectinString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(myConnectinString,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
