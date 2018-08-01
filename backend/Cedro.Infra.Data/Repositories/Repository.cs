using Cedro.Domain.Interfaces.Domain.Keys;
using Cedro.Domain.Interfaces.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Infra.Data.Repositories
{
    public class Repository<TEntity, TKeyType> : IRepository<TEntity,TKeyType>
        where TEntity : class, IEntityKey<TKeyType>
    {
        protected readonly CedroContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(CedroContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(TKeyType id)
        {
            var entity = SelectById(id);
            DbSet.Remove(entity);
        }

        public IEnumerable<TEntity> SelectAll()
        {
            return DbSet.AsNoTracking();
        }

        public TEntity SelectById(TKeyType id)
        {
            return DbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
    }
}
