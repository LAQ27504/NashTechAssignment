namespace assignment.Application.Services.Persons
{
    using assignment.Application.Interface.Gateway;
    using assignment.Application.Interface.Persons;
    public class DeletePerson : IDelete
    {
        private readonly IPersonRepository _personRepository;

        public DeletePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Execute(Guid id)
        {
            return await _personRepository.DeletePerson(id);
        }
    }
}