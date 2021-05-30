using System.Collections.Generic;

namespace PeopleSearchApp.Models.Views {
    public class PersonInterestViewModel {
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<Interest> Interests { get; set; }
    }
}