using Microsoft.Extensions.DependencyInjection;
using ToDo.AutoMapper.Repository;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Mapper;

namespace ToDo.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
               
            });

            services.AddScoped<IToItemDoMapperRepository, ToItemDoMapperRepository>();
            return services;
        }
    }
}
