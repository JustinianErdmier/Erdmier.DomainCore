namespace Demo.Core.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        string connectionString = configuration[AppDbContext.ConnectionStringKey]
                                  ?? throw new InvalidOperationException($"Connection string `{AppDbContext.ConnectionStringKey}` not found.");

        services.AddDbContext<AppDbContext>(options =>
        {
            if (environment.IsDevelopment())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }

            options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });

        return services;
    }
}
