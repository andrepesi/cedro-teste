using Cedro.Domain.Interfaces.Domain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Entities
{
    public abstract class BaseEntity : IIntKey
    {
        public int Id { get; set ; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
