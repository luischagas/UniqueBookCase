using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.Interfaces.CQRS;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands
{
    public class AuthorCommandHandler :
        IRequestHandler<AddAuthorCommand, bool>,
        IRequestHandler<UpdateAuthorCommand, bool>,
        IRequestHandler<DeleteAuthorCommand, bool>
    {

        private readonly IAuthorService _authorCommands;
        private readonly IQueue _queue;
        private readonly ICacheService _cache;
        private const string key_author = "Author:{id}";

        public AuthorCommandHandler(IAuthorService authorCommands, IQueue queue, ICacheService cache)
        {
            _authorCommands = authorCommands;
            _queue = queue;
            _cache = cache;
        }

        public async Task<bool> Handle(AddAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            //Repository
            await _authorCommands.AddAuthor(message.Author);

            //Queue
            _queue.Enqueue(message);

            //Cache
            var key = key_author.Replace("{id}", message.Author.Id.ToString());

            await _cache.Save(message.Author, key);

            return true;
        }
       
        public async Task<bool> Handle(UpdateAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            //Repository
            await _authorCommands.UpdateAuthor(message.Author);

            //Queue
            _queue.Enqueue(message);

            //Cache
            var key = key_author.Replace("{id}", message.Author.Id.ToString());

            await _cache.Save(message.Author, key);

            return true;
        }

        public async Task<bool> Handle(DeleteAuthorCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            //Repository
            await _authorCommands.DeleteAuthor(message.Author.Id);

            //Queue
            _queue.Enqueue(message);

            var key = key_author.Replace("{id}", message.Author.Id.ToString());

            //Cache
            await _cache.Remove(key);

            return true;
        }

        private bool ValidateCommand(Command message)
        {
            if (message.isValid()) return true;

            return false;
        }
    }
}
