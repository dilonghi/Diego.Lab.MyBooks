using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Diego.MyBooks.Infra.Data.Context.Mappings;

public class ReaderMap : IEntityTypeConfiguration<Reader>
{
    public void Configure(EntityTypeBuilder<Reader> builder)
    {
        builder.ToTable("Readers");

        builder.Ignore(c => c.ValidationResult);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(120)")
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasColumnType("varchar(120)")
            .IsRequired();
        
        builder.OwnsOne(c => c.Email, email =>
        {
            email.Property(c => c.Address)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");
        });
    }

}
