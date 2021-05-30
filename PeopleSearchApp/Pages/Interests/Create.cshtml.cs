using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Interests
{
    public class CreateModel : PageModel
    {
        private readonly PeopleSearchApp.Data.PeopleSearchAppContext _context;

        public CreateModel(PeopleSearchApp.Data.PeopleSearchAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Interest Interest { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Interest.Add(Interest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
