using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Data;

namespace PeopleSearchApp.Models {
    public class InterestPageModel : PageModel {
        public SelectList PersonInterestSl { get; set; }

        public void PopulateInterestDropDownList(PeopleSearchAppContext context, object selectedInterest = null) {
            var interestQuery = from i in context.Interest
                orderby i.Name
                select i;

            PersonInterestSl = new SelectList(interestQuery.AsNoTracking(),
                "Id", "Name", selectedInterest);
        }
    }
}