using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Viafirma;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model.Response;

namespace EjemploWebViafirmaClientDotNet
{
    public partial class exampleAuthenticationViafirmaDesktopResult : Page
    {
        string operationId;

        protected async void Page_Load(object sender, EventArgs e)
        {
            operationId = Request.QueryString["operationId"];
            string sessionId = HttpContext.Current.Session.SessionID;

            CertificateValidationResponse response = new CertificateValidationResponse();
            List<CertificateValidationResponse> list = new List<CertificateValidationResponse>();
            CertificateValidationResponse certificateValidationResponse = await ViafirmaClientFactory.GetInstance().GetCertificateValidationResponse(operationId, sessionId);
            list.Add(certificateValidationResponse);

            DataListResult.DataSource = list;
            DataListResult.DataBind();
        }
    }
}