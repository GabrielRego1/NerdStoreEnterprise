using Microsoft.Extensions.DependencyInjection;
using NSE.Clientes.WebAPI.Data.Contexts;

namespace NSE.Clientes.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ClientessContext>();
        }
    }
}