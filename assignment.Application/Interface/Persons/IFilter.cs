using assignment.Domain.Entities;

namespace assignment.Application.Interface.Persons
{
    public interface IFilter
    {
        Task<IEnumerable<Person>> Execute(string? name, HumanGender? gender, string? birthPlace);
    }
}