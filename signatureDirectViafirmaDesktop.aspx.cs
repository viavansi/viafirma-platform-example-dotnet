using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viafirma;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model.Request;
using ViafirmaClientDotNet.Helpers.Policy;

namespace EjemploWebViafirmaClientDotNet
{
    public partial class signatureDirectViafirmaDesktop : System.Web.UI.Page 
    {
        public DirectDesktopInvocation desktopInvocation;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public async void Firmar_ClickAsync(object sender, EventArgs e)
        {
            // Iniciamos el proceso de autenticar redireccionando el usuario a Viafirma.
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            AuthOperationRequest authRequest = new AuthOperationRequest();
            authRequest.AutoSend = true;

            string sessionId = HttpContext.Current.Session.SessionID;
            string[] languages = HttpContext.Current.Request.UserLanguages;
            string locale = languages[0];

            //Creamos la politica de firma
            policy pol = PolicyUtil.newPolicy(typeFormatSign.PAdES_BASIC, typeSign.ATTACHED);
            //Creamos el rectangle
            rectangle r = PolicyUtil.newRectangle(40, 10, 550, 75);
            //Seteamos la politica
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_PAGE, "1");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_RECTANGLE, PolicyUtil.rectangleToJson(r));
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_HIDE_STATUS, "true");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_TEXT, "Firmado por [CN] con DNI [SERIALNUMBER]\ntrabajador de [O] en el departamento de [OU]");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_TYPE, "QR-BAR-H");
            PolicyUtil.AddParameter(pol, PolicyParams.DIGITAL_SIGN_STAMPER_ROTATION_ANGLE, "90");

            // Recuperamos el documento a firmar.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream fs = assembly.GetManifestResourceStream(Global.DEMO_FILE_PDF_PATH);
            byte[] datos_a_firmar = new byte[fs.Length];
            fs.Read(datos_a_firmar, 0, datos_a_firmar.Length);

            OperationFile file = new OperationFile();
            file.Filename = "example.pdf";
            file.Base64Content = System.Convert.ToBase64String(datos_a_firmar);

            List<OperationFile> files = new List<OperationFile>();
            files.Add(file);

            desktopInvocation = await clienteViafirma.PrepareSignatureForDirectDesktopAsync(authRequest, files, pol, sessionId, locale);
            System.Console.Write("OperationId: " + desktopInvocation.OperationId);
        }
    }
}