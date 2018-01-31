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
using System.Reflection;
using ViafirmaClientDotNet.Helpers.Policy;

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class signaturePDFImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FirmarUserPDFImageButton_Click(object sender, EventArgs e) 
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
            _rectangle.x = 120;
            _rectangle.y = 50;

            // Enviamos a firmar el documento
            
            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "FicheroEjemplo.pdf";
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

            // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
            // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
            string idTemporalFirma = clienteViafirma.PrepareSignWithPolicy(pol, doc);

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
