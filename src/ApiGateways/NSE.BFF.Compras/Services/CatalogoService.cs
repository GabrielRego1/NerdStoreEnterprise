using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using NSE.BFF.Compras.Extensions;

namespace NSE.BFF.Compras.Services
{
    public interface ICatalogoService
    {
    }

    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }
    }
}