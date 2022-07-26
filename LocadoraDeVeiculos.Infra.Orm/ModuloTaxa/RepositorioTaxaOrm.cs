using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxa
{
    public class RepositorioTaxaOrm : RepositorioBaseOrm<Taxa, MapeadorTaxaOrm>
    {

        public RepositorioTaxaOrm(LocadoraDeVeiculosDbContext db)
        {
            this.db = db;
            Dados = db.Set<Taxa>();
        }
        public override void Editar(Taxa registro)
        {
            throw new NotImplementedException();
        }

        public override void Excluir(Taxa registro)
        {
            throw new NotImplementedException();
        }

        public Taxa SelecionarPorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }

        public override Taxa SelecionarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public override List<Taxa> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
