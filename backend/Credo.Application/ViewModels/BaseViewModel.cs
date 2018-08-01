using Cedro.Domain.Interfaces.Domain.Keys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credo.Application.ViewModels
{
    public class BaseViewModel
    {
        public int? Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
