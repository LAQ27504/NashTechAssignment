namespace assignment.Infrastructure.Persistence.DBContext.Configuration
{
    using assignment.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.JoinedDate)
                .IsRequired();

            builder.HasOne(e => e.Department)
                .WithMany(g => g.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Employee { Id = 1, Name = "Alice", JoinedDate = new DateTime(2023, 1, 10), DepartmentId = 1 },
                new Employee { Id = 2, Name = "Bob", JoinedDate = new DateTime(2023, 2, 15), DepartmentId = 2 },
                new Employee { Id = 3, Name = "Charlie", JoinedDate = new DateTime(2023, 3, 20), DepartmentId = 3 }
            );

        }
    }
}