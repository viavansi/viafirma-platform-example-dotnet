using System;
using System.Web.UI.WebControls;

using System.IO;
using Viafirma;
using System.Reflection;
using ViafirmaClientDotNet.Helpers.Policy;

namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class signatureXML : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FirmarUserXMLButton_Click(object sender, EventArgs e)
        {
            typeFormatSign typeFormatSign = typeFormatSign.XMLDSIG;
            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "XMLDSIG":
                    typeFormatSign = typeFormatSign.XMLDSIG;
                    break;
                case "XADES_BES":
                    typeFormatSign = typeFormatSign.XADES_BES;
                    break;
                case "XADES_EPES":
                    typeFormatSign = typeFormatSign.XADES_EPES_ENVELOPED;
                    break;
                case "XADES_T":
                    typeFormatSign = typeFormatSign.XADES_T_ENVELOPED;
                    break;
                case "XADES_XL":
                    typeFormatSign = typeFormatSign.XADES_XL_ENVELOPED;
                    break;
                case "XADES_A":
                    typeFormatSign = typeFormatSign.XADES_A_ENVELOPED;
                    break;
            }


            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_XML_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            try
            {
                ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();
                string idFirma;

                //Creamos el objeto documento con los datos a firmar
                documento doc = new documento();
                doc.nombre = "prueba.xml";
                doc.datos = datos_a_firmar;
                doc.typeFormatSign = typeFormatSign;
                doc.tipo = typeFile.XML;

                //Creamos la politica de firma
                policy pol = PolicyUtil.newPolicy(typeFormatSign, typeSign.ENVELOPED);


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
    }
}
