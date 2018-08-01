using Cedro.Domain.Entities;
using Cedro.Domain.Interfaces.Infra.Data;
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
    }
}
