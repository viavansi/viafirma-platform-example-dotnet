using System;
using System.Web.UI.WebControls;

using System.IO;
using Viafirma;
using System.Reflection;
using ViafirmaClientDotNet.Helpers.Policy;
using System.Text;

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class firmarHash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FirmarUserXMLButton_Click(object sender, EventArgs e)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            string originalHash = System.Convert.ToBase64String(datos_a_firmar);

            try
            {
                ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();
                string idFirma;

                //Creamos el objeto documento con los datos a firmar
                documento doc = new documento();
                doc.nombre = "prueba.xml";
                doc.datos = Encoding.ASCII.GetBytes(originalHash);
                doc.typeFormatSign = typeFormatSign.XADES_EPES_ENVELOPED;
                doc.tipo = typeFile.hash;

                //Creamos la politica de firma
                policy pol = PolicyUtil.newPolicy(typeFormatSign.XADES_EPES_ENVELOPED, typeSign.ENVELOPED);


                // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
                // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
                idFirma = clienteViafirma.PrepareSignWithPolicy(pol, doc);

                //Logica del ejemplo para descagar el fichero con la extension correcta
                Session["extension"] = ".xml";

                clienteViafirma.Sign(idFirma);
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

        }


        public void FirmarUserCadesButton_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_CADES_T_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            string originalHash = System.Convert.ToBase64String(datos_a_firmar);

            try
            {
                ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();
                string idFirma;

                //Creamos el objeto documento con los datos a firmar
                documento doc = new documento();
                doc.nombre = "hashSigned";
                doc.datos = Encoding.ASCII.GetBytes(originalHash);
                doc.typeFormatSign = typeFormatSign.CAdES_EPES;
                doc.tipo = typeFile.hash;

                //Creamos la politica de firma
                policy pol = PolicyUtil.newPolicy(typeFormatSign.CAdES_EPES, typeSign.ENVELOPED);


                // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
                // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
                idFirma = clienteViafirma.PrepareSignWithPolicy(pol, doc);

                clienteViafirma.Sign(idFirma);
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }
    }
}
