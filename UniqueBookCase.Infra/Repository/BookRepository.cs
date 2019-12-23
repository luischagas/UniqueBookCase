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
            return await Db.Books.AsNoTracking()
                .Include(c => c.Author)
                .ToListAsync();
        }

        public async Task<Book> GetBookAuthor(Guid id)
        {
            return await Db.Books.AsNoTracking()
                .Include(c => c.Author)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
