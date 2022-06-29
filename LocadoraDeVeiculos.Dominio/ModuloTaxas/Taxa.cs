using System;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public double valor;
        public string descricao;

        public Taxa()
        {
        }

        public Taxa(double valor, string descricao)
        {
            this.valor = valor;
            this.descricao = descricao;
        }
        public override bool Equals(object obj)
        {
            Taxa t = obj as Taxa;
            if (t == null)
                return false;
            
            return t.descricao == this.descricao && t.valor == this.valor;
        }
    }
}
