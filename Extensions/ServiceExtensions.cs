using System.Text;
using EXOPEK_Backend.Application;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Entities.Models;
using EXOPEK_Backend.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;

namespace EXOPEK_Backend.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    
    public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {
        });
    
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();
    
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
    }
    
    public static void ConfigureJwt(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind("JwtSettings", jwtSettings);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.ValidIssuer,
            ValidAudience = jwtSettings.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.AccessTokenSecret)
            )
        };

        services.AddSingleton(tokenValidationParameters);

        services
            .AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.SaveToken = true; // needed for refresh token
                config.TokenValidationParameters = tokenValidationParameters;
            });
    }
    
    public static void ConfigureSqlContext(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var builder = new NpgsqlConnectionStringBuilder();

            if (
                string.IsNullOrWhiteSpace(configuration["POSTGRES_HOST"])
                || string.IsNullOrWhiteSpace(configuration["POSTGRES_DATABASE"])
                || string.IsNullOrWhiteSpace(configuration["POSTGRES_USER"])
                || string.IsNullOrWhiteSpace(configuration["POSTGRES_PASSWORD"])
                ||
                // string.IsNullOrWhiteSpace(configuration["POSTGRES_SSL_MODE"]) ||
                // string.IsNullOrWhiteSpace(configuration["POSTGRES_TRUST_SERVER_CERTIFICATE"]) ||
                !Int32.TryParse(configuration["POSTGRES_PORT"], out int port)
            )
            {
                Console.WriteLine("Using connection string from appsettings.json");
                builder.ConnectionString = configuration.GetConnectionString(
                    "PostgreSqlConnection"
                );
                Console.WriteLine(builder.ConnectionString);
            }
            else
            {
                builder.Host = configuration["POSTGRES_HOST"];
                builder.Database = configuration["POSTGRES_DATABASE"];
                builder.Username = configuration["POSTGRES_USER"];
                builder.Password = configuration["POSTGRES_PASSWORD"];
                builder.SslMode =
                    configuration["POSTGRES_SSL_MODE"] == "Require"
                        ? Npgsql.SslMode.Require
                        : Npgsql.SslMode.Disable;
                if (!string.IsNullOrWhiteSpace(configuration["POSTGRES_TRUST_SERVER_CERTIFICATE"]))
                    builder.TrustServerCertificate = bool.Parse(
                        configuration["POSTGRES_TRUST_SERVER_CERTIFICATE"]
                    );
                
                Console.WriteLine("Using connection string from environment variables");
                Console.WriteLine(builder.ConnectionString);
                builder.Port = port;
            }

            builder.Pooling = true;

            services.AddDbContext<RepositoryContext>(
                options => options.UseNpgsql(builder.ConnectionString)
            );
        }
    
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    
    public static void ConfigureUseCaseManager(this IServiceCollection services) =>
        services.AddScoped<IUseCaseManager, UseCaseManager>();


}