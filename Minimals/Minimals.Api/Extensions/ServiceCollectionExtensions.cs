namespace Minimals.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Description = "This is a minimal .Net 6 API",
                Version = "v1"
            });
        });
        return services;
    }

    public static IServiceCollection AddMinimalsDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MinimalsDbContext>(o =>
        {
            o.UseSqlServer(connectionString);
        });

        return services;
    }
}

