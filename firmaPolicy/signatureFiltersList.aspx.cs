using System;
using System.Collections.Generic;
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
    public partial class signatureFiltersList : System.Web.UI.Page
    {
       

        public void Firmar_Button_Click(object sender, EventArgs e)
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

            // Solo certificados con:
            // O="FMNT" o (1.3.6.1.4.1.5734.1.8 existe e ISSUER.CN="AVANSI CERTIFICADOS DIGITALES")

            List<Dictionary<String, String>> filters = new List<Dictionary<String, String>>();

            Dictionary<String, String> filter1 = new Dictionary<String, String>();
            filter1.Add("O", "FNMT");
            
            Dictionary<String, String> filter2 = new Dictionary<String, String>();
            filter2.Add("1.3.6.1.4.1.5734.1.8", "*");
            filter2.Add("ISSUER.CN", "AVANSI CERTIFICADOS DIGITALES");

            filters.Add(filter1);
            filters.Add(filter2);

            PolicyUtil.AddParameter(pol, PolicyParams.FILTER_CERTIFICATE_BY, PolicyUtil.ObjectToJson(filters));
          
            
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
