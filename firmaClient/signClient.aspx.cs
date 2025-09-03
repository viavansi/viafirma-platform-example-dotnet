using System;

using System.Web;

using Viafirma;
using System.IO;
using ViafirmaClientDotNet.Helpers.Policy;
using System.Reflection;


namespace EjemploWebViafirmaClientDotNet.firmaClient
{
    public partial class signClient : System.Web.UI.Page
    {

        public string signId;
        protected void Page_Load(object sender, EventArgs e)
        {
            signId = "";
        }

     /*   public void signByClient(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            //Obtengo el certificado con el cual voy a firmar
            Stream certificate = assembly.GetManifestResourceStream(Global.DEMO_P12_PATH);
            String certificatePass = "absis";


            // Enviamos a firmar el documento

            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "clientSigned.pdf";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = typeFormatSign.PAdES_BASIC;
            doc.tipo = typeFile.PDF;

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.PAdES_BASIC, typeSign.ATTACHED);

           //pol.previousTypeFormatSign = typeFormatSign.PAdES_BASIC;

            PolicyUtil.AddParameter(pol, PolicyParams.SIGNATURE_ALGORITHM, "SHA1withRSA");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGEST_METHOD, "SHA1");

            //Logica del ejemplo para descagar el fichero con la extension correcta
            Session["extension"] = ".pdf";

            //Hacemos la llamada a la firma en cliente
            signId = clienteViafirma.SignByClient(certificate, certificatePass, pol, doc);

            // Guardamos el Id de Firma
            HttpContext.Current.Session["signId"] = signId;
        }*/

        public void signByClient(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            //Obtengo el certificado con el cual voy a firmar
            Stream certificate = assembly.GetManifestResourceStream(Global.DEMO_P12_PATH);
            String certificatePass = "absis";


            // Enviamos a firmar el documento

            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "clientSigned.xml";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = typeFormatSign.XADES_T_ENVELOPED;
            doc.tipo = typeFile.XML;

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.XADES_T_ENVELOPED, typeSign.ENVELOPED);


            PolicyUtil.AddParameter(pol, PolicyParams.NODE_ID_TO_SIGN, "EXP_INDICE_CONTENIDOES_L09899999_2022_EXP_000000000000000000000005151220");
            PolicyUtil.AddParameter(pol, PolicyParams.ENVELOPED_TARGET_NODE, "/*[local-name()='expediente']/*[local-name()='indice']/*[local-name()='firmas']/*[local-name()='firma']/*[local-name()='ContenidoFirma']/*[local-name()='FirmaConCertificado']");

            PolicyUtil.AddParameter(pol, PolicyParams.SIGNATURE_ALGORITHM, "SHA1withRSA");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGEST_METHOD, "SHA1");

            //Logica del ejemplo para descagar el fichero con la extension correcta
            Session["extension"] = ".xml";

            //Hacemos la llamada a la firma en cliente
            signId = clienteViafirma.SignByClient(certificate, certificatePass, pol, doc);

            // Guardamos el Id de Firma
            HttpContext.Current.Session["signId"] = signId;
        }

        public void DownloadButton_Click(object sender, EventArgs e)
        {
            // The file path to download.
            // The file name used to save the file to the client's system..
            System.IO.Stream stream = null;
            Viafirma.ViafirmaClient clienteViafirma = Viafirma.ViafirmaClientFactory.GetInstance();
            String id = (string)Session["signId"];
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
