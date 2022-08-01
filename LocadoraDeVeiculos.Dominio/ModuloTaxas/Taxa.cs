using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado.ModuloPDF;
using PdfSharpCore.Pdf;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class Taxa : EntidadeBase<Taxa>, IContextoPDF
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

        public PdfPage[] GerarDados()
        {
            PdfDictionary dictionaries = new PdfDictionary(new PdfDocument());

            dictionaries.CreateStream(new byte[3]);
            
            throw new System.NotImplementedException();
        }
    }
}
