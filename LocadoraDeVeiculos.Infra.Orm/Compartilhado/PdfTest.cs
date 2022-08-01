using PdfSharp.Pdf;
//using PdfSharp.Drawing;
using PdfSharp.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public class PdfTest
    {
        public static void main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();

            document.Info.Title = "adad";
            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 20);
               
            XPen xPen = new XPen(XColor.FromKnownColor(XKnownColor.Black));

            XPoint xPoint1 = new XPoint();
            xPoint1.X = 2.3;
            
            gfx.DrawLine(xPen, xPoint1, new XPoint());
            gfx.DrawString("Dads", font, XBrushes.Black, xPoint1);
            gfx.DrawString("Dads", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("Dads", font, XBrushes.Black, xPoint1);

            document.Save("D\\teste.pdf");

        }
    }
}
