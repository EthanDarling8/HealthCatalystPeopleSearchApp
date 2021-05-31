using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Persons {
    public class DeleteModel : PageModel {
        private readonly PeopleSearchAppContext _context;
        private readonly IWebHostEnvironment _environment;

        public DeleteModel(PeopleSearchAppContext context, IWebHostEnvironment environment) {
            _context = context;
            _environment = environment;
        }

        [BindProperty] public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) return NotFound();

            Person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);

            if (Person == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null) return NotFound();

            Person = await _context.Person.FindAsync(id);

            if (Person != null) {
                _context.Person.Remove(Person);
                var path = Path.Combine(_environment.WebRootPath, Person.Picture);
                var file = new FileInfo(path);

                if (file.Exists) file.Delete();

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}