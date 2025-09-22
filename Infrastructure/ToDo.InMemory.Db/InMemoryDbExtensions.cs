using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Interfaces;
using ToDo.InMemory.Db.Repository;

namespace ToDo.InMemory.Db
{
    public static class InMemoryDbExtensions
    {
        public static IServiceCollection AddInMemoryDb(this IServiceCollection services)
        {
            services.AddSingleton<IToDoItemRepository,ToDoItemRepository>();

            return services;
        }
    }
}
