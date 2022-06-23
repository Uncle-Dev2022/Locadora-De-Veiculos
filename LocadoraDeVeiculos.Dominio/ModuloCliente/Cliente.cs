using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        protected string Nome;
        protected string Endereco;
        protected string Email;
        protected string Telefone;

    }
}
