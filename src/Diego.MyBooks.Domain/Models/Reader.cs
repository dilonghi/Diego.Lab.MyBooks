using Diego.MyBooks.Domain.Models.Validations;
using Diego.MyBooks.Domain.Models.ValueObjects;
using System.Xml.Linq;


namespace Diego.MyBooks.Domain.Models;

public class Reader : Entity
{
    protected Reader()
    {
        Email = new Email();
    }

    public Reader(string name, string lastName, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastName = lastName;
        Email = new Email(email);
        InsertDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        Status = EReaderStatus.Active;
        Deleted = false;
    }

    public Reader(string name, string lastName, string email, EReaderStatus status)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastName = lastName;
        Email = new Email(email);
        InsertDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        Status = status;
        Deleted = false;
    }


    public string Name { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public Email Email { get; private set; }
    public DateTime InsertDate { get; private set; }
    public DateTime UpdateDate { get; private set; }
    public EReaderStatus Status { get; private set; }
    public bool Deleted { get; private set; }


    public override bool IsValid()
    {
        ValidationResult = new ReaderValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public Reader Update(Guid id, string name, string lastName, Email email, EReaderStatus status)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email; 
        Status =status;
        UpdateDate = DateTime.Now;
        return this;
    }

    public Reader SetDeletd()
    {
        Deleted = true;
        UpdateDate = DateTime.Now;
        return this;
    }
}
