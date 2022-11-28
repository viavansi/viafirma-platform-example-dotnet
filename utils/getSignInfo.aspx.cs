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
    public partial class getSignInfo : System.Web.UI.Page
    {
        public firmaInfoViafirma infoFirma;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void GetFirmaButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            string path = Environment.CurrentDirectory;
            FileStream fs = File.OpenRead(path + "\\resources\\prueba.xml");
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // Enviamos a firmar el documento al servidor y nos devuelve el identificador de la firma.
            String idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.xml", datos_a_firmar, Global.ALIAS_CERT, Global.PASS_CERT, typeFile.XML, typeFormatSign.XADES_EPES_ENVELOPED);
            // Recuperamos el elemento firmado
            byte[] documento = clienteViafirma.getDocumentoCustodiado(idFirma);
            // Y comprobamos su validez
            //infoFirma = clienteViafirma.getSignInfo;
        }
        public void ComprobarNoValidoButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            string path = Environment.CurrentDirectory;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            // Enviamos a firmar el documento al servidor y nos devuelve el identificador de la firma.
            String idFirma = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.pdf", datos_a_firmar, Global.ALIAS_CERT, Global.PASS_CERT, typeFile.PDF, typeFormatSign.PAdES_EPES);
            byte[] firmado1 = clienteViafirma.getDocumentoCustodiado(idFirma);
            //String idFirma2 = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.pdf", firmado1, Global.ALIAS, Global.PASS_CERT, typeFile.PDF, typeFormatSign.PAdES_EPES);
            //byte[] firmado2 = clienteViafirma.getDocumentoCustodiado(idFirma2);
            //String idFirma3 = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.pdf", firmado2, Global.ALIAS, Global.PASS_CERT, typeFile.PDF, typeFormatSign.PAdES_EPES);
            //byte[] firmado3 = clienteViafirma.getDocumentoCustodiado(idFirma3);

            // Y comprobamos el documento original que no esta firmado para forzar q no sea valido.
            firmaInfoViafirma infoFirma = clienteViafirma.checkSignedDocumentValidityByFileType(firmado1, typeFormatSign.PAdES_EPES);
            if (infoFirma.signed)
            {
                if (infoFirma.otherSigners == null)
                {
                    //Solo tenemos la firma representada por infoFirma
                    int numeroDeFirmas = 1;
                }
                else
                {
                    //El numero de firmas es el numero de otros firmantes más el representado por infoFirma
                    int numeroDeFirmas = infoFirma.otherSigners.Length + 1;
                }
            }
            else
            {
                int numeroDeFirmas = 0;
            }
            
        }
    }
}
