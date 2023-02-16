using Microsoft.Extensions.DependencyInjection;
using MovieStore.Application.Mapping;

namespace BookStoreAPI.Application
{
    public static class ServiceRegistration
    {//ioc containera eklenecekler burada extension metot ile tanımlanıp program.cs de çağırılıyor
        public static void AddApplicationServices(this IServiceCollection service )
        {
            service.AddAutoMapper(typeof(MapProfile));
        }
    }
}
