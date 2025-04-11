using assignment.Domain.Entities;

namespace assignment.Application.Interface.Gateway
{
    public interface ISalaryRepo
    {
        Task<Salaries> AddSalaryAsync(Salaries salary);
        Task<Salaries> UpdateSalaryAsync(int id, Salaries salary);
        Task<bool> DeleteSalaryAsync(int id);
        Task<Salaries> GetSalaryAsync(int id);
        Task<List<Salaries>> GetAllSalariesAsync();
    }
}