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
        private readonly ICacheRepository _cache;
        private readonly IAuthorRepository _authorRepository;
        private const string key_author = "Author:{id}";

        public BookRepository(UniqueBookCaseContext context, ICacheRepository cache, IAuthorRepository authorRepository) : base(context) {
            _cache = cache;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Book>> GetBooksAuthor()
        {
            string key;

            var books = await Db.Books.AsNoTracking()
                .Include(c => c.Author)
                .ToListAsync();

            foreach (Book item in books)
            {
                key = key_author.Replace("{id}", item.AuthorId.ToString());

                var author = await _cache.Get<Author>(key);

                if (author != null)
                {
                  item.Author = author;
                } else 
                {
                  item.Author = await _authorRepository.Read(item.AuthorId);

                  await _cache.Save(item.Author, key);
                }
            }

            return books;

        }
        public async Task<Book> GetBookAuthor(Guid id)
        {
            string key;

            var book = await Db.Books.AsNoTracking()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            key = key_author.Replace("{id}", book.AuthorId.ToString());

            var author = await _cache.Get<Author>(key);

            if (author != null)
            {
                book.Author = author;
            }
            else
            {
                book.Author = await _authorRepository.Read(book.AuthorId);

                await _cache.Save(book.Author, key);
            }

            return book;

        }

    
    }
}
