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
    public class IndexModel : PageModel
    {
        private readonly PeopleSearchApp.Data.PeopleSearchAppContext _context;

        public IndexModel(PeopleSearchApp.Data.PeopleSearchAppContext context)
        {
            _context = context;
        }

        public IList<Interest> Interest { get;set; }

        public async Task OnGetAsync()
        {
            Interest = await _context.Interest.ToListAsync();
        }
    }
}
