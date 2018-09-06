using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using Viafirma;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model.Response;

namespace EjemploWebViafirmaClientDotNet
{
    public partial class exampleSSLClientAuthResult : Page
    {
        string operationId;

        protected async void Page_Load(object sender, EventArgs e)
        {
            operationId = Request.QueryString["operationId"];

            CertificateValidationResponse response = new CertificateValidationResponse();
            List<CertificateValidationResponse> list = new List<CertificateValidationResponse>();
            CertificateValidationResponse certificateValidationResponse = await ViafirmaClientFactory.GetInstance().GetCertificateValidationResponse(operationId, HttpContext.Current.Session.SessionID);
            list.Add(certificateValidationResponse);

            DataListResult.DataSource = list;
            DataListResult.DataBind();
        }
    }
}