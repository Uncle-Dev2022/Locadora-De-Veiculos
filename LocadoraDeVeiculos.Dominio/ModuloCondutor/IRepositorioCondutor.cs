using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public interface IRepositorioCondutor : IRepositorio<Condutor>
    {
        Condutor SelecionarCondutorPorCPF(string cPF);
        Condutor SelecionarCondutorPorNome(string nome);
        Condutor SelecionarCondutorPorCNH(string cNH);
    }
}
