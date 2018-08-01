using Cedro.Application.Interfaces;
using Cedro.Domain.Interfaces.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cedro.Services.WebApi.Controllers
{
    public class BaseController<TEntity, TKeyType, TAppService>: Controller
        where TEntity : class
        where TAppService : IAppService<TEntity, TKeyType>
    {
        TAppService service;
        IUnitOfWork unitOfWork;
        public BaseController(TAppService srv,IUnitOfWork wow)
        {
            service = srv;
            unitOfWork = wow;
        }
        public IActionResult Get()
        {
            return Ok(service.SelectAll());
        }
        public IActionResult Get(TKeyType id)
        {
            return Ok(service.SelectById(id));
        }
        public IActionResult Post([FromBody]TEntity value)
        {
            service.Add(value);
            return Ok();
        }
        public IActionResult Put([FromBody]TEntity value)
        {
            service.Add(value);
            return Ok();
        }
        public IActionResult Delete(TKeyType id)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
