using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculosOrm : RepositorioBaseOrm<GrupoDeVeiculo, MapeadorGrupoDeVeiculosOrm>
    {
        public RepositorioGrupoDeVeiculosOrm(LocadoraDeVeiculosDbContext db)
        {
            this.db = db;
            Dados = db.Set<GrupoDeVeiculo>();
        }

        public GrupoDeVeiculo SelecionarGrupoDeVeiculoPorNome(string nome)
        {
            return Dados.FirstOrDefault(x => x.Nome == nome);
        }

    }
}
