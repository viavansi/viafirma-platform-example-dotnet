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
using ViafirmaClientDotNet.Helpers.Policy;

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class signatureCadesTDetached : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FirmarUserCadesTDetached_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos los documentos a firmar.

            //Docx de ejemplo
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fsdocx = assembly.GetManifestResourceStream(Global.DEMO_CADES_T_PATH);
            byte[] datos_a_firmarDocx = new byte[fsdocx.Length];
            fsdocx.Read(datos_a_firmarDocx, 0, datos_a_firmarDocx.Length);

            //XML de ejemplo
            Stream fsxml = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmarXml = new byte[fsdocx.Length];
            fsxml.Read(datos_a_firmarXml, 0, datos_a_firmarXml.Length);

            //Creamos el objeto documento del docx con los datos a firmar en CAdES_T
            documento docx = new documento();
            docx.nombre = "firmaDocx.CAdES";
            docx.datos = datos_a_firmarDocx;
            docx.typeFormatSign = typeFormatSign.CAdES_T;
            docx.tipo = typeFile.doc;


            //Creamos el objeto documento del xml con los datos a firmar en XAdES_T
            documento xml = new documento();
            xml.nombre = "firmaXml.XAdES";
            xml.datos = datos_a_firmarXml;
            xml.typeFormatSign = typeFormatSign.XADES_T_ENVELOPED;
            xml.tipo = typeFile.xlm;

            // En algunos casos, por ejemplo en el arranque de la aplicación puede ser interesante
            // Comprobar que efectivamente el servidor de firma está disponible
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            // Registramos los documento que deseamos firmar en un listado.
            List<string> idsFirma = new List<string>();

            //Creamos la politica de firma del docx en CAdES
            policy pol = PolicyUtil.newPolicy(typeFormatSign.CAdES_T, typeSign.DETACHED);
            // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
            // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
            string idTemporalFirmaCAdES = clienteViafirma.PrepareSignWithPolicy(pol, docx);


            //Creamos la politica de firma del xml en XAdES
            pol = PolicyUtil.newPolicy(typeFormatSign.XADES_T_ENVELOPED, typeSign.DETACHED);
            // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
            // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
            string idTemporalFirmaXAdES = clienteViafirma.PrepareSignWithPolicy(pol, xml);


            //Añadimos los ids temporales de las firmas que hemos preparado
            idsFirma.Add(idTemporalFirmaCAdES);
            idsFirma.Add(idTemporalFirmaXAdES);


            // Iniciamos el proceso de firma redireccionando al usuario a Viafirma..
            // Esto redireccionará al usuario para la firma de los documentos 
            // con una sola intervención del usuario.
            clienteViafirma.solicitarFirmasIndependientes(idsFirma.ToArray());
        }
    }
}
