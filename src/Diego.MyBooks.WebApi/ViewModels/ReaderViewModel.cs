using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Models.ValueObjects;

namespace Diego.MyBooks.WebApi.ViewModels;

public class ReaderViewModel
{
    public ReaderViewModel()
    {
            
    }

    public ReaderViewModel(Guid id, string name, string lastName, string email, DateTime insertDate, DateTime updateDate, EReaderStatus status)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        InsertDate = insertDate;
        UpdateDate = updateDate;
        Status = status;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; }
    public DateTime InsertDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public EReaderStatus Status { get; set; }

    public static implicit operator ReaderViewModel(Reader reader)
          => reader is not null
                ? new(reader.Id, reader.Name, reader.LastName, reader.Email.Address, reader.InsertDate, reader.UpdateDate, reader.Status)
                : null;


    public static implicit operator Reader(ReaderViewModel readerViewModel)
          => new(readerViewModel.Name, readerViewModel.LastName, readerViewModel.Email, readerViewModel.Status);

}
