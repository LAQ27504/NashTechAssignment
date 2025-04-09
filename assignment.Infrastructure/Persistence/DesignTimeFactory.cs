using assignment.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyProject.Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Build the options for the context.
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Here you can specify your connection string directly, or read it from configuration if you like.
            // Make sure to include the necessary package for your provider (e.g., Microsoft.EntityFrameworkCore.SqlServer)
            optionsBuilder.UseSqlServer("Server=localhost;Database=PersonDb;User Id=sa;Password=SQLServer1@;TrustServerCertificate=True;");

            // Return a new instance of your DbContext.
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
