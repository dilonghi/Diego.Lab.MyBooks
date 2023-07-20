using Diego.MyBooks.Domain.Interfaces;
using Diego.MyBooks.Domain.Models;

namespace Diego.MyBooks.Domain.Services;

public class ReaderService : BaseService, IReaderService
{
    private readonly IReaderRepository _readerRepository;
    public ReaderService(INotifier notificador, 
        IReaderRepository readerRepository) : base(notificador)
    {
        _readerRepository = readerRepository;
    }



    public async Task Insert(Reader reader)
    {
        if (reader.IsInvalid())
        {
            Notify(reader.ValidationResult);
            return;
        }

        var duplicateReader = await _readerRepository.GetReaderByNomeAndEmail(reader.Name, reader.Email.Address);

        if (duplicateReader is not null)
        {
            Notify("Allready exist a Reader with this Name and Email");
            return;
        }

        await _readerRepository.Insert(reader);
    }

    public async Task Update(Reader reader)
    {
        if (reader.IsInvalid())
        {
            Notify(reader.ValidationResult);
            return;
        }

        var duplicateReader = await _readerRepository.GetReaderByNomeAndEmail(reader.Name, reader.Email.Address, reader.Id);

        if (duplicateReader is not null)
        {
            Notify("Allready exist a Reader with this Name and Email");
            return;
        }

        await _readerRepository.Update(reader);
    }

    public async Task Delete(Guid id)
    {
        var reader = await _readerRepository.GetReaderById(id);

        if (reader is not null)
            await _readerRepository.Delete(reader.SetDeletd());

    }

}
