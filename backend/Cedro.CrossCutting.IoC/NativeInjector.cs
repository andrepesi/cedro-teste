using Cedro.Application.Interfaces;
using Cedro.Domain.Interfaces.Domain.Services;
using Cedro.Domain.Interfaces.Infra.Data;
using Cedro.Domain.Services;
using Cedro.Infra.Data;
using Cedro.Infra.Data.Repositories;
using Cedro.Infra.Data.WoW;
using Credo.Application.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<CedroContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            services.AddScoped<IPratoRepository, PratoRepository>();

            services.AddScoped<IRestauranteService, ResturanteService>();
            services.AddScoped<IPratoService, PratoService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRestauranteAppService, RestauranteAppService>();
            services.AddScoped<IPratoAppService, PratoAppService>();           

        }
    }
}
