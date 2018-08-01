using Cedro.Domain.Interfaces.Domain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Entities
{
    public class Restaurante : BaseEntity
    {
        public string Nome { get; set; }
        public virtual List<Prato> Pratos { get; set; }
        protected Restaurante()
        {

        }
        public Restaurante(string nome, int? restauranteId)
        {
            Nome = nome;
            Id = restauranteId.GetValueOrDefault();
        }
    }
}
