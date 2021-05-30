using System.Collections.Generic;

namespace PeopleSearchApp.Models.Views {
    public class PersonInterestViewModel {
        public Person Person { get; set; }
        public Interest Interest { get; set; }
        public PersonInterest PersonInterest { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<Interest> Interests { get; set; }
    }
}