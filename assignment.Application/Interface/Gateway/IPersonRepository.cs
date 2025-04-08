namespace assignment.Application.Interface.Gateway
{
    using assignment.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPersonRepository
    {
        Task<Person> CreatePerson(Person person);
        Task<bool> UpdatePerson(Person person);
        Task<bool> DeletePerson(Guid id);

        Task<Person> FilterData(string name, HumanGender gender, string birthPlace);
    }
}