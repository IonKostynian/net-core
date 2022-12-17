using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ReadersContext _context;

        public IndexModel(ReadersContext context)
        {
            _context = context;
        }
        public List<Book> Books { get; set; } = null!;
        public void OnGet()
        {
            Books = _context.Books.ToList();
        }
    }
}
