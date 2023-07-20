using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Models.ValueObjects;

namespace Diego.MyBooks.Domain.Interfaces;

public interface IBookService
{
    Task Insert(Book book);
    Task UpdateInfo(Book book);
    Task UpdateStatus(Guid bookId, EBookStatus status);
    Task Delete(Guid id);

}
