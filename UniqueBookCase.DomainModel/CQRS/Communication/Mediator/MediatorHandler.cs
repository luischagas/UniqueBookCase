using MediatR;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.CQRS.Commands;
using UniqueBookCase.DomainModel.CQRS.Events;

namespace UniqueBookCase.DomainModel.CQRS.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task<bool> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }
    }
}
