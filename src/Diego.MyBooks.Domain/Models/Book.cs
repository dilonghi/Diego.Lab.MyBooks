using Diego.MyBooks.Domain.Models.Validations;
using Diego.MyBooks.Domain.Models.ValueObjects;

namespace Diego.MyBooks.Domain.Models;

public class Book: Entity
{
    protected Book()
    {
        
    }

    public Book(Guid readerId, string name, string resume, int pages, EFormatBook formatBook)
    {
        Id = Guid.NewGuid();
        ReaderId = readerId;
        Name = name;
        Resume = resume;
        Pages = pages;
        Status = EBookStatus.Unread;
        InsertDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        Deleted = false;

        GetFormatBookIdFromEnum(formatBook);
    }

    public Book(Guid id, Guid readerId, string name, string resume, int pages, EBookStatus status, EFormatBook formatBook)
    {
        Id = id;
        ReaderId = readerId;
        Name = name;
        Resume = resume;
        Pages = pages;
        Status = status;

        GetFormatBookIdFromEnum(formatBook);
    }

    public Guid ReaderId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Resume { get; private set; } = string.Empty;
    public int Pages { get; private set; }
    public EBookStatus Status { get; private set; }
    public DateTime InsertDate { get; private set; }
    public DateTime UpdateDate { get; private set; }
    public Guid FormatBookId { get; private set; }
    public bool Deleted { get; private set; }

    public virtual BookInReading BookInReading{ get; set; }

    public override bool IsInvalid()
    {
        ValidationResult = new BookValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public EFormatBook GetFormatBookEnumFromId(Guid id)
    {
        return id.ToString() switch
        {
            "974a438d-d9dc-405d-9007-414db07af38a" => EFormatBook.Physical,
            "de926090-1117-48e3-ad57-a4c6580f9d7e" => EFormatBook.Kindle,
            "59946ed3-2831-4d15-bef4-00cf7c6653c1" => EFormatBook.EBook,
            "b32e2616-2c85-429b-980c-ec3df6072856" => EFormatBook.WebSite,
        }; 
    }

    private Book GetFormatBookIdFromEnum(EFormatBook formatBook)
    {
        FormatBookId = FormatBooksId(formatBook);
        return this;
    }

    private static Guid FormatBooksId(EFormatBook formatBook)
        => formatBook switch
            {
                EFormatBook.Physical => Guid.Parse("974a438d-d9dc-405d-9007-414db07af38a"),
                EFormatBook.Kindle => Guid.Parse("de926090-1117-48e3-ad57-a4c6580f9d7e"),
                EFormatBook.EBook => Guid.Parse("59946ed3-2831-4d15-bef4-00cf7c6653c1"),
                EFormatBook.WebSite => Guid.Parse("b32e2616-2c85-429b-980c-ec3df6072856"),
                _ => Guid.Parse("66da83fd-4591-4c81-b54d-22f95a7eb74a"),
            };

    public Book SetDeletd()
    {
        Deleted = true;
        UpdateDate = DateTime.Now;
        return this;
    }

    public Book ChangeStatus(EBookStatus status)
    {
        Status = status;
        UpdateDate = DateTime.Now;
        return this;
    }

    
}
