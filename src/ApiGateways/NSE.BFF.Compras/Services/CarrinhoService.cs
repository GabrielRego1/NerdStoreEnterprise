using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using NSE.BFF.Compras.Extensions;

namespace NSE.BFF.Compras.Services
{
    public interface ICarrinhoService
    {
    }

    public class CarrinhoService : Service, ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }
    }
}