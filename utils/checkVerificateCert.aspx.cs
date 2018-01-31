using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using Viafirma;
using System.Reflection;
using System.Text;

namespace EjemploWebViafirmaClientDotNet.utils
{
    public partial class checkVerificateCert : System.Web.UI.Page
    {
        public certificateResponse certificateResponse;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ComprobarCertificadoPemButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient viafirmaClient = ViafirmaClientFactory.GetInstance();
            //Recuperamos el pem introducido en el textarea
            String pem = Request.Form["pem"];
            byte[] pemBytes = Encoding.ASCII.GetBytes(pem);
            certificateResponse = viafirmaClient.verifyCertificate(pemBytes);

        }
    }
}