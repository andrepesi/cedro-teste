using Cedro.Domain.Interfaces.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Infra.Data.WoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CedroContext _context;

        public UnitOfWork(CedroContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
