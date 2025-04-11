namespace assignment.Application.Services
{
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;
    using assignment.Application.Interface.Gateway;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepo _salaryRepository;

        public SalaryService(ISalaryRepo salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public async Task<Salaries> AddSalaryAsync(Salaries salary)
        {
            return await _salaryRepository.AddSalaryAsync(salary);
        }

        public async Task<bool> DeleteSalaryAsync(int id)
        {
            return await _salaryRepository.DeleteSalaryAsync(id);
        }

        public async Task<List<Salaries>> GetAllSalariesAsync()
        {
            return await _salaryRepository.GetAllSalariesAsync();
        }

        public async Task<Salaries> GetSalaryByIdAsync(int id)
        {
            return await _salaryRepository.GetSalaryAsync(id);
        }

        public async Task<Salaries> UpdateSalaryAsync(Salaries salary)
        {
            return await _salaryRepository.UpdateSalaryAsync(salary);
        }
    }
}