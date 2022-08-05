using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacaoOrm : MapeadorBaseOrm<Locacao>
    {
        public override void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TBLocacao");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.dataDeLocacao).IsRequired();
            builder.Property(x => x.dataDeDevolucaoPrevista).IsRequired();
            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.Condutor);
            builder.HasOne(x => x.GrupoDeVeiculo);
            builder.HasOne(x => x.veiculo);
            builder.HasOne(x => x.planoDeCobranca);
            builder.HasOne(x => x.funcionario);
            builder.HasMany(x => x.Taxas);
        }
    }
}
