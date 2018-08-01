using Cedro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Interfaces.Infra.Data
{
    public interface IRestauranteRepository : IRepository<Restaurante,int>
    {
    }
}
