using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Credo.Application.ViewModels
{
    public class PratoViewModel : BaseViewModel
    {
        [Required(ErrorMessage ="Nome do Prato é Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preço do Prato é Obrigatório")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Restaurante do Prato é Obrigatório")]
        public int RestauranteId { get; set; }
        public string NomeRestaurante { get; set; }
    }
}
