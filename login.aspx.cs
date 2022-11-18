using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Viafirma;
using System.IO;
using System.Globalization;
using ViafirmaClientDotNet.Helpers.Policy;
//using log4net;

namespace EjemploWebViafirmaClientDotNet
{

    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Autenticar_Click(object sender, EventArgs e)
        {
            
            // Iniciamos el proceso de autenticar redireccionando el usuario a Viafirma.
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            clienteViafirma.AddOptionalRequest(ViafirmaClient.AUTO_SEND);
            clienteViafirma.AddOptionalRequest(ViafirmaClient.PEM);

            policy pol = new policy();


            clienteViafirma.AuthWithPolicy(pol);
        }
    }
}