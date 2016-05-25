using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repository.Data
{
    /// <summary>
    /// This is the actual DB session for the pluggable IDataSession / DbContext
    /// </summary>
    public class EntityDataSession : IDataSession
    {
        private DbContext _db;

        public EntityDataSession(DbContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return _db.Set<T>();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return _db.Entry(entity);
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public int SqlCommand(string sql, params object[] parameters)
        {
            return _db.Database.ExecuteSqlCommand(sql, parameters);
        }
    }
}
