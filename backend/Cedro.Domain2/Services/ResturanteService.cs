using Cedro.Domain.Entities;
using Cedro.Domain.Interfaces.Domain.Services;
using Cedro.Domain.Interfaces.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Services
{
    public class ResturanteService : CedroService<Restaurante, IRestauranteRepository,int>, IRestauranteService
    {
        public ResturanteService(IRestauranteRepository _repository) : base(_repository)
        {
        }
    }
}
