using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado.ModuloPDF;
using System.Text;
using System.IO;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Linq;
using System;

namespace LocadoraDeVeiculos.Infra.Pdf.Compartilhado
{
    public class GeradorDePdfContext : IGeradorPDF
    {
        static XPen xPen = new XPen(XColor.FromKnownColor(XKnownColor.Black), 10);
        static XFont font = new XFont("Arial", 20);        
        string caminhoArquivo;
        public GeradorDePdfContext(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }
        public void GravarDados<T>(DadosEmPDF<T> dados) where T : IContextoPDF
        {
            PdfDocument documento = new PdfDocument();
            
            documento.Info.Title = "Title";

            PdfPage[] paginas = dados.paginas;
            
            XGraphics gfx;

            foreach (PdfPage item in paginas)
            {

                gfx = XGraphics.FromPdfPage(item);
                GerarContorno(gfx);
                GerarLinha(gfx);
                documento.AddPage(item);
            }
            documento.Close();
            documento.Save(caminhoArquivo + documento.Info.Title + DateTime.Now + ".pdf");
        }

        private void GerarContorno(XGraphics gfx)
        {            
            gfx.DrawLine(xPen, new XPoint(0, 0), new XPoint(0, gfx.PdfPage.Height));
            gfx.DrawLine(xPen, new XPoint(gfx.PdfPage.Width, 0), new XPoint(gfx.PdfPage.Width, gfx.PdfPage.Height));
            gfx.DrawLine(xPen, new XPoint(0, 0), new XPoint(gfx.PdfPage.Width, 0));
            gfx.DrawLine(xPen, new XPoint(0, gfx.PdfPage.Height), new XPoint(gfx.PdfPage.Width, gfx.PdfPage.Height));
        }
        private void GerarLinha(XGraphics gfx)
        {
            //gfx.DrawString(classeEmString, font, XBrushes.Black, xPoint1);
            //gfx.DrawString(classeEmString, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            //gfx.DrawString(classeEmString, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height));
            gfx.DrawString("Dads", font, XBrushes.Black, new XPoint());
            gfx.DrawString("Dads", font, XBrushes.Black, new XRect(0, 0, gfx.PdfPage.Width, gfx.PdfPage.Height), XStringFormats.Center);
            gfx.DrawString("Dads", font, XBrushes.Black, new XPoint());

            XRect rect = new XRect(new XPoint(0, 0), new XPoint(0, 0));
            
        }
    }
}
