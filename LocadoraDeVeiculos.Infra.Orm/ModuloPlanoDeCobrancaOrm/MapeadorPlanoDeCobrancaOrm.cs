using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.OwnsOne(x => x.planoDiario, planoDiario =>
            {
                planoDiario.Property(x => x.valorDiario).HasColumnType("DECIMAL(11,4)").IsRequired();
                planoDiario.Property(x => x.valorKm).HasColumnType("DECIMAL(11,4)").IsRequired();
            });
            builder.OwnsOne(x => x.planoLivre, planoLivre =>
            {
                planoLivre.Property(x => x.valorDiario).HasColumnType("DECIMAL(11,4)").IsRequired();
            });
            builder.OwnsOne(x => x.planoControlado, planoControlado =>
            {
                planoControlado.Property(x => x.valorDiario).HasColumnType("DECIMAL(11,4)").IsRequired();
                planoControlado.Property(x => x.valorKm).HasColumnType("DECIMAL(11,4)").IsRequired();
                planoControlado.Property(x => x.limiteKm).HasColumnType("DECIMAL(11,4)").IsRequired();
            });
            //builder.Property(x => x.planoDiario.valorDiario).HasColumnType("DECIMAL(11,4)").IsRequired();
            //builder.Property(x => x.planoDiario.valorKm).HasColumnType("DECIMAL(11,4)").IsRequired();
            //builder.Property(x => x.planoLivre.valorDiario).HasColumnType("DECIMAL(11,4)").IsRequired();
            //builder.Property(x => x.planoControlado.valorDiario).HasColumnType("DECIMAL(11,4)").IsRequired();
            //builder.Property(x => x.planoControlado.valorKm).HasColumnType("DECIMAL(11,4)").IsRequired();
            //builder.Property(x => x.planoControlado.limiteKm).HasColumnType("DECIMAL(11,4)").IsRequired();
        }
    }
}
