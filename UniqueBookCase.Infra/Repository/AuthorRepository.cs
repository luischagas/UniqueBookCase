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
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(UniqueBookCaseContext context) : base(context) { }

        public async Task<IEnumerable<Author>> GetAuthorBooks()
        {
            return await Db.Authors
                .Include(c => c.Books)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorBook(Guid id)
        {
            return await Db.Authors
                .Include(c => c.Books)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

    }
}
