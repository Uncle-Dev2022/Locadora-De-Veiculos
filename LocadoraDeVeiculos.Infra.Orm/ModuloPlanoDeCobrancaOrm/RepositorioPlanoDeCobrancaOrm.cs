using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobrancaOrm
{
    public class RepositorioPlanoDeCobrancaOrm : RepositorioBaseOrm<PlanoDeCobranca, MapeadorPlanoDeCobrancaOrm>, IRepositorioPlanoDeCobranca
    {
        public RepositorioPlanoDeCobrancaOrm(LocadoraDeVeiculosDbContext db) : base(db)
        {
        }

        public PlanoDeCobranca SelecionarPlanoDeCobrancaPorNome(string nome)
        {
            return Dados.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
