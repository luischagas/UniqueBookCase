using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.CQRS.Commands;

namespace UniqueBookCase.DomainModel.CQRS.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<bool> SendCommand<T>(T comando) where T : Command;
    }
}
