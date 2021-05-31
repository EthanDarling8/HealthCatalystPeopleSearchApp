using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Persons {
    public class EditModel : PageModel {
        private readonly PeopleSearchAppContext _context;
        private readonly IWebHostEnvironment _environment;

        public EditModel(PeopleSearchAppContext context, IWebHostEnvironment environment) {
            _context = context;
            _environment = environment;
        }

        [BindProperty] public Person Person { get; set; }
        [BindProperty] public IFormFile Upload { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) return NotFound();

            Person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);

            if (Person == null) return NotFound();

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Person).State = EntityState.Modified;

            var files = HttpContext.Request.Form.Files;

            var fileUploadBase = new FileUploadBase(_environment, _context);
            await fileUploadBase.Upload(@"images/persons", Person, files);

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!PersonExists(Person.Id)) return NotFound();

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool PersonExists(int id) {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}