using System;
using System.Collections.Generic;
using System.Text;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.DomainModel.CQRS.Commands.BookCommands
{
    public class BookCommand : Command
    {
        public Book Book { get; set; }

        public BookCommand(Book book)
        {
            Book = book;
        }
    }
}
