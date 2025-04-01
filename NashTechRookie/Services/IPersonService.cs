using NashTechRookie.Models;

namespace NashTechRookie.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetMales();
        Person GetOldestPerson();
        IEnumerable<string> GetPersonsFullName();
        IEnumerable<Person>? GetPersonsByBirthYearWithAction(string action);
        FileModel ExportToExcel();
    }
}
