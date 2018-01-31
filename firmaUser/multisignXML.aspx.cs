using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viafirma;
using System.IO;

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class multisignXML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["firmar"] != null)
            {
                MultiSign_OnClick(null,null);
            }
        }

        public void MultiSign_OnClick(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            string path = Environment.CurrentDirectory;
            FileStream fs = File.OpenRead(path + "\\resources\\prueba.xml");
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // Enviamos a firmar el documento

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
            // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
            String idFirma;
            if (Request["idMultifirma"] != null)
            {
                idFirma = Request["idMultifirma"];
                Session.Add("idMultifirma", idFirma);
            }
            idFirma = ViafirmaClientFactory.GetInstance().PrepareFirmaWithTypeFileAndFormatSign("FicheroEjemplo.xml", typeFile.XML, typeFormatSign.XADES_EPES_ENVELOPED, datos_a_firmar);
            idFirma = ViafirmaClientFactory.GetInstance().enabledMultiSign(idFirma);
            Session.Add("idMultifirma", idFirma);


            System.Console.Write("idTemporalFirma: " + idFirma);

            // Iniciamos el proceso de firma redireccionando al usuario a Viafirma..
            // Esto redireccionará al usuario a Viafirma para la firma del documento con el 
            // identificador de firma indicado.
            clienteViafirma.Sign(idFirma);
        }
    }
}
