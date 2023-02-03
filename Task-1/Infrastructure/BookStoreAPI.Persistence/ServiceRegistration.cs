using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
