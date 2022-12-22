using Microsoft.Extensions.DependencyInjection;
using NSE.Catalogo.WebAPI.Data.Contexts;
using NSE.Catalogo.WebAPI.Data.Repositories;
using NSE.Catalogo.WebAPI.Models;

namespace NSE.Catalogo.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}
