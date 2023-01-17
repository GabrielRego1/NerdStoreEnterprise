using FluentValidation;
using NSE.Core.DomainObjects;
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

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Nome do cliente inválido");

            RuleFor(c => c.Cpf)
                .Must(TerCpfValido)
                .WithMessage("Cpf do cliente inválido");

            RuleFor(c => c.Email)
                .Must(TerEmailValido)
                .WithMessage("Email do cliente inválido");
        }
        protected static bool TerCpfValido(string cpf)
        {
            return Cpf.Validar(cpf);
        }

        protected static bool TerEmailValido(string email)
        {
            return Email.Validar(email);
        }
    }
}
