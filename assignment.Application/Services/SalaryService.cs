namespace assignment.Application.Services
{
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;
    using assignment.Application.Interface.Gateway;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Application.DTOs.Request;

    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepo _salaryRepository;

        public SalaryService(ISalaryRepo salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public async Task<Salaries> AddSalaryAsync(SalaryRequest salary)
        {
            Salaries newSalary = new Salaries
            {
                EmployeeId = salary.EmployeeId,
                Salary = salary.Salary,
                Id = salary.Id
            };

            return await _salaryRepository.AddSalaryAsync(newSalary);
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

        public async Task<Salaries> UpdateSalaryAsync(SalaryRequest salary)
        {
            Salaries updateSalary = new Salaries
            {
                EmployeeId = salary.EmployeeId,
                Salary = salary.Salary,
                Id = salary.Id
            };
            return await _salaryRepository.UpdateSalaryAsync(updateSalary);
        }
    }
}