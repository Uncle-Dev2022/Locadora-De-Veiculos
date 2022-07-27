using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : RepositorioBaseOrm<Cliente,MapeadorClienteOrm>
    {
        public RepositorioClienteOrm(LocadoraDeVeiculosDbContext db) : base(db)
        {
            Dados = db.Set<Cliente>();
        }

        public Cliente SelecionarClientePorNome(string nome)
        {
            return Dados.FirstOrDefault(x => x.Nome == nome);
        }

        public Cliente SelecionarClientePorCPFOuCNPJ(string CPF_CNPJ)
        {
            return Dados.FirstOrDefault(x => x.CPF_CNPJ == CPF_CNPJ);
        }
    }
}
