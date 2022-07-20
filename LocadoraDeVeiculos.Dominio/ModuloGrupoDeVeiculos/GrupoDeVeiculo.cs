using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos
{
    public class GrupoDeVeiculo : EntidadeBase<GrupoDeVeiculo>
    {
        public String Nome { get; set; }

        public GrupoDeVeiculo()
        {

        }

        public GrupoDeVeiculo(string nome)
        {
            Nome = nome;
        }


        public override bool Equals(object obj)
        {
            GrupoDeVeiculo gv = obj as GrupoDeVeiculo;

            if (gv == null)
                return false;

            return
                gv.Id.Equals(Id) &&
                gv.Nome.Equals(Nome);
        }

        public GrupoDeVeiculo Clone()
        {
            return MemberwiseClone() as GrupoDeVeiculo;
        }
        public override string ToString()
        {
            return Nome;

        }


    }
}
