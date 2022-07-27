using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxa
{
    public class MapeadorTaxaOrm : MapeadorBaseOrm<Taxa>
    {
        public override void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TBTaxa");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.descricao).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.valor).HasColumnType("FLOAT").IsRequired();
            builder.Property(x => x.tipoCalculo).HasConversion<string>()
                .HasColumnType("VARCHAR(50)").IsRequired();
        }
    }
}
