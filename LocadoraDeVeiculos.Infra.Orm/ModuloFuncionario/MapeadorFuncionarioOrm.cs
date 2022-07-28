using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm : MapeadorBaseOrm<Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(150)").IsRequired();
            builder.Property(x => x.DataAdmissao).IsRequired();
            builder.Property(x => x.Senha).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Login).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Gerente).IsRequired();
        }
    }

}
