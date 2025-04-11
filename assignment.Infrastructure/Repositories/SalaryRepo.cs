namespace assignment.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Application.Interface.Gateway;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Persistence.DBContext;
    using Microsoft.EntityFrameworkCore;

    public class SalaryRepo : ISalaryRepo
    {
        private readonly ApplicationDbContext _context;

        public SalaryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Salaries> AddSalaryAsync(Salaries salary)
        {
            await _context.Salaries.AddAsync(salary);
            await _context.SaveChangesAsync();
            return salary;
        }

        public Task<bool> DeleteSalaryAsync(int id)
        {
            var salary = _context.Salaries.Find(id);
            if (salary != null)
            {
                _context.Salaries.Remove(salary);
                _context.SaveChangesAsync();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<List<Salaries>> GetAllSalariesAsync()
        {
            return _context.Salaries
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Salaries> GetSalaryAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null)
            {
                throw new KeyNotFoundException("Salary not found");
            }
            return salary;
        }

        public async Task<Salaries> UpdateSalaryAsync(int id, Salaries salary)
        {
            var updateSalary = await _context.Salaries.FindAsync(id);
            if (updateSalary == null)
            {
                throw new KeyNotFoundException("Salary not found");
            }
            updateSalary.Salary = salary.Salary;
            updateSalary.EmployeeId = salary.EmployeeId;
            _context.Salaries.Update(updateSalary);
            await _context.SaveChangesAsync();

            return updateSalary;
        }
    }
}