
using NashTechRookie.Models;
using NashTechRookie.Services;
using NashTechRookie.Data;

namespace PersonMVC.Test.Services
{
    [TestFixture]
    public class PersonServiceTests
    {
        private PersonService _personService;

        [SetUp]
        public void Setup()
        {
            // Initialize test data
            PersonData.Persons = new List<Person>
            {
                new Person(1, "ABC", "Doe", Gender.Male, new DateTime(1999, 1, 21), "123-654-8799", "New York", true),
                new Person(2, "DEF", "Doe", Gender.Female, new DateTime(2001, 12, 2), "254-367-9801", "Los Angeles", false),
                new Person(3, "GHI", "Smith", Gender.Male, new DateTime(1995, 6, 15), "345-678-1234", "Chicago", true),
                new Person(4, "JKL", "Johnson", Gender.Female, new DateTime(1998, 10, 30), "456-789-2345", "Houston", false),
                new Person(5, "MNO", "Brown", Gender.Male, new DateTime(2000, 7, 18), "567-890-3456", "Phoenix", true),
                new Person(6, "PQR", "Davis", Gender.Female, new DateTime(2002, 3, 5), "678-901-4567", "Philadelphia", false),
                new Person(7, "STU", "Wilson", Gender.Male, new DateTime(1997, 8, 25), "789-012-5678", "San Francisco", true)
            };

            _personService = new PersonService();
        }

        [Test]
        public void GetAll_ReturnsAllPersons()
        {
            // Act
            var result = _personService.GetAll();

            // Assert
            Assert.That(result.Count, Is.EqualTo(7));
        }

        [Test]
        public void GetMales_ReturnsOnlyMalePersons()
        {
            // Act
            var result = _personService.GetMales();

            // Assert
            Assert.That(result.All(p => p.Gender == Gender.Male));
            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]
        public void GetOldestPerson_ReturnsPersonWithEarliestDOB()
        {
            // Act
            var result = _personService.GetOldestPerson();

            // Assert
            Assert.That(result.FullName, Is.EqualTo("GHI Smith"));
        }

        [Test]
        public void GetPersonsFullName_ReturnsAllFullNames()
        {
            // Act
            var result = _personService.GetPersonsFullName();

            // Assert
            var expectedNames = new List<string>
            {
                "ABC Doe",
                "DEF Doe",
                "GHI Smith",
                "JKL Johnson",
                "MNO Brown",
                "PQR Davis",
                "STU Wilson"
            };
            Assert.That(result, Is.EqualTo(expectedNames));
        }

        [TestCase("GREATER", 4)]
        [TestCase("LOWER", 2)]
        [TestCase("EQUAL", 1)]
        [TestCase("INVALID", 0)]
        public void GetPersonsByBirthYearWithAction_ReturnsCorrectPersons(string action, int expectedCount)
        {
            // Act
            var result = _personService.GetPersonsByBirthYearWithAction(action);

            // Assert
            Assert.That(result?.Count() ?? 0, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Create_AddsNewPerson()
        {
            // Arrange
            var newPerson = new Person
            {
                FirstName = "Jane",
                LastName = "Doe",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1992, 2, 2),
                PhoneNumber = "123-456-7890",
                BirthPlace = "Los Angeles",
                IsGraduated = true
            };

            // Act
            var createdPerson = _personService.Create(newPerson);

            // Assert
            Assert.That(createdPerson.Id, Is.EqualTo(8));
            Assert.That(PersonData.Persons.Count, Is.EqualTo(8));
        }

        [Test]
        public void Update_ModifiesExistingPerson()
        {
            // Arrange
            var updatedPerson = new Person
            {
                Id = 1,
                FirstName = "Updated",
                LastName = "Name",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "999-999-9999",
                BirthPlace = "Updated City",
                IsGraduated = false
            };

            // Act
            var result = _personService.Update(updatedPerson);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo("Updated"));
            Assert.That(PersonData.Persons.First(p => p.Id == 1).BirthPlace, Is.EqualTo("Updated City"));
        }

        [Test]
        public void Delete_RemovesPerson()
        {
            // Act
            var deletedPerson = _personService.Delete(1);

            // Assert
            Assert.That(deletedPerson?.Id, Is.EqualTo(1));
            Assert.That(PersonData.Persons.Any(p => p.FullName == deletedPerson.FullName), Is.False);
            Assert.That(PersonData.Persons.Count, Is.EqualTo(6));
        }

        [Test]
        public void GetPersonById_ReturnsCorrectPerson()
        {
            // Act
            var person = _personService.GetPersonById(2);

            // Assert
            Assert.That(person?.FullName, Is.EqualTo("DEF Doe"));
        }

        [Test]
        public void GetLastId_ReturnsHighestId()
        {
            // Act
            var lastId = _personService.GetLastId();

            // Assert
            Assert.That(lastId, Is.EqualTo(7));
        }

        [Test]
        public void ListAll_ReturnsAllPersons()
        {
            // Act
            var allPersons = _personService.ListAll();

            // Assert
            Assert.That(allPersons.Count, Is.EqualTo(7));
        }
    }
}
