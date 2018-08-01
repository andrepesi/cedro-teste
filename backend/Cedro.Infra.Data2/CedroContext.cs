using Cedro.Domain.Entities;
using Cedro.Infra.Data.Mappings;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Infra.Data
{
    public class FabricaPersisteContext : IDesignTimeDbContextFactory<CedroContext>
    {
        private const string CONNECTIONSTRING = @"Data Source=GABRIEL-LAPTOP\SQLEXPRESSR2;Initial Catalog=ControlePedidos;Integrated Security=True";
        //public CedroContext Create(DbContextFactoryOptions options)
        //{
        //    var construtor = new DbContextOptionsBuilder<CedroContext>();
        //    construtor.UseSqlServer(CONNECTIONSTRING);
        //    return new CedroContext();
        //}

        public CedroContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<CedroContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new CedroContext(builder.Options);
        }
    }
    public class CedroContext : DbContext
    {
        public CedroContext()
        {
        }

        public CedroContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestauranteMap());
            modelBuilder.ApplyConfiguration(new PratoMap());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder
               // .UseLazyLoadingProxies()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
