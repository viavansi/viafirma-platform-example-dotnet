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
using System.IO;
using Viafirma;
using System.Reflection;


namespace EjemploWebViafirmaClientDotNet.utils
{
    public partial class getOriginalDocumentsIds : System.Web.UI.Page
    {
        public System.IO.Stream stream = null;
        public List<documento> docuList;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        public void GetOriginalDocumentIdsButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos los documentos a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fsPDF = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmarPDF = new byte[fsPDF.Length];
            fsPDF.Read(datos_a_firmarPDF, 0, datos_a_firmarPDF.Length);

            Stream fsXML = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmarXML = new byte[fsXML.Length];
            fsXML.Read(datos_a_firmarXML, 0, datos_a_firmarXML.Length);

            Stream fsTXT = assembly.GetManifestResourceStream(Global.DEMO_FILE_TXT_PATH);
            byte[] datos_a_firmarTXT = new byte[fsTXT.Length];
            fsTXT.Read(datos_a_firmarTXT, 0, datos_a_firmarTXT.Length);

            // Creamos el lote:
            string idLote = clienteViafirma.iniciarFirmaEnLotes(typeFormatSign.XADES_EPES_ENVELOPED);

            // Agregamos los documentos al lote:
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "LoteEjemplo1.pdf", typeFile.PDF, datos_a_firmarPDF);
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "LoteEjemplo2.xml", typeFile.XML, datos_a_firmarXML);
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "LoteEjemplo3.txt", typeFile.TXT, datos_a_firmarTXT);

            // Y enviamos a firmar el lote de documentos al servidor y obtenemos el identificador final de la firma.
            string id = clienteViafirma.signByServerEnLotes(idLote, Global.ALIAS, Global.PASS_CERT);

            string[] listadoIds = clienteViafirma.getOriginalDocumentIds(id);
            docuList = new List<documento>();
            foreach(string idOrig in listadoIds){
                documento doc = clienteViafirma.getOriginalDocument(idOrig);
                docuList.Add(doc);
            }
        }
    }
}
