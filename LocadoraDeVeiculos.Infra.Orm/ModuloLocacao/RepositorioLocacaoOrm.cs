using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : RepositorioBaseOrm<Locacao, MapeadorLocacaoOrm>, IRepositorioLocacao
    {
        public RepositorioLocacaoOrm(IContextoPersistencia db) : base(db)
        {

        }

        public override List<Locacao> SelecionarTodos()
        {
            return Dados.Include(x => x.Condutor)
                .Include(x => x.Cliente)
                .Include(x => x.funcionario)
                .Include(x => x.planoDeCobranca).ThenInclude(x => x.grupoDeVeiculo)
                .Include(x => x.Taxas)
                .Include(x => x.veiculo).ThenInclude(x => x.GrupoDeVeiculo)
                .ToList();
        }
    }
}
