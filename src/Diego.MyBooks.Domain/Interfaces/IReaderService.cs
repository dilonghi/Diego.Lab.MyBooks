using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Notifications;

namespace Diego.MyBooks.Domain.Interfaces;

public interface IReaderService
{
    Task Insert(Reader book);
    Task Update(Reader book);
    Task Delete(Guid id);
}
