using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Interfaces.Domain.Keys
{
    public interface IEntityKey<TKeyType>
    {
        TKeyType Id { get; set; }
    }
}
