using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using Viafirma;
using System.Reflection;

namespace EjemploWebViafirmaClientDotNet.utils
{
    public partial class checkCertificateByAlias : System.Web.UI.Page
    {
        public validationInfo validationInfo;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ComprobarCertificadoAliasButton_Click(object sender, EventArgs e)
        {
            //Recuperamos la instancia del cliente
            ViafirmaClient viafirmaClient = ViafirmaClientFactory.GetInstance();
            //Recuperamos el alias introducido en el input text
            String alias = Request.Form["aliasCert"];
            validationInfo = viafirmaClient.checkCertificateByAlias(alias);

        }
    }
}