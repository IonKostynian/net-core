using lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lab5.Pages.Persons
{
    public class EditModel : PageModel
    {
        private readonly ReadersContext _context;
        [BindProperty]
        public Person person { get; set; }

        public EditModel(ReadersContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(person).State = EntityState.Modified;
             await _context.SaveChangesAsync();
           
            return RedirectToPage("Index");
        }
    }
}
