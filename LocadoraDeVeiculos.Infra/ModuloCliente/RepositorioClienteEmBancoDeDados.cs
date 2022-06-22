using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados : RepositorioBaseEmBancoDeDados<Cliente, ValidadorCliente, MapeadorCliente>
    {
        protected override string sqlInserir => "";

        protected override string sqlEditar => "";


        protected override string sqlExcluir => "";


        protected override string sqlSelecionarPorId => "";


        protected override string sqlSelecionarTodos => "";
    }
}
