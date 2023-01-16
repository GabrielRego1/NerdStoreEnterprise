using FluentValidation.Results;
using MediatR;
using NSE.Clientes.WebAPI.Models;
using NSE.Core.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Clientes.WebAPI.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido())
                return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            //validacao de negocio
            if (true)//Ja existe cliente com cpf informado
            {
                AdicionarErro("Este CPF já esta em uso");
                return ValidationResult;
            }

            //persistir no banco


            return message.ValidationResult;
        }
    }
}
