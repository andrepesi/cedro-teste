using AutoMapper;
using Cedro.Application.Interfaces;
using Cedro.Domain.Entities;
using Cedro.Domain.Interfaces.Domain.Services;
using Credo.Application.ViewModels;
using Credo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credo.Application.Implementations
{
    public class RestauranteAppService : AppService<RestauranteViewModel,Restaurante, int, IRestauranteService>, IRestauranteAppService
    {
        public RestauranteAppService(IRestauranteService srv, IMapper mapper) : base(srv,mapper)
        {
        }

        public override ValidationResult ValidateAdd(RestauranteViewModel viewModel)
        {
            var validation = new ValidationResult();

            bool nomeIsValid = !string.IsNullOrEmpty(viewModel.Nome);
            if (!nomeIsValid)
                validation.AddMessage("Nome do Restaurante é Obrigatório");
            return validation;
        }

        public override ValidationResult ValidateDelete(int id)
        {
            var validation = new ValidationResult();
            var prato = base.SelectById(id);
            bool pratoExists = prato != null;

            if (!pratoExists)
                validation.AddMessage("O restaurante informado não existe");

            return validation;
        }

        public override ValidationResult ValidateUpdate(RestauranteViewModel viewModel)
        {
            var validation = this.ValidateAdd(viewModel);

            if (!validation.IsValid)
                return validation;

            return this.ValidateDelete(viewModel.Id.GetValueOrDefault());
        }
    }
}
