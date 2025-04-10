namespace assignment.Application.Interface.UseCase
{
    using assignment.Domain.Entities;
    public interface ISalaryService
    {
        Task<Salaries> AddSalaryAsync(Salaries salary);
        Task<Salaries> UpdateSalaryAsync(Salaries salary);
        Task<bool> DeleteSalaryAsync(int id);
        Task<Salaries> GetSalaryByIdAsync(int id);
        Task<IEnumerable<Salaries>> GetAllSalariesAsync();
    }
}
