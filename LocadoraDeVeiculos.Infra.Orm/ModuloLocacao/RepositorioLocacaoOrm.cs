using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
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
    }
}
