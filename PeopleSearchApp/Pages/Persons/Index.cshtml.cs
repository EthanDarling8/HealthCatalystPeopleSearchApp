using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;
using PeopleSearchApp.Models.Views;

namespace PeopleSearchApp.Pages.Persons {
    public class IndexModel : PageModel {
        private readonly PeopleSearchAppContext _context;

        public IndexModel(PeopleSearchAppContext context) {
            _context = context;
        }

        [BindProperty(SupportsGet = true)] public IList<Person> Person { get; set; }
        [BindProperty(SupportsGet = true)] public string SearchString { get; set; }

        public PersonInterestViewModel PersonInterest { get; set; }
        public int PersonId { get; set; }
        public int InterestId { get; set; }

        public async Task OnGetAsync(int? id) {
            var persons = from p in _context.Person select p;

            PersonInterest = new PersonInterestViewModel();
            PersonInterest.Persons = await _context.Person
                .Include(p => p.Interests)
                .OrderBy(p => p.LastName)
                .ToListAsync();
            
            if (id != null) {
                PersonId = id.Value;
                Person person = PersonInterest.Persons
                    .Where(i => i.Id == id.Value).Single();
                PersonInterest.Interests = person.Interests;
            }

            if (!string.IsNullOrEmpty(SearchString)) {
                PersonInterest.Persons = PersonInterest.Persons.Where(s => 
                    s.FirstName.Contains(SearchString)
                    || s.LastName.Contains(SearchString)
                );
            }
        }
    }
}