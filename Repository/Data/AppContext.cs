using Repository.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repository.Data
{
    /// <summary>
    /// Concrete DbContext class. 
    /// Used for configuration of Entity Framework and injected into IDataSession using StructureMap.
    /// </summary>
    public class AppContext : DbContext
    {
        public AppContext() : base("AppContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserForgotPassword> UserForgotPassword { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Base
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
