using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.WebAPI.Application.Commands;
using NSE.Core.Mediator;
using NSE.WebApi.Core.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.WebAPI.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(new RegistrarClienteCommand(Guid.NewGuid(),
                                                                              "Gabriel",
                                                                              "teste123@teste.com",
                                                                              "77563239049"));

            return CustomResponse(resultado);
        }
    }
}
