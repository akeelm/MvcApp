using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repository.Data
{
    /// <summary>
    /// This is a pluggable layer over the DbContext,
    /// so we can easily create a fake context for unit testing purposes.
    /// </summary>
    public interface IDataSession : IDisposable
    {
        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
        int SqlCommand(string sql, params object[] parameters);
    }
}
