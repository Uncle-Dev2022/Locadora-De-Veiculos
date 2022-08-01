using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
//using PdfSharp.Drawing;
//using PdfSharp.Pdf;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using static PdfSharpCore.Pdf.PdfDictionary;
using System.Collections.Generic;
using PdfSharpCore.Pdf.IO;

namespace ConsolePDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();            

            Classe classe = new Classe("asdasd", 3);
            string classeEmString = JsonConvert.SerializeObject(classe,Formatting.Indented, new JsonConverter[] { }); 
            byte[] classeEmBytes = Encoding.UTF8.GetBytes(classeEmString);
            //JsonConvert.DeserializeObject<byte[]>(classeEmString);
            StringReader reader = new StringReader(classeEmString);
            
            //reader.ReadToEnd();

            JsonTextReader jsonReader = new JsonTextReader(reader);
            //StringWriter sw = new StringWriter();
            //JsonTextWriter jsonWriter = new JsonTextWriter(sw);
            //JsonWriter writer = new JsonTextWriter(sw);
            //BinaryReader binaryFormatter = new BinaryReader(memoryStream, Encoding.UTF8);

            PdfDictionary dictionaries = new PdfDictionary(document);
            
            
            /*
                try
                {
                    //PdfStream stream = dictionaries.CreateStream(classeEmBytes);
                    PdfPage page = document.AddPage();
                
                    //PdfStream stream = page.CreateStream(classeEmBytes);
                    //page.Stream = stream;
                    page.Close();
                }
                catch (JsonReaderException x)
                {
                    Console.WriteLine(x.StackTrace);
                    Console.WriteLine(x.Message);
                } 
            */

            //PdfPage page = document.AddPage();
            //PdfStream stream = page.CreateStream(classeEmBytes);
            //page.Stream = stream;
            //page.Close();
            //MemoryStream memoryStream = new MemoryStream(classeBytes);

            document.Info.Title = "Title";
            
            PdfPage page = document.AddPage();
            
            //page.Contents.AppendContent();
            
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 20);

            XPen xPen = new XPen(XColor.FromKnownColor(XKnownColor.Black), 10);             
            XPoint xPoint1 = new XPoint(30, 30);

            gfx.DrawLine(xPen, new XPoint(0, 0), new XPoint(0, page.Height));
            gfx.DrawLine(xPen, new XPoint(page.Width, 0), new XPoint(page.Width, page.Height));
            gfx.DrawLine(xPen, new XPoint(0, 0), new XPoint(page.Width, 0));
            gfx.DrawLine(xPen, new XPoint(0, page.Height), new XPoint(page.Width, page.Height));
            
            gfx.DrawString(classeEmString, font, XBrushes.Black, xPoint1);            
            //gfx.DrawString(classeEmString, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            //gfx.DrawString(classeEmString, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height));

            document.Close();
            document.Save("teste2.pdf");

        }
    }
    [Serializable]
    public class Classe
    {
        [JsonProperty]
        public string e;
        [JsonProperty]
        public int b;
        public Classe(string e, int b)
        {
            this.e = e;
            this.b = b;
        }
        public Classe()
        {

        }
    }
}