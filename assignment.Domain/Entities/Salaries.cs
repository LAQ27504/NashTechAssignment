namespace assignment.Domain.Entities
{
    public class Salaries
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int Salary { get; set; }

        public Employee? Employee { get; set; }
    }
}