using DbHomework.Repositories;

namespace DbHomework;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddSingleton<IToDoItemRepository, ToDoItemRepository>()
            .AddOptions<ConnectionStringOptions>()
            .Bind(configuration.GetSection("ConnectionStrings"));

        return serviceCollection;
    }
}
