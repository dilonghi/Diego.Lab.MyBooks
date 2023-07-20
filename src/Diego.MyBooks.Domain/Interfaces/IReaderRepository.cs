using Diego.MyBooks.Domain.Models;

namespace Diego.MyBooks.Domain.Interfaces;

public interface IReaderRepository
{
    Task<Reader> GetReaderByNomeAndEmail(string name, string email, Guid? id = null);
    Task<Reader> GetReaderById(Guid id);
    Task Insert(Reader book);
    Task Update(Reader book);
}
