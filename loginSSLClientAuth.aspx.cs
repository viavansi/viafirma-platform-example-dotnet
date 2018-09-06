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
using ViafirmaClientDotNet.Handler.DirectDesktop.Model.Response;

namespace EjemploWebViafirmaClientDotNet
{
    public partial class loginSSLClientAuth : System.Web.UI.Page   
    {
        public SSLClientAuthOperationResponse sslAuthOperation;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public async void Autenticar_SSL_ClickAsync(object sender, EventArgs e)
        {
            string callbackUrl = "";
            string currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            int index = currentUrl.LastIndexOf("/");
            if (index > 0)
            {
                callbackUrl = currentUrl.Substring(0, index) + "/exampleSSLClientAuthResult.aspx";
                Console.Write("destination url: " + callbackUrl);
            }

            // Iniciamos el proceso de autenticar redireccionando el usuario a Viafirma.
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            sslAuthOperation = await clienteViafirma.PrepareSSLClientAuthAsync(callbackUrl);
        }
    }
}