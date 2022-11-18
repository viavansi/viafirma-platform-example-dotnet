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

namespace EjemploWebViafirmaClientDotNet.firmaServer
{
    public partial class signaturePDF : System.Web.UI.Page
    {
        public string idFirma;
        protected void Page_Load(object sender, EventArgs e)
        {
            idFirma = "";
        }

        public void FirmarServerPDFButton_Click(object sender, EventArgs e)
        {

            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            //Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            //byte[] datos_a_firmar = new byte[fs.Length];
            //fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            byte[] datos_a_firmar = File.ReadAllBytes("C:\\Users\\ruben\\Downloads\\20200330_Firma_Portafirmas-Externos.pdf");


            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            //Creamos el objeto documento con los datos a firmar
            typeFormatSign tipoFirma = typeFormatSign.PAdES_BES;
            documento doc = new documento();
            doc.nombre = "PDF_SELLOIMAGEN.pdf";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = tipoFirma;
            doc.tipo = typeFile.PDF;

            //Obtengo la imagen a estampar
            Stream stampImage = assembly.GetManifestResourceStream(Global.DEMO_STAMPER_PATH);
            byte[] image = new byte[stampImage.Length];
            stampImage.Read(image, 0, image.Length);
            String imageB64 = System.Convert.ToBase64String(image);

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(tipoFirma, typeSign.DETACHED);

            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_PAGE, "1");
            //Creamos el rectangle
            rectangle r = PolicyUtil.newRectangle(40, 100, 300, 240);
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_RECTANGLE, PolicyUtil.rectangleToJson(r));
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_IMAGE_STAMPER, imageB64);
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_TEXT, "Prueba Firmado por [CN]\ncon DNI [SERIALNUMBER]\ntrabajador de [O]\nen el departamento de [OU]");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_HIDE_STATUS, "true");

            idFirma = clienteViafirma.SignByServerWithPolicy(pol,doc, Global.ALIAS, Global.PASS_CERT);



            //Obtengo la infirmación del documento firmado
            byte[] signedDoc = clienteViafirma.getDocumentoCustodiado(idFirma);
            firmaInfoViafirma info = clienteViafirma.getSignInfo(idFirma);
            string signTimeStamp = info.signTimeStamp;
            //tsa_cert_notafter
            usuarioGenericoViafirmaEntry[] usersInfo = info.properties;
            foreach (usuarioGenericoViafirmaEntry userInfo in usersInfo)
            {
                if ("tsa_cert_notafter".Equals(userInfo.key))
                {
                    Console.WriteLine(userInfo.value);
                }
            }

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


            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "FicheroEjemplo.pdf";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = typeFormatSign.PDF_PKCS7_T;
            doc.tipo = typeFile.PDF;

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.PDF_PKCS7_T, typeSign.ENVELOPED);

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
