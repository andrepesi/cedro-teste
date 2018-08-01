using AutoMapper;
using Cedro.Domain.Entities;
using Credo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credo.Application.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Restaurante, RestauranteViewModel>();
            CreateMap<Prato, PratoViewModel>()                
                .ForMember(x => x.NomeRestaurante, opt => opt.ResolveUsing(v => v.Restaurante?.Nome));
        }
    }
}
