using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var db = config.GetSection("Database");
        var connectionString = $"Host={db["Host"]};" +
                               $"Port={db["Port"]};" +
                               $"Database={db["Name"]};" +
                               $"Username={db["User"]};" +
                               $"Password={config["DB_PASSWORD"]}";

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IListRepository, ListRepository>();

        return services;
    }
}
