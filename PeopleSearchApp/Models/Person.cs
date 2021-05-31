using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleSearchApp.Models {
    public class Person {
        [Key] public int Id { get; set; }

        [Display(Name = "First Name")] public string FirstName { get; set; }

        [Display(Name = "Last Name")] public string LastName { get; set; }

        public int Age { get; set; }
        public string Picture { get; set; }

        [DataType(DataType.MultilineText)] public string Interests { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName => FirstName + " " + LastName;
    }
}