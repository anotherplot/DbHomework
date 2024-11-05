using DbHomework.Repositories;

namespace DbHomework.Configs;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddSingleton<IToDoItemRepository, ToDoItemRepository>()
            .AddOptions<ConnectionStringOptions>()
            .Bind(configuration.GetSection("ConnectionStrings"));
    }
}
