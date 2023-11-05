using CollaborativeWhiteboard.DataInfrastructure.Repository;

namespace CollaborativeWhiteboard.Web.Extensions;

public static class RepositoryServiceExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        // Add Repository service provider
        services.AddScoped<IWhiteboardRepository, WhiteboardRepository>();
        // More repository services

        // ... any additional data services
        return services;
    }
}
