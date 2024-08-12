using Business.Abstactions.Helpers;
using Business.Security.JWT;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Business.Validations.AuthValidations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Business.ServiceRegistration;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenHelper, JWTHelper>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining(typeof(RegisterDtoValidation)));



        services.AddAuthentication(opt =>
        {
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configuration["TokenOptions:Issuer"],
                ValidAudience = configuration["TokenOptions:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOptions:SecurityKey"])),
                LifetimeValidator = (_, expired, token, _) => token != null ? expired > DateTime.UtcNow : false


            };
        });

        return services;



    }

}
