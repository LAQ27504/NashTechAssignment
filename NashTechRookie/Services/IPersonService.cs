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

        Person Create(
            Person person
        );

        Person Update(
            Person person
        );

        Person Delete(
            int id
        );

        List<Person> ListAll();
    }
}
