using lab7.Server.Database;
using lab7.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab7.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly ReadersContext _context;

        public ReaderController(ReadersContext context)
        {
            _context = context;
        }

        public List<Reader> readers { get; set; } = new List<Reader>();

        [HttpGet]
        public async Task GetReaders()
        {
            readers = await _context.Readers.Include(prop => prop.Person).Include(prop => prop.Book).ToListAsync();
        }
        [HttpGet("{id:int}")]
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
        [HttpDelete("{id:int}")]
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
