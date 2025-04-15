using NashTechRookie.Models;

namespace NashTechRookie.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        IEnumerable<Person> GetMales();
        Person GetOldestPerson();
        IEnumerable<string> GetPersonsFullName();
        IEnumerable<Person>? GetPersonsByBirthYearWithAction(string action);
        FileModel ExportToExcel();

        int GetLastId();

        Person? GetPersonById(int id);

        void Create(
            Person person
        );

        void Update(
            Person person
        );

        void Delete(
            Person person
        );

        List<Person> ListAll();
    }
}
