using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Application.Services;
using BookStoreAPI.Persistence.Repositories;
using BookStoreAPI.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Application.Services;
using MovieStore.Persistence.Services;

namespace BookStoreAPI.Persistence
{
    public static class ServiceRegistration
    {
        //ioc containera eklenecekler burada extension metot ile tanımlanıp program.cs de çağırılıyor

        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        

            service.AddScoped(typeof(IService<>), typeof(Service<>));

            service.AddScoped<IMovieService, MovieService>();
            service.AddScoped<ICustomerService, CustomerService>();

        }
    }
}
