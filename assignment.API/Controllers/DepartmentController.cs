namespace assignment.API.Controllers
{
    using assignment.Application.DTOs.Request;
    using assignment.Application.Interface.UseCase;
    using assignment.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return Ok(new { Message = "Department not found" });
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] DepartmentRequest department)
        {
            if (department == null)
            {
                return Ok(new { Message = "Invalid department data" });
            }

            var createdDepartment = await _departmentService.AddDepartmentAsync(department);
            return Ok(createdDepartment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentRequest department)
        {
            var updated = await _departmentService.UpdateDepartmentAsync(id, department);
            if (updated == null)
            {
                return Ok(new { Message = "Department not found" });
            }

            return Ok(new { Message = "Department updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await _departmentService.DeleteDepartmentAsync(id);
            if (!deleted)
            {
                return Ok(new { Message = "Department not found" });
            }

            return Ok(new { Message = "Department deleted successfully" });
        }
    }
}