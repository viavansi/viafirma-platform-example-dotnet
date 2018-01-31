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
using ViafirmaClientDotNet.Helpers.Policy;
using System.Reflection;


namespace EjemploWebViafirmaClientDotNet.firmaUser
{
    public partial class signatureDigitalized_01 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void InitDigitalizedButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            //recuperamos la clave pública de encriptación
            Stream pemStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EjemploWebViafirmaClientDotNet.resources.xnoccio.pem");
            String pem =  new StreamReader(pemStream).ReadToEnd();

            // En algunos casos, por ejemplo en el arranque de la aplicación, puede ser interesante comprobar conectividad
            System.Console.Write(clienteViafirma.ping("Prueba Conexión") + "\n");

            //Creamos el objeto documento con los datos a firmar
            documento doc = new documento();
            doc.nombre = "signatureDigitalized.pdf";
            doc.datos = datos_a_firmar;
            doc.typeFormatSign = typeFormatSign.DIGITALIZED_SIGN;
            doc.tipo = typeFile.PDF;

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.DIGITALIZED_SIGN, typeSign.ATTACHED);

            //Indica el color de fondo de la pantalla (para aquellos dispositivos de firma que lo permitan - dispositivos móviles)
//            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_BACK_COLOUR, "#0000FF");

            //Indica el color de la firma de la pantalla (para aquellos dispositivos de firma que lo permitan - dispositivos móviles)
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_COLOUR, "#FF0000");

            //Indica el texto de ayuda que aparece en la pantalla 
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_HELP_TEXT, "Texto de ayuda aportado por el integrador");

            //Logo a mostrar (para aquellos dispositivos de firma que lo permitan - dispositivos móviles )
//            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_LOGO, logoStamp);

            //Rectangulo donde se fija la firma
//            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_RECTANGLE, new Rectangle(400,60,160,120));

            //Biometric alias - pass son utilizados para firmar los datos biometricos en servidor (el alias debe existir en el servidor) 
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_BIOMETRIC_ALIAS, "xnoccio");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_BIOMETRIC_PASS, "12345");

            //Clave publica en formato pem con la que cifrar los datos biometricos, si no se indica no se cifran
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_BIOMETRIC_CRYPTO_PEM, pem);

            //Pagina donde insertar la firma, -1 para la ultima pagina, si no se indica, en iOS/Android se permitirá seleccionar la pagina/s manualmente, en tabletas digitalizadoras se pondrá en la última página
//            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_PAGE, -1); 

            //Firma en servidor del documento PDF (en este ejemplo se usa el mismo certificado que en la firma en servidor de los datos biométricos)
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_ALIAS, "xnoccio");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGN_PASS, "12345");

            //Información adicional mapeada como título de firma (por ejemplo el nombre del firmante)
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_SIGNATURE_INFO, "Firmante de ejemplo");

            //Estados permitidos para localización GPS (para aquellos dispositivos de firma que lo permitan - dispositivos móviles)
//            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_LOCATION_STATUS, "0");

            //Indica los stylus permitidos (para aquellos dispositivos de firma que lo permitan - dispositivos móviles)
//            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_PRESSURE_STYLUS, "");

            //Indica si se muestra o no valores de presión (para aquellos dispositivos de firma que lo permitan - dispositivos móviles)
//            PolicyUtil.AddParameter(pol, PolicyParams.DIGITALIZED_PRESSURE_INFO, "");



            // Registramos el documento que deseamos firmar. Obteniendo un identificador temporal.
            // Este identificador temporal no es necesario que sea almacenado ya que sólo tiene validez durante el proceso de firma.
            string idTemporalFirma = clienteViafirma.PrepareSignWithPolicy(pol, doc);

            System.Console.Write("idTemporalFirma: " + idTemporalFirma);

            //Logica del ejemplo para descagar el fichero con la extension correcta
            Session["extension"] = ".pdf";

            // Iniciamos el proceso de firma redireccionando al usuario a Viafirma..
            // Esto redireccionará al usuario a Viafirma para la firma del documento con el 
            // identificador de firma indicado.
            clienteViafirma.Sign(idTemporalFirma);
        }

    }
}
