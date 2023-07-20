using Diego.MyBooks.Domain.Models;

namespace Diego.MyBooks.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksByReader(Guid readerId);
    Task<Book> GetBookByNomeAnReaderId(string name, Guid readerId, Guid? id = null);
    Task<Book> GetBookById(Guid id);
    Task Insert(Book book);
    Task Update(Book book);
}
