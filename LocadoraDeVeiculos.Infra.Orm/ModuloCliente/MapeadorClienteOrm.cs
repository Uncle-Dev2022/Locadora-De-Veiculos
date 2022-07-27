using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCliente
{
    public class MapeadorClienteOrm : MapeadorBaseOrm<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCliente");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.CPF_CNPJ).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Endereco).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.CNH).HasColumnType("VARCHAR(50)");
            builder.Property(x => x.tipoCliente);
            
        }
    }
}
