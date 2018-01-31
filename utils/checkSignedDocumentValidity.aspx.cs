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
using ViafirmaClientDotNet.Helpers.Verify;

namespace EjemploWebViafirmaClientDotNet.utils
{
    public partial class checkSignedDocumentValidity : System.Web.UI.Page
    {
        public firmaInfoViafirma info;
        public string idFirma;

        protected void Page_Load(object sender, EventArgs e)
        {
            idFirma = "";
            info = null;
        }
        public void ComprobarValidoButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // Enviamos a firmar el documento al servidor y nos devuelve el identificador de la firma.
            idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.pdf", datos_a_firmar, Global.ALIAS, Global.PASS_CERT, typeFile.PDF, typeFormatSign.PDF_PKCS7);
            // Recuperamos el elemento firmado
            byte[] documentoFirmado = clienteViafirma.getDocumentoCustodiado(idFirma);
            // Y comprobamos su validez
            info = clienteViafirma.checkSignedDocumentValidityByFileType(documentoFirmado, typeFormatSign.PDF_PKCS7);
        }
        public void ComprobarNoValidoButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // Enviamos a firmar el documento al servidor y nos devuelve el identificador de la firma.
            idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.pdf", datos_a_firmar, Global.ALIAS, Global.PASS_CERT, typeFile.PDF, typeFormatSign.PDF_PKCS7);

            
            // Y comprobamos el documento original que no esta firmado para forzar q no sea valido.
            info = clienteViafirma.checkSignedDocumentValidityByFileType(datos_a_firmar, typeFormatSign.PDF_PKCS7);
        }
    }
}
