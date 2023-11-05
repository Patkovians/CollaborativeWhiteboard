using CollaborativeWhiteboard.Core.Interfaces;
using CollaborativeWhiteboard.Core.Services;

namespace CollaborativeWhiteboard.Web.Extensions;

public static class BusinessServiceExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        // Add Business service provider
        services.AddScoped<IWhiteboardService, WhiteboardService>();
        // More Business services

        return services;
    }
}
