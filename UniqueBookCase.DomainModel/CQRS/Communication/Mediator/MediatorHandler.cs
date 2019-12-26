using MediatR;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.CQRS.Commands;

namespace UniqueBookCase.DomainModel.CQRS.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }
    }
}
