using AutoMapper;
using Credo.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cedro.Services.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var config  = AutoMapperConfig.RegisterMappings();
            services.AddSingleton<IMapper>(sp => config.CreateMapper());
            services.AddAutoMapper();

        }
    }
}
