namespace assignment.Application.Interface.UseCase
{
    using assignment.Application.DTOs.Request;
    using assignment.Domain.Entities;
    public interface ISalaryService
    {
        Task<Salaries> AddSalaryAsync(SalaryRequest salary);
        Task<Salaries> UpdateSalaryAsync(int id, SalaryRequest salary);
        Task<bool> DeleteSalaryAsync(int id);
        Task<Salaries> GetSalaryByIdAsync(int id);
        Task<List<Salaries>> GetAllSalariesAsync();
    }
}
