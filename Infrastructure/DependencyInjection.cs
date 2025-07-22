using System.Text;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Infrastructure.Authentication;
using Infrastructure.Authentication.Identity;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.AddAuth(builderConfiguration);


        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static void AddAuth(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        var jwtSettings       = new JwtSettings();
        var dbContextSettings = new DbContextSettings();

        builderConfiguration.Bind(JwtSettings.SectionName, jwtSettings);
        builderConfiguration.Bind(DbContextSettings.SectionName, dbContextSettings);

        services.AddSingleton(Options.Create(dbContextSettings));
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.Configure<JwtSettings>(builderConfiguration.GetSection(JwtSettings.SectionName));
        services.Configure<DbContextSettings>(builderConfiguration.GetSection(DbContextSettings.SectionName));

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(dbContextSettings.DefaultConnection));

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer           = true,
                ValidateAudience         = true,
                ValidateLifetime         = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer              = jwtSettings.Issuer,
                ValidAudience            = jwtSettings.Audience,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });


        services.AddAuthorization();
    }
}