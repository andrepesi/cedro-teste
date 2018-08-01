using Cedro.Domain.Entities;
using Cedro.Domain.Interfaces.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Infra.Data.Repositories
{
    public class RestauranteRepository : Repository<Restaurante, int>, IRestauranteRepository
    {
        public RestauranteRepository(CedroContext db) : base(db)
        {
        }
        public override IQueryable<Restaurante> QueryBase()
        {
            return DbSet.Include("Pratos");
        }
        public override Restaurante QueryByIdBase(int id)
        {
            var entity = QueryBase().FirstOrDefault(x => x.Id == id);
            Db.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
