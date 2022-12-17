using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.Readers
{
    public class DeleteModel : PageModel
    {
        private readonly ReadersContext _context;
        public Reader reader { get; set; }
        public Person? Person { get; set; }
        public Book? Book { get; set; }
        public DeleteModel(ReadersContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            reader = await _context.Readers.FindAsync(id);

            if (reader == null)
            {
                return NotFound();
            }
            Person = _context.Persons.First(p => p.Id == reader.PersonId);
            Book = _context.Books.First(p => p.Id == reader.BookId);

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
