using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobrancaOrm
{
    public class MapeadorPlanoDeCobrancaOrm : MapeadorBaseOrm<PlanoDeCobranca>
    {
        public override void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TBPlanoDeCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(50)").IsRequired();
            builder.HasOne(x => x.grupoDeVeiculo);
            builder.HasOne(x => x.planoDiario);
            builder.HasOne(x => x.planoLivre);
            builder.HasOne(x => x.planoControlado);
        }
    }
}
