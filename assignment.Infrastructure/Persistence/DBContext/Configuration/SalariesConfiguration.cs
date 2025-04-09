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
        }
    }
}