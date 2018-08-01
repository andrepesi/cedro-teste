using Cedro.Domain.Interfaces.Infra.Data;
using Credo.Domain.Validation;
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

        public ValidationResult Commit()
        {
            ValidationResult validation = new ValidationResult();
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                validation.AddMessage(e.Message);
            }
            return validation;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
