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



    public async Task<Reader> Insert(Reader reader)
    {
        if (!reader.IsValid())
        {
            Notify(reader.ValidationResult);
            return reader;
        }

        var duplicateReader = await _readerRepository.GetReaderByNomeAndEmail(reader.Name, reader.Email.Address);

        if (duplicateReader is not null)
        {
            Notify("Allready exist a Reader with this Name and Email");
            return reader;
        }

        await _readerRepository.Insert(reader);

        return reader;
    }

    public async Task<Reader> Update(Guid id, Reader updateReader)
    {
        if (!updateReader.IsValid())
        {
            Notify(updateReader.ValidationResult);
            return updateReader;
        }

        var reader = await _readerRepository.GetReaderById(id);

        if (reader is null)
        {
            Notify("Reader not found");
            return updateReader;
        }

        var duplicateReader = await _readerRepository.GetReaderByNomeAndEmail(updateReader.Name, updateReader.Email.Address, id);

        if (duplicateReader is not null)
        {
            Notify("Allready exist a Reader with this Name and Email");
            return updateReader;
        }

        reader.Update(id, updateReader.Name, updateReader.LastName, updateReader.Email, updateReader.Status);

        await _readerRepository.Update(reader);

        return reader;

    }

    public async Task Delete(Guid id)
    {
        var reader = await _readerRepository.GetReaderById(id);

        if (reader is null)
        {
            Notify("Reader not found");
            return;
        }

        await _readerRepository.Update(reader.SetDeletd());

    }

}
