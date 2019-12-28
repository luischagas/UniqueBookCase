using Microsoft.EntityFrameworkCore;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.Infra.Mappings;

namespace UniqueBookCase.Infra.Context
{
    public class UniqueBookCaseContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public UniqueBookCaseContext(DbContextOptions<UniqueBookCaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorMapping());
            modelBuilder.ApplyConfiguration(new BookMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
