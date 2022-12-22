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

        public List<Book> books { get; set; } = new List<Book>();

        [HttpGet]
        public async Task GetBooks()
        {
            books = await _context.Books.ToListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<Book> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new Exception("No find this book");
            }
            return book;
        }
        [HttpPost]
        public async Task Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        [HttpPut("{id:int}")]
        public async Task Edit(Book book, int id)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new Exception("No find this book");
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
