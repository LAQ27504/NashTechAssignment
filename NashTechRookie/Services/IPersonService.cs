using NashTechRookie2.Models;

namespace NashTechRookie2.Services
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
