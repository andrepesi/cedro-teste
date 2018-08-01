using Cedro.Domain.Interfaces.Domain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Entities
{
    public class Prato : BaseEntity
    {
        public int RestauranteId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public virtual Restaurante Restaurante { get; set; }

        protected Prato() { }
        public Prato(string nome, decimal preco, int restauranteId, int? pratoId)
        {
            Nome = nome;
            Preco = preco;
            restauranteId = restauranteId;
            Id = pratoId.GetValueOrDefault();
        }
    }
}
