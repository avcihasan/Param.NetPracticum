using Microsoft.Extensions.DependencyInjection;
using MovieStore.Application.Services;
using MovieStore.Infrastructure.Services.TokenServices;

namespace MovieStore.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection service)
        {
            service.AddScoped<ITokenHandler, TokenHandler>();

        }
    }
}
