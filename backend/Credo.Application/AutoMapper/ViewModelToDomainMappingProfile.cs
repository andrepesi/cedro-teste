using AutoMapper;
using Cedro.Domain.Entities;
using Credo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Credo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PratoViewModel, Prato>()
              .ForMember(x=> x.Restaurante ,i=> i.Ignore())
              .ConstructUsing(c => new Prato(c.Nome,c.Preco,c.RestauranteId,c.Id));

            CreateMap<RestauranteViewModel, Restaurante>()
             .ConstructUsing(c => new Restaurante(c.Nome,c.Id));
        }
    }
}
