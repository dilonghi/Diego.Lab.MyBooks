using Diego.MyBooks.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diego.MyBooks.Infra.Data.Context.Mappings;

public class BookInReadingMap : IEntityTypeConfiguration<BookInReading>
{
    public void Configure(EntityTypeBuilder<BookInReading> builder)
    {
        builder.ToTable("BooksInReading");

        builder.HasOne(e => e.Book)
            .WithOne(e => e.BookInReading)
            .HasForeignKey<BookInReading>(e => e.BookId)
            .IsRequired();

    }

}
