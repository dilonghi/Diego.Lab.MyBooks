using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Models;
using Diego.MyBooks.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Diego.MyBooks.Infra.Data.Repositories;

public class ReaderRepository : IReaderRepository
{
    protected readonly MyBooksDbContext Db;

    public ReaderRepository(MyBooksDbContext db)
    {
        Db = db;
    }

    public async Task<Reader> GetReaderById(Guid id)
    {
        return await Db.Reader
            .AsNoTracking()
            .Where(x => x.Deleted == false && x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Reader> GetReaderByNomeAndEmail(string name, string email, Guid? id = null)
    {
        if (id == null)
            return await Db.Reader
               .AsNoTracking()
               .Where(x => x.Deleted == false && x.Name == name && x.Email.Address == email)
               .FirstOrDefaultAsync();

        return await Db.Reader
               .AsNoTracking()
               .Where(x => x.Deleted == false && x.Id != id && x.Name == name && x.Email.Address == email)
               .FirstOrDefaultAsync();
    }

    public async Task Insert(Reader reader)
    {
        Db.Reader.Add(reader);
        await SaveChangesAsync();

        Db.Entry(reader).State = EntityState.Detached;
    }


    public async Task Update(Reader reader)
    {
        Db.Reader.Update(reader);
        await SaveChangesAsync();

        Db.Entry(reader).State = EntityState.Detached;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Db.SaveChangesAsync();
    }


}
