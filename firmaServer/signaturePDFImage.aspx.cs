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
using System.Reflection;
using ViafirmaClientDotNet.Helpers.Policy;

namespace EjemploWebViafirmaClientDotNet.firmaServer
{
    public partial class signaturePDFImage : System.Web.UI.Page
    {
        public string idFirma;
        protected void Page_Load(object sender, EventArgs e)
        {
            idFirma = "";
        }

        public void FirmarServerPDFImageButton_Click(object sender, EventArgs e)
        {

            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            //Recuperamos la imagen de sello
            Stream fsImage = assembly.GetManifestResourceStream(Global.DEMO_IMAGE_LOGO_PATH);
            byte[] image = new byte[fsImage.Length];
            fsImage.Read(image, 0, image.Length);
            String imageB64 = System.Convert.ToBase64String(image);


            //Creamos el rectangle donde se posicionará el sello
            rectangle _rectangle = new rectangle();
            _rectangle.height = 50;
            _rectangle.width = 100;
            _rectangle.x = 200;
            _rectangle.y = 100;

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "FicheroEjemploServer.pdf";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = typeFormatSign.PDF_PKCS7;
            doc.tipo = typeFile.PDF;

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.PDF_PKCS7, typeSign.ENVELOPED);

            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_PAGE, "1");
            //creamos el rectangle
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_RECTANGLE, PolicyUtil.rectangleToJson(_rectangle));
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_HIDE_STATUS, "true");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_IMAGE_STAMPER, imageB64);

            // Enviamos a firmar el documento al servidor y obtenemos el identificador final de la firma.
            idFirma = clienteViafirma.SignByServerWithPolicy(pol, doc, Global.ALIAS, Global.PASS_CERT);

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
