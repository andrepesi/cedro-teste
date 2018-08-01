using Cedro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Infra.Data.Mappings
{
    public class PratoMap : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .HasMaxLength(60)
                   .IsRequired();
            builder.Property(p => p.DataCriacao)
                   .IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(p => p.DataAtualizacao);
            builder.Property(x => x.Preco)                    
                  .IsRequired();
           // builder.HasOne(x => x.Restaurante).WithMany().HasForeignKey(x => x.RestauranteId);
        }
    }
}
