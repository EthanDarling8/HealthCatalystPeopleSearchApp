using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearchApp.Data;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Tests {
    [TestClass]
    public class PersonTests {
        public static DbContextOptions<PeopleSearchAppContext> TestDbContextOptions() {
            // Create a new service provider to create a new in-memory database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance using an in-memory database and 
            // IServiceProvider that the context should resolve all of its 
            // services from.
            var builder = new DbContextOptionsBuilder<PeopleSearchAppContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        // Should be successful
        [TestMethod]
        public void TestAddPerson() {
            using (var db = new PeopleSearchAppContext(TestDbContextOptions())) {
                // Arrange
                Person person = new Person() {
                    FirstName = "Ethan",
                    LastName = "Darling",
                    Address1 = "1234",
                    Age = 30,
                    Address2 = "",
                    City = "Salt Lake City",
                    State = "UT",
                    Zip = "84115"
                };

                // Act
                db.Person.Add(person);

                // Assert
                Person result = db.Person.Find(person.Id);
                Assert.AreEqual(person, result);
            }
        }
        
        // should fail 
        [TestMethod]
        public void TestAddDuplicatePerson() {
            using (var db = new PeopleSearchAppContext(TestDbContextOptions())) {
                // Arrange
                Person person = new Person() {
                    FirstName = "Ethan",
                    LastName = "Darling",
                    Address1 = "1234",
                    Age = 30,
                    Address2 = "",
                    City = "Salt Lake City",
                    State = "UT",
                    Zip = "84115"
                };
                
                Person person2 = new Person() {
                    FirstName = "Ethan",
                    LastName = "Darling",
                    Address1 = "1234",
                    Age = 30,
                    Address2 = "",
                    City = "Salt Lake City",
                    State = "UT",
                    Zip = "84115"
                };
                
                // Act, Assert
                db.Person.Add(person);
                Assert.ThrowsException<DbUpdateException>(() => db.Person.Add(person2), 
                    "Attempt to add duplicate person threw an exception.");
            }
        }

        // should fail
        [TestMethod]
        public void TestAddNullPerson() {
            using (var db = new PeopleSearchAppContext(TestDbContextOptions())) {
                // Arrange
                Person person = new Person();
                
                // Act, Assert
                Assert.ThrowsException<DbUpdateException>(() => db.Person.Add(person), 
                    "Attempt to add null person threw an exception.");
            }
        }
    }
}