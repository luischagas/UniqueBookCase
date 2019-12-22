using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniqueBookCase.DomainModel.AuthorAggregate;

namespace UniqueBookCase.Infra.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.ISBN)
               .IsRequired()
               .HasColumnType("varchar(20)");

            builder.Property(p => p.Category)
              .IsRequired()
              .HasColumnType("varchar(40)");

            builder.ToTable("Books");
        }
    }
}