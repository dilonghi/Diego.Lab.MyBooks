using Diego.MyBooks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diego.MyBooks.Infra.Data.Context.Mappings;

public class BookMap : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.Ignore(c => c.ValidationResult);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.Property(c => c.Resume)
            .HasColumnType("varchar(500)")
            .IsRequired();

    }

}
