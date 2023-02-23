using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Application.Repositories;
using MovieStore.Application.Services;
using MovieStore.Domain.Entities;
using MovieStore.Persistence.Contexts;
using MovieStore.Persistence.Repositories;
using MovieStore.Persistence.Services;

namespace MovieStore.Persistence
{
    public static class ServiceRegistration
    {
        //ioc containera eklenecekler burada extension metot ile tanımlanıp program.cs de çağırılıyor

        public static void AddPersistenceServices(this IServiceCollection service)
        {


            service.AddDbContext<MovieStoreAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            service.AddIdentity<BaseUser, BaseRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<MovieStoreAPIDbContext>()
            .AddDefaultTokenProviders();


            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
           


            service.AddScoped(typeof(IService<>), typeof(Service<>));


            service.AddScoped<IMovieService, MovieService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IActorService, ActorService>();
            service.AddScoped<IDirectorService, DirectorService>();

        }
    }
}
