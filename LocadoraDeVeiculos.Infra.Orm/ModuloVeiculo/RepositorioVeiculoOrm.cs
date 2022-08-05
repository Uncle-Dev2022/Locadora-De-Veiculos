using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : RepositorioBaseOrm<Veiculo,
        MapeadorVeiculoOrm>,IRepositorioVeiculo
    {
        public RepositorioVeiculoOrm(IContextoPersistencia db) : base(db)
        {
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return Dados.FirstOrDefault(x => x.Placa == placa);
        }

    }
}
