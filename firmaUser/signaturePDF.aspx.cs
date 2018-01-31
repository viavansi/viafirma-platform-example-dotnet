using System;
using System.Web;
using System.Web.UI.WebControls;
using Viafirma;
using System.IO;
using System.Reflection;
using ViafirmaClientDotNet.Helpers.Policy;

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class signaturePDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FirmarUserPDFButton_Click(object sender, EventArgs e) 
        {
            typeFormatSign typeFormatSign = typeFormatSign.PDF_PKCS7;
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "PDF_PKCS7":
                    typeFormatSign = typeFormatSign.PDF_PKCS7;
                    break;
                case "PDF_PKCS7_T":
                    typeFormatSign = typeFormatSign.PDF_PKCS7_T;
                    break;
                case "PAdES_BASIC":
                    typeFormatSign = typeFormatSign.PAdES_BASIC;
                    break;
                case "PAdES_BES":
                    typeFormatSign = typeFormatSign.PAdES_BES;
                    break;
                case "PAdES_EPES":
                    typeFormatSign = typeFormatSign.PAdES_EPES;
                    break;
            }

            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // Enviamos a firmar el documento

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            try
            {
                System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");
            }
            catch (System.Web.Services.Protocols.SoapException exc)
            {
                System.Console.WriteLine(exc.Message);
            }
            

            // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
            // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
            string idTemporalFirma = null;
            try
            {
                //Creamos el objeto documento con los datos a firmar
                documento doc = new documento();
                doc.nombre = "FicheroEjemplo.pdf";
                doc.datos = datos_a_firmar;
                doc.typeFormatSign = typeFormatSign;
                doc.tipo = typeFile.PDF;

                // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
                // Comprobar que efectivamente el servidor de firma está disponible
                System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

                //Creamos la politica de firma
                policy pol = PolicyUtil.newPolicy(typeFormatSign, typeSign.ENVELOPED);


                // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
                // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
                idTemporalFirma = clienteViafirma.PrepareSignWithPolicy(pol, doc);

                System.Console.Write("idTemporalFirma: " + idTemporalFirma);
            }
            catch (Exception exc)
            {
                System.Console.WriteLine(exc.Message);
                String messageError = exc.Message;
                Uri url = new Uri(HttpContext.Current.Request.Url, HttpContext.Current.Response.ApplyAppPathModifier("~/errorPage.aspx?errorMessage=" + exc.Message));
                HttpContext.Current.Response.Redirect(url.AbsoluteUri);
                return;
            }
            System.Console.Write("idTemporalFirma: " + idTemporalFirma);

            //Logica del ejemplo para descagar el fichero con la extension correcta
            Session["extension"] = ".pdf";

            // Iniciamos el proceso de firma redireccionando al usuario a Viafirma..
            // Esto redireccionará al usuario a Viafirma para la firma del documento con el 
            // identificador de firma indicado.
            clienteViafirma.Sign(idTemporalFirma);
        }
    }
}
