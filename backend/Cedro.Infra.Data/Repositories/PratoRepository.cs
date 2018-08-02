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
    public class PratoRepository : Repository<Prato, int>, IPratoRepository
    {
        public PratoRepository(CedroContext db) : base(db)
        {
        }
        public override IQueryable<Prato> QueryBase()
        {
            return Db.Pratos.Include("Restaurante");
        }
        public override Prato QueryByIdBase(int id)
        {
            var entity =  QueryBase().FirstOrDefault(x=> x.Id == id);
            Db.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
