using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Viafirma;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model.Request;
using System.Threading.Tasks;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model;

namespace EjemploWebViafirmaClientDotNet
{
    public partial class loginDirectViafirmaDesktop : System.Web.UI.Page
    {
        public DirectDesktopInvocation desktopInvocation;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public async void Autenticar_ClickAsync(object sender, EventArgs e)
        {
            // Iniciamos el proceso de autenticar redireccionando el usuario a Viafirma.
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            AuthOperationRequest request = new AuthOperationRequest();
            request.AutoSend = true;
            request.SessionId = HttpContext.Current.Session.SessionID;
            desktopInvocation = await clienteViafirma.PrepareAuthForDirectDesktopAsync(request);
        }
    }
}