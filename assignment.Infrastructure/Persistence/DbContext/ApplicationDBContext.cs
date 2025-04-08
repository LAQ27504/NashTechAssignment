using assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace assignment.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example: Configure TaskItem entity
        modelBuilder.Entity<Person>().HasKey(t => t.Id);
    }
}
