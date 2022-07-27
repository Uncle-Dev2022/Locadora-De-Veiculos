using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos
{
    public class MapeadorGrupoDeVeiculosOrm : MapeadorBaseOrm<GrupoDeVeiculo>
    {
        public override void Configure(EntityTypeBuilder<GrupoDeVeiculo> builder)
        {
            builder.ToTable("TBGrupoDeVeiculos");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();

        }
    }
}
