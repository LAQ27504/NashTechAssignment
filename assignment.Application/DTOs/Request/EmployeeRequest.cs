namespace assignment.Application.DTOs.Request
{

    public class EmployeeRequest
    {
        public int Id { get; set; }

        public DateTime JoinedDate { get; set; }

        public string? Name { get; set; }

        public int DepartmentId { get; set; }
    }
}