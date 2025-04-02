using NashTechRookie.Data;
using NashTechRookie.Utils;
using NashTechRookie.Models;
using Microsoft.AspNetCore.Mvc;

namespace NashTechRookie.Services
{
    public class PersonService : IPersonService, IPerson
    {
        private readonly PersonData _personData = new();

        public List<Person> GetAll()
        {
            return _personData.Persons.ToList();
        }

        public IEnumerable<Person> GetMales()
        {
            var malePersons = _personData.Persons.Where(mp => mp.Gender == Gender.Male);

            return malePersons;
        }

        public Person GetOldestPerson()
        {
            var oldestPerson = _personData.Persons.OrderByDescending(p => p.DateOfBirth).First();

            return oldestPerson;
        }

        public IEnumerable<string> GetPersonsFullName()
        {
            var fullNames = _personData.Persons.Select(p => p.FullName);

            return fullNames;
        }

        public IEnumerable<Person>? GetPersonsByBirthYearWithAction(string action)
        {
            return action.ToUpper() switch
            {
                "GREATER" => _personData.Persons.Where(p => p.DateOfBirth.Year < 2000),
                "LOWER" => _personData.Persons.Where(p => p.DateOfBirth.Year > 2000),
                "EQUAL" => _personData.Persons.Where(p => p.DateOfBirth.Year == 2000),
                _ => null
            };
        }

        public FileModel ExportToExcel()
        {
            var personToExcel = _personData.Persons.ToList();
            var fileContent = FileHelper<Person>.GenerateExcelFile(personToExcel);
            var fileName = $"Persons_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

            return new FileModel(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }


        public void Create(Person person)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<IPerson> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}