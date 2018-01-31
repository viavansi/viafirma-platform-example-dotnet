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

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class signaturePreviousSigned : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FirmarPreviousSignedButton_Click(object sender, EventArgs e)
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
            doc.typeFormatSign = typeFormatSign.XADES_BES;
            doc.tipo = typeFile.XML;

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.XADES_BES, typeSign.ENVELOPED);


            // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
            // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
            string idFirma = clienteViafirma.PrepareSignWithPolicy(pol, doc);

            System.Console.Write("idFirma: " + idFirma);

            //Logica del ejemplo para descagar el fichero con la extension correcta
            Session["extension"] = ".xml";

            // Iniciamos el proceso de refirmado redireccionando al usuario a Viafirma.
            // Esto redireccionará al usuario a Viafirma para que firme de nuevo el documento
            // con el identificador de firma indicado.
            clienteViafirma.signPreviousSignature(idFirma);
           
        }
    }
}
