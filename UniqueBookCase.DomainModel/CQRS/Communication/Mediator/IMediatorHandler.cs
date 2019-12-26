using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.CQRS.Commands;
using UniqueBookCase.DomainModel.CQRS.Events;

namespace UniqueBookCase.DomainModel.CQRS.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;

        Task<bool> SendCommand<T>(T comando) where T : Command;
    }
}
