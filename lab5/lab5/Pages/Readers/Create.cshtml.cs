using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab5.Pages.Readers
{
    public class CreateModel : PageModel
    {
        private readonly ReadersContext _context;
        public Reader reader { get; set; }
        public SelectList PersonsList { get; set; } = null!;
        public SelectList BooksList { get; set; } = null!;
        public CreateModel(ReadersContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            PersonsList = new SelectList(_context.Persons, "Id", "Name");
            BooksList = new SelectList(_context.Books, "Id", "Name");
        }
        public async Task<IActionResult> OnPostAsync(Reader reader)
        {
            if (reader.PersonId != 0 && reader.BookId != 0)
            {
                _context.Readers.Add(reader);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            PersonsList = new SelectList(_context.Persons, "Id", "Name");
            BooksList = new SelectList(_context.Books, "Id", "Name");
            return Page();
        }
    }
}
