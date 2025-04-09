namespace assignment.Infrastructure.Persistence.DBContext.Configuration
{
    using assignment.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SalariesConfiguration : IEntityTypeConfiguration<Salaries>
    {
        public void Configure(EntityTypeBuilder<Salaries> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Salary)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(s => s.Employee)
                .WithOne(e => e.Salary)
                .HasForeignKey<Salaries>(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Salaries { Id = 1, Salary = 5000, EmployeeId = 1 },
                new Salaries { Id = 2, Salary = 5500, EmployeeId = 2 },
                new Salaries { Id = 3, Salary = 6000, EmployeeId = 3 }
            );

        }
    }
}