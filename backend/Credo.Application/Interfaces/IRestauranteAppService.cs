using Cedro.Domain.Entities;
using Credo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Application.Interfaces
{
    public interface IRestauranteAppService : IAppService<RestauranteViewModel,int>
    {
    }
}
