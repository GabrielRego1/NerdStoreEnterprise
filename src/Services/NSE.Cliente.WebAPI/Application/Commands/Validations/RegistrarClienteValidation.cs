using FluentValidation;
using System;

namespace NSE.Clientes.WebAPI.Application.Commands.Validations
{
    public class RegistrarClienteValidation : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");
        }
    }
}
