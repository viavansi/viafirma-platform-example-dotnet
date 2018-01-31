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

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class signatureLoop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FirmarUserLoopButton_Click(object sender, EventArgs e)
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

           
            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            // Registramos los documento que deseamos firmar en un listado.
            List<string> idsFirma = new List<string>();
            
            // Este listado puede incluir varios tipos distintos de firma dentro del proceso.
            // Archivos sin firmar:
            string idTemporalPDF = clienteViafirma.PrepareFirmaWithTypeFileAndFormatSign("FicheroEjemploPDF.pdf", typeFile.PDF, typeFormatSign.PDF_PKCS7, datos_a_firmarPDF);
            string idTemporalXML = clienteViafirma.PrepareFirmaWithTypeFileAndFormatSign("FicheroEjemploXML.xml", typeFile.XML, typeFormatSign.XADES_EPES_ENVELOPED, datos_a_firmarXML);
            string idTemporalPDF2 = clienteViafirma.PrepareFirmaWithTypeFileAndFormatSign("FicheroEjemploPDF.pdf", typeFile.PDF, typeFormatSign.PDF_PKCS7, datos_a_firmarPDF);
            string idTemporalPDF3 = clienteViafirma.PrepareFirmaWithTypeFileAndFormatSign("FicheroEjemploPDF.pdf", typeFile.PDF, typeFormatSign.PDF_PKCS7, datos_a_firmarPDF);
            string idTemporalPDF4 = clienteViafirma.PrepareFirmaWithTypeFileAndFormatSign("FicheroEjemploPDF.pdf", typeFile.PDF, typeFormatSign.PDF_PKCS7, datos_a_firmarPDF);
            string idTemporalPDF5 = clienteViafirma.PrepareFirmaWithTypeFileAndFormatSign("FicheroEjemploPDF.pdf", typeFile.PDF, typeFormatSign.PDF_PKCS7, datos_a_firmarPDF);
            string idTemporalPDF6 = clienteViafirma.PrepareFirmaWithTypeFileAndFormatSign("FicheroEjemploPDF.pdf", typeFile.PDF, typeFormatSign.PDF_PKCS7, datos_a_firmarPDF);

            idsFirma.Add(idTemporalPDF);
            idsFirma.Add(idTemporalPDF2);
            idsFirma.Add(idTemporalPDF3);
            idsFirma.Add(idTemporalPDF4);
            idsFirma.Add(idTemporalPDF5);
            idsFirma.Add(idTemporalPDF6);
            idsFirma.Add(idTemporalXML);

            // Archivos de lote:
            string idLote = clienteViafirma.iniciarFirmaEnLotes(typeFormatSign.XADES_EPES_ENVELOPED);
            
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "LoteEjemplo1.pdf", typeFile.PDF, datos_a_firmarPDF);
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "LoteEjemplo2.xml", typeFile.XML, datos_a_firmarXML);
            clienteViafirma.addDocumentoFirmaEnLote(idLote, "LoteEjemplo3.txt", typeFile.TXT, datos_a_firmarTXT);
            
            idsFirma.Add(idLote);

            // Archivos ya firmados:
            // string idFirmado = clienteViafirma.signByServerWithTypeFileAndFormatSign("FicheroEjemploServer.pdf", datos_a_firmarPDF, aliasCert, passCert, typeFile.PDF, typeFormatSign.PDF_PKCS7);

            // idsFirma.Add(idFirmado);


            // Iniciamos el proceso de firma redireccionando al usuario a Viafirma..
            // Esto redireccionará al usuario para la firma de los documentos 
            // con una sola intervención del usuario.
            clienteViafirma.solicitarFirmasIndependientes(idsFirma.ToArray());
        }
    }
}
