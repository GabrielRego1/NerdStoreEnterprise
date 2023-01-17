using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Clientes.WebAPI.Application.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
    {
        public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            //Enviar evento de confirmacao
            return Task.CompletedTask;
        }
    }
}
