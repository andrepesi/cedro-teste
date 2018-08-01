using Cedro.Domain.Entities;
using Cedro.Application.Interfaces;
using Cedro.Domain.Interfaces.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credo.Application.ViewModels;
using AutoMapper;
using Credo.Domain.Validation;

namespace Credo.Application.Implementations
{
    public class PratoAppService : AppService<PratoViewModel, Prato, int, IPratoService>, IPratoAppService
    {
        public PratoAppService(IPratoService srv, IMapper mapper) : base(srv, mapper)
        {
        }

        public override ValidationResult ValidateAdd(PratoViewModel viewModel)
        {
            var validation = new ValidationResult();
            bool nomeIsValid = !string.IsNullOrEmpty(viewModel.Nome);
            bool precoIsValid = viewModel.Preco > 0;
            bool restauranteIsValid = viewModel.RestauranteId > 0;
            if (!nomeIsValid)
                validation.AddMessage("Nome do Prato é Obrigatório");
            if (!precoIsValid)
                validation.AddMessage("Preço do Prato é Obrigatório");
            if (!restauranteIsValid)
                validation.AddMessage("Restaurante do Prato é Obrigatório");
            return validation;
        }

        public override ValidationResult ValidateDelete(int id)
        {
            var validation = new ValidationResult();
            var prato = base.SelectById(id);
            bool pratoExists = prato != null;
            
            if (!pratoExists)
                validation.AddMessage("O prato que deseja excluir não existe");

            return validation;
        }

        public override ValidationResult ValidateUpdate(PratoViewModel viewModel)
        {
            var validation = this.ValidateAdd(viewModel);

            if (!validation.IsValid)
                return validation;

            validation = this.ValidateDelete(viewModel.Id.GetValueOrDefault());
            return validation;
            
        }
    }
}
