using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Interests {
    public class IndexModel : PageModel {
        private readonly PeopleSearchApp.Data.PeopleSearchAppContext _context;

        public IndexModel(PeopleSearchApp.Data.PeopleSearchAppContext context) {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public IList<Interest> Interest { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync() {
            var interests = from i in _context.Interest select i;

            if (!string.IsNullOrEmpty(SearchString)) {
                interests = interests.Where(s => s.Name.Contains(SearchString));
            }

            Interest = await interests.ToListAsync();
        }
    }
}