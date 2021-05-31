using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Pages.Persons {
    public class IndexModel : PageModel {
        private readonly PeopleSearchAppContext _context;

        public IndexModel(PeopleSearchAppContext context) {
            _context = context;
        }

        public IList<Person> Persons { get; set; }
        public int PersonId { get; set; }

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)] public bool DelayedSearch { get; set; }

        public async Task OnGetAsync(int? id) {
            Persons = await _context.Person
                .AsNoTracking()
                .ToListAsync();

            var persons = from p in _context.Person select p;
            if (!string.IsNullOrEmpty(SearchString)) {
                if (DelayedSearch) Thread.Sleep(5000);
                persons = persons.Where(s => s.FirstName.Contains(SearchString) ||
                                             s.LastName.Contains(SearchString));
            }

            if (id != null) PersonId = id.Value;

            Persons = await persons.ToListAsync();
        }
    }
}