using Microsoft.EntityFrameworkCore;

namespace lab6.Data
{
    public class ReaderServices : IReaderServices
    {
        private readonly ReadersContext _context;
        public ReaderServices(ReadersContext context)
        {
            _context = context;
        }

        public List<Reader> readers { get; set; } = new List<Reader>();

        public async Task GetReaders()
        {
            readers = await _context.Readers.Include(prop => prop.Person).Include(prop => prop.Book).ToListAsync();
        }

        public async Task<Reader> GetReader(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
            {
                throw new Exception("No find this reader");
            }
            return reader;
        }

        public async Task Create(Reader reader)
        {
            if (reader.PersonId != 0 && reader.BookId != 0)
            {
                await _context.Readers.AddAsync(reader);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task Delete(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
            {
                throw new Exception("No find this reader");
            }
            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
        }
    }
}
