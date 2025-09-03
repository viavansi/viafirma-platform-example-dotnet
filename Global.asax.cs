using System;
using System.Web.SessionState;
using Viafirma;

namespace EjemploWebViafirmaClientDotNet
{
    public class Global : System.Web.HttpApplication
    {



        // URL en la que se encuentra el servidor de Viafirma Utilizado.
        //public static string URL_VIAFIRMA = "https://services.viafirma.com/viafirma/tokenConnector";
        public static string URL_VIAFIRMA = "https://sandbox-platform.viafirma.com/platform/tokenConnector";
        //public static string URL_VIAFIRMA = "https://ci.viafirma.com/platform/tokenConnector";
        //public static string URL_VIAFIRMA = "https://rquintero.viavansi.com/viafirma/tokenConnector";
        //public static string URL_VIAFIRMA = "https://firmades.sergas.es/firmaPlatform/tokenConnector";

        // URL en la que se encuentra el WS del servidor de Viafirma Utilizado.
        //public static string URL_WS_VIAFIRMA = "https://services.viafirma.com/viafirma";
        public static string URL_WS_VIAFIRMA = "https://sandbox-platform.viafirma.com/platform";
        //public static string URL_WS_VIAFIRMA = "https://ci.viafirma.com/platform/viafirma";
        //public static string URL_WS_VIAFIRMA = "https://rquintero.viavansi.com/viafirma";
        //public static string URL_WS_VIAFIRMA = "https://firmades.sergas.es/firmaPlatform";

        //Estos parametros se encuentran en el codigo únicamente por el ejemplo:
        //Alias del certificado instalado en servidor
        public static string ALIAS_CERT = "xnoccio";
        //Pass del certificado instalado en servidor
        public static string PASS_CERT = "12345";

        public static string API_KEY = "xnoccio";
        //public static string API_KEY = "FIRMATESTDES";

        public static string PASS_KEY = "12345";
        //public static string PASS_KEY = "1WKKTLQ9.";

        public static String DEMO_FILE_PDF_PATH { get; set; }
        public static String DEMO_P12_PATH { get; set; }
        public static String DEMO_FILE_PDF_PATH_10_PAGS { get; set; }
        public static String DEMO_FILE_PDF_PATH_10_PAGS_SIGNED { get; set; }
        public static String DEMO_FILE_XML_PATH { get; set; }
        public static String DEMO_FILE_TXT_PATH { get; set; }
        public static String DEMO_IMAGE_LOGO_PATH { get; set; }
        public static String DEMO_STAMPER_PATH { get; set; }
        public static String DEMO_CADES_T_PATH { get; set; }
        public static String DEMO_FILE_PADES_LTV_BIG { get; set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            int maxSize = 50;
            //ViafirmaClientFactory.Init(URL_VIAFIRMA, URL_WS_VIAFIRMA, "xnoccio", "12345", maxSize);
            //ViafirmaClientFactory.Init(URL_VIAFIRMA, URL_WS_VIAFIRMA, "dev_orbit", "YHTYBKTASGKHF0NC77NJC13F027RC", maxSize);

            ConfigProperties configProperties = new ConfigProperties();
            configProperties.ViafirmaPublicUrl = URL_VIAFIRMA;
            configProperties.ViafirmaWSUrl = URL_WS_VIAFIRMA;
            configProperties.ApplicationID = API_KEY;
            configProperties.ApplicationPass = PASS_KEY;
            configProperties.MaxFileSizeToSign = maxSize;
            //configProperties.ReturnUrl = "http://localhost:58082";

            ViafirmaClientFactory.Init(configProperties);

            ////Configure proxy
            //WebProxy myProxy = new WebProxy();
            //Uri newUri = new Uri("http://localhost:8888");
            //// Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
            //myProxy.Address = newUri;
            //// Create a NetworkCredential object and associate it with the 
            //// Proxy property of request object.
            //myProxy.Credentials = new NetworkCredential("1", "1");
            //WebRequest.DefaultWebProxy = myProxy;


            // Path del fichero de ejemplo usado en la firma
            // Se hace la distinción para el caso Windows/Unix                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          


            string appPath = Environment.CurrentDirectory;
            DEMO_FILE_PDF_PATH = "EjemploWebViafirmaClientDotNet.resources.exampleSign.pdf";
            //DEMO_P12_PATH = "EjemploWebViafirmaClientDotNet.resources.xnoccio.p12";
            DEMO_P12_PATH = "EjemploWebViafirmaClientDotNet.resources.cer.pfx";
            DEMO_FILE_PDF_PATH_10_PAGS = "EjemploWebViafirmaClientDotNet.resources.Loremipsum_10_pags.pdf";
            DEMO_FILE_PDF_PATH_10_PAGS_SIGNED = "EjemploWebViafirmaClientDotNet.resources.10_pag_firmado.pdf";
            DEMO_FILE_XML_PATH = "EjemploWebViafirmaClientDotNet.resources.absis.xml";
            DEMO_FILE_TXT_PATH = "EjemploWebViafirmaClientDotNet.resources.ejemplo.txt";
            DEMO_IMAGE_LOGO_PATH = "EjemploWebViafirmaClientDotNet.resources.viafirma-400x400.png";
            DEMO_STAMPER_PATH = "EjemploWebViafirmaClientDotNet.resources.stamperWatermark.png";
            DEMO_CADES_T_PATH = "EjemploWebViafirmaClientDotNet.resources.AdjuntoALaPropueta.docx";
            DEMO_FILE_PADES_LTV_BIG = "EjemploWebViafirmaClientDotNet.resources.598MB.pdf";
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}