using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados : RepositorioBaseEmBancoDeDados<Cliente, ValidadorCliente, MapeadorCliente>
    {
    }
}
