using keke.Common.Mapping;

namespace keke;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();

        services.AddSwaggerGen();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        return services;
    }
}