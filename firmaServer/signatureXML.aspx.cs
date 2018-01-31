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

using Viafirma;
using System.IO;
using System.Globalization;
using System.Reflection;
using ViafirmaClientDotNet.Helpers.Policy;

namespace EjemploWebViafirmaClientDotNet.firmaServer
{
    public partial class signatureXML : System.Web.UI.Page
    {
        public string idFirma;
        protected void Page_Load(object sender, EventArgs e)
        {
            idFirma = "";
        }

        public void FirmarServerXMLButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);
           
            // Enviamos a firmar el documento
           
            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");


            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "prueba.xml";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = typeFormatSign.XADES_EPES_ENVELOPED;
            doc.tipo = typeFile.XML;

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.XADES_EPES_ENVELOPED, typeSign.ENVELOPED);

            // Enviamos a firmar el documento al servidor y nos devuelve el identificador de la firma.
            idFirma = clienteViafirma.SignByServerWithPolicy(pol, doc, Global.ALIAS, Global.PASS_CERT);

            // Generamos la url a la página que gestiona la comunicación con Viafirma.
            //Uri url = new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/ResultadoFirmaServidor.aspx"));
            //Log.Debug("Redireccionado al usuario a: " + url);

            // Guardamos el Id de Firma
            HttpContext.Current.Session["idFirma"] = idFirma;
            
            // Redirecciona a la url
            //HttpContext.Current.Response.Redirect(url.AbsoluteUri);
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
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "Documento_firmado_servidor.xml");
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
