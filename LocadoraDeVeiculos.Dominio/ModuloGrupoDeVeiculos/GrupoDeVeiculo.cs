using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public class GrupoDeVeiculo : EntidadeBase
    {
        public String Nome { get; set; }

        public GrupoDeVeiculo()
        {

        }

        public GrupoDeVeiculo(string nome)
        {
            Nome = nome;
        }
    }
}
