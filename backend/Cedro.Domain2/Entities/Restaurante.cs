using Cedro.Domain.Interfaces.Domain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Entities
{
    public class Restaurante : IIntKey
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
