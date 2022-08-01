using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobrancaOrm
{
    public class RepositorioPlanoDeCobrancaOrm : RepositorioBaseOrm<PlanoDeCobranca, MapeadorPlanoDeCobrancaOrm>, IRepositorioPlanoDeCobranca
    {
        public RepositorioPlanoDeCobrancaOrm(IContextoPersistencia db) : base(db)
        {
        }

        public PlanoDeCobranca SelecionarPlanoDeCobrancaPorNome(string nome)
        {
            return Dados.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
