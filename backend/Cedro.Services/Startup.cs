using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cedro.Infra.Data;
using Cedro.Services.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cedro.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            });
            services.AddAutoMapperSetup();
            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CedroContext>();
                context.Database.Migrate();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(
                options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            );
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        private static void RegisterServices(IServiceCollection services)
        {
            // DI
            Cedro.CrossCutting.IoC.NativeInjector.RegisterServices(services);
        }
    }
}
