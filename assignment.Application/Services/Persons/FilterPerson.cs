namespace assignment.Application.Services.Persons
{
    using assignment.Application.Interface.Gateway;
    using assignment.Application.Interface.Persons;
    using assignment.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FilterPerson : IFilter
    {
        private readonly IPersonRepository _personRepository;

        public FilterPerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> Execute(string? name, HumanGender? gender, string? birthPlace)
        {
            var persons = await _personRepository.FilterData(name, gender, birthPlace);
            return persons;
        }
    }
}