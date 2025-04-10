using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface ISalaryRepo
    {
        Task<Salaries> AddSalary(Salaries salary);
        Task<Salaries> UpdateSalary(Salaries salary);
        Task<bool> DeleteSalary(int id);
        Task<Salaries> GetSalary(int id);
    }
}