using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleSearchApp.Models {
    public class Interest {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}