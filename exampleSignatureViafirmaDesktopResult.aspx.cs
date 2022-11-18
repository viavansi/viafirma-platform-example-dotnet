using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using Viafirma;
using ViafirmaClientDotNet.Handler.DirectDesktop.Model.Response;

namespace EjemploWebViafirmaClientDotNet
{
    public class StringValue
    {
        public StringValue(string s)
        {
            _value = s;
        }
        public string Id { get { return _value; } set { _value = value; } }
        string _value;
    }

    public partial class exampleSignatureViafirmaDesktopResult : System.Web.UI.Page
    {
        public string operationId;
        List<StringValue> SignatureIds = new List<StringValue>();

        protected async void Page_Load(object sender, EventArgs e)
        {
            operationId = Request.QueryString["operationId"];
            string sessionId = HttpContext.Current.Session.SessionID;

            if (!String.IsNullOrEmpty(operationId))
            {
                SignatureResponse response = new SignatureResponse();
                List<SignatureResponse> list = new List<SignatureResponse>();
                SignatureResponse signatureResponse = await ViafirmaClientFactory.GetInstance().GetSignatureResponse(operationId, sessionId);

                string signatureId = signatureResponse.signatureId;

                // Si el id contiene el carácter ";" es una firma múltiple
                if (signatureId.Contains(";"))
                {
                    foreach (string id in signatureId.Split(';'))
                    {
                        SignatureIds.Add(new StringValue(id));
                    }
                }
                else
                {
                    SignatureIds.Add(new StringValue(signatureId));
                }

                list.Add(signatureResponse);

                DataListResult.DataSource = list;
                DataListResult.DataBind();

                SignatureListResult.DataSource = SignatureIds;
                SignatureListResult.DataBind();
            }
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