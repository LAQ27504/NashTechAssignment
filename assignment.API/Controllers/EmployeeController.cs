namespace assignment.API.Controllers
{
    using assignment.Application.DTOs.Request;
    using assignment.Application.DTOs.Response;
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] EmployeeRequest employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            var createdEmployee = await _employeeService.AddEmployeeAsync(employee);
            return Ok(createdEmployee);
        }

        [HttpGet("GetAllEmployeeAndDepartment")]
        public async Task<ActionResult<IEnumerable<EmployeeWithDepartmentDTO>>> GetAllEmployeeAndDepartment()
        {
            var employees = await _employeeService.GetAllEmployeeAndDepartmentAsync();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromBody] EmployeeRequest employee)
        {
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
            if (updatedEmployee == null)
            {
                return NotFound();
            }

            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var isDeleted = await _employeeService.DeleteEmployeeAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok(new { Message = "Employee deleted successfully" });
        }

        [HttpGet("GetAllEmployeeAndProjects")]
        public async Task<ActionResult<IEnumerable<EmployeeWithProjectDTO>>> GetAllEmployeeAndProjects()
        {
            var employees = await _employeeService.GetAllEmployeeAndProjects();
            return Ok(employees);
        }

        [HttpGet("GetHighSalaryEmployeesAsync")]
        public async Task<ActionResult<IEnumerable<EmployeeHighSalaryJoinDate>>> GetHighSalaryEmployeesAsync()
        {
            var employees = await _employeeService.GetHighSalaryEmployeesAsync();
            return Ok(employees);
        }
    }
}