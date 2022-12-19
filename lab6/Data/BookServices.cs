using Microsoft.EntityFrameworkCore;

namespace lab6.Data
{
    public class BookServices : IBookServices
    {
        private readonly ReadersContext _context;
        public BookServices(ReadersContext context)
        {
            _context = context;
        }

        public List<Book> books { get; set; } = new List<Book>();

        public async Task GetBooks()
        {
            books = await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new Exception("No find this book");
            }
            return book;
        }

        public async Task Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Book book, int id)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

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
