using assignment.Domain.Entities;

public class EmployeeWithProjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Project> Projects { get; set; }

}
