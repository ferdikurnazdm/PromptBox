using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromptBox.Persistence.Context;
using PromptBox.Persistence.Options;

namespace PromptBox.Persistence.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddAppDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var dbSettings = configuration
            .GetSection("DatabaseSettings")
            .Get<DatabaseSettings>();

        if (dbSettings == null)
            throw new InvalidOperationException("DatabaseSettings configuration is missing.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(dbSettings.ConnectionString));

        return services;
    }
}
