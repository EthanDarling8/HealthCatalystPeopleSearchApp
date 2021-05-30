using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Models;
using PeopleSearchApp.Models.Views;

namespace PeopleSearchApp.Data {
    public class PeopleSearchAppContext : DbContext {
        public PeopleSearchAppContext(DbContextOptions<PeopleSearchAppContext> options)
            : base(options) {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<PersonInterest> PersonInterest { get; set; }
    }
}