using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao
{
    public class MapeadorDevolucaoOrm : MapeadorBaseOrm<Devolucao>
    {
        public override void Configure(EntityTypeBuilder<Devolucao> builder)
        {
            builder.ToTable("TBDevolucao");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.QuilometragemDevolucao).HasColumnType("INT").IsRequired();
            builder.Property(x => x.DataDevolucao).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.NivelGasolina).HasConversion<string>();

            builder.HasMany(x => x.TaxasAdicionais).WithMany(x => x.Devolucoes);
            builder.Property(x => x.LocacaoId).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(x => x.Locacao).WithMany().HasForeignKey(x => x.LocacaoId).OnDelete(DeleteBehavior.Restrict);
        }


    }
}
