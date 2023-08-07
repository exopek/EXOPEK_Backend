using EXOPEK_Backend.Application;
using EXOPEK_Backend.Contracts.Application;
using EXOPEK_Backend.Contracts.Repository;
using EXOPEK_Backend.Entities;
using EXOPEK_Backend.Repository;
using Microsoft.EntityFrameworkCore;
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
                builder.ConnectionString = configuration.GetConnectionString(
                    "PostgreSqlConnection"
                );
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

                builder.Port = port;
            }

            builder.Pooling = true;

            services.AddDbContext<RepositoryContext>(
                options => options.UseNpgsql(builder.ConnectionString)
            );
        }
    
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();


}