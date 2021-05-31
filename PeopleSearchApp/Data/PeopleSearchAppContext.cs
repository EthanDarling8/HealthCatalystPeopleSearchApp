using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Data {
    public class PeopleSearchAppContext : DbContext {
        public PeopleSearchAppContext(DbContextOptions<PeopleSearchAppContext> options)
            : base(options) {
        }

        public DbSet<Person> Person { get; set; }
    }
}