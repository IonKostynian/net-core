using lab7.Server.Database;
using lab7.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab7.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ReadersContext _context;

        public BookController(ReadersContext context)
        {
            _context = context;
        }
      //  public List<Book> books { get; set; } = new List<Book>();

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _context.Books.FirstAsync(p => p.Id == id);
        }

        [HttpPost]
        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task EditBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteBook(int id)
        {
            _context.Books.Remove(await _context.Books.FirstAsync(p => p.Id == id));
            await _context.SaveChangesAsync();
        }
    }
}
