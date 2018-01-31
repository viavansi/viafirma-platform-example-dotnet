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

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class signatureBatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void FirmarLotesUserButton_Click(object sender, EventArgs e)
        {
            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar_pdf = new byte[fs.Length];
            fs.Read(datos_a_firmar_pdf, 0, datos_a_firmar_pdf.Length);

            // Enviamos a firmar el documento
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();
            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");
            // Generamos un id temporal de lote para añadir documentos en él 
            string idLote = clienteViafirma.iniciarFirmaEnLotes(typeFormatSign.XADES_EPES_ENVELOPED);
            System.Console.Write("idTemporalLote: " + idLote);
            // Añadimos un documento para firmar
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "DocumentoEjemplo1.txt", typeFile.XML, datos_a_firmar);
            // Añadimos otro documento para firmar
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "DocumentoEjemplo2.txt", typeFile.XML, datos_a_firmar);
            // Añadimos otro documento para firmar
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "DocumentoEjemplo3.txt", typeFile.PDF, datos_a_firmar_pdf);
            // Añadimos otro documento para firmar
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "DocumentoEjemplo4.txt", typeFile.PDF, datos_a_firmar_pdf);


            //Logica del ejemplo para no mostrar el boton de multifirma 
            Session["multi"] = null;
            //Logica del ejemplo para descagar el fichero con la extension correcta
            Session["extension"] = ".xml";

            // Firmamos
            clienteViafirma.Sign(idLote);
        }
    }
}
