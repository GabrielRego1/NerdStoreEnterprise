using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.Carrinho.WebAPI.Services;
using NSE.Core.Utils;
using NSE.MessageBus;


namespace NSE.Carrinho.WebAPI.Configurations
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                    .AddHostedService<CarrinhoIntegrationHandler>();
        }
    }
}
