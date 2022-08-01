using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculosOrm : RepositorioBaseOrm<GrupoDeVeiculo, MapeadorGrupoDeVeiculosOrm>
    {
        public RepositorioGrupoDeVeiculosOrm(IContextoPersistencia db) : base(db)
        {
        }

        public GrupoDeVeiculo SelecionarGrupoDeVeiculoPorNome(string nome)
        {
            return Dados.FirstOrDefault(x => x.Nome == nome);
        }

    }
}
