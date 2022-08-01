using LocadoraDeVeiculos.Dominio.Compartilhado.ModuloPDF;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IContextoPDF<T> where T : EntidadeBase<T>
    {
        DadosEmPDF<T> GerarDados();
    }
}
