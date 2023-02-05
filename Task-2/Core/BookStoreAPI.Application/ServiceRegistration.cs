using BookStoreAPI.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
