using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class MapeadorCondutorOrm : MapeadorBaseOrm<Condutor>
    {
        public override void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(70)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.CPF).HasColumnType("VARCHAR(70)").IsRequired();
            builder.Property(x => x.CNH).HasColumnType("VARCHAR(70)");
            builder.Property(x => x.Email).HasColumnType("VARCHAR(70)").IsRequired();
            builder.HasOne(x => x.cliente);
        }
    }
}
