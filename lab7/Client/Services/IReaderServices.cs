using lab7.Shared;

namespace lab7.Client.Services
{
    public interface IReaderServices
    {
        List<Reader> readers { get; set; }
        Task GetReaders();
        Task<Reader> GetReader(int id);
        Task Create(Reader reader);
        Task Delete(int id);
    }
}
