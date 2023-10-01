using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.DbServices.Models
{
    public class DatabaseContext : DbContext
    {
        #region Constructor

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options) { }

        #endregion

        #region DbSets

        public virtual DbSet<ApplicationFeatures> ApplicationFeatures { get; set; }

        #endregion
    }
}
