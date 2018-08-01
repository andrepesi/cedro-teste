using Cedro.Application.Interfaces;
using Cedro.Domain.Entities;
using Cedro.Domain.Interfaces.Infra.Data;
using Credo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Cedro.Services.WebApi.Controllers
{
    public class RestauranteController : BaseController<RestauranteViewModel, int, IRestauranteAppService>
    {
        public RestauranteController(IRestauranteAppService srv, IUnitOfWork wow) : base(srv, wow)
        {
        }
    }
}
