using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace Credo.Application
{
    public abstract class AppService<TViewModel, TEntity, TKeyType, TService> : IAppService<TViewModel, TKeyType>
        where TEntity : BaseEntity
        where TService : IService<TEntity, TKeyType>
    {
        TService service;
        IMapper _mapper;
        public AppService(TService srv, IMapper mapper)
        {
            service = srv;
            _mapper = mapper;
        }

        public ValidationResult Add(TViewModel viewModel)
        {
            var validation = this.ValidateAdd(viewModel);
            if (validation.IsValid)
            {

                var entity = _mapper.Map<TEntity>(viewModel);
                service.Add(entity); 
            }
            return validation;
        }

        public ValidationResult Delete(TKeyType id)
        {
            var validation = this.ValidateDelete(id);
            if (validation.IsValid)
            {
                service.Delete(id);
            }
            return validation;
        }

        public IEnumerable<TViewModel> SelectAll()
        {
            return _mapper.Map<List<TViewModel>>(service.SelectAll());
        }

        public TViewModel SelectById(TKeyType id)
        {

            return _mapper.Map<TViewModel>(service.SelectById(id));

        }

        public ValidationResult Update(TViewModel viewModel)
        {
            var validation = this.ValidateUpdate(viewModel);
            if (validation.IsValid)
            {
                var entity = _mapper.Map<TEntity>(viewModel);
                entity.DataAtualizacao = DateTime.Now;
                service.Update(entity);
            }
            return validation;
        }
        public abstract ValidationResult ValidateAdd(TViewModel viewModel);
        public abstract ValidationResult ValidateUpdate(TViewModel viewModel);
        public abstract ValidationResult ValidateDelete(TKeyType id);
    }
}
