using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : RepositorioBaseOrm<Taxa, MapeadorTaxaOrm>, IRepositorioTaxa
    {
        public RepositorioTaxaOrm(IContextoPersistencia db) : base(db)
        {
        }

        public Taxa SelecionarPorDescricao(string descricao)
        {
            return Dados.FirstOrDefault(x => x.descricao == descricao);
        }
    }
}
