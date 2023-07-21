using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Models.ValueObjects;

namespace Diego.MyBooks.Domain.Interfaces;

public interface IBookService
{
    Task<Book> Insert(Book book);
    Task<Book> UpdateInfo(Guid bookId, Book book);
    Task UpdateStatus(Guid bookId, EBookStatus status);
    Task Delete(Guid id);

}
