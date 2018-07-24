using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using Viafirma;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model.Response;

namespace EjemploWebViafirmaClientDotNet
{
    public partial class exampleSignatureViafirmaDesktopResult : System.Web.UI.Page
    {
        string operationId;

        protected async void Page_Load(object sender, EventArgs e)
        {
            operationId = Request.QueryString["operationId"];
            string sessionId = HttpContext.Current.Session.SessionID;

            SignatureResponse response = new SignatureResponse();
            List<SignatureResponse> list = new List<SignatureResponse>();
            SignatureResponse signatureResponse = await ViafirmaClientFactory.GetInstance().GetSignatureResponse(operationId, sessionId);
            list.Add(signatureResponse);

            DataListResult.DataSource = list;
            DataListResult.DataBind();
        }

        public void Download_Click(Object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;

            string signatureID = Convert.ToString(btn.CommandArgument);

            // Recuperamos la instancia del cliente
            ViafirmaClient clienteViafirma = ViafirmaClientFactory.GetInstance();

            // Recuperamos el documento original.
            documento docu = clienteViafirma.getOriginalDocument(signatureID);
            // Y lo ponemos a disposicion del usario

            Stream stream = null;
            try
            {
                // Open the file into a stream. 
                stream = new MemoryStream(docu.datos);
                // Total bytes to read: 
                long bytesToRead = stream.Length;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "documentoOriginal.xml");
                // Read the bytes from the stream in small portions. 
                while (bytesToRead > 0)
                {
                    // Make sure the client is still connected. 
                    if (Response.IsClientConnected)
                    {
                        // Read the data into the buffer and write into the 
                        // output stream. 
                        byte[] buffer = new Byte[10000];
                        int length = stream.Read(buffer, 0, 10000);
                        Response.OutputStream.Write(buffer, 0, length);
                        Response.Flush();
                        // We have already read some bytes.. need to read 
                        // only the remaining. 
                        bytesToRead = bytesToRead - length;
                    }
                    else
                    {
                        // Get out of the loop, if user is not connected anymore.. 
                        bytesToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                // An error occurred.. 
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}