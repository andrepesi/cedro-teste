using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cedro.Application.Interfaces;
using Cedro.Domain.Interfaces.Infra.Data;
using Cedro.Services.WebApi.Controllers;
using Credo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cedro.Services.Controllers
{
    public class PratoController : BaseController<PratoViewModel, int, IPratoAppService>
    {
        public PratoController(IPratoAppService srv, IUnitOfWork wow, IMapper mapper) : base(srv, wow, mapper)
        {
        }
    }
}
