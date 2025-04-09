using assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assignment.Infrastructure.Persistence.DBContext.Configuration
{
    public class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.HasKey(sc => new { sc.ProjectId, sc.EmployeeId });

            builder.Property(pe => pe.Enable)
                   .IsRequired();

            builder.Property(pe => pe.EmployeeId)
                   .IsRequired();

            builder.HasOne(pe => pe.Project)
                    .WithMany(p => p.ProjectEmployees)
                    .HasForeignKey(pe => pe.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pe => pe.Employee)
                    .WithMany(e => e.ProjectEmployees)
                    .HasForeignKey(pe => pe.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new ProjectEmployee { ProjectId = 1, EmployeeId = 1, Enable = true },
                new ProjectEmployee { ProjectId = 1, EmployeeId = 2, Enable = true },
                new ProjectEmployee { ProjectId = 2, EmployeeId = 2, Enable = true }
            );
        }
    }
}