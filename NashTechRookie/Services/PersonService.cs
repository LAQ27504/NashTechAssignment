using NashTechRookie.Data;
using NashTechRookie.Utils;
using NashTechRookie.Models;

namespace NashTechRookie.Services
{
    public class PersonService : IPersonService
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
            var oldestPerson = PersonData.Persons.OrderBy(p => p.DateOfBirth).First();

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

        public Person Create(Person person)
        {
            // Assign a new ID (if your data source doesn’t handle this automatically)
            person.Id = PersonData.Persons.Any() ? PersonData.Persons.Max(p => p.Id) + 1 : 1;
            PersonData.Persons.Add(person);
            return person;
        }

        public Person Update(Person person)
        {
            var personToUpdate = PersonData.Persons.SingleOrDefault(p => p.Id == person.Id);
            if (personToUpdate != null)
            {
                PersonData.Persons = PersonData.Persons.Select(p =>
                    p.Id == person.Id ? person : p).ToList();
            }

            return person;
        }

        public Person Delete(int id)
        {
            var person = PersonData.Persons.SingleOrDefault(p => p.Id == id);
            PersonData.Persons = PersonData.Persons.Where(p => p.Id != id).ToList();
            UpdateIdForList();

            return person;
        }

        public void UpdateIdForList()
        {
            for (int i = 0; i < PersonData.Persons.Count; i++)
            {
                PersonData.Persons[i].Id = i + 1;
            }
        }

        public List<Person> ListAll()
        {
            return PersonData.Persons.ToList();
        }

        public int GetLastId()
        {
            return PersonData.Persons.Any() ? PersonData.Persons.Max(p => p.Id) : 0;
        }

        public Person? GetPersonById(int id)
        {
            return PersonData.Persons.FirstOrDefault(p => p.Id == id);
        }
    }
}