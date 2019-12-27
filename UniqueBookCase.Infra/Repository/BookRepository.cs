using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.Infra.Context;

namespace UniqueBookCase.Infra.Repository
{
   public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(UniqueBookCaseContext context) : base(context) { }

        public async Task<IEnumerable<Book>> GetBooksAuthor()
        {
            return await Db.Books
                .Include(c => c.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAuthorFromCache(IEnumerable<Author> authors)
        {
            var books = Db.Books;

            foreach (Book item in books)
            {
                item.Author = authors.Where(a => a.Id == item.AuthorId).FirstOrDefault();
            }

            return await books.ToListAsync();

        }

        public async Task<Book> GetBookAuthor(Guid id)
        {
            return await Db.Books
                .Include(c => c.Author)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookAuthorFromCache(Guid id, IEnumerable<Author> authors)
        {
            var book = await Db.Books
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            book.Author = authors.Where(a => a.Id == book.AuthorId).FirstOrDefault();

            return book;

        }
    }
}
