using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public double valor;
        public string descricao;
        public TipoCalculo tipoCalculo;

        public Taxa()
        {
        }

        public Taxa(double valor, string descricao, TipoCalculo tipoCalculo)
        {
            this.valor = valor;
            this.descricao = descricao;
            this.tipoCalculo = tipoCalculo;
        }
        public override bool Equals(object obj)
        {
            Taxa t = obj as Taxa;
            if (t == null)
                return false;

            return t.descricao == this.descricao &&
                t.valor == this.valor && t.tipoCalculo == this.tipoCalculo;
        }
    }
}
