using NashTechRookie.Data;
using NashTechRookie.Utils;
using NashTechRookie.Models;

namespace NashTechRookie.Services
{
    public class PersonService : IPersonService, IPerson
    {

        public List<Person> GetAll()
        {
            return PersonData.Persons.ToList();
        }

        public IEnumerable<Person> GetMales()
        {
            var malePersons = PersonData.Persons.Where(mp => mp.Gender == Gender.Male);

            return malePersons;
        }

        public Person GetOldestPerson()
        {
            var oldestPerson = PersonData.Persons.OrderByDescending(p => p.DateOfBirth).First();

            return oldestPerson;
        }

        public IEnumerable<string> GetPersonsFullName()
        {
            var fullNames = PersonData.Persons.Select(p => p.FullName);

            return fullNames;
        }

        public IEnumerable<Person>? GetPersonsByBirthYearWithAction(string action)
        {
            return action.ToUpper() switch
            {
                "GREATER" => PersonData.Persons.Where(p => p.DateOfBirth.Year < 2000),
                "LOWER" => PersonData.Persons.Where(p => p.DateOfBirth.Year > 2000),
                "EQUAL" => PersonData.Persons.Where(p => p.DateOfBirth.Year == 2000),
                _ => null
            };
        }

        public FileModel ExportToExcel()
        {
            var personToExcel = PersonData.Persons.ToList();
            var fileContent = FileHelper<Person>.GenerateExcelFile(personToExcel);
            var fileName = $"Persons_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            return new FileModel(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        public void Create(Person person)
        {
            // Assign a new ID (if your data source doesn’t handle this automatically)
            person.Id = PersonData.Persons.Any() ? PersonData.Persons.Max(p => p.Id) + 1 : 1;
            PersonData.Persons.Add(person);
        }

        public void Update(Person person)
        {
            Console.WriteLine("Update method called");
            var personToUpdate = PersonData.Persons.SingleOrDefault(p => p.Id == person.Id);
            if (personToUpdate != null)
            {
                PersonData.Persons = PersonData.Persons.Select(p =>
                    p.Id == person.Id ? person : p).ToList();
            }

            return;
        }

        public void Delete(Person person)
        {
            PersonData.Persons = PersonData.Persons.Where(p => p.Id != person.Id).ToList();

            return;
        }

        public List<Person> ListAll()
        {
            return PersonData.Persons.ToList();
        }

        public int GetLastId()
        {
            return PersonData.Persons.Any() ? PersonData.Persons.Max(p => p.Id) : 0;
        }
    }
}