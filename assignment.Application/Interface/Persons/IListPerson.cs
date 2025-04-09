using assignment.Domain.Entities;

namespace assignment.Application.Interface.Persons
{
    public interface IListPerson
    {
        Task<IEnumerable<Person>> Execute(Person person);
    }
}