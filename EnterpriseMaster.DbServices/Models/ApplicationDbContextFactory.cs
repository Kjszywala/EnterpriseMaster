using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnterpriseMaster.DbServices.Models
{
    /// <summary>
    /// We need this class for scafolding when DbServices are in different project.
    /// </summary>
    internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer("Server=DORD0049\\SQLEXPRESS;Database=EnterpriseMaster;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}