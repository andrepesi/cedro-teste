using System;
using System.Collections.Generic;
using System.Text;

namespace Credo.Application.ViewModels
{
    public class RestauranteViewModel :  BaseViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public List<PratoViewModel> Pratos { get; set; }
    }
}
