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
        public RepositorioTaxaOrm(LocadoraDeVeiculosDbContext db) : base(db)
        {
        }

        public Taxa SelecionarPorDescricao(string descricao)
        {
            return Dados.FirstOrDefault(x => x.descricao == descricao);
        }
    }
}
