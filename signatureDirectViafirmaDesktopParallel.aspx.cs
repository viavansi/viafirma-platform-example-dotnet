using System;
using System.IO;
using System.Reflection;
using System.Web;
using Viafirma;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model.Request;
using ViafirmaClientDotNet.Helpers.Policy;

namespace EjemploWebViafirmaClientDotNet
{
    public partial class signatureDirectViafirmaDesktopParallel : System.Web.UI.Page
    {
        public DirectDesktopInvocation desktopInvocation;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public async void Firmar_ClickAsync(object sender, EventArgs e)
        {
            // Iniciamos el proceso de autenticar redireccionando el usuario a Viafirma.
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            string sessionId = HttpContext.Current.Session.SessionID;
            string[] languages = HttpContext.Current.Request.UserLanguages;
            string locale = languages[0];

            AuthOperationRequest authRequest = new AuthOperationRequest();
            authRequest.AutoSend = true;
            authRequest.SessionId = sessionId;

            int fileCount = 20;

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.PAdES_BASIC, typeSign.ATTACHED);
            //Creamos el rectangle
            rectangle r = PolicyUtil.newRectangle(40, 10, 550, 75);
            //Seteamos la politica
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_PAGE, "1");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_RECTANGLE, PolicyUtil.rectangleToJson(r));
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_HIDE_STATUS, "true");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_TEXT, "Firmado por [CN] con DNI [NIF]\ntrabajador de [O]");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_TYPE, "QR-BAR-H");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_ROTATION_ANGLE, "270");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_REASON, "Example Sign");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_CONTACT, "Contact Person Name");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_LOCATION, "Tomares");

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            OperationFile file = new OperationFile();
            file.Filename = "example.pdf";
            file.Base64Content = System.Convert.ToBase64String(datos_a_firmar);
            file.Policy = pol;

            desktopInvocation = await clienteViafirma.InitPrepareParallelSignatureOperationViafirmaDesktopAsync(authRequest, fileCount, sessionId, locale);
            System.Console.Write("OperationId: " + desktopInvocation.OperationId);

            for (int i = 1; i <= fileCount; i++)
            {
                await clienteViafirma.PrepareSignatureOperationViafirmaDesktopAddOperationFileAsync(desktopInvocation.OperationId, file);
            }

            await clienteViafirma.PrepareSignatureOperationViafirmaDesktopFinishAsync(desktopInvocation.OperationId);
        }
    }
}