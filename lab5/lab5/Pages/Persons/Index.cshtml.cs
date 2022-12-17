using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly ReadersContext _context;

        public IndexModel(ReadersContext context)
        {
            _context = context;
        }
        public List<Person> Persons { get; set; } = null!;
        public void OnGet()
        {
            Persons = _context.Persons.ToList();
        }
    }
}
