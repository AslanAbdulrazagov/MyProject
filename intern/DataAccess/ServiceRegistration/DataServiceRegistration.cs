using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Abstractions;
using DataAccess.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.ServiceRegistration;

public static class DataServiceRegistration
{
    public static IServiceCollection AddDataServices(this IServiceCollection services,IConfiguration configuration)
    {

        AddDbContext(services, configuration);
        AddRepositories(services);


        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;  
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;

            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 3;


        }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        return services;
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
    }
}
