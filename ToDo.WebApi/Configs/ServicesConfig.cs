using ToDo.InMemory.Db;
using ToDo.AutoMapper;

namespace ToDo.WebApi.Configs
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddDatabaseServicesConfig(this IServiceCollection services)
        {
            // Add other service configurations here
            services.AddInMemoryDb();
            services.AddAutoMapperConfig();
            return services;
        }
    }
}
