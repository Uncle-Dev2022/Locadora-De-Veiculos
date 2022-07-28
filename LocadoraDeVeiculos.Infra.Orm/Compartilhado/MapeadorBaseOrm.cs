using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public abstract class MapeadorBaseOrm<T> : IEntityTypeConfiguration<T> where T : EntidadeBase<T>
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
