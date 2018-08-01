using Cedro.Domain.Interfaces.Domain.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Entities
{
    public class Prato : IIntKey
    {
        public int Id { get; set; }
        public int RestauranteId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
