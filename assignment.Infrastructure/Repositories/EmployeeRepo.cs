namespace assignment.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using assignment.Application.DTOs.Response;
    using assignment.Application.Interface.Gateway;
    using assignment.Domain.Entities;
    using assignment.Infrastructure.Persistence.DBContext;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<EmployeeWithDepartmentDTO>> GetAllEmployeeAndDepartmentAsync()
        {
            var employees = await _context.Database
            .SqlQueryRaw<EmployeeWithDepartmentDTO>("""
                                                    SELECT 
                                                        [e].[Id],
                                                        [e].[Name],
                                                        [d].[Id] AS [DepartmentId],
                                                        [d].[Name] AS [DepartmentName] 
                                                    FROM 
                                                        [dbo].[Employees] [e]
                                                    INNER JOIN 
                                                        [dbo].[Departments] [d] 
                                                    ON
                                                        [e].[DepartmentId] = [d].[Id]
                                                    """)
                                            .AsNoTracking()
                                            .ToListAsync();

            return employees;
        }

        public async Task<List<EmployeeWithProjectDTO>> GetAllEmployeeAndProjectAsync()
        {
            var employees = await _context.Database
            .SqlQueryRaw<EmployeeWithProjectDTO>("""
                                                    SELECT 
                                                        [e].[Id],
                                                        [e].[Name],
                                                        [p].[Id] AS [ProjectId],
                                                        [p].[Name] AS [ProjectName] 
                                                    FROM 
                                                        [dbo].[Employees] [e]
                                                    LEFT JOIN 
                                                        [dbo].[ProjectEmployees] [pe] 
                                                    ON
                                                        [e].[Id] = [pe].[EmployeeId]
                                                    LEFT JOIN 
                                                        [dbo].[Projects] [p] 
                                                    ON
                                                        [pe].[ProjectId] = [p].[Id]
                                                    """)
                                            .AsNoTracking()
                                            .ToListAsync();

            return employees;

        }

        public async Task<List<EmployeeHighSalaryJoinDate>> GetHighSalaryEmployeesAsync()
        {
            var employees = await _context.Database
            .SqlQueryRaw<EmployeeHighSalaryJoinDate>("""
                        SELECT 
                            [e].[Id],
                            [e].[Name],
                            [e].[Salary],
                            [e].[JoinedDate]
                        FROM 
                            [dbo].[Employees] [e]
                        WHERE 
                            [e].[Salary] > 100 
                            AND [e].[JoinedDate] >= '2024-01-01'
                        """)
            .AsNoTracking()
            .ToListAsync();

            return employees;
        }
    }
}