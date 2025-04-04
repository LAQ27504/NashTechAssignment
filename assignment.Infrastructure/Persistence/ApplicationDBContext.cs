using Microsoft.EntityFrameworkCore;
using assignment.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}
