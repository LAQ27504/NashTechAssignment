namespace assignment.API.Controllers
{
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Salaries>>> GetAllSalaries()
        {
            var salaries = await _salaryService.GetAllSalariesAsync();
            return Ok(salaries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salaries>> GetSalaryById(int id)
        {
            var salary = await _salaryService.GetSalaryByIdAsync(id);
            if (salary == null)
            {
                return NotFound(new { Message = "Salary not found" });
            }
            return Ok(salary);
        }

        [HttpPost]
        public async Task<ActionResult<Salaries>> AddSalary([FromBody] Salaries salary)
        {
            if (salary == null)
            {
                return BadRequest(new { Message = "Invalid salary data" });
            }

            var createdSalary = await _salaryService.AddSalaryAsync(salary);
            return Ok(createdSalary);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Salaries>> UpdateSalary([FromBody] Salaries salary)
        {
            var updateSalaries = await _salaryService.UpdateSalaryAsync(salary);
            if (updateSalaries == null)
            {
                return NotFound(new { Message = "Salary not found" });
            }
            return Ok(updateSalaries);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSalary(int id)
        {
            var successfully = await _salaryService.DeleteSalaryAsync(id);
            if (!successfully)
            {
                return NotFound(new { Message = "Salary not found" });
            }
            return Ok(new { Message = "Delete success" });
        }

    }
}
