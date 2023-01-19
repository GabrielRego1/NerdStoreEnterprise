using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSE.Clientes.WebAPI.Application.Commands;
using NSE.Clientes.WebAPI.Application.Events;
using NSE.Clientes.WebAPI.Data.Contexts;
using NSE.Clientes.WebAPI.Data.Repositories;
using NSE.Clientes.WebAPI.Models;
using NSE.Clientes.WebAPI.Services;
using NSE.Core.Mediator;

namespace NSE.Clientes.WebAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ClientesContext>();

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}