using ToDo.InMemory.Db;

namespace ToDoApi.Configs
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddDatabaseServicesConfig(this IServiceCollection services)
        {
            services.AddInMemoryDb();

            return services;
        }
    }
}
