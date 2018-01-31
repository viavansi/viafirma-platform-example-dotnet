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
using ViafirmaClientDotNet.Helpers.Policy;
using System.Reflection;


namespace EjemploWebViafirmaClientDotNet.firmaPolicy
{
    public partial class firmarSelloTodasPaginas : System.Web.UI.Page
    {
       

        public void Firmar_Button_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH_10_PAGS);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            //Obtengo la imagen a estampar
            Stream stampImage = assembly.GetManifestResourceStream(Global.DEMO_STAMPER_PATH);
            byte[] image = new byte[stampImage.Length];
            stampImage.Read(image, 0, image.Length);
            String imageB64 = System.Convert.ToBase64String(image);


            // Enviamos a firmar el documento

            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "PDF_SELLOIMAGEN.pdf";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = typeFormatSign.PAdES_BASIC;
            doc.tipo = typeFile.PDF;

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.PAdES_BASIC, typeSign.ATTACHED);

            //Al indicar como página el caráter especial "0", la platforma entiende que se desea incorporar el justificante de firma en TODAS las paginas
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_PAGE, "0");
            
            //Se puede insertar justificantes en varias páginas (no todas) del siguiente modo

            //ArrayList pages = new ArrayList();
            //pages.Add("1"); //Se puede usar -1 para referenciar a la última página
            //pages.Add("3");
            //pages.Add("5");
            //pages.Add("7");
            //pages.Add("9");
            //PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_PAGE, PolicyUtil.ObjectToJson(pages));

           
            //Creamos el rectangle
            rectangle r = PolicyUtil.newRectangle(100, 0, 400, 15);
            //Seteamos la politica
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_RECTANGLE, PolicyUtil.rectangleToJson(r));
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_HIDE_STATUS, "true");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_TEXT, "Firmado por [CN] - NIF [SERIALNUMBER] - [vCSVKey]");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_TRANSPARENT_BACKGROUND, "true");
            
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
