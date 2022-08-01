using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado.ModuloPDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Pdf.Compartilhado
{
    public interface IGeradorPDF
    {
        void GravarDados<T>(DadosEmPDF<T> dados) where T : EntidadeBase<T>;
    }
}
