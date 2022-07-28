using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : RepositorioBaseOrm<Veiculo,
        MapeadorVeiculoOrm>
    {
        public RepositorioVeiculoOrm(LocadoraDeVeiculosDbContext db) : base(db)   
        {
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return Dados.FirstOrDefault(x => x.Placa == placa);
        }

    }
}
