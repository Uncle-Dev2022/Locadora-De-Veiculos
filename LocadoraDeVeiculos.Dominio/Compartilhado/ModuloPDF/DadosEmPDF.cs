using LocadoraDeVeiculos.Dominio.Compartilhado;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado.ModuloPDF
{
    public class DadosEmPDF<T> where T : EntidadeBase<T>
    {
        public PdfPage[] paginas;        
        public DadosEmPDF(IContextoPDF<T> registro)
        {
            paginas = registro.GerarDados();            
            
        }
    }
}
