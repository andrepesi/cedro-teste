using Credo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Interfaces.Infra.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ValidationResult Commit();
    }
}
