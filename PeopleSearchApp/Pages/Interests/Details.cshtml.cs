using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Interests
{
    public class DetailsModel : PageModel
    {
        private readonly PeopleSearchApp.Data.PeopleSearchAppContext _context;

        public DetailsModel(PeopleSearchApp.Data.PeopleSearchAppContext context)
        {
            _context = context;
        }

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
    }
}
