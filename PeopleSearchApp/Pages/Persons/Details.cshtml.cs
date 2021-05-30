using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Persons
{
    public class DetailsModel : PageModel
    {
        private readonly PeopleSearchApp.Data.PeopleSearchAppContext _context;

        public DetailsModel(PeopleSearchApp.Data.PeopleSearchAppContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.Id == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
