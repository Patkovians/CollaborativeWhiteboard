using CollaborativeWhiteboard.DataInfrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace CollaborativeWhiteboard.Web.Extensions;

public static class DatabaseServiceExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext using SQL Server Provider
        services.AddDbContext<WhiteboardDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // ... any additional data services

        return services;
    }
}
