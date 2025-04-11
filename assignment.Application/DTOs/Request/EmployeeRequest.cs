namespace assignment.Application.DTOs.Request
{

    public class EmployeeRequest
    {

        public DateTime JoinedDate { get; set; }

        public string? Name { get; set; }

        public int DepartmentId { get; set; }
    }
}