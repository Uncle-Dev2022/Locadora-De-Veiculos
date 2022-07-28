using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    public class MapeadorVeiculoOrm : MapeadorBaseOrm<Veiculo>
    {
        public override void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Marca).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Modelo).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.AnoModelo).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.TipoCombustivel).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("VARCHAR(7)").IsRequired();
            builder.Property(x => x.Quilometragem).HasColumnType("DECIMAL(18, 0)").IsRequired();
            builder.Property(x => x.CapacidadeTanque).HasColumnType("INT").IsRequired();
            builder.Property(x => x.Imagem).HasColumnType("VARBINARY(MAX)").IsRequired();
            builder.HasOne(x => x.GrupoDeVeiculo);
        }
    }

}
