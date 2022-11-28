using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.IO;
using Viafirma;
using ViafirmaClientDotNet.Helpers.Policy;
using System.Reflection;
using System.Text;

namespace EjemploWebViafirmaClientDotNet.firmaServer
{
    public partial class signaturePDFPolicy : System.Web.UI.Page
    {
        public string idFirma;

        protected void Page_Load(object sender, EventArgs e)
        {
            idFirma = "";
        }


        private static void CompleteRead(IAsyncResult result)
        {
            FileStream strm = (FileStream)result.AsyncState;
            int size = strm.EndRead(result);

            strm.Close();
            //this is an example how to read data.
            Console.WriteLine(BitConverter.ToString(datos_a_firmar_grande, 0, size));
        }

        public static byte[] datos_a_firmar_grande;

        public void FirmarServerPDFButton_Click(object sender, EventArgs e)
        {

            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            //string path = Environment.CurrentDirectory;
            //FileStream fs = File.OpenRead(path + "\\resources\\exampleSign.pdf");

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            //byte[] datos_a_firmar = File.ReadAllBytes(@"C:\598MB.pdf");

            //FileStream strm = new FileStream(@"C:\598MB.pdf", FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);

            //datos_a_firmar_grande = new byte[strm.Length];
            //IAsyncResult result = strm.BeginRead(datos_a_firmar_grande, 0, datos_a_firmar_grande.Length, new AsyncCallback(CompleteRead), strm);
            


            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            // Enviamos a firmar el documento al servidor y obtenemos el identificador final de la firma.
            //idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.pdf", datos_a_firmar, Global.ALIAS, Global.PASS_CERT, typeFile.PDF, typeFormatSign.PDF_PKCS7);





            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "PDF_ejemplo.pdf";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = typeFormatSign.PAdES_LTV;
            doc.tipo = typeFile.PDF;

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.PAdES_LTV, typeSign.ATTACHED);

            idFirma = clienteViafirma.SignByServerWithPolicy(pol,doc, Global.ALIAS_CERT, Global.PASS_CERT);

            // Generamos la url a la página que gestiona la comunicación con Viafirma.
            // Uri url = new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/ResultadoFirmaServidor.aspx"));
            // Log.Debug("Redireccionado al usuario a: " + url);
           
            // Guardamos el Id de Firma
             HttpContext.Current.Session["idFirma"] = idFirma;
            
            // Redirecciona a la url
            // HttpContext.Current.Response.Redirect(url.AbsoluteUri);
        }

        public void FirmarServerPDFButton_T_Click(object sender, EventArgs e)
        {

            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            //string path = Environment.CurrentDirectory;
            //FileStream fs = File.OpenRead(path + "\\resources\\exampleSign.pdf");
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            // Enviamos a firmar el documento al servidor y obtenemos el identificador final de la firma.
            idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.pdf", datos_a_firmar, Global.ALIAS_CERT, Global.PASS_CERT, typeFile.PDF, typeFormatSign.PDF_PKCS7_T);

            // Generamos la url a la página que gestiona la comunicación con Viafirma.
            // Uri url = new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/ResultadoFirmaServidor.aspx"));
            // Log.Debug("Redireccionado al usuario a: " + url);

            // Guardamos el Id de Firma
            HttpContext.Current.Session["idFirma"] = idFirma;

            // Redirecciona a la url
            // HttpContext.Current.Response.Redirect(url.AbsoluteUri);
        }

        public void DownloadButton_Click(object sender, EventArgs e)
        {
            // The file path to download.
            // The file name used to save the file to the client's system..
            System.IO.Stream stream = null;
            Viafirma.ViafirmaClient clienteViafirma = Viafirma.ViafirmaClientFactory.GetInstance();
            String id = (string)Session["idFirma"];
            byte[] documento = clienteViafirma.getDocumentoCustodiado(id);

            try
            {
                // Open the file into a stream. 
                stream = new System.IO.MemoryStream(documento);
                // Total bytes to read: 
                long bytesToRead = stream.Length;
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "Documento_firmado_servidor.pdf");
                Response.Buffer = true;
                ((System.IO.MemoryStream)stream).WriteTo(Response.OutputStream);
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                // An error occurred.. 
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                Response.End();
            }
        }
    }
}
