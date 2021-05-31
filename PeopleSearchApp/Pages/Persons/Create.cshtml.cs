using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Persons {
    public class CreateModel : PageModel {
        private readonly PeopleSearchAppContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(PeopleSearchAppContext context, IWebHostEnvironment environment) {
            _context = context;
            _environment = environment;
        }

        [BindProperty] public Person Person { get; set; }

        public IActionResult OnGet() {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) return Page();

            var files = HttpContext.Request.Form.Files;

            var fileUploadBase = new FileUploadBase(_environment, _context);
            await fileUploadBase.Upload(@"images/persons", Person, files);

            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}