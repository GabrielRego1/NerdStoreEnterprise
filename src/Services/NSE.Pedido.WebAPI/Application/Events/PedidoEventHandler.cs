using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NSE.MessageBus;

namespace NSE.Pedidos.WebAPI.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        private readonly IMessageBus _bus;

        public PedidoEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(PedidoRealizadoEvent message, CancellationToken cancellationToken)
        {
        }
    }
}
