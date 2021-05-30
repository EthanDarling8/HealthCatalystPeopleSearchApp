using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Interests
{
    public class EditModel : PageModel
    {
        private readonly PeopleSearchApp.Data.PeopleSearchAppContext _context;

        public EditModel(PeopleSearchApp.Data.PeopleSearchAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Interest Interest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Interest = await _context.Interest.FirstOrDefaultAsync(m => m.Id == id);

            if (Interest == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Interest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterestExists(Interest.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InterestExists(int id)
        {
            return _context.Interest.Any(e => e.Id == id);
        }
    }
}
