using ToDo.InMemory.Db;
using ToDo.AutoMapper;

namespace ToDo.Api.Configs
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            // Add other service configurations here
            services.AddInMemoryDb();
            services.AddAutoMapperConfig();
            return services;
        }
    }
}
