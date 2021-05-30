using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace PeopleSearchApp.Models {
    public class PersonInterest {
        [Key] public int Id { get; set; }
        
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        [Display(Name = "Person Id")]
        public int PersonId { get; set; }
        
        [ForeignKey("InterestId")]
        public virtual Interest Interest{ get; set; }
        [Display(Name = "Interest Id")]
        public int InterestId { get; set; }
    }
}