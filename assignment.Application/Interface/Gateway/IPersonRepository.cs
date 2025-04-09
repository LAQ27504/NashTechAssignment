namespace assignment.Application.Interface.Gateway
{
    using assignment.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPersonRepository
    {
        Task<Person> CreatePerson(Person person);

        Task<Person> UpdatePerson(Guid id, Person person);

        Task<bool> DeletePerson(Guid id);

        Task<List<Person>> FilterData(string? name, HumanGender? gender, string? birthPlace);

        Task<IEnumerable<Person>> GetAllPerson();
    }
}