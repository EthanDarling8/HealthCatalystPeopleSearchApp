using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Data {
    public class PeopleSearchAppContext : DbContext {
        public PeopleSearchAppContext(DbContextOptions<PeopleSearchAppContext> options)
            : base(options) {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Interest> Interest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Person>().ToTable(nameof(Person))
                .HasMany(p => p.Interests)
                .WithMany(i => i.Persons);
        }
    }
}