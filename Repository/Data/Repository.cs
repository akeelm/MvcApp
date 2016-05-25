using System;
using System.Linq;
using System.Data.Entity;
using Repository.Models;

namespace Repository.Data
{
    /// <summary>
    /// This is a generic repository.
    /// All of the entities will need the same basic CRUD functions.
    /// This saves having to recreate the same functions for every new entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Repository<T> where T : Base
    {
        private IDbSet<T> entities;
        public IDataSession _db { get; set; }

        public int Add(T entity, bool commit = true)
        {
            Entities.Add(entity);

            if (commit)
                _db.SaveChanges();

            return entity.ID;
        }

        public T AddReturnEntity(T entity, bool commit = true)
        {
            Entities.Add(entity);

            if (commit)
                _db.SaveChanges();

            return entity;
        }

        public void Update(T entity, bool commit = true)
        {
            entity.ModifiedDate = DateTime.UtcNow;
            Entities.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;            

            if (commit)
                _db.SaveChanges();
        }

        public void Delete(T entity, bool commit = true)
        {
            entity.Deleted = true;
            entity.ModifiedDate = DateTime.UtcNow;
            Update(entity, commit);
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public T GetByPropertySingle(dynamic property, object value)
        {
            var name = nameof(property);
            return Entities.SingleOrDefault(x => x.GetType().GetProperty(name) == value);
            //return Entities.SingleOrDefault(x => x.GetType().GetProperty(name) == (System.Reflection.PropertyInfo)value);
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = _db.Set<T>();
                }
                return entities;
            }
        }
    }
}
