using assignment.Application.Interface.Gateway;
using assignment.Application.Interface.Persons;
using assignment.Domain.Entities;

namespace assignment.Application.Services.Persons
{
    public class ListPerson : IListPerson
    {
        private readonly IPersonRepository _personRepository;

        public ListPerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> Execute()
        {
            return await _personRepository.GetAllPerson();
        }
    }
}