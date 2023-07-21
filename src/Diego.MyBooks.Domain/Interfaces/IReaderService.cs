using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Domain.Notifications;

namespace Diego.MyBooks.Domain.Interfaces;

public interface IReaderService
{
    Task<Reader> Insert(Reader book);
    Task<Reader> Update(Guid id, Reader book);
    Task Delete(Guid id);
}
