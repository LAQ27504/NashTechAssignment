using assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace assignment.Infrastructure.Persistence.DBContext.Configuration
{
    public class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.HasKey(pe => pe.ProjectId);

            builder.Property(pe => pe.Enable)
                   .IsRequired();

            builder.Property(pe => pe.EmployeeId)
                   .IsRequired();
        }
    }
}