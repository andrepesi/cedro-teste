using AutoMapper;
using Cedro.Application.Interfaces;
using Cedro.Domain.Interfaces.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cedro.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TKeyType, TAppService> : Controller
        where TEntity : class
        where TAppService : IAppService<TEntity, TKeyType>
    {
        TAppService service;
        IUnitOfWork unitOfWork;
        public BaseController(TAppService srv, IUnitOfWork wow, IMapper mapper)
        {
            service = srv;
            unitOfWork = wow;
        }
        [HttpGet]
        public virtual IActionResult Get()
        {
            return Ok(service.SelectAll());
        }
        [HttpGet]
        [Route("{id}")]
        public virtual IActionResult Get(TKeyType id)
        {
            return Ok(service.SelectById(id));
        }
        [HttpPost]
        public virtual IActionResult Post([FromBody]TEntity value)
        {
            var validation = service.Add(value);
            if (validation.IsValid)
            {
                validation = unitOfWork.Commit();
            }
            return Ok(new { data = validation.IsValid ? service.SelectAll() : null, ok = validation.IsValid, errors = validation.Errors });


        }
        [HttpPut]
        public virtual IActionResult Put([FromBody]TEntity value)
        {
            var validation = service.Update(value);
            if (validation.IsValid)
            {
                validation = unitOfWork.Commit();
            }
            return Ok(new { data = validation.IsValid ? service.SelectAll() : null, ok = validation.IsValid, errors = validation.Errors });
        }
        [HttpDelete]
        [Route("{id}")]
        public virtual IActionResult Delete(TKeyType id)
        {
            var validation = service.Delete(id);
            if (validation.IsValid)
            {
                validation = unitOfWork.Commit();
            }
            return Ok(new { data = validation.IsValid ? service.SelectAll() : null, ok = validation.IsValid, errors = validation.Errors });
        }
    }
}
