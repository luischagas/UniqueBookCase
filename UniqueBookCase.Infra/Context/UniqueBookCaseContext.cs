using Microsoft.EntityFrameworkCore;
using UniqueBookCase.DomainModel.AuthorAggregate;
using UniqueBookCase.Infra.Mappings;

namespace UniqueBookCase.Infra.Context
{
    public class UniqueBookCaseContext : DbContext
    {
        private static bool _Created = false;
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public UniqueBookCaseContext(DbContextOptions options) : base(options)
        {
            if (!_Created)
            {
                _Created = true;
                Database.EnsureCreated();
            }
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
