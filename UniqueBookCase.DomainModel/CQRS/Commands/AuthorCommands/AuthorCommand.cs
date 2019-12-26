using System;
using System.Collections.Generic;
using System.Text;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.AuthorCommands
{
    public abstract class AuthorCommand : Command
    {
        public Author Author { get; set; }

        public AuthorCommand(Author author)
        {
            Author = author;
        }
    }
}
