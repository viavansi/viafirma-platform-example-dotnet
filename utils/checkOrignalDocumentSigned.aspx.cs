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

namespace EjemploWebViafirmaClientDotNet.utils 
{
    public partial class checkOrignalDocumentSigned : System.Web.UI.Page
    {
        public firmaInfoViafirma infoFirma;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

       public void ComprobarValidoButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // Enviamos a firmar el documento al servidor y nos devuelve el identificador de la firma.
            String idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.xml", datos_a_firmar, Global.ALIAS_CERT, Global.PASS_CERT, typeFile.XML, typeFormatSign.XADES_EPES_ENVELOPED);
            // Recuperamos el elemento firmado
            byte[] documento = clienteViafirma.getOriginalDocument(idFirma).datos;
            // Y comprobamos su validez
            infoFirma = clienteViafirma.checkOriginalDocumentSigned(documento, idFirma);
        }

        [Obsolete]
        public void ComprobarNoValidoButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // Enviamos a firmar el documento al servidor y nos devuelve el identificador de la firma.
            String idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.xml", datos_a_firmar, Global.ALIAS_CERT, Global.PASS_CERT, typeFile.XML, typeFormatSign.XADES_EPES_ENVELOPED);

            // Recuperamos otro documento.
            Stream fsn = assembly.GetManifestResourceStream(Global.DEMO_FILE_TXT_PATH);
            byte[] datos = new byte[fsn.Length];
            fsn.Read(datos, 0, datos.Length);

            // Y comprobamos el documento original que no esta firmado para forzar q no sea valido.
            infoFirma = clienteViafirma.checkOriginalDocumentSigned(datos, idFirma);
        }
    }
}
