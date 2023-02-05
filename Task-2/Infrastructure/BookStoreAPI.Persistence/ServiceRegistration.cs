using BookStoreAPI.Application.Repositories;
using BookStoreAPI.Application.Services;
using BookStoreAPI.Persistence.Repositories;
using BookStoreAPI.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreAPI.Persistence
{
    public static class ServiceRegistration
    {
        //ioc containera eklenecekler burada extension metot ile tanımlanıp program.cs de çağırılıyor

        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IBookRepository, BookRepository>();
            service.AddScoped<IAuthorRepository, AuthorRepository>();
            service.AddScoped<IGenreRepository, GenreRepository>();

            service.AddScoped(typeof(IService<>), typeof(Service<>));
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<IUserService, UserService>();

        }
    }
}
