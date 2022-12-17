using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.Readers
{
    public class IndexModel : PageModel
    {
        private readonly ReadersContext _context;

        public IndexModel(ReadersContext context)
        {
            _context = context;
        }
        public List<Reader> Readers { get; set; } = null!;
        public void OnGet()
        {
            Readers = _context.Readers.Include(prop => prop.Person).Include(prop => prop.Book).ToList();
        }
    }
}
